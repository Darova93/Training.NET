USE [master]
GO
/****** Object:  Database [ToDoList_<DRVA>]    Script Date: 1/30/2018 8:52:40 PM ******/
CREATE DATABASE [ToDoList_<DRVA>]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'ToDoList_<DRVA>', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.SQLEXPRESS\MSSQL\DATA\ToDoList__DRVA_.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'ToDoList__DRVA__log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.SQLEXPRESS\MSSQL\DATA\ToDoList__DRVA__log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [ToDoList_<DRVA>] SET COMPATIBILITY_LEVEL = 140
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [ToDoList_<DRVA>].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [ToDoList_<DRVA>] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [ToDoList_<DRVA>] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [ToDoList_<DRVA>] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [ToDoList_<DRVA>] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [ToDoList_<DRVA>] SET ARITHABORT OFF 
GO
ALTER DATABASE [ToDoList_<DRVA>] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [ToDoList_<DRVA>] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [ToDoList_<DRVA>] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [ToDoList_<DRVA>] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [ToDoList_<DRVA>] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [ToDoList_<DRVA>] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [ToDoList_<DRVA>] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [ToDoList_<DRVA>] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [ToDoList_<DRVA>] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [ToDoList_<DRVA>] SET  ENABLE_BROKER 
GO
ALTER DATABASE [ToDoList_<DRVA>] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [ToDoList_<DRVA>] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [ToDoList_<DRVA>] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [ToDoList_<DRVA>] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [ToDoList_<DRVA>] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [ToDoList_<DRVA>] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [ToDoList_<DRVA>] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [ToDoList_<DRVA>] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [ToDoList_<DRVA>] SET  MULTI_USER 
GO
ALTER DATABASE [ToDoList_<DRVA>] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [ToDoList_<DRVA>] SET DB_CHAINING OFF 
GO
ALTER DATABASE [ToDoList_<DRVA>] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [ToDoList_<DRVA>] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [ToDoList_<DRVA>] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [ToDoList_<DRVA>] SET QUERY_STORE = OFF
GO
USE [ToDoList_<DRVA>]
GO
ALTER DATABASE SCOPED CONFIGURATION SET IDENTITY_CACHE = ON;
GO
ALTER DATABASE SCOPED CONFIGURATION SET LEGACY_CARDINALITY_ESTIMATION = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET LEGACY_CARDINALITY_ESTIMATION = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET MAXDOP = 0;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET MAXDOP = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET PARAMETER_SNIFFING = ON;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET PARAMETER_SNIFFING = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET QUERY_OPTIMIZER_HOTFIXES = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET QUERY_OPTIMIZER_HOTFIXES = PRIMARY;
GO
USE [ToDoList_<DRVA>]
GO
/****** Object:  Table [dbo].[ItemStatus]    Script Date: 1/30/2018 8:52:41 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ItemStatus](
	[StatusId] [int] IDENTITY(1,1) NOT NULL,
	[Description] [nvarchar](15) NOT NULL,
 CONSTRAINT [PK_ItemStatus] PRIMARY KEY CLUSTERED 
(
	[StatusId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Priority]    Script Date: 1/30/2018 8:52:41 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Priority](
	[PriorityId] [int] IDENTITY(1,1) NOT NULL,
	[Description] [nvarchar](15) NOT NULL,
 CONSTRAINT [PK_Priority] PRIMARY KEY CLUSTERED 
(
	[PriorityId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Tags]    Script Date: 1/30/2018 8:52:41 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tags](
	[TagId] [int] IDENTITY(1,1) NOT NULL,
	[Description] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Tags] PRIMARY KEY CLUSTERED 
(
	[TagId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AssignTag]    Script Date: 1/30/2018 8:52:41 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AssignTag](
	[AssignId] [int] IDENTITY(1,1) NOT NULL,
	[ItemId] [int] NOT NULL,
	[TagId] [int] NOT NULL,
 CONSTRAINT [PK_AssignTag] PRIMARY KEY CLUSTERED 
(
	[AssignId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Item]    Script Date: 1/30/2018 8:52:41 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Item](
	[ItemId] [int] IDENTITY(1,1) NOT NULL,
	[Title] [nvarchar](50) NOT NULL,
	[Description] [nvarchar](50) NOT NULL,
	[StatusId] [int] NOT NULL,
	[PriorityId] [int] NOT NULL,
	[Archived] [bit] NOT NULL,
	[CreationDate] [date] NOT NULL,
	[ModifyDate] [date] NULL,
	[DueDate] [date] NOT NULL,
 CONSTRAINT [PK_ItemInfo] PRIMARY KEY CLUSTERED 
(
	[ItemId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  View [dbo].[vw_ToDoList]    Script Date: 1/30/2018 8:52:41 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[vw_ToDoList]
AS
	/*
	Created by: David Rodriguez Vazquez
	Description: Creates a nice view
	*/
	SELECT It.[ItemId], It.[Title], It.[Description], Ta.[Description] AS 'Tag', St.[Description] AS 'Status', Pr.[Description] AS 'Priority', REPLACE(REPLACE(It.[Archived],0,'No'),1,'Yes') AS 'Archived', It.[CreationDate], It.[ModifyDate], It.[DueDate]  FROM [Item] It
	INNER JOIN [ItemStatus] St ON St.[StatusId] = It.[StatusId]
	INNER JOIN [Priority] Pr ON Pr.[PriorityId] = It.[PriorityId]
	LEFT JOIN [AssignTag] Ass ON Ass.[ItemId] = It.[ItemId]
	LEFT JOIN [Tags] Ta ON Ta.[TagId] = Ass.[TagId]
