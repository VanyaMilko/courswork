
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 04/14/2022 18:34:20
-- Generated from EDMX file: C:\Users\Дмитрий\source\repos\Метод взвешенных оценок (на примере автомобильного завода)\DatabaseEntities\EntityModel.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [1];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_ExpertRate]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[RateSet] DROP CONSTRAINT [FK_ExpertRate];
GO
IF OBJECT_ID(N'[dbo].[FK_RateMarket]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[RateSet] DROP CONSTRAINT [FK_RateMarket];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[RateSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[RateSet];
GO
IF OBJECT_ID(N'[dbo].[AdminSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[AdminSet];
GO
IF OBJECT_ID(N'[dbo].[ClientSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ClientSet];
GO
IF OBJECT_ID(N'[dbo].[ExpertSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ExpertSet];
GO
IF OBJECT_ID(N'[dbo].[MarketSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[MarketSet];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'RateSet'
CREATE TABLE [dbo].[RateSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Value] float  NOT NULL,
    [TimeOfCommit] datetime  NOT NULL,
    [Expert_Id] int  NOT NULL,
    [Market_Id] int  NOT NULL
);
GO

-- Creating table 'AdminSet'
CREATE TABLE [dbo].[AdminSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Login] nvarchar(max)  NOT NULL,
    [Password] nvarchar(max)  NOT NULL,
    [UserStatus] int  NOT NULL
);
GO

-- Creating table 'ClientSet'
CREATE TABLE [dbo].[ClientSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Login] nvarchar(max)  NOT NULL,
    [Password] nvarchar(max)  NOT NULL,
    [UserStatus] int  NOT NULL
);
GO

-- Creating table 'ExpertSet'
CREATE TABLE [dbo].[ExpertSet] (
    [RateWeight] float  NOT NULL,
    [Id] int IDENTITY(1,1) NOT NULL,
    [Password] nvarchar(max)  NOT NULL,
    [Login] nvarchar(max)  NOT NULL,
    [UserStatus] int  NOT NULL
);
GO

-- Creating table 'MarketSet'
CREATE TABLE [dbo].[MarketSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [TotalRate] float  NOT NULL,
    [Country] nvarchar(max)  NOT NULL,
    [DemandLevel] float  NOT NULL,
    [CompetitionLevel] float  NOT NULL,
    [Trade] int  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'RateSet'
ALTER TABLE [dbo].[RateSet]
ADD CONSTRAINT [PK_RateSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'AdminSet'
ALTER TABLE [dbo].[AdminSet]
ADD CONSTRAINT [PK_AdminSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'ClientSet'
ALTER TABLE [dbo].[ClientSet]
ADD CONSTRAINT [PK_ClientSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'ExpertSet'
ALTER TABLE [dbo].[ExpertSet]
ADD CONSTRAINT [PK_ExpertSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'MarketSet'
ALTER TABLE [dbo].[MarketSet]
ADD CONSTRAINT [PK_MarketSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [Expert_Id] in table 'RateSet'
ALTER TABLE [dbo].[RateSet]
ADD CONSTRAINT [FK_ExpertRate]
    FOREIGN KEY ([Expert_Id])
    REFERENCES [dbo].[ExpertSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ExpertRate'
CREATE INDEX [IX_FK_ExpertRate]
ON [dbo].[RateSet]
    ([Expert_Id]);
GO

-- Creating foreign key on [Market_Id] in table 'RateSet'
ALTER TABLE [dbo].[RateSet]
ADD CONSTRAINT [FK_RateMarket]
    FOREIGN KEY ([Market_Id])
    REFERENCES [dbo].[MarketSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_RateMarket'
CREATE INDEX [IX_FK_RateMarket]
ON [dbo].[RateSet]
    ([Market_Id]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------