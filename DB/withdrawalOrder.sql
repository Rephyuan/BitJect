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

 Date: 25/05/2018 10:33:44
*/


-- ----------------------------
-- Table structure for withdrawalOrder
-- ----------------------------
IF EXISTS (SELECT * FROM sys.all_objects WHERE object_id = OBJECT_ID(N'[dbo].[withdrawalOrder]') AND type IN ('U'))
	DROP TABLE [dbo].[withdrawalOrder]
GO

CREATE TABLE [dbo].[withdrawalOrder] (
  [id] int  IDENTITY(1,1) NOT NULL,
  [accountIdFrom] int  NOT NULL,
  [bankAccountIdTo] int  NOT NULL,
  [currencyCodeFrom] varchar(10) COLLATE SQL_Latin1_General_CP1_CI_AS  NOT NULL,
  [currencyCodeTo] varchar(10) COLLATE SQL_Latin1_General_CP1_CI_AS  NOT NULL,
  [amountFrom] decimal(28,12)  NOT NULL,
  [amountTo] decimal(28,12)  NOT NULL,
  [exDiff] decimal(28,12)  NOT NULL,
  [fee] decimal(28,12)  NOT NULL,
  [createDateTime] datetime  NOT NULL,
  [exRateWithDiff] decimal(28,14)  NOT NULL,
  [exRateWithoutDiff] decimal(28,14)  NOT NULL,
  [exRateFrom] decimal(16,8)  NOT NULL,
  [exSlopeFrom] decimal(16,8)  NOT NULL,
  [exInterceptFrom] decimal(24,12)  NOT NULL,
  [exRateTo] decimal(16,8)  NOT NULL,
  [exSlopeTo] decimal(16,8)  NOT NULL,
  [exInterceptTo] decimal(24,12)  NOT NULL,
  [feeRatio] decimal(16,8)  NOT NULL,
  [r8] decimal(24,12)  NULL,
  [r7] decimal(24,12)  NULL,
  [r1] decimal(24,12)  NULL,
  [amountFromExternal] decimal(28,12)  NULL,
  [feeRatioInExternal] decimal(28,12)  NULL,
  [feeRatioOutExternal] decimal(28,12)  NULL,
  [exRateInExternal] decimal(28,12)  NULL,
  [exRateOutExternal] decimal(28,12)  NULL,
  [isApiCreate] bit  NOT NULL,
  [status] varchar(5) COLLATE SQL_Latin1_General_CP1_CI_AS  NOT NULL,
  [memo] nvarchar(50) COLLATE SQL_Latin1_General_CP1_CI_AS  NULL,
  [memberId] int  NOT NULL,
  [p8] decimal(24,12)  NOT NULL,
  [p7] decimal(24,12)  NOT NULL,
  [feeMode] varchar(5) COLLATE SQL_Latin1_General_CP1_CI_AS  NOT NULL
)
GO

ALTER TABLE [dbo].[withdrawalOrder] SET (LOCK_ESCALATION = TABLE)
GO


-- ----------------------------
-- Records of [withdrawalOrder]
-- ----------------------------
SET IDENTITY_INSERT [dbo].[withdrawalOrder] ON
GO

INSERT INTO [dbo].[withdrawalOrder] ([id], [accountIdFrom], [bankAccountIdTo], [currencyCodeFrom], [currencyCodeTo], [amountFrom], [amountTo], [exDiff], [fee], [createDateTime], [exRateWithDiff], [exRateWithoutDiff], [exRateFrom], [exSlopeFrom], [exInterceptFrom], [exRateTo], [exSlopeTo], [exInterceptTo], [feeRatio], [r8], [r7], [r1], [amountFromExternal], [feeRatioInExternal], [feeRatioOutExternal], [exRateInExternal], [exRateOutExternal], [isApiCreate], [status], [memo], [memberId], [p8], [p7], [feeMode]) VALUES (N'7', N'2', N'2', N'BJC', N'CNY', N'72.110000000000', N'400.000000000000', N'2.000040000000', N'3.433402000000', N'2018-05-23 06:02:20.000', N'1.00000000000000', N'1.00000000000000', N'1.00000000', N'.00000000', N'.000000000000', N'1.00000000', N'.00000000', N'.000000000000', N'.05000000', N'36.055000000000', N'57.688000000000', N'72.110000000000', N'.000000000000', N'2.000000000000', N'4.000000000000', N'1.000000000000', N'4.000000000000', N'1', N'2', N'', N'8', N'.500000000000', N'.200000000000', N'2')
GO

INSERT INTO [dbo].[withdrawalOrder] ([id], [accountIdFrom], [bankAccountIdTo], [currencyCodeFrom], [currencyCodeTo], [amountFrom], [amountTo], [exDiff], [fee], [createDateTime], [exRateWithDiff], [exRateWithoutDiff], [exRateFrom], [exSlopeFrom], [exInterceptFrom], [exRateTo], [exSlopeTo], [exInterceptTo], [feeRatio], [r8], [r7], [r1], [amountFromExternal], [feeRatioInExternal], [feeRatioOutExternal], [exRateInExternal], [exRateOutExternal], [isApiCreate], [status], [memo], [memberId], [p8], [p7], [feeMode]) VALUES (N'8', N'2', N'1', N'BJC', N'TWD', N'420.000000000000', N'11651.000000000000', N'11.650485436893', N'20.000000000000', N'2018-05-23 06:03:38.000', N'1.00000000000000', N'1.00000000000000', N'1.00000000', N'.00000000', N'.000000000000', N'1.00000000', N'.00000000', N'.000000000000', N'.05000000', N'210.000000000000', N'336.000000000000', N'420.000000000000', N'.000000000000', N'.000000000000', N'.000000000000', N'.000000000000', N'.000000000000', N'1', N'2', N'', N'8', N'.500000000000', N'.200000000000', N'2')
GO

SET IDENTITY_INSERT [dbo].[withdrawalOrder] OFF
GO


-- ----------------------------
-- Primary Key structure for table withdrawalOrder
-- ----------------------------
ALTER TABLE [dbo].[withdrawalOrder] ADD CONSTRAINT [PK__withdraw__3213E83FD4D0B949] PRIMARY KEY CLUSTERED ([id])
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)  
ON [PRIMARY]
GO

