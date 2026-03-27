--=========================================================================================================
--Autor:	  Andres Ferrer Servin
--Crate table:19/03/2026
--Descripcion:SP de rutas para proyecto choferes,ruta y camiones
--P03R01AFS:  Liberacion BD
--=========================================================================================================
USE GenMar
GO

CREATE OR ALTER PROCEDURE [dbo].[Sp_Listar_Rutas]
	@ATiempo INT
AS
BEGIN
SET NOCOUNT ON
	BEGIN TRY

		IF @ATiempo IS NULL
			SELECT * FROM [dbo].[Ruta] ORDER BY IdChofer DESC
		ELSE
			SELECT * FROM [dbo].[Ruta] WHERE ATiempo = @ATiempo ORDER BY IdChofer DESC

	END TRY
	BEGIN CATCH

		THROW

	END CATCH
END
GO

CREATE OR ALTER PROCEDURE [dbo].[Sp_Insert_Ruta]
	@IdChofer int,
	@IdCamion int,
	@Origen varchar(200) ,
	@Destino varchar(200),
	@FechaSalida datetime,
	@FechaLlegada datetime,
	@ATiempo bit,
	@Distancia float,
	@FechaRegistro datetime
AS
BEGIN
SET NOCOUNT ON
	BEGIN TRY
		BEGIN TRANSACTION

			INSERT INTO [dbo].[Ruta]([IdChofer],[IdCamion],[Origen],[Destino],[FechaSalida],[FechaLlegada],[ATiempo],[Distancia],[FechaRegistro])
			VALUES(@IdChofer ,@IdCamion,@Origen,@Destino,@FechaSalida,@FechaLlegada,@ATiempo,@Distancia,@FechaRegistro)
		
		COMMIT TRANSACTION
	END TRY

	BEGIN CATCH
		IF @@TRANCOUNT > 0
			ROLLBACK TRANSACTION
		THROW
	END CATCH
END
GO

CREATE OR ALTER PROCEDURE [dbo].[Sp_Update_Ruta]
@IdRuta int,
@IdChofer int,
@IdCamion int,
@Origen varchar(200),
@Destino varchar(200),
@FechaSalida datetime,
@FechaLlegada datetime,
@ATiempo bit,
@Distancia float,
@FechaRegistro datetime
AS
BEGIN
SET NOCOUNT ON;
	BEGIN TRY
		BEGIN TRANSACTION

			UPDATE [dbo].[Ruta]
			   SET [Origen] = @Origen
				  ,[Destino] = @Destino
				  ,[FechaSalida] = @FechaSalida
				  ,[FechaLlegada] = @FechaLlegada
				  ,[ATiempo] = @ATiempo
				  ,[Distancia] = @Distancia
				  ,[FechaRegistro] = @FechaRegistro
			 WHERE IdRuta = @IdRuta AND IdChofer = @IdChofer AND IdCamion = @IdCamion
		COMMIT TRANSACTION
	END TRY
	BEGIN CATCH
		IF @@TRANCOUNT > 0
			ROLLBACK TRANSACTION
		THROW
	END CATCH
END
GO

CREATE OR ALTER PROCEDURE [dbo].[Sp_Delete_Ruta]
@IdRuta int,
@IdChofer int,
@IdCamion int
AS
BEGIN
SET NOCOUNT ON
	BEGIN TRY
		BEGIN TRANSACTION

			DELETE FROM [dbo].[Ruta] WHERE IdRuta = @IdRuta AND IdChofer = @IdChofer AND IdCamion = @IdCamion
		COMMIT TRANSACTION
	END TRY
	BEGIN CATCH
		IF @@TRANCOUNT > 0
			ROLLBACK TRANSACTION
		THROW
	END CATCH
END