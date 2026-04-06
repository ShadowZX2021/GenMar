USE master;
GO
--=========================================================================================================
--Autor:	  Andres Ferrer Servin
--Crate table:06/04/2026
--Descripcion:Contigencia Borrar Base de datos para proyecto Gestores
--P06R01AFS:  Liberacion BD
--=========================================================================================================


ALTER DATABASE TEST SET SINGLE_USER WITH ROLLBACK IMMEDIATE;
GO

DROP DATABASE IF EXISTS TEST
GO
