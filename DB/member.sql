/*
 Navicat Premium Data Transfer

 Source Server         : bitject
 Source Server Type    : SQL Server
 Source Server Version : 14001000
 Source Host           : 10.140.0.3:1433
 Source Catalog        : bitject
 Source Schema         : dbo

 Target Server Type    : SQL Server
 Target Server Version : 14001000
 File Encoding         : 65001

 Date: 25/05/2018 10:33:26
*/


-- ----------------------------
-- Table structure for member
-- ----------------------------
IF EXISTS (SELECT * FROM sys.all_objects WHERE object_id = OBJECT_ID(N'[dbo].[member]') AND type IN ('U'))
	DROP TABLE [dbo].[member]
GO

CREATE TABLE [dbo].[member] (
  [id] int  IDENTITY(1,1) NOT NULL,
  [username] varchar(50) COLLATE SQL_Latin1_General_CP1_CI_AS  NOT NULL,
  [password] varchar(100) COLLATE SQL_Latin1_General_CP1_CI_AS  NULL,
  [levelId] int  NOT NULL,
  [companyId] int  NOT NULL,
  [status] varchar(50) COLLATE SQL_Latin1_General_CP1_CI_AS  NOT NULL,
  [accountTypeId] int  NOT NULL,
  [parentId] int  NOT NULL,
  [isApiCreate] bit  NOT NULL,
  [createDateTime] datetime  NOT NULL,
  [externalId] varchar(50) COLLATE SQL_Latin1_General_CP1_CI_AS  NULL,
  [nickname] nvarchar(50) COLLATE SQL_Latin1_General_CP1_CI_AS  NULL,
  [nationNumber] varchar(50) COLLATE SQL_Latin1_General_CP1_CI_AS  NULL,
  [phoneNumber] varchar(50) COLLATE SQL_Latin1_General_CP1_CI_AS  NULL,
  [email] varchar(255) COLLATE SQL_Latin1_General_CP1_CI_AS  NULL,
  [childPid] int  NULL,
  [childCanViewId] varchar(max) COLLATE SQL_Latin1_General_CP1_CI_AS  NULL,
  [loginCountryCode] varchar(50) COLLATE SQL_Latin1_General_CP1_CI_AS  NULL,
  [loginDateTime] datetime  NULL,
  [loginCount] int  NULL,
  [loginFailCount] int  NULL,
  [loginIp] varchar(39) COLLATE SQL_Latin1_General_CP1_CI_AS  NULL,
  [personalId] varchar(15) COLLATE SQL_Latin1_General_CP1_CI_AS  NULL,
  [nationCode] varchar(10) COLLATE SQL_Latin1_General_CP1_CI_AS  NULL,
  [firstName] nvarchar(15) COLLATE SQL_Latin1_General_CP1_CI_AS  NULL,
  [lastName] nvarchar(15) COLLATE SQL_Latin1_General_CP1_CI_AS  NULL,
  [sex] varchar(1) COLLATE SQL_Latin1_General_CP1_CI_AS  NULL,
  [birthday] date  NULL,
  [creditCardInfo] varchar(max) COLLATE SQL_Latin1_General_CP1_CI_AS  NULL,
  [auth] varchar(max) COLLATE SQL_Latin1_General_CP1_CI_AS  NULL,
  [info] nvarchar(max) COLLATE SQL_Latin1_General_CP1_CI_AS  NULL,
  [memo] nvarchar(50) COLLATE SQL_Latin1_General_CP1_CI_AS  NULL,
  [lastModifyDateTime] datetime  NULL,
  [lastModifierId] int  NULL,
  [l1] int  NULL,
  [l2] int  NULL,
  [l3] int  NULL,
  [l4] int  NULL,
  [l5] int  NULL,
  [l6] int  NULL,
  [l7] int  NULL,
  [l8] int  NULL,
  [l9] int  NULL,
  [reviewStatus] varchar(5) COLLATE SQL_Latin1_General_CP1_CI_AS  NULL,
  [industryId] varchar(5) COLLATE SQL_Latin1_General_CP1_CI_AS  NULL,
  [feeMode] varchar(5) COLLATE SQL_Latin1_General_CP1_CI_AS  NULL,
  [feeDividedOwnPercent] decimal(8,4)  NULL,
  [feeStackedOwnPercent] decimal(8,4)  NULL,
  [score] int  NULL,
  [registerStatus] varchar(5) COLLATE SQL_Latin1_General_CP1_CI_AS  NULL
)
GO

