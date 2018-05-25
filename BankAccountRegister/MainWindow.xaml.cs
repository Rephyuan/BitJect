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
using System.IO;
using System.Net;

namespace BankAccountRegister
{
    /// <summary>
    /// MainWindow.xaml 的互動邏輯
    /// </summary>
    public partial class MainWindow : Window
    {
        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["bitjectConnectionString"].ConnectionString);

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
                    var i = conn.Query("SELECT id bankAccountId , memberId, currencyCode , bankId bankName, case when currencyCode = 'TWD' then bankBranchName else chinaMainRegionId end branchName, isNull(chinaSubRegionId,'') subBranchName,bankAccountNumber FROM [dbo].[bankAccount] where registerStatus='1'").ToList();

                    if (i.Count > 0)
                    {
                        //var json = JsonConvert.SerializeObject(i);
                        //JArray ja = JArray.FromObject(i);

                        string requestBody = JsonConvert.SerializeObject(i);

                        byte[] requestBodyByte = Encoding.UTF8.GetBytes(requestBody);

                        Dispatcher.Invoke(() => { textblock_msg.Text = requestBody; });

                        string memberRegisterUrl = "http://18.216.220.119/Project_prototype/public/api/setWithdrawBank";

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
                                            ids.Add(item["bankAccountId"].ToString());
                                        }
                                    }

                                    conn.Execute("update [bitject].[dbo].[bankAccount] set registerStatus='2' where id in @id", new { id = ids });
                                }
                            }
                        }
                    }
                    else
                    {
                        Dispatcher.Invoke(() => { textblock_msg.Text = "無帳戶須新增至隊列"; });
                    }

                    var j = conn.Query("select id bankAccountId, memberId from [bitject].[dbo].[bankAccount] where registerStatus='2'").ToList();

                    if (j.Count > 0)
                    {
                        //JArray ja = JArray.FromObject(j);

                        string requestBody = JsonConvert.SerializeObject(j);

                        byte[] requestBodyByte = Encoding.UTF8.GetBytes(requestBody);

                        string memberRegisterUrl = "http://18.216.220.119/Project_prototype/public/api/getWithdrawBankRecords";

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
                                            ids.Add(item["bankAccountId"].ToString());
                                        }
                                    }

                                    conn.Execute("update [bitject].[dbo].[bankAccount] set registerStatus='3' where id in @id", new { id = ids });
                                }
                            }
                        }
                    }

                    Thread.Sleep(10000);
                }
            })
            { IsBackground = true }.Start();
        }
    }
}
