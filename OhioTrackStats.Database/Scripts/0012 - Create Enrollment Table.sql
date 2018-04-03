CREATE TABLE [dbo].[Enrollment]
(
	[Id] UNIQUEIDENTIFIER NOT NULL PRIMARY KEY DEFAULT NEWID(), 
    [Year] [int] NOT NULL,
	[Male] [int] NOT NULL,
	[Female] [int] NOT NULL,
	[SchoolId] [uniqueidentifier] NOT NULL,
    [InsertedDate] DATETIMEOFFSET NOT NULL DEFAULT SYSDATETIMEOFFSET(), 
    [UpdatedDate] DATETIMEOFFSET NOT NULL DEFAULT SYSDATETIMEOFFSET()
)

GO

CREATE TRIGGER [dbo].[Enrollment_AfterUpdate]
    ON [dbo].[Enrollment]
    FOR UPDATE
    AS
    BEGIN
        SET NoCount ON
		UPDATE
			[dbo].[Enrollment]
		SET
			[UpdatedDate] = SYSDATETIMEOFFSET()
		WHERE
			[Id] = (SELECT DISTINCT [Id] FROM inserted);
    END
GO

ALTER TABLE [dbo].[Enrollment]  WITH CHECK ADD  CONSTRAINT [FK_Enrollment_School] FOREIGN KEY([SchoolId])
REFERENCES [dbo].[School] ([Id])
GO

ALTER TABLE [dbo].[Enrollment] CHECK CONSTRAINT [FK_Enrollment_School]
GO