﻿#pragma warning disable 1591
//------------------------------------------------------------------------------
// <auto-generated>
//     這段程式碼是由工具產生的。
//     執行階段版本:4.0.30319.42000
//
//     對這個檔案所做的變更可能會造成錯誤的行為，而且如果重新產生程式碼，
//     變更將會遺失。
// </auto-generated>
//------------------------------------------------------------------------------

namespace MemberRegister
{
	using System.Data.Linq;
	using System.Data.Linq.Mapping;
	using System.Data;
	using System.Collections.Generic;
	using System.Reflection;
	using System.Linq;
	using System.Linq.Expressions;
	using System.ComponentModel;
	using System;
	
	
	[global::System.Data.Linq.Mapping.DatabaseAttribute(Name="bitject")]
	public partial class DataClasses1DataContext : System.Data.Linq.DataContext
	{
		
		private static System.Data.Linq.Mapping.MappingSource mappingSource = new AttributeMappingSource();
		
    #region 擴充性方法定義
    partial void OnCreated();
    partial void Insertmember(member instance);
    partial void Updatemember(member instance);
    partial void Deletemember(member instance);
    #endregion
		
		public DataClasses1DataContext() : 
				base(global::MemberRegister.Properties.Settings.Default.bitjectConnectionString, mappingSource)
		{
			OnCreated();
		}
		
