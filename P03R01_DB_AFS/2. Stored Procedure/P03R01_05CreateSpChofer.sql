--=========================================================================================================
--Autor:	  Andres Ferrer Servin
--Crate table:19/03/2026
--Descripcion:Sp de choferes para proyecto choferes,ruta y camiones
--P03R01AFS:  Liberacion BD
--=========================================================================================================

USE GenMar
GO

CREATE OR ALTER PROCEDURE [dbo].[Sp_Listar_Choferes]
	@Disponibilidad BIT = NULL
AS
BEGIN
	SET NOCOUNT ON

	BEGIN TRY

		IF @Disponibilidad IS NULL
			SELECT * FROM Chofer ORDER BY IdChofer DESC
		ELSE
			SELECT * FROM Chofer WHERE Disponibilidad = @Disponibilidad ORDER BY IdChofer DESC
	END TRY
	BEGIN CATCH

		THROW

	END CATCH
END
GO

CREATE OR ALTER PROCEDURE  [dbo].[Sp_Insert_Chofer]
	@Nombre varchar(100),
	@ApPaterno varchar(100),
	@ApMaterno varchar(100),
	@Telefono varchar(15),
	@FechaNacimiento date,
	@Licencia varchar(50),
	@UrlFoto varchar(255),
	@Disponibilidad bit,
	@FechaRegistro datetime
AS
BEGIN
	SET NOCOUNT ON;
	BEGIN TRY
		BEGIN TRANSACTION

			INSERT INTO [dbo].[Chofer] ([Nombre],[ApPaterno],[ApMaterno],[Telefono],[FechaNacimiento],[Licencia],[UrlFoto],[Disponibilidad],[FechaRegistro])
			VALUES (@Nombre,@ApPaterno ,@ApMaterno,@Telefono,@FechaNacimiento,@Licencia,@UrlFoto,@Disponibilidad,@FechaRegistro)
		
		COMMIT TRANSACTION;
	END TRY
	BEGIN CATCH

		IF @@TRANCOUNT > 0
			ROLLBACK TRANSACTION;
		THROW;

	END CATCH
END
GO

CREATE OR ALTER  PROCEDURE [dbo].[Sp_Update_Chofer]
@IdChofer int,
@Nombre  varchar(100),
@ApPaterno  varchar(100),
@ApMaterno  varchar(100),
@Telefono  varchar(15),
@FechaNacimiento date,
@Licencia varchar(50),
@UrlFoto  varchar(255),
@Disponibilidad  bit

AS 
BEGIN

SET NOCOUNT ON;
	BEGIN TRY
		BEGIN TRANSACTION

			UPDATE [dbo].[Chofer]
				SET [Nombre] = @Nombre
					,[ApPaterno] = @ApPaterno
					,[ApMaterno] = @ApMaterno
					,[Telefono] = @Telefono
					,[FechaNacimiento] = @FechaNacimiento
					,[Licencia] = @Licencia
					,[UrlFoto] = @UrlFoto
					,[Disponibilidad] = @Disponibilidad
				WHERE [IdChofer] =@IdChofer
		COMMIT TRANSACTION
	END TRY
	BEGIN CATCH
		IF @@TRANCOUNT>0
			ROLLBACK TRANSACTION;
		THROW
	END CATCH
END
GO

CREATE OR ALTER PROCEDURE [dbo].[Sp_Delete_Chofer]
@IdChofer INT
AS
BEGIN

SET NOCOUNT ON;
	BEGIN TRY
		BEGIN TRANSACTION
			DELETE FROM [dbo].[Chofer] WHERE IdChofer = @IdChofer
		COMMIT TRANSACTION
	END TRY
	BEGIN CATCH
		IF @@TRANCOUNT>0
			ROLLBACK TRANSACTION
		THROW
	END CATCH
END