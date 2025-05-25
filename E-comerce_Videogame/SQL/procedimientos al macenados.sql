-- 1. Roles
CREATE OR ALTER PROCEDURE dbo.sp_getById_Roles
    @RoleId INT
AS
BEGIN
    SELECT * FROM dbo.Roles WHERE RoleId = @RoleId;
END;
GO

CREATE OR ALTER PROCEDURE dbo.sp_getAll_Roles
AS
BEGIN
    SELECT * FROM dbo.Roles;
END;
GO

CREATE OR ALTER PROCEDURE dbo.sp_create_Roles
    @Name NVARCHAR(50)
AS
BEGIN
    INSERT INTO dbo.Roles (Name)
    VALUES (@Name);
    SELECT SCOPE_IDENTITY() AS NewRoleId;
END;
GO

CREATE OR ALTER PROCEDURE dbo.sp_update_Roles
    @RoleId INT,
    @Name NVARCHAR(50)
AS
BEGIN
    UPDATE dbo.Roles
    SET Name = @Name
    WHERE RoleId = @RoleId;
END;
GO

-- Modificar sp_delete_Roles para eliminar UserRoles
CREATE OR ALTER PROCEDURE dbo.sp_delete_Roles
    @RoleId INT
AS
BEGIN
    DELETE FROM dbo.UserRoles WHERE RoleId = @RoleId;
    DELETE FROM dbo.Roles WHERE RoleId = @RoleId;
END;
GO
-- 2. Users
CREATE OR ALTER PROCEDURE dbo.sp_getById_Users
    @UserId INT
AS
BEGIN
    SELECT * FROM dbo.Users WHERE UserId = @UserId;
END;
GO

CREATE OR ALTER PROCEDURE dbo.sp_getAll_Users
AS
BEGIN
    SELECT * FROM dbo.Users;
END;
GO

CREATE OR ALTER PROCEDURE dbo.sp_create_Users
    @Email NVARCHAR(255),
    @PasswordHash NVARCHAR(255),
    @Name NVARCHAR(100)
AS
BEGIN
    INSERT INTO dbo.Users (Email, PasswordHash, Name)
    VALUES (@Email, @PasswordHash, @Name);
    SELECT SCOPE_IDENTITY() AS NewUserId;
END;
GO

CREATE OR ALTER PROCEDURE dbo.sp_update_Users
    @UserId INT,
    @Email NVARCHAR(255),
    @PasswordHash NVARCHAR(255),
    @Name NVARCHAR(100)
AS
BEGIN
    UPDATE dbo.Users
    SET Email = @Email,
        PasswordHash = @PasswordHash,
        Name = @Name
    WHERE UserId = @UserId;
END;
GO

-- Modificar sp_delete_Users para eliminar UserRoles
CREATE OR ALTER PROCEDURE dbo.sp_delete_Users
    @UserId INT
AS
BEGIN
    DELETE FROM dbo.UserRoles WHERE UserId = @UserId;
    DELETE FROM dbo.Users WHERE UserId = @UserId;
END;
GO

-- Procedimiento para obtener un usuario por email
CREATE OR ALTER PROCEDURE sp_getByEmail_Users
    @Email NVARCHAR(255)
AS
BEGIN
    SET NOCOUNT ON;

    SELECT UserId, Email, PasswordHash, Name, CreatedAt
    FROM Users
    WHERE Email = @Email;
END;

-- 3. UserRoles
CREATE OR ALTER PROCEDURE dbo.sp_getById_UserRoles
    @UserId INT,
    @RoleId INT
AS
BEGIN
    SELECT * FROM dbo.UserRoles
    WHERE UserId = @UserId
      AND RoleId = @RoleId;
END;
GO

CREATE OR ALTER PROCEDURE sp_getAll_UserRoles
AS
BEGIN
    SET NOCOUNT ON;

    SELECT UserId, RoleId
    FROM UserRoles;
END;
go

CREATE OR ALTER PROCEDURE dbo.sp_create_UserRoles
    @UserId INT,
    @RoleId INT
AS
BEGIN
    INSERT INTO dbo.UserRoles (UserId, RoleId)
    VALUES (@UserId, @RoleId);
END;
GO

CREATE OR ALTER PROCEDURE dbo.sp_update_UserRoles
    @OldUserId INT,
    @OldRoleId INT,
    @NewUserId INT,
    @NewRoleId INT