GO
ALTER TABLE [dbo].[AssignTag]  WITH CHECK ADD  CONSTRAINT [FK_AssignTag_ItemInfo] FOREIGN KEY([ItemId])
REFERENCES [dbo].[Item] ([ItemId])
GO
ALTER TABLE [dbo].[AssignTag] CHECK CONSTRAINT [FK_AssignTag_ItemInfo]
GO
ALTER TABLE [dbo].[AssignTag]  WITH CHECK ADD  CONSTRAINT [FK_AssignTag_Tags] FOREIGN KEY([TagId])
REFERENCES [dbo].[Tags] ([TagId])
GO
ALTER TABLE [dbo].[AssignTag] CHECK CONSTRAINT [FK_AssignTag_Tags]
GO
ALTER TABLE [dbo].[Item]  WITH CHECK ADD  CONSTRAINT [FK_ItemInfo_ItemInfo] FOREIGN KEY([PriorityId])
REFERENCES [dbo].[Priority] ([PriorityId])
GO
ALTER TABLE [dbo].[Item] CHECK CONSTRAINT [FK_ItemInfo_ItemInfo]
GO
ALTER TABLE [dbo].[Item]  WITH CHECK ADD  CONSTRAINT [FK_ItemInfo_ItemStatus] FOREIGN KEY([StatusId])
REFERENCES [dbo].[ItemStatus] ([StatusId])
GO
ALTER TABLE [dbo].[Item] CHECK CONSTRAINT [FK_ItemInfo_ItemStatus]
GO
/****** Object:  StoredProcedure [dbo].[usp_AllAssignTag]    Script Date: 1/30/2018 8:52:41 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[usp_AllAssignTag]
AS
/*
Created by: David Rodriguez Vazquez
Description: Gets all assigned tags with item
*/

BEGIN TRY
	SELECT Ass.[AssignId], It.[Title] as TaskName, Ta.[Description] as TagName FROM [AssignTag] Ass
	LEFT JOIN [Item] It ON It.[ItemId] = Ass.[ItemId]
	LEFT JOIN [Tags] Ta ON Ta.[TagId] = Ass.[TagId]
END TRY

BEGIN CATCH
	EXEC usp_GetErrorInfo
END CATCH

GO
/****** Object:  StoredProcedure [dbo].[usp_AllItems]    Script Date: 1/30/2018 8:52:41 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[usp_AllItems]
AS
/*
Created by: David Rodriguez Vazquez
Description: Gets all Items
*/

