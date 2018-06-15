using Dapper;
using GlobalUtils;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Xml.Linq;

namespace Model.Member
{
    public class Define
    {
        private SqlConnection conn = new SqlConnection(Model.Global.GlobalVar.sql_con_str_main);

        private Model.Global.GlobalFunc glbf = new Model.Global.GlobalFunc();

        private DataValidate dataValidate = new DataValidate();

        public class MemberLevels
        {
            public const int SA = 9;
            public const int UpAgent = 8;
            public const int DownAgent = 7;
            public const int Member = 1;
        }

        public static Dictionary<int, string> MemberLevelsLangMap = new Dictionary<int, string>
        {
            {MemberLevels.SA,"MEMBER_LEVELS_" + MemberLevels.SA },
            {MemberLevels.UpAgent,"MEMBER_LEVELS_" + MemberLevels.UpAgent },
            {MemberLevels.DownAgent,"MEMBER_LEVELS_" + MemberLevels.DownAgent },
            {MemberLevels.Member,"MEMBER_LEVELS_" + MemberLevels.Member },
        };

        public class MemberInfoTypes
        {
            public const string PreDepositAlarm = "1";
            public const string LowerWaterLevel = "2";
            public const string WithdrawalLowerLimit = "3";
        }

        public class AccountTypeIds
        {
            public const int Normal = 1;
            public const int Child = 2;
        }

        public static Dictionary<int, string> AccountTypeIdsLangMap = new Dictionary<int, string>
        {
            {AccountTypeIds.Normal,"ACCOUNT_TYPE_ID_" + AccountTypeIds.Normal },
            {AccountTypeIds.Child,"ACCOUNT_TYPE_ID_" + AccountTypeIds.Child },
        };

        public class LoginStauts
        {
            public const string Login = "1";
            public const string Logout = "2";
            public const string Kick = "3";
        }

        public static Dictionary<string, string> LoginStautsLangMap = new Dictionary<string, string>
        {
            { LoginStauts.Login , "LOGINSTATUS_" + LoginStauts.Login },
            { LoginStauts.Logout , "LOGINSTATUS_" + LoginStauts.Logout },
            { LoginStauts.Kick , "LOGINSTATUS_" + LoginStauts.Kick },
        };

        public class AuthStatus
        {
            public const string Enable = "1";
            public const string Disable = "2";
        }

        public static Dictionary<string, string> AuthSwitchLangMap = new Dictionary<string, string>()
        {
            { AuthStatus.Enable , "AUTHSTATUS_" + AuthStatus.Enable },
            { AuthStatus.Disable , "AUTHSTATUS_" + AuthStatus.Disable },
        };

        public int GetNextLevelId(int levelId)
        {
            int i = Model.Global.GlobalVar.point_open_levelIds.IndexOf(levelId);

            int result = 0;
            if (i >= 0)
            {
                if (i + 1 < Model.Global.GlobalVar.point_open_levelIds_with_member.Count)
                {
                    result = Model.Global.GlobalVar.point_open_levelIds_with_member.ElementAt(i + 1);
                }
            }
            return result;
        }

        public class Sex
        {
            public const string MALE = "1";
            public const string FEMALE = "2";
        }

        public static Dictionary<string, string> SexLangMap = new Dictionary<string, string>
        {
            {Sex.MALE,"MALE"},
            {Sex.FEMALE,"FEMALE"},
        };

        public class MemberStatus
        {
            public const string Valid = "1";
            public const string Invalid = "2";
            public const string PasswordLock = "3";
            public const string NeedResetPassword = "4";
        }

        public static Dictionary<string, string> MemberStatusLangMap = new Dictionary<string, string>
        {
            { MemberStatus.Valid,"MEMBERSTATUS_" + MemberStatus.Valid },
            { MemberStatus.Invalid,"MEMBERSTATUS_" + MemberStatus.Invalid },
            { MemberStatus.PasswordLock,"MEMBERSTATUS_" + MemberStatus.PasswordLock },
            { MemberStatus.NeedResetPassword,"MEMBERSTATUS_" + MemberStatus.NeedResetPassword },
        };

