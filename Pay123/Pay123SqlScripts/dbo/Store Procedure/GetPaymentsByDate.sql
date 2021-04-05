CREATE PROCEDURE [dbo].[GetPaymentsByDate]
	@DateFrom datetime,
	@DateTo datetime
AS
	SELECT * FROM PaymentsStatusMerchant
	WHERE Date BETWEEN @DateFrom AND @DateTo
	ORDER BY Date ASC
