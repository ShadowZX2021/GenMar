--=========================================================================================================
--Autor:	  Andres Ferrer Servin
--Create Database:27/03/2026
--Descripcion:Base de datos para proyecto de control de gastos
--P06_R01_3CapasT_AFS:  Liberacion BD
--=========================================================================================================

IF NOT EXISTS(SELECT * FROM sys.databases WHERE NAME = 'ControlGastos')
BEGIN
	CREATE DATABASE ControlGastos
	PRINT 'Base de datos creada correctamente'
END
ELSE
BEGIN
	PRINT'La base ya existe'
END

GO