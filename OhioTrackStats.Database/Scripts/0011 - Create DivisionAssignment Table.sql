CREATE TABLE [dbo].[DivisionAssignment]
(
	[Id] UNIQUEIDENTIFIER NOT NULL PRIMARY KEY DEFAULT NEWID(), 
    [DivisionId] UNIQUEIDENTIFIER NOT NULL,
	[SchoolId] UNIQUEIDENTIFIER NOT NULL,
	[Gender] NVARCHAR(10) NULL,
	[Year] INT NOT NULL,
    [InsertedDate] DATETIMEOFFSET NOT NULL DEFAULT SYSDATETIMEOFFSET(), 
    [UpdatedDate] DATETIMEOFFSET NOT NULL DEFAULT SYSDATETIMEOFFSET()
)

GO

CREATE TRIGGER [dbo].[DivisionAssignment_AfterUpdate]
    ON [dbo].[DivisionAssignment]
    FOR UPDATE
    AS
    BEGIN
        SET NoCount ON
		UPDATE
			[dbo].[DivisionAssignment]
		SET
			[UpdatedDate] = SYSDATETIMEOFFSET()
		WHERE
			[Id] = (SELECT DISTINCT [Id] FROM inserted);
    END
GO

ALTER TABLE [dbo].[DivisionAssignment]  WITH CHECK ADD  CONSTRAINT [FK_DivisionAssignment_Division] FOREIGN KEY([DivisionId])
REFERENCES [dbo].[Division] ([Id])
GO

ALTER TABLE [dbo].[DivisionAssignment] CHECK CONSTRAINT [FK_DivisionAssignment_Division]
GO

ALTER TABLE [dbo].[DivisionAssignment]  WITH CHECK ADD  CONSTRAINT [FK_DivisionAssignment_School] FOREIGN KEY([SchoolId])
REFERENCES [dbo].[School] ([Id])
GO

ALTER TABLE [dbo].[DivisionAssignment] CHECK CONSTRAINT [FK_DivisionAssignment_School]
GO