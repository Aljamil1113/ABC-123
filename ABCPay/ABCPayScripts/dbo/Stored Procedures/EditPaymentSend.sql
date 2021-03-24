CREATE PROCEDURE [dbo].[EditPaymentSend]
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
	UPDATE PaymentSends
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
	StatusId = @statusId
	WHERE ReferenceNumber = @referenceNumber
END