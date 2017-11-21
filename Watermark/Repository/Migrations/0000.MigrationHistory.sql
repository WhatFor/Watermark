IF (OBJECT_ID(N'dbo._MigrationHistory', N'U') IS NULL)
BEGIN

	CREATE TABLE [dbo].[_MigrationHistory] (
		[Id] INT IDENTITY(1, 1) PRIMARY KEY NOT NULL ,
		[MigrationName] NVARCHAR(35) NOT NULL INDEX [IX_MigrationName] NONCLUSTERED,
		[DateApplied] DATETIMEOFFSET(0) NOT NULL DEFAULT (CURRENT_TIMESTAMP)
	);

	INSERT INTO [dbo].[_MigrationHistory] ([MigrationName], [DateApplied]) VALUES (N'MigrationHistory', CURRENT_TIMESTAMP);

END;