ALTER TABLE [dbo].[member] SET (LOCK_ESCALATION = TABLE)
GO


-- ----------------------------
-- Records of [member]
-- ----------------------------
SET IDENTITY_INSERT [dbo].[member] ON
GO

INSERT INTO [dbo].[member] ([id], [username], [password], [levelId], [companyId], [status], [accountTypeId], [parentId], [isApiCreate], [createDateTime], [externalId], [nickname], [nationNumber], [phoneNumber], [email], [childPid], [childCanViewId], [loginCountryCode], [loginDateTime], [loginCount], [loginFailCount], [loginIp], [personalId], [nationCode], [firstName], [lastName], [sex], [birthday], [creditCardInfo], [auth], [info], [memo], [lastModifyDateTime], [lastModifierId], [l1], [l2], [l3], [l4], [l5], [l6], [l7], [l8], [l9], [reviewStatus], [industryId], [feeMode], [feeDividedOwnPercent], [feeStackedOwnPercent], [score], [registerStatus]) VALUES (N'1', N'sasasa', N'sasasasa', N'9', N'1', N'1', N'1', N'0', N'0', N'2018-05-11 09:16:29.000', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'2018-05-23 16:51:29.000', N'21', N'0', N'::1', NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'{"page":{"a1":1,a2:1,a3:1,a4:1,a5:1,a6:1,"a7":1,a8:1,a9:1,a10:1,a11:1,a12:1,a13:1,a14:1,a15:1,a16:1,a17:1,a18:1,a19:1,a20:1,a21:1,a22:1,a23:1,a24:1,a25:1,a26:1,a27:1,a28:1,a29:1,a30:1,a31:1}}', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'1', NULL, NULL, NULL, NULL, NULL, NULL, NULL)
GO

INSERT INTO [dbo].[member] ([id], [username], [password], [levelId], [companyId], [status], [accountTypeId], [parentId], [isApiCreate], [createDateTime], [externalId], [nickname], [nationNumber], [phoneNumber], [email], [childPid], [childCanViewId], [loginCountryCode], [loginDateTime], [loginCount], [loginFailCount], [loginIp], [personalId], [nationCode], [firstName], [lastName], [sex], [birthday], [creditCardInfo], [auth], [info], [memo], [lastModifyDateTime], [lastModifierId], [l1], [l2], [l3], [l4], [l5], [l6], [l7], [l8], [l9], [reviewStatus], [industryId], [feeMode], [feeDividedOwnPercent], [feeStackedOwnPercent], [score], [registerStatus]) VALUES (N'4', N'l8agent01', N'l8agent01', N'8', N'4', N'1', N'1', N'1', N'0', N'2018-05-14 01:43:21.000', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'2018-05-23 03:53:49.000', N'12', N'0', N'::1', NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'{"page":{"a1":"1","a2":"1","a3":"1","a4":"1","a5":"1","a6":"1","a7":"1","a8":"1","a9":"1","a10":"1","a11":"1","a12":"1","a13":"1"}}', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'4', N'1', NULL, NULL, N'2', N'.5000', N'.0000', NULL, NULL)
GO

INSERT INTO [dbo].[member] ([id], [username], [password], [levelId], [companyId], [status], [accountTypeId], [parentId], [isApiCreate], [createDateTime], [externalId], [nickname], [nationNumber], [phoneNumber], [email], [childPid], [childCanViewId], [loginCountryCode], [loginDateTime], [loginCount], [loginFailCount], [loginIp], [personalId], [nationCode], [firstName], [lastName], [sex], [birthday], [creditCardInfo], [auth], [info], [memo], [lastModifyDateTime], [lastModifierId], [l1], [l2], [l3], [l4], [l5], [l6], [l7], [l8], [l9], [reviewStatus], [industryId], [feeMode], [feeDividedOwnPercent], [feeStackedOwnPercent], [score], [registerStatus]) VALUES (N'7', N'l7agent01', N'l7agent01', N'7', N'7', N'1', N'1', N'4', N'0', N'2018-05-14 01:55:21.000', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'0', N'0', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'{"page":{"a1":"1","a2":"1","a3":"1","a4":"1","a5":"1","a6":"1","a11":"1","a12":"1","a13":"1"}}', N'{"1":1000,"2":{"TWD":1000,"CNY":1000,"USD":1000},"3":{"TWD":100,"CNY":20,"USD":3.5}}', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'7', N'4', N'1', NULL, NULL, N'2', N'.2000', N'.0000', NULL, NULL)
GO

