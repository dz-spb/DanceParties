CREATE DATABASE [DanceParties2];
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
    [DateTime]	DATETIMEOFFSET (7) NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Party_Location] FOREIGN KEY ([LocationId]) REFERENCES [dbo].[Location] ([Id]),
    CONSTRAINT [FK_Party_Dance] FOREIGN KEY ([DanceId]) REFERENCES [dbo].[Dance] ([Id])
);
GO

SET IDENTITY_INSERT [dbo].[City] ON

INSERT INTO [dbo].[City] ([Id], [Name]) VALUES
(1, 'Санкт-Петебург'),
(2, 'Москва'),
(3, 'Минск')

SET IDENTITY_INSERT [dbo].[City] OFF

GO

SET IDENTITY_INSERT [dbo].[Dance] ON

INSERT INTO [dbo].[Dance] ([Id], [Name]) VALUES
(1, 'Сальса'),
(2, 'Бачата'),
(3, 'Хастл')

SET IDENTITY_INSERT [dbo].[Dance] OFF

GO

SET IDENTITY_INSERT [dbo].[Location] ON

INSERT INTO [dbo].[Location] ([Id], [CityId], [Name], [Address]) VALUES
(1, 1, 'Tropikana-Atrium', 'Невский 71'),
(2, 1, 'AnyDay', 'Херсонская 12-14'),
(3, 1, 'Ростральные колонны, зимняя площадка', 'Стрелка В.О.'),
(4, 3, 'Гудвин', NULL),
(5, 3, 'Куба', NULL),
(6, 3, 'Дофамин', NULL),
(7, 2, 'Tiki-Bar', NULL),
(8, 2, 'Liberty Bar', NULL),
(9, 2, 'Хастл ОпенЭир на Набережной', 'Пушкинская набережная')

SET IDENTITY_INSERT [dbo].[Location] OFF

GO