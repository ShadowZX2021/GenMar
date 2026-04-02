--====================================================================================================
--Autor:	  Andres Ferrer Servin
--Crate table:19/03/2026
--Descripcion:Se crean base de datos para proyecto choferes,ruta y camiones
--P03R01AFS:  Liberacion BD
--====================================================================================================

IF NOT EXISTS (SELECT * FROM sys.databases WHERE name = 'GenMar')
BEGIN
    CREATE DATABASE GenMar
    PRINT 'Base de datos GenMar creada correctamente'
END
ELSE
BEGIN
    PRINT 'La base de datos GenMar ya existe'
END
GO