USE ControlGastos
GO
--=========================================================================================================
--Autor:	  Andres Ferrer Servin
--Create SP:29/03/2026
--Descripcion:Base de datos para proyecto de control de gastos
--P06_R01_3CapasT_AFS:  Liberacion BD
--=========================================================================================================

CREATE OR ALTER PROCEDURE sp_ListarDatosPersonales
AS
BEGIN
	SELECT [IdDatos],[Nombre],[ApPaterno],[ApMaterno],[Telefono],[Direccion]
	FROM [dbo].[DatosPersonales]
END

GO

CREATE OR ALTER PROCEDURE sp_InsertarDatosPersonales
	@Nombre NVARCHAR(50),
	@ApPaterno NVARCHAR(50),
	@ApMaterno NVARCHAR(50),
	@Telefono NVARCHAR(20),
	@Direccion NVARCHAR(200)
AS
BEGIN
    INSERT INTO [dbo].[DatosPersonales] ([Nombre],[ApPaterno],[ApMaterno],[Telefono],[Direccion])
    VALUES( @Nombre ,@ApPaterno,@ApMaterno,@Telefono,@Direccion)
END
GO

CREATE OR ALTER PROCEDURE sp_ObtenerDatosPersonalesID
	@IdDatos INT
AS
BEGIN
	SELECT [IdDatos],[Nombre],[ApPaterno],[ApMaterno],[Telefono],[Direccion]
	FROM [dbo].[DatosPersonales]
	WHERE [IdDatos] = @IdDatos
END
GO

CREATE OR ALTER PROCEDURE sp_ActualizarDatosPersonales
	@IdDatos INT,
	@Nombre NVARCHAR(50),
	@ApPaterno NVARCHAR(50),
	@ApMaterno NVARCHAR(50),
	@Telefono NVARCHAR(20),
	@Direccion NVARCHAR(200)
AS
BEGIN
	UPDATE [dbo].[DatosPersonales]
	   SET [Nombre] = @Nombre
		  ,[ApPaterno] = @ApPaterno
		  ,[ApMaterno] = @ApMaterno
		  ,[Telefono] = @Telefono
		  ,[Direccion] = @Direccion
	 WHERE [IdDatos] = @IdDatos
END

GO

CREATE OR ALTER PROCEDURE sp_EliminarDatosPersonales
	@IdDatos INT
AS
BEGIN
	DELETE FROM [dbo].[DatosPersonales]
		WHERE IdDatos = @IdDatos
END