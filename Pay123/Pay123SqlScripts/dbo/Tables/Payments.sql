CREATE TABLE [dbo].[Payments] (
    [Date]            DATETIME2 (7)   NOT NULL,
    [ReferenceNumber] NVARCHAR (8)    NOT NULL,
    [AccountNumber]   NVARCHAR (MAX)  NOT NULL,
    [AccountName]     NVARCHAR (20)   NOT NULL,
    [OtherDetails]    NVARCHAR (MAX)  NULL,
    [Amount]          DECIMAL (18, 2) NOT NULL,
    [ServiceFee]      DECIMAL (18, 2) NULL,
    [PPRemarks]       NVARCHAR (MAX)  NULL,
    [MerchantId]      INT             NOT NULL,
    [StatusId]        INT             NOT NULL,
    [UserId]          NVARCHAR (450)  NULL,
    [Client]          NVARCHAR (50)   NULL,
    [Customer]        NVARCHAR (50)   NULL,
    [Attachment] NVARCHAR(MAX) NULL, 
    [ProcessedBy] NVARCHAR(MAX) NULL, 
    CONSTRAINT [PK_Payments] PRIMARY KEY CLUSTERED ([ReferenceNumber] ASC),
    CONSTRAINT [FK_Payments_Merchants_MerchantId] FOREIGN KEY ([MerchantId]) REFERENCES [dbo].[Merchants] ([MerchantId]) ON DELETE CASCADE,
    CONSTRAINT [FK_Payments_Statuses_StatusId] FOREIGN KEY ([StatusId]) REFERENCES [dbo].[Statuses] ([StatusId]) ON DELETE CASCADE
);

