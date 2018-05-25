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

 Date: 25/05/2018 10:33:35
*/


-- ----------------------------
-- Table structure for message
-- ----------------------------
IF EXISTS (SELECT * FROM sys.all_objects WHERE object_id = OBJECT_ID(N'[dbo].[message]') AND type IN ('U'))
	DROP TABLE [dbo].[message]
GO

CREATE TABLE [dbo].[message] (
  [id] int  IDENTITY(1,1) NOT NULL,
  [senderId] int  NOT NULL,
  [receiverId] int  NOT NULL,
  [subject] nvarchar(100) COLLATE SQL_Latin1_General_CP1_CI_AS  NOT NULL,
  [text] nvarchar(500) COLLATE SQL_Latin1_General_CP1_CI_AS  NOT NULL,
  [status] varchar(5) COLLATE SQL_Latin1_General_CP1_CI_AS  NOT NULL,
  [createDateTime] datetime  NOT NULL,
  [isRead] bit  NOT NULL,
  [readDateTime] datetime  NULL,
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
  [l9] int  NULL
)
GO

ALTER TABLE [dbo].[message] SET (LOCK_ESCALATION = TABLE)
GO


-- ----------------------------
-- Primary Key structure for table message
-- ----------------------------
ALTER TABLE [dbo].[message] ADD CONSTRAINT [PK__message__3213E83F3725D0EA] PRIMARY KEY CLUSTERED ([id])
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)  
ON [PRIMARY]
GO

