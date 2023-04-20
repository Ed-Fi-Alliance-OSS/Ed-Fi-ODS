CREATE TABLE [tracked_deletes_samplestudenttransportation].[StudentTransportation]
(
       AMBusNumber [NVARCHAR](6) NOT NULL,
       PMBusNumber [NVARCHAR](6) NOT NULL,
       SchoolId [INT] NOT NULL,
       StudentUSI [INT] NOT NULL,
       Id uniqueidentifier NOT NULL,
       ChangeVersion bigint NOT NULL,
       CONSTRAINT PK_StudentTransportation PRIMARY KEY CLUSTERED (ChangeVersion)
)
