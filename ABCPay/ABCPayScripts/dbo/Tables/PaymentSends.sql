CREATE TABLE [dbo].[PaymentSends] (
    [ReferenceNumber] NVARCHAR (8)    NOT NULL,
    [Date]            DATETIME2 (7)   NOT NULL,
    [AccountNumber]   NVARCHAR (MAX)  NOT NULL,
    [AccountName]     NVARCHAR (50)   NOT NULL,
    [OtherDetails]    NVARCHAR (MAX)  NULL,
    [Amount]          DECIMAL (18, 2) NOT NULL,
    [ServiceFee]      DECIMAL (18, 2) NULL,
    [PPRemarks]       NVARCHAR (MAX)  NULL,
    [Client]          NVARCHAR (50)   NULL,
    [Customer]        NVARCHAR (50)   NULL,
    [MerchantId]      INT             NOT NULL,
    [StatusId]        INT             NOT NULL,
    CONSTRAINT [PK_PaymentSends] PRIMARY KEY CLUSTERED ([ReferenceNumber] ASC),
    CONSTRAINT [FK_PaymentSends_Merchants_MerchantId] FOREIGN KEY ([MerchantId]) REFERENCES [dbo].[Merchants] ([MerchantId]) ON DELETE CASCADE,
    CONSTRAINT [FK_PaymentSends_Statuses_StatusId] FOREIGN KEY ([StatusId]) REFERENCES [dbo].[Statuses] ([StatusId]) ON DELETE CASCADE
);




GO
CREATE NONCLUSTERED INDEX [IX_PaymentSends_MerchantId]
    ON [dbo].[PaymentSends]([MerchantId] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_PaymentSends_StatusId]
    ON [dbo].[PaymentSends]([StatusId] ASC);


GO


