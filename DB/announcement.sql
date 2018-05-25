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

 Date: 25/05/2018 10:32:26
*/


-- ----------------------------
-- Table structure for announcement
-- ----------------------------
IF EXISTS (SELECT * FROM sys.all_objects WHERE object_id = OBJECT_ID(N'[dbo].[announcement]') AND type IN ('U'))
	DROP TABLE [dbo].[announcement]
GO

CREATE TABLE [dbo].[announcement] (
  [id] int  IDENTITY(1,1) NOT NULL,
  [agentId] int  NOT NULL,
  [agentLevelId] int  NOT NULL,
  [typeId] varchar(5) COLLATE SQL_Latin1_General_CP1_CI_AS  NOT NULL,
  [isTop] bit  NOT NULL,
  [status] varchar(10) COLLATE SQL_Latin1_General_CP1_CI_AS  NOT NULL,
  [lastModifierId] int  NULL,
  [createDateTime] datetime  NOT NULL,
  [lastModifyDateTime] datetime  NULL,
  [effectiveBeginDateTime] datetime  NULL,
  [effectiveEndDateTime] datetime  NULL,
  [l7] int  NULL,
  [l8] int  NULL,
  [l9] int  NULL
)
GO

ALTER TABLE [dbo].[announcement] SET (LOCK_ESCALATION = TABLE)
GO


-- ----------------------------
-- Primary Key structure for table announcement
-- ----------------------------
ALTER TABLE [dbo].[announcement] ADD CONSTRAINT [PK__announce__3213E83FDBEF9015] PRIMARY KEY CLUSTERED ([id])
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)  
ON [PRIMARY]
GO

