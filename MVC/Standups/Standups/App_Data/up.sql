

-- #######################################
-- #             Identity Tables         #
-- #######################################

-- ############# AspNetRoles #############
CREATE TABLE [dbo].[AspNetRoles]
(
    [Id]   NVARCHAR (128) NOT NULL,
    [Name] NVARCHAR (256) NOT NULL,
    CONSTRAINT [PK_dbo.AspNetRoles] PRIMARY KEY CLUSTERED ([Id] ASC)
);
GO
CREATE UNIQUE NONCLUSTERED INDEX [RoleNameIndex]
    ON [dbo].[AspNetRoles]([Name] ASC);

-- ############# AspNetUsers #############
CREATE TABLE [dbo].[AspNetUsers]
(
    [Id]                   NVARCHAR (128) NOT NULL,
    [Email]                NVARCHAR (256) NULL,
    [EmailConfirmed]       BIT            NOT NULL,
    [PasswordHash]         NVARCHAR (MAX) NULL,
    [SecurityStamp]        NVARCHAR (MAX) NULL,
    [PhoneNumber]          NVARCHAR (MAX) NULL,
    [PhoneNumberConfirmed] BIT            NOT NULL,
    [TwoFactorEnabled]     BIT            NOT NULL,
    [LockoutEndDateUtc]    DATETIME       NULL,
    [LockoutEnabled]       BIT            NOT NULL,
    [AccessFailedCount]    INT            NOT NULL,
    [UserName]             NVARCHAR (256) NOT NULL,
    CONSTRAINT [PK_dbo.AspNetUsers] PRIMARY KEY CLUSTERED ([Id] ASC)
);
GO
CREATE UNIQUE NONCLUSTERED INDEX [UserNameIndex] ON [dbo].[AspNetUsers]([UserName] ASC);

-- ############# AspNetUserClaims #############
CREATE TABLE [dbo].[AspNetUserClaims]
(
    [Id]         INT            IDENTITY (1, 1) NOT NULL,
    [UserId]     NVARCHAR (128) NOT NULL,
    [ClaimType]  NVARCHAR (MAX) NULL,
    [ClaimValue] NVARCHAR (MAX) NULL,
    CONSTRAINT [PK_dbo.AspNetUserClaims] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_dbo.AspNetUserClaims_dbo.AspNetUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [dbo].[AspNetUsers] ([Id]) ON DELETE CASCADE
);
GO
CREATE NONCLUSTERED INDEX [IX_UserId] ON [dbo].[AspNetUserClaims]([UserId] ASC);