        public class ReviewStatus
        {
            public const string Valid = "3";
            public const string Invalid = "1";
            public const string WaitForReview = "2";
        }

        public static Dictionary<string, string> ChkedStatusLangMap = new Dictionary<string, string>
        {
            { ReviewStatus.Valid,"REVIEW_STATUS_" + ReviewStatus.Valid },
            { ReviewStatus.Invalid,"REVIEW_STATUS_" + ReviewStatus.Invalid },
            { ReviewStatus.WaitForReview,"REVIEW_STATUS_" + ReviewStatus.WaitForReview },
        };

        public class FeeModes
        {
            public const string Stack = "1";
            public const string Divide = "2";
        }

        public static Dictionary<string, string> FeeModesLangMap = new Dictionary<string, string>
        {
            { FeeModes.Stack,"FEE_MODES_" + FeeModes.Stack },
            { FeeModes.Divide,"FEE_MODES_" + FeeModes.Divide },
        };

        public class ExchangeRegisterStatus
        {
            public const string Pending = "1";
            public const string InQueue = "2";
            public const string Success = "3";
        }

        public static Dictionary<string, string> RegisterStatusLangMap = new Dictionary<string, string>
        {
            { ExchangeRegisterStatus.Pending,"REGISTER_STATUS_" + ExchangeRegisterStatus.Pending },
            { ExchangeRegisterStatus.InQueue,"REGISTER_STATUS_" + ExchangeRegisterStatus.InQueue },
            { ExchangeRegisterStatus.Success,"REGISTER_STATUS_" + ExchangeRegisterStatus.Success },
        };

        public class IndustryId
        {
            public const string GamblingAndBetting = "1";
            public const string ComputerAndElectronics = "2";
            public const string GeneralManufacturing = "3";
            public const string MiningAndQuarrying = "4";
            public const string SocialWorkReligiousAndSocialWelfare = "5";
            public const string FinancialAndInsurance = "6";
            public const string TransportationAndStorage = "7";
            public const string ConstructionAndRealEstate = "8";
            public const string HumanHealthAndEnvironment = "9";
            public const string AgricultureForestryFishingAndAnimalHusbandry = "10";
            public const string GeneralService = "11";
            public const string TourismRecreationAndSports = "12";
            public const string AccommodationAndFoodService = "13";
            public const string MassCommunication = "14";
            public const string EducationPublishingAndArts = "15";
            public const string WholesaleAndRetail = "16";
            public const string Other = "17";
        }

        public static Dictionary<string, string> IndustryIdLangMap = new Dictionary<string, string>
        {
            { IndustryId.GamblingAndBetting                           , "INDUSTRYID_" + IndustryId.GamblingAndBetting                           },
            { IndustryId.ComputerAndElectronics                       , "INDUSTRYID_" + IndustryId.ComputerAndElectronics                       },
            { IndustryId.GeneralManufacturing                         , "INDUSTRYID_" + IndustryId.GeneralManufacturing                         },
            { IndustryId.MiningAndQuarrying                           , "INDUSTRYID_" + IndustryId.MiningAndQuarrying                           },
            { IndustryId.SocialWorkReligiousAndSocialWelfare          , "INDUSTRYID_" + IndustryId.SocialWorkReligiousAndSocialWelfare          },
            { IndustryId.FinancialAndInsurance                        , "INDUSTRYID_" + IndustryId.FinancialAndInsurance                        },
            { IndustryId.TransportationAndStorage                     , "INDUSTRYID_" + IndustryId.TransportationAndStorage                     },
            { IndustryId.ConstructionAndRealEstate                    , "INDUSTRYID_" + IndustryId.ConstructionAndRealEstate                    },
            { IndustryId.HumanHealthAndEnvironment                    , "INDUSTRYID_" + IndustryId.HumanHealthAndEnvironment                    },
            { IndustryId.AgricultureForestryFishingAndAnimalHusbandry , "INDUSTRYID_" + IndustryId.AgricultureForestryFishingAndAnimalHusbandry },
            { IndustryId.GeneralService                               , "INDUSTRYID_" + IndustryId.GeneralService                               },
            { IndustryId.TourismRecreationAndSports                   , "INDUSTRYID_" + IndustryId.TourismRecreationAndSports                   },
            { IndustryId.AccommodationAndFoodService                  , "INDUSTRYID_" + IndustryId.AccommodationAndFoodService                  },
            { IndustryId.MassCommunication                            , "INDUSTRYID_" + IndustryId.MassCommunication                            },
            { IndustryId.EducationPublishingAndArts                   , "INDUSTRYID_" + IndustryId.EducationPublishingAndArts                   },
            { IndustryId.WholesaleAndRetail                           , "INDUSTRYID_" + IndustryId.WholesaleAndRetail                           },
            { IndustryId.Other                                        , "INDUSTRYID_" + IndustryId.Other                                        },
        };

