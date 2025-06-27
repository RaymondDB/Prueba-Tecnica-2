CREATE DATABASE ProductosDb2;
GO

USE ProductosDb2;
GO

CREATE TABLE Categorias (
    CategoriaId INT PRIMARY KEY IDENTITY(1,1),
    Nombre NVARCHAR(100) NOT NULL
);

CREATE TABLE Productos (
    ProductoId INT PRIMARY KEY IDENTITY(1,1),
    Nombre NVARCHAR(100) NOT NULL,
    Precio DECIMAL(10, 2) NOT NULL,
    Stock INT NOT NULL,
    CategoriaId INT NOT NULL,
    FOREIGN KEY (CategoriaId) REFERENCES Categorias(CategoriaId)
);

CREATE TABLE Ventas (
    VentaId INT PRIMARY KEY IDENTITY(1,1),
    ProductoId INT NOT NULL,
    Fecha DATE NOT NULL,
    Cantidad INT NOT NULL,
    FOREIGN KEY (ProductoId) REFERENCES Productos(ProductoId)
);

INSERT INTO Categorias (Nombre) VALUES
('Electrónica'),
('Hogar'),
('Deportes');

INSERT INTO Productos (Nombre, Precio, Stock, CategoriaId) VALUES
('Laptop', 1500.00, 5, 1),
('Smartphone', 800.00, 10, 1),
('Televisor', 1200.00, 2, 1),
('Aspiradora', 200.00, 8, 2),
('Licuadora', 75.00, 15, 2),
('Pelota', 25.00, 50, 3),
('Bicicleta', 350.00, 4, 3),
('Raqueta', 60.00, 20, 3);

INSERT INTO Ventas (ProductoId, Fecha, Cantidad) VALUES
(1, '2024-06-28', 2),  
(2, '2024-06-28', 1),  
(4, '2024-06-28', 3),  
(6, '2024-06-28', 10); 


