--=========================================================================================================
--Autor:	  Andres Ferrer Servin
--Crate table:19/03/2026
--Descripcion:Contigencia para proyecto choferes,ruta y camiones
--P03R01AFS:  Liberacion BD
--=========================================================================================================

USE GenMar
GO
--=========================================================================================================
--Descripcion:Borrar Viws
--=========================================================================================================
DROP VIEW [dbo].[Vw_Camiones]
GO

DROP VIEW [dbo].[Vw_Choferes]
GO

DROP VIEW [dbo].[Vw_Rutas]
GO
--=========================================================================================================
--Descripcion:Borrar SP Existencia
--=========================================================================================================

DROP PROCEDURE [dbo].[Obtener_Camion_PorId]
GO

DROP PROCEDURE [dbo].[Existe_Matricula]
GO

DROP PROCEDURE [dbo].[Existe_Licencia]
GO

--=========================================================================================================
--Descripcion:Borrar SP Ruta
--=========================================================================================================
DROP PROCEDURE IF EXISTS [dbo].[Sp_Delete_Ruta]
GO

DROP PROCEDURE IF EXISTS [dbo].[Sp_Update_Ruta]
GO

DROP PROCEDURE IF EXISTS [dbo].[Sp_Insert_Ruta]
GO

DROP PROCEDURE IF EXISTS [dbo].[Sp_Listar_Rutas]
GO

--=========================================================================================================
--Descripcion:Borrar SP Chofer
--=========================================================================================================
DROP PROCEDURE IF EXISTS [dbo].[Sp_Delete_Chofer]
GO

DROP PROCEDURE IF EXISTS [dbo].[Sp_Update_Chofer]
GO

DROP PROCEDURE IF EXISTS [dbo].[Sp_Insert_Chofer]
GO

DROP PROCEDURE IF EXISTS [dbo].[Sp_Listar_Choferes]
GO

--=========================================================================================================
--Descripcion:Borrar SP Camiones
--=========================================================================================================
DROP PROCEDURE IF EXISTS [dbo].[Sp_Delete_Camiones]
GO

DROP PROCEDURE IF EXISTS [dbo].[Sp_Update_Camion]
GO

DROP PROCEDURE IF EXISTS [dbo].[Sp_Insert_Camion]
GO

DROP PROCEDURE IF EXISTS [dbo].[Sp_Listar_Camiones]
GO

--=========================================================================================================
--Descripcion:Borrar datos de la tabla Camiones
--=========================================================================================================
TRUNCATE TABLE [dbo].[Ruta]
GO

--=========================================================================================================
--Descripcion:Borrar datos de la tabla Camiones
--=========================================================================================================
TRUNCATE TABLE [dbo].[Camiones]
GO

--=========================================================================================================
--Descripcion:Borrar datos de la tabla chofer
--=========================================================================================================
TRUNCATE TABLE [dbo].[Chofer]
GO

--=========================================================================================================
--Descripcion:Borrar tabla Chofer
--=========================================================================================================
DROP TABLE IF EXISTS [dbo].[Chofer]
GO

--=========================================================================================================
--Descripcion:Borrar tabla Camiones
--=========================================================================================================
DROP TABLE IF EXISTS [dbo].[Camiones]
GO

--=========================================================================================================
--Descripcion:Borrar tabla Ruta
--=========================================================================================================
DROP TABLE IF EXISTS [dbo].[Ruta]
GO
