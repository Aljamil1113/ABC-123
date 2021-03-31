/*
 Pre-Deployment Script Template							
--------------------------------------------------------------------------------------
 This file contains SQL statements that will be executed before the build script.	
 Use SQLCMD syntax to include a file in the pre-deployment script.			
 Example:      :r .\myfile.sql								
 Use SQLCMD syntax to reference a variable in the pre-deployment script.		
 Example:      :setvar TableName MyTable							
               SELECT * FROM [$(TableName)]					
--------------------------------------------------------------------------------------
*/


IF NOT EXISTS(Select * from Users where UserName = 'root' AND Password = 'root123*')
BEGIN
   INSERT INTO Users(UserName, Password) VALUES('root', 'root123*');
END
GO

IF NOT EXISTS(Select * from Users where UserName = 'admin' AND Password = 'Admin123*')
BEGIN
   INSERT INTO Users(UserName, Password) VALUES('admin', 'Admin123*');
END
GO

