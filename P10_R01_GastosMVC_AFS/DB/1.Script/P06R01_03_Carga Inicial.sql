USE ControlGastos
GO
--=========================================================================================================
--Autor:	  Andres Ferrer Servin
--Carga Inicial:29/03/2026
--Descripcion:Base de datos para proyecto de control de gastos
--P06_R01_3CapasT_AFS:  Liberacion BD
--=========================================================================================================

BEGIN TRANSACTION
BEGIN TRY


INSERT INTO NivelUsuario (Descripcion)
VALUES ('Administrador'),
('Usuario');

INSERT INTO TipoSueldo (Descripcion)
VALUES ('Semanal'),
('Quincenal'),
('Mensual');

INSERT INTO Categorias (Nombre, Descripcion)
VALUES ('Alimentación', 'Gastos en comida y supermercado'),
('Transporte', 'Gasolina, transporte público, Uber'),
('Vivienda', 'Renta, servicios, mantenimiento'),
('Entretenimiento', 'Cine, videojuegos, salidas'),
('Salud', 'Medicinas, consultas'),
('Educación', 'Cursos, libros'),
('Otros', 'Gastos varios');

INSERT INTO DatosPersonales
(Nombre,ApPaterno,ApMaterno,Telefono,Direccion,SueldoBase,IdTipoSueldo)
VALUES('Andres','Ferrer','Servin','5512345678','CDMX',15000.00,3 ),
('Luis', 'Gomez', 'Perez', '5511111111', 'CDMX', 8000, 1),
('Maria', 'Lopez', 'Hernandez', '5522222222', 'CDMX', 12000, 2),
('Carlos', 'Ramirez', 'Torres', '5533333333', 'CDMX', 9500, 1),
('Ana', 'Martinez', 'Diaz', '5544444444', 'CDMX', 11000, 3),
('Jorge', 'Sanchez', 'Ruiz', '5555555555', 'CDMX', 7000, 1),
('Fernanda', 'Castro', 'Morales', '5566666666', 'CDMX', 13000, 2),
('Diego', 'Ortega', 'Vega', '5577777777', 'CDMX', 9000, 1),
('Sofia', 'Navarro', 'Mendez', '5588888888', 'CDMX', 15000, 3);


INSERT INTO Usuarios
(IdDatos,IdNivelUsuario,Nombre,Email,Password)
VALUES(1,1,'Andres Ferrer','admin@controlgastos.com','123456'),
(2, 2, 'Luis Gomez', 'luis@mail.com', '123456'),
(3, 2, 'Maria Lopez', 'maria@mail.com', '123456'),
(4, 2, 'Carlos Ramirez', 'carlos@mail.com', '123456'),
(5, 2, 'Ana Martinez', 'ana@mail.com', '123456'),
(6, 2, 'Jorge Sanchez', 'jorge@mail.com', '123456'),
(7, 2, 'Fernanda Castro', 'fernanda@mail.com', '123456'),
(8, 2, 'Diego Ortega', 'diego@mail.com', '123456'),
(9, 2, 'Sofia Navarro', 'sofia@mail.com', '123456');


INSERT INTO Gastos(IdUsuario,IdCategorias,Monto,Descripcion)
VALUES(1, 1, 250.50, 'Supermercado'),
(1, 2, 500.00, 'Gasolina'),
(1, 4, 150.00, 'Cine'),
(1, 3, 3000.00, 'Renta'),
(1, 5, 200.00, 'Medicinas');

COMMIT TRANSACTION

END TRY
BEGIN CATCH
    IF @@TRANCOUNT > 0
        ROLLBACK TRANSACTION

    PRINT 'Error en carga inicial'
    
END CATCH
GO