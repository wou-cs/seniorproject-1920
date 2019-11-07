
-- *********** Drop Tables ***********


-- #######################################
-- #             Identity Tables         #
-- #######################################

--DROP TABLE [dbo].[__MigrationHistory];
DROP TABLE [dbo].[AspNetUserRoles];
DROP TABLE [dbo].[AspNetRoles];
DROP TABLE [dbo].[AspNetUserClaims];
DROP TABLE [dbo].[AspNetUserLogins];
DROP TABLE [dbo].[AspNetUsers];


-- #######################################
-- #            Our Model Tables         #
-- #######################################
ALTER TABLE [dbo].[SUPUsers] DROP CONSTRAINT [FK_dbo.SUPUsers_dbo.SUPGroups_ID];
ALTER TABLE [dbo].[SUPMeetings] DROP CONSTRAINT [FK_dbo.SUPMeetings_dbo.SUPUsers_ID];
ALTER TABLE [dbo].[SUPGroups] DROP CONSTRAINT [FK_dbo.SUPGroups_dbo.SUPAcademicYears_ID];

DROP TABLE [dbo].[SUPGroups];
DROP TABLE [dbo].[SUPAdvisors];
DROP TABLE [dbo].[SUPUsers];
DROP TABLE [dbo].[SUPMeetings];

DROP TABLE [dbo].[SUPAcademicYears];