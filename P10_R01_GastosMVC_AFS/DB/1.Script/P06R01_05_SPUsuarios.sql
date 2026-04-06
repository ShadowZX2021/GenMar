USE ControlGastos
GO
--=========================================================================================================
--Autor:	  Andres Ferrer Servin
--Create SP:29/03/2026
--Descripcion:Base de datos para proyecto de control de gastos
--P06_R01_3CapasT_AFS:  Liberacion BD
--=========================================================================================================

CREATE OR ALTER PROCEDURE sp_ListarUsuarios
AS
BEGIN
	SELECT [IdUsuario],[IdDatos],[Nombre],[Email],[Password],[FechaRegistro]
	FROM [dbo].[Usuarios]
END
GO

CREATE OR ALTER PROCEDURE sp_InsertarUsuario
    @IdDatos INT,
    @IdNivelUsuario INT,
    @Nombre NVARCHAR(100),
    @Email NVARCHAR(100),
    @Password NVARCHAR(255)
AS
BEGIN
    INSERT INTO [dbo].[Usuarios] ([IdDatos],[IdNivelUsuario],[Nombre],[Email],[Password])
    VALUES (@IdDatos,@IdNivelUsuario,@Nombre,@Email,@Password)
END
GO

CREATE OR ALTER PROCEDURE sp_ActualizarUsario
@IdUsuario INT,
@IdDatos INT,
@Nombre NVARCHAR(100),
@Email NVARCHAR(100),
@Password NVARCHAR(255),
@IdNivelUsuario INT

AS
BEGIN
    UPDATE [dbo].[Usuarios]
    SET [IdDatos] = @IdDatos,
        [IdNivelUsuario] = @IdNivelUsuario,
        [Nombre] = @Nombre,
        [Email] = @Email,
        [Password] = @Password
    WHERE [IdUsuario] =@IdUsuario
END
GO

CREATE OR ALTER PROCEDURE sp_EliminarUsuario
@IdUsuario INT,
@IdEstatus INT
AS
BEGIN
        UPDATE [dbo].[Usuarios]
    SET IdEstatus=@IdEstatus
    WHERE [IdUsuario] =@IdUsuario
END
GO

CREATE OR ALTER PROCEDURE sp_ObtenerUsuarioId
    @IdUsuario INT
AS
BEGIN
	SELECT [IdUsuario],[IdDatos],[Nombre],[Email],[Password],[FechaRegistro]
	FROM [dbo].[Usuarios]
    WHERE [IdUsuario]=@IdUsuario
END

GO

CREATE OR ALTER PROCEDURE sp_LoginUsuario
@Email NVARCHAR(100),
@Password NVARCHAR(255)
AS 
BEGIN
    SELECT [Email],[Password] FROM [dbo].[Usuarios]
        WHERE [Email] = @Email AND [Password]= @Password
END

GO

CREATE OR ALTER PROCEDURE sp_ExisteEmail
	@Email VARCHAR (100)
AS
BEGIN
	SELECT COUNT(*) FROM Usuarios
	WHERE [Email] =@Email
END

GO

CREATE OR ALTER PROCEDURE sp_ExisteUsuario
	@IdDatos INT
AS
BEGIN
	SELECT COUNT(*) FROM Usuarios
	WHERE [IdDatos] =@IdDatos
END

GO

CREATE OR ALTER PROCEDURE sp_DropListDatosPersonales
AS
BEGIN
	SELECT [IdDatos],[Nombre]+[ApPaterno]+[ApMaterno] AS Nombre
	FROM [dbo].[DatosPersonales]
END
GO