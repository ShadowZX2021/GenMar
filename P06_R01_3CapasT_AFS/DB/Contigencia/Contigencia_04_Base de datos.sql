USE master;
GO
--=========================================================================================================
--Autor:	  Andres Ferrer Servin
--Crate table:29/03/2026
--Descripcion:Contigencia Borrar Base de datos para proyecto Control de gastos
--P06R01AFS:  Liberacion BD
--=========================================================================================================


ALTER DATABASE ControlGastos SET SINGLE_USER WITH ROLLBACK IMMEDIATE;
GO

DROP DATABASE IF EXISTS ControlGastos
GO
