
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
-- ROLES TABLE
-- ============================================================

CREATE TABLE Roles (
    RoleId INT IDENTITY(1,1) PRIMARY KEY,
    RoleResourceId UNIQUEIDENTIFIER NOT NULL DEFAULT NEWID(),
    Name NVARCHAR(100) NOT NULL UNIQUE
);

-- ============================================================
-- USERS TABLE
-- ============================================================

CREATE TABLE Users (
    UserId INT IDENTITY(1,1) PRIMARY KEY,
    UserResourceId UNIQUEIDENTIFIER NOT NULL DEFAULT NEWID(),
    Name NVARCHAR(100) NOT NULL,
    Username NVARCHAR(50) NOT NULL UNIQUE,
    Email NVARCHAR(100) NOT NULL UNIQUE,
    PasswordHash NVARCHAR(255) NOT NULL
);


-- ============================================================
-- USER ROLES TABLE
-- ============================================================

CREATE TABLE UserRoles (
    UserId INT NOT NULL,
    RoleId INT NOT NULL,
    UserRoleResourceId UNIQUEIDENTIFIER NOT NULL DEFAULT NEWID(),

    PRIMARY KEY (UserId, RoleId),

    FOREIGN KEY (UserId) REFERENCES Users(UserId),
    FOREIGN KEY (RoleId) REFERENCES Roles(RoleId)
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
('Laptop Dell', 'Laptop Inspiron 15', 10, 550000, 'P001', 'https://i5.walmartimages.com/asr/707defde-6782-4af5-b154-e73d6dcab835.7205df4d9a432cdef2995e6a69a42429.jpeg', 1, 0, 0, 'Aluminio'),

('Mouse Logitech', 'Mouse inalámbrico', 25, 15000, 'P002', 'https://i.pinimg.com/736x/ae/05/ab/ae05abcca196c4a5b082ccebdf546e4f.jpg', 1, 0, 0, 'Plástico'),

('Teclado Redragon', 'Teclado mecánico RGB', 15, 35000, 'P003', 'https://extremetechcr.com/wp-content/uploads/2024/11/37888.jpg', 1, 5, 2, 'Plástico'),

('Monitor Samsung', 'Monitor 24 pulgadas Full HD', 8, 120000, 'P004', 'https://m.media-amazon.com/images/I/91aS-5urQLL._AC_UF894,1000_QL80_.jpg', 1, 10, 1, 'Metal'),

('Audífonos Sony', 'Audífonos inalámbricos', 20, 45000, 'P005', 'https://www.intelec.co.cr/wp-content/uploads/2024/08/WH-CH720P-768x768.webp', 1, 0, 0, 'Plástico'),

('Silla Gamer', 'Silla ergonómica gamer', 5, 98000, 'P006', 'https://media.nidux.net/pull/700/700/3259/138261-product-6080acad742b5-img-0978-copia.jpg', 1, 15, 1, 'Cuero'),

('Tablet Samsung', 'Tablet Galaxy Tab S9', 12, 320000, 'P007', 'https://d3l40gffhwe96q.cloudfront.net/products/e4a7dde0-a125-45d0-bf9f-f2395441d6d8.jpg', 1, 0, 0, 'Aluminio'),

('Juguete Jellycat', 'Peluche temático de conejo', 18, 65000, 'P008', 'https://curolletes.com/wp-content/uploads/2026/02/Jellycat-Fawn-Flufflet-Bunny-Curolletes.jpg', 1, 8, 2, 'Algodón'),

('Sofá Roche Bobois y Minotti', 'Sofá de 3 plazas', 6, 89000, 'P009', 'https://www.miliboo.es/sofa-3-plazas-de-tela-beige-y-madera-clara-munik-53609-6847f20c05679_1200_800_0.jpg', 1, 0, 0, 'Lino'),

('Tinta de labios Maybelline', 'Maybelline Super Stay Teddy Tint', 30, 27000, 'P010', 'https://casitadelmaquillaje.com/wp-content/uploads/2025/02/56ecb3e9-165f-4e7b-966d-f8f24614ac60.jpeg', 1, 5, 3, 'Maquillaje');
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


-- ============================================================
-- Creación de roles 
-- ============================================================
INSERT INTO Roles (Name)
VALUES
('Administrator'),
('Customer'),
('Support');



INSERT INTO UserRoles
(
    UserId,
    RoleId
)
VALUES
(
    1,
    1
);

INSERT INTO UserRoles
(
    UserId,
    RoleId
)
VALUES
(
    2,
    2
);

