using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using Dapper;
using GlobalUtils;
using Model.Global;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

/// <summary>
/// Define 的摘要描述
/// </summary>

namespace Model.Account
{
    public class Define
    {
        private SqlConnection conn = new SqlConnection(Model.Global.GlobalVar.sql_con_str_main);

        private Model.Global.GlobalFunc glbf = new Model.Global.GlobalFunc();

        public Define()
        {
            //
            // TODO: 在這裡新增建構函式邏輯
            //
        }

        public class AccountStatus
        {
            /// <summary>
            /// 有效
            /// </summary>
            public const string Valid = "1";

            /// <summary>
            /// 無效
            /// </summary>
            public const string Invalid = "2";
        }

        public static Dictionary<string, string> AccountStatusLangMap = new Dictionary<string, string>
        {
            {AccountStatus.Valid,"ACCOUNT_STATUS_" + AccountStatus.Valid},
            {AccountStatus.Invalid,"ACCOUNT_STATUS_" + AccountStatus.Invalid}
        };

        public class BankAccountStatus
        {
            /// <summary>
            /// 有效
            /// </summary>
            public const string Valid = "1";

            /// <summary>
            /// 無效
            /// </summary>
            public const string Invalid = "2";
        }

        public static Dictionary<string, string> BankAccountStatusLangMap = new Dictionary<string, string>
        {
            {BankAccountStatus.Valid,"BANKACCOUNTSTATUS_" + BankAccountStatus.Valid},
            {BankAccountStatus.Invalid,"BANKACCOUNTSTATUS_" + BankAccountStatus.Invalid}
        };

        public class BankAccountReviewStatus
        {
            public const string Invalid = "1";
            public const string WaitForReview = "2";
            public const string Valid = "3";
        }

        public static Dictionary<string, string> BankAccountReviewStatusLangMap = new Dictionary<string, string>
        {
            { BankAccountReviewStatus.Valid,"REVIEW_STATUS_" + BankAccountReviewStatus.Valid },
            { BankAccountReviewStatus.Invalid,"REVIEW_STATUS_" + BankAccountReviewStatus.Invalid },
            { BankAccountReviewStatus.WaitForReview,"REVIEW_STATUS_" + BankAccountReviewStatus.WaitForReview },
        };

        public class TransferTypeIds
        {
            public const string Deposit = "1";
            public const string Withdrawal = "2";
        }

        public static Dictionary<string, string> TransferTypeIdsLangMap = new Dictionary<string, string>
        {
            { TransferTypeIds.Deposit , "TRANSFER_TYPE_" + TransferTypeIds.Deposit },
            { TransferTypeIds.Withdrawal , "TRANSFER_TYPE_" + TransferTypeIds.Withdrawal }
        };

        public class AccountTransAmoutTypeId
        {
            /// <summary>
            /// 帳面餘額
            /// </summary>
            public const string NormalBalance = "1";

            /// <summary>
            /// 凍結餘額
            /// </summary>
            public const string FrozenBalance = "2";
        }

        public static Dictionary<string, string> AccountTransAmountTypeIdLangMap = new Dictionary<string, string>
        {
            {AccountTransAmoutTypeId.NormalBalance,"ACCOUNT_TRANS_AMOUNT_TYPE_" + AccountTransAmoutTypeId.NormalBalance},
            {AccountTransAmoutTypeId.FrozenBalance,"ACCOUNT_TRANS_AMOUNT_TYPE_" + AccountTransAmoutTypeId.FrozenBalance}
        };

        public class TransferSides
        {
            public const string Sender = "1";
            public const string Receiver = "2";
        }

        public static Dictionary<string, string> TransferSidesLangMap = new Dictionary<string, string>
        {
            {TransferSides.Sender,"TRANSFER_SIDE_" + TransferSides.Sender},
            {TransferSides.Receiver,"TRANSFER_SIDE_" + TransferSides.Receiver}
        };

        public class FeeModes
        {
            public const string Stack = "1";
            public const string Divid = "2";
        }

        public static Dictionary<string, string> FeeModesLangMap = new Dictionary<string, string>
        {
            {FeeModes.Stack,"FEE_MODE_" + FeeModes.Stack},
            {FeeModes.Divid,"FEE_MODE_" + FeeModes.Divid}
        };

        public class TransferReportTypeIds
        {
            public const string Summary = "1";
            public const string Detail = "2";
        }

        public static Dictionary<string, string> TransferReportTypeIdsLangMap = new Dictionary<string, string>
        {
            {TransferReportTypeIds.Summary,"TRANSFER_REPORT_TYPEID_" + TransferReportTypeIds.Summary},
            {TransferReportTypeIds.Detail,"TRANSFER_REPORT_TYPEID_" + TransferReportTypeIds.Detail}
        };

        public class TransferCateIds
        {
            public const string ExternalDeposit = "1";
            public const string ApiDeposit = "2";
            public const string InternalTransfer = "3";
            public const string ExternalWithdrawal = "4";
            public const string PreDeposit = "5";
        }

        public static Dictionary<string, string> TransferCateIdsLangMap = new Dictionary<string, string>
        {
            { TransferCateIds.ExternalDeposit,"TRANSFER_CATE_ID_" + TransferCateIds.ExternalDeposit },
            { TransferCateIds.ApiDeposit,"TRANSFER_CATE_ID_" + TransferCateIds.ApiDeposit },
            { TransferCateIds.InternalTransfer,"TRANSFER_CATE_ID_" + TransferCateIds.InternalTransfer },
            { TransferCateIds.ExternalWithdrawal,"TRANSFER_CATE_ID_" + TransferCateIds.ExternalWithdrawal },
            { TransferCateIds.PreDeposit,"TRANSFER_CATE_ID_" + TransferCateIds.PreDeposit },
        };

        public class BankAccountRegisterStatus
        {
            public const string Pending = "1";
            public const string InQueue = "2";
            public const string Success = "3";
        }

        public static Dictionary<string, string> BankAccountRegisterStatusLangMap = new Dictionary<string, string>
        {
            { BankAccountRegisterStatus.Pending,"BANK_ACCOUNT_REGISTER_STATUS_" + BankAccountRegisterStatus.Pending },
            { BankAccountRegisterStatus.InQueue,"BANK_ACCOUNT_REGISTER_STATUS_" + BankAccountRegisterStatus.InQueue },
            { BankAccountRegisterStatus.Success,"BANK_ACCOUNT_REGISTER_STATUS_" + BankAccountRegisterStatus.Success },
        };

        public class WithDrawalOrderStatus
        {
            public const string Pending = "1";
            public const string InQueue = "2";
            public const string Success = "3";
            public const string Locking = "4";
        }

        public static Dictionary<string, string> WithdrawalOrderStatusLangMap = new Dictionary<string, string>
        {
            { WithDrawalOrderStatus.Pending,"WITHDRAWAL_ORDER_STATUS_ID_" + WithDrawalOrderStatus.Pending },
            { WithDrawalOrderStatus.InQueue,"WITHDRAWAL_ORDER_STATUS_ID_" + WithDrawalOrderStatus.InQueue },
            { WithDrawalOrderStatus.Success,"WITHDRAWAL_ORDER_STATUS_ID_" + WithDrawalOrderStatus.Success },
            { WithDrawalOrderStatus.Locking,"WITHDRAWAL_ORDER_STATUS_ID_" + WithDrawalOrderStatus.Locking },
        };

        public class WithdrawalOrderRequestTypeId
        {
            public const string Api = "1";
            public const string MemberInternal = "2";
        }

        public static Dictionary<string, string> WithdrawalOrderRequestTypeIdLangMap = new Dictionary<string, string>
        {
            { WithdrawalOrderRequestTypeId.Api,"WITHDRAWAL_ORDER_REQUEST_TYPE_ID_" + WithdrawalOrderRequestTypeId.Api },
            { WithdrawalOrderRequestTypeId.MemberInternal,"WITHDRAWAL_ORDER_REQUEST_TYPE_ID_" + WithdrawalOrderRequestTypeId.MemberInternal },
        };


        public class Banks
        {
            public const string B004 = "004";
            public const string B005 = "005";
            public const string B006 = "006";
            public const string B007 = "007";
            public const string B008 = "008";
            public const string B009 = "009";
            public const string B011 = "011";
            public const string B012 = "012";
            public const string B013 = "013";
            public const string B016 = "016";
            public const string B017 = "017";
            public const string B018 = "018";
            public const string B021 = "021";
            public const string B022 = "022";
            public const string B025 = "025";
            public const string B039 = "039";
            public const string B040 = "040";
            public const string B048 = "048";
            public const string B050 = "050";
            public const string B052 = "052";
            public const string B053 = "053";
            public const string B054 = "054";
            public const string B072 = "072";
            public const string B075 = "075";
            public const string B081 = "081";
            public const string B085 = "085";
            public const string B101 = "101";
            public const string B102 = "102";
            public const string B103 = "103";
            public const string B104 = "104";
            public const string B108 = "108";
            public const string B114 = "114";
            public const string B115 = "115";
            public const string B118 = "118";
            public const string B119 = "119";
            public const string B120 = "120";
            public const string B124 = "124";
            public const string B127 = "127";
            public const string B130 = "130";
            public const string B132 = "132";
            public const string B146 = "146";
            public const string B147 = "147";
            public const string B158 = "158";
            public const string B161 = "161";
            public const string B162 = "162";
            public const string B163 = "163";
            public const string B165 = "165";
            public const string B178 = "178";
            public const string B188 = "188";
            public const string B204 = "204";
            public const string B215 = "215";
            public const string B216 = "216";
            public const string B222 = "222";
            public const string B223 = "223";
            public const string B224 = "224";
            public const string B503 = "503";
            public const string B504 = "504";
            public const string B505 = "505";
            public const string B506 = "506";
            public const string B507 = "507";
            public const string B512 = "512";
            public const string B515 = "515";
            public const string B517 = "517";
            public const string B518 = "518";
            public const string B520 = "520";
            public const string B521 = "521";
            public const string B523 = "523";
            public const string B524 = "524";
            public const string B525 = "525";
            public const string B603 = "603";
            public const string B605 = "605";
            public const string B606 = "606";
            public const string B607 = "607";
            public const string B608 = "608";
            public const string B610 = "610";
            public const string B611 = "611";
            public const string B612 = "612";
            public const string B613 = "613";
            public const string B614 = "614";
            public const string B616 = "616";
            public const string B617 = "617";
            public const string B618 = "618";
            public const string B619 = "619";
            public const string B620 = "620";
            public const string B621 = "621";
            public const string B622 = "622";
            public const string B623 = "623";
            public const string B624 = "624";
            public const string B625 = "625";
            public const string B627 = "627";
            public const string B698 = "698";
            public const string B700 = "700";
            public const string B803 = "803";
            public const string B805 = "805";
            public const string B806 = "806";
            public const string B807 = "807";
            public const string B808 = "808";
            public const string B809 = "809";
            public const string B810 = "810";
            public const string B812 = "812";
            public const string B814 = "814";
            public const string B815 = "815";
            public const string B816 = "816";
            public const string B822 = "822";
            public const string B869 = "869";
            public const string B901 = "901";
            public const string B903 = "903";
            public const string B904 = "904";
            public const string B910 = "910";
            public const string B912 = "912";
            public const string B916 = "916";
            public const string B922 = "922";
            public const string B928 = "928";
            public const string B951 = "951";
            public const string B954 = "954";
        }

        #region BanksLangMap
        public static Dictionary<string, string> BanksLangMap = new Dictionary<string, string>
        {
            {Banks.B004,"ACCOUNT_BANK_" + Banks.B004 },
            {Banks.B005,"ACCOUNT_BANK_" + Banks.B005 },
            {Banks.B006,"ACCOUNT_BANK_" + Banks.B006 },
            {Banks.B007,"ACCOUNT_BANK_" + Banks.B007 },
            {Banks.B008,"ACCOUNT_BANK_" + Banks.B008 },
            {Banks.B009,"ACCOUNT_BANK_" + Banks.B009 },
            {Banks.B011,"ACCOUNT_BANK_" + Banks.B011 },
            {Banks.B012,"ACCOUNT_BANK_" + Banks.B012 },
            {Banks.B013,"ACCOUNT_BANK_" + Banks.B013 },
            {Banks.B016,"ACCOUNT_BANK_" + Banks.B016 },
            {Banks.B017,"ACCOUNT_BANK_" + Banks.B017 },
            {Banks.B018,"ACCOUNT_BANK_" + Banks.B018 },
            {Banks.B021,"ACCOUNT_BANK_" + Banks.B021 },
            {Banks.B022,"ACCOUNT_BANK_" + Banks.B022 },
            {Banks.B025,"ACCOUNT_BANK_" + Banks.B025 },
            {Banks.B039,"ACCOUNT_BANK_" + Banks.B039 },
            {Banks.B040,"ACCOUNT_BANK_" + Banks.B040 },
            {Banks.B048,"ACCOUNT_BANK_" + Banks.B048 },
            {Banks.B050,"ACCOUNT_BANK_" + Banks.B050 },
            {Banks.B052,"ACCOUNT_BANK_" + Banks.B052 },
            {Banks.B053,"ACCOUNT_BANK_" + Banks.B053 },
            {Banks.B054,"ACCOUNT_BANK_" + Banks.B054 },
            {Banks.B072,"ACCOUNT_BANK_" + Banks.B072 },
            {Banks.B075,"ACCOUNT_BANK_" + Banks.B075 },
            {Banks.B081,"ACCOUNT_BANK_" + Banks.B081 },
            {Banks.B085,"ACCOUNT_BANK_" + Banks.B085 },
            {Banks.B101,"ACCOUNT_BANK_" + Banks.B101 },
            {Banks.B102,"ACCOUNT_BANK_" + Banks.B102 },
            {Banks.B103,"ACCOUNT_BANK_" + Banks.B103 },
            {Banks.B104,"ACCOUNT_BANK_" + Banks.B104 },
            {Banks.B108,"ACCOUNT_BANK_" + Banks.B108 },
            {Banks.B114,"ACCOUNT_BANK_" + Banks.B114 },
            {Banks.B115,"ACCOUNT_BANK_" + Banks.B115 },
            {Banks.B118,"ACCOUNT_BANK_" + Banks.B118 },
            {Banks.B119,"ACCOUNT_BANK_" + Banks.B119 },
            {Banks.B120,"ACCOUNT_BANK_" + Banks.B120 },
            {Banks.B124,"ACCOUNT_BANK_" + Banks.B124 },
            {Banks.B127,"ACCOUNT_BANK_" + Banks.B127 },
            {Banks.B130,"ACCOUNT_BANK_" + Banks.B130 },
            {Banks.B132,"ACCOUNT_BANK_" + Banks.B132 },
            {Banks.B146,"ACCOUNT_BANK_" + Banks.B146 },
            {Banks.B147,"ACCOUNT_BANK_" + Banks.B147 },
            {Banks.B158,"ACCOUNT_BANK_" + Banks.B158 },
            {Banks.B161,"ACCOUNT_BANK_" + Banks.B161 },
            {Banks.B162,"ACCOUNT_BANK_" + Banks.B162 },
            {Banks.B163,"ACCOUNT_BANK_" + Banks.B163 },
            {Banks.B165,"ACCOUNT_BANK_" + Banks.B165 },
            {Banks.B178,"ACCOUNT_BANK_" + Banks.B178 },
            {Banks.B188,"ACCOUNT_BANK_" + Banks.B188 },
            {Banks.B204,"ACCOUNT_BANK_" + Banks.B204 },
            {Banks.B215,"ACCOUNT_BANK_" + Banks.B215 },
            {Banks.B216,"ACCOUNT_BANK_" + Banks.B216 },
            {Banks.B222,"ACCOUNT_BANK_" + Banks.B222 },
            {Banks.B223,"ACCOUNT_BANK_" + Banks.B223 },
            {Banks.B224,"ACCOUNT_BANK_" + Banks.B224 },
            {Banks.B503,"ACCOUNT_BANK_" + Banks.B503 },
            {Banks.B504,"ACCOUNT_BANK_" + Banks.B504 },
            {Banks.B505,"ACCOUNT_BANK_" + Banks.B505 },
            {Banks.B506,"ACCOUNT_BANK_" + Banks.B506 },
            {Banks.B507,"ACCOUNT_BANK_" + Banks.B507 },
            {Banks.B512,"ACCOUNT_BANK_" + Banks.B512 },
            {Banks.B515,"ACCOUNT_BANK_" + Banks.B515 },
            {Banks.B517,"ACCOUNT_BANK_" + Banks.B517 },
            {Banks.B518,"ACCOUNT_BANK_" + Banks.B518 },
            {Banks.B520,"ACCOUNT_BANK_" + Banks.B520 },
            {Banks.B521,"ACCOUNT_BANK_" + Banks.B521 },
            {Banks.B523,"ACCOUNT_BANK_" + Banks.B523 },
            {Banks.B524,"ACCOUNT_BANK_" + Banks.B524 },
            {Banks.B525,"ACCOUNT_BANK_" + Banks.B525 },
            {Banks.B603,"ACCOUNT_BANK_" + Banks.B603 },
            {Banks.B605,"ACCOUNT_BANK_" + Banks.B605 },
            {Banks.B606,"ACCOUNT_BANK_" + Banks.B606 },
            {Banks.B607,"ACCOUNT_BANK_" + Banks.B607 },
            {Banks.B608,"ACCOUNT_BANK_" + Banks.B608 },
            {Banks.B610,"ACCOUNT_BANK_" + Banks.B610 },
            {Banks.B611,"ACCOUNT_BANK_" + Banks.B611 },
            {Banks.B612,"ACCOUNT_BANK_" + Banks.B612 },
            {Banks.B613,"ACCOUNT_BANK_" + Banks.B613 },
            {Banks.B614,"ACCOUNT_BANK_" + Banks.B614 },
            {Banks.B616,"ACCOUNT_BANK_" + Banks.B616 },
            {Banks.B617,"ACCOUNT_BANK_" + Banks.B617 },
            {Banks.B618,"ACCOUNT_BANK_" + Banks.B618 },
            {Banks.B619,"ACCOUNT_BANK_" + Banks.B619 },
            {Banks.B620,"ACCOUNT_BANK_" + Banks.B620 },
            {Banks.B621,"ACCOUNT_BANK_" + Banks.B621 },
            {Banks.B622,"ACCOUNT_BANK_" + Banks.B622 },
            {Banks.B623,"ACCOUNT_BANK_" + Banks.B623 },
            {Banks.B624,"ACCOUNT_BANK_" + Banks.B624 },
            {Banks.B625,"ACCOUNT_BANK_" + Banks.B625 },
            {Banks.B627,"ACCOUNT_BANK_" + Banks.B627 },
            {Banks.B698,"ACCOUNT_BANK_" + Banks.B698 },
            {Banks.B700,"ACCOUNT_BANK_" + Banks.B700 },
            {Banks.B803,"ACCOUNT_BANK_" + Banks.B803 },
            {Banks.B805,"ACCOUNT_BANK_" + Banks.B805 },
            {Banks.B806,"ACCOUNT_BANK_" + Banks.B806 },
            {Banks.B807,"ACCOUNT_BANK_" + Banks.B807 },
            {Banks.B808,"ACCOUNT_BANK_" + Banks.B808 },
            {Banks.B809,"ACCOUNT_BANK_" + Banks.B809 },
            {Banks.B810,"ACCOUNT_BANK_" + Banks.B810 },
            {Banks.B812,"ACCOUNT_BANK_" + Banks.B812 },
            {Banks.B814,"ACCOUNT_BANK_" + Banks.B814 },
            {Banks.B815,"ACCOUNT_BANK_" + Banks.B815 },
            {Banks.B816,"ACCOUNT_BANK_" + Banks.B816 },
            {Banks.B822,"ACCOUNT_BANK_" + Banks.B822 },
            {Banks.B869,"ACCOUNT_BANK_" + Banks.B869 },
            {Banks.B901,"ACCOUNT_BANK_" + Banks.B901 },
            {Banks.B903,"ACCOUNT_BANK_" + Banks.B903 },
            {Banks.B904,"ACCOUNT_BANK_" + Banks.B904 },
            {Banks.B910,"ACCOUNT_BANK_" + Banks.B910 },
            {Banks.B912,"ACCOUNT_BANK_" + Banks.B912 },
            {Banks.B916,"ACCOUNT_BANK_" + Banks.B916 },
            {Banks.B922,"ACCOUNT_BANK_" + Banks.B922 },
            {Banks.B928,"ACCOUNT_BANK_" + Banks.B928 },
            {Banks.B951,"ACCOUNT_BANK_" + Banks.B951 },
            {Banks.B954,"ACCOUNT_BANK_" + Banks.B954 },

        };