        public static Dictionary<string, decimal> IndustryIdAndFeeMap = new Dictionary<string, decimal>
        {
            { IndustryId.GamblingAndBetting                           , 0.1M },
            { IndustryId.ComputerAndElectronics                       , 0.1M },
            { IndustryId.GeneralManufacturing                         , 0.1M },
            { IndustryId.MiningAndQuarrying                           , 0.1M },
            { IndustryId.SocialWorkReligiousAndSocialWelfare          , 0.1M },
            { IndustryId.FinancialAndInsurance                        , 0.1M },
            { IndustryId.TransportationAndStorage                     , 0.1M },
            { IndustryId.ConstructionAndRealEstate                    , 0.1M },
            { IndustryId.HumanHealthAndEnvironment                    , 0.1M },
            { IndustryId.AgricultureForestryFishingAndAnimalHusbandry , 0.1M },
            { IndustryId.GeneralService                               , 0.1M },
            { IndustryId.TourismRecreationAndSports                   , 0.1M },
            { IndustryId.AccommodationAndFoodService                  , 0.1M },
            { IndustryId.MassCommunication                            , 0.1M },
            { IndustryId.EducationPublishingAndArts                   , 0.1M },
            { IndustryId.WholesaleAndRetail                           , 0.1M },
            { IndustryId.Other                                        , 0.1M },
        };

        public string GetIdCardImgFileName(int memberId, bool isBackSide = false)
        {
            Security security = new Security();

            string fileName = (isBackSide ? "idCardBackSide" : "idCard") + memberId + "##" + Model.Global.GlobalVar.personal_id_md5;

            return security.MD5Encrypt(fileName) + ".jpg";
        }

        public string GetIdCardImgPath(int memberId, bool isBackSide = false)
        {
            return Model.Global.GlobalVar.webDirPath + "content\\memberData\\idCardImg\\" + memberId + "\\" + GetIdCardImgFileName(memberId);
        }

        public string GetIdCardImgBase64(int memberId, bool isBackSide = false)
        {
            string path = GetIdCardImgPath(memberId, isBackSide);

            string base64 = glbf.GetFileBase64(path);

            return base64;
        }

        public bool AgentExistCheck(int memberId)
        {
            var q_exists = conn.Query<member>("select id from bitject.dbo.member where levelId >= " + MemberLevels.DownAgent + " and id = " + memberId).FirstOrDefault();

            if (q_exists != null) return true;

            return false;
        }

        public bool MemberExistCheck(int memberId , bool includeAgent = false)
        {
            string sql = "select id from bitject.dbo.member where id = " + memberId;

            if (!includeAgent) sql += " and levelId = " + MemberLevels.Member;

            var q_exists = conn.Query<member>(sql).FirstOrDefault();

            if (q_exists != null) return true;

            return false;
        }

