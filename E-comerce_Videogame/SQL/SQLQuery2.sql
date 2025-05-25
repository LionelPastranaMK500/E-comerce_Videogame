-- 1. Roles
EXEC dbo.sp_create_Roles @Name = 'Admin';
EXEC dbo.sp_create_Roles @Name = 'User';


-- Categorías existentes
EXEC dbo.sp_create_Categories @Name = 'Action', @Description = 'Action-packed video games';
EXEC dbo.sp_create_Categories @Name = 'RPG', @Description = 'Role-playing games';

-- Nuevas categorías
EXEC dbo.sp_create_Categories @Name = 'Strategy', @Description = 'Strategic and tactical games';
EXEC dbo.sp_create_Categories @Name = 'Sports', @Description = 'Sports simulation games';
EXEC dbo.sp_create_Categories @Name = 'Racing', @Description = 'High-speed racing games';
EXEC dbo.sp_create_Categories @Name = 'Simulation', @Description = 'Life and world simulation games';
EXEC dbo.sp_create_Categories @Name = 'Fighting', @Description = 'Combat-based fighting games';

-- Publishers existentes
EXEC dbo.sp_create_Publishers @Name = 'Electronic Arts', @Website = 'https://www.ea.com';
EXEC dbo.sp_create_Publishers @Name = 'Ubisoft', @Website = 'https://www.ubisoft.com';

-- Nuevos publishers
EXEC dbo.sp_create_Publishers @Name = 'Nintendo', @Website = 'https://www.nintendo.com';
EXEC dbo.sp_create_Publishers @Name = 'Activision', @Website = 'https://www.activision.com';
EXEC dbo.sp_create_Publishers @Name = 'Square Enix', @Website = 'https://www.square-enix.com';
EXEC dbo.sp_create_Publishers @Name = 'Capcom', @Website = 'https://www.capcom.com';
EXEC dbo.sp_create_Publishers @Name = 'Rockstar Games', @Website = 'https://www.rockstargames.com';

-- Géneros existentes
EXEC dbo.sp_create_Genres @Name = 'Adventure';
EXEC dbo.sp_create_Genres @Name = 'Shooter';

-- Nuevos géneros
EXEC dbo.sp_create_Genres @Name = 'Strategy';
EXEC dbo.sp_create_Genres @Name = 'Sports';
EXEC dbo.sp_create_Genres @Name = 'Racing';
EXEC dbo.sp_create_Genres @Name = 'Puzzle';
EXEC dbo.sp_create_Genres @Name = 'Platformer';

-- Juegos existentes
EXEC dbo.sp_create_Games @Title = 'Cyberpunk 2077', @Description = 'Open-world action RPG', @ReleaseDate = '2020-12-10', @CategoryId = 1, @PublisherId = 1, @GenreId = 1, @Precio = 59.99;
EXEC dbo.sp_create_Games @Title = 'Assassin''s Creed Valhalla', @Description = 'Viking-themed action adventure', @ReleaseDate = '2020-11-10', @CategoryId = 1, @PublisherId = 2, @GenreId = 1, @Precio = 49.99;