        #endregion

        public class ChinaBanks
        {
            public const string C001 = "C001";
            public const string C002 = "C002";
            public const string C003 = "C003";
            public const string C004 = "C004";
            public const string C005 = "C005";
            public const string C006 = "C006";
            public const string C007 = "C007";
            public const string C008 = "C008";
            public const string C009 = "C009";
            public const string C010 = "C010";
            public const string C011 = "C011";
            public const string C012 = "C012";
            public const string C013 = "C013";
            public const string C014 = "C014";
            public const string C015 = "C015";
            public const string C016 = "C016";
            public const string C017 = "C017";
            public const string C018 = "C018";
            public const string C019 = "C019";
            public const string C020 = "C020";
            public const string C021 = "C021";
            public const string C022 = "C022";
            public const string C023 = "C023";
            public const string C024 = "C024";
            public const string C025 = "C025";
            public const string C026 = "C026";
            public const string C027 = "C027";
            public const string C028 = "C028";
            public const string C029 = "C029";
            public const string C030 = "C030";
            public const string C031 = "C031";
            public const string C032 = "C032";
            public const string C033 = "C033";
            public const string C034 = "C034";
            public const string C035 = "C035";
            public const string C036 = "C036";
            public const string C037 = "C037";
            public const string C038 = "C038";
            public const string C039 = "C039";
            public const string C040 = "C040";
            public const string C041 = "C041";
            public const string C042 = "C042";
            public const string C043 = "C043";
            public const string C044 = "C044";
            public const string C045 = "C045";
            public const string C046 = "C046";
            public const string C047 = "C047";
            public const string C048 = "C048";
            public const string C049 = "C049";
            public const string C050 = "C050";
            public const string C051 = "C051";
            public const string C052 = "C052";
            public const string C053 = "C053";
            public const string C054 = "C054";
            public const string C055 = "C055";
            public const string C056 = "C056";
            public const string C057 = "C057";
            public const string C058 = "C058";
            public const string C059 = "C059";
            public const string C060 = "C060";
            public const string C061 = "C061";
            public const string C062 = "C062";
            public const string C063 = "C063";
            public const string C064 = "C064";
            public const string C065 = "C065";
            public const string C066 = "C066";
            public const string C067 = "C067";
            public const string C068 = "C068";
            public const string C069 = "C069";
            public const string C070 = "C070";
            public const string C071 = "C071";
            public const string C072 = "C072";
            public const string C073 = "C073";
            public const string C074 = "C074";
            public const string C075 = "C075";
            public const string C076 = "C076";
            public const string C077 = "C077";
            public const string C078 = "C078";
            public const string C079 = "C079";
            public const string C080 = "C080";
            public const string C081 = "C081";
            public const string C082 = "C082";
            public const string C083 = "C083";
            public const string C084 = "C084";
            public const string C085 = "C085";
            public const string C086 = "C086";
            public const string C087 = "C087";
            public const string C088 = "C088";
            public const string C089 = "C089";
            public const string C090 = "C090";
            public const string C091 = "C091";
            public const string C092 = "C092";
            public const string C093 = "C093";
            public const string C094 = "C094";
            public const string C095 = "C095";
            public const string C096 = "C096";
            public const string C097 = "C097";
            public const string C098 = "C098";
            public const string C099 = "C099";
            public const string C100 = "C100";
            public const string C101 = "C101";
            public const string C102 = "C102";
            public const string C103 = "C103";
            public const string C104 = "C104";
            public const string C105 = "C105";
            public const string C106 = "C106";
            public const string C107 = "C107";
            public const string C108 = "C108";
            public const string C109 = "C109";
            public const string C110 = "C110";
            public const string C111 = "C111";
            public const string C112 = "C112";
            public const string C113 = "C113";
            public const string C114 = "C114";
            public const string C115 = "C115";
            public const string C116 = "C116";
            public const string C117 = "C117";
            public const string C118 = "C118";
            public const string C119 = "C119";
            public const string C120 = "C120";
            public const string C121 = "C121";
            public const string C122 = "C122";
            public const string C123 = "C123";
            public const string C124 = "C124";
            public const string C125 = "C125";
            public const string C126 = "C126";
            public const string C127 = "C127";
            public const string C128 = "C128";
            public const string C129 = "C129";
            public const string C130 = "C130";
            public const string C131 = "C131";
            public const string C132 = "C132";
            public const string C133 = "C133";
            public const string C134 = "C134";
            public const string C135 = "C135";
            public const string C136 = "C136";
            public const string C137 = "C137";
            public const string C138 = "C138";
            public const string C139 = "C139";
            public const string C140 = "C140";
            public const string C141 = "C141";
            public const string C142 = "C142";
            public const string C143 = "C143";
            public const string C144 = "C144";
            public const string C145 = "C145";
            public const string C146 = "C146";
            public const string C147 = "C147";
            public const string C148 = "C148";
            public const string C149 = "C149";
            public const string C150 = "C150";
            public const string C151 = "C151";
            public const string C152 = "C152";
            public const string C153 = "C153";
            public const string C154 = "C154";
            public const string C155 = "C155";
            public const string C156 = "C156";
            public const string C157 = "C157";
            public const string C158 = "C158";
            public const string C159 = "C159";
        }

        #region ChinaBanksLangMap
        public static Dictionary<string, string> ChinaBanksLangMap = new Dictionary<string, string>
        {
            {ChinaBanks.C001,"ACCOUNT_CHINA_BANK_" + ChinaBanks.C001 },
            {ChinaBanks.C002,"ACCOUNT_CHINA_BANK_" + ChinaBanks.C002 },
            {ChinaBanks.C003,"ACCOUNT_CHINA_BANK_" + ChinaBanks.C003 },
            {ChinaBanks.C004,"ACCOUNT_CHINA_BANK_" + ChinaBanks.C004 },
            {ChinaBanks.C005,"ACCOUNT_CHINA_BANK_" + ChinaBanks.C005 },
            {ChinaBanks.C006,"ACCOUNT_CHINA_BANK_" + ChinaBanks.C006 },
            {ChinaBanks.C007,"ACCOUNT_CHINA_BANK_" + ChinaBanks.C007 },
            {ChinaBanks.C008,"ACCOUNT_CHINA_BANK_" + ChinaBanks.C008 },
            {ChinaBanks.C009,"ACCOUNT_CHINA_BANK_" + ChinaBanks.C009 },
            {ChinaBanks.C010,"ACCOUNT_CHINA_BANK_" + ChinaBanks.C010 },
            {ChinaBanks.C011,"ACCOUNT_CHINA_BANK_" + ChinaBanks.C011 },
            {ChinaBanks.C012,"ACCOUNT_CHINA_BANK_" + ChinaBanks.C012 },
            {ChinaBanks.C013,"ACCOUNT_CHINA_BANK_" + ChinaBanks.C013 },
            {ChinaBanks.C014,"ACCOUNT_CHINA_BANK_" + ChinaBanks.C014 },
            {ChinaBanks.C015,"ACCOUNT_CHINA_BANK_" + ChinaBanks.C015 },
            {ChinaBanks.C016,"ACCOUNT_CHINA_BANK_" + ChinaBanks.C016 },
            {ChinaBanks.C017,"ACCOUNT_CHINA_BANK_" + ChinaBanks.C017 },
            {ChinaBanks.C018,"ACCOUNT_CHINA_BANK_" + ChinaBanks.C018 },
            {ChinaBanks.C019,"ACCOUNT_CHINA_BANK_" + ChinaBanks.C019 },
            {ChinaBanks.C020,"ACCOUNT_CHINA_BANK_" + ChinaBanks.C020 },
            {ChinaBanks.C021,"ACCOUNT_CHINA_BANK_" + ChinaBanks.C021 },
            {ChinaBanks.C022,"ACCOUNT_CHINA_BANK_" + ChinaBanks.C022 },
            {ChinaBanks.C023,"ACCOUNT_CHINA_BANK_" + ChinaBanks.C023 },
            {ChinaBanks.C024,"ACCOUNT_CHINA_BANK_" + ChinaBanks.C024 },
            {ChinaBanks.C025,"ACCOUNT_CHINA_BANK_" + ChinaBanks.C025 },
            {ChinaBanks.C026,"ACCOUNT_CHINA_BANK_" + ChinaBanks.C026 },
            {ChinaBanks.C027,"ACCOUNT_CHINA_BANK_" + ChinaBanks.C027 },
            {ChinaBanks.C028,"ACCOUNT_CHINA_BANK_" + ChinaBanks.C028 },
            {ChinaBanks.C029,"ACCOUNT_CHINA_BANK_" + ChinaBanks.C029 },
            {ChinaBanks.C030,"ACCOUNT_CHINA_BANK_" + ChinaBanks.C030 },
            {ChinaBanks.C031,"ACCOUNT_CHINA_BANK_" + ChinaBanks.C031 },
            {ChinaBanks.C032,"ACCOUNT_CHINA_BANK_" + ChinaBanks.C032 },
            {ChinaBanks.C033,"ACCOUNT_CHINA_BANK_" + ChinaBanks.C033 },
            {ChinaBanks.C034,"ACCOUNT_CHINA_BANK_" + ChinaBanks.C034 },
            {ChinaBanks.C035,"ACCOUNT_CHINA_BANK_" + ChinaBanks.C035 },
            {ChinaBanks.C036,"ACCOUNT_CHINA_BANK_" + ChinaBanks.C036 },
            {ChinaBanks.C037,"ACCOUNT_CHINA_BANK_" + ChinaBanks.C037 },
            {ChinaBanks.C038,"ACCOUNT_CHINA_BANK_" + ChinaBanks.C038 },
            {ChinaBanks.C039,"ACCOUNT_CHINA_BANK_" + ChinaBanks.C039 },
            {ChinaBanks.C040,"ACCOUNT_CHINA_BANK_" + ChinaBanks.C040 },
            {ChinaBanks.C041,"ACCOUNT_CHINA_BANK_" + ChinaBanks.C041 },
            {ChinaBanks.C042,"ACCOUNT_CHINA_BANK_" + ChinaBanks.C042 },
            {ChinaBanks.C043,"ACCOUNT_CHINA_BANK_" + ChinaBanks.C043 },
            {ChinaBanks.C044,"ACCOUNT_CHINA_BANK_" + ChinaBanks.C044 },
            {ChinaBanks.C045,"ACCOUNT_CHINA_BANK_" + ChinaBanks.C045 },
            {ChinaBanks.C046,"ACCOUNT_CHINA_BANK_" + ChinaBanks.C046 },
            {ChinaBanks.C047,"ACCOUNT_CHINA_BANK_" + ChinaBanks.C047 },
            {ChinaBanks.C048,"ACCOUNT_CHINA_BANK_" + ChinaBanks.C048 },
            {ChinaBanks.C049,"ACCOUNT_CHINA_BANK_" + ChinaBanks.C049 },
            {ChinaBanks.C050,"ACCOUNT_CHINA_BANK_" + ChinaBanks.C050 },
            {ChinaBanks.C051,"ACCOUNT_CHINA_BANK_" + ChinaBanks.C051 },
            {ChinaBanks.C052,"ACCOUNT_CHINA_BANK_" + ChinaBanks.C052 },
            {ChinaBanks.C053,"ACCOUNT_CHINA_BANK_" + ChinaBanks.C053 },
            {ChinaBanks.C054,"ACCOUNT_CHINA_BANK_" + ChinaBanks.C054 },
            {ChinaBanks.C055,"ACCOUNT_CHINA_BANK_" + ChinaBanks.C055 },
            {ChinaBanks.C056,"ACCOUNT_CHINA_BANK_" + ChinaBanks.C056 },
            {ChinaBanks.C057,"ACCOUNT_CHINA_BANK_" + ChinaBanks.C057 },
            {ChinaBanks.C058,"ACCOUNT_CHINA_BANK_" + ChinaBanks.C058 },
            {ChinaBanks.C059,"ACCOUNT_CHINA_BANK_" + ChinaBanks.C059 },
            {ChinaBanks.C060,"ACCOUNT_CHINA_BANK_" + ChinaBanks.C060 },
            {ChinaBanks.C061,"ACCOUNT_CHINA_BANK_" + ChinaBanks.C061 },
            {ChinaBanks.C062,"ACCOUNT_CHINA_BANK_" + ChinaBanks.C062 },
            {ChinaBanks.C063,"ACCOUNT_CHINA_BANK_" + ChinaBanks.C063 },
            {ChinaBanks.C064,"ACCOUNT_CHINA_BANK_" + ChinaBanks.C064 },
            {ChinaBanks.C065,"ACCOUNT_CHINA_BANK_" + ChinaBanks.C065 },
            {ChinaBanks.C066,"ACCOUNT_CHINA_BANK_" + ChinaBanks.C066 },
            {ChinaBanks.C067,"ACCOUNT_CHINA_BANK_" + ChinaBanks.C067 },
            {ChinaBanks.C068,"ACCOUNT_CHINA_BANK_" + ChinaBanks.C068 },
            {ChinaBanks.C069,"ACCOUNT_CHINA_BANK_" + ChinaBanks.C069 },
            {ChinaBanks.C070,"ACCOUNT_CHINA_BANK_" + ChinaBanks.C070 },
            {ChinaBanks.C071,"ACCOUNT_CHINA_BANK_" + ChinaBanks.C071 },
            {ChinaBanks.C072,"ACCOUNT_CHINA_BANK_" + ChinaBanks.C072 },
            {ChinaBanks.C073,"ACCOUNT_CHINA_BANK_" + ChinaBanks.C073 },
            {ChinaBanks.C074,"ACCOUNT_CHINA_BANK_" + ChinaBanks.C074 },
            {ChinaBanks.C075,"ACCOUNT_CHINA_BANK_" + ChinaBanks.C075 },
            {ChinaBanks.C076,"ACCOUNT_CHINA_BANK_" + ChinaBanks.C076 },
            {ChinaBanks.C077,"ACCOUNT_CHINA_BANK_" + ChinaBanks.C077 },
            {ChinaBanks.C078,"ACCOUNT_CHINA_BANK_" + ChinaBanks.C078 },
            {ChinaBanks.C079,"ACCOUNT_CHINA_BANK_" + ChinaBanks.C079 },
            {ChinaBanks.C080,"ACCOUNT_CHINA_BANK_" + ChinaBanks.C080 },
            {ChinaBanks.C081,"ACCOUNT_CHINA_BANK_" + ChinaBanks.C081 },
            {ChinaBanks.C082,"ACCOUNT_CHINA_BANK_" + ChinaBanks.C082 },
            {ChinaBanks.C083,"ACCOUNT_CHINA_BANK_" + ChinaBanks.C083 },
            {ChinaBanks.C084,"ACCOUNT_CHINA_BANK_" + ChinaBanks.C084 },
            {ChinaBanks.C085,"ACCOUNT_CHINA_BANK_" + ChinaBanks.C085 },
            {ChinaBanks.C086,"ACCOUNT_CHINA_BANK_" + ChinaBanks.C086 },
            {ChinaBanks.C087,"ACCOUNT_CHINA_BANK_" + ChinaBanks.C087 },
            {ChinaBanks.C088,"ACCOUNT_CHINA_BANK_" + ChinaBanks.C088 },
            {ChinaBanks.C089,"ACCOUNT_CHINA_BANK_" + ChinaBanks.C089 },
            {ChinaBanks.C090,"ACCOUNT_CHINA_BANK_" + ChinaBanks.C090 },
            {ChinaBanks.C091,"ACCOUNT_CHINA_BANK_" + ChinaBanks.C091 },
            {ChinaBanks.C092,"ACCOUNT_CHINA_BANK_" + ChinaBanks.C092 },
            {ChinaBanks.C093,"ACCOUNT_CHINA_BANK_" + ChinaBanks.C093 },
            {ChinaBanks.C094,"ACCOUNT_CHINA_BANK_" + ChinaBanks.C094 },
            {ChinaBanks.C095,"ACCOUNT_CHINA_BANK_" + ChinaBanks.C095 },
            {ChinaBanks.C096,"ACCOUNT_CHINA_BANK_" + ChinaBanks.C096 },
            {ChinaBanks.C097,"ACCOUNT_CHINA_BANK_" + ChinaBanks.C097 },
            {ChinaBanks.C098,"ACCOUNT_CHINA_BANK_" + ChinaBanks.C098 },
            {ChinaBanks.C099,"ACCOUNT_CHINA_BANK_" + ChinaBanks.C099 },
            {ChinaBanks.C100,"ACCOUNT_CHINA_BANK_" + ChinaBanks.C100 },
            {ChinaBanks.C101,"ACCOUNT_CHINA_BANK_" + ChinaBanks.C101 },
            {ChinaBanks.C102,"ACCOUNT_CHINA_BANK_" + ChinaBanks.C102 },
            {ChinaBanks.C103,"ACCOUNT_CHINA_BANK_" + ChinaBanks.C103 },
            {ChinaBanks.C104,"ACCOUNT_CHINA_BANK_" + ChinaBanks.C104 },
            {ChinaBanks.C105,"ACCOUNT_CHINA_BANK_" + ChinaBanks.C105 },
            {ChinaBanks.C106,"ACCOUNT_CHINA_BANK_" + ChinaBanks.C106 },
            {ChinaBanks.C107,"ACCOUNT_CHINA_BANK_" + ChinaBanks.C107 },
            {ChinaBanks.C108,"ACCOUNT_CHINA_BANK_" + ChinaBanks.C108 },
            {ChinaBanks.C109,"ACCOUNT_CHINA_BANK_" + ChinaBanks.C109 },

        };

