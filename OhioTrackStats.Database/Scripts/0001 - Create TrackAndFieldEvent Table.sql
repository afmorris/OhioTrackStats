CREATE TABLE [dbo].[TrackAndFieldEvent]
(
	[Id] UNIQUEIDENTIFIER NOT NULL PRIMARY KEY DEFAULT NEWID(), 
    [Name] NVARCHAR(25) NOT NULL, 
	[SafeName] NVARCHAR(25) NOT NULL, 
    [Gender] NVARCHAR(10) NOT NULL, 
    [IsRunningEvent] BIT NOT NULL, 
    [IsRelayEvent] BIT NOT NULL, 
	[Order] INT NOT NULL,
    [InsertedDate] DATETIMEOFFSET NOT NULL DEFAULT SYSDATETIMEOFFSET(), 
    [UpdatedDate] DATETIMEOFFSET NOT NULL DEFAULT SYSDATETIMEOFFSET()
)

GO

CREATE TRIGGER [dbo].[TrackAndFieldEvent_AfterUpdate]
    ON [dbo].[TrackAndFieldEvent]
    FOR UPDATE
    AS
    BEGIN
        SET NoCount ON
		UPDATE
			[dbo].[TrackAndFieldEvent]
		SET
			[UpdatedDate] = SYSDATETIMEOFFSET()
		WHERE
			[Id] = (SELECT DISTINCT [Id] FROM inserted);
    END
GO

CREATE INDEX [IX_TrackAndFieldEvent_Gender] ON [dbo].[TrackAndFieldEvent] ([Gender]);

GO

CREATE INDEX [IX_TrackAndFieldEvent_RunningEvent] ON [dbo].[TrackAndFieldEvent] ([IsRunningEvent]);

GO

CREATE INDEX [IX_TrackAndFieldEvent_RelayEvent] ON [dbo].[TrackAndFieldEvent] ([IsRelayEvent]);
