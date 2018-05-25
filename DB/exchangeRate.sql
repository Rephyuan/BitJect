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

 Date: 25/05/2018 10:33:11
*/


-- ----------------------------
-- Table structure for exchangeRate
-- ----------------------------
IF EXISTS (SELECT * FROM sys.all_objects WHERE object_id = OBJECT_ID(N'[dbo].[exchangeRate]') AND type IN ('U'))
	DROP TABLE [dbo].[exchangeRate]
GO

CREATE TABLE [dbo].[exchangeRate] (
  [id] int  IDENTITY(1,1) NOT NULL,
  [currencyCode] varchar(10) COLLATE SQL_Latin1_General_CP1_CI_AS  NOT NULL,
  [exRate] decimal(16,8)  NOT NULL,
  [exSlope] decimal(16,8)  NOT NULL,
  [exIntercept] decimal(24,12)  NOT NULL,
  [lastModifyDateTime] datetime  NULL
)
GO

ALTER TABLE [dbo].[exchangeRate] SET (LOCK_ESCALATION = TABLE)
GO


-- ----------------------------
-- Records of [exchangeRate]
-- ----------------------------
SET IDENTITY_INSERT [dbo].[exchangeRate] ON
GO

INSERT INTO [dbo].[exchangeRate] ([id], [currencyCode], [exRate], [exSlope], [exIntercept], [lastModifyDateTime]) VALUES (N'1', N'BJC', N'1.00000000', N'.00000000', N'.000000000000', N'2018-05-15 03:06:26.000')
GO

INSERT INTO [dbo].[exchangeRate] ([id], [currencyCode], [exRate], [exSlope], [exIntercept], [lastModifyDateTime]) VALUES (N'3', N'TWD', N'.03333000', N'.03000000', N'.000000000000', N'2018-05-15 03:06:55.000')
GO

INSERT INTO [dbo].[exchangeRate] ([id], [currencyCode], [exRate], [exSlope], [exIntercept], [lastModifyDateTime]) VALUES (N'4', N'CNY', N'.16667000', N'.03000000', N'.000000000000', N'2018-05-15 03:07:14.000')
GO

INSERT INTO [dbo].[exchangeRate] ([id], [currencyCode], [exRate], [exSlope], [exIntercept], [lastModifyDateTime]) VALUES (N'5', N'USD', N'1.00000000', N'.00000000', N'.000000000000', N'2018-05-15 03:07:33.000')
GO

SET IDENTITY_INSERT [dbo].[exchangeRate] OFF
GO


-- ----------------------------
-- Primary Key structure for table exchangeRate
-- ----------------------------
ALTER TABLE [dbo].[exchangeRate] ADD CONSTRAINT [PK__exchange__3213E83F940B202B] PRIMARY KEY CLUSTERED ([id])
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)  
ON [PRIMARY]
GO

