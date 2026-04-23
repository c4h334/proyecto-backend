
IF DB_ID('RaulVega') IS NOT NULL
BEGIN
    DROP DATABASE [RaulVega];
END

CREATE DATABASE [RaulVega];
USE [RaulVega];

-- ============================================================
-- PRODUCTS TABLE
-- ============================================================
DROP TABLE IF EXISTS [Products];
CREATE TABLE [Products] (
    ProductId           INT NOT NULL IDENTITY PRIMARY KEY CLUSTERED,
    ProductResourceId   UNIQUEIDENTIFIER NOT NULL DEFAULT NEWID(),
    Name                NVARCHAR(100)  NOT NULL,
    Description         NVARCHAR(255),
    Quantity            INT            NOT NULL DEFAULT 0,
    Price               DECIMAL(10,2)  NOT NULL,
    Code                NVARCHAR(50)   NOT NULL UNIQUE,
    Image               NVARCHAR(500),
    Available           BIT            NOT NULL DEFAULT 1,
    Discount            DECIMAL(5,2)   DEFAULT 0,
    DiscountQuantity    INT            DEFAULT 0,
    Material            NVARCHAR(100)
);

-- ============================================================
-- CUSTOMERS TABLE
-- ============================================================
DROP TABLE IF EXISTS [Customers];
CREATE TABLE [Customers] (
    CustomerId          INT NOT NULL IDENTITY PRIMARY KEY CLUSTERED,
    CustomerResourceId  UNIQUEIDENTIFIER NOT NULL DEFAULT NEWID(),
    FullName            NVARCHAR(150)  NOT NULL,
    Identification      NVARCHAR(20)   NOT NULL UNIQUE,
    Phone               NVARCHAR(20),
    HomeAddress         NVARCHAR(255),
    Email               NVARCHAR(100)
);

-- ============================================================
-- SUPPLIERS TABLE
-- ============================================================
DROP TABLE IF EXISTS [Suppliers];
CREATE TABLE [Suppliers] (
    SupplierId          INT NOT NULL IDENTITY PRIMARY KEY CLUSTERED,
    SupplierResourceId  UNIQUEIDENTIFIER NOT NULL DEFAULT NEWID(),
    CompanyName         NVARCHAR(150)  NOT NULL,
    LegalId             NVARCHAR(20)   NOT NULL UNIQUE,
    Location            NVARCHAR(255),
    Phone               NVARCHAR(20),
    Email               NVARCHAR(100),
    ProductList         NVARCHAR(500)
);

-- ============================================================
-- Pruebas
-- ============================================================
INSERT INTO [Products] (Name, Description, Quantity, Price, Code, Available, Material)
VALUES 
('White T-Shirt', 'Size M, cotton', 20, 8500.00, 'PROD-001', 1, 'Cotton'),
('Blue Jeans', 'Size 32, slim fit', 15, 25000.00, 'PROD-002', 1, 'Denim');

INSERT INTO [Customers] (FullName, Identification, Phone, Email)
VALUES 
('María Fernández', '304560123', '87651234', 'maria@gmail.com'),
('Carlos Ramírez', '112233445', '83334444', 'carlos@hotmail.com');

INSERT INTO [Suppliers] (CompanyName, LegalId, Phone, Email, ProductList)
VALUES 
('Textiles S.A.', '3-101-654321', '22345678', 'sales@textiles.com', 'T-shirts, jeans');


SELECT * FROM Products;