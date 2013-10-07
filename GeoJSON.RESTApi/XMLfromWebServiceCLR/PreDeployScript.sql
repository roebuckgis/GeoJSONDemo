--database work before deploy
--enable clr
sp_configure 'show advanced options', 1;
GO
RECONFIGURE;
GO
sp_configure 'clr enabled', 1;
GO
RECONFIGURE;
GO

--set trustworty on 
ALTER DATABASE bcc3 SET TRUSTWORTHY ON