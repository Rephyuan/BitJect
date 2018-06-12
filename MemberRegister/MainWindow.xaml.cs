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
        SqlConnection conn = new SqlConnection(Model.Global.GlobalVar.sql_con_str_main);

        Model.Global.GlobalFunc glbf = new Model.Global.GlobalFunc();

        Model.Member.Define memberDefine = new Model.Member.Define();

        string personal_id_md5 = Model.Global.GlobalVar.personal_id_md5;

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
                    #region memberStatus = pending

                    var i = conn.Query("select id, email, firstName, lastName, personalId, nationNumber, phoneNumber, nationCode, sex, birthday from member where registerStatus=@registerStatus", new { registerStatus = Model.Member.Define.ExchangeRegisterStatus.Pending }).ToList();

                    if (i.Count > 0)
                    {
                        JArray ja = new JArray();

                        foreach (var item in i)
                        {
                            JToken jtReq = JObject.FromObject(item);

                            jtReq["idCardImg"] = memberDefine.GetIdCardImgBase64(item.id);
                            jtReq["idCardImgBackSide"] = memberDefine.GetIdCardImgBase64(item.id, true);

                            ja.Add(jtReq);
                        }

                        string memberRegisterUrl = "http://18.216.220.119/api/getRegister";

                        string requestBody = JsonConvert.SerializeObject(ja);

                        JToken jtResult = glbf.GetHttpPostResponse(memberRegisterUrl, requestBody);

                        string responseStatus = Convert.ToString(jtResult["status"]);

                        if (responseStatus == "success")
                        {
                            List<int> idList = new List<int>();

                            int iTemp;

                            string memberRegisterStatus;

                            foreach (var item in jtResult["data"])
                            {
                                memberRegisterStatus = Convert.ToString(item["status"]);

                                if (memberRegisterStatus == "success")
                                {
                                    var s = int.TryParse(Convert.ToString(item["id"]), out iTemp);

                                    if (s) idList.Add(iTemp);
                                }
                            }

                            conn.Execute("update [bitject].[dbo].[member] set registerStatus='2' where id in @id", new { id = idList });
                        }
                    }
                    else
                    {
                        Dispatcher.Invoke(() => { textblock_msg.Text = "無帳戶需註冊"; });
                    }

                    #endregion memberStatus = pending

                    #region memberStatus = inQuere

                    var j = conn.Query("select id from member where registerStatus=@registerStatus", new { registerStatus = Model.Member.Define.ExchangeRegisterStatus.InQueue }).ToList();

                    if (j.Count > 0)
                    {
                        JArray ja = JArray.FromObject(j);

                        string queryRegisterUrl = "http://18.216.220.119/api/getRegisterRecords";

                        string requestBody = JsonConvert.SerializeObject(ja);

                        JToken jtResult = glbf.GetHttpPostResponse(queryRegisterUrl, requestBody);

                        string responseStatus = Convert.ToString(jtResult["status"]);
                        //Dispatcher.Invoke(() => { textblock_msg.Text = st; });

                        if (responseStatus == "success")
                        {
                            List<int> idList = new List<int>();

                            string memberRegisterStatus;

                            int iTemp;

                            foreach (var item in jtResult["data"])
                            {
                                memberRegisterStatus = Convert.ToString(item["status"]);

                                if (memberRegisterStatus == "success")
                                {
                                    var s = int.TryParse(Convert.ToString(item["id"]), out iTemp);

                                    if (s) idList.Add(iTemp);
                                }
                            }

                            conn.Execute("update [bitject].[dbo].[member] set registerStatus=@registerStatus where id in @id", new { id = idList , registerStatus = Model.Member.Define.ExchangeRegisterStatus.Success });
                        }
                    }
                    else
                    {
                        Dispatcher.Invoke(() => { textblock_msg.Text = "無隊列中帳戶"; });
                    }

                    #endregion memberStatus = inQuere

                    Thread.Sleep(10000);
                }
            })
            { IsBackground = true }.Start();
        }
    }
}