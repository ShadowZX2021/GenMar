USE ControlGastos
GO
--=========================================================================================================
--Autor:	  Andres Ferrer Servin
--Create table:27/03/2026
--Descripcion:Base de datos para proyecto de control de gastos
--P06_R01_3CapasT_AFS:  Liberacion BD
--=========================================================================================================

BEGIN TRANSACTION 
BEGIN TRY
	IF NOT EXISTS(SELECT*FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'DatosPersonales')
	BEGIN
		CREATE TABLE DatosPersonales (
			IdDatos INT IDENTITY PRIMARY KEY,
			Nombre NVARCHAR(50) NOT NULL,
			ApPaterno NVARCHAR(50) NOT NULL,
			ApMaterno NVARCHAR(50) NOT NULL,
			Telefono NVARCHAR(20) NULL,
			Direccion NVARCHAR(200) NULL,
		);
	END
	ELSE
		PRINT'La tabla [dbo].[DatosPersonales] ya existe'
	COMMIT TRANSACTION

END TRY BEGIN CATCH IF @@TRANCOUNT > 0
	ROLLBACK TRANSACTION
	THROW
END CATCH
GO

BEGIN TRANSACTION 
BEGIN TRY
	IF NOT EXISTS(SELECT*FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'Usuarios')
	BEGIN
		CREATE TABLE[dbo].[Usuarios](
			IdUsuario INT PRIMARY KEY IDENTITY(1,1),
			IdDatos INT,
			Nombre NVARCHAR(100) NOT NULL,
			Email NVARCHAR(100) NOT NULL,
			Password NVARCHAR(255)NOT NULL,
			FechaRegistro DATETIME DEFAULT GETDATE(),
			FOREIGN KEY (IdDatos) REFERENCES DatosPersonales(IdDatos)
		)
	END
	ELSE
		PRINT'La tabla [dbo].[Usuario] ya existe'
	COMMIT TRANSACTION

END TRY BEGIN CATCH IF @@TRANCOUNT > 0
	ROLLBACK TRANSACTION
	THROW
END CATCH
GO

BEGIN TRANSACTION 
BEGIN TRY
	IF NOT EXISTS(SELECT*FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'Categorias')
	BEGIN
		CREATE TABLE[dbo].[Categorias](
			IdCategorias INT PRIMARY KEY IDENTITY(1,1),
			Nombre NVARCHAR(100) NOT NULL,
			Descripcion NVARCHAR (255) NOT NULL
		)
	END
	ELSE
		PRINT'La tabla [dbo].[Categorias] ya existe'
	COMMIT TRANSACTION

END TRY BEGIN CATCH IF @@TRANCOUNT > 0
	ROLLBACK TRANSACTION
	THROW
END CATCH
GO

BEGIN TRANSACTION 
BEGIN TRY
	IF NOT EXISTS(SELECT*FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'Gastos')
	BEGIN
		CREATE TABLE[dbo].[Gastos](
			IdGastos INT PRIMARY KEY IDENTITY (1,1),
			IdUsuario INT,
			IdCategorias INT,
			Monto Decimal (10,2),
			Descripcion NVARCHAR(255),
			Fecha DATETIME DEFAULT GETDATE(),

			FOREIGN KEY(IdUsuario)REFERENCES Usuarios(IdUsuario),
			FOREIGN KEY(IdCategorias)REFERENCES Categorias(IdCategorias)

		)
	END
	ELSE
		PRINT'La tabla [dbo].[Gastos] ya existe'
	COMMIT TRANSACTION

END TRY BEGIN CATCH IF @@TRANCOUNT > 0
	ROLLBACK TRANSACTION
	THROW
END CATCH
GO