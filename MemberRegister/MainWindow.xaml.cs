using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Threading;
using System.Data.SqlClient;
using System.Configuration;
using Dapper;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using GlobalUtils;
using System.IO;
using System.Net;

namespace MemberRegister
{
    /// <summary>
    /// MainWindow.xaml 的互動邏輯
    /// </summary>
    public partial class MainWindow : Window
    {
        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["bitjectConnectionString"].ConnectionString);

        string personal_id_md5 = ConfigurationManager.ConnectionStrings["personalIdMd5"].ConnectionString;

        string idCardImgPath = ConfigurationManager.ConnectionStrings["idCardImgPath"].ConnectionString;

        public MainWindow()
        {
            InitializeComponent();

            Work();
        }

        private void Work()
        {
            new Thread(() =>
            {
                while (true)
                {
                    var i = conn.Query("select id, email, firstName, lastName, personalId, nationNumber, phoneNumber, nationCode, sex, birthday from member where registerStatus='1'").ToList();

                    if (i.Count > 0)
                    {
                        //var json = JsonConvert.SerializeObject(i);
                        JArray ja = new JArray();

                        foreach (var item in i)
                        {
                            var fs = new FileStream(GetIdCardImgPath(item.id), FileMode.Open);
                            byte[] img = new byte[fs.Length];
                            fs.Read(img, 0, img.Length);
                            fs.Close();

                            var fsBackSide = new FileStream(GetIdCardImgPath(item.id, true), FileMode.Open);
                            byte[] imgBackSide = new byte[fsBackSide.Length];
                            fsBackSide.Read(imgBackSide, 0, imgBackSide.Length);
                            fsBackSide.Close();


                            JToken jt = JObject.FromObject(item);

                            //jt["idCardImg"] = Convert.ToBase64String(img);
                            //jt["idcardimgbackside"] = Convert.ToBase64String(imgBackSide);
                            //Dispatcher.Invoke(()=> { textblock_msg.Text += item.id + " " + GetIdCardImgFileName(item.id,true) + "\r\n"; });
                            //Dispatcher.Invoke(() => { textblock_msg.Text += item.Value.id + " " + File.Exists(GetIdCardImgPath(item.Value.id)) + GetIdCardImgPath(item.Value.id)+ "\r\n"; });
                            ja.Add(jt);
                        }

                        string requestBody = JsonConvert.SerializeObject(ja);

                        byte[] requestBodyByte = Encoding.UTF8.GetBytes(requestBody);

                        //Dispatcher.Invoke(() => { textblock_msg.Text = requestBody; });

                        string memberRegisterUrl = "http://18.216.220.119/Project_prototype/public/api/getRegister";

                        HttpWebRequest hwr = HttpWebRequest.CreateHttp(memberRegisterUrl);

                        hwr.Method = "POST";

                        using (Stream reqStream = hwr.GetRequestStream())
                        {
                            reqStream.Write(requestBodyByte, 0, requestBodyByte.Length);
                        }

                        using (WebResponse wr = hwr.GetResponse())
                        {
                            using (StreamReader sr = new StreamReader(wr.GetResponseStream(), Encoding.UTF8, true))
                            {
                                string st = sr.ReadToEnd();

                                JToken jt = JsonConvert.DeserializeObject<JObject>(st);

                                Dispatcher.Invoke(() => { textblock_msg.Text = st; });

                                if (jt["status"].ToString() == "success")
                                {
                                    List<string> ids = new List<string>();

                                    foreach (var item in jt["data"])
                                    {
                                        if (item["status"].ToString() == "success")
                                        {
                                            ids.Add(item["id"].ToString());
                                        }
                                    }

                                    conn.Execute("update [bitject].[dbo].[member] set registerStatus='2' where id in @id", new { id = ids });
                                }
                            }
                        }
                    }
                    else
                    {
                        Dispatcher.Invoke(() => { textblock_msg.Text = "OK"; });
                    }

                    var j = conn.Query("select id from member where registerStatus='2'").ToList();

                    if (j.Count > 0)
                    {
                        JArray ja = JArray.FromObject(j);

                        string requestBody = JsonConvert.SerializeObject(ja);

                        byte[] requestBodyByte = Encoding.UTF8.GetBytes(requestBody);

                        string memberRegisterUrl = "http://18.216.220.119/Project_prototype/public/api/getRegisterRecords";

                        HttpWebRequest hwr = HttpWebRequest.CreateHttp(memberRegisterUrl);

                        hwr.Method = WebRequestMethods.Http.Post;

                        using (Stream reqStream = hwr.GetRequestStream())
                        {
                            reqStream.Write(requestBodyByte, 0, requestBodyByte.Length);
                        }

                        using (WebResponse wr = hwr.GetResponse())
                        {
                            using (StreamReader sr = new StreamReader(wr.GetResponseStream(), Encoding.UTF8, true))
                            {
                                string st = sr.ReadToEnd();

                                JToken jt = JsonConvert.DeserializeObject<JObject>(st);

                                Dispatcher.Invoke(() => { textblock_msg.Text = st; });

                                if (jt["status"].ToString() == "success")
                                {
                                    List<string> ids = new List<string>();

                                    foreach (var item in jt["data"])
                                    {
                                        if (item["status"].ToString() == "success")
                                        {
                                            ids.Add(item["id"].ToString());
                                        }
                                    }

                                    conn.Execute("update [bitject].[dbo].[member] set registerStatus='3' where id in @id", new { id = ids });
                                }
                            }
                        }
                    }

                    Thread.Sleep(10000);
                }
            })
            { IsBackground = true }.Start();
        }

        public string GetIdCardImgFileName(int memberId, bool isBackSide = false)
        {
            Security security = new Security();

            string filename = isBackSide ? "idCardBackSide" : "idCard";

            filename += memberId + "##" + personal_id_md5;

            return security.MD5Encrypt(filename) + ".jpg";
        }

        public string GetIdCardImgPath(int memberId, bool isBackSide = false)
        {
            return idCardImgPath + memberId + "\\" + GetIdCardImgFileName(memberId, isBackSide);
        }
    }
}
