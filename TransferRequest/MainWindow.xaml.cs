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
using System.Data;
using System.Data.SqlClient;
using System.Threading;
using System.Configuration;
using Dapper;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.IO;
using System.Net;
using System.Transactions;
using NetMQ;
using NetMQ.Sockets;
using System.Net.Sockets;
using Model.Global;
using Model;

namespace TransferRequest
{
    /// <summary>
    /// MainWindow.xaml 的互動邏輯
    /// </summary>
    public partial class MainWindow : Window
    {
        SqlConnection conn = new SqlConnection(Model.Global.GlobalVar.sql_con_str_main);

        string transDetailInsert = "INSERT INTO [dbo].[accountTransDetail]([transferCateId],[accountIdFrom],[accountIdTo],[currencyCodeFrom],[currencyCodeTo],[amountFrom],[amountTo],[exDiff],[fee],[createDateTime],[exRateWithDiff],[exRateWithoutDiff],[exRateFrom],[exSlopeFrom],[exInterceptFrom],[exRateTo],[exSlopeTo],[exInterceptTo],[feeRatio],[r8],[r7],[r1],[amountFromExchange],[feeRatioInExchange],[feeRatioOutExchange],[exRateInExchange],[exRateOutExchange],[memo],[handlerId],[handlerIp]) VALUES (@transferCateId,@accountIdFrom,@accountIdTo,@currencyCodeFrom,@currencyCodeTo,@amountFrom,@amountTo,@exDiff,@fee,@createDateTime,@exRateWithDiff,@exRateWithoutDiff,@exRateFrom,@exSlopeFrom,@exInterceptFrom,@exRateTo,@exSlopeTo,@exInterceptTo,@feeRatio,@r8,@r7,@r1,@amountFromExchange,@feeRatioInExchange,@feeRatioOutExchange,@exRateInExchange,@exRateOutExchange,@memo,@handlerId,@handlerIp);select cast(scope_identity() as int)";

        string transInsert = "INSERT INTO [dbo].[accountTrans]([detailId],[memberId],[memberLevelId],[memberParentId],[accountId],[transferCateId],[transferTypeId],[amountTypeId],[amount],[balanceBefore],[balanceAfter],[frozenBalanceBefore],[frozenBalanceAfter],[createDateTime],[l1],[l2],[l3],[l4],[l5],[l6],[l7],[l8],[l9]) VALUES (@detailId,@memberId,@memberLevelId,@memberParentId,@accountId,@transferCateId,@transferTypeId,@amountTypeId,@amount,@balanceBefore,@balanceAfter,@frozenBalanceBefore,@frozenBalanceAfter,@createDateTime,@l1,@l2,@l3,@l4,@l5,@l6,@l7,@l8,@l9)";

        public MainWindow()
        {
            InitializeComponent();

            Work();
        }

        void Work()
        {
            new Thread(() =>
            {
                JToken jt_result = new JObject();

                //Transfer();
                using (var server = new ResponseSocket())
                {
                    server.Bind("tcp://*:592");

                    while (true)
                    {
                        var message = server.ReceiveFrameString().Trim('@', '$');

                        var jt_req = JsonConvert.DeserializeObject<JObject>(message);

                        Dispatcher.Invoke(() => { textblock_msg.Text += message + "\r\n"; });

                        jt_result = Transfer(jt_req["d"]);

                        string feedbackMsg = JsonConvert.SerializeObject(jt_result);

                        server.SendFrame(feedbackMsg);
                    }
                }
            }
            )
            { IsBackground = true }.Start();
        }

