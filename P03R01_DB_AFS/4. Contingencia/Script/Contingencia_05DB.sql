--=========================================================================================================
--Autor:	  Andres Ferrer Servin
--Crate table:19/03/2026
--Descripcion:Contigencia Borrar Base de datos para proyecto choferes,ruta y camiones
--P03R01AFS:  Liberacion BD
--=========================================================================================================
USE master;
GO

ALTER DATABASE GenMar SET SINGLE_USER WITH ROLLBACK IMMEDIATE;
GO

DROP DATABASE IF EXISTS GenMar
GO
