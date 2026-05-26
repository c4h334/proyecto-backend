
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
('Valeria Rojas', '667788990', '89998888', 'San Roque', 'valeria@gmail.com'),
('Daniel Pérez', '778899001', '87776655', 'Cartago', 'daniel@gmail.com'),
('Lucía Jiménez', '889900112', '86665544', 'Alajuela', 'lucia@gmail.com'),
('Kevin Solano', '990011223', '85554433', 'Liberia', 'kevin@gmail.com');


-- ============================================================
-- Datos Productos
-- ============================================================
INSERT INTO Products
(Name, Description, Quantity, Price, Code, Image, Available, Discount, DiscountQuantity, Material)
VALUES
('Laptop Dell', 'Laptop Inspiron 15', 10, 550000, 'P001', 'https://picsum.photos/300/200', 1, 0, 0, 'Aluminio'),

('Mouse Logitech', 'Mouse inalámbrico', 25, 15000, 'P002', 'https://picsum.photos/300/201', 1, 0, 0, 'Plástico'),

('Teclado Redragon', 'Teclado mecánico RGB', 15, 35000, 'P003', 'https://picsum.photos/300/202', 1, 5, 2, 'Plástico'),

('Monitor Samsung', 'Monitor 24 pulgadas Full HD', 8, 120000, 'P004', 'https://picsum.photos/300/203', 1, 10, 1, 'Metal'),

('Audífonos Sony', 'Audífonos inalámbricos', 20, 45000, 'P005', 'https://picsum.photos/300/204', 1, 0, 0, 'Plástico'),

('Silla Gamer', 'Silla ergonómica gamer', 5, 98000, 'P006', 'https://picsum.photos/300/205', 1, 15, 1, 'Cuero'),

('Tablet Samsung', 'Tablet Galaxy Tab S9', 12, 320000, 'P007', 'https://picsum.photos/300/206', 1, 0, 0, 'Aluminio'),

('Disco SSD Kingston', 'SSD 1TB NVMe', 18, 65000, 'P008', 'https://picsum.photos/300/207', 1, 8, 2, 'Metal'),

('Impresora Epson', 'Impresora multifuncional', 6, 89000, 'P009', 'https://picsum.photos/300/208', 1, 0, 0, 'Plástico'),

('Webcam Logitech', 'Webcam HD 1080p', 30, 27000, 'P010', 'https://picsum.photos/300/209', 1, 5, 3, 'Plástico');
-- ============================================================
-- Datos Proveedores 
-- ============================================================
INSERT INTO Suppliers
(CompanyName, LegalId, Location, Phone, Email, ProductList)
VALUES
('Tech Supplies CR', '3101122233', 'San José', '22223333', 'tech@supplies.com',
'Laptop Dell, Mouse Logitech'),

('Importadora Digital', '3102233344', 'Heredia', '24445555', 'ventas@digital.com',
'Teclado Redragon, Monitor Samsung'),

('Electronix CR', '3103344455', 'Cartago', '25556666', 'info@electronix.com',
'Audífonos Sony, Webcam Logitech'),

('Gaming World', '3104455566', 'Alajuela', '26667777', 'gaming@world.com',
'Silla Gamer, Teclado Redragon'),

('Office Tech', '3105566677', 'Puntarenas', '27778888', 'office@tech.com',
'Impresora Epson, Monitor Samsung'),

('Smart Devices', '3106677788', 'Limón', '28889999', 'smart@devices.com',
'Tablet Samsung, Disco SSD Kingston'),

('CompuStore', '3107788899', 'Heredia', '29990000', 'ventas@compustore.com',
'Laptop Dell, SSD Kingston'),

('Mega Solutions', '3108899900', 'San Carlos', '21112222', 'mega@solutions.com',
'Mouse Logitech, Webcam Logitech'),

('Digital Imports', '3109900011', 'Escazú', '23334444', 'imports@digital.com',
'Tablet Samsung, Audífonos Sony'),

('Nova Tecnología', '3110011122', 'Curridabat', '25553333', 'nova@tecnologia.com',
'Monitor Samsung, Impresora Epson');
