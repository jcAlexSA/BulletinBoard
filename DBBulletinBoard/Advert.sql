CREATE TABLE [dbo].[Advert]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY(1, 1),
	[Title] VARCHAR(250) NOT NULL,
	[Description] VARCHAR(8000) NOT NULL,
	[PublishDate] DateTime NOT NULL
)
