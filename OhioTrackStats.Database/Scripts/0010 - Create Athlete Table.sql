CREATE TABLE [dbo].[Athlete]
(
	[Id] UNIQUEIDENTIFIER NOT NULL PRIMARY KEY DEFAULT NEWID(), 
    [FirstName] NVARCHAR(4000) NULL,
	[LastName] NVARCHAR(4000) NULL,
	[Gender] NVARCHAR(10) NULL,
	[SchoolId] UNIQUEIDENTIFIER NOT NULL,
	[GraduationYear] INT,
    [InsertedDate] DATETIMEOFFSET NOT NULL DEFAULT SYSDATETIMEOFFSET(), 
    [UpdatedDate] DATETIMEOFFSET NOT NULL DEFAULT SYSDATETIMEOFFSET()
)

GO

CREATE TRIGGER [dbo].[Athlete_AfterUpdate]
    ON [dbo].[Athlete]
    FOR UPDATE
    AS
    BEGIN
        SET NoCount ON
		UPDATE
			[dbo].[Athlete]
		SET
			[UpdatedDate] = SYSDATETIMEOFFSET()
		WHERE
			[Id] = (SELECT DISTINCT [Id] FROM inserted);
    END
GO

ALTER TABLE [dbo].[Athlete]  WITH CHECK ADD  CONSTRAINT [FK_Athlete_School] FOREIGN KEY([SchoolId])
REFERENCES [dbo].[School] ([Id])
GO

ALTER TABLE [dbo].[Athlete] CHECK CONSTRAINT [FK_Athlete_School]
GO