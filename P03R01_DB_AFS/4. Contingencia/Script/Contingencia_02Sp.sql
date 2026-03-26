--=========================================================================================================
--Autor:	  Andres Ferrer Servin
--Crate table:19/03/2026
--Descripcion:Contigencia de Sp para proyecto choferes,ruta y camiones
--P03R01AFS:  Liberacion BD
--=========================================================================================================

USE GenMar
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