        #endregion

        public class ChinaMainRegions
        {
            public const string MR01 = "MR01";
            public const string MR02 = "MR02";
            public const string MR03 = "MR03";
            public const string MR04 = "MR04";
            public const string MR05 = "MR05";
            public const string MR06 = "MR06";
            public const string MR07 = "MR07";
            public const string MR08 = "MR08";
            public const string MR09 = "MR09";
            public const string MR10 = "MR10";
            public const string MR11 = "MR11";
            public const string MR12 = "MR12";
            public const string MR13 = "MR13";
            public const string MR14 = "MR14";
            public const string MR15 = "MR15";
            public const string MR16 = "MR16";
            public const string MR17 = "MR17";
            public const string MR18 = "MR18";
            public const string MR19 = "MR19";
            public const string MR20 = "MR20";
            public const string MR21 = "MR21";
            public const string MR22 = "MR22";
            public const string MR23 = "MR23";
            public const string MR24 = "MR24";
            public const string MR25 = "MR25";
            public const string MR26 = "MR26";
            public const string MR27 = "MR27";
            public const string MR28 = "MR28";
            public const string MR29 = "MR29";
            public const string MR30 = "MR30";
            public const string MR31 = "MR31";

        }

        #region ChinaMainRegionsLangMap
        public static Dictionary<string, string> ChinaMainRegionsLangMap = new Dictionary<string, string>
        {
            {ChinaMainRegions.MR01,"ACCOUNT_CHINA_MAIN_REGION_" + ChinaMainRegions.MR01 },
            {ChinaMainRegions.MR02,"ACCOUNT_CHINA_MAIN_REGION_" + ChinaMainRegions.MR02 },
            {ChinaMainRegions.MR03,"ACCOUNT_CHINA_MAIN_REGION_" + ChinaMainRegions.MR03 },
            {ChinaMainRegions.MR04,"ACCOUNT_CHINA_MAIN_REGION_" + ChinaMainRegions.MR04 },
            {ChinaMainRegions.MR05,"ACCOUNT_CHINA_MAIN_REGION_" + ChinaMainRegions.MR05 },
            {ChinaMainRegions.MR06,"ACCOUNT_CHINA_MAIN_REGION_" + ChinaMainRegions.MR06 },
            {ChinaMainRegions.MR07,"ACCOUNT_CHINA_MAIN_REGION_" + ChinaMainRegions.MR07 },
            {ChinaMainRegions.MR08,"ACCOUNT_CHINA_MAIN_REGION_" + ChinaMainRegions.MR08 },
            {ChinaMainRegions.MR09,"ACCOUNT_CHINA_MAIN_REGION_" + ChinaMainRegions.MR09 },
            {ChinaMainRegions.MR10,"ACCOUNT_CHINA_MAIN_REGION_" + ChinaMainRegions.MR10 },
            {ChinaMainRegions.MR11,"ACCOUNT_CHINA_MAIN_REGION_" + ChinaMainRegions.MR11 },
            {ChinaMainRegions.MR12,"ACCOUNT_CHINA_MAIN_REGION_" + ChinaMainRegions.MR12 },
            {ChinaMainRegions.MR13,"ACCOUNT_CHINA_MAIN_REGION_" + ChinaMainRegions.MR13 },
            {ChinaMainRegions.MR14,"ACCOUNT_CHINA_MAIN_REGION_" + ChinaMainRegions.MR14 },
            {ChinaMainRegions.MR15,"ACCOUNT_CHINA_MAIN_REGION_" + ChinaMainRegions.MR15 },
            {ChinaMainRegions.MR16,"ACCOUNT_CHINA_MAIN_REGION_" + ChinaMainRegions.MR16 },
            {ChinaMainRegions.MR17,"ACCOUNT_CHINA_MAIN_REGION_" + ChinaMainRegions.MR17 },
            {ChinaMainRegions.MR18,"ACCOUNT_CHINA_MAIN_REGION_" + ChinaMainRegions.MR18 },
            {ChinaMainRegions.MR19,"ACCOUNT_CHINA_MAIN_REGION_" + ChinaMainRegions.MR19 },
            {ChinaMainRegions.MR20,"ACCOUNT_CHINA_MAIN_REGION_" + ChinaMainRegions.MR20 },
            {ChinaMainRegions.MR21,"ACCOUNT_CHINA_MAIN_REGION_" + ChinaMainRegions.MR21 },
            {ChinaMainRegions.MR22,"ACCOUNT_CHINA_MAIN_REGION_" + ChinaMainRegions.MR22 },
            {ChinaMainRegions.MR23,"ACCOUNT_CHINA_MAIN_REGION_" + ChinaMainRegions.MR23 },
            {ChinaMainRegions.MR24,"ACCOUNT_CHINA_MAIN_REGION_" + ChinaMainRegions.MR24 },
            {ChinaMainRegions.MR25,"ACCOUNT_CHINA_MAIN_REGION_" + ChinaMainRegions.MR25 },
            {ChinaMainRegions.MR26,"ACCOUNT_CHINA_MAIN_REGION_" + ChinaMainRegions.MR26 },
            {ChinaMainRegions.MR27,"ACCOUNT_CHINA_MAIN_REGION_" + ChinaMainRegions.MR27 },
            {ChinaMainRegions.MR28,"ACCOUNT_CHINA_MAIN_REGION_" + ChinaMainRegions.MR28 },
            {ChinaMainRegions.MR29,"ACCOUNT_CHINA_MAIN_REGION_" + ChinaMainRegions.MR29 },
            {ChinaMainRegions.MR30,"ACCOUNT_CHINA_MAIN_REGION_" + ChinaMainRegions.MR30 },
            {ChinaMainRegions.MR31,"ACCOUNT_CHINA_MAIN_REGION_" + ChinaMainRegions.MR31 }
        };

        #endregion

        public class ChinaSubRegions
        {
            public const string SR001 = "SR001";
            public const string SR002 = "SR002";
            public const string SR003 = "SR003";
            public const string SR004 = "SR004";
            public const string SR005 = "SR005";
            public const string SR006 = "SR006";
            public const string SR007 = "SR007";
            public const string SR008 = "SR008";
            public const string SR009 = "SR009";
            public const string SR010 = "SR010";
            public const string SR011 = "SR011";
            public const string SR012 = "SR012";
            public const string SR013 = "SR013";
            public const string SR014 = "SR014";
            public const string SR015 = "SR015";
            public const string SR016 = "SR016";
            public const string SR017 = "SR017";
            public const string SR018 = "SR018";
            public const string SR019 = "SR019";
            public const string SR020 = "SR020";
            public const string SR021 = "SR021";
            public const string SR022 = "SR022";
            public const string SR023 = "SR023";
            public const string SR024 = "SR024";
            public const string SR025 = "SR025";
            public const string SR026 = "SR026";
            public const string SR027 = "SR027";
            public const string SR028 = "SR028";
            public const string SR029 = "SR029";
            public const string SR030 = "SR030";
            public const string SR031 = "SR031";
            public const string SR032 = "SR032";
            public const string SR033 = "SR033";
            public const string SR034 = "SR034";
            public const string SR035 = "SR035";
            public const string SR036 = "SR036";
            public const string SR037 = "SR037";
            public const string SR038 = "SR038";
            public const string SR039 = "SR039";
            public const string SR040 = "SR040";
            public const string SR041 = "SR041";
            public const string SR042 = "SR042";
            public const string SR043 = "SR043";
            public const string SR044 = "SR044";
            public const string SR045 = "SR045";
            public const string SR046 = "SR046";
            public const string SR047 = "SR047";
            public const string SR048 = "SR048";
            public const string SR049 = "SR049";
            public const string SR050 = "SR050";
            public const string SR051 = "SR051";
            public const string SR052 = "SR052";
            public const string SR053 = "SR053";
            public const string SR054 = "SR054";
            public const string SR055 = "SR055";
            public const string SR056 = "SR056";
            public const string SR057 = "SR057";
            public const string SR058 = "SR058";
            public const string SR059 = "SR059";
            public const string SR060 = "SR060";
            public const string SR061 = "SR061";
            public const string SR062 = "SR062";
            public const string SR063 = "SR063";
            public const string SR064 = "SR064";
            public const string SR065 = "SR065";
            public const string SR066 = "SR066";
            public const string SR067 = "SR067";
            public const string SR068 = "SR068";
            public const string SR069 = "SR069";
            public const string SR070 = "SR070";
            public const string SR071 = "SR071";
            public const string SR072 = "SR072";
            public const string SR073 = "SR073";
            public const string SR074 = "SR074";
            public const string SR075 = "SR075";
            public const string SR076 = "SR076";
            public const string SR077 = "SR077";
            public const string SR078 = "SR078";
            public const string SR079 = "SR079";
            public const string SR080 = "SR080";
            public const string SR081 = "SR081";
            public const string SR082 = "SR082";
            public const string SR083 = "SR083";
            public const string SR084 = "SR084";
            public const string SR085 = "SR085";
            public const string SR086 = "SR086";
            public const string SR087 = "SR087";
            public const string SR088 = "SR088";
            public const string SR089 = "SR089";
            public const string SR090 = "SR090";
            public const string SR091 = "SR091";
            public const string SR092 = "SR092";
            public const string SR093 = "SR093";
            public const string SR094 = "SR094";
            public const string SR095 = "SR095";
            public const string SR096 = "SR096";
            public const string SR097 = "SR097";
            public const string SR098 = "SR098";
            public const string SR099 = "SR099";
            public const string SR100 = "SR100";
            public const string SR101 = "SR101";
            public const string SR102 = "SR102";
            public const string SR103 = "SR103";
            public const string SR104 = "SR104";
            public const string SR105 = "SR105";
            public const string SR106 = "SR106";
            public const string SR107 = "SR107";
            public const string SR108 = "SR108";
            public const string SR109 = "SR109";
            public const string SR110 = "SR110";
            public const string SR111 = "SR111";
            public const string SR112 = "SR112";
            public const string SR113 = "SR113";
            public const string SR114 = "SR114";
            public const string SR115 = "SR115";
            public const string SR116 = "SR116";
            public const string SR117 = "SR117";
            public const string SR118 = "SR118";
            public const string SR119 = "SR119";
            public const string SR120 = "SR120";
            public const string SR121 = "SR121";
            public const string SR122 = "SR122";
            public const string SR123 = "SR123";
            public const string SR124 = "SR124";
            public const string SR125 = "SR125";
            public const string SR126 = "SR126";
            public const string SR127 = "SR127";
            public const string SR128 = "SR128";
            public const string SR129 = "SR129";
            public const string SR130 = "SR130";
            public const string SR131 = "SR131";
            public const string SR132 = "SR132";
            public const string SR133 = "SR133";
            public const string SR134 = "SR134";
            public const string SR135 = "SR135";
            public const string SR136 = "SR136";
            public const string SR137 = "SR137";
            public const string SR138 = "SR138";
            public const string SR139 = "SR139";
            public const string SR140 = "SR140";
            public const string SR141 = "SR141";
            public const string SR142 = "SR142";
            public const string SR143 = "SR143";
            public const string SR144 = "SR144";
            public const string SR145 = "SR145";
            public const string SR146 = "SR146";
            public const string SR147 = "SR147";
            public const string SR148 = "SR148";
            public const string SR149 = "SR149";
            public const string SR150 = "SR150";
            public const string SR151 = "SR151";
            public const string SR152 = "SR152";
            public const string SR153 = "SR153";
            public const string SR154 = "SR154";
            public const string SR155 = "SR155";
            public const string SR156 = "SR156";
            public const string SR157 = "SR157";
            public const string SR158 = "SR158";
            public const string SR159 = "SR159";
            public const string SR160 = "SR160";
            public const string SR161 = "SR161";
            public const string SR162 = "SR162";
            public const string SR163 = "SR163";
            public const string SR164 = "SR164";
            public const string SR165 = "SR165";
            public const string SR166 = "SR166";
            public const string SR167 = "SR167";
            public const string SR168 = "SR168";
            public const string SR169 = "SR169";
            public const string SR170 = "SR170";
            public const string SR171 = "SR171";
            public const string SR172 = "SR172";
            public const string SR173 = "SR173";
            public const string SR174 = "SR174";
            public const string SR175 = "SR175";
            public const string SR176 = "SR176";
            public const string SR177 = "SR177";
            public const string SR178 = "SR178";
            public const string SR179 = "SR179";
            public const string SR180 = "SR180";
            public const string SR181 = "SR181";
            public const string SR182 = "SR182";
            public const string SR183 = "SR183";
            public const string SR184 = "SR184";
            public const string SR185 = "SR185";
            public const string SR186 = "SR186";
            public const string SR187 = "SR187";
            public const string SR188 = "SR188";
            public const string SR189 = "SR189";
            public const string SR190 = "SR190";
            public const string SR191 = "SR191";
            public const string SR192 = "SR192";
            public const string SR193 = "SR193";
            public const string SR194 = "SR194";
            public const string SR195 = "SR195";
            public const string SR196 = "SR196";
            public const string SR197 = "SR197";
            public const string SR198 = "SR198";
            public const string SR199 = "SR199";
            public const string SR200 = "SR200";
            public const string SR201 = "SR201";
            public const string SR202 = "SR202";
            public const string SR203 = "SR203";
            public const string SR204 = "SR204";
            public const string SR205 = "SR205";
            public const string SR206 = "SR206";
            public const string SR207 = "SR207";
            public const string SR208 = "SR208";
            public const string SR209 = "SR209";
            public const string SR210 = "SR210";
            public const string SR211 = "SR211";
            public const string SR212 = "SR212";
            public const string SR213 = "SR213";
            public const string SR214 = "SR214";
            public const string SR215 = "SR215";
            public const string SR216 = "SR216";
            public const string SR217 = "SR217";
            public const string SR218 = "SR218";
            public const string SR219 = "SR219";
            public const string SR220 = "SR220";
            public const string SR221 = "SR221";
            public const string SR222 = "SR222";
            public const string SR223 = "SR223";
            public const string SR224 = "SR224";
            public const string SR225 = "SR225";
            public const string SR226 = "SR226";
            public const string SR227 = "SR227";
            public const string SR228 = "SR228";
            public const string SR229 = "SR229";
            public const string SR230 = "SR230";
            public const string SR231 = "SR231";
            public const string SR232 = "SR232";
            public const string SR233 = "SR233";
            public const string SR234 = "SR234";
            public const string SR235 = "SR235";
            public const string SR236 = "SR236";
            public const string SR237 = "SR237";
            public const string SR238 = "SR238";
            public const string SR239 = "SR239";
            public const string SR240 = "SR240";
            public const string SR241 = "SR241";
            public const string SR242 = "SR242";
            public const string SR243 = "SR243";
            public const string SR244 = "SR244";
            public const string SR245 = "SR245";
            public const string SR246 = "SR246";
            public const string SR247 = "SR247";
            public const string SR248 = "SR248";
            public const string SR249 = "SR249";
            public const string SR250 = "SR250";
            public const string SR251 = "SR251";
            public const string SR252 = "SR252";
            public const string SR253 = "SR253";
            public const string SR254 = "SR254";
            public const string SR255 = "SR255";
            public const string SR256 = "SR256";
            public const string SR257 = "SR257";
            public const string SR258 = "SR258";
            public const string SR259 = "SR259";
            public const string SR260 = "SR260";
            public const string SR261 = "SR261";
            public const string SR262 = "SR262";
            public const string SR263 = "SR263";
            public const string SR264 = "SR264";
            public const string SR265 = "SR265";
            public const string SR266 = "SR266";
            public const string SR267 = "SR267";
            public const string SR268 = "SR268";
            public const string SR269 = "SR269";
            public const string SR270 = "SR270";
            public const string SR271 = "SR271";
            public const string SR272 = "SR272";
            public const string SR273 = "SR273";
            public const string SR274 = "SR274";
            public const string SR275 = "SR275";
            public const string SR276 = "SR276";
            public const string SR277 = "SR277";
            public const string SR278 = "SR278";
            public const string SR279 = "SR279";
            public const string SR280 = "SR280";
            public const string SR281 = "SR281";
            public const string SR282 = "SR282";
            public const string SR283 = "SR283";
            public const string SR284 = "SR284";
            public const string SR285 = "SR285";
            public const string SR286 = "SR286";
            public const string SR287 = "SR287";
            public const string SR288 = "SR288";
            public const string SR289 = "SR289";
            public const string SR290 = "SR290";
            public const string SR291 = "SR291";
            public const string SR292 = "SR292";
            public const string SR293 = "SR293";
            public const string SR294 = "SR294";
            public const string SR295 = "SR295";
            public const string SR296 = "SR296";
            public const string SR297 = "SR297";
            public const string SR298 = "SR298";
            public const string SR299 = "SR299";
            public const string SR300 = "SR300";
            public const string SR301 = "SR301";
            public const string SR302 = "SR302";
            public const string SR303 = "SR303";
            public const string SR304 = "SR304";
            public const string SR305 = "SR305";
            public const string SR306 = "SR306";
            public const string SR307 = "SR307";
            public const string SR308 = "SR308";
            public const string SR309 = "SR309";
            public const string SR310 = "SR310";
            public const string SR311 = "SR311";
            public const string SR312 = "SR312";
            public const string SR313 = "SR313";
            public const string SR314 = "SR314";
            public const string SR315 = "SR315";
            public const string SR316 = "SR316";
            public const string SR317 = "SR317";
            public const string SR318 = "SR318";
            public const string SR319 = "SR319";
            public const string SR320 = "SR320";
            public const string SR321 = "SR321";
            public const string SR322 = "SR322";
            public const string SR323 = "SR323";
            public const string SR324 = "SR324";
            public const string SR325 = "SR325";
            public const string SR326 = "SR326";
            public const string SR327 = "SR327";
            public const string SR328 = "SR328";
            public const string SR329 = "SR329";
            public const string SR330 = "SR330";
            public const string SR331 = "SR331";
            public const string SR332 = "SR332";
            public const string SR333 = "SR333";
            public const string SR334 = "SR334";
            public const string SR335 = "SR335";
            public const string SR336 = "SR336";
            public const string SR337 = "SR337";
            public const string SR338 = "SR338";
            public const string SR339 = "SR339";
            public const string SR340 = "SR340";
            public const string SR341 = "SR341";
            public const string SR342 = "SR342";
            public const string SR343 = "SR343";
            public const string SR344 = "SR344";
            public const string SR345 = "SR345";
            public const string SR346 = "SR346";
            public const string SR347 = "SR347";
            public const string SR348 = "SR348";
            public const string SR349 = "SR349";
            public const string SR350 = "SR350";
            public const string SR351 = "SR351";
            public const string SR352 = "SR352";
            public const string SR353 = "SR353";
            public const string SR354 = "SR354";
            public const string SR355 = "SR355";
            public const string SR356 = "SR356";
            public const string SR357 = "SR357";
            public const string SR358 = "SR358";
            public const string SR359 = "SR359";
            public const string SR360 = "SR360";
            public const string SR361 = "SR361";
            public const string SR362 = "SR362";
            public const string SR363 = "SR363";
            public const string SR364 = "SR364";
            public const string SR365 = "SR365";
            public const string SR366 = "SR366";
            public const string SR367 = "SR367";
            public const string SR368 = "SR368";
            public const string SR369 = "SR369";
            public const string SR370 = "SR370";
            public const string SR371 = "SR371";
            public const string SR372 = "SR372";
            public const string SR373 = "SR373";
            public const string SR374 = "SR374";
            public const string SR375 = "SR375";
            public const string SR376 = "SR376";
            public const string SR377 = "SR377";
            public const string SR378 = "SR378";
            public const string SR379 = "SR379";
            public const string SR380 = "SR380";
            public const string SR381 = "SR381";
            public const string SR382 = "SR382";
            public const string SR383 = "SR383";
            public const string SR384 = "SR384";
            public const string SR385 = "SR385";
            public const string SR386 = "SR386";
            public const string SR387 = "SR387";
            public const string SR388 = "SR388";
            public const string SR389 = "SR389";
            public const string SR390 = "SR390";
            public const string SR391 = "SR391";
            public const string SR392 = "SR392";
            public const string SR393 = "SR393";
            public const string SR394 = "SR394";
            public const string SR395 = "SR395";
            public const string SR396 = "SR396";
            public const string SR397 = "SR397";
            public const string SR398 = "SR398";
            public const string SR399 = "SR399";
            public const string SR400 = "SR400";
            public const string SR401 = "SR401";
            public const string SR402 = "SR402";
            public const string SR403 = "SR403";
            public const string SR404 = "SR404";
            public const string SR405 = "SR405";
            public const string SR406 = "SR406";
            public const string SR407 = "SR407";
            public const string SR408 = "SR408";
            public const string SR409 = "SR409";
            public const string SR410 = "SR410";
            public const string SR411 = "SR411";
            public const string SR412 = "SR412";
            public const string SR413 = "SR413";
            public const string SR414 = "SR414";
            public const string SR415 = "SR415";
            public const string SR416 = "SR416";
            public const string SR417 = "SR417";
            public const string SR418 = "SR418";
            public const string SR419 = "SR419";
            public const string SR420 = "SR420";
            public const string SR421 = "SR421";
            public const string SR422 = "SR422";
            public const string SR423 = "SR423";
            public const string SR424 = "SR424";
            public const string SR425 = "SR425";
            public const string SR426 = "SR426";
            public const string SR427 = "SR427";
            public const string SR428 = "SR428";
            public const string SR429 = "SR429";
            public const string SR430 = "SR430";
            public const string SR431 = "SR431";
            public const string SR432 = "SR432";
            public const string SR433 = "SR433";
            public const string SR434 = "SR434";
            public const string SR435 = "SR435";
            public const string SR436 = "SR436";
            public const string SR437 = "SR437";
            public const string SR438 = "SR438";
            public const string SR439 = "SR439";
            public const string SR440 = "SR440";
            public const string SR441 = "SR441";
            public const string SR442 = "SR442";
            public const string SR443 = "SR443";
            public const string SR444 = "SR444";
            public const string SR445 = "SR445";
            public const string SR446 = "SR446";
            public const string SR447 = "SR447";
            public const string SR448 = "SR448";
            public const string SR449 = "SR449";
            public const string SR450 = "SR450";
            public const string SR451 = "SR451";
            public const string SR452 = "SR452";
            public const string SR453 = "SR453";
            public const string SR454 = "SR454";
            public const string SR455 = "SR455";
            public const string SR456 = "SR456";
            public const string SR457 = "SR457";
            public const string SR458 = "SR458";
            public const string SR459 = "SR459";
            public const string SR460 = "SR460";
            public const string SR461 = "SR461";
        }

