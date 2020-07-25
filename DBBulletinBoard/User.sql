﻿CREATE TABLE [dbo].[User]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY(1,1),
	[Email] VARCHAR(100) NOT NULL UNIQUE,
	[Password] VARCHAR(100) NOT NULL,
	[FirstName] VARCHAR(100) NOT NULL,
	[SecondName] VARCHAR(100) NOT NULL,
	[Phone] VARCHAR(10),
	[Age] INT,
	[Gender] VARCHAR(10)
)