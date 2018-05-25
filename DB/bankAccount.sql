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

 Date: 25/05/2018 10:32:56
*/


-- ----------------------------
-- Table structure for bankAccount
-- ----------------------------
IF EXISTS (SELECT * FROM sys.all_objects WHERE object_id = OBJECT_ID(N'[dbo].[bankAccount]') AND type IN ('U'))
	DROP TABLE [dbo].[bankAccount]
GO

CREATE TABLE [dbo].[bankAccount] (
  [id] int  IDENTITY(1,1) NOT NULL,
  [memberId] int  NOT NULL,
  [parentId] int  NOT NULL,
  [bankId] varchar(10) COLLATE SQL_Latin1_General_CP1_CI_AS  NULL,
  [bankBranchName] nvarchar(30) COLLATE SQL_Latin1_General_CP1_CI_AS  NULL,
  [chinaMainRegionId] varchar(30) COLLATE SQL_Latin1_General_CP1_CI_AS  NULL,
  [chinaSubRegionId] varchar(30) COLLATE SQL_Latin1_General_CP1_CI_AS  NULL,
  [bankAccountNumber] varchar(30) COLLATE SQL_Latin1_General_CP1_CI_AS  NULL,
  [currencyCode] varchar(10) COLLATE SQL_Latin1_General_CP1_CI_AS  NOT NULL,
  [amount] decimal(28,12)  NOT NULL,
  [status] varchar(50) COLLATE SQL_Latin1_General_CP1_CI_AS  NOT NULL,
  [isChecked] bit  NOT NULL,
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
  [l9] int  NULL,
  [lastModifyDateTime] datetime  NULL,
  [lastModifierId] int  NULL,
  [registerStatus] varchar(5) COLLATE SQL_Latin1_General_CP1_CI_AS  NOT NULL
)
GO

ALTER TABLE [dbo].[bankAccount] SET (LOCK_ESCALATION = TABLE)
GO


-- ----------------------------
-- Records of [bankAccount]
-- ----------------------------
SET IDENTITY_INSERT [dbo].[bankAccount] ON
GO

INSERT INTO [dbo].[bankAccount] ([id], [memberId], [parentId], [bankId], [bankBranchName], [chinaMainRegionId], [chinaSubRegionId], [bankAccountNumber], [currencyCode], [amount], [status], [isChecked], [createDateTime], [memo], [l1], [l2], [l3], [l4], [l5], [l6], [l7], [l8], [l9], [lastModifyDateTime], [lastModifierId], [registerStatus]) VALUES (N'1', N'8', N'7', N'005', N'長春分行', NULL, NULL, N'4562358123456', N'TWD', N'.000000000000', N'1', N'0', N'2018-05-23 02:48:08.000', N'', N'8', NULL, NULL, NULL, NULL, NULL, N'7', N'4', N'1', NULL, NULL, N'2')
GO

INSERT INTO [dbo].[bankAccount] ([id], [memberId], [parentId], [bankId], [bankBranchName], [chinaMainRegionId], [chinaSubRegionId], [bankAccountNumber], [currencyCode], [amount], [status], [isChecked], [createDateTime], [memo], [l1], [l2], [l3], [l4], [l5], [l6], [l7], [l8], [l9], [lastModifyDateTime], [lastModifierId], [registerStatus]) VALUES (N'2', N'8', N'7', N'C013', NULL, N'MR06', N'SR081', N'13245458214', N'CNY', N'.000000000000', N'1', N'0', N'2018-05-23 02:48:15.000', N'', N'8', NULL, NULL, NULL, NULL, NULL, N'7', N'4', N'1', NULL, NULL, N'2')
GO

SET IDENTITY_INSERT [dbo].[bankAccount] OFF
GO


-- ----------------------------
-- Primary Key structure for table bankAccount
-- ----------------------------
ALTER TABLE [dbo].[bankAccount] ADD CONSTRAINT [PK__bankAcco__3213E83F6864E8BE] PRIMARY KEY CLUSTERED ([id])
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)  
ON [PRIMARY]
GO

