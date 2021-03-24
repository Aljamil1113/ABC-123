CREATE PROCEDURE [dbo].[AddPaymentSend]
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
	@statusId int
AS
BEGIN
	INSERT PaymentSends(ReferenceNumber,[Date],AccountNumber,AccountName,OtherDetails,Amount,ServiceFee,PPRemarks,Client,Customer,MerchantId,StatusId)
	VALUES (@referenceNumber,@date,@accountNumber,@accountName,@otherDetails,@amount,@serviceFee,@ppRemarkcs,@client,@customer,@merchantId,@statusId)
END