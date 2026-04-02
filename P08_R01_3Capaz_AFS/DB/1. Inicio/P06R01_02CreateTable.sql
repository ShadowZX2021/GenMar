--=========================================================================================================
--Autor:	  Andres Ferrer Servin
--Crate table:19/03/2026
--Descripcion:Se crean tablas para proyecto choferes,ruta y camiones
--P03R01AFS:  Liberacion BD
--=========================================================================================================
USE GenMar
go

BEGIN TRANSACTION;
BEGIN TRY
	IF NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME ='Camiones')
	BEGIN
		CREATE TABLE [dbo].[Camiones](
			IdCamion int primary key identity(1,1) not null,
			Matricula nvarchar(50)not null,
			TipoCamion nvarchar(50) not null,
			Modelo int not null,
			Marca nvarchar(50) not null,
			Capacidad int not null,
			Kilometraje float not null,
			Disponibilidad bit not null,
			URLFoto nvarchar (255) null,
			FechaRegistro datetime null
		)
	END 
		ELSE 
			PRINT 'La tabla [dbo].[Camiones] ya existe'

			COMMIT TRANSACTION;
--Confirmar cambios
END TRY BEGIN CATCH IF @@TRANCOUNT > 0
--Verificar si hay una transacción activa

ROLLBACK TRANSACTION;
--Deshacer si hay error
--Manejar el error (log,mensaje,etc.)
THROW;
--Re-lanza el error para que lo maneje la aplicacion
END CATCH;
GO

BEGIN TRANSACTION;
BEGIN TRY
	IF NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME ='Chofer')
	BEGIN
		CREATE TABLE [dbo].[Chofer](
			IdChofer int primary key identity(1,1) not null,
			Nombre nvarchar(100)not null,
			ApPaterno nvarchar(100)not null,
			ApMaterno nvarchar (100)not null,
			Telefono nvarchar (15)not null,
			FechaNacimiento date not null,
			Licencia nvarchar (50) not null,
			UrlFoto nvarchar (255)null,
			Disponibilidad bit not null,
			FechaRegistro datetime null )
	END
		ELSE 
			PRINT 'La tabla [dbo].[Chofer] ya existe'
			COMMIT TRANSACTION;
--Confirmar cambios
END TRY BEGIN CATCH IF @@TRANCOUNT > 0
--Verificar si hay una transacción activa

ROLLBACK TRANSACTION;
--Deshacer si hay error
--Manejar el error (log,mensaje,etc.)
THROW;
--Re-lanza el error para que lo maneje la aplicacion
END CATCH;
GO

BEGIN TRANSACTION;
BEGIN TRY
	IF NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME ='Ruta')
	BEGIN
	
	CREATE TABLE[dbo].[Ruta](
		IdRuta  int primary key identity(1,1)not null,
		IdChofer int not null foreign key references Chofer(IdChofer),
		IdCamion int not null foreign key references Camiones(IdCamion),
		Origen nvarchar (200) not null,
		Destino nvarchar (200)not null,
		FechaSalida datetime not null,
		FechaLlegada datetime not null,
		ATiempo bit not null,
		Distancia float not null,
		FechaRegistro datetime null
	)
	END
		ELSE 
			PRINT 'La tabla [dbo].[Ruta] ya existe'
			COMMIT TRANSACTION;
--Confirmar cambios
END TRY BEGIN CATCH IF @@TRANCOUNT > 0
--Verificar si hay una transacción activa

ROLLBACK TRANSACTION;
--Deshacer si hay error
--Manejar el error (log,mensaje,etc.)
THROW;
--Re-lanza el error para que lo maneje la aplicacion
END CATCH;