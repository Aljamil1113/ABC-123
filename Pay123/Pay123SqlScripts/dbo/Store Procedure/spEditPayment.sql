CREATE PROCEDURE [dbo].[spEditPayment]
	@referenceNumber nvarchar(8),
	@date datetime,
	@accountNumber nvarchar(MAX),
	@accountName nvarchar(50),
	@otherDetails nvarchar(MAX),
	@amount decimal(18,2),
	@serviceFee decimal(18,2),
	@ppRemarkcs nvarchar(MAX),
	@client nvarchar(50),
	@customer nvarchar(50),
	@merchantId int,
	@statusId int,
	@attachment nvarchar(MAX),
	@processedBy nvarchar(MAX)
AS
    BEGIN
	  UPDATE Payments
	  set ReferenceNumber = @referenceNumber,
	  [Date] = @date,
	  AccountNumber = @accountNumber,
	  AccountName = @accountName,
	  OtherDetails = @otherDetails,
	  Amount = @amount,
	  ServiceFee = @serviceFee,
	  PPRemarks = @ppRemarkcs,
	  Client = @client,
	  Customer = @customer,
	  MerchantId = @merchantId,
	  StatusId = @statusId,
	  Attachment = @attachment,
	  ProcessedBy = @processedBy
	  WHERE ReferenceNumber = @referenceNumber
	END