        JToken Transfer(JToken jt_req)
        {
            JToken jt_result = new JObject();
            
            int handlerId = (int)jt_req["handlerId"];
            string handlerIp = Convert.ToString(jt_req["handlerIp"]);
            string transferCateId = (string)jt_req["transferCateId"];
            int accountIdFrom = (int)jt_req["accountIdFrom"];
            int accountIdTo = (int)jt_req["accountIdTo"];
            decimal amount = (decimal)jt_req["amount"];
            string amountOwner = (string)jt_req["amountOwner"];
            string memo = (string)jt_req["memo"];
            decimal feeRatio = 0;
            string feeOwner = Model.Account.Define.TransferSides.Sender;

            using (var ts = new TransactionScope())
            {
                try
                {
                    DateTime createDateTime = DateTime.Now;
                    
                    List<int> accountIds = new List<int>() { accountIdFrom, accountIdTo };

                    var accounts = conn.Query<account>("select * from bitject.dbo.account with(nolock) where id in @accountIds", new { accountIds = accountIds }).ToDictionary(x => x.id);

                    var accountFrom = accounts[accountIdFrom];
                    var accountTo = accounts[accountIdTo];

                    decimal amountFrom;
                    decimal amountTo;
                    decimal fee;
                    decimal exDiff;

                    List<string> currencyCodes = new List<string>() { accountFrom.currencyCode, accountTo.currencyCode };

                    var exchangeRates = conn.Query<exchangeRate>("select * from bitject.dbo.exchangeRate with(nolock) where currencyCode in @currencyCodes", new { currencyCodes = currencyCodes }).ToDictionary(x => x.currencyCode);

                    var exchangeRateFrom = exchangeRates[accountFrom.currencyCode];
                    var exchangeRateTo = exchangeRates[accountTo.currencyCode];

                    int decimalDigitFrom = Model.Global.GlobalVar.CurrencyCodeDecimalDigitsMap[accountFrom.currencyCode];

                    int decimalDigitTo = Model.Global.GlobalVar.CurrencyCodeDecimalDigitsMap[accountTo.currencyCode];

                    decimal exRateWithDiff = 1;

                    decimal exRateWithoutDiff = exchangeRateFrom.exRate / exchangeRateTo.exRate; ;

                    if (exchangeRateFrom.currencyCode != exchangeRateTo.currencyCode)
                    {
                        exRateWithDiff = (exchangeRateFrom.exRate * (1 - exchangeRateFrom.exSlope) - exchangeRateFrom.exIntercept) / (exchangeRateTo.exRate * (1 + exchangeRateTo.exSlope) + exchangeRateTo.exIntercept);
                    }

                    if (amountOwner == Model.Account.Define.TransferSides.Sender)
                    {
                        if (feeOwner == Model.Account.Define.TransferSides.Sender)
                        {
                            fee = amount * feeRatio;

                            amountFrom = (amount + fee).RoundUp(decimalDigitFrom);

                            amountTo = (amount * exRateWithDiff).RoundDown(decimalDigitTo);

                            exDiff = amount * (exRateWithoutDiff - exRateWithDiff) / exRateWithoutDiff;
                        }
                        else
                        {
                            amountFrom = amount;

                            exDiff = amount * (exRateWithoutDiff - exRateWithDiff) / exRateWithoutDiff;

                            fee = amount * feeRatio;

                            amountTo = ((amount - fee) * exRateWithDiff).RoundDown(decimalDigitTo);
                        }
                    }
                    else
                    {
                        if (feeOwner == Model.Account.Define.TransferSides.Sender)
                        {
                            amountTo = amount;

                            fee = amountTo / exRateWithDiff * feeRatio;

                            amountFrom = (amountTo / exRateWithDiff * (1 + feeRatio)).RoundUp(decimalDigitFrom);

                            exDiff = amountTo / exRateWithDiff * (exRateWithoutDiff - exRateWithDiff) / exRateWithoutDiff;
                        }
                        else
                        {
                            amountFrom = (amount / exRateWithDiff).RoundUp(decimalDigitFrom);

                            exDiff = amount / exRateWithDiff * (exRateWithoutDiff - exRateWithDiff) / exRateWithoutDiff;

                            fee = amount / exRateWithDiff * feeRatio;

                            amountTo = (amount - fee * exRateWithoutDiff).RoundDown(decimalDigitTo);
                        }
                    }

                    if (amountFrom > (accountFrom.balance - accountFrom.frozenBalance))
                    {
                        jt_result["result"] = "fail";
                        jt_result["msg"] = "餘額不足";
                        jt_result["column"] = "amount";

                        return jt_result;
                    }

                    //var memberObjTo = conn.Query<member>("select * from bitject.dbo.member with(nolock) where id = " + memberIdTo).FirstOrDefault();

                    // 計算代理獲利(from fee)
                    decimal r1 = fee;

                    decimal r7 = 0;

                    decimal r8 = 0;

                    //if ( == Model.Account.Define.FeeModes.Stack)
                    //{
                    //    r7 = r1;
                    //    r8 = r7 * ownPercentAgent / ownPercentUpAgent;
                    //}
                    //else if (sqlStruct.FeeMode == Model.Account.Define.FeeModes.Divid)
                    //{
                    //    r7 = r1 * (1 - ownPercentAgent);
                    //    r8 = r1 * (1 - ownPercentUpAgent);
                    //}

                    conn.Execute("update account set balance -= " + amountFrom + " where id = " + accountIdFrom);

                    conn.Execute("update account set balance += " + amountTo + " where id = " + accountIdTo);

                    accountTransDetail atd = new accountTransDetail()
                    {
                        accountIdFrom = accountIdFrom,
                        accountIdTo = accountIdTo,
                        transferCateId = transferCateId,
                        currencyCodeFrom = accountFrom.currencyCode,
                        currencyCodeTo = accountTo.currencyCode,
                        amountFrom = amountFrom,
                        amountTo = amountTo,
                        exDiff = exDiff,
                        fee = fee,
                        r8 = r8,
                        r7 = r7,
                        r1 = r1,
                        createDateTime = createDateTime,
                        exRateWithDiff = exRateWithDiff,
                        exRateWithoutDiff = exRateWithoutDiff,
                        exRateFrom = exchangeRateFrom.exRate,
                        exSlopeFrom = exchangeRateFrom.exSlope,
                        exInterceptFrom = exchangeRateFrom.exIntercept,
                        exRateTo = exchangeRateTo.exRate,
                        exSlopeTo = exchangeRateTo.exSlope,
                        exInterceptTo = exchangeRateTo.exIntercept,
                        feeRatio = feeRatio,
                        amountFromExchange = 0,
                        feeRatioInExchange = 0,
                        feeRatioOutExchange = 0,
                        exRateInExchange = 0,
                        exRateOutExchange =0,
                        handlerId = handlerId,
                        handlerIp = handlerIp,
                        memo = memo,
                    };

                    int detailId = conn.Query<int>(transDetailInsert, atd).Single();

                    accountTrans accountTransFromObj = new accountTrans()
                    {
                        detailId = detailId,
                        memberId = accountFrom.memberId,
                        memberLevelId = accountFrom.memberLevelId,
                        memberParentId = accountFrom.memberParentId,
                        accountId = accountFrom.id,
                        transferCateId = transferCateId,
                        transferTypeId = Model.Account.Define.TransferTypeIds.Withdrawal,
                        amountTypeId = Model.Account.Define.AccountTransAmoutTypeId.NormalBalance,
                        amount = amountFrom,
                        balanceBefore = accountFrom.balance,
                        balanceAfter = accountFrom.balance - amountFrom,
                        frozenBalanceBefore = accountFrom.frozenBalance,
                        frozenBalanceAfter = accountFrom.frozenBalance,
                        createDateTime = createDateTime,
                        l1 = accountFrom.l1,
                        l2 = accountFrom.l2,
                        l3 = accountFrom.l3,
                        l4 = accountFrom.l4,
                        l5 = accountFrom.l5,
                        l6 = accountFrom.l6,
                        l7 = accountFrom.l7,
                        l8 = accountFrom.l8,
                        l9 = accountFrom.l9,
                    };

                    accountTrans accountTransToObj = new accountTrans()
                    {
                        detailId = detailId,
                        memberId = accountTo.memberId,
                        memberLevelId = accountTo.memberLevelId,
                        memberParentId = accountTo.memberParentId,
                        accountId = accountTo.id,
                        transferCateId = transferCateId,
                        transferTypeId = Model.Account.Define.TransferTypeIds.Deposit,
                        amountTypeId = Model.Account.Define.AccountTransAmoutTypeId.NormalBalance,
                        amount = amountTo,
                        balanceBefore = accountTo.balance,
                        balanceAfter = accountTo.balance + amountTo,
                        frozenBalanceBefore = accountTo.frozenBalance,
                        frozenBalanceAfter = accountTo.frozenBalance,
                        createDateTime = createDateTime,
                        l1 = accountTo.l1,
                        l2 = accountTo.l2,
                        l3 = accountTo.l3,
                        l4 = accountTo.l4,
                        l5 = accountTo.l5,
                        l6 = accountTo.l6,
                        l7 = accountTo.l7,
                        l8 = accountTo.l8,
                        l9 = accountTo.l9,
                    };

                    conn.Execute(transInsert, new object[] { accountTransFromObj, accountTransToObj });

                    ts.Complete();

                    jt_result["result"] = "success";
                    jt_result["msg"] = "轉帳成功，從 #" + accountFrom.id + " 轉出 " + accountFrom.currencyCode + " " + amountFrom + " 至 #" + accountTo.id + " " + accountTo.currencyCode + " " + amountTo;

                    return jt_result;
                }
                catch (Exception ex)
                {
                    jt_result["result"] = "fail";
                    jt_result["msg"] = "請稍後再試 " + ex.Message;

                    return jt_result;
                }
            }
        }
    }
}