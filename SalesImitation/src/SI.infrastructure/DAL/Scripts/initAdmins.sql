GO

INSERT INTO [dbo].[Users]
           ([ID]
           ,[UserName]
           ,[PasswordHash]
           ,[LastUpdateDate])
     VALUES
           (NEWID()
           ,'admin'
           ,'1000:icj07LSJxsEExtUkaO6Fgw1Koov8Iaz+:PpX8KLxVm7dbB2/TqEEa0JHeySw='
           ,GETDATE())
GO


