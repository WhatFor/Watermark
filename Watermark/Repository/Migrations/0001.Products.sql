IF ((SELECT 1 FROM [dbo].[_MigrationHistory] WHERE [MigrationName] = N'Products') IS NULL)
BEGIN

	CREATE TABLE [dbo].[Products] (
		[Id] INT IDENTITY(1,1) PRIMARY KEY NOT NULL
	);
	
	INSERT INTO [dbo].[_MigrationHistory] ([MigrationName], [DateApplied]) VALUES (N'Products', CURRENT_TIMESTAMP);
END;