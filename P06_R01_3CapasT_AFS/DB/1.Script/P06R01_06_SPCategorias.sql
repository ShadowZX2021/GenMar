USE ControlGastos
GO
--=========================================================================================================
--Autor:	  Andres Ferrer Servin
--Create SP:29/03/2026
--Descripcion:Base de datos para proyecto de control de gastos
--P06_R01_3CapasT_AFS:  Liberacion BD
--=========================================================================================================

CREATE OR ALTER PROCEDURE sp_ListarCategoria
AS
BEGIN
	SELECT [IdCategorias],[Nombre],[Descripcion]
	  FROM [dbo].[Categorias]
END
GO

CREATE OR ALTER PROCEDURE sp_InsertarCategoria
@Nombre NVARCHAR(100),
@Descripcion NVARCHAR(255)
AS
BEGIN
	INSERT INTO [dbo].[Categorias]([Nombre],[Descripcion])
		VALUES(@Nombre,@Descripcion)
END

GO

CREATE OR ALTER PROCEDURE sp_ActualizarCategoria
@IdCategorias INT,
@Nombre NVARCHAR(100),
@Descripcion NVARCHAR(255)

AS
BEGIN
	UPDATE [dbo].[Categorias]
		SET [Nombre] = @Nombre,
		[Descripcion] = @Descripcion
		WHERE IdCategorias = @IdCategorias
END
GO

CREATE OR ALTER PROCEDURE sp_EliminarCategoria
@IdCategorias INT

AS
BEGIN
	DELETE FROM [dbo].[Categorias]
		WHERE IdCategorias = @IdCategorias
END
GO

CREATE OR ALTER PROCEDURE sp_ObtenerCategoriasPorId
@IdCategorias INT
AS 
BEGIN
	SELECT * FROM [dbo].[Categorias]
		WHERE IdCategorias = @IdCategorias
END
