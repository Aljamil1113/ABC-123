CREATE PROCEDURE [dbo].[spDeletePayment]
	@referenceNumber nvarchar(8)
AS
BEGIN
	SET NOCOUNT ON;

	DELETE from Payments WHERE ReferenceNumber = @referenceNumber;
END 