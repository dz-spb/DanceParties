USE [DanceParties];
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
(9, 2, 'Хастл ОпенЭир на Набережной', 'Пушкинская набережная'),
(10, 1, 'Ростральные колонны, байкерская площадка', 'Стрелка В.О.')

SET IDENTITY_INSERT [dbo].[Location] OFF

GO

SET IDENTITY_INSERT [dbo].[Party] ON

INSERT INTO [dbo].[Party] ([Id], [LocationId], [DanceId], [Name], [Start]) VALUES
(1, 1, 1, 'Salsa & Bachata - Rueda Party', '2019-07-03T17:30:00+03:00'),
(2, 1, 2, 'The Best of Bachata', '2019-07-04T17:30:00+03:00'),
(3, 3, 3, 'Hustle Open Air', '2019-07-06T17:00:00+03:00'),
(4, 10, 1, 'Salsa Plus open air', '2019-07-05T17:00:00+03:00'),
(5, 9, 1, NULL, '2019-07-02T17:00:00+03:00')

SET IDENTITY_INSERT [dbo].[Party] OFF
