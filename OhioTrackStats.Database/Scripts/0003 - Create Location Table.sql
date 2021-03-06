﻿CREATE TABLE [dbo].[Location]
(
	[Id] UNIQUEIDENTIFIER NOT NULL PRIMARY KEY DEFAULT NEWID(), 
    [Address1] NVARCHAR(4000) NOT NULL, 
    [Address2] NVARCHAR(4000) NULL,
	[City] NVARCHAR(4000) NULL,
	[State] NVARCHAR(100) NULL,
	[Zip] NVARCHAR(50) NULL,
    [InsertedDate] DATETIMEOFFSET NOT NULL DEFAULT SYSDATETIMEOFFSET(), 
    [UpdatedDate] DATETIMEOFFSET NOT NULL DEFAULT SYSDATETIMEOFFSET()
)

GO

CREATE TRIGGER [dbo].[Location_AfterUpdate]
    ON [dbo].[Location]
    FOR UPDATE
    AS
    BEGIN
        SET NoCount ON
		UPDATE
			[dbo].[Location]
		SET
			[UpdatedDate] = SYSDATETIMEOFFSET()
		WHERE
			[Id] = (SELECT DISTINCT [Id] FROM inserted);
    END
GO