using GlobalUtils;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Text;

namespace Model.Global
{
    public class GlobalFunc
    {
        public GlobalFunc()
        {
        }

        public int GetFileSize(string fileBase64)
        {
            byte[] file = Convert.FromBase64String(fileBase64);

            return file.Length;
        }

        public string GetFileBase64(string fileFullPath)
        {
            if (!File.Exists(fileFullPath)) return "";

            using (var file = new FileStream(fileFullPath, FileMode.Open))
            {
                byte[] fileByte = new byte[file.Length];

                file.Read(fileByte, 0, fileByte.Length);

                return Convert.ToBase64String(fileByte);
            }
        }

        public JToken GetHttpPostResponse(string url, string requestBody)
        {
            JToken jt;

            try
            {
                byte[] requestBodyByte = Encoding.UTF8.GetBytes(requestBody);

                string memberRegisterUrl = url;

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

                        jt = JsonConvert.DeserializeObject<JObject>(st);

                        return jt;
                    }
                }
            }
            catch(Exception ex)
            {
                jt = new JObject();

                jt["result"] = "fail";

                SetLog(ex.Message + " " + url + " " + requestBody);

                return jt;
            }
        }

        public void SetLog(string text)
        {
            string logFileName = DateTime.Now.ToString("yyyyMMdd") + ".txt";

            string logDirPath = Environment.CurrentDirectory + "\\Log\\";

            if (!Directory.Exists(logDirPath)) Directory.CreateDirectory(logDirPath);

            using (StreamWriter sw = new StreamWriter(logDirPath + logFileName, true, Encoding.UTF8))
                sw.WriteLine("[" + DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss.fff") + "]" + text);
        }

        public class OSTypes
        {
            public const string Mac = "1";
            public const string Linux = "2";
            public const string Windows = "3";
            public const string WindowsPhone = "4";
            public const string IPhone = "5";
            public const string Ubuntu = "6";
            public const string Android = "7";
            public const string IPad = "8";
            public const string MeeGo = "9";
            public const string BlackBerry = "10";
        }

        public class DeviceTypes
        {
            public const string Desktop = "1";
            public const string Mobile = "2";
            public const string Tablet = "3";
        }

        private string TakeBrowserVersion(string s, int from)
        {
            string version = "";
            int point_num = 0;
            for (int i = from; i < s.Length; i++)
            {
                char c = s[i];
                bool is_point = c == '.';
                if (char.IsDigit(c) || is_point)
                {
                    if (is_point)
                    {
                        point_num++;
                        if (point_num > 1) return version;
                    }
                    version += c;
                }
                else if (c == '/') continue;
                else if (c == ' ' && version == "") continue;
                else
                {
                    return version;
                }
                if (version.Length > 20)
                {
                    return version;
                }
            }
            return version;
        }

        private string TakeOSVersion(string s, int from)
        {
            string version = "";
            for (int i = from; ; i++)
            {
                char c = s[i];
                if (char.IsDigit(c) || c == '_' || c == '.')
                {
                    version += c;
                }
                else if (c == ' ') continue;
                else
                {
                    return version.Replace("_", ".");
                }
                if (version.Length > 10) return version.Replace("_", ".");
            }
        }
    }

    public static class DecimalExtensionMethod
    {
        public static decimal RoundUp(this decimal dec, int digit)
        {
            decimal coef = (decimal)Math.Pow(10, digit);

            var tmp = Math.Ceiling(dec * coef);

            return tmp / coef;
        }

        public static decimal RoundDown(this decimal dec, int digit)
        {
            decimal coef = (decimal)Math.Pow(10, digit);

            var tmp = Math.Floor(dec * coef);

            return tmp / coef;
        }

        public static int GetDecimalDigit(this decimal dec)
        {
            string decTmp = dec.ToString();

            int digit = 0;

            int dotIndex = decTmp.IndexOf('.');

            if (dotIndex > -1) digit = decTmp.Length - (dotIndex + 1);

            return digit;
        }
    }

    public static class DateTimeExtensionMethod
    {
        public static DateTime TruncateToSecond(this DateTime dateTime)
        {
            dateTime = new DateTime(dateTime.Ticks - dateTime.Ticks % TimeSpan.TicksPerSecond);

            return dateTime;
        }
    }
}