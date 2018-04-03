CREATE TABLE [dbo].[DivisionEnrollment]
(
	[Id] UNIQUEIDENTIFIER NOT NULL PRIMARY KEY DEFAULT NEWID(),
	[Year] INT NOT NULL,
	[MaleMax] INT NOT NULL,
	[MaleMin] INT NOT NULL,
	[FemaleMax] INT NOT NULL,
	[FemaleMin] INT NOT NULL,
	[DivisionId] UNIQUEIDENTIFIER NOT NULL,
    [InsertedDate] DATETIMEOFFSET NOT NULL DEFAULT SYSDATETIMEOFFSET(), 
    [UpdatedDate] DATETIMEOFFSET NOT NULL DEFAULT SYSDATETIMEOFFSET()
)

GO

CREATE TRIGGER [dbo].[DivisionEnrollment_AfterUpdate]
    ON [dbo].[DivisionEnrollment]
    FOR UPDATE
    AS
    BEGIN
        SET NoCount ON
		UPDATE
			[dbo].[DivisionEnrollment]
		SET
			[UpdatedDate] = SYSDATETIMEOFFSET()
		WHERE
			[Id] = (SELECT DISTINCT [Id] FROM inserted);
    END
GO

ALTER TABLE [dbo].[DivisionEnrollment]  WITH CHECK ADD  CONSTRAINT [FK_DivisionEnrollment_Division] FOREIGN KEY([DivisionId])
REFERENCES [dbo].[Division] ([Id])
GO

ALTER TABLE [dbo].[DivisionEnrollment] CHECK CONSTRAINT [FK_DivisionEnrollment_Division]
GO