        public bool MemberExistCheck(int agentId, string externalId)
        {
            var q_exists = conn.Query<member>("select id from bitject.dbo.member where levelId = " + MemberLevels.Member + " and parentId = @parentId and externalId = @externalId ", new { parentId = agentId, externalId = externalId }).FirstOrDefault();

            if (q_exists != null) return true;

            return false;
        }

        public bool IsSameLine(int childId, int parentId)
        {
            int parentLevelId = GetLevelId(parentId);

            var q_exists = conn.Query<member>("select id from bitject.dbo.member where l" + parentLevelId + " = @parentId and id = @id", new { parentId = parentId, id = childId }).FirstOrDefault();

            if (q_exists != null) return true;

            return false;
        }

        public bool IsFeeDividedOwnPercentLessThanParent(int parentId, decimal feeDividedOwnPercent)
        {
            decimal parentOwnPercent = GetFeeDividedOwnPercent(parentId).Value;

            if (feeDividedOwnPercent > parentOwnPercent) return false;

            return true;
        }

        public bool IsFeeStackedOwnPercentMoreThanParent(int parentId, decimal feeStackedOwnPercent)
        {
            decimal parentOwnPercent = GetFeeStackedOwnPercent(parentId).Value;

            if (feeStackedOwnPercent > parentOwnPercent) return false;

            return true;
        }

        public bool EmailExistCheck(string email, bool isMember, bool isApiCreate)
        {
            string levelId_target = "";

            if (isMember)
            {
                levelId_target = Model.Member.Define.MemberLevels.Member.ToString();
            }
            else
            {
                foreach (var l in Model.Global.GlobalVar.point_open_levelIds)
                {
                    levelId_target += l + ",";
                }
                levelId_target = levelId_target.Remove(levelId_target.Length - 1);
            }
            var q_exists = conn.Query<member>("select id from bitject.dbo.member where email='" + email + "' and levelId in (" + levelId_target + ") and isApiCreate = " + Convert.ToByte(isApiCreate)).ToList();

            if (q_exists.Count > 0) return true;

            return false;
        }

        //檢查該電話是否為自己所有
        public bool PhoneNumberExistCheck(string phoneNumber, bool isMember)
        {
            string levelId_target = "";

            if (isMember)
            {
                levelId_target = Model.Member.Define.MemberLevels.Member.ToString();
            }
            else
            {
                foreach (var l in Model.Global.GlobalVar.point_open_levelIds)
                {
                    levelId_target += l + ",";
                }
                levelId_target = levelId_target.Remove(levelId_target.Length - 1);
            }
            var q_exists = conn.Query<member>("select id,companyId from bitject.dbo.member where phoneNumber='" + phoneNumber + "' and levelId in (" + levelId_target + ")").ToList();
            if (q_exists.Count > 0) return true;
            else return false;
        }

        public bool PhoneNumberExistCheck(string phoneNumber)
        {
            var q_exist = conn.Query<member>("select id from bitject.dbo.member where phoneNumber='" + phoneNumber + "'").FirstOrDefault();

            if (q_exist != null) return true;

            return false;
        }

        public bool PhoneNumberSelfCheck(string phoneNumber, int id)
        {
            var q_exist = conn.Query<member>("select id from bitject.dbo.member where phoneNumber='" + phoneNumber + "' and id = " + id).FirstOrDefault();

            if (q_exist != null) return true;

            return false;
        }

        public bool PhoneNumberFormatCheck(string nationNumber, string phone)
        {
            var r = new Regex("[^0-9]").Match(phone);

            if (r.Success) return false;

            switch (nationNumber)
            {
                case Model.Global.GlobalVar.NationNumbers.Taiwan:
                    {
                        if (phone.Length != 10) return false;
                        if (phone.IndexOf("09") != 0) return false;
                        return true;
                    }
                case Model.Global.GlobalVar.NationNumbers.China:
                    {
                        if (phone.Length != 11) return false;
                        if (phone[0] != '1') return false;
                        return true;
                    }
            }

            return false;
        }

