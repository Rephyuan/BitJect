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

 Date: 25/05/2018 10:31:59
*/


-- ----------------------------
-- Table structure for account
-- ----------------------------
IF EXISTS (SELECT * FROM sys.all_objects WHERE object_id = OBJECT_ID(N'[dbo].[account]') AND type IN ('U'))
	DROP TABLE [dbo].[account]
GO

CREATE TABLE [dbo].[account] (
  [id] int  IDENTITY(1,1) NOT NULL,
  [memberId] int  NOT NULL,
  [memberLevelId] int  NOT NULL,
  [memberParentId] int  NOT NULL,
  [currencyCode] nvarchar(50) COLLATE SQL_Latin1_General_CP1_CI_AS  NOT NULL,
  [balance] decimal(28,12)  NOT NULL,
  [frozenBalance] decimal(28,12)  NOT NULL,
  [status] varchar(50) COLLATE SQL_Latin1_General_CP1_CI_AS  NOT NULL,
  [createDateTime] datetime  NOT NULL,
  [memo] nvarchar(50) COLLATE SQL_Latin1_General_CP1_CI_AS  NULL,
  [l1] int  NULL,
  [l2] int  NULL,
  [l3] int  NULL,
  [l4] int  NULL,
  [l5] int  NULL,
  [l6] int  NULL,
  [l7] int  NULL,
  [l8] int  NULL,
  [l9] int  NULL
)
GO

ALTER TABLE [dbo].[account] SET (LOCK_ESCALATION = TABLE)
GO


-- ----------------------------
-- Records of [account]
-- ----------------------------
SET IDENTITY_INSERT [dbo].[account] ON
GO

INSERT INTO [dbo].[account] ([id], [memberId], [memberLevelId], [memberParentId], [currencyCode], [balance], [frozenBalance], [status], [createDateTime], [memo], [l1], [l2], [l3], [l4], [l5], [l6], [l7], [l8], [l9]) VALUES (N'1', N'1', N'9', N'0', N'BJC', N'100000000000.000000000000', N'100000000000.000000000000', N'1', N'2018-05-11 09:40:23.000', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'1')
GO

INSERT INTO [dbo].[account] ([id], [memberId], [memberLevelId], [memberParentId], [currencyCode], [balance], [frozenBalance], [status], [createDateTime], [memo], [l1], [l2], [l3], [l4], [l5], [l6], [l7], [l8], [l9]) VALUES (N'2', N'8', N'1', N'7', N'BJC', N'2939.220000000000', N'.000000000000', N'1', N'2018-05-14 02:12:35.000', NULL, N'8', NULL, NULL, NULL, NULL, NULL, N'7', N'4', N'1')
GO

INSERT INTO [dbo].[account] ([id], [memberId], [memberLevelId], [memberParentId], [currencyCode], [balance], [frozenBalance], [status], [createDateTime], [memo], [l1], [l2], [l3], [l4], [l5], [l6], [l7], [l8], [l9]) VALUES (N'3', N'4', N'8', N'1', N'BJC', N'.000000000000', N'.000000000000', N'1', N'2018-05-14 01:43:21.000', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'4', N'1')
GO

INSERT INTO [dbo].[account] ([id], [memberId], [memberLevelId], [memberParentId], [currencyCode], [balance], [frozenBalance], [status], [createDateTime], [memo], [l1], [l2], [l3], [l4], [l5], [l6], [l7], [l8], [l9]) VALUES (N'4', N'7', N'7', N'4', N'BJC', N'496570.910000000000', N'492.110000000000', N'1', N'2018-05-14 01:55:21.000', NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'7', N'4', N'1')
GO

INSERT INTO [dbo].[account] ([id], [memberId], [memberLevelId], [memberParentId], [currencyCode], [balance], [frozenBalance], [status], [createDateTime], [memo], [l1], [l2], [l3], [l4], [l5], [l6], [l7], [l8], [l9]) VALUES (N'5', N'9', N'1', N'7', N'BJC', N'.000000000000', N'.000000000000', N'1', N'2018-05-14 02:14:55.000', NULL, N'9', NULL, NULL, NULL, NULL, NULL, N'7', N'4', N'1')
GO

