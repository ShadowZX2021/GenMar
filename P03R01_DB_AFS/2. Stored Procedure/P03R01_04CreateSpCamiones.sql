--=========================================================================================================
--Autor:	  Andres Ferrer Servin
--Crate table:19/03/2026
--Descripcion:Sp de camiones para proyecto choferes,ruta y camiones
--P03R01AFS:  Liberacion BD
--=========================================================================================================

USE [GenMar]
GO

CREATE OR ALTER PROCEDURE [dbo].[Sp_Listar_Camiones]
    @Disponibilidad BIT = NULL
AS
BEGIN
    SET NOCOUNT ON;

    BEGIN TRY

        IF @Disponibilidad IS NULL
            SELECT * FROM Camiones ORDER BY IdCamion DESC;
        ELSE
            SELECT * FROM Camiones WHERE Disponibilidad = @Disponibilidad ORDER BY IdCamion DESC;

    END TRY
    BEGIN CATCH

        THROW;

    END CATCH
END;

GO

CREATE OR ALTER PROCEDURE [dbo].[Sp_Insert_Camion]
    @Matricula VARCHAR(50),
    @TipoCamion VARCHAR(50),
    @Modelo INT,
    @Marca VARCHAR(50),
    @Capacidad INT,
    @Kilometraje FLOAT,
    @Disponibilidad BIT,
    @URLFoto VARCHAR(255),
    @FechaRegistro DATETIME
AS
BEGIN
    SET NOCOUNT ON;

    BEGIN TRY

        BEGIN TRANSACTION;

            INSERT INTO [dbo].[Camiones] ([Matricula],[TipoCamion],[Modelo],[Marca],[Capacidad],[Kilometraje],[Disponibilidad],[URLFoto],[FechaRegistro])
            VALUES(@Matricula,@TipoCamion,@Modelo,@Marca,@Capacidad,@Kilometraje,@Disponibilidad,@URLFoto,@FechaRegistro)

        COMMIT TRANSACTION;

    END TRY
    BEGIN CATCH

        IF @@TRANCOUNT > 0
            ROLLBACK TRANSACTION;

        THROW;

    END CATCH
END;

GO

CREATE OR ALTER PROCEDURE [dbo].[Sp_Update_Camion]
    @IdCamion int,
    @Matricula varchar(50),
    @TipoCamion varchar(50),
    @Modelo int,
    @Marca varchar(50),
    @Capacidad int,
    @Kilometraje float,
    @Disponibilidad bit,
    @URLFoto varchar(255)
AS
BEGIN

SET NOCOUNT ON;
    BEGIN TRY
        BEGIN TRANSACTION

            UPDATE [dbo].[Camiones]
               SET [Matricula] = @Matricula
                  ,[TipoCamion] = @TipoCamion
                  ,[Modelo] =@Modelo
                  ,[Marca] =@Marca
                  ,[Capacidad] =@Capacidad
                  ,[Kilometraje] =@Kilometraje
                  ,[Disponibilidad] =@Disponibilidad
                  ,[URLFoto] =@URLFoto

            WHERE IdCamion = @IdCamion

        COMMIT TRANSACTION
    END TRY
    BEGIN CATCH
        IF @@TRANCOUNT > 0
            ROLLBACK TRANSACTION;
        THROW
    END CATCH
END
GO

CREATE OR ALTER PROCEDURE [dbo].[Sp_Delete_Camiones]
    @IdCamion INT
AS 
BEGIN
SET NOCOUNT ON;
    BEGIN TRY
        BEGIN TRANSACTION 
            DELETE FROM Camiones WHERE IdCamion = @IdCamion
        COMMIT TRANSACTION
    END TRY
    BEGIN CATCH
        IF @@TRANCOUNT > 0
            ROLLBACK TRANSACTION;
        THROW
    END CATCH
END
GO

