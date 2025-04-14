CREATE TABLE Usuarios (
    UsuarioID INT IDENTITY(1,1) PRIMARY KEY,
    NombreUsuario VARCHAR(50) NOT NULL UNIQUE,
    Contrasena VARCHAR(64) NOT NULL
);

CREATE TABLE Productos (
    ProductoID INT IDENTITY(1,1) PRIMARY KEY,
    Nombre VARCHAR(100) NOT NULL,
    Descripcion VARCHAR(255),
    Precio DECIMAL(10, 2) NOT NULL,
    StockActual INT NOT NULL DEFAULT 0
);

CREATE TABLE MovimientosInventario (
    MovimientoID INT IDENTITY(1,1) PRIMARY KEY,
    ProductoID INT NOT NULL,
    TipoMovimiento VARCHAR(10) NOT NULL CHECK (TipoMovimiento IN ('Entrada', 'Salida')),
    Cantidad INT NOT NULL CHECK (Cantidad > 0),
    FechaMovimiento DATETIME NOT NULL DEFAULT GETDATE(),
    FOREIGN KEY (ProductoID) REFERENCES Productos(ProductoID) ON DELETE CASCADE
);

-- Usuario de prueba
INSERT INTO Usuarios (NombreUsuario, Contrasena)
VALUES ('admin', '8c6976e5b5410415bde908bd4dee15dfb167a9c873fc4bb8a81f6f2ab448a918'); -- 'admin' en SHA256

-- Procedimientos para la creación y validación de usuarios
-- Insertar nuevo usuario
CREATE PROCEDURE sp_InsertarUsuario

    @NombreUsuario VARCHAR(50),
    @Contrasena VARCHAR(64)
AS
BEGIN
    INSERT INTO Usuarios (NombreUsuario, Contrasena)
    VALUES (@NombreUsuario, @Contrasena);
END;
GO

-- Validar login
CREATE PROCEDURE sp_ValidarLogin
    @NombreUsuario VARCHAR(50),
    @Contrasena VARCHAR(64)
AS
BEGIN
    SELECT UsuarioID, NombreUsuario
    FROM Usuarios
    WHERE NombreUsuario = @NombreUsuario AND Contrasena = @Contrasena;
END;
GO

-- Procedimientos para el CRUD de la tabla Productos
-- Insertar producto
CREATE PROCEDURE sp_InsertarProducto
    @Nombre VARCHAR(100),
    @Descripcion VARCHAR(255),
    @Precio DECIMAL(10, 2),
    @StockInicial INT
AS
BEGIN
    INSERT INTO Productos (Nombre, Descripcion, Precio, StockActual)
    VALUES (@Nombre, @Descripcion, @Precio, @StockInicial);
END;
GO

-- Actualizar producto
CREATE PROCEDURE sp_ActualizarProducto
    @ProductoID INT,
    @Nombre VARCHAR(100),
    @Descripcion VARCHAR(255),
    @Precio DECIMAL(10, 2),
	@StockActual INT
AS
BEGIN
    UPDATE Productos
    SET Nombre = @Nombre,
        Descripcion = @Descripcion,
        Precio = @Precio,
		StockActual = @StockActual
    WHERE ProductoID = @ProductoID;
END;
GO

-- Eliminar producto
CREATE PROCEDURE sp_EliminarProducto
    @ProductoID INT
AS
BEGIN
    DELETE FROM Productos WHERE ProductoID = @ProductoID;
END;
GO

-- Obtener lista de productos
CREATE PROCEDURE sp_ObtenerProductos
AS
BEGIN
    SELECT * FROM Productos;
END;
GO

-- Procedimiento para registrar movimientos
CREATE PROCEDURE sp_RegistrarMovimiento
    @ProductoID INT,
    @TipoMovimiento VARCHAR(10), -- 'Entrada' o 'Salida'
    @Cantidad INT
