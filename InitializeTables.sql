----Cats category----
--Structure
CREATE TABLE [dbo].[Cats] (
    [Id]    INT            IDENTITY (1, 1) NOT NULL,
    [Word]  NVARCHAR (50)  NULL,
    [Hints] NVARCHAR (MAX) NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

--Data
SET IDENTITY_INSERT [dbo].[Cats] ON
INSERT INTO [dbo].[Cats] ([Id], [Word], [Hints]) VALUES (1, N'אוריינטל', N'מתחיל באות א')
INSERT INTO [dbo].[Cats] ([Id], [Word], [Hints]) VALUES (2, N'אביסיני', N'מתחיל ב"אבי"')
INSERT INTO [dbo].[Cats] ([Id], [Word], [Hints]) VALUES (3, N'הימלאיה
', N'יש את המילה "מלא"')
INSERT INTO [dbo].[Cats] ([Id], [Word], [Hints]) VALUES (4, N'טונקינזי', N'מתחיל ב"טונ"')
INSERT INTO [dbo].[Cats] ([Id], [Word], [Hints]) VALUES (5, N'מאו מצרי
', N'יש חלק מהמילה מצרים')
INSERT INTO [dbo].[Cats] ([Id], [Word], [Hints]) VALUES (6, N'סינגפורה', N'נשמע דומה לעיר סינגפור')
INSERT INTO [dbo].[Cats] ([Id], [Word], [Hints]) VALUES (7, N'דבון רקס', N'מתחיל ב"בד"')
SET IDENTITY_INSERT [dbo].[Cats] OFF


----Dogs category----
--Structure
CREATE TABLE [dbo].[Dogs] (
    [Id]    INT            IDENTITY (1, 1) NOT NULL,
    [Word]  NVARCHAR (50)  NULL,
    [Hints] NVARCHAR (MAX) NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

--Data
SET IDENTITY_INSERT [dbo].[Dogs] ON
INSERT INTO [dbo].[Dogs] ([Id], [Word], [Hints]) VALUES (1, N'דוברמן', N'נגמר ב"מן". מתחיל ב"דובר". יש "בר')
SET IDENTITY_INSERT [dbo].[Dogs] OFF