BEGIN TRY
	SELECT It.[ItemId], It.[Title], It.[Description], Ta.[Description] AS 'Tag', St.[Description] AS 'Status', Pr.[Description] AS 'Priority', REPLACE(REPLACE(It.[Archived],0,'No'),1,'Yes') AS 'Archived', It.[CreationDate], It.[ModifyDate], It.[DueDate]  FROM [Item] It
	INNER JOIN [ItemStatus] St ON St.[StatusId] = It.[StatusId]
	INNER JOIN [Priority] Pr ON Pr.[PriorityId] = It.[PriorityId]
	LEFT JOIN [AssignTag] Ass ON Ass.[ItemId] = It.[ItemId]
	LEFT JOIN [Tags] Ta ON Ta.[TagId] = Ass.[TagId]
	
END TRY

BEGIN CATCH
	EXEC usp_GetErrorInfo
END CATCH

GO
/****** Object:  StoredProcedure [dbo].[usp_AllPriorities]    Script Date: 1/30/2018 8:52:41 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[usp_AllPriorities]
AS
/*
Created by: David Rodriguez Vazquez
Description: Gets all Priorities
*/

BEGIN TRY
	SELECT * FROM [Priority]
END TRY

BEGIN CATCH
	EXEC usp_GetErrorInfo
END CATCH

GO
/****** Object:  StoredProcedure [dbo].[usp_AllStatus]    Script Date: 1/30/2018 8:52:41 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[usp_AllStatus]
AS
/*
Created by: David Rodriguez Vazquez
Description: Gets all status
*/

BEGIN TRY
	SELECT * FROM [ItemStatus]
END TRY

BEGIN CATCH
	EXEC usp_GetErrorInfo
END CATCH

GO
/****** Object:  StoredProcedure [dbo].[usp_AllTags]    Script Date: 1/30/2018 8:52:41 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[usp_AllTags]
AS
/*
Created by: David Rodriguez Vazquez
Description: Gets all Tags
*/

BEGIN TRY
	SELECT * FROM [Tags]
END TRY

BEGIN CATCH
	EXEC usp_GetErrorInfo
END CATCH

GO
/****** Object:  StoredProcedure [dbo].[usp_ArchiveItem]    Script Date: 1/30/2018 8:52:41 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[usp_ArchiveItem] (
	@Id int)
AS
/*
Created by: David Rodriguez Vazquez
Description: Archives an item
*/
BEGIN TRANSACTION;

BEGIN TRY
	UPDATE [dbo].[Item]
	SET 
		[Archived] = 1,
		[ModifyDate] = GETDATE()
	WHERE [Item].[ItemId] = @Id
END TRY

BEGIN CATCH
	EXEC usp_GetErrorInfo
	IF @@TRANCOUNT > 0
	ROLLBACK TRANSACTION;
END CATCH

IF @@TRANCOUNT > 0 
	COMMIT TRANSACTION;
GO
/****** Object:  StoredProcedure [dbo].[usp_CancelItem]    Script Date: 1/30/2018 8:52:41 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[usp_CancelItem] (
	@Id int)
AS
/*
Created by: David Rodriguez Vazquez
Description: Archives an item
*/
BEGIN TRANSACTION;

BEGIN TRY
	UPDATE [dbo].[Item]
	SET 
		[StatusId] = 4,
		[ModifyDate] = GETDATE()
	WHERE [Item].[ItemId] = @Id
END TRY

BEGIN CATCH
	EXEC usp_GetErrorInfo
	IF @@TRANCOUNT > 0
	ROLLBACK TRANSACTION;
END CATCH

IF @@TRANCOUNT > 0 
	COMMIT TRANSACTION;
GO
/****** Object:  StoredProcedure [dbo].[usp_DeleteAssignTag]    Script Date: 1/30/2018 8:52:41 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[usp_DeleteAssignTag](
	@Id int)
AS
/*
Created by: David Rodriguez Vazquez
Description: Deletes an assigned tag
*/
BEGIN TRANSACTION;

