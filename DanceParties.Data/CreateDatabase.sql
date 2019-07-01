--CREATE DATABASE [DanceParties];
--GO

USE [DanceParties];
GO

CREATE TABLE [dbo].[Cities] (
    [Id]   INT            NOT NULL IDENTITY,
    [Name] NVARCHAR (100) NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);
GO

CREATE TABLE [dbo].[Dances] (
    [Id]   INT            NOT NULL IDENTITY,
    [Name] NVARCHAR (100) NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);
GO

CREATE TABLE [dbo].[Locations] (
    [Id]      INT            NOT NULL IDENTITY,
    [CityId]  INT            NOT NULL,
	[Name]	  NVARCHAR (100) NOT NULL,
    [Address] NVARCHAR (100),
    PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Locations_Cities] FOREIGN KEY ([CityId]) REFERENCES [dbo].[Cities] ([Id])
);
GO

CREATE TABLE [dbo].[Parties] (
    [Id]		INT               NOT NULL IDENTITY,
    [LocationId]	INT           NOT NULL,
    [DanceId]	INT               NOT NULL,
	[Name]		NVARCHAR(100),
    [DateTime]	DATETIMEOFFSET (7) NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Parties_Locations] FOREIGN KEY ([LocationId]) REFERENCES [dbo].[Locations] ([Id]),
    CONSTRAINT [FK_Parties_Dances] FOREIGN KEY ([DanceId]) REFERENCES [dbo].[Dances] ([Id])
);
GO

SET IDENTITY_INSERT [dbo].[Cities] ON

INSERT INTO [dbo].[Cities] ([Id], [Name]) VALUES
(1, 'Санкт-Петебург'),
(2, 'Москва'),
(3, 'Минск')

SET IDENTITY_INSERT [dbo].[Cities] OFF

GO

SET IDENTITY_INSERT [dbo].[Dances] ON

INSERT INTO [dbo].[Dances] ([Id], [Name]) VALUES
(1, 'Сальса'),
(2, 'Бачата'),
(3, 'Хастл')

SET IDENTITY_INSERT [dbo].[Dances] OFF

GO

SET IDENTITY_INSERT [dbo].[Locations] ON

INSERT INTO [dbo].[Locations] ([Id], [CityId], [Name], [Address]) VALUES
(1, 1, 'Tropikana-Atrium', 'Невский 71'),
(2, 1, 'AnyDay', 'Херсонская 12-14'),
(3, 1, 'Ростральные колонны, зимняя площадка', 'Стрелка В.О.'),
(4, 3, 'Гудвин', NULL),
(5, 3, 'Куба', NULL),
(6, 3, 'Дофамин', NULL),
(7, 2, 'Tiki-Bar', NULL),
(8, 2, 'Liberty Bar', NULL),
(9, 2, 'Хастл ОпенЭир на Набережной', 'Пушкинская набережная')

SET IDENTITY_INSERT [dbo].[Locations] OFF

GO