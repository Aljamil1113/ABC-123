CREATE VIEW [dbo].[PaymentMS]
	AS SELECT  [dbo].[Payments].[ReferenceNumber], [dbo].[Payments].[Date], [dbo].[Payments].[AccountNumber], [dbo].[Payments].[AccountName], 
	[dbo].[Payments].[OtherDetails], [dbo].[Payments].[Amount], [dbo].[Payments].[ServiceFee], 
	[dbo].[Payments].[PPRemarks], [dbo].[Payments].[Client], [dbo].[Payments].[Customer], 
	[dbo].[Merchants].[MerchantName], [dbo].[Statuses].[StatusName], [dbo].[Payments].[UserId], [dbo].[Payments].[Attachment] FROM Payments inner join Merchants 
	on Payments.MerchantId = Merchants.MerchantId inner join Statuses
	on Payments.StatusId = Statuses.StatusId;