        #region ChinaSubRegionsLangMap
        public static Dictionary<string, string> ChinaSubRegionsLangMap = new Dictionary<string, string>
        {
            {ChinaSubRegions.SR001,"ACCOUNT_CHINA_SUB_REGION_" + ChinaSubRegions.SR001 },
            {ChinaSubRegions.SR002,"ACCOUNT_CHINA_SUB_REGION_" + ChinaSubRegions.SR002 },
            {ChinaSubRegions.SR003,"ACCOUNT_CHINA_SUB_REGION_" + ChinaSubRegions.SR003 },
            {ChinaSubRegions.SR004,"ACCOUNT_CHINA_SUB_REGION_" + ChinaSubRegions.SR004 },
            {ChinaSubRegions.SR005,"ACCOUNT_CHINA_SUB_REGION_" + ChinaSubRegions.SR005 },
            {ChinaSubRegions.SR006,"ACCOUNT_CHINA_SUB_REGION_" + ChinaSubRegions.SR006 },
            {ChinaSubRegions.SR007,"ACCOUNT_CHINA_SUB_REGION_" + ChinaSubRegions.SR007 },
            {ChinaSubRegions.SR008,"ACCOUNT_CHINA_SUB_REGION_" + ChinaSubRegions.SR008 },
            {ChinaSubRegions.SR009,"ACCOUNT_CHINA_SUB_REGION_" + ChinaSubRegions.SR009 },
            {ChinaSubRegions.SR010,"ACCOUNT_CHINA_SUB_REGION_" + ChinaSubRegions.SR010 },
            {ChinaSubRegions.SR011,"ACCOUNT_CHINA_SUB_REGION_" + ChinaSubRegions.SR011 },
            {ChinaSubRegions.SR012,"ACCOUNT_CHINA_SUB_REGION_" + ChinaSubRegions.SR012 },
            {ChinaSubRegions.SR013,"ACCOUNT_CHINA_SUB_REGION_" + ChinaSubRegions.SR013 },
            {ChinaSubRegions.SR014,"ACCOUNT_CHINA_SUB_REGION_" + ChinaSubRegions.SR014 },
            {ChinaSubRegions.SR015,"ACCOUNT_CHINA_SUB_REGION_" + ChinaSubRegions.SR015 },
            {ChinaSubRegions.SR016,"ACCOUNT_CHINA_SUB_REGION_" + ChinaSubRegions.SR016 },
            {ChinaSubRegions.SR017,"ACCOUNT_CHINA_SUB_REGION_" + ChinaSubRegions.SR017 },
            {ChinaSubRegions.SR018,"ACCOUNT_CHINA_SUB_REGION_" + ChinaSubRegions.SR018 },
            {ChinaSubRegions.SR019,"ACCOUNT_CHINA_SUB_REGION_" + ChinaSubRegions.SR019 },
            {ChinaSubRegions.SR020,"ACCOUNT_CHINA_SUB_REGION_" + ChinaSubRegions.SR020 },
            {ChinaSubRegions.SR021,"ACCOUNT_CHINA_SUB_REGION_" + ChinaSubRegions.SR021 },
            {ChinaSubRegions.SR022,"ACCOUNT_CHINA_SUB_REGION_" + ChinaSubRegions.SR022 },
            {ChinaSubRegions.SR023,"ACCOUNT_CHINA_SUB_REGION_" + ChinaSubRegions.SR023 },
            {ChinaSubRegions.SR024,"ACCOUNT_CHINA_SUB_REGION_" + ChinaSubRegions.SR024 },
            {ChinaSubRegions.SR025,"ACCOUNT_CHINA_SUB_REGION_" + ChinaSubRegions.SR025 },
            {ChinaSubRegions.SR026,"ACCOUNT_CHINA_SUB_REGION_" + ChinaSubRegions.SR026 },
            {ChinaSubRegions.SR027,"ACCOUNT_CHINA_SUB_REGION_" + ChinaSubRegions.SR027 },
            {ChinaSubRegions.SR028,"ACCOUNT_CHINA_SUB_REGION_" + ChinaSubRegions.SR028 },
            {ChinaSubRegions.SR029,"ACCOUNT_CHINA_SUB_REGION_" + ChinaSubRegions.SR029 },
            {ChinaSubRegions.SR030,"ACCOUNT_CHINA_SUB_REGION_" + ChinaSubRegions.SR030 },
            {ChinaSubRegions.SR031,"ACCOUNT_CHINA_SUB_REGION_" + ChinaSubRegions.SR031 },
            {ChinaSubRegions.SR032,"ACCOUNT_CHINA_SUB_REGION_" + ChinaSubRegions.SR032 },
            {ChinaSubRegions.SR033,"ACCOUNT_CHINA_SUB_REGION_" + ChinaSubRegions.SR033 },
            {ChinaSubRegions.SR034,"ACCOUNT_CHINA_SUB_REGION_" + ChinaSubRegions.SR034 },
            {ChinaSubRegions.SR035,"ACCOUNT_CHINA_SUB_REGION_" + ChinaSubRegions.SR035 },
            {ChinaSubRegions.SR036,"ACCOUNT_CHINA_SUB_REGION_" + ChinaSubRegions.SR036 },
            {ChinaSubRegions.SR037,"ACCOUNT_CHINA_SUB_REGION_" + ChinaSubRegions.SR037 },
            {ChinaSubRegions.SR038,"ACCOUNT_CHINA_SUB_REGION_" + ChinaSubRegions.SR038 },
            {ChinaSubRegions.SR039,"ACCOUNT_CHINA_SUB_REGION_" + ChinaSubRegions.SR039 },
            {ChinaSubRegions.SR040,"ACCOUNT_CHINA_SUB_REGION_" + ChinaSubRegions.SR040 },
            {ChinaSubRegions.SR041,"ACCOUNT_CHINA_SUB_REGION_" + ChinaSubRegions.SR041 },
            {ChinaSubRegions.SR042,"ACCOUNT_CHINA_SUB_REGION_" + ChinaSubRegions.SR042 },
            {ChinaSubRegions.SR043,"ACCOUNT_CHINA_SUB_REGION_" + ChinaSubRegions.SR043 },
            {ChinaSubRegions.SR044,"ACCOUNT_CHINA_SUB_REGION_" + ChinaSubRegions.SR044 },
            {ChinaSubRegions.SR045,"ACCOUNT_CHINA_SUB_REGION_" + ChinaSubRegions.SR045 },
            {ChinaSubRegions.SR046,"ACCOUNT_CHINA_SUB_REGION_" + ChinaSubRegions.SR046 },
            {ChinaSubRegions.SR047,"ACCOUNT_CHINA_SUB_REGION_" + ChinaSubRegions.SR047 },
            {ChinaSubRegions.SR048,"ACCOUNT_CHINA_SUB_REGION_" + ChinaSubRegions.SR048 },
            {ChinaSubRegions.SR049,"ACCOUNT_CHINA_SUB_REGION_" + ChinaSubRegions.SR049 },
            {ChinaSubRegions.SR050,"ACCOUNT_CHINA_SUB_REGION_" + ChinaSubRegions.SR050 },
            {ChinaSubRegions.SR051,"ACCOUNT_CHINA_SUB_REGION_" + ChinaSubRegions.SR051 },
            {ChinaSubRegions.SR052,"ACCOUNT_CHINA_SUB_REGION_" + ChinaSubRegions.SR052 },
            {ChinaSubRegions.SR053,"ACCOUNT_CHINA_SUB_REGION_" + ChinaSubRegions.SR053 },
            {ChinaSubRegions.SR054,"ACCOUNT_CHINA_SUB_REGION_" + ChinaSubRegions.SR054 },
            {ChinaSubRegions.SR055,"ACCOUNT_CHINA_SUB_REGION_" + ChinaSubRegions.SR055 },
            {ChinaSubRegions.SR056,"ACCOUNT_CHINA_SUB_REGION_" + ChinaSubRegions.SR056 },
            {ChinaSubRegions.SR057,"ACCOUNT_CHINA_SUB_REGION_" + ChinaSubRegions.SR057 },
            {ChinaSubRegions.SR058,"ACCOUNT_CHINA_SUB_REGION_" + ChinaSubRegions.SR058 },
            {ChinaSubRegions.SR059,"ACCOUNT_CHINA_SUB_REGION_" + ChinaSubRegions.SR059 },
            {ChinaSubRegions.SR060,"ACCOUNT_CHINA_SUB_REGION_" + ChinaSubRegions.SR060 },
            {ChinaSubRegions.SR061,"ACCOUNT_CHINA_SUB_REGION_" + ChinaSubRegions.SR061 },
            {ChinaSubRegions.SR062,"ACCOUNT_CHINA_SUB_REGION_" + ChinaSubRegions.SR062 },
            {ChinaSubRegions.SR063,"ACCOUNT_CHINA_SUB_REGION_" + ChinaSubRegions.SR063 },
            {ChinaSubRegions.SR064,"ACCOUNT_CHINA_SUB_REGION_" + ChinaSubRegions.SR064 },
            {ChinaSubRegions.SR065,"ACCOUNT_CHINA_SUB_REGION_" + ChinaSubRegions.SR065 },
            {ChinaSubRegions.SR066,"ACCOUNT_CHINA_SUB_REGION_" + ChinaSubRegions.SR066 },
            {ChinaSubRegions.SR067,"ACCOUNT_CHINA_SUB_REGION_" + ChinaSubRegions.SR067 },
            {ChinaSubRegions.SR068,"ACCOUNT_CHINA_SUB_REGION_" + ChinaSubRegions.SR068 },
            {ChinaSubRegions.SR069,"ACCOUNT_CHINA_SUB_REGION_" + ChinaSubRegions.SR069 },
            {ChinaSubRegions.SR070,"ACCOUNT_CHINA_SUB_REGION_" + ChinaSubRegions.SR070 },
            {ChinaSubRegions.SR071,"ACCOUNT_CHINA_SUB_REGION_" + ChinaSubRegions.SR071 },
            {ChinaSubRegions.SR072,"ACCOUNT_CHINA_SUB_REGION_" + ChinaSubRegions.SR072 },
            {ChinaSubRegions.SR073,"ACCOUNT_CHINA_SUB_REGION_" + ChinaSubRegions.SR073 },
            {ChinaSubRegions.SR074,"ACCOUNT_CHINA_SUB_REGION_" + ChinaSubRegions.SR074 },
            {ChinaSubRegions.SR075,"ACCOUNT_CHINA_SUB_REGION_" + ChinaSubRegions.SR075 },
            {ChinaSubRegions.SR076,"ACCOUNT_CHINA_SUB_REGION_" + ChinaSubRegions.SR076 },
            {ChinaSubRegions.SR077,"ACCOUNT_CHINA_SUB_REGION_" + ChinaSubRegions.SR077 },
            {ChinaSubRegions.SR078,"ACCOUNT_CHINA_SUB_REGION_" + ChinaSubRegions.SR078 },
            {ChinaSubRegions.SR079,"ACCOUNT_CHINA_SUB_REGION_" + ChinaSubRegions.SR079 },
            {ChinaSubRegions.SR080,"ACCOUNT_CHINA_SUB_REGION_" + ChinaSubRegions.SR080 },
            {ChinaSubRegions.SR081,"ACCOUNT_CHINA_SUB_REGION_" + ChinaSubRegions.SR081 },
            {ChinaSubRegions.SR082,"ACCOUNT_CHINA_SUB_REGION_" + ChinaSubRegions.SR082 },
            {ChinaSubRegions.SR083,"ACCOUNT_CHINA_SUB_REGION_" + ChinaSubRegions.SR083 },
            {ChinaSubRegions.SR084,"ACCOUNT_CHINA_SUB_REGION_" + ChinaSubRegions.SR084 },
            {ChinaSubRegions.SR085,"ACCOUNT_CHINA_SUB_REGION_" + ChinaSubRegions.SR085 },
            {ChinaSubRegions.SR086,"ACCOUNT_CHINA_SUB_REGION_" + ChinaSubRegions.SR086 },
            {ChinaSubRegions.SR087,"ACCOUNT_CHINA_SUB_REGION_" + ChinaSubRegions.SR087 },
            {ChinaSubRegions.SR088,"ACCOUNT_CHINA_SUB_REGION_" + ChinaSubRegions.SR088 },
            {ChinaSubRegions.SR089,"ACCOUNT_CHINA_SUB_REGION_" + ChinaSubRegions.SR089 },
            {ChinaSubRegions.SR090,"ACCOUNT_CHINA_SUB_REGION_" + ChinaSubRegions.SR090 },
            {ChinaSubRegions.SR091,"ACCOUNT_CHINA_SUB_REGION_" + ChinaSubRegions.SR091 },
            {ChinaSubRegions.SR092,"ACCOUNT_CHINA_SUB_REGION_" + ChinaSubRegions.SR092 },
            {ChinaSubRegions.SR093,"ACCOUNT_CHINA_SUB_REGION_" + ChinaSubRegions.SR093 },
            {ChinaSubRegions.SR094,"ACCOUNT_CHINA_SUB_REGION_" + ChinaSubRegions.SR094 },
            {ChinaSubRegions.SR095,"ACCOUNT_CHINA_SUB_REGION_" + ChinaSubRegions.SR095 },
            {ChinaSubRegions.SR096,"ACCOUNT_CHINA_SUB_REGION_" + ChinaSubRegions.SR096 },
            {ChinaSubRegions.SR097,"ACCOUNT_CHINA_SUB_REGION_" + ChinaSubRegions.SR097 },
            {ChinaSubRegions.SR098,"ACCOUNT_CHINA_SUB_REGION_" + ChinaSubRegions.SR098 },
            {ChinaSubRegions.SR099,"ACCOUNT_CHINA_SUB_REGION_" + ChinaSubRegions.SR099 },
            {ChinaSubRegions.SR100,"ACCOUNT_CHINA_SUB_REGION_" + ChinaSubRegions.SR100 },
            {ChinaSubRegions.SR101,"ACCOUNT_CHINA_SUB_REGION_" + ChinaSubRegions.SR101 },
            {ChinaSubRegions.SR102,"ACCOUNT_CHINA_SUB_REGION_" + ChinaSubRegions.SR102 },
            {ChinaSubRegions.SR103,"ACCOUNT_CHINA_SUB_REGION_" + ChinaSubRegions.SR103 },
            {ChinaSubRegions.SR104,"ACCOUNT_CHINA_SUB_REGION_" + ChinaSubRegions.SR104 },
            {ChinaSubRegions.SR105,"ACCOUNT_CHINA_SUB_REGION_" + ChinaSubRegions.SR105 },
            {ChinaSubRegions.SR106,"ACCOUNT_CHINA_SUB_REGION_" + ChinaSubRegions.SR106 },
            {ChinaSubRegions.SR107,"ACCOUNT_CHINA_SUB_REGION_" + ChinaSubRegions.SR107 },
            {ChinaSubRegions.SR108,"ACCOUNT_CHINA_SUB_REGION_" + ChinaSubRegions.SR108 },
            {ChinaSubRegions.SR109,"ACCOUNT_CHINA_SUB_REGION_" + ChinaSubRegions.SR109 },
            {ChinaSubRegions.SR110,"ACCOUNT_CHINA_SUB_REGION_" + ChinaSubRegions.SR110 },
            {ChinaSubRegions.SR111,"ACCOUNT_CHINA_SUB_REGION_" + ChinaSubRegions.SR111 },
            {ChinaSubRegions.SR112,"ACCOUNT_CHINA_SUB_REGION_" + ChinaSubRegions.SR112 },
            {ChinaSubRegions.SR113,"ACCOUNT_CHINA_SUB_REGION_" + ChinaSubRegions.SR113 },
            {ChinaSubRegions.SR114,"ACCOUNT_CHINA_SUB_REGION_" + ChinaSubRegions.SR114 },
            {ChinaSubRegions.SR115,"ACCOUNT_CHINA_SUB_REGION_" + ChinaSubRegions.SR115 },
            {ChinaSubRegions.SR116,"ACCOUNT_CHINA_SUB_REGION_" + ChinaSubRegions.SR116 },
            {ChinaSubRegions.SR117,"ACCOUNT_CHINA_SUB_REGION_" + ChinaSubRegions.SR117 },
            {ChinaSubRegions.SR118,"ACCOUNT_CHINA_SUB_REGION_" + ChinaSubRegions.SR118 },
            {ChinaSubRegions.SR119,"ACCOUNT_CHINA_SUB_REGION_" + ChinaSubRegions.SR119 },
            {ChinaSubRegions.SR120,"ACCOUNT_CHINA_SUB_REGION_" + ChinaSubRegions.SR120 },
            {ChinaSubRegions.SR121,"ACCOUNT_CHINA_SUB_REGION_" + ChinaSubRegions.SR121 },
            {ChinaSubRegions.SR122,"ACCOUNT_CHINA_SUB_REGION_" + ChinaSubRegions.SR122 },
            {ChinaSubRegions.SR123,"ACCOUNT_CHINA_SUB_REGION_" + ChinaSubRegions.SR123 },
            {ChinaSubRegions.SR124,"ACCOUNT_CHINA_SUB_REGION_" + ChinaSubRegions.SR124 },
            {ChinaSubRegions.SR125,"ACCOUNT_CHINA_SUB_REGION_" + ChinaSubRegions.SR125 },
            {ChinaSubRegions.SR126,"ACCOUNT_CHINA_SUB_REGION_" + ChinaSubRegions.SR126 },
            {ChinaSubRegions.SR127,"ACCOUNT_CHINA_SUB_REGION_" + ChinaSubRegions.SR127 },
            {ChinaSubRegions.SR128,"ACCOUNT_CHINA_SUB_REGION_" + ChinaSubRegions.SR128 },
            {ChinaSubRegions.SR129,"ACCOUNT_CHINA_SUB_REGION_" + ChinaSubRegions.SR129 },
            {ChinaSubRegions.SR130,"ACCOUNT_CHINA_SUB_REGION_" + ChinaSubRegions.SR130 },
            {ChinaSubRegions.SR131,"ACCOUNT_CHINA_SUB_REGION_" + ChinaSubRegions.SR131 },
            {ChinaSubRegions.SR132,"ACCOUNT_CHINA_SUB_REGION_" + ChinaSubRegions.SR132 },
            {ChinaSubRegions.SR133,"ACCOUNT_CHINA_SUB_REGION_" + ChinaSubRegions.SR133 },
            {ChinaSubRegions.SR134,"ACCOUNT_CHINA_SUB_REGION_" + ChinaSubRegions.SR134 },
            {ChinaSubRegions.SR135,"ACCOUNT_CHINA_SUB_REGION_" + ChinaSubRegions.SR135 },
            {ChinaSubRegions.SR136,"ACCOUNT_CHINA_SUB_REGION_" + ChinaSubRegions.SR136 },
            {ChinaSubRegions.SR137,"ACCOUNT_CHINA_SUB_REGION_" + ChinaSubRegions.SR137 },
            {ChinaSubRegions.SR138,"ACCOUNT_CHINA_SUB_REGION_" + ChinaSubRegions.SR138 },
            {ChinaSubRegions.SR139,"ACCOUNT_CHINA_SUB_REGION_" + ChinaSubRegions.SR139 },
            {ChinaSubRegions.SR140,"ACCOUNT_CHINA_SUB_REGION_" + ChinaSubRegions.SR140 },
            {ChinaSubRegions.SR141,"ACCOUNT_CHINA_SUB_REGION_" + ChinaSubRegions.SR141 },
            {ChinaSubRegions.SR142,"ACCOUNT_CHINA_SUB_REGION_" + ChinaSubRegions.SR142 },
            {ChinaSubRegions.SR143,"ACCOUNT_CHINA_SUB_REGION_" + ChinaSubRegions.SR143 },
            {ChinaSubRegions.SR144,"ACCOUNT_CHINA_SUB_REGION_" + ChinaSubRegions.SR144 },
            {ChinaSubRegions.SR145,"ACCOUNT_CHINA_SUB_REGION_" + ChinaSubRegions.SR145 },
            {ChinaSubRegions.SR146,"ACCOUNT_CHINA_SUB_REGION_" + ChinaSubRegions.SR146 },
            {ChinaSubRegions.SR147,"ACCOUNT_CHINA_SUB_REGION_" + ChinaSubRegions.SR147 },
            {ChinaSubRegions.SR148,"ACCOUNT_CHINA_SUB_REGION_" + ChinaSubRegions.SR148 },
            {ChinaSubRegions.SR149,"ACCOUNT_CHINA_SUB_REGION_" + ChinaSubRegions.SR149 },
            {ChinaSubRegions.SR150,"ACCOUNT_CHINA_SUB_REGION_" + ChinaSubRegions.SR150 },
            {ChinaSubRegions.SR151,"ACCOUNT_CHINA_SUB_REGION_" + ChinaSubRegions.SR151 },
            {ChinaSubRegions.SR152,"ACCOUNT_CHINA_SUB_REGION_" + ChinaSubRegions.SR152 },
            {ChinaSubRegions.SR153,"ACCOUNT_CHINA_SUB_REGION_" + ChinaSubRegions.SR153 },
            {ChinaSubRegions.SR154,"ACCOUNT_CHINA_SUB_REGION_" + ChinaSubRegions.SR154 },
            {ChinaSubRegions.SR155,"ACCOUNT_CHINA_SUB_REGION_" + ChinaSubRegions.SR155 },
            {ChinaSubRegions.SR156,"ACCOUNT_CHINA_SUB_REGION_" + ChinaSubRegions.SR156 },
            {ChinaSubRegions.SR157,"ACCOUNT_CHINA_SUB_REGION_" + ChinaSubRegions.SR157 },
            {ChinaSubRegions.SR158,"ACCOUNT_CHINA_SUB_REGION_" + ChinaSubRegions.SR158 },
            {ChinaSubRegions.SR159,"ACCOUNT_CHINA_SUB_REGION_" + ChinaSubRegions.SR159 },
            {ChinaSubRegions.SR160,"ACCOUNT_CHINA_SUB_REGION_" + ChinaSubRegions.SR160 },
            {ChinaSubRegions.SR161,"ACCOUNT_CHINA_SUB_REGION_" + ChinaSubRegions.SR161 },
            {ChinaSubRegions.SR162,"ACCOUNT_CHINA_SUB_REGION_" + ChinaSubRegions.SR162 },
            {ChinaSubRegions.SR163,"ACCOUNT_CHINA_SUB_REGION_" + ChinaSubRegions.SR163 },
            {ChinaSubRegions.SR164,"ACCOUNT_CHINA_SUB_REGION_" + ChinaSubRegions.SR164 },
            {ChinaSubRegions.SR165,"ACCOUNT_CHINA_SUB_REGION_" + ChinaSubRegions.SR165 },
            {ChinaSubRegions.SR166,"ACCOUNT_CHINA_SUB_REGION_" + ChinaSubRegions.SR166 },
            {ChinaSubRegions.SR167,"ACCOUNT_CHINA_SUB_REGION_" + ChinaSubRegions.SR167 },
            {ChinaSubRegions.SR168,"ACCOUNT_CHINA_SUB_REGION_" + ChinaSubRegions.SR168 },
            {ChinaSubRegions.SR169,"ACCOUNT_CHINA_SUB_REGION_" + ChinaSubRegions.SR169 },
            {ChinaSubRegions.SR170,"ACCOUNT_CHINA_SUB_REGION_" + ChinaSubRegions.SR170 },
            {ChinaSubRegions.SR171,"ACCOUNT_CHINA_SUB_REGION_" + ChinaSubRegions.SR171 },
            {ChinaSubRegions.SR172,"ACCOUNT_CHINA_SUB_REGION_" + ChinaSubRegions.SR172 },
            {ChinaSubRegions.SR173,"ACCOUNT_CHINA_SUB_REGION_" + ChinaSubRegions.SR173 },
            {ChinaSubRegions.SR174,"ACCOUNT_CHINA_SUB_REGION_" + ChinaSubRegions.SR174 },
            {ChinaSubRegions.SR175,"ACCOUNT_CHINA_SUB_REGION_" + ChinaSubRegions.SR175 },
            {ChinaSubRegions.SR176,"ACCOUNT_CHINA_SUB_REGION_" + ChinaSubRegions.SR176 },
            {ChinaSubRegions.SR177,"ACCOUNT_CHINA_SUB_REGION_" + ChinaSubRegions.SR177 },
            {ChinaSubRegions.SR178,"ACCOUNT_CHINA_SUB_REGION_" + ChinaSubRegions.SR178 },
            {ChinaSubRegions.SR179,"ACCOUNT_CHINA_SUB_REGION_" + ChinaSubRegions.SR179 },
            {ChinaSubRegions.SR180,"ACCOUNT_CHINA_SUB_REGION_" + ChinaSubRegions.SR180 },
            {ChinaSubRegions.SR181,"ACCOUNT_CHINA_SUB_REGION_" + ChinaSubRegions.SR181 },
            {ChinaSubRegions.SR182,"ACCOUNT_CHINA_SUB_REGION_" + ChinaSubRegions.SR182 },
            {ChinaSubRegions.SR183,"ACCOUNT_CHINA_SUB_REGION_" + ChinaSubRegions.SR183 },
            {ChinaSubRegions.SR184,"ACCOUNT_CHINA_SUB_REGION_" + ChinaSubRegions.SR184 },
            {ChinaSubRegions.SR185,"ACCOUNT_CHINA_SUB_REGION_" + ChinaSubRegions.SR185 },
            {ChinaSubRegions.SR186,"ACCOUNT_CHINA_SUB_REGION_" + ChinaSubRegions.SR186 },
            {ChinaSubRegions.SR187,"ACCOUNT_CHINA_SUB_REGION_" + ChinaSubRegions.SR187 },
            {ChinaSubRegions.SR188,"ACCOUNT_CHINA_SUB_REGION_" + ChinaSubRegions.SR188 },
            {ChinaSubRegions.SR189,"ACCOUNT_CHINA_SUB_REGION_" + ChinaSubRegions.SR189 },
            {ChinaSubRegions.SR190,"ACCOUNT_CHINA_SUB_REGION_" + ChinaSubRegions.SR190 },
            {ChinaSubRegions.SR191,"ACCOUNT_CHINA_SUB_REGION_" + ChinaSubRegions.SR191 },
            {ChinaSubRegions.SR192,"ACCOUNT_CHINA_SUB_REGION_" + ChinaSubRegions.SR192 },
            {ChinaSubRegions.SR193,"ACCOUNT_CHINA_SUB_REGION_" + ChinaSubRegions.SR193 },
            {ChinaSubRegions.SR194,"ACCOUNT_CHINA_SUB_REGION_" + ChinaSubRegions.SR194 },
            {ChinaSubRegions.SR195,"ACCOUNT_CHINA_SUB_REGION_" + ChinaSubRegions.SR195 },
            {ChinaSubRegions.SR196,"ACCOUNT_CHINA_SUB_REGION_" + ChinaSubRegions.SR196 },
            {ChinaSubRegions.SR197,"ACCOUNT_CHINA_SUB_REGION_" + ChinaSubRegions.SR197 },
            {ChinaSubRegions.SR198,"ACCOUNT_CHINA_SUB_REGION_" + ChinaSubRegions.SR198 },
            {ChinaSubRegions.SR199,"ACCOUNT_CHINA_SUB_REGION_" + ChinaSubRegions.SR199 },
            {ChinaSubRegions.SR200,"ACCOUNT_CHINA_SUB_REGION_" + ChinaSubRegions.SR200 },
            {ChinaSubRegions.SR201,"ACCOUNT_CHINA_SUB_REGION_" + ChinaSubRegions.SR201 },
            {ChinaSubRegions.SR202,"ACCOUNT_CHINA_SUB_REGION_" + ChinaSubRegions.SR202 },
            {ChinaSubRegions.SR203,"ACCOUNT_CHINA_SUB_REGION_" + ChinaSubRegions.SR203 },
            {ChinaSubRegions.SR204,"ACCOUNT_CHINA_SUB_REGION_" + ChinaSubRegions.SR204 },
            {ChinaSubRegions.SR205,"ACCOUNT_CHINA_SUB_REGION_" + ChinaSubRegions.SR205 },
            {ChinaSubRegions.SR206,"ACCOUNT_CHINA_SUB_REGION_" + ChinaSubRegions.SR206 },
            {ChinaSubRegions.SR207,"ACCOUNT_CHINA_SUB_REGION_" + ChinaSubRegions.SR207 },
            {ChinaSubRegions.SR208,"ACCOUNT_CHINA_SUB_REGION_" + ChinaSubRegions.SR208 },
            {ChinaSubRegions.SR209,"ACCOUNT_CHINA_SUB_REGION_" + ChinaSubRegions.SR209 },
            {ChinaSubRegions.SR210,"ACCOUNT_CHINA_SUB_REGION_" + ChinaSubRegions.SR210 },
            {ChinaSubRegions.SR211,"ACCOUNT_CHINA_SUB_REGION_" + ChinaSubRegions.SR211 },
            {ChinaSubRegions.SR212,"ACCOUNT_CHINA_SUB_REGION_" + ChinaSubRegions.SR212 },
            {ChinaSubRegions.SR213,"ACCOUNT_CHINA_SUB_REGION_" + ChinaSubRegions.SR213 },
            {ChinaSubRegions.SR214,"ACCOUNT_CHINA_SUB_REGION_" + ChinaSubRegions.SR214 },
            {ChinaSubRegions.SR215,"ACCOUNT_CHINA_SUB_REGION_" + ChinaSubRegions.SR215 },
            {ChinaSubRegions.SR216,"ACCOUNT_CHINA_SUB_REGION_" + ChinaSubRegions.SR216 },
            {ChinaSubRegions.SR217,"ACCOUNT_CHINA_SUB_REGION_" + ChinaSubRegions.SR217 },
            {ChinaSubRegions.SR218,"ACCOUNT_CHINA_SUB_REGION_" + ChinaSubRegions.SR218 },
            {ChinaSubRegions.SR219,"ACCOUNT_CHINA_SUB_REGION_" + ChinaSubRegions.SR219 },
            {ChinaSubRegions.SR220,"ACCOUNT_CHINA_SUB_REGION_" + ChinaSubRegions.SR220 },
            {ChinaSubRegions.SR221,"ACCOUNT_CHINA_SUB_REGION_" + ChinaSubRegions.SR221 },
            {ChinaSubRegions.SR222,"ACCOUNT_CHINA_SUB_REGION_" + ChinaSubRegions.SR222 },
            {ChinaSubRegions.SR223,"ACCOUNT_CHINA_SUB_REGION_" + ChinaSubRegions.SR223 },
            {ChinaSubRegions.SR224,"ACCOUNT_CHINA_SUB_REGION_" + ChinaSubRegions.SR224 },
            {ChinaSubRegions.SR225,"ACCOUNT_CHINA_SUB_REGION_" + ChinaSubRegions.SR225 },
            {ChinaSubRegions.SR226,"ACCOUNT_CHINA_SUB_REGION_" + ChinaSubRegions.SR226 },
            {ChinaSubRegions.SR227,"ACCOUNT_CHINA_SUB_REGION_" + ChinaSubRegions.SR227 },
            {ChinaSubRegions.SR228,"ACCOUNT_CHINA_SUB_REGION_" + ChinaSubRegions.SR228 },
            {ChinaSubRegions.SR229,"ACCOUNT_CHINA_SUB_REGION_" + ChinaSubRegions.SR229 },
            {ChinaSubRegions.SR230,"ACCOUNT_CHINA_SUB_REGION_" + ChinaSubRegions.SR230 },
            {ChinaSubRegions.SR231,"ACCOUNT_CHINA_SUB_REGION_" + ChinaSubRegions.SR231 },
            {ChinaSubRegions.SR232,"ACCOUNT_CHINA_SUB_REGION_" + ChinaSubRegions.SR232 },
            {ChinaSubRegions.SR233,"ACCOUNT_CHINA_SUB_REGION_" + ChinaSubRegions.SR233 },
            {ChinaSubRegions.SR234,"ACCOUNT_CHINA_SUB_REGION_" + ChinaSubRegions.SR234 },
            {ChinaSubRegions.SR235,"ACCOUNT_CHINA_SUB_REGION_" + ChinaSubRegions.SR235 },
            {ChinaSubRegions.SR236,"ACCOUNT_CHINA_SUB_REGION_" + ChinaSubRegions.SR236 },
            {ChinaSubRegions.SR237,"ACCOUNT_CHINA_SUB_REGION_" + ChinaSubRegions.SR237 },
            {ChinaSubRegions.SR238,"ACCOUNT_CHINA_SUB_REGION_" + ChinaSubRegions.SR238 },
            {ChinaSubRegions.SR239,"ACCOUNT_CHINA_SUB_REGION_" + ChinaSubRegions.SR239 },
            {ChinaSubRegions.SR240,"ACCOUNT_CHINA_SUB_REGION_" + ChinaSubRegions.SR240 },
            {ChinaSubRegions.SR241,"ACCOUNT_CHINA_SUB_REGION_" + ChinaSubRegions.SR241 },
            {ChinaSubRegions.SR242,"ACCOUNT_CHINA_SUB_REGION_" + ChinaSubRegions.SR242 },
            {ChinaSubRegions.SR243,"ACCOUNT_CHINA_SUB_REGION_" + ChinaSubRegions.SR243 },
            {ChinaSubRegions.SR244,"ACCOUNT_CHINA_SUB_REGION_" + ChinaSubRegions.SR244 },
            {ChinaSubRegions.SR245,"ACCOUNT_CHINA_SUB_REGION_" + ChinaSubRegions.SR245 },
            {ChinaSubRegions.SR246,"ACCOUNT_CHINA_SUB_REGION_" + ChinaSubRegions.SR246 },
            {ChinaSubRegions.SR247,"ACCOUNT_CHINA_SUB_REGION_" + ChinaSubRegions.SR247 },
            {ChinaSubRegions.SR248,"ACCOUNT_CHINA_SUB_REGION_" + ChinaSubRegions.SR248 },
            {ChinaSubRegions.SR249,"ACCOUNT_CHINA_SUB_REGION_" + ChinaSubRegions.SR249 },
            {ChinaSubRegions.SR250,"ACCOUNT_CHINA_SUB_REGION_" + ChinaSubRegions.SR250 },
            {ChinaSubRegions.SR251,"ACCOUNT_CHINA_SUB_REGION_" + ChinaSubRegions.SR251 },
            {ChinaSubRegions.SR252,"ACCOUNT_CHINA_SUB_REGION_" + ChinaSubRegions.SR252 },
            {ChinaSubRegions.SR253,"ACCOUNT_CHINA_SUB_REGION_" + ChinaSubRegions.SR253 },
            {ChinaSubRegions.SR254,"ACCOUNT_CHINA_SUB_REGION_" + ChinaSubRegions.SR254 },
            {ChinaSubRegions.SR255,"ACCOUNT_CHINA_SUB_REGION_" + ChinaSubRegions.SR255 },
            {ChinaSubRegions.SR256,"ACCOUNT_CHINA_SUB_REGION_" + ChinaSubRegions.SR256 },
            {ChinaSubRegions.SR257,"ACCOUNT_CHINA_SUB_REGION_" + ChinaSubRegions.SR257 },
            {ChinaSubRegions.SR258,"ACCOUNT_CHINA_SUB_REGION_" + ChinaSubRegions.SR258 },
            {ChinaSubRegions.SR259,"ACCOUNT_CHINA_SUB_REGION_" + ChinaSubRegions.SR259 },
            {ChinaSubRegions.SR260,"ACCOUNT_CHINA_SUB_REGION_" + ChinaSubRegions.SR260 },
            {ChinaSubRegions.SR261,"ACCOUNT_CHINA_SUB_REGION_" + ChinaSubRegions.SR261 },
            {ChinaSubRegions.SR262,"ACCOUNT_CHINA_SUB_REGION_" + ChinaSubRegions.SR262 },
            {ChinaSubRegions.SR263,"ACCOUNT_CHINA_SUB_REGION_" + ChinaSubRegions.SR263 },
            {ChinaSubRegions.SR264,"ACCOUNT_CHINA_SUB_REGION_" + ChinaSubRegions.SR264 },
            {ChinaSubRegions.SR265,"ACCOUNT_CHINA_SUB_REGION_" + ChinaSubRegions.SR265 },
            {ChinaSubRegions.SR266,"ACCOUNT_CHINA_SUB_REGION_" + ChinaSubRegions.SR266 },
            {ChinaSubRegions.SR267,"ACCOUNT_CHINA_SUB_REGION_" + ChinaSubRegions.SR267 },
            {ChinaSubRegions.SR268,"ACCOUNT_CHINA_SUB_REGION_" + ChinaSubRegions.SR268 },
            {ChinaSubRegions.SR269,"ACCOUNT_CHINA_SUB_REGION_" + ChinaSubRegions.SR269 },
            {ChinaSubRegions.SR270,"ACCOUNT_CHINA_SUB_REGION_" + ChinaSubRegions.SR270 },
            {ChinaSubRegions.SR271,"ACCOUNT_CHINA_SUB_REGION_" + ChinaSubRegions.SR271 },
            {ChinaSubRegions.SR272,"ACCOUNT_CHINA_SUB_REGION_" + ChinaSubRegions.SR272 },
            {ChinaSubRegions.SR273,"ACCOUNT_CHINA_SUB_REGION_" + ChinaSubRegions.SR273 },
            {ChinaSubRegions.SR274,"ACCOUNT_CHINA_SUB_REGION_" + ChinaSubRegions.SR274 },
            {ChinaSubRegions.SR275,"ACCOUNT_CHINA_SUB_REGION_" + ChinaSubRegions.SR275 },
            {ChinaSubRegions.SR276,"ACCOUNT_CHINA_SUB_REGION_" + ChinaSubRegions.SR276 },
            {ChinaSubRegions.SR277,"ACCOUNT_CHINA_SUB_REGION_" + ChinaSubRegions.SR277 },
            {ChinaSubRegions.SR278,"ACCOUNT_CHINA_SUB_REGION_" + ChinaSubRegions.SR278 },
            {ChinaSubRegions.SR279,"ACCOUNT_CHINA_SUB_REGION_" + ChinaSubRegions.SR279 },
            {ChinaSubRegions.SR280,"ACCOUNT_CHINA_SUB_REGION_" + ChinaSubRegions.SR280 },
            {ChinaSubRegions.SR281,"ACCOUNT_CHINA_SUB_REGION_" + ChinaSubRegions.SR281 },
            {ChinaSubRegions.SR282,"ACCOUNT_CHINA_SUB_REGION_" + ChinaSubRegions.SR282 },
            {ChinaSubRegions.SR283,"ACCOUNT_CHINA_SUB_REGION_" + ChinaSubRegions.SR283 },
            {ChinaSubRegions.SR284,"ACCOUNT_CHINA_SUB_REGION_" + ChinaSubRegions.SR284 },
            {ChinaSubRegions.SR285,"ACCOUNT_CHINA_SUB_REGION_" + ChinaSubRegions.SR285 },
            {ChinaSubRegions.SR286,"ACCOUNT_CHINA_SUB_REGION_" + ChinaSubRegions.SR286 },
            {ChinaSubRegions.SR287,"ACCOUNT_CHINA_SUB_REGION_" + ChinaSubRegions.SR287 },
            {ChinaSubRegions.SR288,"ACCOUNT_CHINA_SUB_REGION_" + ChinaSubRegions.SR288 },
            {ChinaSubRegions.SR289,"ACCOUNT_CHINA_SUB_REGION_" + ChinaSubRegions.SR289 },
            {ChinaSubRegions.SR290,"ACCOUNT_CHINA_SUB_REGION_" + ChinaSubRegions.SR290 },
            {ChinaSubRegions.SR291,"ACCOUNT_CHINA_SUB_REGION_" + ChinaSubRegions.SR291 },
            {ChinaSubRegions.SR292,"ACCOUNT_CHINA_SUB_REGION_" + ChinaSubRegions.SR292 },
            {ChinaSubRegions.SR293,"ACCOUNT_CHINA_SUB_REGION_" + ChinaSubRegions.SR293 },
            {ChinaSubRegions.SR294,"ACCOUNT_CHINA_SUB_REGION_" + ChinaSubRegions.SR294 },
            {ChinaSubRegions.SR295,"ACCOUNT_CHINA_SUB_REGION_" + ChinaSubRegions.SR295 },
            {ChinaSubRegions.SR296,"ACCOUNT_CHINA_SUB_REGION_" + ChinaSubRegions.SR296 },
            {ChinaSubRegions.SR297,"ACCOUNT_CHINA_SUB_REGION_" + ChinaSubRegions.SR297 },
            {ChinaSubRegions.SR298,"ACCOUNT_CHINA_SUB_REGION_" + ChinaSubRegions.SR298 },
            {ChinaSubRegions.SR299,"ACCOUNT_CHINA_SUB_REGION_" + ChinaSubRegions.SR299 },
            {ChinaSubRegions.SR300,"ACCOUNT_CHINA_SUB_REGION_" + ChinaSubRegions.SR300 },
            {ChinaSubRegions.SR301,"ACCOUNT_CHINA_SUB_REGION_" + ChinaSubRegions.SR301 },
            {ChinaSubRegions.SR302,"ACCOUNT_CHINA_SUB_REGION_" + ChinaSubRegions.SR302 },
            {ChinaSubRegions.SR303,"ACCOUNT_CHINA_SUB_REGION_" + ChinaSubRegions.SR303 },
            {ChinaSubRegions.SR304,"ACCOUNT_CHINA_SUB_REGION_" + ChinaSubRegions.SR304 },
            {ChinaSubRegions.SR305,"ACCOUNT_CHINA_SUB_REGION_" + ChinaSubRegions.SR305 },
            {ChinaSubRegions.SR306,"ACCOUNT_CHINA_SUB_REGION_" + ChinaSubRegions.SR306 },
            {ChinaSubRegions.SR307,"ACCOUNT_CHINA_SUB_REGION_" + ChinaSubRegions.SR307 },
            {ChinaSubRegions.SR308,"ACCOUNT_CHINA_SUB_REGION_" + ChinaSubRegions.SR308 },
            {ChinaSubRegions.SR309,"ACCOUNT_CHINA_SUB_REGION_" + ChinaSubRegions.SR309 },
            {ChinaSubRegions.SR310,"ACCOUNT_CHINA_SUB_REGION_" + ChinaSubRegions.SR310 },
            {ChinaSubRegions.SR311,"ACCOUNT_CHINA_SUB_REGION_" + ChinaSubRegions.SR311 },
            {ChinaSubRegions.SR312,"ACCOUNT_CHINA_SUB_REGION_" + ChinaSubRegions.SR312 },
            {ChinaSubRegions.SR313,"ACCOUNT_CHINA_SUB_REGION_" + ChinaSubRegions.SR313 },
            {ChinaSubRegions.SR314,"ACCOUNT_CHINA_SUB_REGION_" + ChinaSubRegions.SR314 },
            {ChinaSubRegions.SR315,"ACCOUNT_CHINA_SUB_REGION_" + ChinaSubRegions.SR315 },
            {ChinaSubRegions.SR316,"ACCOUNT_CHINA_SUB_REGION_" + ChinaSubRegions.SR316 },
            {ChinaSubRegions.SR317,"ACCOUNT_CHINA_SUB_REGION_" + ChinaSubRegions.SR317 },
            {ChinaSubRegions.SR318,"ACCOUNT_CHINA_SUB_REGION_" + ChinaSubRegions.SR318 },
            {ChinaSubRegions.SR319,"ACCOUNT_CHINA_SUB_REGION_" + ChinaSubRegions.SR319 },
            {ChinaSubRegions.SR320,"ACCOUNT_CHINA_SUB_REGION_" + ChinaSubRegions.SR320 },
            {ChinaSubRegions.SR321,"ACCOUNT_CHINA_SUB_REGION_" + ChinaSubRegions.SR321 },
            {ChinaSubRegions.SR322,"ACCOUNT_CHINA_SUB_REGION_" + ChinaSubRegions.SR322 },
            {ChinaSubRegions.SR323,"ACCOUNT_CHINA_SUB_REGION_" + ChinaSubRegions.SR323 },
            {ChinaSubRegions.SR324,"ACCOUNT_CHINA_SUB_REGION_" + ChinaSubRegions.SR324 },
            {ChinaSubRegions.SR325,"ACCOUNT_CHINA_SUB_REGION_" + ChinaSubRegions.SR325 },
            {ChinaSubRegions.SR326,"ACCOUNT_CHINA_SUB_REGION_" + ChinaSubRegions.SR326 },
            {ChinaSubRegions.SR327,"ACCOUNT_CHINA_SUB_REGION_" + ChinaSubRegions.SR327 },
            {ChinaSubRegions.SR328,"ACCOUNT_CHINA_SUB_REGION_" + ChinaSubRegions.SR328 },
            {ChinaSubRegions.SR329,"ACCOUNT_CHINA_SUB_REGION_" + ChinaSubRegions.SR329 },
            {ChinaSubRegions.SR330,"ACCOUNT_CHINA_SUB_REGION_" + ChinaSubRegions.SR330 },
            {ChinaSubRegions.SR331,"ACCOUNT_CHINA_SUB_REGION_" + ChinaSubRegions.SR331 },
            {ChinaSubRegions.SR332,"ACCOUNT_CHINA_SUB_REGION_" + ChinaSubRegions.SR332 },
            {ChinaSubRegions.SR333,"ACCOUNT_CHINA_SUB_REGION_" + ChinaSubRegions.SR333 },
            {ChinaSubRegions.SR334,"ACCOUNT_CHINA_SUB_REGION_" + ChinaSubRegions.SR334 },
            {ChinaSubRegions.SR335,"ACCOUNT_CHINA_SUB_REGION_" + ChinaSubRegions.SR335 },
            {ChinaSubRegions.SR336,"ACCOUNT_CHINA_SUB_REGION_" + ChinaSubRegions.SR336 },
            {ChinaSubRegions.SR337,"ACCOUNT_CHINA_SUB_REGION_" + ChinaSubRegions.SR337 },
            {ChinaSubRegions.SR338,"ACCOUNT_CHINA_SUB_REGION_" + ChinaSubRegions.SR338 },
            {ChinaSubRegions.SR339,"ACCOUNT_CHINA_SUB_REGION_" + ChinaSubRegions.SR339 },
            {ChinaSubRegions.SR340,"ACCOUNT_CHINA_SUB_REGION_" + ChinaSubRegions.SR340 },
            {ChinaSubRegions.SR341,"ACCOUNT_CHINA_SUB_REGION_" + ChinaSubRegions.SR341 },
            {ChinaSubRegions.SR342,"ACCOUNT_CHINA_SUB_REGION_" + ChinaSubRegions.SR342 },
            {ChinaSubRegions.SR343,"ACCOUNT_CHINA_SUB_REGION_" + ChinaSubRegions.SR343 },
            {ChinaSubRegions.SR344,"ACCOUNT_CHINA_SUB_REGION_" + ChinaSubRegions.SR344 },
            {ChinaSubRegions.SR345,"ACCOUNT_CHINA_SUB_REGION_" + ChinaSubRegions.SR345 },
            {ChinaSubRegions.SR346,"ACCOUNT_CHINA_SUB_REGION_" + ChinaSubRegions.SR346 },
            {ChinaSubRegions.SR347,"ACCOUNT_CHINA_SUB_REGION_" + ChinaSubRegions.SR347 },
            {ChinaSubRegions.SR348,"ACCOUNT_CHINA_SUB_REGION_" + ChinaSubRegions.SR348 },
            {ChinaSubRegions.SR349,"ACCOUNT_CHINA_SUB_REGION_" + ChinaSubRegions.SR349 },
            {ChinaSubRegions.SR350,"ACCOUNT_CHINA_SUB_REGION_" + ChinaSubRegions.SR350 },
            {ChinaSubRegions.SR351,"ACCOUNT_CHINA_SUB_REGION_" + ChinaSubRegions.SR351 },
            {ChinaSubRegions.SR352,"ACCOUNT_CHINA_SUB_REGION_" + ChinaSubRegions.SR352 },
            {ChinaSubRegions.SR353,"ACCOUNT_CHINA_SUB_REGION_" + ChinaSubRegions.SR353 },
            {ChinaSubRegions.SR354,"ACCOUNT_CHINA_SUB_REGION_" + ChinaSubRegions.SR354 },
            {ChinaSubRegions.SR355,"ACCOUNT_CHINA_SUB_REGION_" + ChinaSubRegions.SR355 },
            {ChinaSubRegions.SR356,"ACCOUNT_CHINA_SUB_REGION_" + ChinaSubRegions.SR356 },
            {ChinaSubRegions.SR357,"ACCOUNT_CHINA_SUB_REGION_" + ChinaSubRegions.SR357 },
            {ChinaSubRegions.SR358,"ACCOUNT_CHINA_SUB_REGION_" + ChinaSubRegions.SR358 },
            {ChinaSubRegions.SR359,"ACCOUNT_CHINA_SUB_REGION_" + ChinaSubRegions.SR359 },
            {ChinaSubRegions.SR360,"ACCOUNT_CHINA_SUB_REGION_" + ChinaSubRegions.SR360 },
            {ChinaSubRegions.SR361,"ACCOUNT_CHINA_SUB_REGION_" + ChinaSubRegions.SR361 },
            {ChinaSubRegions.SR362,"ACCOUNT_CHINA_SUB_REGION_" + ChinaSubRegions.SR362 },
            {ChinaSubRegions.SR363,"ACCOUNT_CHINA_SUB_REGION_" + ChinaSubRegions.SR363 },
            {ChinaSubRegions.SR364,"ACCOUNT_CHINA_SUB_REGION_" + ChinaSubRegions.SR364 },
            {ChinaSubRegions.SR365,"ACCOUNT_CHINA_SUB_REGION_" + ChinaSubRegions.SR365 },
            {ChinaSubRegions.SR366,"ACCOUNT_CHINA_SUB_REGION_" + ChinaSubRegions.SR366 },
            {ChinaSubRegions.SR367,"ACCOUNT_CHINA_SUB_REGION_" + ChinaSubRegions.SR367 },
            {ChinaSubRegions.SR368,"ACCOUNT_CHINA_SUB_REGION_" + ChinaSubRegions.SR368 },
            {ChinaSubRegions.SR369,"ACCOUNT_CHINA_SUB_REGION_" + ChinaSubRegions.SR369 },
            {ChinaSubRegions.SR370,"ACCOUNT_CHINA_SUB_REGION_" + ChinaSubRegions.SR370 },
            {ChinaSubRegions.SR371,"ACCOUNT_CHINA_SUB_REGION_" + ChinaSubRegions.SR371 },
            {ChinaSubRegions.SR372,"ACCOUNT_CHINA_SUB_REGION_" + ChinaSubRegions.SR372 },
            {ChinaSubRegions.SR373,"ACCOUNT_CHINA_SUB_REGION_" + ChinaSubRegions.SR373 },
            {ChinaSubRegions.SR374,"ACCOUNT_CHINA_SUB_REGION_" + ChinaSubRegions.SR374 },
            {ChinaSubRegions.SR375,"ACCOUNT_CHINA_SUB_REGION_" + ChinaSubRegions.SR375 },
            {ChinaSubRegions.SR376,"ACCOUNT_CHINA_SUB_REGION_" + ChinaSubRegions.SR376 },
            {ChinaSubRegions.SR377,"ACCOUNT_CHINA_SUB_REGION_" + ChinaSubRegions.SR377 },
            {ChinaSubRegions.SR378,"ACCOUNT_CHINA_SUB_REGION_" + ChinaSubRegions.SR378 },
            {ChinaSubRegions.SR379,"ACCOUNT_CHINA_SUB_REGION_" + ChinaSubRegions.SR379 },
            {ChinaSubRegions.SR380,"ACCOUNT_CHINA_SUB_REGION_" + ChinaSubRegions.SR380 },
            {ChinaSubRegions.SR381,"ACCOUNT_CHINA_SUB_REGION_" + ChinaSubRegions.SR381 },
            {ChinaSubRegions.SR382,"ACCOUNT_CHINA_SUB_REGION_" + ChinaSubRegions.SR382 },
            {ChinaSubRegions.SR383,"ACCOUNT_CHINA_SUB_REGION_" + ChinaSubRegions.SR383 },
            {ChinaSubRegions.SR384,"ACCOUNT_CHINA_SUB_REGION_" + ChinaSubRegions.SR384 },
            {ChinaSubRegions.SR385,"ACCOUNT_CHINA_SUB_REGION_" + ChinaSubRegions.SR385 },
            {ChinaSubRegions.SR386,"ACCOUNT_CHINA_SUB_REGION_" + ChinaSubRegions.SR386 },
            {ChinaSubRegions.SR387,"ACCOUNT_CHINA_SUB_REGION_" + ChinaSubRegions.SR387 },
            {ChinaSubRegions.SR388,"ACCOUNT_CHINA_SUB_REGION_" + ChinaSubRegions.SR388 },
            {ChinaSubRegions.SR389,"ACCOUNT_CHINA_SUB_REGION_" + ChinaSubRegions.SR389 },
            {ChinaSubRegions.SR390,"ACCOUNT_CHINA_SUB_REGION_" + ChinaSubRegions.SR390 },
            {ChinaSubRegions.SR391,"ACCOUNT_CHINA_SUB_REGION_" + ChinaSubRegions.SR391 },
            {ChinaSubRegions.SR392,"ACCOUNT_CHINA_SUB_REGION_" + ChinaSubRegions.SR392 },
            {ChinaSubRegions.SR393,"ACCOUNT_CHINA_SUB_REGION_" + ChinaSubRegions.SR393 },
            {ChinaSubRegions.SR394,"ACCOUNT_CHINA_SUB_REGION_" + ChinaSubRegions.SR394 },
            {ChinaSubRegions.SR395,"ACCOUNT_CHINA_SUB_REGION_" + ChinaSubRegions.SR395 },
            {ChinaSubRegions.SR396,"ACCOUNT_CHINA_SUB_REGION_" + ChinaSubRegions.SR396 },
            {ChinaSubRegions.SR397,"ACCOUNT_CHINA_SUB_REGION_" + ChinaSubRegions.SR397 },
            {ChinaSubRegions.SR398,"ACCOUNT_CHINA_SUB_REGION_" + ChinaSubRegions.SR398 },
            {ChinaSubRegions.SR399,"ACCOUNT_CHINA_SUB_REGION_" + ChinaSubRegions.SR399 },
            {ChinaSubRegions.SR400,"ACCOUNT_CHINA_SUB_REGION_" + ChinaSubRegions.SR400 },
            {ChinaSubRegions.SR401,"ACCOUNT_CHINA_SUB_REGION_" + ChinaSubRegions.SR401 },
            {ChinaSubRegions.SR402,"ACCOUNT_CHINA_SUB_REGION_" + ChinaSubRegions.SR402 },
            {ChinaSubRegions.SR403,"ACCOUNT_CHINA_SUB_REGION_" + ChinaSubRegions.SR403 },
            {ChinaSubRegions.SR404,"ACCOUNT_CHINA_SUB_REGION_" + ChinaSubRegions.SR404 },
            {ChinaSubRegions.SR405,"ACCOUNT_CHINA_SUB_REGION_" + ChinaSubRegions.SR405 },
            {ChinaSubRegions.SR406,"ACCOUNT_CHINA_SUB_REGION_" + ChinaSubRegions.SR406 },
            {ChinaSubRegions.SR407,"ACCOUNT_CHINA_SUB_REGION_" + ChinaSubRegions.SR407 },
            {ChinaSubRegions.SR408,"ACCOUNT_CHINA_SUB_REGION_" + ChinaSubRegions.SR408 },
            {ChinaSubRegions.SR409,"ACCOUNT_CHINA_SUB_REGION_" + ChinaSubRegions.SR409 },
            {ChinaSubRegions.SR410,"ACCOUNT_CHINA_SUB_REGION_" + ChinaSubRegions.SR410 },
            {ChinaSubRegions.SR411,"ACCOUNT_CHINA_SUB_REGION_" + ChinaSubRegions.SR411 },
            {ChinaSubRegions.SR412,"ACCOUNT_CHINA_SUB_REGION_" + ChinaSubRegions.SR412 },
            {ChinaSubRegions.SR413,"ACCOUNT_CHINA_SUB_REGION_" + ChinaSubRegions.SR413 },
            {ChinaSubRegions.SR414,"ACCOUNT_CHINA_SUB_REGION_" + ChinaSubRegions.SR414 },
            {ChinaSubRegions.SR415,"ACCOUNT_CHINA_SUB_REGION_" + ChinaSubRegions.SR415 },
            {ChinaSubRegions.SR416,"ACCOUNT_CHINA_SUB_REGION_" + ChinaSubRegions.SR416 },
            {ChinaSubRegions.SR417,"ACCOUNT_CHINA_SUB_REGION_" + ChinaSubRegions.SR417 },
            {ChinaSubRegions.SR418,"ACCOUNT_CHINA_SUB_REGION_" + ChinaSubRegions.SR418 },
            {ChinaSubRegions.SR419,"ACCOUNT_CHINA_SUB_REGION_" + ChinaSubRegions.SR419 },
            {ChinaSubRegions.SR420,"ACCOUNT_CHINA_SUB_REGION_" + ChinaSubRegions.SR420 },
            {ChinaSubRegions.SR421,"ACCOUNT_CHINA_SUB_REGION_" + ChinaSubRegions.SR421 },
            {ChinaSubRegions.SR422,"ACCOUNT_CHINA_SUB_REGION_" + ChinaSubRegions.SR422 },
            {ChinaSubRegions.SR423,"ACCOUNT_CHINA_SUB_REGION_" + ChinaSubRegions.SR423 },
            {ChinaSubRegions.SR424,"ACCOUNT_CHINA_SUB_REGION_" + ChinaSubRegions.SR424 },
            {ChinaSubRegions.SR425,"ACCOUNT_CHINA_SUB_REGION_" + ChinaSubRegions.SR425 },
            {ChinaSubRegions.SR426,"ACCOUNT_CHINA_SUB_REGION_" + ChinaSubRegions.SR426 },
            {ChinaSubRegions.SR427,"ACCOUNT_CHINA_SUB_REGION_" + ChinaSubRegions.SR427 },
            {ChinaSubRegions.SR428,"ACCOUNT_CHINA_SUB_REGION_" + ChinaSubRegions.SR428 },
            {ChinaSubRegions.SR429,"ACCOUNT_CHINA_SUB_REGION_" + ChinaSubRegions.SR429 },
            {ChinaSubRegions.SR430,"ACCOUNT_CHINA_SUB_REGION_" + ChinaSubRegions.SR430 },
            {ChinaSubRegions.SR431,"ACCOUNT_CHINA_SUB_REGION_" + ChinaSubRegions.SR431 },
            {ChinaSubRegions.SR432,"ACCOUNT_CHINA_SUB_REGION_" + ChinaSubRegions.SR432 },
            {ChinaSubRegions.SR433,"ACCOUNT_CHINA_SUB_REGION_" + ChinaSubRegions.SR433 },
            {ChinaSubRegions.SR434,"ACCOUNT_CHINA_SUB_REGION_" + ChinaSubRegions.SR434 },
            {ChinaSubRegions.SR435,"ACCOUNT_CHINA_SUB_REGION_" + ChinaSubRegions.SR435 },
            {ChinaSubRegions.SR436,"ACCOUNT_CHINA_SUB_REGION_" + ChinaSubRegions.SR436 },
            {ChinaSubRegions.SR437,"ACCOUNT_CHINA_SUB_REGION_" + ChinaSubRegions.SR437 },
            {ChinaSubRegions.SR438,"ACCOUNT_CHINA_SUB_REGION_" + ChinaSubRegions.SR438 },
            {ChinaSubRegions.SR439,"ACCOUNT_CHINA_SUB_REGION_" + ChinaSubRegions.SR439 },
            {ChinaSubRegions.SR440,"ACCOUNT_CHINA_SUB_REGION_" + ChinaSubRegions.SR440 },
            {ChinaSubRegions.SR441,"ACCOUNT_CHINA_SUB_REGION_" + ChinaSubRegions.SR441 },
            {ChinaSubRegions.SR442,"ACCOUNT_CHINA_SUB_REGION_" + ChinaSubRegions.SR442 },
            {ChinaSubRegions.SR443,"ACCOUNT_CHINA_SUB_REGION_" + ChinaSubRegions.SR443 },
            {ChinaSubRegions.SR444,"ACCOUNT_CHINA_SUB_REGION_" + ChinaSubRegions.SR444 },
            {ChinaSubRegions.SR445,"ACCOUNT_CHINA_SUB_REGION_" + ChinaSubRegions.SR445 },
            {ChinaSubRegions.SR446,"ACCOUNT_CHINA_SUB_REGION_" + ChinaSubRegions.SR446 },
            {ChinaSubRegions.SR447,"ACCOUNT_CHINA_SUB_REGION_" + ChinaSubRegions.SR447 },
            {ChinaSubRegions.SR448,"ACCOUNT_CHINA_SUB_REGION_" + ChinaSubRegions.SR448 },
            {ChinaSubRegions.SR449,"ACCOUNT_CHINA_SUB_REGION_" + ChinaSubRegions.SR449 },
            {ChinaSubRegions.SR450,"ACCOUNT_CHINA_SUB_REGION_" + ChinaSubRegions.SR450 },
            {ChinaSubRegions.SR451,"ACCOUNT_CHINA_SUB_REGION_" + ChinaSubRegions.SR451 },
            {ChinaSubRegions.SR452,"ACCOUNT_CHINA_SUB_REGION_" + ChinaSubRegions.SR452 },
            {ChinaSubRegions.SR453,"ACCOUNT_CHINA_SUB_REGION_" + ChinaSubRegions.SR453 },
            {ChinaSubRegions.SR454,"ACCOUNT_CHINA_SUB_REGION_" + ChinaSubRegions.SR454 },
            {ChinaSubRegions.SR455,"ACCOUNT_CHINA_SUB_REGION_" + ChinaSubRegions.SR455 },
            {ChinaSubRegions.SR456,"ACCOUNT_CHINA_SUB_REGION_" + ChinaSubRegions.SR456 },
            {ChinaSubRegions.SR457,"ACCOUNT_CHINA_SUB_REGION_" + ChinaSubRegions.SR457 },
            {ChinaSubRegions.SR458,"ACCOUNT_CHINA_SUB_REGION_" + ChinaSubRegions.SR458 },
            {ChinaSubRegions.SR459,"ACCOUNT_CHINA_SUB_REGION_" + ChinaSubRegions.SR459 },
            {ChinaSubRegions.SR460,"ACCOUNT_CHINA_SUB_REGION_" + ChinaSubRegions.SR460 },
            {ChinaSubRegions.SR461,"ACCOUNT_CHINA_SUB_REGION_" + ChinaSubRegions.SR461 },

        };