        public bool UsernameExistCheck(string username)
        {
            var q_exist = conn.Query<member>("select id from bitject.dbo.member where username=@username", new { username = username }).FirstOrDefault();

            if (q_exist != null) return true;

            return false;
        }

        public int PasswordValidate(string password)
        {
            if (string.IsNullOrEmpty(password) || password.Length < 6 || password.Length > 12)
            {
                return 1;
            }

            if (!dataValidate.IsLetterOrDigitOrSymbol(password))
            {
                return 2;
            }

            if (!dataValidate.PasswordComplexityCheck(password, 2, 0, 0))
            {
                return 3;
            }

            return 0;
        }

        public int UsernameValidate(string username)
        {
            if (string.IsNullOrEmpty(username) || username.Length < 4 || username.Length > 12)
            {
                return 1;
            }

            var r = new Regex("[^a-zA-Z0-9]").Match(username);

            if (r.Success) return 2;

            if (!dataValidate.PasswordComplexityCheck(username, 1, 1, 0))
            {
                return 3;
            }

            return 0;
        }

        public bool PersonalIdValidate(string personalId)
        {
            return dataValidate.IsPersonalId(personalId);
        }

        public int AccountNameValidate(string name)
        {
            if (string.IsNullOrEmpty(name) || name.Length < 1 || name.Length > 10)
            {
                return 1;
            }

            var r = new Regex("[^\u4e00-\u9fa5a-zA-Z]").Match(name);

            if (r.Success) return 2;

            return 0;
        }

        public int CommunicatAccountNameValidate(string name)
        {
            if (string.IsNullOrEmpty(name) || name.Length <= 1 || name.Length > 30)
            {
                return 1;
            }
            var r = new Regex("[^a-zA-Z0-9_\\@\\.-]");
            var m = r.Match(name);
            if (m.Success)
            {
                return 2;
            }

            return 0;
        }

        public int SubDomainPrefixValidate(string prefix)
        {
            if (string.IsNullOrEmpty(prefix) || prefix.Length < 4 || prefix.Length > 6)
            {
                return 1;
            }
            var r = new Regex("[^a-zA-Z0-9]");
            var m = r.Match(prefix);
            if (m.Success)
            {
                return 2;
            }

            return 0;
        }

        public string GetRandomPassword(int length)
        {
            int length_new = length - 2;
            int min = (int)Math.Pow(10, length_new);
            int max = min * 10 - 1;
            return RandomLetter() + "" + RandomLetter() + new Random(Guid.NewGuid().GetHashCode()).Next(min, max);
        }

        private char RandomLetter()
        {
            return (char)new Random(Guid.NewGuid().GetHashCode()).Next(97, 122);
        }

        public HashSet<int> SearchMemberId(string username)
        {
            HashSet<int> hash_memberId = new HashSet<int>();
            try
            {
                bool is_search_id = username[0] == '#';
                username = username.Replace("#", "");
                if (is_search_id)
                {
                    int ii;
                    if (int.TryParse(username, out ii))
                    {
                        hash_memberId.Add(ii);
                    }
                }
                else
                {
                    string select_str = "select id from game.dbo.member with(nolock) where username=@u";
                    var q_member = conn.Query<int?>(select_str, new { u = username }).FirstOrDefault();
                    if (!q_member.HasValue)
                    {
                        string select_str2 = "select id from game.dbo.member with(nolock) where username like @u or nickname like @u";
                        var q_member2 = conn.Query<int>(select_str2, new { u = "" + username + "%" }).ToList();
                        if (q_member2.Count == 0)
                        {
                            hash_memberId.Add(0);
                        }
                        else
                        {
                            foreach (var i in q_member2)
                            {
                                hash_memberId.Add(i);
                            }
                        }
                    }
                    else
                    {
                        hash_memberId.Add(q_member.Value);
                    }
                }
            }
            catch
            {
            }
            return hash_memberId;
        }

