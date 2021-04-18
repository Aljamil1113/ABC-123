CREATE PROCEDURE [dbo].[spAddPayment]
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
    INSERT Payments(ReferenceNumber,[Date],AccountNumber,AccountName,OtherDetails,Amount,ServiceFee,PPRemarks,Client,Customer,MerchantId,StatusId,Attachment,ProcessedBy)
	VALUES (@referenceNumber,@date,@accountNumber,@accountName,@otherDetails,@amount,@serviceFee,@ppRemarkcs,@client,@customer,@merchantId,@statusId,@attachment,@processedBy)
  END
