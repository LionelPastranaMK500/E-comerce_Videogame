/*
DROP DATABASE ecommerce_videogame;
GO
*/

CREATE DATABASE ecommerce_videogame;
GO

USE ecommerce_videogame;
GO

-- 1. Roles
CREATE TABLE [dbo].[Roles] (
    [RoleId] INT IDENTITY(1,1) PRIMARY KEY,
    [Name]  NVARCHAR(50) NOT NULL UNIQUE
);
GO

-- 2. Users
CREATE TABLE [dbo].[Users] (
    [UserId]       INT IDENTITY(1,1) PRIMARY KEY,
    [Email]        NVARCHAR(255) NOT NULL UNIQUE,
    [PasswordHash] NVARCHAR(255) NOT NULL,
    [Name]         NVARCHAR(100) NOT NULL,
    [CreatedAt]    DATETIME2 NOT NULL DEFAULT SYSDATETIME()
);
GO

-- 3. User–Role (N–N)
CREATE TABLE [dbo].[UserRoles] (
    [UserId]     INT NOT NULL,
    [RoleId]     INT NOT NULL,
    [AssignedAt] DATETIME2 NOT NULL DEFAULT SYSDATETIME(),
    CONSTRAINT PK_UserRoles PRIMARY KEY ([UserId],[RoleId]),
    CONSTRAINT FK_UserRoles_User FOREIGN KEY ([UserId]) REFERENCES [dbo].[Users]([UserId]) ON DELETE CASCADE,
    CONSTRAINT FK_UserRoles_Role FOREIGN KEY ([RoleId]) REFERENCES [dbo].[Roles]([RoleId]) ON DELETE CASCADE
);
GO

-- 4. Categories
CREATE TABLE [dbo].[Categories] (
    [CategoryId]  INT IDENTITY(1,1) PRIMARY KEY,
    [Name]        NVARCHAR(100) NOT NULL UNIQUE,
    [Description] NVARCHAR(MAX)  NULL
);
GO

-- 5. Publishers
CREATE TABLE [dbo].[Publishers] (
    [PublisherId] INT IDENTITY(1,1) PRIMARY KEY,
    [Name]        NVARCHAR(255) NOT NULL UNIQUE,
    [Website]     NVARCHAR(255) NULL
);
GO

-- 6. Genres
CREATE TABLE [dbo].[Genres] (
    [GenreId] INT IDENTITY(1,1) PRIMARY KEY,
    [Name]    NVARCHAR(100) NOT NULL UNIQUE
);
GO

CREATE TABLE [dbo].[Games] (
    [GameId]      INT IDENTITY(1,1) PRIMARY KEY,
    [Title]       NVARCHAR(255) NOT NULL,
    [Description] NVARCHAR(MAX)  NULL,
    [precio]      FLOAT         NULL,
    [ReleaseDate] DATE           NULL,
    [CategoryId]  INT            NULL,
    [PublisherId] INT            NULL,
    [GenreId]     INT            NULL,
    [CreatedAt]   DATETIME2      NOT NULL DEFAULT SYSDATETIME(),
    CONSTRAINT FK_Games_Genres FOREIGN KEY (GenreId) REFERENCES Genres(GenreId),
    CONSTRAINT FK_Games_Category  FOREIGN KEY ([CategoryId]) REFERENCES [dbo].[Categories]([CategoryId]) ON DELETE SET NULL,
    CONSTRAINT FK_Games_Publisher FOREIGN KEY ([PublisherId]) REFERENCES [dbo].[Publishers]([PublisherId]) ON DELETE SET NULL
);
GO
CREATE INDEX IX_Games_Title     ON [dbo].[Games]([Title]);
GO
CREATE INDEX IX_Games_Category  ON [dbo].[Games]([CategoryId]);
GO

-- 8. Editions
CREATE TABLE [dbo].[Editions] (
    [EditionId] INT IDENTITY(1,1) PRIMARY KEY,
    [GameId]    INT NOT NULL,
    [Name]      NVARCHAR(100) NOT NULL,
    [BasePrice] DECIMAL(10,2) NOT NULL,
    CONSTRAINT FK_Editions_Game FOREIGN KEY ([GameId]) REFERENCES [dbo].[Games]([GameId]) ON DELETE CASCADE
);
GO

-- 9. Platforms
CREATE TABLE [dbo].[Platforms] (
    [PlatformId] INT IDENTITY(1,1) PRIMARY KEY,
    [Name]       NVARCHAR(100) NOT NULL UNIQUE
);
GO

-- 10. Variants
CREATE TABLE [dbo].[Variants] (
    [VariantId]       INT IDENTITY(1,1) PRIMARY KEY,
    [EditionId]       INT NOT NULL,
    [PlatformId]      INT NOT NULL,
    [StockQuantity]   INT NOT NULL DEFAULT(0),
    [PriceAdjustment] DECIMAL(10,2) NOT NULL DEFAULT(0.00),
    CONSTRAINT FK_Variants_Edition  FOREIGN KEY ([EditionId])  REFERENCES [dbo].[Editions]([EditionId])  ON DELETE CASCADE,
    CONSTRAINT FK_Variants_Platform FOREIGN KEY ([PlatformId]) REFERENCES [dbo].[Platforms]([PlatformId]) ON DELETE CASCADE
);
GO
