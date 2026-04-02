--=========================================================================================================
--Autor:	  Andres Ferrer Servin
--Crate table:19/03/2026
--Descripcion:Sp obtener camion por id
--P03R01AFS:  Liberacion BD
--=========================================================================================================

USE GenMar
GO

CREATE OR ALTER PROCEDURE [dbo].[Obtener_Camion_PorId]
	@IdCamion int
AS
BEGIN
	SELECT * FROM Camiones WHERE IdCamion = @IdCamion
END
GO

--=========================================================================================================
--Descripcion:Validar si existe la matricula
--=========================================================================================================

CREATE OR ALTER PROCEDURE [dbo].[Existe_Matricula]
	@Matricula VARCHAR(50)
AS
BEGIN
	SELECT * FROM Camiones WHERE Matricula = @Matricula
END
GO

--=========================================================================================================
--Descripcion:Validar si esxiste la licencia
--=========================================================================================================

CREATE OR ALTER PROCEDURE [dbo].[Existe_Licencia]
	@Licencia VARCHAR (50)
AS
BEGIN
	SELECT COUNT(*) FROM Chofer	
END