INSERT INTO [dbo].[member] ([id], [username], [password], [levelId], [companyId], [status], [accountTypeId], [parentId], [isApiCreate], [createDateTime], [externalId], [nickname], [nationNumber], [phoneNumber], [email], [childPid], [childCanViewId], [loginCountryCode], [loginDateTime], [loginCount], [loginFailCount], [loginIp], [personalId], [nationCode], [firstName], [lastName], [sex], [birthday], [creditCardInfo], [auth], [info], [memo], [lastModifyDateTime], [lastModifierId], [l1], [l2], [l3], [l4], [l5], [l6], [l7], [l8], [l9], [reviewStatus], [industryId], [feeMode], [feeDividedOwnPercent], [feeStackedOwnPercent], [score], [registerStatus]) VALUES (N'8', N'bitto@yahoo.com.tw', NULL, N'1', N'7', N'1', N'1', N'7', N'1', N'2018-05-14 02:12:35.000', N'member004', N'feqd', N'886', N'0924781354', N'bitto@yahoo.com.tw', NULL, NULL, NULL, NULL, N'0', N'0', NULL, N'L159021500', N'TW', N'bi', N'to', N'1', N'1988-01-25', NULL, N'{}', NULL, NULL, NULL, NULL, N'8', NULL, NULL, NULL, NULL, NULL, N'7', N'4', N'1', NULL, NULL, N'2', NULL, NULL, NULL, N'2')
GO

INSERT INTO [dbo].[member] ([id], [username], [password], [levelId], [companyId], [status], [accountTypeId], [parentId], [isApiCreate], [createDateTime], [externalId], [nickname], [nationNumber], [phoneNumber], [email], [childPid], [childCanViewId], [loginCountryCode], [loginDateTime], [loginCount], [loginFailCount], [loginIp], [personalId], [nationCode], [firstName], [lastName], [sex], [birthday], [creditCardInfo], [auth], [info], [memo], [lastModifyDateTime], [lastModifierId], [l1], [l2], [l3], [l4], [l5], [l6], [l7], [l8], [l9], [reviewStatus], [industryId], [feeMode], [feeDividedOwnPercent], [feeStackedOwnPercent], [score], [registerStatus]) VALUES (N'9', N'cccchs@yahoo.com.tw', NULL, N'1', N'7', N'1', N'1', N'7', N'1', N'2018-05-14 02:14:55.000', N'member005', N'superman', N'886', N'0924654852', N'cccchs@yahoo.com.tw', NULL, NULL, NULL, NULL, N'0', N'0', NULL, N'A149766486', N'TW', N'changchang', N'wang', N'1', N'1984-11-25', NULL, N'{}', NULL, NULL, NULL, NULL, N'9', NULL, NULL, NULL, NULL, NULL, N'7', N'4', N'1', NULL, NULL, N'2', NULL, NULL, NULL, N'2')
GO

INSERT INTO [dbo].[member] ([id], [username], [password], [levelId], [companyId], [status], [accountTypeId], [parentId], [isApiCreate], [createDateTime], [externalId], [nickname], [nationNumber], [phoneNumber], [email], [childPid], [childCanViewId], [loginCountryCode], [loginDateTime], [loginCount], [loginFailCount], [loginIp], [personalId], [nationCode], [firstName], [lastName], [sex], [birthday], [creditCardInfo], [auth], [info], [memo], [lastModifyDateTime], [lastModifierId], [l1], [l2], [l3], [l4], [l5], [l6], [l7], [l8], [l9], [reviewStatus], [industryId], [feeMode], [feeDividedOwnPercent], [feeStackedOwnPercent], [score], [registerStatus]) VALUES (N'10', N'dsadasd1', N'asdasdsad', N'8', N'8', N'1', N'1', N'1', N'0', N'2018-05-15 10:16:25.000', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'0', N'0', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'{"page":{"a1":"1","a2":"1","a3":"1","a4":"1","a5":"1","a6":"1","a7":"1","a8":"1","a9":"1","a10":"1","a11":"1","a12":"1","a13":"1"}}', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'10', N'1', NULL, NULL, N'1', N'.0000', N'.1000', NULL, NULL)
GO