        #endregion

        #region ChinaMainRegionMapToSubRegion

        public static Dictionary<string, List<string>> ChinaMainRegionMapToSubRegion = new Dictionary<string, List<string>>
        {
            { ChinaMainRegions.MR01, new List<string> { ChinaSubRegions.SR001, ChinaSubRegions.SR002, ChinaSubRegions.SR003, ChinaSubRegions.SR004, ChinaSubRegions.SR005, ChinaSubRegions.SR006, ChinaSubRegions.SR007, ChinaSubRegions.SR008, ChinaSubRegions.SR009, ChinaSubRegions.SR010, ChinaSubRegions.SR011, ChinaSubRegions.SR012, ChinaSubRegions.SR013, ChinaSubRegions.SR014, ChinaSubRegions.SR015, ChinaSubRegions.SR016, ChinaSubRegions.SR017, ChinaSubRegions.SR018, ChinaSubRegions.SR019 } },
            { ChinaMainRegions.MR02, new List<string> { ChinaSubRegions.SR020, ChinaSubRegions.SR021, ChinaSubRegions.SR022, ChinaSubRegions.SR023, ChinaSubRegions.SR024, ChinaSubRegions.SR025, ChinaSubRegions.SR026, ChinaSubRegions.SR027, ChinaSubRegions.SR028, ChinaSubRegions.SR029, ChinaSubRegions.SR030, ChinaSubRegions.SR031, ChinaSubRegions.SR032, ChinaSubRegions.SR033, ChinaSubRegions.SR034, ChinaSubRegions.SR035 } },
            { ChinaMainRegions.MR03, new List<string> { ChinaSubRegions.SR036, ChinaSubRegions.SR037, ChinaSubRegions.SR038, ChinaSubRegions.SR039, ChinaSubRegions.SR040, ChinaSubRegions.SR041, ChinaSubRegions.SR042, ChinaSubRegions.SR043, ChinaSubRegions.SR044, ChinaSubRegions.SR045, ChinaSubRegions.SR046, ChinaSubRegions.SR047 } },
            { ChinaMainRegions.MR04, new List<string> { ChinaSubRegions.SR048, ChinaSubRegions.SR049, ChinaSubRegions.SR050, ChinaSubRegions.SR051, ChinaSubRegions.SR052, ChinaSubRegions.SR053, ChinaSubRegions.SR054, ChinaSubRegions.SR055, ChinaSubRegions.SR056, ChinaSubRegions.SR057, ChinaSubRegions.SR058, ChinaSubRegions.SR059, ChinaSubRegions.SR060, ChinaSubRegions.SR061, ChinaSubRegions.SR062, ChinaSubRegions.SR063, ChinaSubRegions.SR064, ChinaSubRegions.SR065 } },
            { ChinaMainRegions.MR05, new List<string> { ChinaSubRegions.SR066, ChinaSubRegions.SR067, ChinaSubRegions.SR068, ChinaSubRegions.SR069, ChinaSubRegions.SR070, ChinaSubRegions.SR071, ChinaSubRegions.SR072, ChinaSubRegions.SR073, ChinaSubRegions.SR074 } },
            { ChinaMainRegions.MR06, new List<string> { ChinaSubRegions.SR075, ChinaSubRegions.SR076, ChinaSubRegions.SR077, ChinaSubRegions.SR078, ChinaSubRegions.SR079, ChinaSubRegions.SR080, ChinaSubRegions.SR081, ChinaSubRegions.SR082, ChinaSubRegions.SR083, ChinaSubRegions.SR084, ChinaSubRegions.SR085, ChinaSubRegions.SR086, ChinaSubRegions.SR087, ChinaSubRegions.SR088, ChinaSubRegions.SR089, ChinaSubRegions.SR090, ChinaSubRegions.SR091, ChinaSubRegions.SR092, ChinaSubRegions.SR093, ChinaSubRegions.SR094, ChinaSubRegions.SR095 } },
            { ChinaMainRegions.MR07, new List<string> { ChinaSubRegions.SR096, ChinaSubRegions.SR097, ChinaSubRegions.SR098, ChinaSubRegions.SR099, ChinaSubRegions.SR100, ChinaSubRegions.SR101, ChinaSubRegions.SR102, ChinaSubRegions.SR103, ChinaSubRegions.SR104, ChinaSubRegions.SR105, ChinaSubRegions.SR106, ChinaSubRegions.SR107, ChinaSubRegions.SR108, ChinaSubRegions.SR109, ChinaSubRegions.SR110, ChinaSubRegions.SR111, ChinaSubRegions.SR112, ChinaSubRegions.SR113 } },
            { ChinaMainRegions.MR08, new List<string> { ChinaSubRegions.SR114, ChinaSubRegions.SR115, ChinaSubRegions.SR116, ChinaSubRegions.SR117, ChinaSubRegions.SR118 } },
            { ChinaMainRegions.MR09, new List<string> { ChinaSubRegions.SR119, ChinaSubRegions.SR120, ChinaSubRegions.SR121, ChinaSubRegions.SR122, ChinaSubRegions.SR123, ChinaSubRegions.SR124, ChinaSubRegions.SR125, ChinaSubRegions.SR126, ChinaSubRegions.SR127, ChinaSubRegions.SR128, ChinaSubRegions.SR129, ChinaSubRegions.SR130, ChinaSubRegions.SR131, ChinaSubRegions.SR132, ChinaSubRegions.SR133, ChinaSubRegions.SR134, ChinaSubRegions.SR135 } },
            { ChinaMainRegions.MR10, new List<string> { ChinaSubRegions.SR136, ChinaSubRegions.SR137, ChinaSubRegions.SR138, ChinaSubRegions.SR139, ChinaSubRegions.SR140, ChinaSubRegions.SR141, ChinaSubRegions.SR142, ChinaSubRegions.SR143, ChinaSubRegions.SR144, ChinaSubRegions.SR145, ChinaSubRegions.SR146, ChinaSubRegions.SR147, ChinaSubRegions.SR148, ChinaSubRegions.SR149, ChinaSubRegions.SR150, ChinaSubRegions.SR151, ChinaSubRegions.SR152 } },
            { ChinaMainRegions.MR11, new List<string> { ChinaSubRegions.SR153, ChinaSubRegions.SR154, ChinaSubRegions.SR155, ChinaSubRegions.SR156, ChinaSubRegions.SR157, ChinaSubRegions.SR158, ChinaSubRegions.SR159, ChinaSubRegions.SR160, ChinaSubRegions.SR161, ChinaSubRegions.SR162, ChinaSubRegions.SR163 } },
            { ChinaMainRegions.MR12, new List<string> { ChinaSubRegions.SR164, ChinaSubRegions.SR165, ChinaSubRegions.SR166, ChinaSubRegions.SR167, ChinaSubRegions.SR168, ChinaSubRegions.SR169, ChinaSubRegions.SR170, ChinaSubRegions.SR171, ChinaSubRegions.SR172, ChinaSubRegions.SR173, ChinaSubRegions.SR174, ChinaSubRegions.SR175, ChinaSubRegions.SR176, ChinaSubRegions.SR177, ChinaSubRegions.SR178, ChinaSubRegions.SR179, ChinaSubRegions.SR180, ChinaSubRegions.SR181, ChinaSubRegions.SR182, ChinaSubRegions.SR183, ChinaSubRegions.SR184, ChinaSubRegions.SR185 } },
            { ChinaMainRegions.MR13, new List<string> { ChinaSubRegions.SR186, ChinaSubRegions.SR187, ChinaSubRegions.SR188, ChinaSubRegions.SR189, ChinaSubRegions.SR190, ChinaSubRegions.SR191, ChinaSubRegions.SR192, ChinaSubRegions.SR193, ChinaSubRegions.SR194, ChinaSubRegions.SR195, ChinaSubRegions.SR196, ChinaSubRegions.SR197, ChinaSubRegions.SR198, ChinaSubRegions.SR199, ChinaSubRegions.SR200 } },
            { ChinaMainRegions.MR14, new List<string> { ChinaSubRegions.SR201, ChinaSubRegions.SR202, ChinaSubRegions.SR203, ChinaSubRegions.SR204, ChinaSubRegions.SR205, ChinaSubRegions.SR206, ChinaSubRegions.SR207, ChinaSubRegions.SR208, ChinaSubRegions.SR209, ChinaSubRegions.SR210, ChinaSubRegions.SR211, ChinaSubRegions.SR212, ChinaSubRegions.SR213, ChinaSubRegions.SR214, ChinaSubRegions.SR215, ChinaSubRegions.SR216, ChinaSubRegions.SR217, ChinaSubRegions.SR218 } },
            { ChinaMainRegions.MR15, new List<string> { ChinaSubRegions.SR219, ChinaSubRegions.SR220, ChinaSubRegions.SR221, ChinaSubRegions.SR222, ChinaSubRegions.SR223, ChinaSubRegions.SR224, ChinaSubRegions.SR225, ChinaSubRegions.SR226, ChinaSubRegions.SR227, ChinaSubRegions.SR228, ChinaSubRegions.SR229, ChinaSubRegions.SR230, ChinaSubRegions.SR231, ChinaSubRegions.SR232 } },
            { ChinaMainRegions.MR16, new List<string> { ChinaSubRegions.SR233, ChinaSubRegions.SR234, ChinaSubRegions.SR235, ChinaSubRegions.SR236, ChinaSubRegions.SR237, ChinaSubRegions.SR238, ChinaSubRegions.SR239, ChinaSubRegions.SR240, ChinaSubRegions.SR241, ChinaSubRegions.SR242, ChinaSubRegions.SR243 } },
            { ChinaMainRegions.MR17, new List<string> { ChinaSubRegions.SR244, ChinaSubRegions.SR245, ChinaSubRegions.SR246, ChinaSubRegions.SR247, ChinaSubRegions.SR248, ChinaSubRegions.SR249, ChinaSubRegions.SR250, ChinaSubRegions.SR251, ChinaSubRegions.SR252, ChinaSubRegions.SR253, ChinaSubRegions.SR254 } },
            { ChinaMainRegions.MR18, new List<string> { ChinaSubRegions.SR255, ChinaSubRegions.SR256, ChinaSubRegions.SR257, ChinaSubRegions.SR258, ChinaSubRegions.SR259, ChinaSubRegions.SR260, ChinaSubRegions.SR261, ChinaSubRegions.SR262, ChinaSubRegions.SR263, ChinaSubRegions.SR264, ChinaSubRegions.SR265, ChinaSubRegions.SR266, ChinaSubRegions.SR267, ChinaSubRegions.SR268, ChinaSubRegions.SR269, ChinaSubRegions.SR270, ChinaSubRegions.SR271, ChinaSubRegions.SR272 } },
            { ChinaMainRegions.MR19, new List<string> { ChinaSubRegions.SR273, ChinaSubRegions.SR274, ChinaSubRegions.SR275, ChinaSubRegions.SR276, ChinaSubRegions.SR277, ChinaSubRegions.SR278, ChinaSubRegions.SR279, ChinaSubRegions.SR280, ChinaSubRegions.SR281, ChinaSubRegions.SR282, ChinaSubRegions.SR283, ChinaSubRegions.SR284 } },
            { ChinaMainRegions.MR20, new List<string> { ChinaSubRegions.SR285, ChinaSubRegions.SR286, ChinaSubRegions.SR287, ChinaSubRegions.SR288, ChinaSubRegions.SR289, ChinaSubRegions.SR290, ChinaSubRegions.SR291, ChinaSubRegions.SR292, ChinaSubRegions.SR293, ChinaSubRegions.SR294, ChinaSubRegions.SR295, ChinaSubRegions.SR296, ChinaSubRegions.SR297, ChinaSubRegions.SR298, ChinaSubRegions.SR299, ChinaSubRegions.SR300, ChinaSubRegions.SR301, ChinaSubRegions.SR302, ChinaSubRegions.SR303, ChinaSubRegions.SR304, ChinaSubRegions.SR305 } },
            { ChinaMainRegions.MR21, new List<string> { ChinaSubRegions.SR306, ChinaSubRegions.SR307, ChinaSubRegions.SR308, ChinaSubRegions.SR309, ChinaSubRegions.SR310, ChinaSubRegions.SR311, ChinaSubRegions.SR312, ChinaSubRegions.SR313, ChinaSubRegions.SR314, ChinaSubRegions.SR315, ChinaSubRegions.SR316, ChinaSubRegions.SR317, ChinaSubRegions.SR318, ChinaSubRegions.SR319, ChinaSubRegions.SR320, ChinaSubRegions.SR321, ChinaSubRegions.SR322, ChinaSubRegions.SR323 } },
            { ChinaMainRegions.MR22, new List<string> { ChinaSubRegions.SR324, ChinaSubRegions.SR325, ChinaSubRegions.SR326, ChinaSubRegions.SR327, ChinaSubRegions.SR328, ChinaSubRegions.SR329, ChinaSubRegions.SR330, ChinaSubRegions.SR331, ChinaSubRegions.SR332, ChinaSubRegions.SR333, ChinaSubRegions.SR334, ChinaSubRegions.SR335, ChinaSubRegions.SR336, ChinaSubRegions.SR337 } },
            { ChinaMainRegions.MR23, new List<string> { ChinaSubRegions.SR338, ChinaSubRegions.SR339, ChinaSubRegions.SR340, ChinaSubRegions.SR341, ChinaSubRegions.SR342, ChinaSubRegions.SR343, ChinaSubRegions.SR344, ChinaSubRegions.SR345, ChinaSubRegions.SR346, ChinaSubRegions.SR347, ChinaSubRegions.SR348, ChinaSubRegions.SR349, ChinaSubRegions.SR350, ChinaSubRegions.SR351 } },
            { ChinaMainRegions.MR24, new List<string> { ChinaSubRegions.SR352, ChinaSubRegions.SR353, ChinaSubRegions.SR354, ChinaSubRegions.SR355, ChinaSubRegions.SR356, ChinaSubRegions.SR357, ChinaSubRegions.SR358, ChinaSubRegions.SR359, ChinaSubRegions.SR360 } },
            { ChinaMainRegions.MR25, new List<string> { ChinaSubRegions.SR361, ChinaSubRegions.SR362, ChinaSubRegions.SR363, ChinaSubRegions.SR364, ChinaSubRegions.SR365, ChinaSubRegions.SR366, ChinaSubRegions.SR367 } },
            { ChinaMainRegions.MR26, new List<string> { ChinaSubRegions.SR368, ChinaSubRegions.SR369, ChinaSubRegions.SR370, ChinaSubRegions.SR371, ChinaSubRegions.SR372, ChinaSubRegions.SR373, ChinaSubRegions.SR374, ChinaSubRegions.SR375, ChinaSubRegions.SR376 } },
            { ChinaMainRegions.MR27, new List<string> { ChinaSubRegions.SR377, ChinaSubRegions.SR378, ChinaSubRegions.SR379, ChinaSubRegions.SR380, ChinaSubRegions.SR381, ChinaSubRegions.SR382, ChinaSubRegions.SR383, ChinaSubRegions.SR384, ChinaSubRegions.SR385, ChinaSubRegions.SR386, ChinaSubRegions.SR387, ChinaSubRegions.SR388, ChinaSubRegions.SR389, ChinaSubRegions.SR390 } },
            { ChinaMainRegions.MR28, new List<string> { ChinaSubRegions.SR391, ChinaSubRegions.SR392, ChinaSubRegions.SR393, ChinaSubRegions.SR394, ChinaSubRegions.SR395, ChinaSubRegions.SR396, ChinaSubRegions.SR397, ChinaSubRegions.SR398, ChinaSubRegions.SR399, ChinaSubRegions.SR400, ChinaSubRegions.SR401, ChinaSubRegions.SR402, ChinaSubRegions.SR403, ChinaSubRegions.SR404, ChinaSubRegions.SR405, ChinaSubRegions.SR406, ChinaSubRegions.SR407, ChinaSubRegions.SR408, ChinaSubRegions.SR409, ChinaSubRegions.SR410, ChinaSubRegions.SR411, ChinaSubRegions.SR412, ChinaSubRegions.SR413, ChinaSubRegions.SR414, ChinaSubRegions.SR415, ChinaSubRegions.SR416, ChinaSubRegions.SR417, ChinaSubRegions.SR418, ChinaSubRegions.SR419, ChinaSubRegions.SR420, ChinaSubRegions.SR421, ChinaSubRegions.SR422, ChinaSubRegions.SR423, ChinaSubRegions.SR424, ChinaSubRegions.SR425, ChinaSubRegions.SR426, ChinaSubRegions.SR427, ChinaSubRegions.SR428, ChinaSubRegions.SR429, ChinaSubRegions.SR430 } },
            { ChinaMainRegions.MR29, new List<string> { ChinaSubRegions.SR431, ChinaSubRegions.SR432, ChinaSubRegions.SR433, ChinaSubRegions.SR434, ChinaSubRegions.SR435, ChinaSubRegions.SR436, ChinaSubRegions.SR437, ChinaSubRegions.SR438, ChinaSubRegions.SR439, ChinaSubRegions.SR440 } },
            { ChinaMainRegions.MR30, new List<string> { ChinaSubRegions.SR441, ChinaSubRegions.SR442, ChinaSubRegions.SR443, ChinaSubRegions.SR444, ChinaSubRegions.SR445, ChinaSubRegions.SR446, ChinaSubRegions.SR447, ChinaSubRegions.SR448 } },
            { ChinaMainRegions.MR31, new List<string> { ChinaSubRegions.SR449, ChinaSubRegions.SR450, ChinaSubRegions.SR451, ChinaSubRegions.SR452, ChinaSubRegions.SR453, ChinaSubRegions.SR454, ChinaSubRegions.SR455, ChinaSubRegions.SR456, ChinaSubRegions.SR457, ChinaSubRegions.SR458, ChinaSubRegions.SR459, ChinaSubRegions.SR460, ChinaSubRegions.SR461 } },
        };