-- Nuevos juegos (hasta 30 en total)
EXEC dbo.sp_create_Games @Title = 'The Legend of Zelda: Breath of the Wild', @Description = 'Open-world adventure', @ReleaseDate = '2017-03-03', @CategoryId = 1, @PublisherId = 3, @GenreId = 1, @Precio = 59.99;
EXEC dbo.sp_create_Games @Title = 'Call of Duty: Modern Warfare', @Description = 'First-person shooter', @ReleaseDate = '2019-10-25', @CategoryId = 1, @PublisherId = 4, @GenreId = 2, @Precio = 69.99;
EXEC dbo.sp_create_Games @Title = 'Final Fantasy VII Remake', @Description = 'Action RPG remake', @ReleaseDate = '2020-04-10', @CategoryId = 2, @PublisherId = 5, @GenreId = 1, @Precio = 59.99;
EXEC dbo.sp_create_Games @Title = 'Resident Evil Village', @Description = 'Survival horror', @ReleaseDate = '2021-05-07', @CategoryId = 1, @PublisherId = 6, @GenreId = 1, @Precio = 59.99;
EXEC dbo.sp_create_Games @Title = 'Grand Theft Auto V', @Description = 'Open-world crime', @ReleaseDate = '2013-09-17', @CategoryId = 1, @PublisherId = 7, @GenreId = 1, @Precio = 39.99;
EXEC dbo.sp_create_Games @Title = 'FIFA 23', @Description = 'Football simulation', @ReleaseDate = '2022-09-30', @CategoryId = 3, @PublisherId = 1, @GenreId = 4, @Precio = 69.99;
EXEC dbo.sp_create_Games @Title = 'Need for Speed Heat', @Description = 'Racing game', @ReleaseDate = '2019-11-08', @CategoryId = 4, @PublisherId = 1, @GenreId = 5, @Precio = 59.99;
EXEC dbo.sp_create_Games @Title = 'The Sims 4', @Description = 'Life simulation', @ReleaseDate = '2014-09-02', @CategoryId = 5, @PublisherId = 1, @GenreId = 6, @Precio = 39.99;
EXEC dbo.sp_create_Games @Title = 'Street Fighter V', @Description = 'Fighting game', @ReleaseDate = '2016-02-16', @CategoryId = 6, @PublisherId = 6, @GenreId = 7, @Precio = 39.99;
EXEC dbo.sp_create_Games @Title = 'Civilization VI', @Description = 'Turn-based strategy', @ReleaseDate = '2016-10-21', @CategoryId = 3, @PublisherId = 2, @GenreId = 3, @Precio = 59.99;
EXEC dbo.sp_create_Games @Title = 'Mario Kart 8 Deluxe', @Description = 'Racing game', @ReleaseDate = '2017-04-28', @CategoryId = 4, @PublisherId = 3, @GenreId = 5, @Precio = 59.99;
EXEC dbo.sp_create_Games @Title = 'Overwatch 2', @Description = 'Team-based shooter', @ReleaseDate = '2022-10-04', @CategoryId = 1, @PublisherId = 4, @GenreId = 2, @Precio = 0.00; -- Free-to-play
EXEC dbo.sp_create_Games @Title = 'Dragon Quest XI', @Description = 'Classic RPG', @ReleaseDate = '2018-09-04', @CategoryId = 2, @PublisherId = 5, @GenreId = 1, @Precio = 59.99;
EXEC dbo.sp_create_Games @Title = 'Monster Hunter Rise', @Description = 'Action RPG', @ReleaseDate = '2021-03-26', @CategoryId = 1, @PublisherId = 6, @GenreId = 1, @Precio = 59.99;
EXEC dbo.sp_create_Games @Title = 'Red Dead Redemption 2', @Description = 'Open-world western', @ReleaseDate = '2018-10-26', @CategoryId = 1, @PublisherId = 7, @GenreId = 1, @Precio = 59.99;
EXEC dbo.sp_create_Games @Title = 'NBA 2K23', @Description = 'Basketball simulation', @ReleaseDate = '2022-09-09', @CategoryId = 3, @PublisherId = 2, @GenreId = 4, @Precio = 69.99;
EXEC dbo.sp_create_Games @Title = 'Forza Horizon 5', @Description = 'Open-world racing', @ReleaseDate = '2021-11-09', @CategoryId = 4, @PublisherId = 1, @GenreId = 5, @Precio = 59.99;
EXEC dbo.sp_create_Games @Title = 'Cities: Skylines', @Description = 'City-building simulation', @ReleaseDate = '2015-03-10', @CategoryId = 5, @PublisherId = 2, @GenreId = 6, @Precio = 29.99;
EXEC dbo.sp_create_Games @Title = 'Tekken 7', @Description = 'Fighting game', @ReleaseDate = '2015-06-02', @CategoryId = 6, @PublisherId = 6, @GenreId = 7, @Precio = 39.99;
EXEC dbo.sp_create_Games @Title = 'Age of Empires IV', @Description = 'Real-time strategy', @ReleaseDate = '2021-10-28', @CategoryId = 3, @PublisherId = 5, @GenreId = 3, @Precio = 59.99;
EXEC dbo.sp_create_Games @Title = 'Super Mario Odyssey', @Description = '3D platformer', @ReleaseDate = '2017-10-27', @CategoryId = 1, @PublisherId = 3, @GenreId = 8, @Precio = 59.99;
EXEC dbo.sp_create_Games @Title = 'Apex Legends', @Description = 'Battle royale shooter', @ReleaseDate = '2019-02-04', @CategoryId = 1, @PublisherId = 4, @GenreId = 2, @Precio = 1.00; -- Free-to-play
EXEC dbo.sp_create_Games @Title = 'Persona 5 Royal', @Description = 'Stylish RPG', @ReleaseDate = '2020-03-31', @CategoryId = 2, @PublisherId = 5, @GenreId = 1, @Precio = 59.99;
EXEC dbo.sp_create_Games @Title = 'Devil May Cry 5', @Description = 'Action hack-and-slash', @ReleaseDate = '2019-03-08', @CategoryId = 1, @PublisherId = 6, @GenreId = 1, @Precio = 59.99;
EXEC dbo.sp_create_Games @Title = 'GTA IV', @Description = 'Open-world crime', @ReleaseDate = '2008-04-29', @CategoryId = 1, @PublisherId = 7, @GenreId = 1, @Precio = 19.99;
EXEC dbo.sp_create_Games @Title = 'Madden NFL 23', @Description = 'American football simulation', @ReleaseDate = '2022-08-19', @CategoryId = 3, @PublisherId = 1, @GenreId = 4, @Precio = 69.99;
EXEC dbo.sp_create_Games @Title = 'F1 2022', @Description = 'Formula 1 racing', @ReleaseDate = '2022-06-30', @CategoryId = 4, @PublisherId = 2, @GenreId = 5, @Precio = 59.99;
EXEC dbo.sp_create_Games @Title = 'Stardew Valley', @Description = 'Farming simulation', @ReleaseDate = '2016-02-26', @CategoryId = 5, @PublisherId = 5, @GenreId = 6, @Precio = 14.99;
EXEC dbo.sp_create_Games @Title = 'Mortal Kombat 11', @Description = 'Fighting game', @ReleaseDate = '2019-04-23', @CategoryId = 6, @PublisherId = 4, @GenreId = 7, @Precio = 49.99;

