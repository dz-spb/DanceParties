USE [DanceParties];
GO

SET IDENTITY_INSERT [dbo].[City] ON

INSERT INTO [dbo].[City] ([Id], [Name]) VALUES
(1, N'Saint Petersburg'),
(2, N'Moscow'),
(3, N'Minsk')

SET IDENTITY_INSERT [dbo].[City] OFF

GO

SET IDENTITY_INSERT [dbo].[Dance] ON

INSERT INTO [dbo].[Dance] ([Id], [Name]) VALUES
(1, N'Salsa'),
(2, N'Bachata'),
(3, N'Hustle')

SET IDENTITY_INSERT [dbo].[Dance] OFF

GO

SET IDENTITY_INSERT [dbo].[Location] ON

INSERT INTO [dbo].[Location] ([Id], [CityId], [Name], [Address]) VALUES
(1, 1, N'Tropikana-Atrium', N'71 Nevsky ave'),
(2, 1, N'AnyDay', N'12-14 Khersonskaya str'),
(3, 1, N'Rostral columns, winter site', N'Strelka V.O.'),
(4, 3, N'Goodwin', NULL),
(5, 3, N'Cuba', NULL),
(6, 3, N'Dopamine', NULL),
(7, 2, N'Tiki-Bar', NULL),
(8, 2, N'Liberty Bar', NULL),
(9, 2, N'Hustle open air on quay', N'Pushkinskaya quay'),
(10, 1, N'Rostral columns, biker site', N'Strelka V.O.')

SET IDENTITY_INSERT [dbo].[Location] OFF

GO

SET IDENTITY_INSERT [dbo].[Party] ON

INSERT INTO [dbo].[Party] ([Id], [LocationId], [DanceId], [Name], [Start]) VALUES
(1, 1, 1, N'Salsa & Bachata - Rueda Party', '2019-07-03T20:30:00+03:00'),
(2, 1, 2, N'The Best of Bachata', '2019-07-04T20:30:00+03:00'),
(3, 3, 3, N'Hustle Open Air', '2019-07-06T20:00:00+03:00'),
(4, 10, 1, N'Salsa Plus open air', '2019-07-05T20:00:00+03:00'),
(5, 9, 1, NULL, N'2019-07-02T20:00:00+03:00')

SET IDENTITY_INSERT [dbo].[Party] OFF
