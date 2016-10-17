CREATE TABLE [dbo].[Tickets] (
    [TicketId]    INT            IDENTITY (1, 1) NOT NULL,
    [Title]       NVARCHAR (MAX) NULL,
    [Description] NVARCHAR (MAX) NULL,
    [Resolve]     INT            NULL,
    [Meeting]     DATETIME       NULL,
    CONSTRAINT [PK_dbo.Tickets] PRIMARY KEY CLUSTERED ([TicketId] ASC)
);
