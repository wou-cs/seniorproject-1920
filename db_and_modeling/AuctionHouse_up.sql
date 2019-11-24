-- Reginalds Ancient Antiquities Auction House
-- Example for first "simple" data model
-- Create tables and populate with seed data

CREATE TABLE [dbo].[Buyers]
(
	[ID]	INT IDENTITY (1,1)	NOT NULL,
	[Name]	NVARCHAR (50)		NOT NULL,
	CONSTRAINT [PK_dbo.Buyers] PRIMARY KEY CLUSTERED ([ID] ASC)
);

CREATE TABLE [dbo].[Sellers]
(
	[ID]	INT IDENTITY (1,1)	NOT NULL,
	[Name]	NVARCHAR (50)		NOT NULL,
	CONSTRAINT [PK_dbo.Sellers] PRIMARY KEY CLUSTERED ([ID] ASC)
);

CREATE TABLE [dbo].[Items]
(
	[ID]			INT IDENTITY (1001,1)	NOT NULL,
	[Name]			NVARCHAR (50)			NOT NULL,
	[Description]	NVARCHAR (256)	NOT NULL,
	[SellerID]		INT,
	CONSTRAINT [PK_dbo.Items] PRIMARY KEY CLUSTERED ([ID] ASC),
	CONSTRAINT [FK_dbo.Items_dbo.Sellers_ID] FOREIGN KEY ([SellerID]) REFERENCES [dbo].[Sellers] ([ID])
);

CREATE TABLE [dbo].[Bids]
(
	[ID]		INT IDENTITY (1,1) NOT NULL,
	[ItemID]	INT,
	[BuyerID]	INT,
	[Price]		DECIMAL (17,2),
	[Timestamp]	DATETIME,
	CONSTRAINT [PK_dbo.Bids] PRIMARY KEY CLUSTERED ([ID] ASC),
	CONSTRAINT [FK_dbo.Bids_dbo.Items_ID] FOREIGN KEY ([ItemID]) REFERENCES [dbo].[Items] ([ID]),
	CONSTRAINT [FK_dbo.Bids_dbo.Buyers_ID] FOREIGN KEY ([BuyerID]) REFERENCES [dbo].[Buyers] ([ID])
);

INSERT INTO [dbo].[Buyers](Name)
	VALUES
	('Jane Stone'),
	('Tom McMasters'),
	('Otto Vanderwall');

INSERT INTO [dbo].[Sellers](Name)
	VALUES
	('Gayle Hardy'),
	('Lyle Banks'),
	('Pearl Greene');

INSERT INTO [dbo].[Items](Name,Description,SellerID)
	VALUES
	('Abraham Lincoln Hammer','A bench mallet fashioned from a broken rail-splitting maul in 1829 and owned by Abraham Lincoln',3),
	('Albert Einsteins Telescope','A brass telescope owned by Albert Einstein in Germany, circa 1927',1),
	('Bob Dylan Love Poems','Five versions of an original unpublished, handwritten, love poem by Bob Dylan',2);

INSERT INTO [dbo].[Bids](ItemID,BuyerID,Price,Timestamp)
	VALUES
	(1001,3,250000,	'12/04/2017 09:04:22'),
	(1003,1,95000,  '12/04/2017 08:44:03');