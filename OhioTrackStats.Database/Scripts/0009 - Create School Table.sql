CREATE TABLE [dbo].[School]
(
	[Id] UNIQUEIDENTIFIER NOT NULL PRIMARY KEY DEFAULT NEWID(), 
    [Name] NVARCHAR(4000) NULL,
	[OhsaaId] INT NOT NULL,
	[ConferenceId] UNIQUEIDENTIFIER NOT NULL,
	[LocationId] UNIQUEIDENTIFIER NOT NULL,
	[Phone] NVARCHAR(100) NULL,
	[Fax] NVARCHAR(100) NULL,
	[Website] NVARCHAR(max) NULL,
	[CountyId] UNIQUEIDENTIFIER NOT NULL,
	[OhsaaDistrictId] UNIQUEIDENTIFIER NOT NULL,
	[OhsaaTournamentName] NVARCHAR(4000) NULL,
	[PrimaryColor] INT NOT NULL,
	[SecondaryColor] INT NOT NULL,
	[TertiaryColor] INT NOT NULL,
	[MaleMascot] NVARCHAR(200) NULL,
	[FemaleMascot] NVARCHAR(200) NULL,
	[SchoolType] NVARCHAR(20) NULL,
    [InsertedDate] DATETIMEOFFSET NOT NULL DEFAULT SYSDATETIMEOFFSET(), 
    [UpdatedDate] DATETIMEOFFSET NOT NULL DEFAULT SYSDATETIMEOFFSET()
)

GO

CREATE TRIGGER [dbo].[School_AfterUpdate]
    ON [dbo].[School]
    FOR UPDATE
    AS
    BEGIN
        SET NoCount ON
		UPDATE
			[dbo].[School]
		SET
			[UpdatedDate] = SYSDATETIMEOFFSET()
		WHERE
			[Id] = (SELECT DISTINCT [Id] FROM inserted);
    END
GO

ALTER TABLE [dbo].[School]  WITH CHECK ADD  CONSTRAINT [FK_School_Conference] FOREIGN KEY([ConferenceId])
REFERENCES [dbo].[Conference] ([Id])
GO

ALTER TABLE [dbo].[School] CHECK CONSTRAINT [FK_School_Conference]
GO

ALTER TABLE [dbo].[School]  WITH CHECK ADD  CONSTRAINT [FK_School_Location] FOREIGN KEY([LocationId])
REFERENCES [dbo].[Location] ([Id])
GO

ALTER TABLE [dbo].[School] CHECK CONSTRAINT [FK_School_Location]
GO

ALTER TABLE [dbo].[School]  WITH CHECK ADD  CONSTRAINT [FK_School_County] FOREIGN KEY([CountyId])
REFERENCES [dbo].[County] ([Id])
GO

ALTER TABLE [dbo].[School] CHECK CONSTRAINT [FK_School_County]
GO

ALTER TABLE [dbo].[School]  WITH CHECK ADD  CONSTRAINT [FK_School_OhsaaDistrict] FOREIGN KEY([OhsaaDistrictId])
REFERENCES [dbo].[OhsaaDistrict] ([Id])
GO

ALTER TABLE [dbo].[School] CHECK CONSTRAINT [FK_School_OhsaaDistrict]
GO

