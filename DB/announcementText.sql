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

 Date: 25/05/2018 10:32:47
*/


-- ----------------------------
-- Table structure for announcementText
-- ----------------------------
IF EXISTS (SELECT * FROM sys.all_objects WHERE object_id = OBJECT_ID(N'[dbo].[announcementText]') AND type IN ('U'))
	DROP TABLE [dbo].[announcementText]
GO

CREATE TABLE [dbo].[announcementText] (
  [id] int  IDENTITY(1,1) NOT NULL,
  [announcementId] int  NOT NULL,
  [lang] varchar(5) COLLATE SQL_Latin1_General_CP1_CI_AS  NOT NULL,
  [subject] nvarchar(100) COLLATE SQL_Latin1_General_CP1_CI_AS  NOT NULL,
  [text] nvarchar(500) COLLATE SQL_Latin1_General_CP1_CI_AS  NOT NULL
)
GO

ALTER TABLE [dbo].[announcementText] SET (LOCK_ESCALATION = TABLE)
GO


-- ----------------------------
-- Primary Key structure for table announcementText
-- ----------------------------
ALTER TABLE [dbo].[announcementText] ADD CONSTRAINT [PK__announce__3213E83F372E766C] PRIMARY KEY CLUSTERED ([id])
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)  
ON [PRIMARY]
GO

