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

IF NOT EXISTS(Select * from Merchants where MerchantName = 'AT&T')
BEGIN
   INSERT INTO Merchants(MerchantName) VALUES('AT&T');
END
GO

IF NOT EXISTS(Select * from Merchants where MerchantName = 'TELEPAY')
BEGIN
   INSERT INTO Merchants(MerchantName) VALUES('TELEPAY');
END
GO

IF NOT EXISTS(Select * from Merchants where MerchantName = 'Netflix')
BEGIN
   INSERT INTO Merchants(MerchantName) VALUES('Netflix');
END
GO
