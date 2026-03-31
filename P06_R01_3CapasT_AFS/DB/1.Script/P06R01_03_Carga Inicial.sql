USE ControlGastos
GO
--=========================================================================================================
--Autor:	  Andres Ferrer Servin
--Carga Inicial:29/03/2026
--Descripcion:Base de datos para proyecto de control de gastos
--P06_R01_3CapasT_AFS:  Liberacion BD
--=========================================================================================================

--Inserta DatosPersonales
 
INSERT INTO DatosPersonales (Nombre, ApPaterno,ApMaterno, Telefono, Direccion)
VALUES 
('Juan', 'Perez','Flores', '5512345678', 'CDMX'),
('Maria', 'Lopez','Martinez', '5523456789', 'Guadalajara'),
('Carlos', 'Sanchez','Rojas', '5534567890', 'Monterrey'),
('Ana', 'Martinez','Del Monte', '5545678901', 'Puebla'),
('Luis', 'Gomez','Morales', '5556789012', 'Toluca');
GO

--Inserta Usuarios

INSERT INTO Usuarios (IdDatos, Nombre, Email, Password)
VALUES
(1, 'Juan Perez', 'juan@mail.com', '12345'),
(2, 'Maria Lopez', 'maria@mail.com', '12345'),
(3, 'Carlos Sanchez', 'carlos@mail.com', '12345'),
(4, 'Ana Martinez', 'ana@mail.com', '12345'),
(5, 'Luis Gomez', 'luis@mail.com', '12345');

GO
--Inserta Categorias

INSERT INTO Categorias (Nombre, Descripcion)
VALUES
('Comida', 'Gastos en alimentos'),
('Transporte', 'Pasajes y gasolina'),
('Servicios', 'Luz, agua, internet'),
('Entretenimiento', 'Cine, juegos, salidas'),
('Salud', 'Medicinas y consultas');

--Inserta Gastos

INSERT INTO Gastos (IdUsuario, IdCategorias, Monto, Descripcion)
VALUES
(1, 1, 150.50, 'Comida en restaurante'),
(2, 2, 80.00, 'Taxi'),
(3, 3, 500.75, 'Pago de luz'),
(4, 4, 200.00, 'Cine'),
(5, 5, 300.00, 'Consulta médica');