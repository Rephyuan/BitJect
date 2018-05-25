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

 Date: 25/05/2018 10:33:20
*/


-- ----------------------------
-- Table structure for log
-- ----------------------------
IF EXISTS (SELECT * FROM sys.all_objects WHERE object_id = OBJECT_ID(N'[dbo].[log]') AND type IN ('U'))
	DROP TABLE [dbo].[log]
GO

CREATE TABLE [dbo].[log] (
  [id] int  IDENTITY(1,1) NOT NULL,
  [createDateTime] datetime  NOT NULL,
  [memberId] int  NOT NULL,
  [targetId] int  NULL,
  [pageId] varchar(10) COLLATE SQL_Latin1_General_CP1_CI_AS  NOT NULL,
  [action] varchar(10) COLLATE SQL_Latin1_General_CP1_CI_AS  NOT NULL,
  [os] varchar(30) COLLATE SQL_Latin1_General_CP1_CI_AS  NOT NULL,
  [osVer] varchar(30) COLLATE SQL_Latin1_General_CP1_CI_AS  NOT NULL,
  [isWin64] bit  NOT NULL,
  [browser] varchar(30) COLLATE SQL_Latin1_General_CP1_CI_AS  NOT NULL,
  [browserVer] varchar(30) COLLATE SQL_Latin1_General_CP1_CI_AS  NOT NULL,
  [device] varchar(30) COLLATE SQL_Latin1_General_CP1_CI_AS  NOT NULL,
  [ip] varchar(40) COLLATE SQL_Latin1_General_CP1_CI_AS  NOT NULL,
  [desc] nvarchar(1000) COLLATE SQL_Latin1_General_CP1_CI_AS  NOT NULL,
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

ALTER TABLE [dbo].[log] SET (LOCK_ESCALATION = TABLE)
GO


-- ----------------------------
-- Records of [log]
-- ----------------------------
SET IDENTITY_INSERT [dbo].[log] ON
GO

INSERT INTO [dbo].[log] ([id], [createDateTime], [memberId], [targetId], [pageId], [action], [os], [osVer], [isWin64], [browser], [browserVer], [device], [ip], [desc], [l1], [l2], [l3], [l4], [l5], [l6], [l7], [l8], [l9]) VALUES (N'3', N'2018-05-14 01:55:22.000', N'4', N'7', N'a7', N'create', N'3', N'10', N'0', N'Chrome', N'66.0', N'1', N'::1', N'id=7', NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'4', N'1')
GO

INSERT INTO [dbo].[log] ([id], [createDateTime], [memberId], [targetId], [pageId], [action], [os], [osVer], [isWin64], [browser], [browserVer], [device], [ip], [desc], [l1], [l2], [l3], [l4], [l5], [l6], [l7], [l8], [l9]) VALUES (N'4', N'2018-05-15 10:16:26.000', N'1', N'10', N'a7', N'create', N'3', N'10', N'0', N'Chrome', N'66.0', N'1', N'127.0.0.1', N'id=10', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'1')
GO

INSERT INTO [dbo].[log] ([id], [createDateTime], [memberId], [targetId], [pageId], [action], [os], [osVer], [isWin64], [browser], [browserVer], [device], [ip], [desc], [l1], [l2], [l3], [l4], [l5], [l6], [l7], [l8], [l9]) VALUES (N'5', N'2018-05-15 10:19:27.000', N'1', N'11', N'a7', N'create', N'3', N'10', N'0', N'Chrome', N'66.0', N'1', N'127.0.0.1', N'id=11', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'1')
GO

INSERT INTO [dbo].[log] ([id], [createDateTime], [memberId], [targetId], [pageId], [action], [os], [osVer], [isWin64], [browser], [browserVer], [device], [ip], [desc], [l1], [l2], [l3], [l4], [l5], [l6], [l7], [l8], [l9]) VALUES (N'6', N'2018-05-15 10:20:34.000', N'4', N'12', N'a7', N'create', N'3', N'10', N'0', N'Chrome', N'66.0', N'1', N'127.0.0.1', N'id=12', NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'4', N'1')
GO

INSERT INTO [dbo].[log] ([id], [createDateTime], [memberId], [targetId], [pageId], [action], [os], [osVer], [isWin64], [browser], [browserVer], [device], [ip], [desc], [l1], [l2], [l3], [l4], [l5], [l6], [l7], [l8], [l9]) VALUES (N'7', N'2018-05-15 10:22:13.000', N'1', N'13', N'a7', N'create', N'3', N'10', N'0', N'Chrome', N'66.0', N'1', N'127.0.0.1', N'id=13', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'1')
GO

INSERT INTO [dbo].[log] ([id], [createDateTime], [memberId], [targetId], [pageId], [action], [os], [osVer], [isWin64], [browser], [browserVer], [device], [ip], [desc], [l1], [l2], [l3], [l4], [l5], [l6], [l7], [l8], [l9]) VALUES (N'8', N'2018-05-15 11:30:06.000', N'1', N'15', N'a7', N'create', N'3', N'10', N'0', N'Chrome', N'66.0', N'1', N'127.0.0.1', N'id=15', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'1')
GO

INSERT INTO [dbo].[log] ([id], [createDateTime], [memberId], [targetId], [pageId], [action], [os], [osVer], [isWin64], [browser], [browserVer], [device], [ip], [desc], [l1], [l2], [l3], [l4], [l5], [l6], [l7], [l8], [l9]) VALUES (N'9', N'2018-05-15 11:32:37.000', N'1', N'16', N'a7', N'create', N'3', N'10', N'0', N'Chrome', N'66.0', N'1', N'127.0.0.1', N'id=16', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'1')
GO

INSERT INTO [dbo].[log] ([id], [createDateTime], [memberId], [targetId], [pageId], [action], [os], [osVer], [isWin64], [browser], [browserVer], [device], [ip], [desc], [l1], [l2], [l3], [l4], [l5], [l6], [l7], [l8], [l9]) VALUES (N'10', N'2018-05-15 11:45:36.000', N'1', N'17', N'a7', N'create', N'3', N'10', N'0', N'Chrome', N'66.0', N'1', N'127.0.0.1', N'id=17', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'1')
GO

SET IDENTITY_INSERT [dbo].[log] OFF
GO


-- ----------------------------
-- Primary Key structure for table log
-- ----------------------------
ALTER TABLE [dbo].[log] ADD CONSTRAINT [PK__log__3213E83FFE4937ED] PRIMARY KEY CLUSTERED ([id])
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)  
ON [PRIMARY]
GO

