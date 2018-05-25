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

 Date: 25/05/2018 10:32:09
*/


-- ----------------------------
-- Table structure for accountTrans
-- ----------------------------
IF EXISTS (SELECT * FROM sys.all_objects WHERE object_id = OBJECT_ID(N'[dbo].[accountTrans]') AND type IN ('U'))
	DROP TABLE [dbo].[accountTrans]
GO

CREATE TABLE [dbo].[accountTrans] (
  [id] int  IDENTITY(1,1) NOT NULL,
  [detailId] int  NOT NULL,
  [memberId] int  NOT NULL,
  [memberLevelId] int  NOT NULL,
  [memberParentId] int  NOT NULL,
  [accountId] int  NOT NULL,
  [transferCateId] varchar(5) COLLATE SQL_Latin1_General_CP1_CI_AS  NOT NULL,
  [transferTypeId] varchar(5) COLLATE SQL_Latin1_General_CP1_CI_AS  NOT NULL,
  [amountTypeId] varchar(5) COLLATE SQL_Latin1_General_CP1_CI_AS  NOT NULL,
  [amount] decimal(28,12)  NOT NULL,
  [balanceBefore] decimal(28,12)  NOT NULL,
  [balanceAfter] decimal(28,12)  NOT NULL,
  [frozenBalanceBefore] decimal(28,12)  NOT NULL,
  [frozenBalanceAfter] decimal(28,12)  NOT NULL,
  [createDateTime] datetime  NOT NULL,
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

ALTER TABLE [dbo].[accountTrans] SET (LOCK_ESCALATION = TABLE)
GO


-- ----------------------------
-- Records of [accountTrans]
-- ----------------------------
SET IDENTITY_INSERT [dbo].[accountTrans] ON
GO

INSERT INTO [dbo].[accountTrans] ([id], [detailId], [memberId], [memberLevelId], [memberParentId], [accountId], [transferCateId], [transferTypeId], [amountTypeId], [amount], [balanceBefore], [balanceAfter], [frozenBalanceBefore], [frozenBalanceAfter], [createDateTime], [l1], [l2], [l3], [l4], [l5], [l6], [l7], [l8], [l9]) VALUES (N'5', N'7', N'7', N'7', N'4', N'4', N'4', N'2', N'2', N'72.110000000000', N'496570.910000000000', N'496570.910000000000', N'.000000000000', N'72.110000000000', N'2018-05-23 06:02:20.000', NULL, NULL, NULL, NULL, NULL, NULL, N'7', N'4', N'1')
GO

INSERT INTO [dbo].[accountTrans] ([id], [detailId], [memberId], [memberLevelId], [memberParentId], [accountId], [transferCateId], [transferTypeId], [amountTypeId], [amount], [balanceBefore], [balanceAfter], [frozenBalanceBefore], [frozenBalanceAfter], [createDateTime], [l1], [l2], [l3], [l4], [l5], [l6], [l7], [l8], [l9]) VALUES (N'6', N'8', N'7', N'7', N'4', N'4', N'4', N'2', N'2', N'420.000000000000', N'496570.910000000000', N'496570.910000000000', N'72.110000000000', N'492.110000000000', N'2018-05-23 06:03:38.000', NULL, NULL, NULL, NULL, NULL, NULL, N'7', N'4', N'1')
GO

SET IDENTITY_INSERT [dbo].[accountTrans] OFF
GO


-- ----------------------------
-- Primary Key structure for table accountTrans
-- ----------------------------
ALTER TABLE [dbo].[accountTrans] ADD CONSTRAINT [PK__accountT__3213E83F4B9D6384] PRIMARY KEY CLUSTERED ([id])
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)  
ON [PRIMARY]
GO