        private JToken jt_info = null;
        private member q_member = null;

        public string GetUsername(int memberId)
        {
            GetMember(memberId);

            return q_member.username;
        }

        public string GetPassword(int memberId)
        {
            GetMember(memberId);

            return q_member.password;
        }

        public int GetParentId(int memberId)
        {
            GetMember(memberId);

            return q_member.parentId;
        }

        public string GetNickname(int memberId)
        {
            GetMember(memberId);

            return q_member.nickname;
        }

        public string GetFirstName(int memberId)
        {
            GetMember(memberId);

            return q_member.firstName;
        }

        public string GetLastName(int memberId)
        {
            GetMember(memberId);

            return q_member.lastName;
        }

        public string GetPersonalId(int memberId)
        {
            GetMember(memberId);

            return q_member.personalId;
        }

        public int GetLevelId(int memberId)
        {
            GetMember(memberId);

            return q_member.levelId;
        }

        public int GetAccountType(int memberId)
        {
            GetMember(memberId);

            return q_member.accountTypeId;
        }

        public string GetStauts(int memberId)
        {
            GetMember(memberId);

            return q_member.status;
        }

        public string GetNationNumber(int memberId)
        {
            GetMember(memberId);

            return q_member.nationNumber;
        }

        public string GetPhone(int memberId)
        {
            GetMember(memberId);

            return q_member.phoneNumber;
        }

        public string GetReviewStatus(int memberId)
        {
            GetMember(memberId);

            return q_member.reviewStatus;
        }

        public decimal? GetFeeDividedOwnPercent(int memberId)
        {
            GetMember(memberId);

            return q_member.feeDividedOwnPercent;
        }

        public decimal? GetFeeStackedOwnPercent(int memberId)
        {
            GetMember(memberId);

            return q_member.feeStackedOwnPercent;
        }

        public string GetFeeMode(int memberId)
        {
            GetMember(memberId);

            return q_member.feeMode;
        }

        public string GetIndustryId(int memberId)
        {
            GetMember(memberId);

            return q_member.industryId;
        }

        public JToken GetMemberAuth(int memberId)
        {
            GetMember(memberId);
            return JsonConvert.DeserializeObject<JToken>(q_member.auth);
        }

        public JToken GetMemberInfo(int memberId)
        {
            GetMember(memberId);

            return JsonConvert.DeserializeObject<JToken>(q_member.info);
        }

        /// <summary>
        /// 下壓
        /// </summary>
        /// <param name="parentId"></param>
        /// <param name="targetJson"></param>

        public int GetMemberId(string username)
        {
            string select_str = "select id from [bitject].[dbo].[member] with(nolock)";

            string where_str = " where username = @username";

            var m = conn.Query<member>(select_str + where_str, new { username = username }).FirstOrDefault();

            if (m == null) return 0;

            return m.id;
        }

        public int GetMemberIdByEmail(string email)
        {
            string select_str = "select id from [bitject].[dbo].[member] with(nolock)";
            string where_str = " where email = @email";

            var m = conn.Query<member>(select_str + where_str, new { email = email }).FirstOrDefault();

            if (m == null) return 0;

            return m.id;
        }

        public int GetMemberId(int agentId, string externalId)
        {
            string select_str = "select id from [bitject].[dbo].[member] with(nolock)";
            string where_str = " where parentId = @parentId and externalId = @externalId";
            var m = conn.Query<member>(select_str + where_str,
                new { parentId = agentId, externalId = externalId }).FirstOrDefault();
            if (m == null)
            {
                return 0;
            }
            return m.id;
        }

        public member GetMember(int memberId, bool getNew = false)
        {
            if (q_member == null || getNew || q_member.id != memberId)
            {
                var q = conn.Query<member>("select * from bitject.dbo.member with(nolock) where id=" + memberId).FirstOrDefault();
                if (q != null)
                {
                    q_member = q;

                    return q;
                }
            }

            return q_member;
        }
    }
}