BEGIN TRY
	DELETE FROM [dbo].[AssignTag]
	WHERE [AssignTag].[AssignId] = @Id
END TRY

BEGIN CATCH
	EXEC usp_GetErrorInfo
	IF @@TRANCOUNT > 0
	ROLLBACK TRANSACTION;
END CATCH

IF @@TRANCOUNT > 0 
	COMMIT TRANSACTION;
GO
/****** Object:  StoredProcedure [dbo].[usp_DeleteItem]    Script Date: 1/30/2018 8:52:41 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[usp_DeleteItem] (
	@Id int)
AS
/*
Created by: David Rodriguez Vazquez
Description: Deletes an item
*/
BEGIN TRANSACTION;

BEGIN TRY
	DELETE FROM [dbo].[Item]
	WHERE [Item].[ItemId] = @Id
END TRY

BEGIN CATCH
	EXEC usp_GetErrorInfo
	IF @@TRANCOUNT > 0
	ROLLBACK TRANSACTION;
END CATCH

IF @@TRANCOUNT > 0 
	COMMIT TRANSACTION;
GO
/****** Object:  StoredProcedure [dbo].[usp_DeletePriority]    Script Date: 1/30/2018 8:52:41 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[usp_DeletePriority](
	@Id int)
AS
/*
Created by: David Rodriguez Vazquez
Description: Deletes a Priority
*/
BEGIN TRANSACTION;

BEGIN TRY
	DELETE FROM [dbo].[Priority]
	WHERE [Priority].[PriorityId] = @Id
END TRY

BEGIN CATCH
	EXEC usp_GetErrorInfo
	IF @@TRANCOUNT > 0
	ROLLBACK TRANSACTION;
END CATCH

IF @@TRANCOUNT > 0 
	COMMIT TRANSACTION;
GO
/****** Object:  StoredProcedure [dbo].[usp_DeleteStatus]    Script Date: 1/30/2018 8:52:41 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[usp_DeleteStatus](
	@Id int)
AS
/*
Created by: David Rodriguez Vazquez
Description: Deletes a status
*/
BEGIN TRANSACTION;

BEGIN TRY
	DELETE FROM [dbo].[ItemStatus]
	WHERE [ItemStatus].[StatusId] = @Id
END TRY

BEGIN CATCH
	EXEC usp_GetErrorInfo
	IF @@TRANCOUNT > 0
	ROLLBACK TRANSACTION;
END CATCH

IF @@TRANCOUNT > 0 
	COMMIT TRANSACTION;
GO
/****** Object:  StoredProcedure [dbo].[usp_DeleteTag]    Script Date: 1/30/2018 8:52:41 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[usp_DeleteTag](
	@Id int)
AS
/*
Created by: David Rodriguez Vazquez
Description: Deletes a tag
*/
BEGIN TRANSACTION;

BEGIN TRY
	DELETE FROM [dbo].[Tags]
	WHERE [Tags].[TagId] = @Id
END TRY

BEGIN CATCH
	EXEC usp_GetErrorInfo
	IF @@TRANCOUNT > 0
	ROLLBACK TRANSACTION;
END CATCH

IF @@TRANCOUNT > 0 
	COMMIT TRANSACTION;
GO
/****** Object:  StoredProcedure [dbo].[usp_GetErrorInfo]    Script Date: 1/30/2018 8:52:41 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[usp_GetErrorInfo]  
AS  
SELECT  
    ERROR_NUMBER() AS ErrorNumber  
    ,ERROR_SEVERITY() AS ErrorSeverity  
    ,ERROR_STATE() AS ErrorState  
    ,ERROR_PROCEDURE() AS ErrorProcedure  
    ,ERROR_LINE() AS ErrorLine  
    ,ERROR_MESSAGE() AS ErrorMessage;  
GO
/****** Object:  StoredProcedure [dbo].[usp_InsertNewAssignTag]    Script Date: 1/30/2018 8:52:41 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[usp_InsertNewAssignTag](
	@TagId int,
	@ItemId int)
AS
/*
Created by: David Rodriguez Vazquez
Description: Assigns a tag
*/
BEGIN TRANSACTION;

