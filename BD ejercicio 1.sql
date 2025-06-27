CREATE DATABASE ProductosDb;
GO

USE ProductosDb;
GO

CREATE TABLE Categorias (
    CategoriaId INT PRIMARY KEY IDENTITY(1,1),
    Nombre NVARCHAR(100) NOT NULL
);

CREATE TABLE Proveedores (
    ProveedorId INT PRIMARY KEY IDENTITY(1,1),
    Nombre NVARCHAR(150) NOT NULL,
    Telefono NVARCHAR(20),
    Email NVARCHAR(100)
);

CREATE TABLE UnidadesMedida (
    UnidadId INT PRIMARY KEY IDENTITY(1,1),
    Nombre NVARCHAR(50) NOT NULL
);

CREATE TABLE Productos (
    ProductoId INT PRIMARY KEY IDENTITY(1,1),
    Nombre NVARCHAR(150) NOT NULL,
    Precio DECIMAL(18,2) NOT NULL,
    Stock INT NOT NULL,
    CategoriaId INT NOT NULL,
    ProveedorId INT NOT NULL,
    UnidadId INT NOT NULL,
    FechaRegistro DATETIME NOT NULL DEFAULT GETDATE(),

    FOREIGN KEY (CategoriaId) REFERENCES Categorias(CategoriaId),
    FOREIGN KEY (ProveedorId) REFERENCES Proveedores(ProveedorId),
    FOREIGN KEY (UnidadId) REFERENCES UnidadesMedida(UnidadId)
);
