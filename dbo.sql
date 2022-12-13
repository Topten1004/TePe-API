/*
 Navicat Premium Data Transfer

 Source Server         : DESKTOP-Q4OJVS5
 Source Server Type    : SQL Server
 Source Server Version : 15002000
 Source Host           : DESKTOP-Q4OJVS5:1433
 Source Catalog        : TePeBrtDb
 Source Schema         : dbo

 Target Server Type    : SQL Server
 Target Server Version : 15002000
 File Encoding         : 65001

 Date: 08/09/2022 08:49:18
*/


-- ----------------------------
-- Table structure for __EFMigrationsHistory
-- ----------------------------
IF EXISTS (SELECT * FROM sys.all_objects WHERE object_id = OBJECT_ID(N'[dbo].[__EFMigrationsHistory]') AND type IN ('U'))
	DROP TABLE [dbo].[__EFMigrationsHistory]
GO

CREATE TABLE [dbo].[__EFMigrationsHistory] (
  [MigrationId] nvarchar(150) COLLATE SQL_Latin1_General_CP1_CI_AS  NOT NULL,
  [ProductVersion] nvarchar(32) COLLATE SQL_Latin1_General_CP1_CI_AS  NOT NULL
)
GO

ALTER TABLE [dbo].[__EFMigrationsHistory] SET (LOCK_ESCALATION = TABLE)
GO