AS
BEGIN
    UPDATE dbo.UserRoles
    SET UserId = @NewUserId,
        RoleId = @NewRoleId
    WHERE UserId = @OldUserId
      AND RoleId = @OldRoleId;
END;
GO

CREATE OR ALTER PROCEDURE dbo.sp_delete_UserRoles
    @UserId INT,
    @RoleId INT
AS
BEGIN
    DELETE FROM dbo.UserRoles
    WHERE UserId = @UserId
      AND RoleId = @RoleId;
END;
GO

-- 4. Categories
CREATE OR ALTER PROCEDURE dbo.sp_getById_Categories
    @CategoryId INT
AS
BEGIN
    SELECT * FROM dbo.Categories WHERE CategoryId = @CategoryId;
END;
GO

CREATE OR ALTER PROCEDURE dbo.sp_getAll_Categories
AS
BEGIN
    SELECT * FROM dbo.Categories;
END;
GO

CREATE OR ALTER PROCEDURE dbo.sp_create_Categories
    @Name NVARCHAR(100),
    @Description NVARCHAR(MAX) = NULL
AS
BEGIN
    INSERT INTO dbo.Categories (Name, Description)
    VALUES (@Name, @Description);
    SELECT SCOPE_IDENTITY() AS NewCategoryId;
END;
GO

CREATE OR ALTER PROCEDURE dbo.sp_update_Categories
    @CategoryId INT,
    @Name NVARCHAR(100),
    @Description NVARCHAR(MAX) = NULL
AS
BEGIN
    UPDATE dbo.Categories
    SET Name = @Name,
        Description = @Description
    WHERE CategoryId = @CategoryId;
END;
GO

CREATE OR ALTER PROCEDURE dbo.sp_delete_Categories
    @CategoryId INT
AS
BEGIN
    DELETE FROM dbo.Categories
    WHERE CategoryId = @CategoryId;
END;
GO

-- 5. Publishers
CREATE OR ALTER PROCEDURE dbo.sp_getById_Publishers
    @PublisherId INT
AS
BEGIN
    SELECT * FROM dbo.Publishers WHERE PublisherId = @PublisherId;
END;
GO

CREATE OR ALTER PROCEDURE dbo.sp_getAll_Publishers
AS
BEGIN
    SELECT * FROM dbo.Publishers;
END;
GO

CREATE OR ALTER PROCEDURE dbo.sp_create_Publishers
    @Name NVARCHAR(255),
    @Website NVARCHAR(255) = NULL
AS
BEGIN
    INSERT INTO dbo.Publishers (Name, Website)
    VALUES (@Name, @Website);
    SELECT SCOPE_IDENTITY() AS NewPublisherId;
END;
GO

CREATE OR ALTER PROCEDURE dbo.sp_update_Publishers
    @PublisherId INT,
    @Name NVARCHAR(255),
    @Website NVARCHAR(255) = NULL
AS
BEGIN
    UPDATE dbo.Publishers
    SET Name = @Name,
        Website = @Website
    WHERE PublisherId = @PublisherId;
END;
GO

CREATE OR ALTER PROCEDURE dbo.sp_delete_Publishers
    @PublisherId INT
AS
BEGIN
    DELETE FROM dbo.Publishers
    WHERE PublisherId = @PublisherId;
END;
GO

-- 6. Genres
CREATE OR ALTER PROCEDURE dbo.sp_getById_Genres
    @GenreId INT
AS
BEGIN
    SELECT * FROM dbo.Genres WHERE GenreId = @GenreId;
END;
GO

CREATE OR ALTER PROCEDURE dbo.sp_getAll_Genres
AS
BEGIN
    SELECT * FROM dbo.Genres;
END;
GO

CREATE OR ALTER PROCEDURE dbo.sp_create_Genres
    @Name NVARCHAR(100)
AS
BEGIN
    INSERT INTO dbo.Genres (Name)
    VALUES (@Name);
    SELECT SCOPE_IDENTITY() AS NewGenreId;
END;
GO

CREATE OR ALTER PROCEDURE dbo.sp_update_Genres
    @GenreId INT,
    @Name NVARCHAR(100)
AS
BEGIN
    UPDATE dbo.Genres
    SET Name = @Name
    WHERE GenreId = @GenreId;
END;
GO

