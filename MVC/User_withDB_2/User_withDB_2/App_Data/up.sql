CREATE TABLE [dbo].[Users]
(
	[ID]		INT IDENTITY (1,1)	NOT NULL,
	[FirstName] NVARCHAR(64)		NOT NULL,
	[LastName]	NVARCHAR(128)		NOT NULL,
	[DOB]		DATETIME			NOT NULL,
	CONSTRAINT [PK_dbo.Users] PRIMARY KEY CLUSTERED ([ID] ASC)
);

INSERT INTO [dbo].[Users] (FirstName, LastName, DOB) VALUES
	('Madonna','The Material Girl','1958-08-16 00:00:00'),
	('Phil','Collins','1959-08-16 00:00:00'),
	('Bob','Saget','1957-08-16 00:00:00'),
	('Jimmie','Hoffa','1927-09-12 02:02:10')
GO