-- ----------------------------
-- Records of __EFMigrationsHistory
-- ----------------------------
INSERT INTO [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20220901200427_Initial Migration', N'6.0.8')
GO


-- ----------------------------
-- Table structure for Categories
-- ----------------------------
IF EXISTS (SELECT * FROM sys.all_objects WHERE object_id = OBJECT_ID(N'[dbo].[Categories]') AND type IN ('U'))
	DROP TABLE [dbo].[Categories]
GO

CREATE TABLE [dbo].[Categories] (
  [Id] uniqueidentifier  NOT NULL,
  [Title] nvarchar(max) COLLATE SQL_Latin1_General_CP1_CI_AS  NULL,
  [catImage] nvarchar(max) COLLATE SQL_Latin1_General_CP1_CI_AS  NULL
)
GO

ALTER TABLE [dbo].[Categories] SET (LOCK_ESCALATION = TABLE)
GO


-- ----------------------------
-- Records of Categories
-- ----------------------------
INSERT INTO [dbo].[Categories] ([Id], [Title], [catImage]) VALUES (N'4C0D0419-A05E-4585-F6EE-08DA91803216', N'12312', N'files/CategoryImages/upwork_cda1.png')
GO

INSERT INTO [dbo].[Categories] ([Id], [Title], [catImage]) VALUES (N'FE92C431-C893-4DC0-54AF-08DA9197EF85', N'aaaa', N'files/CategoryImages/Screenshot_2022.07.17_06.49.52.629_955b.png')
GO


-- ----------------------------
-- Table structure for CategoryEntityMarketEntity
-- ----------------------------
IF EXISTS (SELECT * FROM sys.all_objects WHERE object_id = OBJECT_ID(N'[dbo].[CategoryEntityMarketEntity]') AND type IN ('U'))
	DROP TABLE [dbo].[CategoryEntityMarketEntity]
GO

CREATE TABLE [dbo].[CategoryEntityMarketEntity] (
  [CategoriesId] uniqueidentifier  NOT NULL,
  [MarketsId] uniqueidentifier  NOT NULL
)
GO

ALTER TABLE [dbo].[CategoryEntityMarketEntity] SET (LOCK_ESCALATION = TABLE)
GO


-- ----------------------------
-- Table structure for Markets
-- ----------------------------
IF EXISTS (SELECT * FROM sys.all_objects WHERE object_id = OBJECT_ID(N'[dbo].[Markets]') AND type IN ('U'))
	DROP TABLE [dbo].[Markets]
GO

CREATE TABLE [dbo].[Markets] (
  [Id] uniqueidentifier  NOT NULL,
  [Country] nvarchar(max) COLLATE SQL_Latin1_General_CP1_CI_AS  NULL,
  [LangCode] nvarchar(max) COLLATE SQL_Latin1_General_CP1_CI_AS  NULL
)
GO

ALTER TABLE [dbo].[Markets] SET (LOCK_ESCALATION = TABLE)
GO


-- ----------------------------
-- Records of Markets
-- ----------------------------
INSERT INTO [dbo].[Markets] ([Id], [Country], [LangCode]) VALUES (N'26FA154E-48DF-4B90-EB71-08DA9198544A', N'ad', N'adfadfadf')
GO


-- ----------------------------
-- Table structure for Patients
-- ----------------------------
IF EXISTS (SELECT * FROM sys.all_objects WHERE object_id = OBJECT_ID(N'[dbo].[Patients]') AND type IN ('U'))
	DROP TABLE [dbo].[Patients]
GO

CREATE TABLE [dbo].[Patients] (
  [Id] uniqueidentifier  NOT NULL,
  [Email] nvarchar(max) COLLATE SQL_Latin1_General_CP1_CI_AS  NULL,
  [PhoneNumber] nvarchar(max) COLLATE SQL_Latin1_General_CP1_CI_AS  NULL
)
GO

ALTER TABLE [dbo].[Patients] SET (LOCK_ESCALATION = TABLE)
GO


-- ----------------------------
-- Records of Patients
-- ----------------------------
INSERT INTO [dbo].[Patients] ([Id], [Email], [PhoneNumber]) VALUES (N'8A588E6D-A4D1-47B9-AF82-08DA917D967A', NULL, NULL)
GO


-- ----------------------------
-- Table structure for Products
-- ----------------------------
IF EXISTS (SELECT * FROM sys.all_objects WHERE object_id = OBJECT_ID(N'[dbo].[Products]') AND type IN ('U'))
	DROP TABLE [dbo].[Products]
GO

CREATE TABLE [dbo].[Products] (
  [Id] uniqueidentifier  NOT NULL,
  [Name] nvarchar(max) COLLATE SQL_Latin1_General_CP1_CI_AS  NULL,
  [Size] nvarchar(max) COLLATE SQL_Latin1_General_CP1_CI_AS  NULL,
  [Hex] nvarchar(max) COLLATE SQL_Latin1_General_CP1_CI_AS  NULL,
  [CategoryID] uniqueidentifier  NOT NULL
)
GO

ALTER TABLE [dbo].[Products] SET (LOCK_ESCALATION = TABLE)
GO


-- ----------------------------
-- Table structure for Puffs
-- ----------------------------
IF EXISTS (SELECT * FROM sys.all_objects WHERE object_id = OBJECT_ID(N'[dbo].[Puffs]') AND type IN ('U'))
	DROP TABLE [dbo].[Puffs]
GO

CREATE TABLE [dbo].[Puffs] (
  [Id] uniqueidentifier  NOT NULL,
  [Heading] nvarchar(max) COLLATE SQL_Latin1_General_CP1_CI_AS  NULL,
  [PuffImage] nvarchar(max) COLLATE SQL_Latin1_General_CP1_CI_AS  NULL,
  [Content] nvarchar(max) COLLATE SQL_Latin1_General_CP1_CI_AS  NULL,
  [MarketID] uniqueidentifier  NOT NULL
)
GO

ALTER TABLE [dbo].[Puffs] SET (LOCK_ESCALATION = TABLE)
GO


-- ----------------------------
-- Table structure for RecoItems
-- ----------------------------
IF EXISTS (SELECT * FROM sys.all_objects WHERE object_id = OBJECT_ID(N'[dbo].[RecoItems]') AND type IN ('U'))
	DROP TABLE [dbo].[RecoItems]
GO

CREATE TABLE [dbo].[RecoItems] (
  [Id] uniqueidentifier  NOT NULL,
  [Title] nvarchar(max) COLLATE SQL_Latin1_General_CP1_CI_AS  NULL,
  [Description] nvarchar(max) COLLATE SQL_Latin1_General_CP1_CI_AS  NULL,
  [Area] nvarchar(max) COLLATE SQL_Latin1_General_CP1_CI_AS  NULL,
  [RecommendationID] uniqueidentifier  NOT NULL
)
GO

ALTER TABLE [dbo].[RecoItems] SET (LOCK_ESCALATION = TABLE)
GO


-- ----------------------------
-- Table structure for Recommendations
-- ----------------------------
IF EXISTS (SELECT * FROM sys.all_objects WHERE object_id = OBJECT_ID(N'[dbo].[Recommendations]') AND type IN ('U'))
	DROP TABLE [dbo].[Recommendations]
GO

CREATE TABLE [dbo].[Recommendations] (
  [Id] uniqueidentifier  NOT NULL,
  [Comment] nvarchar(max) COLLATE SQL_Latin1_General_CP1_CI_AS  NOT NULL,
  [TeethImage] nvarchar(max) COLLATE SQL_Latin1_General_CP1_CI_AS  NULL,
  [Bridge] nvarchar(max) COLLATE SQL_Latin1_General_CP1_CI_AS  NULL,
  [Missing] nvarchar(max) COLLATE SQL_Latin1_General_CP1_CI_AS  NULL,
  [PatientID] uniqueidentifier  NOT NULL
)
GO

ALTER TABLE [dbo].[Recommendations] SET (LOCK_ESCALATION = TABLE)
GO


-- ----------------------------
-- Primary Key structure for table __EFMigrationsHistory
-- ----------------------------
ALTER TABLE [dbo].[__EFMigrationsHistory] ADD CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY CLUSTERED ([MigrationId])
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)  
ON [PRIMARY]
GO