BEGIN TRY
	INSERT INTO [dbo].[AssignTag]([ItemId], [TagId]) VALUES
	(@ItemId, @TagId)
END TRY

BEGIN CATCH
	EXEC usp_GetErrorInfo
	IF @@TRANCOUNT > 0
	ROLLBACK TRANSACTION;
END CATCH

IF @@TRANCOUNT > 0 
	COMMIT TRANSACTION;
GO
/****** Object:  StoredProcedure [dbo].[usp_InsertNewItem]    Script Date: 1/30/2018 8:52:41 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[usp_InsertNewItem] (
	@Title nvarchar(50),
	@Description nvarchar(50),
	@Status int,
	@Priority int,
	@DueDate Date)
AS
/*
Created by: David Rodriguez Vazquez
Description: Adds a new item
*/
BEGIN TRANSACTION;

BEGIN TRY
	INSERT INTO [dbo].[Item] ([Title],[Description],[StatusId],[PriorityId],[Archived],[CreationDate],[DueDate]) VALUES
	(@Title, @Description, @Status, @Priority, 0, GETDATE(), @DueDate)
END TRY

BEGIN CATCH
	EXEC usp_GetErrorInfo
	IF @@TRANCOUNT > 0
	ROLLBACK TRANSACTION;
END CATCH

IF @@TRANCOUNT > 0 
	COMMIT TRANSACTION;
GO
/****** Object:  StoredProcedure [dbo].[usp_InsertNewPriority]    Script Date: 1/30/2018 8:52:41 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[usp_InsertNewPriority] (
	@Description nvarchar(50))
AS
/*
Created by: David Rodriguez Vazquez
Description: Adds a new priority
*/
BEGIN TRANSACTION;

BEGIN TRY
	INSERT INTO [dbo].[Priority] ([Description]) VALUES
	(@Description)
END TRY

BEGIN CATCH
	EXEC usp_GetErrorInfo
	IF @@TRANCOUNT > 0
	ROLLBACK TRANSACTION;
END CATCH

IF @@TRANCOUNT > 0 
	COMMIT TRANSACTION;
GO
/****** Object:  StoredProcedure [dbo].[usp_InsertNewStatus]    Script Date: 1/30/2018 8:52:41 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[usp_InsertNewStatus] (
	@Description nvarchar(50))
AS
/*
Created by: David Rodriguez Vazquez
Description: Adds a new status
*/
BEGIN TRANSACTION;

BEGIN TRY
	INSERT INTO [dbo].[ItemStatus] ([Description]) VALUES
	(@Description)
END TRY

BEGIN CATCH
	EXEC usp_GetErrorInfo
	IF @@TRANCOUNT > 0
	ROLLBACK TRANSACTION;
END CATCH

IF @@TRANCOUNT > 0 
	COMMIT TRANSACTION;
GO
/****** Object:  StoredProcedure [dbo].[usp_InsertNewTag]    Script Date: 1/30/2018 8:52:41 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[usp_InsertNewTag] (
	@Description nvarchar(50))
AS
/*
Created by: David Rodriguez Vazquez
Description: Adds a new tag
*/
BEGIN TRANSACTION;

BEGIN TRY
	INSERT INTO [dbo].[Tags] ([Description]) VALUES
	(@Description)
END TRY

BEGIN CATCH
	EXEC usp_GetErrorInfo
	IF @@TRANCOUNT > 0
	ROLLBACK TRANSACTION;
END CATCH

IF @@TRANCOUNT > 0 
	COMMIT TRANSACTION;
GO
/****** Object:  StoredProcedure [dbo].[usp_SearchByRangeOfDates]    Script Date: 1/30/2018 8:52:41 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[usp_SearchByRangeOfDates](
	@MinDate Date = NULL,
	@MaxDate Date = NULL,
	@ShowArchived bit = 0)
AS
/*
Created by: David Rodriguez Vazquez
Description: Searches by range of due dates
*/

