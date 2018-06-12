using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Web;

namespace Model.Global
{
    public class GlobalVar
    {
        public static string sql_con_str_main = ConfigurationManager.ConnectionStrings["bitjectConnectionString"].ConnectionString;
        public static List<int> point_open_levelIds = new List<int> { Model.Member.Define.MemberLevels.SA, Model.Member.Define.MemberLevels.UpAgent, Model.Member.Define.MemberLevels.DownAgent };
        public static List<int> point_open_levelIds_with_member = new List<int> { Model.Member.Define.MemberLevels.SA, Model.Member.Define.MemberLevels.UpAgent, Model.Member.Define.MemberLevels.DownAgent, Model.Member.Define.MemberLevels.Member };
        public static List<string> list_langs = new List<string> { NationCodes.TW, NationCodes.CN, NationCodes.US };
        public static IPAddress ipa_memcached = null;
        //public static string memcached_host = ConfigurationManager.ConnectionStrings["memhost"].ConnectionString;
        //public static int memcached_port = int.Parse(ConfigurationManager.ConnectionStrings["memport"].ConnectionString);
        //public static string aes_key = ConfigurationManager.ConnectionStrings["aesKey"].ConnectionString;
        //public static string aes_iv = ConfigurationManager.ConnectionStrings["aesIv"].ConnectionString;
        public static ContryCodeProviders default_contrycode_provider = ContryCodeProviders.Cloudflare;
        //public static bool is_test = bool.Parse(ConfigurationManager.ConnectionStrings["isTest"].ConnectionString);
        public static string default_nation_when_empty = NationCodes.US;//當語系找不到時，設為此語系的資料
        public static string decimal_format = ",0.##";
        public static string personal_id_md5 = ConfigurationManager.ConnectionStrings["personalIdMd5"].ConnectionString;
        //public static string redis_host = ConfigurationManager.ConnectionStrings["redisHost"].ConnectionString;
        //public static int redis_port = int.Parse(ConfigurationManager.ConnectionStrings["redisPort"].ConnectionString);
        public static string default_currency_code = Model.Global.GlobalVar.CurrencyCodes.BJC;
        public static decimal default_feeRatio = 0.05M;
        public static string webDirPath = @"C:\Users\liaouw\Documents\Visual Studio 2015\Web\Project_Bitject\";

        public GlobalVar()
        {
        }

        static GlobalVar()
        {
            GlobalVar gv = new GlobalVar();
        }

        public class NationCodes
        {
            public const string TW = "TW";
            public const string CN = "CN";
            public const string US = "US";
        }

        public static Dictionary<string, string> NationCodesLangMap = new Dictionary<string, string>
        {
            {NationCodes.TW,"NATION_CODE_" + NationCodes.TW },
            {NationCodes.CN,"NATION_CODE_" + NationCodes.CN },
            {NationCodes.US,"NATION_CODE_" + NationCodes.US }
        };

        public class NationNumbers
        {
            public const string Taiwan = "886";
            public const string China = "86";
            public const string USA = "1";
        }

        public static Dictionary<string, string> NationNumbersLangMap = new Dictionary<string, string>
        {
            {NationNumbers.Taiwan,"NATION_NUMBER_" + NationNumbers.Taiwan },
            {NationNumbers.China,"NATION_NUMBER_" + NationNumbers.China },
            {NationNumbers.USA,"NATION_NUMBER_" + NationNumbers.USA }
        };

        public class CurrencyCodes
        {
            public const string TWD = "TWD";
            public const string CNY = "CNY";
            public const string USD = "USD";
            public const string BJC = "BJC";
        }

        public static Dictionary<string, string> CurrencyCodesLangMap = new Dictionary<string, string>
        {
            {CurrencyCodes.TWD,"CURRENCY_CODE_" + CurrencyCodes.TWD },
            {CurrencyCodes.USD,"CURRENCY_CODE_" + CurrencyCodes.USD },
            {CurrencyCodes.CNY,"CURRENCY_CODE_" + CurrencyCodes.CNY },
            {CurrencyCodes.BJC,"CURRENCY_CODE_" + CurrencyCodes.BJC }
        };
        
        public static Dictionary<string, int> CurrencyCodeDecimalDigitsMap = new Dictionary<string, int>
        {
            { CurrencyCodes.TWD, 0 },
            { CurrencyCodes.USD, 2 },
            { CurrencyCodes.CNY, 2 },
            { CurrencyCodes.BJC, 2 }
        };

        public enum ContryCodeProviders
        {
            Akamai,
            Cloudflare,
            GeoPugin,// 120/min
            Ipinfo,// 1000/day
            Dbip,// 2000/day
        }
    }
}