INSERT INTO [dbo].[member] ([id], [username], [password], [levelId], [companyId], [status], [accountTypeId], [parentId], [isApiCreate], [createDateTime], [externalId], [nickname], [nationNumber], [phoneNumber], [email], [childPid], [childCanViewId], [loginCountryCode], [loginDateTime], [loginCount], [loginFailCount], [loginIp], [personalId], [nationCode], [firstName], [lastName], [sex], [birthday], [creditCardInfo], [auth], [info], [memo], [lastModifyDateTime], [lastModifierId], [l1], [l2], [l3], [l4], [l5], [l6], [l7], [l8], [l9], [reviewStatus], [industryId], [feeMode], [feeDividedOwnPercent], [feeStackedOwnPercent], [score], [registerStatus]) VALUES (N'11', N'dasdasd1', N'aa1111', N'8', N'9', N'1', N'1', N'1', N'0', N'2018-05-15 10:19:27.000', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'0', N'0', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'{"page":{"a1":"1","a2":"1","a3":"1","a4":"1","a5":"1","a6":"1","a7":"1","a8":"1","a9":"1","a10":"1","a11":"1","a12":"1","a13":"1"}}', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'11', N'1', NULL, NULL, N'1', N'.0000', N'.1000', NULL, NULL)
GO

INSERT INTO [dbo].[member] ([id], [username], [password], [levelId], [companyId], [status], [accountTypeId], [parentId], [isApiCreate], [createDateTime], [externalId], [nickname], [nationNumber], [phoneNumber], [email], [childPid], [childCanViewId], [loginCountryCode], [loginDateTime], [loginCount], [loginFailCount], [loginIp], [personalId], [nationCode], [firstName], [lastName], [sex], [birthday], [creditCardInfo], [auth], [info], [memo], [lastModifyDateTime], [lastModifierId], [l1], [l2], [l3], [l4], [l5], [l6], [l7], [l8], [l9], [reviewStatus], [industryId], [feeMode], [feeDividedOwnPercent], [feeStackedOwnPercent], [score], [registerStatus]) VALUES (N'12', N'adasdad1', N'l7agent01', N'7', N'10', N'1', N'1', N'4', N'0', N'2018-05-15 10:20:34.000', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'0', N'0', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'{"page":{"a1":"1","a2":"1","a3":"1","a4":"1","a5":"1","a6":"1","a11":"1","a12":"1","a13":"1"}}', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'12', N'4', N'1', NULL, NULL, N'2', N'.5000', N'.0000', NULL, NULL)
GO

INSERT INTO [dbo].[member] ([id], [username], [password], [levelId], [companyId], [status], [accountTypeId], [parentId], [isApiCreate], [createDateTime], [externalId], [nickname], [nationNumber], [phoneNumber], [email], [childPid], [childCanViewId], [loginCountryCode], [loginDateTime], [loginCount], [loginFailCount], [loginIp], [personalId], [nationCode], [firstName], [lastName], [sex], [birthday], [creditCardInfo], [auth], [info], [memo], [lastModifyDateTime], [lastModifierId], [l1], [l2], [l3], [l4], [l5], [l6], [l7], [l8], [l9], [reviewStatus], [industryId], [feeMode], [feeDividedOwnPercent], [feeStackedOwnPercent], [score], [registerStatus]) VALUES (N'13', N'test1234', N'aa1111', N'8', N'11', N'1', N'1', N'1', N'0', N'2018-05-15 10:22:13.000', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'0', N'0', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'{"page":{"a1":"1","a2":"1","a3":"1","a4":"1","a5":"1","a6":"1","a7":"1","a8":"1","a9":"1","a10":"1","a11":"1","a12":"1","a13":"1"}}', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'13', N'1', NULL, NULL, N'1', N'.0000', N'.1000', NULL, NULL)
GO

INSERT INTO [dbo].[member] ([id], [username], [password], [levelId], [companyId], [status], [accountTypeId], [parentId], [isApiCreate], [createDateTime], [externalId], [nickname], [nationNumber], [phoneNumber], [email], [childPid], [childCanViewId], [loginCountryCode], [loginDateTime], [loginCount], [loginFailCount], [loginIp], [personalId], [nationCode], [firstName], [lastName], [sex], [birthday], [creditCardInfo], [auth], [info], [memo], [lastModifyDateTime], [lastModifierId], [l1], [l2], [l3], [l4], [l5], [l6], [l7], [l8], [l9], [reviewStatus], [industryId], [feeMode], [feeDividedOwnPercent], [feeStackedOwnPercent], [score], [registerStatus]) VALUES (N'14', N'ddddd@yahoo.com.tw', NULL, N'1', N'7', N'1', N'1', N'7', N'1', N'2018-05-15 02:35:12.000', N'member006', N'ddddd', N'886', N'0924398809', N'ddddd@yahoo.com.tw', NULL, NULL, NULL, NULL, N'0', N'0', NULL, N'A177398809', N'TW', N'ddddd', N'ddddd', N'1', N'1985-11-25', NULL, N'{}', NULL, NULL, NULL, NULL, N'14', NULL, NULL, NULL, NULL, NULL, N'7', N'4', N'1', NULL, NULL, N'2', NULL, NULL, NULL, N'2')
GO

