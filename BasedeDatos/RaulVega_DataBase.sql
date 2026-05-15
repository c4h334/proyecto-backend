
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
-- Datos Cliente 
-- ============================================================
INSERT INTO Customers (FullName, Identification, Phone, HomeAddress, Email)
VALUES
('María Fernández', '304560123', '87651234', 'Desamparados', 'maria@gmail.com'),
('Carlos Ramírez', '112233445', '83334444', 'Hatillo', 'carlos@hotmail.com'),
('Ana López', '223344556', '88887777', 'Pavas', 'ana@gmail.com'),
('Andrey Vargas', '334455667', '85556666', 'Matina', 'andrey@gmail.com'),
('Sofía Castillo', '445566778', '82223344', 'San Vicente', 'sofia@gmail.com'),
('Rosa Mora', '556677889', '81112233', 'Santa Lucía', 'rosa@gmail.com'),
('Valeria Rojas', '667788990', '89998888', 'San Roque', 'valeria@gmail.com');


-- ============================================================
-- Datos Productos
-- ============================================================
INSERT INTO Products
(Name, Description, Quantity, Price, Code, Image, Available, Discount, DiscountQuantity, Material)
VALUES
('Laptop Dell', 'Laptop Inspiron 15', 10, 550000, 'P001', 'https://www.ebay.com/itm/305682075981?_ul=CR', 1, 0, 0, 'Aluminio'),

('Mouse Logitech', 'Mouse inalámbrico', 25, 15000, 'P002', 'https://www.rottler.com/pests/rodents/meadow-mouse/', 1, 0, 0, 'Plástico');

-- ============================================================
-- Datos Proveedores 
-- ============================================================
INSERT INTO Suppliers
(CompanyName, LegalId, Location, Phone, Email, ProductList)
VALUES
('Tech Supplies CR', '3101122233', 'San José', '22223333', 'tech@supplies.com',
'Laptop Dell, Mouse Logitech'),

('Importadora Digital', '3102233344', 'Heredia', '24445555', 'ventas@digital.com',
'Teclado Redragon, Monitor Samsung');