        #endregion ChinaMainRegionMapToSubRegion

        public bool IsSameLine(int accountId, int parentId)
        {
            Model.Member.Define memberDefine = new Model.Member.Define();

            int parentLevelId = memberDefine.GetLevelId(parentId);

            var q_exists = conn.Query<account>("select id from bitject.dbo.account where l" + parentLevelId + " = @parentId and id = @id", new { parentId = parentId, id = accountId }).FirstOrDefault();

            if (q_exists != null) return true;

            return false;
        }

        public bool IsBankAccountIdSameLine(int bankAccountId, int parentId)
        {
            Model.Member.Define memberDefine = new Model.Member.Define();

            int parentLevelId = memberDefine.GetLevelId(parentId);

            var q_exists = conn.Query<bankAccount>("select id from bitject.dbo.bankAccount where l" + parentLevelId + " = @parentId and id = @id", new { parentId = parentId, id = bankAccountId }).FirstOrDefault();

            if (q_exists != null) return true;

            return false;
        }

        public bool AccountExistCheck(int accountId)
        {
            var q_exists = conn.Query<account>("select id from bitject.dbo.account where id = @id ", new { id = accountId }).FirstOrDefault();

            if (q_exists != null) return true;

            return false;
        }

        public bool BankAccountExistCheck(int bankAccountId)
        {
            var q_exists = conn.Query<bankAccount>("select id from bitject.dbo.bankAccount where id = @id ", new { id = bankAccountId }).FirstOrDefault();

            if (q_exists != null) return true;

            return false;
        }