INSERT INTO [dbo].[member] ([id], [username], [password], [levelId], [companyId], [status], [accountTypeId], [parentId], [isApiCreate], [createDateTime], [externalId], [nickname], [nationNumber], [phoneNumber], [email], [childPid], [childCanViewId], [loginCountryCode], [loginDateTime], [loginCount], [loginFailCount], [loginIp], [personalId], [nationCode], [firstName], [lastName], [sex], [birthday], [creditCardInfo], [auth], [info], [memo], [lastModifyDateTime], [lastModifierId], [l1], [l2], [l3], [l4], [l5], [l6], [l7], [l8], [l9], [reviewStatus], [industryId], [feeMode], [feeDividedOwnPercent], [feeStackedOwnPercent], [score], [registerStatus]) VALUES (N'15', N'dasdsad1', N'asdasd', N'8', N'12', N'1', N'1', N'1', N'0', N'2018-05-15 11:30:06.000', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'0', N'0', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'{"page":{"a1":"1","a2":"1","a3":"1","a4":"1","a5":"1","a6":"1","a7":"1","a8":"1","a9":"1","a10":"1","a11":"1","a12":"1","a13":"1"}}', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'15', N'1', NULL, NULL, N'1', N'.0000', N'.1000', NULL, NULL)
GO

INSERT INTO [dbo].[member] ([id], [username], [password], [levelId], [companyId], [status], [accountTypeId], [parentId], [isApiCreate], [createDateTime], [externalId], [nickname], [nationNumber], [phoneNumber], [email], [childPid], [childCanViewId], [loginCountryCode], [loginDateTime], [loginCount], [loginFailCount], [loginIp], [personalId], [nationCode], [firstName], [lastName], [sex], [birthday], [creditCardInfo], [auth], [info], [memo], [lastModifyDateTime], [lastModifierId], [l1], [l2], [l3], [l4], [l5], [l6], [l7], [l8], [l9], [reviewStatus], [industryId], [feeMode], [feeDividedOwnPercent], [feeStackedOwnPercent], [score], [registerStatus]) VALUES (N'16', N'aa111', N'aa1111', N'8', N'13', N'1', N'1', N'1', N'0', N'2018-05-15 11:32:37.000', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'0', N'0', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'{"page":{"a1":"1","a2":"1","a3":"1","a4":"1","a5":"1","a6":"1","a7":"1","a8":"1","a9":"1","a10":"1","a11":"1","a12":"1","a13":"1"}}', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'16', N'1', NULL, NULL, N'1', N'.0000', N'.1000', NULL, NULL)
GO

INSERT INTO [dbo].[member] ([id], [username], [password], [levelId], [companyId], [status], [accountTypeId], [parentId], [isApiCreate], [createDateTime], [externalId], [nickname], [nationNumber], [phoneNumber], [email], [childPid], [childCanViewId], [loginCountryCode], [loginDateTime], [loginCount], [loginFailCount], [loginIp], [personalId], [nationCode], [firstName], [lastName], [sex], [birthday], [creditCardInfo], [auth], [info], [memo], [lastModifyDateTime], [lastModifierId], [l1], [l2], [l3], [l4], [l5], [l6], [l7], [l8], [l9], [reviewStatus], [industryId], [feeMode], [feeDividedOwnPercent], [feeStackedOwnPercent], [score], [registerStatus]) VALUES (N'17', N'asdasd1', N'aa1111', N'8', N'14', N'1', N'1', N'1', N'0', N'2018-05-15 11:45:36.000', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'0', N'0', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'{"page":{"a1":"1","a2":"1","a3":"1","a4":"1","a5":"1","a6":"1","a7":"1","a8":"1","a9":"1","a10":"1","a11":"1","a12":"1","a13":"1"}}', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'17', N'1', NULL, NULL, N'1', N'.0000', N'.1000', NULL, NULL)
GO

SET IDENTITY_INSERT [dbo].[member] OFF
GO


-- ----------------------------
-- Primary Key structure for table member
-- ----------------------------
ALTER TABLE [dbo].[member] ADD CONSTRAINT [PK__member__3213E83F90964E78] PRIMARY KEY CLUSTERED ([id])
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)  
ON [PRIMARY]
GO

