CREATE TABLE [dbo].[AthletePerformance]
(
	[Id] UNIQUEIDENTIFIER NOT NULL PRIMARY KEY DEFAULT NEWID(), 
    [AthleteId] UNIQUEIDENTIFIER NOT NULL,
	[PerformanceId] UNIQUEIDENTIFIER NOT NULL,
    [InsertedDate] DATETIMEOFFSET NOT NULL DEFAULT SYSDATETIMEOFFSET(), 
    [UpdatedDate] DATETIMEOFFSET NOT NULL DEFAULT SYSDATETIMEOFFSET()
)

GO

CREATE TRIGGER [dbo].[AthletePerformance_AfterUpdate]
    ON [dbo].[AthletePerformance]
    FOR UPDATE
    AS
    BEGIN
        SET NoCount ON
		UPDATE
			[dbo].[AthletePerformance]
		SET
			[UpdatedDate] = SYSDATETIMEOFFSET()
		WHERE
			[Id] = (SELECT DISTINCT [Id] FROM inserted);
    END
GO

ALTER TABLE [dbo].[AthletePerformance]  WITH CHECK ADD  CONSTRAINT [FK_AthletePerformance_Athlete] FOREIGN KEY([AthleteId])
REFERENCES [dbo].[Athlete] ([Id])
GO

ALTER TABLE [dbo].[AthletePerformance] CHECK CONSTRAINT [FK_AthletePerformance_Athlete]
GO

ALTER TABLE [dbo].[AthletePerformance]  WITH CHECK ADD  CONSTRAINT [FK_AthletePerformance_Performance] FOREIGN KEY([PerformanceId])
REFERENCES [dbo].[Performance] ([Id])
GO

ALTER TABLE [dbo].[AthletePerformance] CHECK CONSTRAINT [FK_AthletePerformance_Performance]
GO