        public bool BankAccountExistCheck(int bankAccountId, int memberId)
        {
            var q_exists = conn.Query<bankAccount>("select id from bitject.dbo.bankAccount where id = @id and memberId = @memberId", new { id = bankAccountId, memberId = memberId }).FirstOrDefault();

            if (q_exists != null) return true;

            return false;
        }

        public bool BankAccountNumberExistCheck(string bankId, string bankAccountNumber)
        {
            var q_exists = conn.Query<bankAccount>("select id from bitject.dbo.bankAccount where bankId = @bankId and bankAccountNumber = @bankAccountNumber", new { bankId = bankId, bankAccountNumber = bankAccountNumber }).FirstOrDefault();

            if (q_exists != null) return true;

            return false;
        }

        public bool IsAccountExist(int memberId, string currency)
        {
            var q_account = conn.Query<account>("select id from bitject.dbo.account where memberId = @memberId and currency = @currency ", new { memberId = memberId, currency = currency }).FirstOrDefault();

            if (q_account != null) return true;

            return false;
        }

        public int GetAccountId(int memberId, string currencyCode)
        {
            var q_account = conn.Query<account>("select id from bitject.dbo.account where memberId = @memberId and currencyCode = @currencyCode ", new { memberId = memberId, currencyCode = currencyCode }).FirstOrDefault();

            return q_account.id;
        }

