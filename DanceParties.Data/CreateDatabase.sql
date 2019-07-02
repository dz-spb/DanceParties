CREATE DATABASE [DanceParties];
GO

USE [DanceParties];
GO

CREATE TABLE [dbo].[City] (
    [Id]   INT            NOT NULL IDENTITY,
    [Name] NVARCHAR (100) NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);
GO

CREATE TABLE [dbo].[Dance] (
    [Id]   INT            NOT NULL IDENTITY,
    [Name] NVARCHAR (100) NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);
GO

CREATE TABLE [dbo].[Location] (
    [Id]      INT            NOT NULL IDENTITY,
    [CityId]  INT            NOT NULL,
	[Name]	  NVARCHAR (100) NOT NULL,
    [Address] NVARCHAR (100),
    PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Location_City] FOREIGN KEY ([CityId]) REFERENCES [dbo].[City] ([Id])
);
GO

CREATE TABLE [dbo].[Party] (
    [Id]		INT               NOT NULL IDENTITY,
    [LocationId]	INT           NOT NULL,
    [DanceId]	INT               NOT NULL,
	[Name]		NVARCHAR(100),
    [Start]	DATETIMEOFFSET (0) NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Party_Location] FOREIGN KEY ([LocationId]) REFERENCES [dbo].[Location] ([Id]),
    CONSTRAINT [FK_Party_Dance] FOREIGN KEY ([DanceId]) REFERENCES [dbo].[Dance] ([Id])
);
GO
