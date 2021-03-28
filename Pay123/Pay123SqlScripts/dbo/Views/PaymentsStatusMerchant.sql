CREATE VIEW [dbo].[PaymentsStatusMerchant]
	AS SELECT [dbo].[Payments].[Date], [dbo].[Payments].[ReferenceNumber], [dbo].[Merchants].[MerchantName], 
	[dbo].[Payments].[Client], [dbo].[Payments].[Customer],[dbo].[Payments].[AccountNumber], [dbo].[Payments].[AccountName], 
	[dbo].[Payments].[OtherDetails], [dbo].[Payments].[Amount], [dbo].[Payments].[ServiceFee], [dbo].[Payments].[PPRemarks], 
	[dbo].[Statuses].[StatusName] FROM Payments inner join Merchants
	on Payments.MerchantId = Merchants.MerchantId
	inner join Statuses on Payments.StatusId = Statuses.StatusId;
