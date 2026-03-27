--=========================================================================================================
--Autor:	  Andres Ferrer Servin
--Crate table:19/03/2026
--Descripcion:View Camiones para proyecto choferes,ruta y camiones
--P03R01AFS:  Liberacion BD
--=========================================================================================================

USE GenMar
GO

CREATE OR ALTER VIEW [dbo].[Vw_Camiones]
AS
SELECT * FROM [dbo].[Camiones]

GO

--=========================================================================================================
--Descripcion:View Choferes para proyecto choferes,ruta y camiones
--=========================================================================================================

CREATE OR ALTER VIEW [dbo].[Vw_Choferes]
AS
SELECT * FROM [dbo].[Chofer]

GO

--=========================================================================================================
--Descripcion:View Rutas para proyecto choferes,ruta y camiones
--=========================================================================================================

CREATE OR ALTER VIEW [dbo].[Vw_Rutas]
AS
SELECT * FROM [dbo].[Ruta]

GO