CREATE OR ALTER PROCEDURE dbo.sp_delete_Genres
    @GenreId INT
AS
BEGIN
    DELETE FROM dbo.Genres
    WHERE GenreId = @GenreId;
END;
GO

-- games
CREATE OR ALTER PROCEDURE dbo.sp_getAll_Games
AS
BEGIN
    SELECT 
        GameId,
        Title,
        Description,
        precio,
        ReleaseDate
    FROM Games;
END;
GO

CREATE OR ALTER PROCEDURE dbo.sp_getById_Games
    @GameId INT
AS
BEGIN
    SELECT 
        g.GameId,
        g.Title,
        g.Description,
        g.precio,
        g.ReleaseDate,
        g.CategoryId,
        c.Name AS CategoryName,
        g.PublisherId,
        p.Name AS PublisherName,
        g.GenreId,
        ge.Name AS GenreName,
        g.CreatedAt
    FROM Games g
    LEFT JOIN Categories c ON g.CategoryId = c.CategoryId
    LEFT JOIN Publishers p ON g.PublisherId = p.PublisherId
    LEFT JOIN Genres ge ON g.GenreId = ge.GenreId
    WHERE g.GameId = @GameId;
END;
GO

CREATE OR ALTER PROCEDURE dbo.sp_create_Games
    @Title NVARCHAR(255),
    @Description NVARCHAR(MAX) = NULL,
    @ReleaseDate DATE = NULL,
    @CategoryId INT = NULL,
    @PublisherId INT = NULL,
    @GenreId INT = NULL,
    @Precio FLOAT = NULL
AS
BEGIN
    INSERT INTO Games (Title, Description, precio, ReleaseDate, CategoryId, PublisherId, GenreId, CreatedAt)
    VALUES (@Title, @Description, @Precio, @ReleaseDate, @CategoryId, @PublisherId, @GenreId, SYSDATETIME());
    SELECT SCOPE_IDENTITY() AS NewGameId;
END;
GO

CREATE OR ALTER PROCEDURE dbo.sp_update_Games
    @GameId INT,
    @Title NVARCHAR(255),
    @Description NVARCHAR(MAX) = NULL,
    @ReleaseDate DATE = NULL,
    @CategoryId INT = NULL,
    @PublisherId INT = NULL,
    @GenreId INT = NULL,
    @Precio FLOAT = NULL
AS
BEGIN
    UPDATE Games
    SET 
        Title = @Title,
        Description = @Description,
        precio = @Precio,
        ReleaseDate = @ReleaseDate,
        CategoryId = @CategoryId,
        PublisherId = @PublisherId,
        GenreId = @GenreId
    WHERE GameId = @GameId;
END;
GO

CREATE OR ALTER PROCEDURE dbo.sp_delete_Games
    @GameId INT
AS
BEGIN
    DELETE FROM Games
    WHERE GameId = @GameId;
END;
GO

CREATE OR ALTER PROCEDURE dbo.sp_getAll_Games_Detailed
AS
BEGIN
    SELECT 
        g.GameId,
        g.Title,
        g.Description,
        g.precio,
        g.ReleaseDate,
        c.Name AS CategoryName,
        p.Name AS PublisherName,
        ge.Name AS GenreName,
        g.CreatedAt
    FROM Games g
    LEFT JOIN Categories c ON g.CategoryId = c.CategoryId
    LEFT JOIN Publishers p ON g.PublisherId = p.PublisherId
    LEFT JOIN Genres ge ON g.GenreId = ge.GenreId;
END;
GO

-- 8. Editions
CREATE OR ALTER PROCEDURE dbo.sp_getById_Editions
    @EditionId INT
AS
BEGIN
    SELECT * FROM dbo.Editions WHERE EditionId = @EditionId;
END;
GO

CREATE OR ALTER PROCEDURE dbo.sp_getAll_Editions
AS
BEGIN
    SELECT * FROM dbo.Editions;
END;
GO

CREATE OR ALTER PROCEDURE dbo.sp_create_Editions
    @GameId INT,
    @Name NVARCHAR(100),
    @BasePrice DECIMAL(10,2)
AS
BEGIN
    INSERT INTO dbo.Editions (GameId, Name, BasePrice)
    VALUES (@GameId, @Name, @BasePrice);
    SELECT SCOPE_IDENTITY() AS NewEditionId;
END;
GO

