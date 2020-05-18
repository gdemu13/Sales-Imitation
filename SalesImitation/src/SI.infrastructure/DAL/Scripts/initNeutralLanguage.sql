-- USE [SalesImitation]
GO

IF NOT EXISTS (SELECT * FROM [dbo].[Languages]
                   WHERE Code = 'neutral')
BEGIN
	INSERT INTO [dbo].[Languages]
           ([ID] ,[Name] ,[Code] ,[LastUpdateDate])
     VALUES
           (NEWID(),'neutral', 'neutral', GETDATE())
END

GO

DECLARE @LANGUAGE_ID uniqueidentifier;
SET @LANGUAGE_ID = (SELECT ID FROM Languages where Code = 'neutral')
DECLARE @KEY varchar(250);
DECLARE @VALUE varchar(250);


SET @KEY = 'menu_main'
SET @VALUE = N'მთავარი'
IF NOT EXISTS (SELECT * FROM [dbo].[Translations]
                   WHERE [Key] = @KEY)
BEGIN
INSERT INTO [dbo].[Translations]
           ([ID],[Key] ,[Value],[LanguageID],[LastUpdateDate])
     VALUES
           (NEWID(), @KEY, @VALUE, @LANGUAGE_ID, GETDATE())
END

SET @KEY = 'menu_about_us'
SET @VALUE = N'ჩვენს შესახებ'
IF NOT EXISTS (SELECT * FROM [dbo].[Translations]
                   WHERE [Key] = @KEY)
BEGIN
INSERT INTO [dbo].[Translations]
           ([ID],[Key] ,[Value],[LanguageID],[LastUpdateDate])
     VALUES
           (NEWID(), @KEY, @VALUE, @LANGUAGE_ID, GETDATE())
END

SET @KEY = 'menu_game_rules'
SET @VALUE = N'თამაშის წესები'
IF NOT EXISTS (SELECT * FROM [dbo].[Translations]
                   WHERE [Key] = @KEY)
BEGIN
INSERT INTO [dbo].[Translations]
           ([ID],[Key] ,[Value],[LanguageID],[LastUpdateDate])
     VALUES
           (NEWID(), @KEY, @VALUE, @LANGUAGE_ID, GETDATE())
END

SET @KEY = 'menu_faq'
SET @VALUE = 'FAQ'
IF NOT EXISTS (SELECT * FROM [dbo].[Translations]
                   WHERE [Key] = @KEY)
BEGIN
INSERT INTO [dbo].[Translations]
           ([ID],[Key] ,[Value],[LanguageID],[LastUpdateDate])
     VALUES
           (NEWID(), @KEY, @VALUE, @LANGUAGE_ID, GETDATE())
END

SET @KEY = 'menu_contact'
SET @VALUE = N'კონტაქტი'
IF NOT EXISTS (SELECT * FROM [dbo].[Translations]
                   WHERE [Key] = @KEY)
BEGIN
INSERT INTO [dbo].[Translations]
           ([ID],[Key] ,[Value],[LanguageID],[LastUpdateDate])
     VALUES
           (NEWID(), @KEY, @VALUE, @LANGUAGE_ID, GETDATE())
END

SET @KEY = 'dashboard_mission'
SET @VALUE = N'მისია'
IF NOT EXISTS (SELECT * FROM [dbo].[Translations]
                   WHERE [Key] = @KEY)
BEGIN
INSERT INTO [dbo].[Translations]
           ([ID],[Key] ,[Value],[LanguageID],[LastUpdateDate])
     VALUES
           (NEWID(), @KEY, @VALUE, @LANGUAGE_ID, GETDATE())
END

GO