		public DataClasses1DataContext(string connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public DataClasses1DataContext(System.Data.IDbConnection connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public DataClasses1DataContext(string connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public DataClasses1DataContext(System.Data.IDbConnection connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public System.Data.Linq.Table<member> member
		{
			get
			{
				return this.GetTable<member>();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.member")]
	public partial class member : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _id;
		
		private string _username;
		
		private string _password;
		
		private int _levelId;
		
		private int _companyId;
		
		private string _status;
		
		private int _accountTypeId;
		
		private int _parentId;
		
		private bool _isApiCreate;
		
		private System.DateTime _createDateTime;
		
		private string _externalId;
		
		private string _nickname;
		
		private string _nationNumber;
		
		private string _phoneNumber;
		
		private string _email;
		
		private System.Nullable<int> _childPid;
		
		private string _childCanViewId;
		
		private string _loginCountryCode;
		
		private System.Nullable<System.DateTime> _loginDateTime;
		
		private System.Nullable<int> _loginCount;
		
		private System.Nullable<int> _loginFailCount;
		
		private string _loginIp;
		
		private string _personalId;
		
		private string _nationCode;
		
		private string _firstName;
		
		private string _lastName;
		
		private string _sex;
		
		private System.Nullable<System.DateTime> _birthday;
		
		private string _creditCardInfo;
		
		private string _auth;
		
		private string _info;
		
		private string _memo;
		
		private System.Nullable<System.DateTime> _lastModifyDateTime;
		
		private System.Nullable<int> _lastModifierId;
		
		private System.Nullable<int> _l1;
		
		private System.Nullable<int> _l2;
		
		private System.Nullable<int> _l3;
		
		private System.Nullable<int> _l4;
		
		private System.Nullable<int> _l5;
		
		private System.Nullable<int> _l6;
		
		private System.Nullable<int> _l7;
		
		private System.Nullable<int> _l8;
		
		private System.Nullable<int> _l9;
		
		private string _reviewStatus;
		
		private string _industryId;
		
		private string _feeMode;
		
		private System.Nullable<decimal> _feeDividedOwnPercent;
		
		private System.Nullable<decimal> _feeStackedOwnPercent;
		
		private System.Nullable<int> _score;
		
		private string _registerStatus;
		
    #region 擴充性方法定義
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnidChanging(int value);
    partial void OnidChanged();
    partial void OnusernameChanging(string value);
    partial void OnusernameChanged();
    partial void OnpasswordChanging(string value);
    partial void OnpasswordChanged();
    partial void OnlevelIdChanging(int value);
    partial void OnlevelIdChanged();
    partial void OncompanyIdChanging(int value);
    partial void OncompanyIdChanged();
    partial void OnstatusChanging(string value);
    partial void OnstatusChanged();
    partial void OnaccountTypeIdChanging(int value);
    partial void OnaccountTypeIdChanged();
    partial void OnparentIdChanging(int value);
    partial void OnparentIdChanged();
    partial void OnisApiCreateChanging(bool value);
    partial void OnisApiCreateChanged();
    partial void OncreateDateTimeChanging(System.DateTime value);
    partial void OncreateDateTimeChanged();
    partial void OnexternalIdChanging(string value);
    partial void OnexternalIdChanged();
    partial void OnnicknameChanging(string value);
    partial void OnnicknameChanged();
    partial void OnnationNumberChanging(string value);
    partial void OnnationNumberChanged();
    partial void OnphoneNumberChanging(string value);
    partial void OnphoneNumberChanged();
    partial void OnemailChanging(string value);
    partial void OnemailChanged();
    partial void OnchildPidChanging(System.Nullable<int> value);
    partial void OnchildPidChanged();
    partial void OnchildCanViewIdChanging(string value);
    partial void OnchildCanViewIdChanged();
    partial void OnloginCountryCodeChanging(string value);
    partial void OnloginCountryCodeChanged();
    partial void OnloginDateTimeChanging(System.Nullable<System.DateTime> value);
    partial void OnloginDateTimeChanged();
    partial void OnloginCountChanging(System.Nullable<int> value);
    partial void OnloginCountChanged();
    partial void OnloginFailCountChanging(System.Nullable<int> value);
    partial void OnloginFailCountChanged();
    partial void OnloginIpChanging(string value);
    partial void OnloginIpChanged();
    partial void OnpersonalIdChanging(string value);
    partial void OnpersonalIdChanged();
    partial void OnnationCodeChanging(string value);
    partial void OnnationCodeChanged();
    partial void OnfirstNameChanging(string value);
    partial void OnfirstNameChanged();
    partial void OnlastNameChanging(string value);
    partial void OnlastNameChanged();
    partial void OnsexChanging(string value);
    partial void OnsexChanged();
    partial void OnbirthdayChanging(System.Nullable<System.DateTime> value);
    partial void OnbirthdayChanged();
    partial void OncreditCardInfoChanging(string value);
    partial void OncreditCardInfoChanged();
    partial void OnauthChanging(string value);
    partial void OnauthChanged();
    partial void OninfoChanging(string value);
    partial void OninfoChanged();
    partial void OnmemoChanging(string value);
    partial void OnmemoChanged();
    partial void OnlastModifyDateTimeChanging(System.Nullable<System.DateTime> value);
    partial void OnlastModifyDateTimeChanged();
    partial void OnlastModifierIdChanging(System.Nullable<int> value);
    partial void OnlastModifierIdChanged();
    partial void Onl1Changing(System.Nullable<int> value);
    partial void Onl1Changed();
    partial void Onl2Changing(System.Nullable<int> value);
    partial void Onl2Changed();
    partial void Onl3Changing(System.Nullable<int> value);
    partial void Onl3Changed();
    partial void Onl4Changing(System.Nullable<int> value);
    partial void Onl4Changed();
    partial void Onl5Changing(System.Nullable<int> value);
    partial void Onl5Changed();
    partial void Onl6Changing(System.Nullable<int> value);
    partial void Onl6Changed();
    partial void Onl7Changing(System.Nullable<int> value);
    partial void Onl7Changed();
    partial void Onl8Changing(System.Nullable<int> value);
    partial void Onl8Changed();
    partial void Onl9Changing(System.Nullable<int> value);
    partial void Onl9Changed();
    partial void OnreviewStatusChanging(string value);
    partial void OnreviewStatusChanged();
    partial void OnindustryIdChanging(string value);
    partial void OnindustryIdChanged();
    partial void OnfeeModeChanging(string value);
    partial void OnfeeModeChanged();
    partial void OnfeeDividedOwnPercentChanging(System.Nullable<decimal> value);
    partial void OnfeeDividedOwnPercentChanged();
    partial void OnfeeStackedOwnPercentChanging(System.Nullable<decimal> value);
    partial void OnfeeStackedOwnPercentChanged();
    partial void OnscoreChanging(System.Nullable<int> value);
    partial void OnscoreChanged();
    partial void OnregisterStatusChanging(string value);
    partial void OnregisterStatusChanged();
    #endregion
		
		public member()
		{
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_id", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public int id
		{
			get
			{
				return this._id;
			}
			set
			{
				if ((this._id != value))
				{
					this.OnidChanging(value);
					this.SendPropertyChanging();
					this._id = value;
					this.SendPropertyChanged("id");
					this.OnidChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_username", DbType="VarChar(50) NOT NULL", CanBeNull=false)]
		public string username
		{
			get
			{
				return this._username;
			}
			set
			{
				if ((this._username != value))
				{
					this.OnusernameChanging(value);
					this.SendPropertyChanging();
					this._username = value;
					this.SendPropertyChanged("username");
					this.OnusernameChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_password", DbType="VarChar(100)")]
		public string password
		{
			get
			{
				return this._password;
			}
			set
			{
				if ((this._password != value))
				{
					this.OnpasswordChanging(value);
					this.SendPropertyChanging();
					this._password = value;
					this.SendPropertyChanged("password");
					this.OnpasswordChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_levelId", DbType="Int NOT NULL")]
		public int levelId
		{
			get
			{
				return this._levelId;
			}
			set
			{
				if ((this._levelId != value))
				{
					this.OnlevelIdChanging(value);
					this.SendPropertyChanging();
					this._levelId = value;
					this.SendPropertyChanged("levelId");
					this.OnlevelIdChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_companyId", DbType="Int NOT NULL")]
		public int companyId
		{
			get
			{
				return this._companyId;
			}
			set
			{
				if ((this._companyId != value))
				{
					this.OncompanyIdChanging(value);
					this.SendPropertyChanging();
					this._companyId = value;
					this.SendPropertyChanged("companyId");
					this.OncompanyIdChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_status", DbType="VarChar(50) NOT NULL", CanBeNull=false)]
		public string status
		{
			get
			{
				return this._status;
			}
			set
			{
				if ((this._status != value))
				{
					this.OnstatusChanging(value);
					this.SendPropertyChanging();
					this._status = value;
					this.SendPropertyChanged("status");
					this.OnstatusChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_accountTypeId", DbType="Int NOT NULL")]
		public int accountTypeId
		{
			get
			{
				return this._accountTypeId;
			}
			set
			{
				if ((this._accountTypeId != value))
				{
					this.OnaccountTypeIdChanging(value);
					this.SendPropertyChanging();
					this._accountTypeId = value;
					this.SendPropertyChanged("accountTypeId");
					this.OnaccountTypeIdChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_parentId", DbType="Int NOT NULL")]
		public int parentId
		{
			get
			{
				return this._parentId;
			}
			set
			{
				if ((this._parentId != value))
				{
					this.OnparentIdChanging(value);
					this.SendPropertyChanging();
					this._parentId = value;
					this.SendPropertyChanged("parentId");
					this.OnparentIdChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_isApiCreate", DbType="Bit NOT NULL")]
		public bool isApiCreate
		{
			get
			{
				return this._isApiCreate;
			}
			set
			{
				if ((this._isApiCreate != value))
				{
					this.OnisApiCreateChanging(value);
					this.SendPropertyChanging();
					this._isApiCreate = value;
					this.SendPropertyChanged("isApiCreate");
					this.OnisApiCreateChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_createDateTime", DbType="DateTime NOT NULL")]
		public System.DateTime createDateTime
		{
			get
			{
				return this._createDateTime;
			}
			set
			{
				if ((this._createDateTime != value))
				{
					this.OncreateDateTimeChanging(value);
					this.SendPropertyChanging();
					this._createDateTime = value;
					this.SendPropertyChanged("createDateTime");
					this.OncreateDateTimeChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_externalId", DbType="VarChar(50)")]
		public string externalId
		{
			get
			{
				return this._externalId;
			}
			set
			{
				if ((this._externalId != value))
				{
					this.OnexternalIdChanging(value);
					this.SendPropertyChanging();
					this._externalId = value;
					this.SendPropertyChanged("externalId");
					this.OnexternalIdChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_nickname", DbType="NVarChar(50)")]
		public string nickname
		{
			get
			{
				return this._nickname;
			}
			set
			{
				if ((this._nickname != value))
				{
					this.OnnicknameChanging(value);
					this.SendPropertyChanging();
					this._nickname = value;
					this.SendPropertyChanged("nickname");
					this.OnnicknameChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_nationNumber", DbType="VarChar(50)")]
		public string nationNumber
		{
			get
			{
				return this._nationNumber;
			}
			set
			{
				if ((this._nationNumber != value))
				{
					this.OnnationNumberChanging(value);
					this.SendPropertyChanging();
					this._nationNumber = value;
					this.SendPropertyChanged("nationNumber");
					this.OnnationNumberChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_phoneNumber", DbType="VarChar(50)")]
		public string phoneNumber
		{
			get
			{
				return this._phoneNumber;
			}
			set
			{
				if ((this._phoneNumber != value))
				{
					this.OnphoneNumberChanging(value);
					this.SendPropertyChanging();
					this._phoneNumber = value;
					this.SendPropertyChanged("phoneNumber");
					this.OnphoneNumberChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_email", DbType="VarChar(255)")]
		public string email
		{
			get
			{
				return this._email;
			}
			set
			{
				if ((this._email != value))
				{
					this.OnemailChanging(value);
					this.SendPropertyChanging();
					this._email = value;
					this.SendPropertyChanged("email");
					this.OnemailChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_childPid", DbType="Int")]
		public System.Nullable<int> childPid
		{
			get
			{
				return this._childPid;
			}
			set
			{
				if ((this._childPid != value))
				{
					this.OnchildPidChanging(value);
					this.SendPropertyChanging();
					this._childPid = value;
					this.SendPropertyChanged("childPid");
					this.OnchildPidChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_childCanViewId", DbType="VarChar(MAX)")]
		public string childCanViewId
		{
			get
			{
				return this._childCanViewId;
			}
			set
			{
				if ((this._childCanViewId != value))
				{
					this.OnchildCanViewIdChanging(value);
					this.SendPropertyChanging();
					this._childCanViewId = value;
					this.SendPropertyChanged("childCanViewId");
					this.OnchildCanViewIdChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_loginCountryCode", DbType="VarChar(50)")]
		public string loginCountryCode
		{
			get
			{
				return this._loginCountryCode;
			}
			set
			{
				if ((this._loginCountryCode != value))
				{
					this.OnloginCountryCodeChanging(value);
					this.SendPropertyChanging();
					this._loginCountryCode = value;
					this.SendPropertyChanged("loginCountryCode");
					this.OnloginCountryCodeChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_loginDateTime", DbType="DateTime")]
		public System.Nullable<System.DateTime> loginDateTime
		{
			get
			{
				return this._loginDateTime;
			}
			set
			{
				if ((this._loginDateTime != value))
				{
					this.OnloginDateTimeChanging(value);
					this.SendPropertyChanging();
					this._loginDateTime = value;
					this.SendPropertyChanged("loginDateTime");
					this.OnloginDateTimeChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_loginCount", DbType="Int")]
		public System.Nullable<int> loginCount
		{
			get
			{
				return this._loginCount;
			}
			set
			{
				if ((this._loginCount != value))
				{
					this.OnloginCountChanging(value);
					this.SendPropertyChanging();
					this._loginCount = value;
					this.SendPropertyChanged("loginCount");
					this.OnloginCountChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_loginFailCount", DbType="Int")]
		public System.Nullable<int> loginFailCount
		{
			get
			{
				return this._loginFailCount;
			}
			set
			{
				if ((this._loginFailCount != value))
				{
					this.OnloginFailCountChanging(value);
					this.SendPropertyChanging();
					this._loginFailCount = value;
					this.SendPropertyChanged("loginFailCount");
					this.OnloginFailCountChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_loginIp", DbType="VarChar(39)")]
		public string loginIp
		{
			get
			{
				return this._loginIp;
			}
			set
			{
				if ((this._loginIp != value))
				{
					this.OnloginIpChanging(value);
					this.SendPropertyChanging();
					this._loginIp = value;
					this.SendPropertyChanged("loginIp");
					this.OnloginIpChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_personalId", DbType="VarChar(15)")]
		public string personalId
		{
			get
			{
				return this._personalId;
			}
			set
			{
				if ((this._personalId != value))
				{
					this.OnpersonalIdChanging(value);
					this.SendPropertyChanging();
					this._personalId = value;
					this.SendPropertyChanged("personalId");
					this.OnpersonalIdChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_nationCode", DbType="VarChar(10)")]
		public string nationCode
		{
			get
			{
				return this._nationCode;
			}
			set
			{
				if ((this._nationCode != value))
				{
					this.OnnationCodeChanging(value);
					this.SendPropertyChanging();
					this._nationCode = value;
					this.SendPropertyChanged("nationCode");
					this.OnnationCodeChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_firstName", DbType="NVarChar(15)")]
		public string firstName
		{
			get
			{
				return this._firstName;
			}
			set
			{
				if ((this._firstName != value))
				{
					this.OnfirstNameChanging(value);
					this.SendPropertyChanging();
					this._firstName = value;
					this.SendPropertyChanged("firstName");
					this.OnfirstNameChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_lastName", DbType="NVarChar(15)")]
		public string lastName
		{
			get
			{
				return this._lastName;
			}
			set
			{
				if ((this._lastName != value))
				{
					this.OnlastNameChanging(value);
					this.SendPropertyChanging();
					this._lastName = value;
					this.SendPropertyChanged("lastName");
					this.OnlastNameChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_sex", DbType="VarChar(1)")]
		public string sex
		{
			get
			{
				return this._sex;
			}
			set
			{
				if ((this._sex != value))
				{
					this.OnsexChanging(value);
					this.SendPropertyChanging();
					this._sex = value;
					this.SendPropertyChanged("sex");
					this.OnsexChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_birthday", DbType="Date")]
		public System.Nullable<System.DateTime> birthday
		{
			get
			{
				return this._birthday;
			}
			set
			{
				if ((this._birthday != value))
				{
					this.OnbirthdayChanging(value);
					this.SendPropertyChanging();
					this._birthday = value;
					this.SendPropertyChanged("birthday");
					this.OnbirthdayChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_creditCardInfo", DbType="VarChar(MAX)")]
		public string creditCardInfo
		{
			get
			{
				return this._creditCardInfo;
			}
			set
			{
				if ((this._creditCardInfo != value))
				{
					this.OncreditCardInfoChanging(value);
					this.SendPropertyChanging();
					this._creditCardInfo = value;
					this.SendPropertyChanged("creditCardInfo");
					this.OncreditCardInfoChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_auth", DbType="VarChar(MAX)")]
		public string auth
		{
			get
			{
				return this._auth;
			}
			set
			{
				if ((this._auth != value))
				{
					this.OnauthChanging(value);
					this.SendPropertyChanging();
					this._auth = value;
					this.SendPropertyChanged("auth");
					this.OnauthChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_info", DbType="NVarChar(MAX)")]
		public string info
		{
			get
			{
				return this._info;
			}
			set
			{
				if ((this._info != value))
				{
					this.OninfoChanging(value);
					this.SendPropertyChanging();
					this._info = value;
					this.SendPropertyChanged("info");
					this.OninfoChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_memo", DbType="NVarChar(50)")]
		public string memo
		{
			get
			{
				return this._memo;
			}
			set
			{
				if ((this._memo != value))
				{
					this.OnmemoChanging(value);
					this.SendPropertyChanging();
					this._memo = value;
					this.SendPropertyChanged("memo");
					this.OnmemoChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_lastModifyDateTime", DbType="DateTime")]
		public System.Nullable<System.DateTime> lastModifyDateTime
		{
			get
			{
				return this._lastModifyDateTime;
			}
			set
			{
				if ((this._lastModifyDateTime != value))
				{
					this.OnlastModifyDateTimeChanging(value);
					this.SendPropertyChanging();
					this._lastModifyDateTime = value;
					this.SendPropertyChanged("lastModifyDateTime");
					this.OnlastModifyDateTimeChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_lastModifierId", DbType="Int")]
		public System.Nullable<int> lastModifierId
		{
			get
			{
				return this._lastModifierId;
			}
			set
			{
				if ((this._lastModifierId != value))
				{
					this.OnlastModifierIdChanging(value);
					this.SendPropertyChanging();
					this._lastModifierId = value;
					this.SendPropertyChanged("lastModifierId");
					this.OnlastModifierIdChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_l1", DbType="Int")]
		public System.Nullable<int> l1
		{
			get
			{
				return this._l1;
			}
			set
			{
				if ((this._l1 != value))
				{
					this.Onl1Changing(value);
					this.SendPropertyChanging();
					this._l1 = value;
					this.SendPropertyChanged("l1");
					this.Onl1Changed();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_l2", DbType="Int")]
		public System.Nullable<int> l2
		{
			get
			{
				return this._l2;
			}
			set
			{
				if ((this._l2 != value))
				{
					this.Onl2Changing(value);
					this.SendPropertyChanging();
					this._l2 = value;
					this.SendPropertyChanged("l2");
					this.Onl2Changed();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_l3", DbType="Int")]
		public System.Nullable<int> l3
		{
			get
			{
				return this._l3;
			}
			set
			{
				if ((this._l3 != value))
				{
					this.Onl3Changing(value);
					this.SendPropertyChanging();
					this._l3 = value;
					this.SendPropertyChanged("l3");
					this.Onl3Changed();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_l4", DbType="Int")]
		public System.Nullable<int> l4
		{
			get
			{
				return this._l4;
			}
			set
			{
				if ((this._l4 != value))
				{
					this.Onl4Changing(value);
					this.SendPropertyChanging();
					this._l4 = value;
					this.SendPropertyChanged("l4");
					this.Onl4Changed();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_l5", DbType="Int")]
		public System.Nullable<int> l5
		{
			get
			{
				return this._l5;
			}
			set
			{
				if ((this._l5 != value))
				{
					this.Onl5Changing(value);
					this.SendPropertyChanging();
					this._l5 = value;
					this.SendPropertyChanged("l5");
					this.Onl5Changed();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_l6", DbType="Int")]
		public System.Nullable<int> l6
		{
			get
			{
				return this._l6;
			}
			set
			{
				if ((this._l6 != value))
				{
					this.Onl6Changing(value);
					this.SendPropertyChanging();
					this._l6 = value;
					this.SendPropertyChanged("l6");
					this.Onl6Changed();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_l7", DbType="Int")]
		public System.Nullable<int> l7
		{
			get
			{
				return this._l7;
			}
			set
			{
				if ((this._l7 != value))
				{
					this.Onl7Changing(value);
					this.SendPropertyChanging();
					this._l7 = value;
					this.SendPropertyChanged("l7");
					this.Onl7Changed();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_l8", DbType="Int")]
		public System.Nullable<int> l8
		{
			get
			{
				return this._l8;
			}
			set
			{
				if ((this._l8 != value))
				{
					this.Onl8Changing(value);
					this.SendPropertyChanging();
					this._l8 = value;
					this.SendPropertyChanged("l8");
					this.Onl8Changed();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_l9", DbType="Int")]
		public System.Nullable<int> l9
		{
			get
			{
				return this._l9;
			}
			set
			{
				if ((this._l9 != value))
				{
					this.Onl9Changing(value);
					this.SendPropertyChanging();
					this._l9 = value;
					this.SendPropertyChanged("l9");
					this.Onl9Changed();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_reviewStatus", DbType="VarChar(5)")]
		public string reviewStatus
		{
			get
			{
				return this._reviewStatus;
			}
			set
			{
				if ((this._reviewStatus != value))
				{
					this.OnreviewStatusChanging(value);
					this.SendPropertyChanging();
					this._reviewStatus = value;
					this.SendPropertyChanged("reviewStatus");
					this.OnreviewStatusChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_industryId", DbType="VarChar(5)")]
		public string industryId
		{
			get
			{
				return this._industryId;
			}
			set
			{
				if ((this._industryId != value))
				{
					this.OnindustryIdChanging(value);
					this.SendPropertyChanging();
					this._industryId = value;
					this.SendPropertyChanged("industryId");
					this.OnindustryIdChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_feeMode", DbType="VarChar(5)")]
		public string feeMode
		{
			get
			{
				return this._feeMode;
			}
			set
			{
				if ((this._feeMode != value))
				{
					this.OnfeeModeChanging(value);
					this.SendPropertyChanging();
					this._feeMode = value;
					this.SendPropertyChanged("feeMode");
					this.OnfeeModeChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_feeDividedOwnPercent", DbType="Decimal(8,4)")]
		public System.Nullable<decimal> feeDividedOwnPercent
		{
			get
			{
				return this._feeDividedOwnPercent;
			}
			set
			{
				if ((this._feeDividedOwnPercent != value))
				{
					this.OnfeeDividedOwnPercentChanging(value);
					this.SendPropertyChanging();
					this._feeDividedOwnPercent = value;
					this.SendPropertyChanged("feeDividedOwnPercent");
					this.OnfeeDividedOwnPercentChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_feeStackedOwnPercent", DbType="Decimal(8,4)")]
		public System.Nullable<decimal> feeStackedOwnPercent
		{
			get
			{
				return this._feeStackedOwnPercent;
			}
			set
			{
				if ((this._feeStackedOwnPercent != value))
				{
					this.OnfeeStackedOwnPercentChanging(value);
					this.SendPropertyChanging();
					this._feeStackedOwnPercent = value;
					this.SendPropertyChanged("feeStackedOwnPercent");
					this.OnfeeStackedOwnPercentChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_score", DbType="Int")]
		public System.Nullable<int> score
		{
			get
			{
				return this._score;
			}
			set
			{
				if ((this._score != value))
				{
					this.OnscoreChanging(value);
					this.SendPropertyChanging();
					this._score = value;
					this.SendPropertyChanged("score");
					this.OnscoreChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_registerStatus", DbType="VarChar(5)")]
		public string registerStatus
		{
			get
			{
				return this._registerStatus;
			}
			set
			{
				if ((this._registerStatus != value))
				{
					this.OnregisterStatusChanging(value);
					this.SendPropertyChanging();
					this._registerStatus = value;
					this.SendPropertyChanged("registerStatus");
					this.OnregisterStatusChanged();
				}
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
	}
}
#pragma warning restore 1591