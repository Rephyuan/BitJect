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

 Date: 25/05/2018 10:32:16
*/


-- ----------------------------
-- Table structure for accountTransDetail
-- ----------------------------
IF EXISTS (SELECT * FROM sys.all_objects WHERE object_id = OBJECT_ID(N'[dbo].[accountTransDetail]') AND type IN ('U'))
	DROP TABLE [dbo].[accountTransDetail]
GO

CREATE TABLE [dbo].[accountTransDetail] (
  [id] int  IDENTITY(1,1) NOT NULL,
  [transferCateId] varchar(5) COLLATE SQL_Latin1_General_CP1_CI_AS  NOT NULL,
  [accountIdFrom] int  NOT NULL,
  [accountIdTo] int  NOT NULL,
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
  [r8] decimal(24,12)  NOT NULL,
  [r7] decimal(24,12)  NOT NULL,
  [r1] decimal(24,12)  NOT NULL,
  [amountFromExternal] decimal(28,12)  NULL,
  [feeRatioInExternal] decimal(28,12)  NULL,
  [feeRatioOutExternal] decimal(28,12)  NULL,
  [exRateInExternal] decimal(28,12)  NULL,
  [exRateOutExternal] decimal(28,12)  NULL,
  [memo] nvarchar(50) COLLATE SQL_Latin1_General_CP1_CI_AS  NULL
)
GO

ALTER TABLE [dbo].[accountTransDetail] SET (LOCK_ESCALATION = TABLE)
GO


-- ----------------------------
-- Primary Key structure for table accountTransDetail
-- ----------------------------
ALTER TABLE [dbo].[accountTransDetail] ADD CONSTRAINT [PK__accountT__3213E83FF24A85EE] PRIMARY KEY CLUSTERED ([id])
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)  
ON [PRIMARY]
GO