-- Ediciones existentes
EXEC dbo.sp_create_Editions @GameId = 1, @Name = 'Standard Edition', @BasePrice = 59.99;
EXEC dbo.sp_create_Editions @GameId = 1, @Name = 'Deluxe Edition', @BasePrice = 79.99;

-- Nuevas ediciones (para algunos juegos nuevos)
EXEC dbo.sp_create_Editions @GameId = 3, @Name = 'Standard Edition', @BasePrice = 59.99;
EXEC dbo.sp_create_Editions @GameId = 3, @Name = 'Master Edition', @BasePrice = 99.99;
EXEC dbo.sp_create_Editions @GameId = 5, @Name = 'Standard Edition', @BasePrice = 39.99;
EXEC dbo.sp_create_Editions @GameId = 5, @Name = 'Premium Edition', @BasePrice = 69.99;
EXEC dbo.sp_create_Editions @GameId = 7, @Name = 'Standard Edition', @BasePrice = 59.99;
EXEC dbo.sp_create_Editions @GameId = 7, @Name = 'Deluxe Edition', @BasePrice = 79.99;

-- Plataformas existentes
EXEC dbo.sp_create_Platforms @Name = 'PC';
EXEC dbo.sp_create_Platforms @Name = 'PlayStation 5';

-- Nuevas plataformas
EXEC dbo.sp_create_Platforms @Name = 'Xbox Series X';
EXEC dbo.sp_create_Platforms @Name = 'Nintendo Switch';
EXEC dbo.sp_create_Platforms @Name = 'PlayStation 4';

-- Variantes existentes
EXEC dbo.sp_create_Variants @EditionId = 1, @PlatformId = 1, @StockQuantity = 100, @PriceAdjustment = 0.00;
EXEC dbo.sp_create_Variants @EditionId = 1, @PlatformId = 2, @StockQuantity = 50, @PriceAdjustment = 5.00;

-- Nuevas variantes
EXEC dbo.sp_create_Variants @EditionId = 3, @PlatformId = 1, @StockQuantity = 80, @PriceAdjustment = 0.00;
EXEC dbo.sp_create_Variants @EditionId = 3, @PlatformId = 3, @StockQuantity = 60, @PriceAdjustment = 5.00;
EXEC dbo.sp_create_Variants @EditionId = 4, @PlatformId = 1, @StockQuantity = 70, @PriceAdjustment = 0.00;
EXEC dbo.sp_create_Variants @EditionId = 4, @PlatformId = 4, @StockQuantity = 50, @PriceAdjustment = 10.00;
EXEC dbo.sp_create_Variants @EditionId = 5, @PlatformId = 2, @StockQuantity = 90, @PriceAdjustment = 0.00;
EXEC dbo.sp_create_Variants @EditionId = 5, @PlatformId = 5, @StockQuantity = 40, @PriceAdjustment = 5.00;
EXEC dbo.sp_create_Variants @EditionId = 6, @PlatformId = 1, @StockQuantity = 75, @StockQuantity = 0.00;
EXEC dbo.sp_create_Variants @EditionId = 6, @PlatformId = 3, @StockQuantity = 45, @PriceAdjustment = 5.00;


-- Insertar usuario 1
EXEC dbo.sp_create_Users 
    @Email = 'worker1@example.com', 
    @PasswordHash = '$2b$11$hQ0jsuP5UV2PvSqJ9ajPuOef4shcP0bvrX7tQWTQeuXG/tu42zXYa', -- pasword2
    @Name = 'Worker 1';

-- Insertar usuario 2
EXEC dbo.sp_create_Users 
    @Email = 'worker2@example.com', 
    @PasswordHash = '$2b$11$hS4XIPmDhkjHpohTUKMm8ekUU/5a9L1JhJU8vWPThXl9469Ehk8ki', -- pasword3
    @Name = 'Worker 2';

-- Insertar usuario 3
EXEC dbo.sp_create_Users 
    @Email = 'worker3@example.com', 
    @PasswordHash = '$2b$11$kK4oHWK9KChQnZIRA5WvuOnX6GvW1nqzkDiRsjAMBjynC6A0DW.wi', -- pasword4
    @Name = 'Worker 3';

EXEC dbo.sp_create_UserRoles @UserId = 1, @RoleId = 1; -- Admin
EXEC dbo.sp_create_UserRoles @UserId = 2, @RoleId = 2; -- User

exec sp_getAll_Games