-- ----------------------------
-- Primary Key structure for table Categories
-- ----------------------------
ALTER TABLE [dbo].[Categories] ADD CONSTRAINT [PK_Categories] PRIMARY KEY CLUSTERED ([Id])
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)  
ON [PRIMARY]
GO


-- ----------------------------
-- Indexes structure for table CategoryEntityMarketEntity
-- ----------------------------
CREATE NONCLUSTERED INDEX [IX_CategoryEntityMarketEntity_MarketsId]
ON [dbo].[CategoryEntityMarketEntity] (
  [MarketsId] ASC
)
GO


-- ----------------------------
-- Primary Key structure for table CategoryEntityMarketEntity
-- ----------------------------
ALTER TABLE [dbo].[CategoryEntityMarketEntity] ADD CONSTRAINT [PK_CategoryEntityMarketEntity] PRIMARY KEY CLUSTERED ([CategoriesId], [MarketsId])
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)  
ON [PRIMARY]
GO


-- ----------------------------
-- Primary Key structure for table Markets
-- ----------------------------
ALTER TABLE [dbo].[Markets] ADD CONSTRAINT [PK_Markets] PRIMARY KEY CLUSTERED ([Id])
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)  
ON [PRIMARY]
GO


-- ----------------------------
-- Primary Key structure for table Patients
-- ----------------------------
ALTER TABLE [dbo].[Patients] ADD CONSTRAINT [PK_Patients] PRIMARY KEY CLUSTERED ([Id])
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)  
ON [PRIMARY]
GO


-- ----------------------------
-- Indexes structure for table Products
-- ----------------------------
CREATE NONCLUSTERED INDEX [IX_Products_CategoryID]
ON [dbo].[Products] (
  [CategoryID] ASC
)
GO


-- ----------------------------
-- Primary Key structure for table Products
-- ----------------------------
ALTER TABLE [dbo].[Products] ADD CONSTRAINT [PK_Products] PRIMARY KEY CLUSTERED ([Id])
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)  
ON [PRIMARY]
GO