CREATE OR ALTER PROCEDURE dbo.sp_update_Editions
    @EditionId INT,
    @GameId INT,
    @Name NVARCHAR(100),
    @BasePrice DECIMAL(10,2)
AS
BEGIN
    UPDATE dbo.Editions
    SET GameId    = @GameId,
        Name      = @Name,
        BasePrice = @BasePrice
    WHERE EditionId = @EditionId;
END;
GO

CREATE OR ALTER PROCEDURE dbo.sp_delete_Editions
    @EditionId INT
AS
BEGIN
    DELETE FROM dbo.Editions WHERE EditionId = @EditionId;
END;
GO

-- 9. Platforms
CREATE OR ALTER PROCEDURE dbo.sp_getById_Platforms
    @PlatformId INT
AS
BEGIN
    SELECT * FROM dbo.Platforms WHERE PlatformId = @PlatformId;
END;
GO

CREATE OR ALTER PROCEDURE dbo.sp_getAll_Platforms
AS
BEGIN
    SELECT * FROM dbo.Platforms;
END;
GO

CREATE OR ALTER PROCEDURE dbo.sp_create_Platforms
    @Name NVARCHAR(100)
AS
BEGIN
    INSERT INTO dbo.Platforms (Name)
    VALUES (@Name);
    SELECT SCOPE_IDENTITY() AS NewPlatformId;
END;
GO

CREATE OR ALTER PROCEDURE dbo.sp_update_Platforms
    @PlatformId INT,
    @Name NVARCHAR(100)
AS
BEGIN
    UPDATE dbo.Platforms
    SET Name = @Name
    WHERE PlatformId = @PlatformId;
END;
GO

CREATE OR ALTER PROCEDURE dbo.sp_delete_Platforms
    @PlatformId INT
AS
BEGIN
    DELETE FROM dbo.Platforms WHERE PlatformId = @PlatformId;
END;
GO

-- 10. Variants
CREATE OR ALTER PROCEDURE dbo.sp_getById_Variants
    @VariantId INT
AS
BEGIN
    SELECT * FROM dbo.Variants WHERE VariantId = @VariantId;
END;
GO

CREATE OR ALTER PROCEDURE dbo.sp_getAll_Variants
AS
BEGIN
    SELECT * FROM dbo.Variants;
END;
GO

CREATE OR ALTER PROCEDURE dbo.sp_create_Variants
    @EditionId INT,
    @PlatformId INT,
    @StockQuantity INT,
    @PriceAdjustment DECIMAL(10,2)
AS
BEGIN
    INSERT INTO dbo.Variants (EditionId, PlatformId, StockQuantity, PriceAdjustment)
    VALUES (@EditionId, @PlatformId, @StockQuantity, @PriceAdjustment);
    SELECT SCOPE_IDENTITY() AS NewVariantId;
END;
GO

CREATE OR ALTER PROCEDURE dbo.sp_update_Variants
    @VariantId INT,
    @EditionId INT,
    @PlatformId INT,
    @StockQuantity INT,
    @PriceAdjustment DECIMAL(10,2)
AS
BEGIN
    UPDATE dbo.Variants
    SET EditionId       = @EditionId,
        PlatformId      = @PlatformId,
        StockQuantity   = @StockQuantity,
        PriceAdjustment = @PriceAdjustment
    WHERE VariantId = @VariantId;
END;
GO

CREATE OR ALTER PROCEDURE dbo.sp_delete_Variants
    @VariantId INT
AS
BEGIN
    DELETE FROM dbo.Variants WHERE VariantId = @VariantId;
END;
GO

CREATE OR ALTER PROCEDURE sp_getAll_UserRoles
AS
BEGIN
    SET NOCOUNT ON;

    SELECT ur.UserId, ur.RoleId, ur.AssignedAt, u.Email, r.Name AS RoleName
    FROM UserRoles ur
    INNER JOIN Users u ON ur.UserId = u.UserId
    INNER JOIN Roles r ON ur.RoleId = r.RoleId;
END;

CREATE OR ALTER PROCEDURE sp_getById_UserRoles
    @UserId INT,
    @RoleId INT
AS
BEGIN
    SET NOCOUNT ON;
    SELECT UserId, RoleId, AssignedAt
    FROM UserRoles
    WHERE UserId = @UserId AND RoleId = @RoleId;
END;


EXEC sp_getAll_UserRoles;