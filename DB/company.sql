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

 Date: 25/05/2018 10:33:03
*/


-- ----------------------------
-- Table structure for company
-- ----------------------------
IF EXISTS (SELECT * FROM sys.all_objects WHERE object_id = OBJECT_ID(N'[dbo].[company]') AND type IN ('U'))
	DROP TABLE [dbo].[company]
GO

CREATE TABLE [dbo].[company] (
  [id] int  IDENTITY(1,1) NOT NULL,
  [name] nvarchar(50) COLLATE SQL_Latin1_General_CP1_CI_AS  NULL,
  [data] nvarchar(max) COLLATE SQL_Latin1_General_CP1_CI_AS  NULL,
  [createDateTime] datetime  NOT NULL,
  [status] varchar(50) COLLATE SQL_Latin1_General_CP1_CI_AS  NOT NULL,
  [gmt] float(53)  NULL,
  [principalId] int  NOT NULL,
  [rentPrice] decimal(18,2)  NULL,
  [beginDateTime] datetime  NULL,
  [endDateTime] datetime  NULL,
  [url] varchar(255) COLLATE SQL_Latin1_General_CP1_CI_AS  NULL,
  [apiKey] varchar(255) COLLATE SQL_Latin1_General_CP1_CI_AS  NULL,
  [isMain] bit  NULL,
  [logoPath] varchar(255) COLLATE SQL_Latin1_General_CP1_CI_AS  NULL,
  [principalLevelId] int  NOT NULL,
  [templates] varchar(50) COLLATE SQL_Latin1_General_CP1_CI_AS  NULL,
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

ALTER TABLE [dbo].[company] SET (LOCK_ESCALATION = TABLE)
GO


-- ----------------------------
-- Records of [company]
-- ----------------------------
SET IDENTITY_INSERT [dbo].[company] ON
GO

INSERT INTO [dbo].[company] ([id], [name], [data], [createDateTime], [status], [gmt], [principalId], [rentPrice], [beginDateTime], [endDateTime], [url], [apiKey], [isMain], [logoPath], [principalLevelId], [templates], [l1], [l2], [l3], [l4], [l5], [l6], [l7], [l8], [l9]) VALUES (N'1', N'幣捷', NULL, N'2018-05-11 09:13:54.000', N'1', NULL, N'1', NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'9', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'1')
GO

INSERT INTO [dbo].[company] ([id], [name], [data], [createDateTime], [status], [gmt], [principalId], [rentPrice], [beginDateTime], [endDateTime], [url], [apiKey], [isMain], [logoPath], [principalLevelId], [templates], [l1], [l2], [l3], [l4], [l5], [l6], [l7], [l8], [l9]) VALUES (N'4', N'鎂果', N'{}', N'2018-05-14 01:43:21.000', N'1', NULL, N'4', N'.00', N'2018-05-14 01:43:21.000', N'2118-05-14 01:43:21.000', N'', N'4109bf8c386a4f2f94fd58b24b600b1d', N'1', N'', N'8', N'{}', NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'4', N'1')
GO

INSERT INTO [dbo].[company] ([id], [name], [data], [createDateTime], [status], [gmt], [principalId], [rentPrice], [beginDateTime], [endDateTime], [url], [apiKey], [isMain], [logoPath], [principalLevelId], [templates], [l1], [l2], [l3], [l4], [l5], [l6], [l7], [l8], [l9]) VALUES (N'7', N'味全', N'{}', N'2018-05-14 01:55:21.000', N'1', NULL, N'7', N'.00', N'2018-05-14 01:55:21.000', N'2118-05-14 01:55:21.000', N'', N'3406836b5a5a45289fdb79652b6db59e', N'1', N'', N'7', N'{}', NULL, NULL, NULL, NULL, NULL, NULL, N'7', N'4', N'1')
GO

INSERT INTO [dbo].[company] ([id], [name], [data], [createDateTime], [status], [gmt], [principalId], [rentPrice], [beginDateTime], [endDateTime], [url], [apiKey], [isMain], [logoPath], [principalLevelId], [templates], [l1], [l2], [l3], [l4], [l5], [l6], [l7], [l8], [l9]) VALUES (N'8', N'test', N'{}', N'2018-05-15 10:16:25.000', N'1', NULL, N'10', N'.00', N'2018-05-15 10:16:25.000', N'2118-05-15 10:16:25.000', N'', N'a78a6e849ff94b4c886a4d9a92f97b88', N'1', N'', N'8', N'{}', NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'10', N'1')
GO

INSERT INTO [dbo].[company] ([id], [name], [data], [createDateTime], [status], [gmt], [principalId], [rentPrice], [beginDateTime], [endDateTime], [url], [apiKey], [isMain], [logoPath], [principalLevelId], [templates], [l1], [l2], [l3], [l4], [l5], [l6], [l7], [l8], [l9]) VALUES (N'9', N'測試', N'{}', N'2018-05-15 10:19:27.000', N'1', NULL, N'11', N'.00', N'2018-05-15 10:19:27.000', N'2118-05-15 10:19:27.000', N'', N'6eb92433b86241feb819533859eaa6f1', N'1', N'', N'8', N'{}', NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'11', N'1')
GO

INSERT INTO [dbo].[company] ([id], [name], [data], [createDateTime], [status], [gmt], [principalId], [rentPrice], [beginDateTime], [endDateTime], [url], [apiKey], [isMain], [logoPath], [principalLevelId], [templates], [l1], [l2], [l3], [l4], [l5], [l6], [l7], [l8], [l9]) VALUES (N'10', N'味全', N'{}', N'2018-05-15 10:20:34.000', N'1', NULL, N'12', N'.00', N'2018-05-15 10:20:34.000', N'2118-05-15 10:20:34.000', N'', N'cbb18737d50546d8b786d2361859e160', N'1', N'', N'7', N'{}', NULL, NULL, NULL, NULL, NULL, NULL, N'12', N'4', N'1')
GO

INSERT INTO [dbo].[company] ([id], [name], [data], [createDateTime], [status], [gmt], [principalId], [rentPrice], [beginDateTime], [endDateTime], [url], [apiKey], [isMain], [logoPath], [principalLevelId], [templates], [l1], [l2], [l3], [l4], [l5], [l6], [l7], [l8], [l9]) VALUES (N'11', N'測試用', N'{}', N'2018-05-15 10:22:13.000', N'1', NULL, N'13', N'.00', N'2018-05-15 10:22:13.000', N'2118-05-15 10:22:13.000', N'', N'191537bd6eca403fb3ae41dbbe7ea8b9', N'1', N'', N'8', N'{}', NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'13', N'1')
GO

INSERT INTO [dbo].[company] ([id], [name], [data], [createDateTime], [status], [gmt], [principalId], [rentPrice], [beginDateTime], [endDateTime], [url], [apiKey], [isMain], [logoPath], [principalLevelId], [templates], [l1], [l2], [l3], [l4], [l5], [l6], [l7], [l8], [l9]) VALUES (N'12', N'測試', N'{}', N'2018-05-15 11:30:06.000', N'1', NULL, N'15', N'.00', N'2018-05-15 11:30:06.000', N'2118-05-15 11:30:06.000', N'', N'36b1aaef090447799bae2cbc187ac4e6', N'1', N'', N'8', N'{}', NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'15', N'1')
GO

INSERT INTO [dbo].[company] ([id], [name], [data], [createDateTime], [status], [gmt], [principalId], [rentPrice], [beginDateTime], [endDateTime], [url], [apiKey], [isMain], [logoPath], [principalLevelId], [templates], [l1], [l2], [l3], [l4], [l5], [l6], [l7], [l8], [l9]) VALUES (N'13', N'測試', N'{}', N'2018-05-15 11:32:37.000', N'1', NULL, N'16', N'.00', N'2018-05-15 11:32:37.000', N'2118-05-15 11:32:37.000', N'', N'9b37df444d444f788e7f1549eb6769ce', N'1', N'', N'8', N'{}', NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'16', N'1')
GO

INSERT INTO [dbo].[company] ([id], [name], [data], [createDateTime], [status], [gmt], [principalId], [rentPrice], [beginDateTime], [endDateTime], [url], [apiKey], [isMain], [logoPath], [principalLevelId], [templates], [l1], [l2], [l3], [l4], [l5], [l6], [l7], [l8], [l9]) VALUES (N'14', N'測試', N'{}', N'2018-05-15 11:45:36.000', N'1', NULL, N'17', N'.00', N'2018-05-15 11:45:36.000', N'2118-05-15 11:45:36.000', N'', N'a843e9c819df493a9013bc9f6af3a953', N'1', N'', N'8', N'{}', NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'17', N'1')
GO

SET IDENTITY_INSERT [dbo].[company] OFF
GO


-- ----------------------------
-- Primary Key structure for table company
-- ----------------------------
ALTER TABLE [dbo].[company] ADD CONSTRAINT [PK__company__3213E83F1A994436] PRIMARY KEY CLUSTERED ([id])
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)  
ON [PRIMARY]
GO

