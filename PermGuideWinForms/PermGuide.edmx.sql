
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 03/26/2018 05:22:18
-- Generated from EDMX file: C:\Users\Максим\Documents\Visual Studio 2017\Projects\PermGuideWinForms\PermGuideWinForms\PermGuide.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [PermGuide];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_UserReview]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ReviewSet] DROP CONSTRAINT [FK_UserReview];
GO
IF OBJECT_ID(N'[dbo].[FK_RegionSight]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ContentSet_Sight] DROP CONSTRAINT [FK_RegionSight];
GO
IF OBJECT_ID(N'[dbo].[FK_UserTimetable]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[TimetableSet] DROP CONSTRAINT [FK_UserTimetable];
GO
IF OBJECT_ID(N'[dbo].[FK_ArticleFile_Article]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ArticleFile] DROP CONSTRAINT [FK_ArticleFile_Article];
GO
IF OBJECT_ID(N'[dbo].[FK_ArticleFile_File]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ArticleFile] DROP CONSTRAINT [FK_ArticleFile_File];
GO
IF OBJECT_ID(N'[dbo].[FK_SightArticle]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ContentSet_Article] DROP CONSTRAINT [FK_SightArticle];
GO
IF OBJECT_ID(N'[dbo].[FK_RegionArticle]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ContentSet_Article] DROP CONSTRAINT [FK_RegionArticle];
GO
IF OBJECT_ID(N'[dbo].[FK_ExcursionArticle]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ContentSet_Article] DROP CONSTRAINT [FK_ExcursionArticle];
GO
IF OBJECT_ID(N'[dbo].[FK_ExcursionSight_Excursion]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ExcursionSight] DROP CONSTRAINT [FK_ExcursionSight_Excursion];
GO
IF OBJECT_ID(N'[dbo].[FK_ExcursionSight_Sight]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ExcursionSight] DROP CONSTRAINT [FK_ExcursionSight_Sight];
GO
IF OBJECT_ID(N'[dbo].[FK_UserRecordFileRecord]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[MediaFileSet] DROP CONSTRAINT [FK_UserRecordFileRecord];
GO
IF OBJECT_ID(N'[dbo].[FK_ContentRecordReviewRecord]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ReviewSet] DROP CONSTRAINT [FK_ContentRecordReviewRecord];
GO
IF OBJECT_ID(N'[dbo].[FK_UserRecordContentRecord]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ContentSet] DROP CONSTRAINT [FK_UserRecordContentRecord];
GO
IF OBJECT_ID(N'[dbo].[FK_Sight_inherits_Content]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ContentSet_Sight] DROP CONSTRAINT [FK_Sight_inherits_Content];
GO
IF OBJECT_ID(N'[dbo].[FK_Article_inherits_Content]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ContentSet_Article] DROP CONSTRAINT [FK_Article_inherits_Content];
GO
IF OBJECT_ID(N'[dbo].[FK_Excursion_inherits_Content]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ContentSet_Excursion] DROP CONSTRAINT [FK_Excursion_inherits_Content];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[UserSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[UserSet];
GO
IF OBJECT_ID(N'[dbo].[ReviewSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ReviewSet];
GO
IF OBJECT_ID(N'[dbo].[MediaFileSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[MediaFileSet];
GO
IF OBJECT_ID(N'[dbo].[RegionSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[RegionSet];
GO
IF OBJECT_ID(N'[dbo].[TimetableSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[TimetableSet];
GO
IF OBJECT_ID(N'[dbo].[ContentSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ContentSet];
GO
IF OBJECT_ID(N'[dbo].[ContentSet_Sight]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ContentSet_Sight];
GO
IF OBJECT_ID(N'[dbo].[ContentSet_Article]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ContentSet_Article];
GO
IF OBJECT_ID(N'[dbo].[ContentSet_Excursion]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ContentSet_Excursion];
GO
IF OBJECT_ID(N'[dbo].[ArticleFile]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ArticleFile];
GO
IF OBJECT_ID(N'[dbo].[ExcursionSight]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ExcursionSight];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'UserSet'
CREATE TABLE [dbo].[UserSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Login] nvarchar(max)  NOT NULL,
    [Password] nvarchar(max)  NOT NULL,
    [Nickname] nvarchar(max)  NOT NULL,
    [Status] int  NOT NULL,
    [BanStatus_IsBanned] bit  NOT NULL,
    [BanStatus_BannedTill] datetime  NOT NULL
);
GO

-- Creating table 'ReviewSet'
CREATE TABLE [dbo].[ReviewSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [CreationDate] datetime  NOT NULL,
    [Mark] int  NOT NULL,
    [Text] nvarchar(max)  NOT NULL,
    [User_Id] int  NOT NULL,
    [Content_Id] int  NOT NULL
);
GO

-- Creating table 'MediaFileSet'
CREATE TABLE [dbo].[MediaFileSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Uri] nvarchar(max)  NOT NULL,
    [MediaType] int  NOT NULL,
    [User_Id] int  NOT NULL
);
GO

-- Creating table 'RegionSet'
CREATE TABLE [dbo].[RegionSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'TimetableSet'
CREATE TABLE [dbo].[TimetableSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [CreationDate] datetime  NOT NULL,
    [Activities] nvarchar(max)  NOT NULL,
    [User_Id] int  NOT NULL
);
GO

-- Creating table 'ContentSet'
CREATE TABLE [dbo].[ContentSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [ProposalStatus] int  NOT NULL,
    [User_Id] int  NOT NULL
);
GO

-- Creating table 'ContentSet_Sight'
CREATE TABLE [dbo].[ContentSet_Sight] (
    [Location] nvarchar(max)  NOT NULL,
    [Address] nvarchar(max)  NOT NULL,
    [Id] int  NOT NULL,
    [Region_Id] int  NULL
);
GO

-- Creating table 'ContentSet_Article'
CREATE TABLE [dbo].[ContentSet_Article] (
    [Id] int  NOT NULL,
    [Sight_Id] int  NULL,
    [Region_Id] int  NULL,
    [Excursion_Id] int  NULL
);
GO

-- Creating table 'ContentSet_Excursion'
CREATE TABLE [dbo].[ContentSet_Excursion] (
    [Id] int  NOT NULL
);
GO

-- Creating table 'ArticleFile'
CREATE TABLE [dbo].[ArticleFile] (
    [Article_Id] int  NOT NULL,
    [File_Id] int  NOT NULL
);
GO

-- Creating table 'ExcursionSight'
CREATE TABLE [dbo].[ExcursionSight] (
    [Excursion_Id] int  NOT NULL,
    [Sight_Id] int  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'UserSet'
ALTER TABLE [dbo].[UserSet]
ADD CONSTRAINT [PK_UserSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'ReviewSet'
ALTER TABLE [dbo].[ReviewSet]
ADD CONSTRAINT [PK_ReviewSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'MediaFileSet'
ALTER TABLE [dbo].[MediaFileSet]
ADD CONSTRAINT [PK_MediaFileSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'RegionSet'
ALTER TABLE [dbo].[RegionSet]
ADD CONSTRAINT [PK_RegionSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'TimetableSet'
ALTER TABLE [dbo].[TimetableSet]
ADD CONSTRAINT [PK_TimetableSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'ContentSet'
ALTER TABLE [dbo].[ContentSet]
ADD CONSTRAINT [PK_ContentSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'ContentSet_Sight'
ALTER TABLE [dbo].[ContentSet_Sight]
ADD CONSTRAINT [PK_ContentSet_Sight]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'ContentSet_Article'
ALTER TABLE [dbo].[ContentSet_Article]
ADD CONSTRAINT [PK_ContentSet_Article]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'ContentSet_Excursion'
ALTER TABLE [dbo].[ContentSet_Excursion]
ADD CONSTRAINT [PK_ContentSet_Excursion]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Article_Id], [File_Id] in table 'ArticleFile'
ALTER TABLE [dbo].[ArticleFile]
ADD CONSTRAINT [PK_ArticleFile]
    PRIMARY KEY CLUSTERED ([Article_Id], [File_Id] ASC);
GO

-- Creating primary key on [Excursion_Id], [Sight_Id] in table 'ExcursionSight'
ALTER TABLE [dbo].[ExcursionSight]
ADD CONSTRAINT [PK_ExcursionSight]
    PRIMARY KEY CLUSTERED ([Excursion_Id], [Sight_Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [User_Id] in table 'ReviewSet'
ALTER TABLE [dbo].[ReviewSet]
ADD CONSTRAINT [FK_UserReview]
    FOREIGN KEY ([User_Id])
    REFERENCES [dbo].[UserSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_UserReview'
CREATE INDEX [IX_FK_UserReview]
ON [dbo].[ReviewSet]
    ([User_Id]);
GO

-- Creating foreign key on [Region_Id] in table 'ContentSet_Sight'
ALTER TABLE [dbo].[ContentSet_Sight]
ADD CONSTRAINT [FK_RegionSight]
    FOREIGN KEY ([Region_Id])
    REFERENCES [dbo].[RegionSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_RegionSight'
CREATE INDEX [IX_FK_RegionSight]
ON [dbo].[ContentSet_Sight]
    ([Region_Id]);
GO

-- Creating foreign key on [User_Id] in table 'TimetableSet'
ALTER TABLE [dbo].[TimetableSet]
ADD CONSTRAINT [FK_UserTimetable]
    FOREIGN KEY ([User_Id])
    REFERENCES [dbo].[UserSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_UserTimetable'
CREATE INDEX [IX_FK_UserTimetable]
ON [dbo].[TimetableSet]
    ([User_Id]);
GO

-- Creating foreign key on [Article_Id] in table 'ArticleFile'
ALTER TABLE [dbo].[ArticleFile]
ADD CONSTRAINT [FK_ArticleFile_Article]
    FOREIGN KEY ([Article_Id])
    REFERENCES [dbo].[ContentSet_Article]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [File_Id] in table 'ArticleFile'
ALTER TABLE [dbo].[ArticleFile]
ADD CONSTRAINT [FK_ArticleFile_File]
    FOREIGN KEY ([File_Id])
    REFERENCES [dbo].[MediaFileSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ArticleFile_File'
CREATE INDEX [IX_FK_ArticleFile_File]
ON [dbo].[ArticleFile]
    ([File_Id]);
GO

-- Creating foreign key on [Sight_Id] in table 'ContentSet_Article'
ALTER TABLE [dbo].[ContentSet_Article]
ADD CONSTRAINT [FK_SightArticle]
    FOREIGN KEY ([Sight_Id])
    REFERENCES [dbo].[ContentSet_Sight]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_SightArticle'
CREATE INDEX [IX_FK_SightArticle]
ON [dbo].[ContentSet_Article]
    ([Sight_Id]);
GO

-- Creating foreign key on [Region_Id] in table 'ContentSet_Article'
ALTER TABLE [dbo].[ContentSet_Article]
ADD CONSTRAINT [FK_RegionArticle]
    FOREIGN KEY ([Region_Id])
    REFERENCES [dbo].[RegionSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_RegionArticle'
CREATE INDEX [IX_FK_RegionArticle]
ON [dbo].[ContentSet_Article]
    ([Region_Id]);
GO

-- Creating foreign key on [Excursion_Id] in table 'ContentSet_Article'
ALTER TABLE [dbo].[ContentSet_Article]
ADD CONSTRAINT [FK_ExcursionArticle]
    FOREIGN KEY ([Excursion_Id])
    REFERENCES [dbo].[ContentSet_Excursion]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ExcursionArticle'
CREATE INDEX [IX_FK_ExcursionArticle]
ON [dbo].[ContentSet_Article]
    ([Excursion_Id]);
GO

-- Creating foreign key on [Excursion_Id] in table 'ExcursionSight'
ALTER TABLE [dbo].[ExcursionSight]
ADD CONSTRAINT [FK_ExcursionSight_Excursion]
    FOREIGN KEY ([Excursion_Id])
    REFERENCES [dbo].[ContentSet_Excursion]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Sight_Id] in table 'ExcursionSight'
ALTER TABLE [dbo].[ExcursionSight]
ADD CONSTRAINT [FK_ExcursionSight_Sight]
    FOREIGN KEY ([Sight_Id])
    REFERENCES [dbo].[ContentSet_Sight]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ExcursionSight_Sight'
CREATE INDEX [IX_FK_ExcursionSight_Sight]
ON [dbo].[ExcursionSight]
    ([Sight_Id]);
GO

-- Creating foreign key on [User_Id] in table 'MediaFileSet'
ALTER TABLE [dbo].[MediaFileSet]
ADD CONSTRAINT [FK_UserRecordFileRecord]
    FOREIGN KEY ([User_Id])
    REFERENCES [dbo].[UserSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_UserRecordFileRecord'
CREATE INDEX [IX_FK_UserRecordFileRecord]
ON [dbo].[MediaFileSet]
    ([User_Id]);
GO

-- Creating foreign key on [Content_Id] in table 'ReviewSet'
ALTER TABLE [dbo].[ReviewSet]
ADD CONSTRAINT [FK_ContentRecordReviewRecord]
    FOREIGN KEY ([Content_Id])
    REFERENCES [dbo].[ContentSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ContentRecordReviewRecord'
CREATE INDEX [IX_FK_ContentRecordReviewRecord]
ON [dbo].[ReviewSet]
    ([Content_Id]);
GO

-- Creating foreign key on [User_Id] in table 'ContentSet'
ALTER TABLE [dbo].[ContentSet]
ADD CONSTRAINT [FK_UserRecordContentRecord]
    FOREIGN KEY ([User_Id])
    REFERENCES [dbo].[UserSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_UserRecordContentRecord'
CREATE INDEX [IX_FK_UserRecordContentRecord]
ON [dbo].[ContentSet]
    ([User_Id]);
GO

-- Creating foreign key on [Id] in table 'ContentSet_Sight'
ALTER TABLE [dbo].[ContentSet_Sight]
ADD CONSTRAINT [FK_Sight_inherits_Content]
    FOREIGN KEY ([Id])
    REFERENCES [dbo].[ContentSet]
        ([Id])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Id] in table 'ContentSet_Article'
ALTER TABLE [dbo].[ContentSet_Article]
ADD CONSTRAINT [FK_Article_inherits_Content]
    FOREIGN KEY ([Id])
    REFERENCES [dbo].[ContentSet]
        ([Id])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Id] in table 'ContentSet_Excursion'
ALTER TABLE [dbo].[ContentSet_Excursion]
ADD CONSTRAINT [FK_Excursion_inherits_Content]
    FOREIGN KEY ([Id])
    REFERENCES [dbo].[ContentSet]
        ([Id])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------