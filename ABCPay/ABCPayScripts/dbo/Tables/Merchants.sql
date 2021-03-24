CREATE TABLE [dbo].[Merchants] (
    [MerchantId]   INT            IDENTITY (1, 1) NOT NULL,
    [MerchantName] NVARCHAR (100) NULL,
    CONSTRAINT [PK_Merchants] PRIMARY KEY CLUSTERED ([MerchantId] ASC)
);