        public string GetBankPassbookImgFileName(int bankAccountId)
        {
            Security security = new Security();

            return security.MD5Encrypt("passbookImg" + bankAccountId + "##" + Model.Global.GlobalVar.personal_id_md5) + ".jpg";
        }

        public string GetBankPassbookImgPath(int memberId, int bankAccountId)
        {
            return Model.Global.GlobalVar.webDirPath + "content\\memberData\\passbookImg\\" + memberId + "\\" + GetBankPassbookImgFileName(bankAccountId);
        }

        public string GetBankPassbookImgBase64(int memberId, int bankAccountId)
        {
            string path = GetBankPassbookImgPath(memberId, bankAccountId);

            string base64 = glbf.GetFileBase64(path);

            return base64;
        }

        public decimal GetExRate(string currencyCodeFrom, string currencyCodeTo, bool withDiff = true)
        {
            decimal exRate = 1;

            List<string> currencyCodes = new List<string>() { currencyCodeFrom, currencyCodeTo };

            var exchangeRates = conn.Query<exchangeRate>("select * from [bitject].[dbo].[exchangeRate] where currencyCode in @currencyCodes", new { currencyCodes = currencyCodes }).ToDictionary(x => x.currencyCode);

            var exchangeRateFrom = exchangeRates[currencyCodeFrom];

            var exchangeRateTo = exchangeRates[currencyCodeTo];

            if (withDiff)
            {
                if (currencyCodeFrom != currencyCodeTo)
                {
                    exRate = (exchangeRateFrom.exRate * (1 - exchangeRateFrom.exSlope) - exchangeRateFrom.exIntercept) / (exchangeRateTo.exRate * (1 + exchangeRateTo.exSlope) + exchangeRateTo.exIntercept);
                }
            }
            else
            {
                exRate = exchangeRateFrom.exRate / exchangeRateTo.exRate;
            }

            return exRate;
        }

        private account q_account = null;

        private void GetAccount(int accountId, bool getNew = false)
        {
            if (q_account == null || getNew || q_account.id != accountId)
            {
                var q = conn.Query<account>("select * from bitject.dbo.account with(nolock) where id=" + accountId).FirstOrDefault();

                if (q != null) q_account = q;
            }
        }

        public string GetStauts(int accountId)
        {
            GetAccount(accountId);

            return q_account.status;
        }

        public decimal GetBalance(int accountId)
        {
            GetAccount(accountId);

            return q_account.balance;
        }

        public decimal GetForzenBalance(int accountId)
        {
            GetAccount(accountId);

            return q_account.frozenBalance;
        }

        public decimal GetValidBalance(int accountId)
        {
            GetAccount(accountId);

            return q_account.balance - q_account.frozenBalance;
        }

        public int GetMemberId(int accountId)
        {
            GetAccount(accountId);

            return q_account.memberId;
        }

        public int GetMemberLevelId(int accountId)
        {
            GetAccount(accountId);

            return q_account.memberLevelId;
        }

        public string GetCurrencyCode(int accountId)
        {
            GetAccount(accountId);

            return q_account.currencyCode;
        }

        private bankAccount q_bankAccount = null;

        private void GetBankAccount(int bankAccountId, bool getNew = false)
        {
            if (q_bankAccount == null || getNew || q_bankAccount.id != bankAccountId)
            {
                var q = conn.Query<bankAccount>("select * from bitject.dbo.bankAccount with(nolock) where id=" + bankAccountId).FirstOrDefault();

                q_bankAccount = q;
            }
        }

        public int GetBankAccountMemberId(int bankAccountId)
        {
            GetBankAccount(bankAccountId);

            return q_bankAccount.memberId;
        }

        public string GetBankAccountStatus(int bankAccountId)
        {
            GetBankAccount(bankAccountId);

            return q_bankAccount.status;
        }

        public string GetBankAccountReviewStatus(int bankAccountId)
        {
            GetBankAccount(bankAccountId);

            return q_bankAccount.reviewStatus;
        }

        public string GetBankAccountCurrencyCode(int bankAccountId)
        {
            GetBankAccount(bankAccountId);

            return q_bankAccount.currencyCode;
        }

        private Dictionary<string, exchangeRate> q_exchangeRates = new Dictionary<string, exchangeRate>();

        public exchangeRate GetExchangeRate(string currencyCode)
        {
            if (!q_exchangeRates.ContainsKey(currencyCode))
            {
                var q_exchangeRate = conn.Query<exchangeRate>("select * from bitject.dbo.exchangeRate with(nolock) where currencyCode=@currencyCode", new { currencyCode = currencyCode }).FirstOrDefault();

                q_exchangeRates[q_exchangeRate.currencyCode] = q_exchangeRate;

                return q_exchangeRate;
            }

            return q_exchangeRates[currencyCode];
        }

        public decimal GetExchangeRateExRate(string currencyCode)
        {
            GetExchangeRate(currencyCode);

            return q_exchangeRates[currencyCode].exRate;
        }

        public decimal GetExchangeRateExSlope(string currencyCode)
        {
            GetExchangeRate(currencyCode);

            return q_exchangeRates[currencyCode].exSlope;
        }

        public decimal GetExchangeRateExIntercept(string currencyCode)
        {
            GetExchangeRate(currencyCode);

            return q_exchangeRates[currencyCode].exIntercept;
        }
    }


}