-- ############# AspNetUserLogins #############
CREATE TABLE [dbo].[AspNetUserLogins]
(
    [LoginProvider] NVARCHAR (128) NOT NULL,
    [ProviderKey]   NVARCHAR (128) NOT NULL,
    [UserId]        NVARCHAR (128) NOT NULL,
    CONSTRAINT [PK_dbo.AspNetUserLogins] PRIMARY KEY CLUSTERED ([LoginProvider] ASC, [ProviderKey] ASC, [UserId] ASC),
    CONSTRAINT [FK_dbo.AspNetUserLogins_dbo.AspNetUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [dbo].[AspNetUsers] ([Id]) ON DELETE CASCADE
);
GO
CREATE NONCLUSTERED INDEX [IX_UserId] ON [dbo].[AspNetUserLogins]([UserId] ASC);

-- ############# AspNetUserRoles #############
CREATE TABLE [dbo].[AspNetUserRoles]
(
    [UserId] NVARCHAR (128) NOT NULL,
    [RoleId] NVARCHAR (128) NOT NULL,
    CONSTRAINT [PK_dbo.AspNetUserRoles] PRIMARY KEY CLUSTERED ([UserId] ASC, [RoleId] ASC),
    CONSTRAINT [FK_dbo.AspNetUserRoles_dbo.AspNetRoles_RoleId] FOREIGN KEY ([RoleId]) REFERENCES [dbo].[AspNetRoles] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_dbo.AspNetUserRoles_dbo.AspNetUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [dbo].[AspNetUsers] ([Id]) ON DELETE CASCADE
);
GO
CREATE NONCLUSTERED INDEX [IX_UserId] ON [dbo].[AspNetUserRoles]([UserId] ASC);
GO
CREATE NONCLUSTERED INDEX [IX_RoleId] ON [dbo].[AspNetUserRoles]([RoleId] ASC);


-- #######################################
-- #            Our Model Tables         #
-- #######################################

-- ########### SUPAdvisors ###########
CREATE TABLE [dbo].[SUPAdvisors]
(
	[ID] INT IDENTITY (1,1) NOT NULL,
	[FirstName] NVARCHAR (50) NOT NULL,
	[LastName] NVARCHAR (50) NOT NULL,
	CONSTRAINT [PK_dbo.SUPAdvisors] PRIMARY KEY CLUSTERED ([ID] ASC)
);

-- ########### SUPGroups ###########
CREATE TABLE [dbo].[SUPGroups]
(
	[ID] INT IDENTITY (1,1) NOT NULL,
	[Name] NVARCHAR (50) NOT NULL,
	[Motto] NVARCHAR (100) NOT NULL,
	[SUPAdvisorID] INT,
	[SUPAcademicYearID] INT NOT NULL,
	CONSTRAINT [PK_dbo.SUPGroups] PRIMARY KEY CLUSTERED ([ID] ASC),
	CONSTRAINT [FK_dbo.SUPGroups_dbo.SUPAdvisors_ID] FOREIGN KEY ([SUPAdvisorID]) 
		REFERENCES [dbo].[SUPAdvisors] ([ID])
);

-- ########### SUPUsers ###########
CREATE TABLE [dbo].[SUPUsers]
(
	[ID] INT IDENTITY (1,1)		NOT NULL,
	[FirstName] NVARCHAR (50)	NOT NULL,
	[LastName] NVARCHAR (50)	NOT NULL,
	[SUPGroupID] INT,
	[ASPNetIdentityID] NVARCHAR (128) NOT NULL,			-- Id into Identity User table, but NOT a FK on purpose
	CONSTRAINT [PK_dbo.SUPUsers] PRIMARY KEY CLUSTERED ([ID] ASC),
	CONSTRAINT [FK_dbo.SUPUsers_dbo.SUPGroups_ID] FOREIGN KEY ([SUPGroupID]) 
		REFERENCES [dbo].[SUPGroups] ([ID])
);

-- ########### SUPMeetings ###########
-- finally, the table of meeting reports.
CREATE TABLE [dbo].[SUPMeetings]
(
	[ID] INT IDENTITY (1,1)		NOT NULL,
	[SubmissionDate] DATETIME	NOT NULL,
	[SUPUserID] INT				NOT NULL,
	[Completed] NVARCHAR(1000)	NOT NULL,
	[Planning] NVARCHAR(1000)	NOT NULL,
	[Obstacles] NVARCHAR(1000)	NOT NULL,
	CONSTRAINT [PK_dbo.SUPMeetings] PRIMARY KEY CLUSTERED ([ID] ASC),
	CONSTRAINT [FK_dbo.SUPMeetings_dbo.SUPUsers_ID] FOREIGN KEY ([SUPUserID]) 
		REFERENCES [dbo].[SUPUsers] ([ID])
);

-- ########### SUPAcademicYears ###########
-- Academic Year table, so we know which students/groups to display each year
CREATE TABLE [dbo].[SUPAcademicYears]
(
	[ID]	  INT IDENTITY (1,1)	NOT NULL,
	[Year]    CHAR (9)				NOT NULL,
	CONSTRAINT [PK_dbo.SUPAcademicYears] PRIMARY KEY CLUSTERED ([ID] ASC)
);
GO

-- populate academic years table
INSERT INTO [dbo].[SUPAcademicYears] (Year) VALUES 
	('2016-2017'),
	('2017-2018'),
	('2018-2019'),
	('2019-2020'),
	('2020-2021'),
	('2021-2022'),
	('2022-2023'),
	('2023-2024'),
	('2024-2025'),
	('2025-2026');
GO

-- Add FK to year id.  Doing it this way rather than reordering the create's above
ALTER TABLE [dbo].[SUPGroups] ADD CONSTRAINT [FK_dbo.SUPGroups_dbo.SUPAcademicYears_ID] FOREIGN KEY ([SUPAcademicYearID]) REFERENCES [dbo].[SUPAcademicYears] ([ID]); 
GO