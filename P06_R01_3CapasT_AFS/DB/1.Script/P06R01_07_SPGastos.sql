USE ControlGastos
GO
--=========================================================================================================
--Autor:	  Andres Ferrer Servin
--Create SP:29/03/2026
--Descripcion:Base de datos para proyecto de control de gastos
--P06_R01_3CapasT_AFS:  Liberacion BD
--=========================================================================================================

CREATE OR ALTER PROCEDURE sp_ListarGastos
AS
BEGIN
	SELECT [IdGastos],g.IdUsuario AS IdUsuario,g.IdCategorias AS IdCategorias,[Monto],
	g.Descripcion AS Descripcion,[Fecha],dp.Nombre+' '+dp.ApPaterno+' '+dp.ApMaterno AS NombrePersona,
	u.Nombre AS Usuario,c.Nombre AS Categoria
	FROM [dbo].[Gastos] AS g
	INNER JOIN Usuarios AS u ON g.IdUsuario = u.IdUsuario
	INNER JOIN DatosPersonales AS dp ON u.IdDatos = dp.IdDatos
	INNER JOIN Categorias AS c ON g.IdCategorias = c.IdCategorias
END
GO

CREATE OR ALTER PROCEDURE sp_InsertarGastos
    @IdUsuario int,
    @IdCategorias int,
    @Monto decimal(10,2),
    @Descripcion nvarchar(255)
    
AS
BEGIN
	INSERT INTO [dbo].[Gastos] ([IdUsuario],[IdCategorias],[Monto],[Descripcion])
		 VALUES(@IdUsuario,@IdCategorias ,@Monto ,@Descripcion)
END
GO

CREATE OR ALTER PROCEDURE sp_EliminarGastos
@IdGastos INT
AS 
BEGIN
	DELETE FROM [dbo].[Gastos]
		WHERE IdGastos =@IdGastos
END