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
using System.Transactions;

namespace WithDrawalOrderRequest
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
                    var i = conn.Query("SELECT * FROM [bitject].[dbo].[withdrawalOrder] where status='1'");

                    var idic = i.ToDictionary(x => x.id);

                    var exRate = conn.Query("SELECT currencyCode, exRate FROM [bitject].[dbo].[exchangeRate]").ToDictionary(x => x.currencyCode, x => x.exRate);

                    if (i.Count() > 0)
                    {
                        JObject request = new JObject();
                        //var json = JsonConvert.SerializeObject(i);
                        JArray ja = JArray.FromObject(i.Select(x => new { withdrawalOrderId = x.id, memberId = x.memberId, bankAccountId = x.bankAccountIdTo, currencyCode = x.currencyCodeTo, amount = x.amountTo }));

                        JObject jo = JObject.FromObject(exRate);

                        request["data"] = ja;
                        request["exchangeRate"] = jo;

                        string requestBody = JsonConvert.SerializeObject(request);

                        byte[] requestBodyByte = Encoding.UTF8.GetBytes(requestBody);

                        Dispatcher.Invoke(() => { textblock_msg.Text = requestBody; });

                        string memberRegisterUrl = "http://18.216.220.119/Project_prototype/public/api/getWithdraw";

                        HttpWebRequest hwr = WebRequest.CreateHttp(memberRegisterUrl);

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
                                    foreach (var item in jt["data"])
                                    {
                                        if (item["status"].ToString() == "success")
                                        {
                                            int id = (int)item["withdrawalOrderId"];

                                            var order = idic[id];

                                            decimal p7 = (decimal)order.p7;

                                            decimal p8 = (decimal)order.p8;

                                            decimal amountFromExternal = (decimal)item["cost"]["cost"];

                                            decimal feeRatioInExternal = (decimal)item["cost"]["deposit_fee"];

                                            decimal feeRatioOutExternal = (decimal)item["cost"]["withdraw_fee"];

                                            decimal exRateInExternal = (decimal)item["cost"]["deposit_rate"];

                                            decimal exRateOutExternal = (decimal)item["cost"]["withdraw_rate"];

                                            decimal r1 = (decimal)order.amountFrom - amountFromExternal;

                                            decimal r7 = 0;

                                            decimal r8 = 0;

                                            if (order.feeMode == "1")
                                            {
                                                r7 = r1;
                                                r8 = r7 * p7 / p8;
                                            }
                                            else if (order.feeMode == "2")
                                            {
                                                r7 = r1 * (1 - p7);
                                                r8 = r1 * (1 - p8);
                                            }
                                            conn.Execute("update [bitject].[dbo].[withdrawalOrder] set status='2' , amountFromExternal=@amountFromExternal, feeRatioInExternal=@feeRatioInExternal , feeRatioOutExternal=@feeRatioOutExternal, exRateInExternal=@exRateInExternal,exRateOutExternal=@exRateOutExternal, r1=@r1,r7=@r7,r8=@r8 where id = @id", new { amountFromExternal = amountFromExternal, feeRatioInExternal = feeRatioInExternal, feeRatioOutExternal = feeRatioOutExternal, exRateInExternal = exRateInExternal, exRateOutExternal = exRateOutExternal, r1 = r1, r7 = r7, r8 = r8, id = id });
                                        }
                                    }
                                }
                            }
                        }
                    }
                    else
                    {
                        Dispatcher.Invoke(() => { textblock_msg.Text = "There is no order needs to be processed."; });
                    }

                    var j = conn.Query("SELECT * FROM [bitject].[dbo].[withdrawalOrder] where status='2'");

                    var jdic = j.ToDictionary(x => x.id);

                    if (j.Count() > 0)
                    {
                        //JArray ja = JArray.FromObject(j);

                        string requestBody = JsonConvert.SerializeObject(j.Select(x => new { withdrawalOrderId = x.id, memberId = x.memberId }));

                        byte[] requestBodyByte = Encoding.UTF8.GetBytes(requestBody);

                        string memberRegisterUrl = "http://18.216.220.119/Project_prototype/public/api/getWithdrawRecords";

                        HttpWebRequest hwr = WebRequest.CreateHttp(memberRegisterUrl);

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
                                    foreach (var item in jt["data"])
                                    {
                                        if (item["status"].ToString() == "success")
                                        {
                                            int id = (int)item["withdrawalOrderId"];

                                            var order = (withdrawalOrder)idic[id];

                                            Transaction(order);
                                        }
                                    }


                                }
                            }
                        }
                    }

                    Thread.Sleep(10000);
                }
            })
            { IsBackground = true }.Start();
        }

        private void Transaction(withdrawalOrder wo)
        {
            DateTime createDateTime = Convert.ToDateTime(DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss"));

            string transDetailInsert = "INSERT INTO [dbo].[accountTransDetail]([transferCateId],[accountIdFrom],[accountIdTo],[currencyCodeFrom],[currencyCodeTo],[amountFrom],[amountTo],[exDiff],[fee],[createDateTime],[exRateWithDiff],[exRateWithoutDiff],[exRateFrom],[exSlopeFrom],[exInterceptFrom],[exRateTo],[exSlopeTo],[exInterceptTo],[feeRatio],[r8],[r7],[r1],[amountFromExternal],[feeRatioInExternal],[feeRatioOutExternal],[exRateInExternal],[exRateOutExternal],[memo]) VALUES (@transferCateId,@accountIdFrom,@accountIdTo,@currencyCodeFrom,@currencyCodeTo,@amountFrom,@amountTo,@exDiff,@fee,@createDateTime,@exRateWithDiff,@exRateWithoutDiff,@exRateFrom,@exSlopeFrom,@exInterceptFrom,@exRateTo,@exSlopeTo,@exInterceptTo,@feeRatio,@r8,@r7,@r1,@amountFromExternal,@feeRatioInExternal,@feeRatioOutExternal,@exRateInExternal,@exRateOutExternal,@memo,);select cast(scope_identity() as int";

            string transInsert = "INSERT INTO [dbo].[accountTrans]([detailId],[memberId],[memberLevelId],[memberParentId],[accountId],[transferCateId],[transferTypeId],[amountTypeId],[amount],[balanceBefore],[balanceAfter],[frozenBalanceBefore],[frozenBalanceAfter],[createDateTime],[l1],[l2],[l3],[l4],[l5],[l6],[l7],[l8],[l9]) VALUES (@detailId,@memberId,@memberLevelId,@memberParentId,@accountId,@transferCateId,@transferTypeId,@amountTypeId,@amount,@balanceBefore,@balanceAfter,@frozenBalanceBefore,@frozenBalanceAfter,@createDateTime,@l1,@l2,@l3,@l4,@l5,@l6,@l7,@l8,@l9)";

            using (var ts = new TransactionScope())
            {
                try
                {
                    int agentAccountId = GetAgentAccountId(wo.id);

                    List<int> accountIds = new List<int> { agentAccountId, wo.accountIdFrom };

                    var accounts = conn.Query<account>("select * from [bitject].[dbo].[account] where id in @id", accountIds).ToDictionary(x => x.id);

                    var agentAccount = accounts[agentAccountId];

                    var memberAccount = accounts[wo.accountIdFrom];

                    #region apiCreate == trun 從 agent 帳戶扣款

                    if (wo.isApiCreate)
                    {
                        accountTransDetail atd = new accountTransDetail()
                        {
                            accountIdFrom = agentAccountId,
                            accountIdTo = wo.accountIdFrom,
                            transferCateId = "2",
                            currencyCodeFrom = wo.currencyCodeFrom,
                            currencyCodeTo = wo.currencyCodeFrom,
                            amountFrom = wo.amountFrom,
                            amountTo = wo.amountFrom,
                            exDiff = 0,
                            fee = 0,
                            r8 = 0,
                            r7 = 0,
                            r1 = 0,
                            createDateTime = createDateTime,
                            exRateWithDiff = 1M,
                            exRateWithoutDiff = 1M,
                            exRateFrom = 1M,
                            exSlopeFrom = 0M,
                            exInterceptFrom = 0M,
                            exRateTo = 1M,
                            exSlopeTo = 0M,
                            exInterceptTo = 0M,
                            feeRatio = 0M,
                            amountFromExternal = null,
                            feeRatioInExternal = null,
                            feeRatioOutExternal = null,
                            exRateInExternal = null,
                            exRateOutExternal = null,
                            memo = null,
                        };

                        int detailId = conn.Query<int>(transDetailInsert, atd).FirstOrDefault();

                        conn.Execute("update [bitject].[dbo].[account] set frozenBalance=@frozenBalance, balance=@balance where id=@id", new { frozenBalance = agentAccount.frozenBalance - wo.amountFrom, balance = agentAccount.balance - wo.amountFrom, id = agentAccountId });

                        conn.Execute("update [bitject].[dbo].[account] set balance=@balance where id=@id", new { balance = memberAccount.balance + wo.amountFrom, id = wo.accountIdFrom });

                        // 交易紀錄 agentAccount balance
                        var agentBalance = new accountTrans()
                        {
                            detailId = detailId,
                            memberId = agentAccount.memberId,
                            memberLevelId = agentAccount.memberLevelId,
                            memberParentId = agentAccount.memberParentId,
                            accountId = agentAccount.id,
                            transferCateId = "2", // ApiDeposit
                            transferTypeId = "2", // Withdrawal
                            amount = wo.amountFrom,
                            amountTypeId = "1", // NormalBalance
                            balanceBefore = agentAccount.balance,
                            balanceAfter = agentAccount.balance - wo.amountFrom,
                            frozenBalanceBefore = agentAccount.frozenBalance,
                            frozenBalanceAfter = agentAccount.frozenBalance,
                            createDateTime = createDateTime,
                            l1 = agentAccount.l1,
                            l2 = agentAccount.l2,
                            l3 = agentAccount.l3,
                            l4 = agentAccount.l4,
                            l5 = agentAccount.l5,
                            l6 = agentAccount.l6,
                            l7 = agentAccount.l7,
                            l8 = agentAccount.l8,
                            l9 = agentAccount.l9,
                        };

                        conn.Execute(transInsert, agentBalance);

                        // 交易紀錄 agentAccount frozenBalance
                        var agentFrozenBalance = new accountTrans()
                        {
                            detailId = detailId,
                            memberId = agentAccount.memberId,
                            memberLevelId = agentAccount.memberLevelId,
                            memberParentId = agentAccount.memberParentId,
                            accountId = agentAccount.id,
                            transferCateId = "2", // ApiDeposit
                            transferTypeId = "2", // Withdrawal
                            amount = wo.amountFrom,
                            amountTypeId = "2", // FrozenBalance
                            balanceBefore = agentBalance.balanceAfter,
                            balanceAfter = agentBalance.balanceAfter,
                            frozenBalanceBefore = agentAccount.frozenBalance,
                            frozenBalanceAfter = agentAccount.frozenBalance - wo.amountFrom,
                            createDateTime = createDateTime,
                            l1 = agentAccount.l1,
                            l2 = agentAccount.l2,
                            l3 = agentAccount.l3,
                            l4 = agentAccount.l4,
                            l5 = agentAccount.l5,
                            l6 = agentAccount.l6,
                            l7 = agentAccount.l7,
                            l8 = agentAccount.l8,
                            l9 = agentAccount.l9,
                        };

                        conn.Execute(transInsert, agentFrozenBalance);

                        // 交易紀錄 memberAccount balance depoist
                        var memberBalanceDeposit = new accountTrans()
                        {
                            detailId = detailId,
                            memberId = memberAccount.memberId,
                            memberLevelId = memberAccount.memberLevelId,
                            memberParentId = memberAccount.memberParentId,
                            accountId = memberAccount.id,
                            transferCateId = "2", // ApiDeposit
                            transferTypeId = "1", // Withdrawal
                            amount = wo.amountFrom,
                            amountTypeId = "1", // NormalBalance
                            balanceBefore = memberAccount.balance,
                            balanceAfter = memberAccount.balance + wo.amountFrom,
                            frozenBalanceBefore = memberAccount.frozenBalance,
                            frozenBalanceAfter = memberAccount.frozenBalance,
                            createDateTime = createDateTime,
                            l1 = memberAccount.l1,
                            l2 = memberAccount.l2,
                            l3 = memberAccount.l3,
                            l4 = memberAccount.l4,
                            l5 = memberAccount.l5,
                            l6 = memberAccount.l6,
                            l7 = memberAccount.l7,
                            l8 = memberAccount.l8,
                            l9 = memberAccount.l9,
                        };

                        conn.Execute(transInsert, memberBalanceDeposit);

                        memberAccount.balance = memberAccount.balance + wo.amountFrom;
                    }

                    #endregion apiCreate == trun 從 agent 帳戶扣款

                    accountTransDetail atdWithdrawal = new accountTransDetail()
                    {
                        accountIdFrom = wo.accountIdFrom,
                        accountIdTo = wo.bankAccountIdTo,
                        transferCateId = "4",
                        currencyCodeFrom = wo.currencyCodeFrom,
                        currencyCodeTo = wo.currencyCodeTo,
                        amountFrom = wo.amountFrom,
                        amountTo = wo.amountTo,
                        exDiff = wo.exDiff,
                        fee = wo.fee,
                        r8 = wo.r8.Value,
                        r7 = wo.r7.Value,
                        r1 = wo.r1.Value,
                        createDateTime = createDateTime,
                        exRateWithDiff = wo.exRateWithDiff,
                        exRateWithoutDiff = wo.exRateWithoutDiff,
                        exRateFrom = wo.exRateFrom,
                        exSlopeFrom = wo.exSlopeFrom,
                        exInterceptFrom = wo.exInterceptFrom,
                        exRateTo = wo.exRateTo,
                        exSlopeTo = wo.exSlopeTo,
                        exInterceptTo = wo.exInterceptTo,
                        feeRatio = wo.feeRatio,
                        amountFromExternal = wo.amountFromExternal,
                        feeRatioInExternal = wo.feeRatioInExternal,
                        feeRatioOutExternal = wo.feeRatioOutExternal,
                        exRateInExternal = wo.exRateInExternal,
                        exRateOutExternal = wo.exRateOutExternal,
                        memo = wo.memo,
                    };

                    int detailIdWithdrawal = conn.Query<int>(transDetailInsert, atdWithdrawal).FirstOrDefault();

                    conn.Execute("update [bitject].[dbo].[account] set balance=@balance where id=@id", new { balance = memberAccount.balance - wo.amountFrom, id = wo.accountIdFrom });

                    var memberBalanceWithDrawal = new accountTrans()
                    {
                        detailId = detailIdWithdrawal,
                        memberId = memberAccount.memberId,
                        memberLevelId = memberAccount.memberLevelId,
                        memberParentId = memberAccount.memberParentId,
                        accountId = memberAccount.id,
                        transferCateId = "4", // ExternalWithdrawal
                        transferTypeId = "1", // Withdrawal
                        amount = wo.amountFrom,
                        amountTypeId = "1", // NormalBalance
                        balanceBefore = memberAccount.balance,
                        balanceAfter = memberAccount.balance - wo.amountFrom,
                        frozenBalanceBefore = memberAccount.frozenBalance,
                        frozenBalanceAfter = memberAccount.frozenBalance,
                        createDateTime = createDateTime,
                        l1 = memberAccount.l1,
                        l2 = memberAccount.l2,
                        l3 = memberAccount.l3,
                        l4 = memberAccount.l4,
                        l5 = memberAccount.l5,
                        l6 = memberAccount.l6,
                        l7 = memberAccount.l7,
                        l8 = memberAccount.l8,
                        l9 = memberAccount.l9,
                    };

                    conn.Execute(transInsert, memberBalanceWithDrawal);


                    conn.Execute("update [bitject].[dbo].[withdrawalOrder] set status='3' where id=@id", new { id = wo.id });
                }
                catch(Exception ex)
                {
                    Dispatcher.Invoke(() => { textblock_msg.Text = ex.Message; });
                }
            }
        }

        private int GetAgentAccountId(int memberId)
        {
            int agentAccountId = conn.Query<int>("select u.id from member t inner join account u on t.parentId = u.memberId where u.currencyCode='BJC' and t.id=@id ", memberId).FirstOrDefault();
            return agentAccountId;
        }
    }
}