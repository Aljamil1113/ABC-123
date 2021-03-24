CREATE PROCEDURE [dbo].[DeletePaymentSend]
	@referenceNumber nvarchar(8)
AS
BEGIN
	SET NOCOUNT ON;

	DELETE from PaymentSends WHERE ReferenceNumber = @referenceNumber;
END