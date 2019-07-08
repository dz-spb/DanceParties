USE [DanceParties];
GO

SET IDENTITY_INSERT [dbo].[City] ON

INSERT INTO [dbo].[City] ([Id], [Name]) VALUES
(1, 'Saint Petersburg'),
(2, 'Moscow'),
(3, 'Minsk')

SET IDENTITY_INSERT [dbo].[City] OFF

GO

SET IDENTITY_INSERT [dbo].[Dance] ON

INSERT INTO [dbo].[Dance] ([Id], [Name]) VALUES
(1, 'Salsa'),
(2, 'Bachata'),
(3, 'Hustle')

SET IDENTITY_INSERT [dbo].[Dance] OFF

GO

SET IDENTITY_INSERT [dbo].[Location] ON

INSERT INTO [dbo].[Location] ([Id], [CityId], [Name], [Address]) VALUES
(1, 1, 'Tropikana-Atrium', '71 Nevsky ave'),
(2, 1, 'AnyDay', '12-14 Khersonskaya str'),
(3, 1, 'Rostral columns, winter site', 'Strelka V.O.'),
(4, 3, 'Goodwin', NULL),
(5, 3, 'Cuba', NULL),
(6, 3, 'Dopamine', NULL),
(7, 2, 'Tiki-Bar', NULL),
(8, 2, 'Liberty Bar', NULL),
(9, 2, 'Hustle open air on quay', 'Pushkinskaya quay'),
(10, 1, 'Rostral columns, biker site', 'Strelka V.O.')

SET IDENTITY_INSERT [dbo].[Location] OFF

GO

SET IDENTITY_INSERT [dbo].[Party] ON

INSERT INTO [dbo].[Party] ([Id], [LocationId], [DanceId], [Name], [Start]) VALUES
(1, 1, 1, 'Salsa & Bachata - Rueda Party', '2019-07-03T20:30:00+03:00'),
(2, 1, 2, 'The Best of Bachata', '2019-07-04T20:30:00+03:00'),
(3, 3, 3, 'Hustle Open Air', '2019-07-06T20:00:00+03:00'),
(4, 10, 1, 'Salsa Plus open air', '2019-07-05T20:00:00+03:00'),
(5, 9, 1, NULL, '2019-07-02T20:00:00+03:00')

SET IDENTITY_INSERT [dbo].[Party] OFF