BEGIN TRY
	SELECT It.[ItemId],It.Title, It.[Description], Ta.[Description] AS 'Tag', St.[Description] AS 'Status', Pr.[Description] AS 'Priority', It.[CreationDate], It.[ModifyDate], It.[DueDate]  FROM [Item] It
	LEFT JOIN [ItemStatus] St ON St.[StatusId] = It.[StatusId]
	LEFT JOIN [Priority] Pr ON Pr.[PriorityId] = It.[PriorityId]
	LEFT JOIN [AssignTag] Ass ON Ass.[ItemId] = It.[ItemId]
	LEFT JOIN [Tags] Ta ON Ta.[TagId] = Ass.[TagId]
	WHERE It.[DueDate] >= @MinDate AND It.[DueDate] <= @MaxDate AND It.Archived <= @ShowArchived
END TRY

BEGIN CATCH
	EXEC usp_GetErrorInfo
END CATCH

GO
/****** Object:  StoredProcedure [dbo].[usp_SearchByStatus]    Script Date: 1/30/2018 8:52:41 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[usp_SearchByStatus](
	@Status nvarchar(50) = NULL,
	@ShowArchived bit = 0)
AS
/*
Created by: David Rodriguez Vazquez
Description: Searches by status
*/

BEGIN TRY
	SELECT It.[ItemId], It.[Title], It.[Description], Ta.[Description] AS 'Tag', St.[Description] AS 'Status', Pr.[Description] AS 'Priority', It.[CreationDate], It.[ModifyDate], It.[DueDate]  FROM [Item] It
	INNER JOIN [ItemStatus] St ON St.[StatusId] = It.[StatusId]
	INNER JOIN [Priority] Pr ON Pr.[PriorityId] = It.[PriorityId]
	LEFT JOIN [AssignTag] Ass ON Ass.[ItemId] = It.[ItemId]
	LEFT JOIN [Tags] Ta ON Ta.[TagId] = Ass.[TagId]
	WHERE St.[Description] LIKE '%' + @Status + '%' AND It.[Archived] <= @ShowArchived
END TRY

BEGIN CATCH
	EXEC usp_GetErrorInfo
END CATCH

GO
/****** Object:  StoredProcedure [dbo].[usp_SearchByTag]    Script Date: 1/30/2018 8:52:41 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[usp_SearchByTag](
	@Tag nvarchar(50) = NULL,
	@ShowArchived bit = 0)
AS
/*
Created by: David Rodriguez Vazquez
Description: Searches by Tag
*/

BEGIN TRY
	SELECT It.[ItemId], It.[Title], It.[Description], Ta.[Description] AS 'Tag', St.[Description] AS 'Status', Pr.[Description] AS 'Priority', It.[CreationDate], It.[ModifyDate], It.[DueDate]  FROM [Item] It
	INNER JOIN [ItemStatus] St ON St.[StatusId] = It.[StatusId]
	INNER JOIN [Priority] Pr ON Pr.[PriorityId] = It.[PriorityId]
	LEFT JOIN [AssignTag] Ass ON Ass.[ItemId] = It.[ItemId]
	LEFT JOIN [Tags] Ta ON Ta.[TagId] = Ass.[TagId]
	WHERE Ta.[Description] LIKE '%' + @Tag + '%' AND It.[Archived] <= @ShowArchived
END TRY

BEGIN CATCH
	EXEC usp_GetErrorInfo
END CATCH

GO
/****** Object:  StoredProcedure [dbo].[usp_SearchByTitle]    Script Date: 1/30/2018 8:52:41 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[usp_SearchByTitle](
	@Title nvarchar(50) = NULL,
	@ShowArchived bit = 0)
AS
/*
Created by: David Rodriguez Vazquez
Description: Searches by title
*/

BEGIN TRY
	SELECT It.[ItemId], It.[Title], It.[Description], Ta.[Description] AS 'Tag', St.[Description] AS 'Status', Pr.[Description] AS 'Priority', It.[CreationDate], It.[ModifyDate], It.[DueDate]  FROM [Item] It
	INNER JOIN [ItemStatus] St ON St.[StatusId] = It.[StatusId]
	INNER JOIN [Priority] Pr ON Pr.[PriorityId] = It.[PriorityId]
	LEFT JOIN [AssignTag] Ass ON Ass.[ItemId] = It.[ItemId]
	LEFT JOIN [Tags] Ta ON Ta.[TagId] = Ass.[TagId]
	WHERE It.[Title] LIKE '%' + @Title + '%' AND It.[Archived] <= @ShowArchived
