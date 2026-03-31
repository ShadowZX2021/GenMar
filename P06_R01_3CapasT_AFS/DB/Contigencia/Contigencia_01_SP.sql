USE ControlGastos
GO
--=========================================================================================================
--Autor:	  Andres Ferrer Servin
--Crate table:29/03/2026
--Descripcion:Contigencia de Sp para proyecto control de gastos
--P03R01AFS:  Liberacion BD
--=========================================================================================================



--=========================================================================================================
--Descripcion:Borrar SP Categoria
--=========================================================================================================

DROP PROCEDURE IF EXISTS [dbo].[sp_ActualizarCategoria]
GO

DROP PROCEDURE IF EXISTS [dbo].[sp_EliminarCategoria]
GO

DROP PROCEDURE IF EXISTS [dbo].[sp_InsertarCategoria]
GO

DROP PROCEDURE IF EXISTS [dbo].[sp_ListarCategoria]
GO

--=========================================================================================================
--Descripcion:Borrar SP Usuario
--=========================================================================================================
DROP PROCEDURE IF EXISTS [dbo].[sp_ActualizarUsario]
GO

DROP PROCEDURE IF EXISTS [dbo].[sp_EliminarUsuario]
GO

DROP PROCEDURE IF EXISTS [dbo].[sp_ExisteEmail]
GO

DROP PROCEDURE IF EXISTS [dbo].[sp_InsertarUsuario]
GO

DROP PROCEDURE IF EXISTS [dbo].[sp_ListarUsuarios]
GO

DROP PROCEDURE IF EXISTS [dbo].[sp_LoginUsuario]
GO

DROP PROCEDURE IF EXISTS [dbo].[sp_ObtenerUusuarioId]
GO

--=========================================================================================================
--Descripcion:Borrar SP Gastos
--=========================================================================================================
DROP PROCEDURE IF EXISTS [dbo].[sp_InsertarGastos]
GO

DROP PROCEDURE IF EXISTS [dbo].[sp_ListarGastos]
GO

DROP PROCEDURE IF EXISTS [dbo].[sp_EliminarGastos]
GO

--=========================================================================================================
--Descripcion:Borrar SP Datos Personales
--=========================================================================================================

DROP PROCEDURE IF EXISTS [dbo].[sp_ActualizarDatosPersonales]
GO

DROP PROCEDURE IF EXISTS [dbo].[sp_EliminarDatosPersonales]
GO
DROP PROCEDURE IF EXISTS [dbo].[sp_InsertarDatosPersonales]
GO
DROP PROCEDURE IF EXISTS [dbo].[sp_ListarDatosPersonales]
GO
DROP PROCEDURE IF EXISTS [dbo].[sp_ObtenerDatosPersonalesID]
GO