CREATE TABLE [dbo].[Advert]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY(1, 1),
	[Title] VARCHAR(250) NOT NULL,
	[Description] VARCHAR(8000) NOT NULL,
	[PublishDate] DateTime NOT NULL,
	[UserId] INT NOT NULL
	CONSTRAINT FK_Advert_User FOREIGN KEY (UserId)
        REFERENCES [dbo].[User] ([Id])
        ON DELETE CASCADE
        ON UPDATE CASCADE
)