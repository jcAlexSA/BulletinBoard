﻿CREATE TABLE [dbo].[Question]
(
	[QuestionId] INT NOT NULL PRIMARY KEY IDENTITY(1,1),
	[AdvertId] INT NOT NULL,
	[Question] VARCHAR(1000) NOT NULL,
	[PublishDate] DATETIME NOT NULL,
	[UserId] INT NOT NULL
)
