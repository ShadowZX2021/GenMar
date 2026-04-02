USE GenMar
GO

--=========================================================================================================
--Autor:	  Andres Ferrer Servin
--Crate table:19/03/2026
--Descripcion:Sp de camiones para proyecto choferes,ruta y camiones
--P03R01AFS:  Liberacion BD
--=========================================================================================================

CREATE TABLE Usuarios(
IdUsuario INT PRIMARY KEY IDENTITY(1,1),
Usuario NVARCHAR (100) NOT NULL,
Password NVARCHAR(200) NOT NULL,
Email NVARCHAR(100) NOT NULL,
FechaRegistro DATETIME DEFAULT GETDATE()
)

GO
 
CREATE OR ALTER PROCEDURE sp_Obtenerusuario
AS
BEGIN
	SELECT IdUsuario, Usuario, Password, Email FROM Usuarios 
END

GO

CREATE OR ALTER PROCEDURE sp_ExisteEmail
@Email NVARCHAR (50)
AS
BEGIN
	SELECT IdUsuario, Usuario, Password, Email 
	FROM Usuarios
	WHERE Email = @Email
END

GO

CREATE OR ALTER PROCEDURE sp_InsertarUsuario
@Usuario NVARCHAR(100),
@Password NVARCHAR(200),
@Email NVARCHAR(100)
AS
BEGIN
	INSERT INTO [dbo].[Usuarios]([Usuario],[Password],[Email])
	VALUES (@Usuario,@Password,@Email)
END