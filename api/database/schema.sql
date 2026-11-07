IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;
GO

BEGIN TRANSACTION;
IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20261106220708_InitialCreate'
)
BEGIN
    CREATE TABLE [Categories] (
        [CategoryId] tinyint NOT NULL,
        [Slug] nvarchar(450) NOT NULL,
        [Name] nvarchar(max) NOT NULL,
        [IsActive] bit NOT NULL,
        CONSTRAINT [PK_Categories] PRIMARY KEY ([CategoryId])
    );
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20261106220708_InitialCreate'
)
BEGIN
    CREATE TABLE [Stores] (
        [StoreId] bigint NOT NULL IDENTITY,
        [Name] nvarchar(max) NOT NULL,
        [City] nvarchar(max) NOT NULL,
        [Location] geography NULL,
        [IsActive] bit NOT NULL,
        [CreatedAt] datetime2 NOT NULL,
        CONSTRAINT [PK_Stores] PRIMARY KEY ([StoreId])
    );
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20261106220708_InitialCreate'
)
BEGIN
    CREATE TABLE [Subcategories] (
        [SubcategoryId] tinyint NOT NULL,
        [CategoryId] tinyint NOT NULL,
        [Slug] nvarchar(450) NOT NULL,
        [Name] nvarchar(max) NOT NULL,
        [SortOrder] tinyint NOT NULL,
        [IsActive] bit NOT NULL,
        CONSTRAINT [PK_Subcategories] PRIMARY KEY ([SubcategoryId]),
        CONSTRAINT [FK_Subcategories_Categories_CategoryId] FOREIGN KEY ([CategoryId]) REFERENCES [Categories] ([CategoryId]) ON DELETE CASCADE
    );
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20261106220708_InitialCreate'
)
BEGIN
    CREATE TABLE [Sales] (
        [SaleId] bigint NOT NULL IDENTITY,
        [StoreId] bigint NOT NULL,
        [Name] nvarchar(max) NOT NULL,
        [StartDate] datetime2 NULL,
        [EndDate] datetime2 NULL,
        [IsActive] bit NOT NULL,
        CONSTRAINT [PK_Sales] PRIMARY KEY ([SaleId]),
        CONSTRAINT [FK_Sales_Stores_StoreId] FOREIGN KEY ([StoreId]) REFERENCES [Stores] ([StoreId]) ON DELETE NO ACTION
    );
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20261106220708_InitialCreate'
)
BEGIN
    CREATE TABLE [Products] (
        [ProductId] bigint NOT NULL IDENTITY,
        [StoreId] bigint NOT NULL,
        [SaleId] bigint NULL,
        [Title] nvarchar(max) NOT NULL,
        [Description] nvarchar(max) NULL,
        [CategoryId] tinyint NOT NULL,
        [SubcategoryId] tinyint NULL,
        [OriginalPrice] decimal(10,2) NOT NULL,
        [SalePrice] decimal(10,2) NULL,
        [DiscountPercentage] int NULL,
        [Rating] float NOT NULL,
        [IsActive] bit NOT NULL,
        [CreatedAt] datetime2 NOT NULL,
        CONSTRAINT [PK_Products] PRIMARY KEY ([ProductId]),
        CONSTRAINT [FK_Products_Categories_CategoryId] FOREIGN KEY ([CategoryId]) REFERENCES [Categories] ([CategoryId]) ON DELETE NO ACTION,
        CONSTRAINT [FK_Products_Sales_SaleId] FOREIGN KEY ([SaleId]) REFERENCES [Sales] ([SaleId]) ON DELETE SET NULL,
        CONSTRAINT [FK_Products_Stores_StoreId] FOREIGN KEY ([StoreId]) REFERENCES [Stores] ([StoreId]) ON DELETE CASCADE,
        CONSTRAINT [FK_Products_Subcategories_SubcategoryId] FOREIGN KEY ([SubcategoryId]) REFERENCES [Subcategories] ([SubcategoryId]) ON DELETE SET NULL
    );
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20261106220708_InitialCreate'
)
BEGIN
    CREATE TABLE [ProductImages] (
        [ProductImageId] bigint NOT NULL IDENTITY,
        [ProductId] bigint NOT NULL,
        [ImageUrl] nvarchar(max) NOT NULL,
        [SortOrder] int NOT NULL,
        CONSTRAINT [PK_ProductImages] PRIMARY KEY ([ProductImageId]),
        CONSTRAINT [FK_ProductImages_Products_ProductId] FOREIGN KEY ([ProductId]) REFERENCES [Products] ([ProductId]) ON DELETE CASCADE
    );
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20261106220708_InitialCreate'
)
BEGIN
    CREATE TABLE [ProductSizes] (
        [ProductSizeId] bigint NOT NULL IDENTITY,
        [ProductId] bigint NOT NULL,
        [Size] nvarchar(450) NOT NULL,
        [Quantity] int NOT NULL,
        [UnitsSold] int NOT NULL,
        CONSTRAINT [PK_ProductSizes] PRIMARY KEY ([ProductSizeId]),
        CONSTRAINT [FK_ProductSizes_Products_ProductId] FOREIGN KEY ([ProductId]) REFERENCES [Products] ([ProductId]) ON DELETE CASCADE
    );
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20261106220708_InitialCreate'
)
BEGIN
    CREATE UNIQUE INDEX [IX_Categories_Slug] ON [Categories] ([Slug]);
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20261106220708_InitialCreate'
)
BEGIN
    CREATE INDEX [IX_ProductImages_ProductId_SortOrder] ON [ProductImages] ([ProductId], [SortOrder]);
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20261106220708_InitialCreate'
)
BEGIN
    CREATE INDEX [IX_Products_CategoryId] ON [Products] ([CategoryId]);
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20261106220708_InitialCreate'
)
BEGIN
    CREATE INDEX [IX_Products_SaleId] ON [Products] ([SaleId]);
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20261106220708_InitialCreate'
)
BEGIN
    CREATE INDEX [IX_Products_StoreId] ON [Products] ([StoreId]);
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20261106220708_InitialCreate'
)
BEGIN
    CREATE INDEX [IX_Products_SubcategoryId] ON [Products] ([SubcategoryId]);
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20261106220708_InitialCreate'
)
BEGIN
    CREATE UNIQUE INDEX [IX_ProductSizes_ProductId_Size] ON [ProductSizes] ([ProductId], [Size]);
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20261106220708_InitialCreate'
)
BEGIN
    CREATE INDEX [IX_Sales_StoreId] ON [Sales] ([StoreId]);
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20261106220708_InitialCreate'
)
BEGIN
    CREATE INDEX [IX_Subcategories_CategoryId] ON [Subcategories] ([CategoryId]);
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20261106220708_InitialCreate'
)
BEGIN
    CREATE UNIQUE INDEX [IX_Subcategories_Slug] ON [Subcategories] ([Slug]);
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20261106220708_InitialCreate'
)
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20261106220708_InitialCreate', N'10.0.12');
END;

COMMIT;
GO

