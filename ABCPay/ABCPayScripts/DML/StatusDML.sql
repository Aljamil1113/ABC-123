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

IF NOT EXISTS(Select * from Statuses where StatusName = 'Pending')
BEGIN
   INSERT INTO Statuses(StatusName) VALUES('Pending');
END
GO

IF NOT EXISTS(Select * from Statuses where StatusName = 'Processing')
BEGIN
   INSERT INTO Statuses(StatusName) VALUES('Processing');
END
GO

IF NOT EXISTS(Select * from Statuses where StatusName = 'Done')
BEGIN
   INSERT INTO Statuses(StatusName) VALUES('Done');
END
GO

IF NOT EXISTS(Select * from Statuses where StatusName = 'Failed')
BEGIN
   INSERT INTO Statuses(StatusName) VALUES('Failed');
END
GO