END TRY

BEGIN CATCH
	EXEC usp_GetErrorInfo
END CATCH

GO
/****** Object:  StoredProcedure [dbo].[usp_UpdateItem]    Script Date: 1/30/2018 8:52:41 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[usp_UpdateItem] (
	@Id int,
	@Title nvarchar(50) = [Title],
	@Description nvarchar(50) = [Description],
	@Status int = [StatusId],
	@Priority int = [PriorityId],
	@Archived bit = 0,
	@DueDate Date = [DueDate])
AS
/*
Created by: David Rodriguez Vazquez
Description: Updates an item
*/
BEGIN TRANSACTION;

BEGIN TRY
	UPDATE [dbo].[Item]
	SET [Title] = @Title,
		[Description] = @Description,
		[StatusId] = @Status,
		[PriorityId] = @Priority,
		[Archived] = @Archived,
		[ModifyDate] = GETDATE(),
		[DueDate] = @DueDate
	WHERE [Item].[ItemId] = @Id
END TRY

BEGIN CATCH
	EXEC usp_GetErrorInfo
	IF @@TRANCOUNT > 0
	ROLLBACK TRANSACTION;
END CATCH

IF @@TRANCOUNT > 0 
	COMMIT TRANSACTION;
GO
/****** Object:  StoredProcedure [dbo].[usp_UpdatePriority]    Script Date: 1/30/2018 8:52:41 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[usp_UpdatePriority] (
	@Id int,
	@Description nvarchar(50) = [Description])
AS
/*
Created by: David Rodriguez Vazquez
Description: Updates a priority
*/
BEGIN TRANSACTION;

BEGIN TRY
	UPDATE [dbo].[Priority]
	SET [Description] = @Description
	WHERE [Priority].[PriorityId] = @Id
END TRY

BEGIN CATCH
	EXEC usp_GetErrorInfo
	IF @@TRANCOUNT > 0
	ROLLBACK TRANSACTION;
END CATCH

IF @@TRANCOUNT > 0 
	COMMIT TRANSACTION;
GO
/****** Object:  StoredProcedure [dbo].[usp_UpdateStatus]    Script Date: 1/30/2018 8:52:41 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[usp_UpdateStatus] (
	@Id int,
	@Description nvarchar(50) = [Description])
AS
/*
Created by: David Rodriguez Vazquez
Description: Updates a status
*/
BEGIN TRANSACTION;

BEGIN TRY
	UPDATE [dbo].[ItemStatus]
	SET [Description] = @Description
	WHERE [ItemStatus].[StatusId] = @Id
END TRY

BEGIN CATCH
	EXEC usp_GetErrorInfo
	IF @@TRANCOUNT > 0
	ROLLBACK TRANSACTION;
END CATCH

IF @@TRANCOUNT > 0 
	COMMIT TRANSACTION;
GO
/****** Object:  StoredProcedure [dbo].[usp_UpdateTag]    Script Date: 1/30/2018 8:52:41 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[usp_UpdateTag](
	@Id int,
	@Description nvarchar(50) = [Description])
AS
/*
Created by: David Rodriguez Vazquez
Description: Updates a tag
*/
BEGIN TRANSACTION;

BEGIN TRY
	UPDATE [dbo].[Tags]
	SET [Description] = @Description
	WHERE [Tags].[TagId] = @Id
END TRY

BEGIN CATCH
	EXEC usp_GetErrorInfo
	IF @@TRANCOUNT > 0
	ROLLBACK TRANSACTION;
END CATCH

IF @@TRANCOUNT > 0 
	COMMIT TRANSACTION;
GO
USE [master]
GO
ALTER DATABASE [ToDoList_<DRVA>] SET  READ_WRITE 
GO