INSERT INTO [dbo].[account] ([id], [memberId], [memberLevelId], [memberParentId], [currencyCode], [balance], [frozenBalance], [status], [createDateTime], [memo], [l1], [l2], [l3], [l4], [l5], [l6], [l7], [l8], [l9]) VALUES (N'6', N'10', N'8', N'1', N'BJC', N'.000000000000', N'.000000000000', N'1', N'2018-05-15 10:16:25.000', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'10', N'1')
GO

INSERT INTO [dbo].[account] ([id], [memberId], [memberLevelId], [memberParentId], [currencyCode], [balance], [frozenBalance], [status], [createDateTime], [memo], [l1], [l2], [l3], [l4], [l5], [l6], [l7], [l8], [l9]) VALUES (N'7', N'11', N'8', N'1', N'BJC', N'.000000000000', N'.000000000000', N'1', N'2018-05-15 10:19:27.000', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'11', N'1')
GO

INSERT INTO [dbo].[account] ([id], [memberId], [memberLevelId], [memberParentId], [currencyCode], [balance], [frozenBalance], [status], [createDateTime], [memo], [l1], [l2], [l3], [l4], [l5], [l6], [l7], [l8], [l9]) VALUES (N'8', N'12', N'7', N'4', N'BJC', N'.000000000000', N'.000000000000', N'1', N'2018-05-15 10:20:34.000', NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'12', N'4', N'1')
GO

INSERT INTO [dbo].[account] ([id], [memberId], [memberLevelId], [memberParentId], [currencyCode], [balance], [frozenBalance], [status], [createDateTime], [memo], [l1], [l2], [l3], [l4], [l5], [l6], [l7], [l8], [l9]) VALUES (N'9', N'13', N'8', N'1', N'BJC', N'.000000000000', N'.000000000000', N'1', N'2018-05-15 10:22:13.000', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'13', N'1')
GO

INSERT INTO [dbo].[account] ([id], [memberId], [memberLevelId], [memberParentId], [currencyCode], [balance], [frozenBalance], [status], [createDateTime], [memo], [l1], [l2], [l3], [l4], [l5], [l6], [l7], [l8], [l9]) VALUES (N'10', N'14', N'1', N'7', N'BJC', N'.000000000000', N'.000000000000', N'1', N'2018-05-15 02:35:12.000', NULL, N'14', NULL, NULL, NULL, NULL, NULL, N'7', N'4', N'1')
GO

INSERT INTO [dbo].[account] ([id], [memberId], [memberLevelId], [memberParentId], [currencyCode], [balance], [frozenBalance], [status], [createDateTime], [memo], [l1], [l2], [l3], [l4], [l5], [l6], [l7], [l8], [l9]) VALUES (N'11', N'15', N'8', N'1', N'BJC', N'.000000000000', N'.000000000000', N'1', N'2018-05-15 11:30:06.000', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'15', N'1')
GO

INSERT INTO [dbo].[account] ([id], [memberId], [memberLevelId], [memberParentId], [currencyCode], [balance], [frozenBalance], [status], [createDateTime], [memo], [l1], [l2], [l3], [l4], [l5], [l6], [l7], [l8], [l9]) VALUES (N'12', N'16', N'8', N'1', N'BJC', N'.000000000000', N'.000000000000', N'1', N'2018-05-15 11:32:37.000', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'16', N'1')
GO

INSERT INTO [dbo].[account] ([id], [memberId], [memberLevelId], [memberParentId], [currencyCode], [balance], [frozenBalance], [status], [createDateTime], [memo], [l1], [l2], [l3], [l4], [l5], [l6], [l7], [l8], [l9]) VALUES (N'13', N'17', N'8', N'1', N'BJC', N'.000000000000', N'.000000000000', N'1', N'2018-05-15 11:45:36.000', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'17', N'1')
GO

SET IDENTITY_INSERT [dbo].[account] OFF
GO


-- ----------------------------
-- Primary Key structure for table account
-- ----------------------------
ALTER TABLE [dbo].[account] ADD CONSTRAINT [PK__account__3213E83FC4A7D7BA] PRIMARY KEY CLUSTERED ([id])
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)  
ON [PRIMARY]
GO

