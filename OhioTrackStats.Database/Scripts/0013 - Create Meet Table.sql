﻿CREATE TABLE [dbo].[Meet]
(
	[Id] UNIQUEIDENTIFIER NOT NULL PRIMARY KEY DEFAULT NEWID(), 
    [Name] NVARCHAR(25) NOT NULL, 
    [LocationId] UNIQUEIDENTIFIER NOT NULL, 
    [Date] DATETIMEOFFSET NOT NULL, 
    [InsertedDate] DATETIMEOFFSET NOT NULL DEFAULT SYSDATETIMEOFFSET(), 
    [UpdatedDate] DATETIMEOFFSET NOT NULL DEFAULT SYSDATETIMEOFFSET()
)

GO

CREATE TRIGGER [dbo].[Meet_AfterUpdate]
    ON [dbo].[Meet]
    FOR UPDATE
    AS
    BEGIN
        SET NoCount ON
		UPDATE
			[dbo].[Meet]
		SET
			[UpdatedDate] = SYSDATETIMEOFFSET()
		WHERE
			[Id] = (SELECT DISTINCT [Id] FROM inserted);
    END
GO

ALTER TABLE [dbo].[Meet]  WITH CHECK ADD  CONSTRAINT [FK_Meet_Location] FOREIGN KEY([LocationId])
REFERENCES [dbo].[Location] ([Id])
GO

ALTER TABLE [dbo].[Meet] CHECK CONSTRAINT [FK_Meet_Location]
GO