AS
BEGIN
    SET NOCOUNT ON;

    BEGIN TRY
        BEGIN TRANSACTION;

        DECLARE @StockActual INT;

        -- Obtener stock actual
        SELECT @StockActual = StockActual FROM Productos WHERE ProductoID = @ProductoID;

        -- Validar existencia si es salida
        IF @TipoMovimiento = 'Salida' AND @Cantidad > @StockActual
        BEGIN
            RAISERROR('No hay suficiente stock disponible.', 16, 1);
            ROLLBACK TRANSACTION;
            RETURN;
        END

        -- Insertar movimiento
        INSERT INTO MovimientosInventario (ProductoID, TipoMovimiento, Cantidad)
        VALUES (@ProductoID, @TipoMovimiento, @Cantidad);

        -- Actualizar stock
        IF @TipoMovimiento = 'Entrada'
        BEGIN
            UPDATE Productos SET StockActual = StockActual + @Cantidad WHERE ProductoID = @ProductoID;
        END
        ELSE IF @TipoMovimiento = 'Salida'
        BEGIN
            UPDATE Productos SET StockActual = StockActual - @Cantidad WHERE ProductoID = @ProductoID;
        END

        COMMIT TRANSACTION;
    END TRY
    BEGIN CATCH
        ROLLBACK TRANSACTION;

        DECLARE @ErrorMessage NVARCHAR(4000) = ERROR_MESSAGE();
        RAISERROR(@ErrorMessage, 16, 1);
    END CATCH
END;
GO

-- Procedimiento para obtener el historial de movimientos con filtros

CREATE PROCEDURE sp_ObtenerMovimientos
    @FechaInicio DATE = NULL,
    @FechaFin DATE = NULL,
    @ProductoID INT = NULL
AS
BEGIN
    SELECT 
        m.MovimientoID,
        p.Nombre AS NombreProducto,
        m.TipoMovimiento,
        m.Cantidad,
        m.FechaMovimiento
    FROM MovimientosInventario m
    INNER JOIN Productos p ON m.ProductoID = p.ProductoID
    WHERE 
        (@FechaInicio IS NULL OR m.FechaMovimiento >= @FechaInicio) AND
        (@FechaFin IS NULL OR m.FechaMovimiento <= @FechaFin) AND
        (@ProductoID IS NULL OR m.ProductoID = @ProductoID)
    ORDER BY m.FechaMovimiento DESC;
END;
GO

-- DATOS DE PRUEBA
-- PRODUCTOS
INSERT INTO Productos (Nombre, Descripcion, Precio, StockActual) VALUES
('Sensor de Nivel', 'Sensor ultrasónico para detección de nivel en tanques de líquidos', 350.00, 15),
('Motor Eléctrico 5HP', 'Motor trifásico para sistema de transporte de alimentos', 1200.00, 8),
('PLC Siemens S7-1200', 'Controlador lógico programable para automatización de procesos', 850.00, 5),
('Banda Transportadora', 'Sistema modular de transporte de alimentos con superficie de acero inoxidable', 1500.00, 3),
('Válvula Neumática', 'Válvula para control de flujo en líneas de proceso', 220.00, 20),
('Termómetro Digital', 'Sensor de temperatura de precisión para procesos térmicos', 180.00, 10),
('Panel HMI 10"', 'Interfaz táctil para control de línea de producción', 950.00, 4),
('Cinta de Sellado', 'Cinta resistente a temperaturas para sellado de empaques', 15.00, 100),
('Filtro Sanitario', 'Filtro de acero inoxidable para líquidos de proceso', 310.00, 12),
('Cableado Industrial', 'Rollos de cable resistente para ambientes industriales', 95.00, 25);

-- MOVIMIENTOS
-- Entradas
INSERT INTO MovimientosInventario (ProductoID, TipoMovimiento, Cantidad, FechaMovimiento) VALUES
(1, 'Entrada', 10, '2025-04-01'),
(2, 'Entrada', 5, '2025-04-02'),
(3, 'Entrada', 2, '2025-04-03'),
(4, 'Entrada', 1, '2025-04-03'),
(5, 'Entrada', 20, '2025-04-04');

-- Salidas
INSERT INTO MovimientosInventario (ProductoID, TipoMovimiento, Cantidad, FechaMovimiento) VALUES
(1, 'Salida', 3, '2025-04-05'),
(2, 'Salida', 1, '2025-04-06'),
(5, 'Salida', 5, '2025-04-07'),
(6, 'Salida', 2, '2025-04-08'),
(10, 'Salida', 10, '2025-04-08');
