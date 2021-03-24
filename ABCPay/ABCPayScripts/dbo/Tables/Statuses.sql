CREATE TABLE [dbo].[Statuses] (
    [StatusId]   INT            IDENTITY (1, 1) NOT NULL,
    [StatusName] NVARCHAR (MAX) NULL,
    CONSTRAINT [PK_Statuses] PRIMARY KEY CLUSTERED ([StatusId] ASC)
);