-- ----------------------------
-- Indexes structure for table Puffs
-- ----------------------------
CREATE NONCLUSTERED INDEX [IX_Puffs_MarketID]
ON [dbo].[Puffs] (
  [MarketID] ASC
)
GO


-- ----------------------------
-- Primary Key structure for table Puffs
-- ----------------------------
ALTER TABLE [dbo].[Puffs] ADD CONSTRAINT [PK_Puffs] PRIMARY KEY CLUSTERED ([Id])
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)  
ON [PRIMARY]
GO


-- ----------------------------
-- Indexes structure for table RecoItems
-- ----------------------------
CREATE NONCLUSTERED INDEX [IX_RecoItems_RecommendationID]
ON [dbo].[RecoItems] (
  [RecommendationID] ASC
)
GO


-- ----------------------------
-- Primary Key structure for table RecoItems
-- ----------------------------
ALTER TABLE [dbo].[RecoItems] ADD CONSTRAINT [PK_RecoItems] PRIMARY KEY CLUSTERED ([Id])
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)  
ON [PRIMARY]
GO


-- ----------------------------
-- Indexes structure for table Recommendations
-- ----------------------------
CREATE NONCLUSTERED INDEX [IX_Recommendations_PatientID]
ON [dbo].[Recommendations] (
  [PatientID] ASC
)
GO


-- ----------------------------
-- Primary Key structure for table Recommendations
-- ----------------------------
ALTER TABLE [dbo].[Recommendations] ADD CONSTRAINT [PK_Recommendations] PRIMARY KEY CLUSTERED ([Id])
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)  
ON [PRIMARY]
GO


-- ----------------------------
-- Foreign Keys structure for table CategoryEntityMarketEntity
-- ----------------------------
ALTER TABLE [dbo].[CategoryEntityMarketEntity] ADD CONSTRAINT [FK_CategoryEntityMarketEntity_Categories_CategoriesId] FOREIGN KEY ([CategoriesId]) REFERENCES [dbo].[Categories] ([Id]) ON DELETE CASCADE ON UPDATE NO ACTION
GO

ALTER TABLE [dbo].[CategoryEntityMarketEntity] ADD CONSTRAINT [FK_CategoryEntityMarketEntity_Markets_MarketsId] FOREIGN KEY ([MarketsId]) REFERENCES [dbo].[Markets] ([Id]) ON DELETE CASCADE ON UPDATE NO ACTION
GO


-- ----------------------------
-- Foreign Keys structure for table Products
-- ----------------------------
ALTER TABLE [dbo].[Products] ADD CONSTRAINT [FK_Products_Categories_CategoryID] FOREIGN KEY ([CategoryID]) REFERENCES [dbo].[Categories] ([Id]) ON DELETE CASCADE ON UPDATE NO ACTION
GO


-- ----------------------------
-- Foreign Keys structure for table Puffs
-- ----------------------------
ALTER TABLE [dbo].[Puffs] ADD CONSTRAINT [FK_Puffs_Markets_MarketID] FOREIGN KEY ([MarketID]) REFERENCES [dbo].[Markets] ([Id]) ON DELETE CASCADE ON UPDATE NO ACTION
GO


-- ----------------------------
-- Foreign Keys structure for table RecoItems
-- ----------------------------
ALTER TABLE [dbo].[RecoItems] ADD CONSTRAINT [FK_RecoItems_Recommendations_RecommendationID] FOREIGN KEY ([RecommendationID]) REFERENCES [dbo].[Recommendations] ([Id]) ON DELETE CASCADE ON UPDATE NO ACTION
GO


-- ----------------------------
-- Foreign Keys structure for table Recommendations
-- ----------------------------
ALTER TABLE [dbo].[Recommendations] ADD CONSTRAINT [FK_Recommendations_Patients_PatientID] FOREIGN KEY ([PatientID]) REFERENCES [dbo].[Patients] ([Id]) ON DELETE CASCADE ON UPDATE NO ACTION
GO

