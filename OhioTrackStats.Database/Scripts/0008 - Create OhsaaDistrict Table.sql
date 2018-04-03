CREATE TABLE [dbo].[OhsaaDistrict]
(
	[Id] UNIQUEIDENTIFIER NOT NULL PRIMARY KEY DEFAULT NEWID(), 
    [Name] NVARCHAR(50) NOT NULL,
    [InsertedDate] DATETIMEOFFSET NOT NULL DEFAULT SYSDATETIMEOFFSET(), 
    [UpdatedDate] DATETIMEOFFSET NOT NULL DEFAULT SYSDATETIMEOFFSET()
)

GO

CREATE TRIGGER [dbo].[OhsaaDistrict_AfterUpdate]
    ON [dbo].[OhsaaDistrict]
    FOR UPDATE
    AS
    BEGIN
        SET NoCount ON
		UPDATE
			[dbo].[OhsaaDistrict]
		SET
			[UpdatedDate] = SYSDATETIMEOFFSET()
		WHERE
			[Id] = (SELECT DISTINCT [Id] FROM inserted);
    END
GO