DROP TABLE IF EXISTS dbo.ProductCategory;
DROP TABLE IF EXISTS dbo.Category;
DROP TABLE IF EXISTS dbo.Product;

CREATE TABLE dbo.Category (
    [Id] INT PRIMARY KEY,
    [Title] VARCHAR(200) NOT NULL
    );

CREATE TABLE dbo.Product (
    [Id] INT PRIMARY KEY,
    [Title] VARCHAR(200) NOT NULL
    );

CREATE TABLE  dbo.ProductCategory (
    [ProductId] INT NOT NULL,
    [CategoryId] INT NOT NULL,
     FOREIGN KEY ([ProductId]) REFERENCES dbo.Product([Id]),
     FOREIGN KEY ([CategoryId]) REFERENCES dbo.Category([Id]),
     PRIMARY KEY ([ProductId], [CategoryId])
);

-- ExecuteListCommand_InsertAndCheckResults_SingleProductWithManyCategories
INSERT INTO dbo.Category([Id], [Title]) VALUES (1, '1'), (2, '2'), (3, '3');
INSERT INTO dbo.Product([Id], [Title]) VALUES (1, '1');
INSERT INTO dbo.ProductCategory([ProductId], [CategoryId]) VALUES (1, 1), (1, 2), (1, 3);
select * from Product;
select * from ProductCategory;
select * from Category;

SELECT CASE
           WHEN c.[Title] IS NULL THEN p.[Title]
           ELSE  CONCAT(p.[Title], ' - ', c.[Title])
           END AS Title
FROM dbo.Product AS p
         LEFT JOIN dbo.ProductCategory pc ON pc.[ProductId] = p.[Id]
         LEFT JOIN dbo.Category c ON pc.[CategoryId] = c.[Id]
ORDER BY 1;



DELETE FROM dbo.ProductCategory;
DELETE FROM dbo.Category;
DELETE FROM dbo.Product;



-- ExecuteListCommand_InsertAndCheckResults_ThreeProductsEachWithItsOwnCategory
INSERT INTO dbo.Category([Id], [Title]) VALUES (1, '1'), (2, '2'), (3, '3');
INSERT INTO dbo.Product([Id], [Title]) VALUES (1, '1'), (2, '2'), (3, '3');
INSERT INTO dbo.ProductCategory([ProductId], [CategoryId]) VALUES (1, 1), (2, 2), (3, 3);
SELECT CASE
           WHEN c.[Title] IS NULL THEN p.[Title]
           ELSE  CONCAT(p.[Title], ' - ', c.[Title])
           END AS Title
FROM dbo.Product AS p
         LEFT JOIN dbo.ProductCategory pc ON pc.[ProductId] = p.[Id]
         LEFT JOIN dbo.Category c ON pc.[CategoryId] = c.[Id]
ORDER BY 1;



DELETE FROM dbo.ProductCategory;
DELETE FROM dbo.Category;
DELETE FROM dbo.Product;



-- ExecuteListCommand_InsertAndCheckResults_SingleProductWithManyCategoriesAndTwoWithoutCategories
INSERT INTO dbo.Category([Id], [Title]) VALUES (1, '1'), (2, '2'), (3, '3');
INSERT INTO dbo.Product([Id], [Title]) VALUES (1, '1'), (2, '2'), (3, '3');
INSERT INTO dbo.ProductCategory([ProductId], [CategoryId]) VALUES (1, 1), (1, 2), (1, 3);
SELECT CASE
           WHEN c.[Title] IS NULL THEN p.[Title]
           ELSE  CONCAT(p.[Title], ' - ', c.[Title])
           END AS Title
FROM dbo.Product AS p
         LEFT JOIN dbo.ProductCategory pc ON pc.[ProductId] = p.[Id]
         LEFT JOIN dbo.Category c ON pc.[CategoryId] = c.[Id]
ORDER BY 1;



DELETE FROM dbo.ProductCategory;
DELETE FROM dbo.Category;
DELETE FROM dbo.Product;