BEGIN TRANSACTION;
IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20261106233945_SeedProducts'
)
BEGIN
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'CategoryId', N'IsActive', N'Name', N'Slug') AND [object_id] = OBJECT_ID(N'[Categories]'))
        SET IDENTITY_INSERT [Categories] ON;
    EXEC(N'INSERT INTO [Categories] ([CategoryId], [IsActive], [Name], [Slug])
    VALUES (CAST(1 AS tinyint), CAST(1 AS bit), N''Men''''s'', N''mens''),
    (CAST(2 AS tinyint), CAST(1 AS bit), N''Women''''s'', N''womens''),
    (CAST(3 AS tinyint), CAST(1 AS bit), N''Beauty'', N''beauty''),
    (CAST(4 AS tinyint), CAST(1 AS bit), N''Home'', N''home''),
    (CAST(5 AS tinyint), CAST(1 AS bit), N''Kids'', N''kids''),
    (CAST(6 AS tinyint), CAST(1 AS bit), N''Office'', N''office''),
    (CAST(7 AS tinyint), CAST(1 AS bit), N''Electronics'', N''electronics''),
    (CAST(8 AS tinyint), CAST(1 AS bit), N''Curve'', N''curve''),
    (CAST(9 AS tinyint), CAST(1 AS bit), N''Jewelry'', N''jewelry''),
    (CAST(10 AS tinyint), CAST(1 AS bit), N''Sports'', N''sports''),
    (CAST(11 AS tinyint), CAST(1 AS bit), N''Bags'', N''bags''),
    (CAST(12 AS tinyint), CAST(1 AS bit), N''Toys'', N''toys''),
    (CAST(13 AS tinyint), CAST(1 AS bit), N''Seasonal'', N''seasonal'')');
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'CategoryId', N'IsActive', N'Name', N'Slug') AND [object_id] = OBJECT_ID(N'[Categories]'))
        SET IDENTITY_INSERT [Categories] OFF;
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20261106233945_SeedProducts'
)
BEGIN
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'StoreId', N'City', N'CreatedAt', N'IsActive', N'Location', N'Name') AND [object_id] = OBJECT_ID(N'[Stores]'))
        SET IDENTITY_INSERT [Stores] ON;
    EXEC(N'INSERT INTO [Stores] ([StoreId], [City], [CreatedAt], [IsActive], [Location], [Name])
    VALUES (CAST(1 AS bigint), N''Cape Town'', ''2026-09-21T00:00:00.0000000Z'', CAST(1 AS bit), NULL, N''Plugg Demo Store'')');
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'StoreId', N'City', N'CreatedAt', N'IsActive', N'Location', N'Name') AND [object_id] = OBJECT_ID(N'[Stores]'))
        SET IDENTITY_INSERT [Stores] OFF;
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20261106233945_SeedProducts'
)
BEGIN
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'SaleId', N'EndDate', N'IsActive', N'Name', N'StartDate', N'StoreId') AND [object_id] = OBJECT_ID(N'[Sales]'))
        SET IDENTITY_INSERT [Sales] ON;
    EXEC(N'INSERT INTO [Sales] ([SaleId], [EndDate], [IsActive], [Name], [StartDate], [StoreId])
    VALUES (CAST(1 AS bigint), ''2026-10-17T20:00:00.0000000Z'', CAST(1 AS bit), N''Flash Sale'', ''2026-09-21T00:00:00.0000000Z'', CAST(1 AS bigint)),
    (CAST(2 AS bigint), ''2026-10-20T20:00:00.0000000Z'', CAST(1 AS bit), N''Weekend Deals'', ''2026-09-21T00:00:00.0000000Z'', CAST(1 AS bigint))');
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'SaleId', N'EndDate', N'IsActive', N'Name', N'StartDate', N'StoreId') AND [object_id] = OBJECT_ID(N'[Sales]'))
        SET IDENTITY_INSERT [Sales] OFF;
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20261106233945_SeedProducts'
)
BEGIN
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'SubcategoryId', N'CategoryId', N'IsActive', N'Name', N'Slug', N'SortOrder') AND [object_id] = OBJECT_ID(N'[Subcategories]'))
        SET IDENTITY_INSERT [Subcategories] ON;
    EXEC(N'INSERT INTO [Subcategories] ([SubcategoryId], [CategoryId], [IsActive], [Name], [Slug], [SortOrder])
    VALUES (CAST(1 AS tinyint), CAST(2 AS tinyint), CAST(1 AS bit), N''Dresses'', N''dresses'', CAST(1 AS tinyint)),
    (CAST(2 AS tinyint), CAST(2 AS tinyint), CAST(1 AS bit), N''Suits & Corsets'', N''suits-corsets'', CAST(2 AS tinyint)),
    (CAST(3 AS tinyint), CAST(2 AS tinyint), CAST(1 AS bit), N''Shoes'', N''shoes'', CAST(3 AS tinyint)),
    (CAST(4 AS tinyint), CAST(2 AS tinyint), CAST(1 AS bit), N''Eyewear'', N''eyewear'', CAST(4 AS tinyint)),
    (CAST(5 AS tinyint), CAST(1 AS tinyint), CAST(1 AS bit), N''Shirts & Tees'', N''shirts-tees'', CAST(1 AS tinyint)),
    (CAST(6 AS tinyint), CAST(1 AS tinyint), CAST(1 AS bit), N''Footwear'', N''footwear'', CAST(2 AS tinyint)),
    (CAST(7 AS tinyint), CAST(1 AS tinyint), CAST(1 AS bit), N''Watches'', N''watches'', CAST(3 AS tinyint)),
    (CAST(8 AS tinyint), CAST(11 AS tinyint), CAST(1 AS bit), N''Handbags'', N''handbags'', CAST(1 AS tinyint)),
    (CAST(9 AS tinyint), CAST(11 AS tinyint), CAST(1 AS bit), N''Backpacks'', N''backpacks'', CAST(2 AS tinyint)),
    (CAST(10 AS tinyint), CAST(9 AS tinyint), CAST(1 AS bit), N''Earrings'', N''earrings'', CAST(1 AS tinyint))');
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'SubcategoryId', N'CategoryId', N'IsActive', N'Name', N'Slug', N'SortOrder') AND [object_id] = OBJECT_ID(N'[Subcategories]'))
        SET IDENTITY_INSERT [Subcategories] OFF;
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20261106233945_SeedProducts'
)
BEGIN
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'ProductId', N'CategoryId', N'CreatedAt', N'Description', N'DiscountPercentage', N'IsActive', N'OriginalPrice', N'Rating', N'SaleId', N'SalePrice', N'StoreId', N'SubcategoryId', N'Title') AND [object_id] = OBJECT_ID(N'[Products]'))
        SET IDENTITY_INSERT [Products] ON;
    EXEC(N'INSERT INTO [Products] ([ProductId], [CategoryId], [CreatedAt], [Description], [DiscountPercentage], [IsActive], [OriginalPrice], [Rating], [SaleId], [SalePrice], [StoreId], [SubcategoryId], [Title])
    VALUES (CAST(1 AS bigint), CAST(2 AS tinyint), ''2026-09-21T00:00:00.0000000Z'', N''An elegant floor-length gown in black, finished with a tailored silhouette for evening occasions.'', 10, CAST(1 AS bit), 129.99, 3.6400000000000001E0, CAST(1 AS bigint), 116.99, CAST(1 AS bigint), CAST(1 AS tinyint), N''Black Women''''s Gown''),
    (CAST(2 AS bigint), CAST(2 AS tinyint), ''2026-09-21T00:00:00.0000000Z'', N''A structured leather corset paired with a matching skirt for a bold, fitted look.'', 16, CAST(1 AS bit), 89.99, 3.0499999999999998E0, CAST(1 AS bigint), 75.59, CAST(1 AS bigint), CAST(2 AS tinyint), N''Corset Leather With Skirt''),
    (CAST(3 AS bigint), CAST(2 AS tinyint), ''2026-09-21T00:00:00.0000000Z'', N''A classic black corset top with a coordinating skirt, cinched at the waist.'', 15, CAST(1 AS bit), 79.99, 4.5199999999999996E0, CAST(1 AS bigint), 67.99, CAST(1 AS bigint), CAST(2 AS tinyint), N''Corset With Black Skirt''),
    (CAST(4 AS bigint), CAST(2 AS tinyint), ''2026-09-21T00:00:00.0000000Z'', N''A soft pea-green dress with a relaxed fit, perfect for everyday wear.'', 18, CAST(1 AS bit), 49.99, 4.8799999999999999E0, CAST(1 AS bigint), 40.99, CAST(1 AS bigint), CAST(1 AS tinyint), N''Dress Pea''),
    (CAST(5 AS bigint), CAST(2 AS tinyint), ''2026-09-21T00:00:00.0000000Z'', N''A striking red and black two-piece suit with sharp tailoring.'', 19, CAST(1 AS bit), 179.99, 4.4800000000000004E0, CAST(1 AS bigint), 145.79, CAST(1 AS bigint), CAST(2 AS tinyint), N''Marni Red & Black Suit''),
    (CAST(6 AS bigint), CAST(2 AS tinyint), ''2026-09-21T00:00:00.0000000Z'', N''A lightweight blue frock with a flattering A-line cut.'', 12, CAST(1 AS bit), 29.99, 4.1699999999999999E0, CAST(1 AS bigint), 26.39, CAST(1 AS bigint), CAST(1 AS tinyint), N''Blue Frock''),
    (CAST(7 AS bigint), CAST(2 AS tinyint), ''2026-09-21T00:00:00.0000000Z'', N''A breezy summer dress in a light fabric, ideal for warm days.'', 19, CAST(1 AS bit), 19.99, 4.7699999999999996E0, CAST(1 AS bigint), 16.19, CAST(1 AS bigint), CAST(1 AS tinyint), N''Girl Summer Dress''),
    (CAST(8 AS bigint), CAST(2 AS tinyint), ''2026-09-21T00:00:00.0000000Z'', N''A versatile grey dress that moves easily from day to evening.'', 14, CAST(1 AS bit), 34.99, 2.7200000000000002E0, CAST(1 AS bigint), 30.09, CAST(1 AS bigint), CAST(1 AS tinyint), N''Gray Dress''),
    (CAST(9 AS bigint), CAST(2 AS tinyint), ''2026-09-21T00:00:00.0000000Z'', N''A playful short frock with a fitted bodice and flared hem.'', 13, CAST(1 AS bit), 24.99, 3.23E0, CAST(1 AS bigint), 21.74, CAST(1 AS bigint), CAST(1 AS tinyint), N''Short Frock''),
    (CAST(10 AS bigint), CAST(2 AS tinyint), ''2026-09-21T00:00:00.0000000Z'', N''A tartan-print dress with a nipped waist and classic collar.'', 13, CAST(1 AS bit), 39.99, 4.0499999999999998E0, CAST(1 AS bigint), 34.79, CAST(1 AS bigint), CAST(1 AS tinyint), N''Tartan Dress''),
    (CAST(11 AS bigint), CAST(2 AS tinyint), ''2026-09-21T00:00:00.0000000Z'', N''Soft slip-on slippers in a black and brown colourway.'', 3, CAST(1 AS bit), 19.99, 2.5299999999999998E0, CAST(1 AS bigint), 19.39, CAST(1 AS bigint), CAST(3 AS tinyint), N''Black & Brown Slipper''),
    (CAST(12 AS bigint), CAST(2 AS tinyint), ''2026-09-21T00:00:00.0000000Z'', N''Pointed-toe heels from Calvin Klein with a sleek finish.'', 3, CAST(1 AS bit), 79.99, 4.9199999999999999E0, CAST(1 AS bigint), 77.59, CAST(1 AS bigint), CAST(3 AS tinyint), N''Calvin Klein Heel Shoes''),
    (CAST(13 AS bigint), CAST(2 AS tinyint), ''2026-09-21T00:00:00.0000000Z'', N''Metallic gold heels designed to catch the light at any event.'', 14, CAST(1 AS bit), 49.99, 3.2599999999999998E0, CAST(1 AS bigint), 42.99, CAST(1 AS bigint), CAST(3 AS tinyint), N''Golden Shoes Woman''),
    (CAST(14 AS bigint), CAST(2 AS tinyint), ''2026-09-21T00:00:00.0000000Z'', N''Comfortable everyday flats with a cushioned footbed.'', 14, CAST(1 AS bit), 29.99, 3.0499999999999998E0, CAST(1 AS bigint), 25.79, CAST(1 AS bigint), CAST(3 AS tinyint), N''Pampi Shoes''),
    (CAST(15 AS bigint), CAST(2 AS tinyint), ''2026-09-21T00:00:00.0000000Z'', N''Statement red shoes with a rounded toe and block heel.'', 18, CAST(1 AS bit), 34.99, 3.25E0, CAST(1 AS bigint), 28.69, CAST(1 AS bigint), CAST(3 AS tinyint), N''Red Shoes''),
    (CAST(16 AS bigint), CAST(11 AS tinyint), ''2026-09-21T00:00:00.0000000Z'', N''A structured blue handbag with a top handle and adjustable strap.'', 18, CAST(1 AS bit), 49.99, 2.9199999999999999E0, CAST(1 AS bigint), 40.99, CAST(1 AS bigint), CAST(8 AS tinyint), N''Blue Women''''s Handbag''),
    (CAST(17 AS bigint), CAST(11 AS tinyint), ''2026-09-21T00:00:00.0000000Z'', N''A genuine leather handbag from Heshe with a timeless silhouette.'', 4, CAST(1 AS bit), 129.99, 4.9199999999999999E0, CAST(1 AS bigint), 124.79, CAST(1 AS bigint), CAST(8 AS tinyint), N''Heshe Women''''s Leather Bag''),
    (CAST(18 AS bigint), CAST(11 AS tinyint), ''2026-09-21T00:00:00.0000000Z'', N''A premium Prada handbag crafted for everyday luxury.'', 14, CAST(1 AS bit), 599.99, 2.71E0, CAST(1 AS bigint), 515.99, CAST(1 AS bigint), CAST(8 AS tinyint), N''Prada Women Bag''),
    (CAST(19 AS bigint), CAST(11 AS tinyint), ''2026-09-21T00:00:00.0000000Z'', N''A white faux-leather backpack with padded straps for daily use.'', 15, CAST(1 AS bit), 39.99, 3.3599999999999999E0, CAST(1 AS bigint), 33.99, CAST(1 AS bigint), CAST(9 AS tinyint), N''White Faux Leather Backpack''),
    (CAST(20 AS bigint), CAST(11 AS tinyint), ''2026-09-21T00:00:00.0000000Z'', N''A classic black handbag with a roomy interior and secure zip closure.'', 12, CAST(1 AS bit), 59.99, 2.8900000000000001E0, CAST(1 AS bigint), 52.79, CAST(1 AS bigint), CAST(8 AS tinyint), N''Women Handbag Black''),
    (CAST(21 AS bigint), CAST(9 AS tinyint), ''2026-09-21T00:00:00.0000000Z'', N''Crystal drop earrings in a rich emerald green.'', 15, CAST(1 AS bit), 29.99, 3.96E0, CAST(1 AS bigint), 25.49, CAST(1 AS bigint), CAST(10 AS tinyint), N''Green Crystal Earring''),
    (CAST(22 AS bigint), CAST(9 AS tinyint), ''2026-09-21T00:00:00.0000000Z'', N''Oval-cut green stone earrings with a delicate gold-tone setting.'', 15, CAST(1 AS bit), 24.99, 3.5699999999999998E0, CAST(1 AS bigint), 21.24, CAST(1 AS bigint), CAST(10 AS tinyint), N''Green Oval Earring''),
    (CAST(23 AS bigint), CAST(9 AS tinyint), ''2026-09-21T00:00:00.0000000Z'', N''Statement earrings with a tropical-inspired design.'', 1, CAST(1 AS bit), 19.99, 4.4000000000000004E0, CAST(2 AS bigint), 19.79, CAST(1 AS bigint), CAST(10 AS tinyint), N''Tropical Earring''),
    (CAST(24 AS bigint), CAST(2 AS tinyint), ''2026-09-21T00:00:00.0000000Z'', N''Classic black sunglasses with UV-protective lenses.'', 5, CAST(1 AS bit), 29.99, 4.4100000000000001E0, CAST(2 AS bigint), 28.49, CAST(1 AS bigint), CAST(4 AS tinyint), N''Black Sun Glasses''),
    (CAST(25 AS bigint), CAST(2 AS tinyint), ''2026-09-21T00:00:00.0000000Z'', N''Timeless sunglasses with a rounded frame.'', 5, CAST(1 AS bit), 24.99, 3.8599999999999999E0, CAST(2 AS bigint), 23.74, CAST(1 AS bigint), CAST(4 AS tinyint), N''Classic Sun Glasses''),
    (CAST(26 AS bigint), CAST(2 AS tinyint), ''2026-09-21T00:00:00.0000000Z'', N''Two-tone sunglasses in green and black with a modern frame.'', 1, CAST(1 AS bit), 34.99, 4.5499999999999998E0, CAST(2 AS bigint), 34.64, CAST(1 AS bigint), CAST(4 AS tinyint), N''Green and Black Glasses''),
    (CAST(27 AS bigint), CAST(2 AS tinyint), ''2026-09-21T00:00:00.0000000Z'', N''Statement sunglasses with a bold frame, made for standing out.'', 11, CAST(1 AS bit), 19.99, 2.79E0, CAST(2 AS bigint), 17.79, CAST(1 AS bigint), CAST(4 AS tinyint), N''Party Glasses''),
    (CAST(28 AS bigint), CAST(2 AS tinyint), ''2026-09-21T00:00:00.0000000Z'', N''Everyday sunglasses with a lightweight frame.'', 2, CAST(1 AS bit), 22.99, 3.02E0, CAST(2 AS bigint), 22.53, CAST(1 AS bigint), CAST(4 AS tinyint), N''Sunglasses''),
    (CAST(29 AS bigint), CAST(1 AS tinyint), ''2026-09-21T00:00:00.0000000Z'', N''A checked shirt in blue and black, cut for a relaxed everyday fit.'', 15, CAST(1 AS bit), 29.99, 3.6400000000000001E0, CAST(2 AS bigint), 25.49, CAST(1 AS bigint), CAST(5 AS tinyint), N''Blue & Black Check Shirt''),
    (CAST(30 AS bigint), CAST(1 AS tinyint), ''2026-09-21T00:00:00.0000000Z'', N''A graphic Aorus-branded t-shirt in soft cotton.'', 1, CAST(1 AS bit), 24.99, 3.1800000000000002E0, CAST(2 AS bigint), 24.74, CAST(1 AS bigint), CAST(5 AS tinyint), N''Gigabyte Aorus Men Tshirt''),
    (CAST(31 AS bigint), CAST(1 AS tinyint), ''2026-09-21T00:00:00.0000000Z'', N''A classic plaid shirt with a button-down collar.'', 20, CAST(1 AS bit), 34.99, 3.46E0, CAST(2 AS bigint), 27.99, CAST(1 AS bigint), CAST(5 AS tinyint), N''Man Plaid Shirt''),
    (CAST(32 AS bigint), CAST(1 AS tinyint), ''2026-09-21T00:00:00.0000000Z'', N''A lightweight short-sleeve shirt for warm-weather wear.'', 7, CAST(1 AS bit), 19.99, 2.8999999999999999E0, CAST(2 AS bigint), 18.59, CAST(1 AS bigint), CAST(5 AS tinyint), N''Man Short Sleeve Shirt''),
    (CAST(33 AS bigint), CAST(1 AS tinyint), ''2026-09-21T00:00:00.0000000Z'', N''A checked button-up shirt with a tailored fit.'', 11, CAST(1 AS bit), 27.99, 2.7200000000000002E0, CAST(2 AS bigint), 24.91, CAST(1 AS bigint), CAST(5 AS tinyint), N''Men Check Shirt''),
    (CAST(34 AS bigint), CAST(1 AS tinyint), ''2026-09-21T00:00:00.0000000Z'', N''Iconic Air Jordan 1 sneakers in a red and black colourway.'', 4, CAST(1 AS bit), 149.99, 4.7699999999999996E0, CAST(2 AS bigint), 143.99, CAST(1 AS bigint), CAST(6 AS tinyint), N''Nike Air Jordan 1 Red And Black''),
    (CAST(35 AS bigint), CAST(1 AS tinyint), ''2026-09-21T00:00:00.0000000Z'', N''Performance baseball cleats built for grip and speed.'', 18, CAST(1 AS bit), 79.99, 3.8799999999999999E0, CAST(2 AS bigint), 65.59, CAST(1 AS bigint), CAST(6 AS tinyint), N''Nike Baseball Cleats''),
    (CAST(36 AS bigint), CAST(1 AS tinyint), ''2026-09-21T00:00:00.0000000Z'', N''Retro-styled Puma trainers with a cushioned sole.'', 4, CAST(1 AS bit), 89.99, 4.9000000000000004E0, CAST(2 AS bigint), 86.39, CAST(1 AS bigint), CAST(6 AS tinyint), N''Puma Future Rider Trainers''),
    (CAST(37 AS bigint), CAST(1 AS tinyint), ''2026-09-21T00:00:00.0000000Z'', N''Lightweight sneakers in off-white and red, built for everyday training.'', 5, CAST(1 AS bit), 119.99, 4.7699999999999996E0, CAST(2 AS bigint), 113.99, CAST(1 AS bigint), CAST(6 AS tinyint), N''Sports Sneakers Off White & Red''),
    (CAST(38 AS bigint), CAST(1 AS tinyint), ''2026-09-21T00:00:00.0000000Z'', N''A low-top sneaker in off-white with red accents.'', NULL, CAST(1 AS bit), 109.99, 4.6900000000000004E0, NULL, NULL, CAST(1 AS bigint), CAST(6 AS tinyint), N''Sports Sneakers Off White Red''),
    (CAST(39 AS bigint), CAST(1 AS tinyint), ''2026-09-21T00:00:00.0000000Z'', N''A classic watch with a brown leather strap and minimalist dial.'', 6, CAST(1 AS bit), 89.99, 4.1900000000000004E0, CAST(2 AS bigint), 84.59, CAST(1 AS bigint), CAST(7 AS tinyint), N''Brown Leather Belt Watch''),
    (CAST(40 AS bigint), CAST(1 AS tinyint), ''2026-09-21T00:00:00.0000000Z'', N''A Longines Master Collection watch with a refined, understated face.'', 17, CAST(1 AS bit), 1499.99, 3.8700000000000001E0, CAST(2 AS bigint), 1244.99, CAST(1 AS bigint), CAST(7 AS tinyint), N''Longines Master Collection''),
    (CAST(41 AS bigint), CAST(1 AS tinyint), ''2026-09-21T00:00:00.0000000Z'', N''A Rolex Cellini with a black dial and date function.'', 9, CAST(1 AS bit), 8999.99, 4.9699999999999998E0, CAST(2 AS bigint), 8189.99, CAST(1 AS bigint), CAST(7 AS tinyint), N''Rolex Cellini Date Black Dial''),
    (CAST(42 AS bigint), CAST(1 AS tinyint), ''2026-09-21T00:00:00.0000000Z'', N''A Rolex Cellini Moonphase with an intricate dial complication.'', 18, CAST(1 AS bit), 12999.99, 2.5800000000000001E0, CAST(2 AS bigint), 10659.99, CAST(1 AS bigint), CAST(7 AS tinyint), N''Rolex Cellini Moonphase'');
    INSERT INTO [Products] ([ProductId], [CategoryId], [CreatedAt], [Description], [DiscountPercentage], [IsActive], [OriginalPrice], [Rating], [SaleId], [SalePrice], [StoreId], [SubcategoryId], [Title])
    VALUES (CAST(43 AS bigint), CAST(1 AS tinyint), ''2026-09-21T00:00:00.0000000Z'', N''A Rolex Datejust, the brand''''s most recognisable classic.'', 4, CAST(1 AS bit), 10999.99, 3.6600000000000001E0, CAST(2 AS bigint), 10559.99, CAST(1 AS bigint), CAST(7 AS tinyint), N''Rolex Datejust''),
    (CAST(44 AS bigint), CAST(1 AS tinyint), ''2026-09-21T00:00:00.0000000Z'', N''A Rolex Submariner built for durability and timeless style.'', 5, CAST(1 AS bit), 13999.99, 2.6899999999999999E0, CAST(2 AS bigint), 13299.99, CAST(1 AS bigint), CAST(7 AS tinyint), N''Rolex Submariner Watch'')');
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'ProductId', N'CategoryId', N'CreatedAt', N'Description', N'DiscountPercentage', N'IsActive', N'OriginalPrice', N'Rating', N'SaleId', N'SalePrice', N'StoreId', N'SubcategoryId', N'Title') AND [object_id] = OBJECT_ID(N'[Products]'))
        SET IDENTITY_INSERT [Products] OFF;
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20261106233945_SeedProducts'
)
BEGIN
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'ProductImageId', N'ImageUrl', N'ProductId', N'SortOrder') AND [object_id] = OBJECT_ID(N'[ProductImages]'))
        SET IDENTITY_INSERT [ProductImages] ON;
    EXEC(N'INSERT INTO [ProductImages] ([ProductImageId], [ImageUrl], [ProductId], [SortOrder])
    VALUES (CAST(1 AS bigint), N''https://cdn.dummyjson.com/product-images/womens-dresses/black-women''''s-gown/thumbnail.webp'', CAST(1 AS bigint), 0),
    (CAST(2 AS bigint), N''https://cdn.dummyjson.com/product-images/womens-dresses/black-women''''s-gown/1.webp'', CAST(1 AS bigint), 1),
    (CAST(3 AS bigint), N''https://cdn.dummyjson.com/product-images/womens-dresses/corset-leather-with-skirt/thumbnail.webp'', CAST(2 AS bigint), 0),
    (CAST(4 AS bigint), N''https://cdn.dummyjson.com/product-images/womens-dresses/corset-with-black-skirt/thumbnail.webp'', CAST(3 AS bigint), 0),
    (CAST(5 AS bigint), N''https://cdn.dummyjson.com/product-images/womens-dresses/dress-pea/thumbnail.webp'', CAST(4 AS bigint), 0),
    (CAST(6 AS bigint), N''https://cdn.dummyjson.com/product-images/womens-dresses/marni-red-&-black-suit/thumbnail.webp'', CAST(5 AS bigint), 0),
    (CAST(7 AS bigint), N''https://cdn.dummyjson.com/product-images/tops/blue-frock/thumbnail.webp'', CAST(6 AS bigint), 0),
    (CAST(8 AS bigint), N''https://cdn.dummyjson.com/product-images/tops/girl-summer-dress/thumbnail.webp'', CAST(7 AS bigint), 0),
    (CAST(9 AS bigint), N''https://cdn.dummyjson.com/product-images/tops/gray-dress/thumbnail.webp'', CAST(8 AS bigint), 0),
    (CAST(10 AS bigint), N''https://cdn.dummyjson.com/product-images/tops/short-frock/thumbnail.webp'', CAST(9 AS bigint), 0),
    (CAST(11 AS bigint), N''https://cdn.dummyjson.com/product-images/tops/tartan-dress/thumbnail.webp'', CAST(10 AS bigint), 0),
    (CAST(12 AS bigint), N''https://cdn.dummyjson.com/product-images/womens-shoes/black-&-brown-slipper/thumbnail.webp'', CAST(11 AS bigint), 0),
    (CAST(13 AS bigint), N''https://cdn.dummyjson.com/product-images/womens-shoes/calvin-klein-heel-shoes/thumbnail.webp'', CAST(12 AS bigint), 0),
    (CAST(14 AS bigint), N''https://cdn.dummyjson.com/product-images/womens-shoes/golden-shoes-woman/thumbnail.webp'', CAST(13 AS bigint), 0),
    (CAST(15 AS bigint), N''https://cdn.dummyjson.com/product-images/womens-shoes/pampi-shoes/thumbnail.webp'', CAST(14 AS bigint), 0),
    (CAST(16 AS bigint), N''https://cdn.dummyjson.com/product-images/womens-shoes/red-shoes/thumbnail.webp'', CAST(15 AS bigint), 0),
    (CAST(17 AS bigint), N''https://cdn.dummyjson.com/product-images/womens-bags/blue-women''''s-handbag/thumbnail.webp'', CAST(16 AS bigint), 0),
    (CAST(18 AS bigint), N''https://cdn.dummyjson.com/product-images/womens-bags/heshe-women''''s-leather-bag/thumbnail.webp'', CAST(17 AS bigint), 0),
    (CAST(19 AS bigint), N''https://cdn.dummyjson.com/product-images/womens-bags/prada-women-bag/thumbnail.webp'', CAST(18 AS bigint), 0),
    (CAST(20 AS bigint), N''https://cdn.dummyjson.com/product-images/womens-bags/prada-women-bag/1.webp'', CAST(18 AS bigint), 1),
    (CAST(21 AS bigint), N''https://cdn.dummyjson.com/product-images/womens-bags/white-faux-leather-backpack/thumbnail.webp'', CAST(19 AS bigint), 0),
    (CAST(22 AS bigint), N''https://cdn.dummyjson.com/product-images/womens-bags/women-handbag-black/thumbnail.webp'', CAST(20 AS bigint), 0),
    (CAST(23 AS bigint), N''https://cdn.dummyjson.com/product-images/womens-jewellery/green-crystal-earring/thumbnail.webp'', CAST(21 AS bigint), 0),
    (CAST(24 AS bigint), N''https://cdn.dummyjson.com/product-images/womens-jewellery/green-oval-earring/thumbnail.webp'', CAST(22 AS bigint), 0),
    (CAST(25 AS bigint), N''https://cdn.dummyjson.com/product-images/womens-jewellery/tropical-earring/thumbnail.webp'', CAST(23 AS bigint), 0),
    (CAST(26 AS bigint), N''https://cdn.dummyjson.com/product-images/sunglasses/black-sun-glasses/thumbnail.webp'', CAST(24 AS bigint), 0),
    (CAST(27 AS bigint), N''https://cdn.dummyjson.com/product-images/sunglasses/black-sun-glasses/1.webp'', CAST(24 AS bigint), 1),
    (CAST(28 AS bigint), N''https://cdn.dummyjson.com/product-images/sunglasses/classic-sun-glasses/thumbnail.webp'', CAST(25 AS bigint), 0),
    (CAST(29 AS bigint), N''https://cdn.dummyjson.com/product-images/sunglasses/green-and-black-glasses/thumbnail.webp'', CAST(26 AS bigint), 0),
    (CAST(30 AS bigint), N''https://cdn.dummyjson.com/product-images/sunglasses/party-glasses/thumbnail.webp'', CAST(27 AS bigint), 0),
    (CAST(31 AS bigint), N''https://cdn.dummyjson.com/product-images/sunglasses/sunglasses/thumbnail.webp'', CAST(28 AS bigint), 0),
    (CAST(32 AS bigint), N''https://cdn.dummyjson.com/product-images/mens-shirts/blue-&-black-check-shirt/thumbnail.webp'', CAST(29 AS bigint), 0),
    (CAST(33 AS bigint), N''https://cdn.dummyjson.com/product-images/mens-shirts/gigabyte-aorus-men-tshirt/thumbnail.webp'', CAST(30 AS bigint), 0),
    (CAST(34 AS bigint), N''https://cdn.dummyjson.com/product-images/mens-shirts/man-plaid-shirt/thumbnail.webp'', CAST(31 AS bigint), 0),
    (CAST(35 AS bigint), N''https://cdn.dummyjson.com/product-images/mens-shirts/man-short-sleeve-shirt/thumbnail.webp'', CAST(32 AS bigint), 0),
    (CAST(36 AS bigint), N''https://cdn.dummyjson.com/product-images/mens-shirts/men-check-shirt/thumbnail.webp'', CAST(33 AS bigint), 0),
    (CAST(37 AS bigint), N''https://cdn.dummyjson.com/product-images/mens-shoes/nike-air-jordan-1-red-and-black/thumbnail.webp'', CAST(34 AS bigint), 0),
    (CAST(38 AS bigint), N''https://cdn.dummyjson.com/product-images/mens-shoes/nike-air-jordan-1-red-and-black/1.webp'', CAST(34 AS bigint), 1),
    (CAST(39 AS bigint), N''https://cdn.dummyjson.com/product-images/mens-shoes/nike-baseball-cleats/thumbnail.webp'', CAST(35 AS bigint), 0),
    (CAST(40 AS bigint), N''https://cdn.dummyjson.com/product-images/mens-shoes/puma-future-rider-trainers/thumbnail.webp'', CAST(36 AS bigint), 0),
    (CAST(41 AS bigint), N''https://cdn.dummyjson.com/product-images/mens-shoes/sports-sneakers-off-white-&-red/thumbnail.webp'', CAST(37 AS bigint), 0),
    (CAST(42 AS bigint), N''https://cdn.dummyjson.com/product-images/mens-shoes/sports-sneakers-off-white-red/thumbnail.webp'', CAST(38 AS bigint), 0);
    INSERT INTO [ProductImages] ([ProductImageId], [ImageUrl], [ProductId], [SortOrder])
    VALUES (CAST(43 AS bigint), N''https://cdn.dummyjson.com/product-images/mens-watches/brown-leather-belt-watch/thumbnail.webp'', CAST(39 AS bigint), 0),
    (CAST(44 AS bigint), N''https://cdn.dummyjson.com/product-images/mens-watches/longines-master-collection/thumbnail.webp'', CAST(40 AS bigint), 0),
    (CAST(45 AS bigint), N''https://cdn.dummyjson.com/product-images/mens-watches/rolex-cellini-date-black-dial/thumbnail.webp'', CAST(41 AS bigint), 0),
    (CAST(46 AS bigint), N''https://cdn.dummyjson.com/product-images/mens-watches/rolex-cellini-date-black-dial/1.webp'', CAST(41 AS bigint), 1),
    (CAST(47 AS bigint), N''https://cdn.dummyjson.com/product-images/mens-watches/rolex-cellini-moonphase/thumbnail.webp'', CAST(42 AS bigint), 0),
    (CAST(48 AS bigint), N''https://cdn.dummyjson.com/product-images/mens-watches/rolex-datejust/thumbnail.webp'', CAST(43 AS bigint), 0),
    (CAST(49 AS bigint), N''https://cdn.dummyjson.com/product-images/mens-watches/rolex-submariner-watch/thumbnail.webp'', CAST(44 AS bigint), 0)');
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'ProductImageId', N'ImageUrl', N'ProductId', N'SortOrder') AND [object_id] = OBJECT_ID(N'[ProductImages]'))
        SET IDENTITY_INSERT [ProductImages] OFF;
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20261106233945_SeedProducts'
)
BEGIN
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'ProductSizeId', N'ProductId', N'Quantity', N'Size', N'UnitsSold') AND [object_id] = OBJECT_ID(N'[ProductSizes]'))
        SET IDENTITY_INSERT [ProductSizes] ON;
    EXEC(N'INSERT INTO [ProductSizes] ([ProductSizeId], [ProductId], [Quantity], [Size], [UnitsSold])
    VALUES (CAST(1 AS bigint), CAST(1 AS bigint), 20, N''XS'', 0),
    (CAST(2 AS bigint), CAST(1 AS bigint), 20, N''S'', 0),
    (CAST(3 AS bigint), CAST(1 AS bigint), 20, N''M'', 0),
    (CAST(4 AS bigint), CAST(1 AS bigint), 20, N''L'', 0),
    (CAST(5 AS bigint), CAST(1 AS bigint), 20, N''XL'', 0),
    (CAST(6 AS bigint), CAST(2 AS bigint), 20, N''XS'', 0),
    (CAST(7 AS bigint), CAST(2 AS bigint), 20, N''S'', 0),
    (CAST(8 AS bigint), CAST(2 AS bigint), 20, N''M'', 0),
    (CAST(9 AS bigint), CAST(2 AS bigint), 20, N''L'', 0),
    (CAST(10 AS bigint), CAST(2 AS bigint), 20, N''XL'', 0),
    (CAST(11 AS bigint), CAST(3 AS bigint), 20, N''XS'', 0),
    (CAST(12 AS bigint), CAST(3 AS bigint), 20, N''S'', 0),
    (CAST(13 AS bigint), CAST(3 AS bigint), 20, N''M'', 0),
    (CAST(14 AS bigint), CAST(3 AS bigint), 20, N''L'', 0),
    (CAST(15 AS bigint), CAST(3 AS bigint), 20, N''XL'', 0),
    (CAST(16 AS bigint), CAST(4 AS bigint), 20, N''XS'', 0),
    (CAST(17 AS bigint), CAST(4 AS bigint), 20, N''S'', 0),
    (CAST(18 AS bigint), CAST(4 AS bigint), 20, N''M'', 0),
    (CAST(19 AS bigint), CAST(4 AS bigint), 20, N''L'', 0),
    (CAST(20 AS bigint), CAST(4 AS bigint), 20, N''XL'', 0),
    (CAST(21 AS bigint), CAST(5 AS bigint), 20, N''XS'', 0),
    (CAST(22 AS bigint), CAST(5 AS bigint), 20, N''S'', 0),
    (CAST(23 AS bigint), CAST(5 AS bigint), 20, N''M'', 0),
    (CAST(24 AS bigint), CAST(5 AS bigint), 20, N''L'', 0),
    (CAST(25 AS bigint), CAST(5 AS bigint), 20, N''XL'', 0),
    (CAST(26 AS bigint), CAST(6 AS bigint), 20, N''XS'', 0),
    (CAST(27 AS bigint), CAST(6 AS bigint), 20, N''S'', 0),
    (CAST(28 AS bigint), CAST(6 AS bigint), 20, N''M'', 0),
    (CAST(29 AS bigint), CAST(6 AS bigint), 20, N''L'', 0),
    (CAST(30 AS bigint), CAST(6 AS bigint), 20, N''XL'', 0),
    (CAST(31 AS bigint), CAST(7 AS bigint), 20, N''XS'', 0),
    (CAST(32 AS bigint), CAST(7 AS bigint), 20, N''S'', 0),
    (CAST(33 AS bigint), CAST(7 AS bigint), 20, N''M'', 0),
    (CAST(34 AS bigint), CAST(7 AS bigint), 20, N''L'', 0),
    (CAST(35 AS bigint), CAST(7 AS bigint), 20, N''XL'', 0),
    (CAST(36 AS bigint), CAST(8 AS bigint), 20, N''XS'', 0),
    (CAST(37 AS bigint), CAST(8 AS bigint), 20, N''S'', 0),
    (CAST(38 AS bigint), CAST(8 AS bigint), 20, N''M'', 0),
    (CAST(39 AS bigint), CAST(8 AS bigint), 20, N''L'', 0),
    (CAST(40 AS bigint), CAST(8 AS bigint), 20, N''XL'', 0),
    (CAST(41 AS bigint), CAST(9 AS bigint), 20, N''XS'', 0),
    (CAST(42 AS bigint), CAST(9 AS bigint), 20, N''S'', 0);
    INSERT INTO [ProductSizes] ([ProductSizeId], [ProductId], [Quantity], [Size], [UnitsSold])
    VALUES (CAST(43 AS bigint), CAST(9 AS bigint), 20, N''M'', 0),
    (CAST(44 AS bigint), CAST(9 AS bigint), 20, N''L'', 0),
    (CAST(45 AS bigint), CAST(9 AS bigint), 20, N''XL'', 0),
    (CAST(46 AS bigint), CAST(10 AS bigint), 20, N''XS'', 0),
    (CAST(47 AS bigint), CAST(10 AS bigint), 20, N''S'', 0),
    (CAST(48 AS bigint), CAST(10 AS bigint), 20, N''M'', 0),
    (CAST(49 AS bigint), CAST(10 AS bigint), 20, N''L'', 0),
    (CAST(50 AS bigint), CAST(10 AS bigint), 20, N''XL'', 0),
    (CAST(51 AS bigint), CAST(11 AS bigint), 20, N''6'', 0),
    (CAST(52 AS bigint), CAST(11 AS bigint), 20, N''7'', 0),
    (CAST(53 AS bigint), CAST(11 AS bigint), 20, N''8'', 0),
    (CAST(54 AS bigint), CAST(11 AS bigint), 20, N''9'', 0),
    (CAST(55 AS bigint), CAST(11 AS bigint), 20, N''10'', 0),
    (CAST(56 AS bigint), CAST(11 AS bigint), 20, N''11'', 0),
    (CAST(57 AS bigint), CAST(12 AS bigint), 20, N''6'', 0),
    (CAST(58 AS bigint), CAST(12 AS bigint), 20, N''7'', 0),
    (CAST(59 AS bigint), CAST(12 AS bigint), 20, N''8'', 0),
    (CAST(60 AS bigint), CAST(12 AS bigint), 20, N''9'', 0),
    (CAST(61 AS bigint), CAST(12 AS bigint), 20, N''10'', 0),
    (CAST(62 AS bigint), CAST(12 AS bigint), 20, N''11'', 0),
    (CAST(63 AS bigint), CAST(13 AS bigint), 20, N''6'', 0),
    (CAST(64 AS bigint), CAST(13 AS bigint), 20, N''7'', 0),
    (CAST(65 AS bigint), CAST(13 AS bigint), 20, N''8'', 0),
    (CAST(66 AS bigint), CAST(13 AS bigint), 20, N''9'', 0),
    (CAST(67 AS bigint), CAST(13 AS bigint), 20, N''10'', 0),
    (CAST(68 AS bigint), CAST(13 AS bigint), 20, N''11'', 0),
    (CAST(69 AS bigint), CAST(14 AS bigint), 20, N''6'', 0),
    (CAST(70 AS bigint), CAST(14 AS bigint), 20, N''7'', 0),
    (CAST(71 AS bigint), CAST(14 AS bigint), 20, N''8'', 0),
    (CAST(72 AS bigint), CAST(14 AS bigint), 20, N''9'', 0),
    (CAST(73 AS bigint), CAST(14 AS bigint), 20, N''10'', 0),
    (CAST(74 AS bigint), CAST(14 AS bigint), 20, N''11'', 0),
    (CAST(75 AS bigint), CAST(15 AS bigint), 20, N''6'', 0),
    (CAST(76 AS bigint), CAST(15 AS bigint), 20, N''7'', 0),
    (CAST(77 AS bigint), CAST(15 AS bigint), 20, N''8'', 0),
    (CAST(78 AS bigint), CAST(15 AS bigint), 20, N''9'', 0),
    (CAST(79 AS bigint), CAST(15 AS bigint), 20, N''10'', 0),
    (CAST(80 AS bigint), CAST(15 AS bigint), 20, N''11'', 0),
    (CAST(81 AS bigint), CAST(16 AS bigint), 20, N''One Size'', 0),
    (CAST(82 AS bigint), CAST(17 AS bigint), 20, N''One Size'', 0),
    (CAST(83 AS bigint), CAST(18 AS bigint), 20, N''One Size'', 0),
    (CAST(84 AS bigint), CAST(19 AS bigint), 20, N''One Size'', 0);
    INSERT INTO [ProductSizes] ([ProductSizeId], [ProductId], [Quantity], [Size], [UnitsSold])
    VALUES (CAST(85 AS bigint), CAST(20 AS bigint), 20, N''One Size'', 0),
    (CAST(86 AS bigint), CAST(21 AS bigint), 20, N''One Size'', 0),
    (CAST(87 AS bigint), CAST(22 AS bigint), 20, N''One Size'', 0),
    (CAST(88 AS bigint), CAST(23 AS bigint), 20, N''One Size'', 0),
    (CAST(89 AS bigint), CAST(24 AS bigint), 20, N''One Size'', 0),
    (CAST(90 AS bigint), CAST(25 AS bigint), 20, N''One Size'', 0),
    (CAST(91 AS bigint), CAST(26 AS bigint), 20, N''One Size'', 0),
    (CAST(92 AS bigint), CAST(27 AS bigint), 20, N''One Size'', 0),
    (CAST(93 AS bigint), CAST(28 AS bigint), 20, N''One Size'', 0),
    (CAST(94 AS bigint), CAST(29 AS bigint), 20, N''XS'', 0),
    (CAST(95 AS bigint), CAST(29 AS bigint), 20, N''S'', 0),
    (CAST(96 AS bigint), CAST(29 AS bigint), 20, N''M'', 0),
    (CAST(97 AS bigint), CAST(29 AS bigint), 20, N''L'', 0),
    (CAST(98 AS bigint), CAST(29 AS bigint), 20, N''XL'', 0),
    (CAST(99 AS bigint), CAST(30 AS bigint), 20, N''XS'', 0),
    (CAST(100 AS bigint), CAST(30 AS bigint), 20, N''S'', 0),
    (CAST(101 AS bigint), CAST(30 AS bigint), 20, N''M'', 0),
    (CAST(102 AS bigint), CAST(30 AS bigint), 20, N''L'', 0),
    (CAST(103 AS bigint), CAST(30 AS bigint), 20, N''XL'', 0),
    (CAST(104 AS bigint), CAST(31 AS bigint), 20, N''XS'', 0),
    (CAST(105 AS bigint), CAST(31 AS bigint), 20, N''S'', 0),
    (CAST(106 AS bigint), CAST(31 AS bigint), 20, N''M'', 0),
    (CAST(107 AS bigint), CAST(31 AS bigint), 20, N''L'', 0),
    (CAST(108 AS bigint), CAST(31 AS bigint), 20, N''XL'', 0),
    (CAST(109 AS bigint), CAST(32 AS bigint), 20, N''XS'', 0),
    (CAST(110 AS bigint), CAST(32 AS bigint), 20, N''S'', 0),
    (CAST(111 AS bigint), CAST(32 AS bigint), 20, N''M'', 0),
    (CAST(112 AS bigint), CAST(32 AS bigint), 20, N''L'', 0),
    (CAST(113 AS bigint), CAST(32 AS bigint), 20, N''XL'', 0),
    (CAST(114 AS bigint), CAST(33 AS bigint), 20, N''XS'', 0),
    (CAST(115 AS bigint), CAST(33 AS bigint), 20, N''S'', 0),
    (CAST(116 AS bigint), CAST(33 AS bigint), 20, N''M'', 0),
    (CAST(117 AS bigint), CAST(33 AS bigint), 20, N''L'', 0),
    (CAST(118 AS bigint), CAST(33 AS bigint), 20, N''XL'', 0),
    (CAST(119 AS bigint), CAST(34 AS bigint), 20, N''6'', 0),
    (CAST(120 AS bigint), CAST(34 AS bigint), 20, N''7'', 0),
    (CAST(121 AS bigint), CAST(34 AS bigint), 20, N''8'', 0),
    (CAST(122 AS bigint), CAST(34 AS bigint), 20, N''9'', 0),
    (CAST(123 AS bigint), CAST(34 AS bigint), 20, N''10'', 0),
    (CAST(124 AS bigint), CAST(34 AS bigint), 20, N''11'', 0),
    (CAST(125 AS bigint), CAST(34 AS bigint), 20, N''12'', 0),
    (CAST(126 AS bigint), CAST(35 AS bigint), 20, N''6'', 0);
    INSERT INTO [ProductSizes] ([ProductSizeId], [ProductId], [Quantity], [Size], [UnitsSold])
    VALUES (CAST(127 AS bigint), CAST(35 AS bigint), 20, N''7'', 0),
    (CAST(128 AS bigint), CAST(35 AS bigint), 20, N''8'', 0),
    (CAST(129 AS bigint), CAST(35 AS bigint), 20, N''9'', 0),
    (CAST(130 AS bigint), CAST(35 AS bigint), 20, N''10'', 0),
    (CAST(131 AS bigint), CAST(35 AS bigint), 20, N''11'', 0),
    (CAST(132 AS bigint), CAST(35 AS bigint), 20, N''12'', 0),
    (CAST(133 AS bigint), CAST(36 AS bigint), 20, N''6'', 0),
    (CAST(134 AS bigint), CAST(36 AS bigint), 20, N''7'', 0),
    (CAST(135 AS bigint), CAST(36 AS bigint), 20, N''8'', 0),
    (CAST(136 AS bigint), CAST(36 AS bigint), 20, N''9'', 0),
    (CAST(137 AS bigint), CAST(36 AS bigint), 20, N''10'', 0),
    (CAST(138 AS bigint), CAST(36 AS bigint), 20, N''11'', 0),
    (CAST(139 AS bigint), CAST(36 AS bigint), 20, N''12'', 0),
    (CAST(140 AS bigint), CAST(37 AS bigint), 20, N''6'', 0),
    (CAST(141 AS bigint), CAST(37 AS bigint), 20, N''7'', 0),
    (CAST(142 AS bigint), CAST(37 AS bigint), 20, N''8'', 0),
    (CAST(143 AS bigint), CAST(37 AS bigint), 20, N''9'', 0),
    (CAST(144 AS bigint), CAST(37 AS bigint), 20, N''10'', 0),
    (CAST(145 AS bigint), CAST(37 AS bigint), 20, N''11'', 0),
    (CAST(146 AS bigint), CAST(37 AS bigint), 20, N''12'', 0),
    (CAST(147 AS bigint), CAST(38 AS bigint), 20, N''6'', 0),
    (CAST(148 AS bigint), CAST(38 AS bigint), 20, N''7'', 0),
    (CAST(149 AS bigint), CAST(38 AS bigint), 20, N''8'', 0),
    (CAST(150 AS bigint), CAST(38 AS bigint), 20, N''9'', 0),
    (CAST(151 AS bigint), CAST(38 AS bigint), 20, N''10'', 0),
    (CAST(152 AS bigint), CAST(38 AS bigint), 20, N''11'', 0),
    (CAST(153 AS bigint), CAST(38 AS bigint), 20, N''12'', 0),
    (CAST(154 AS bigint), CAST(39 AS bigint), 20, N''One Size'', 0),
    (CAST(155 AS bigint), CAST(40 AS bigint), 20, N''One Size'', 0),
    (CAST(156 AS bigint), CAST(41 AS bigint), 20, N''One Size'', 0),
    (CAST(157 AS bigint), CAST(42 AS bigint), 20, N''One Size'', 0),
    (CAST(158 AS bigint), CAST(43 AS bigint), 20, N''One Size'', 0),
    (CAST(159 AS bigint), CAST(44 AS bigint), 20, N''One Size'', 0)');
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'ProductSizeId', N'ProductId', N'Quantity', N'Size', N'UnitsSold') AND [object_id] = OBJECT_ID(N'[ProductSizes]'))
        SET IDENTITY_INSERT [ProductSizes] OFF;
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20261106233945_SeedProducts'
)
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20261106233945_SeedProducts', N'10.0.12');
END;

COMMIT;
GO

