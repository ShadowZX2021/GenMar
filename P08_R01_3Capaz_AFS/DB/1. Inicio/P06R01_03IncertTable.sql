--=========================================================================================================
--Autor:	  Andres Ferrer Servin
--Crate table:19/03/2026
--Descripcion:Se carga inicial de datos para proyecto choferes,ruta y camiones
--P03R01AFS:  Liberacion BD
--=========================================================================================================

USE [GenMar]
GO

INSERT INTO [dbo].[Camiones] ([Matricula],[TipoCamion],[Modelo],[Marca],[Capacidad],[Kilometraje],[Disponibilidad],[FechaRegistro])
VALUES ('ABCD-1234','Carga',2020,'Nissan Frontier',650,123443123,1,GETDATE()),
	   ('EFGH-0932','Carga',2022,'Nissan NV2500',880,123443123,1,GETDATE()),
       ('PSLX-0234','Carga',2020,'Ford Transit.',930,123443123,1,GETDATE()),
       ('KCMD-0323','Carga',2026,'Forward ',1020,123443123,1,GETDATE()),
       ('LKDS-2342','Carga',2026,'Freightliner M2',1120,123443123,1,GETDATE())
GO

INSERT INTO [dbo].[Chofer] ([Nombre],[ApPaterno],[ApMaterno],[Telefono],[FechaNacimiento],[Licencia],[Disponibilidad],[FechaRegistro])
VALUES ('Andres','Ferrer','Servin','5534234455','1998/05/20','55443322',1,GETDATE()),
       ('Hector','Martinez','Flores','5509342813','1993/02/05','55442091',1,GETDATE()),
       ('Juan','Andres','Serano','5694832839','1995/12/15','55449932',1,GETDATE()),
       ('Daniel','Olivo','Garcia','5509234222','1990/07/13','55447387',1,GETDATE()),
       ('Elizabeth','Sanches','Ramoz','5692348273','1999/08/23','55434532',1,GETDATE())
GO

INSERT INTO [dbo].[Ruta]([IdChofer],[IdCamion],[Origen],[Destino],[FechaSalida],[FechaLlegada],[ATiempo],[Distancia],[FechaRegistro])
VALUES(1,1,'CDMX','OAX','2026-03-19T00:00:00','2026-03-20T00:00:00',1,330293.233,GETDATE()),
      (2,2,'AGS','PUE','2026-03-25T00:00:00','2026-03-28T00:00:00',1,330293.233,GETDATE()),
      (3,3,'QRO','SLP','2026-03-21T00:00:00','2026-03-23T00:00:00',1,330293.233,GETDATE()),
      (4,4,'YUC','SIN','2026-04-01T00:00:00','2026-04-04T00:00:00',1,330293.233,GETDATE()),
      (5,5,'TAB','VER','2026-04-11T00:00:00','2026-04-15T00:00:00',1,330293.233,GETDATE())
GO




