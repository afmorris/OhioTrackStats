CREATE TABLE [dbo].[Performance]
(
	[Id] UNIQUEIDENTIFIER NOT NULL PRIMARY KEY DEFAULT NEWID(), 
    [EventId] UNIQUEIDENTIFIER NOT NULL,
	[SchoolId] UNIQUEIDENTIFIER NOT NULL,
	[MeetId] UNIQUEIDENTIFIER NOT NULL,
	[Data] DECIMAL(38, 6) NOT NULL,
	[Date] DATETIMEOFFSET NOT NULL,
	[TimingMethod] NVARCHAR(20) NOT NULL,
	[Notes] NVARCHAR(4000) NULL,
	[ComputedScore] DECIMAL(38, 6) NOT NULL DEFAULT 0,
	[Approved] BIT NOT NULL DEFAULT 0,
	[ApprovalDate] DATETIMEOFFSET NULL,
    [InsertedDate] DATETIMEOFFSET NOT NULL DEFAULT SYSDATETIMEOFFSET(), 
    [UpdatedDate] DATETIMEOFFSET NOT NULL DEFAULT SYSDATETIMEOFFSET()
)

GO

CREATE TRIGGER [dbo].[Performance_AfterUpdate]
    ON [dbo].[Performance]
    FOR UPDATE
    AS
    BEGIN
        SET NoCount ON
		UPDATE
			[dbo].[Performance]
		SET
			[UpdatedDate] = SYSDATETIMEOFFSET()
		WHERE
			[Id] = (SELECT DISTINCT [Id] FROM inserted);
    END
GO

ALTER TABLE [dbo].[Performance]  WITH CHECK ADD  CONSTRAINT [FK_Performance_Event] FOREIGN KEY([EventId])
REFERENCES [dbo].[TrackAndFieldEvent] ([Id])
GO

ALTER TABLE [dbo].[Performance] CHECK CONSTRAINT [FK_Performance_Event]
GO

ALTER TABLE [dbo].[Performance]  WITH CHECK ADD  CONSTRAINT [FK_Performance_School] FOREIGN KEY([SchoolId])
REFERENCES [dbo].[School] ([Id])
GO

ALTER TABLE [dbo].[Performance] CHECK CONSTRAINT [FK_Performance_School]
GO

ALTER TABLE [dbo].[Performance]  WITH CHECK ADD  CONSTRAINT [FK_Performance_Meet] FOREIGN KEY([MeetId])
REFERENCES [dbo].[Meet] ([Id])
GO

ALTER TABLE [dbo].[Performance] CHECK CONSTRAINT [FK_Performance_Meet]
GO