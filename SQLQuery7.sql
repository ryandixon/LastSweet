CREATE TABLE [dbo].[Meetings] (
    [MeetingId] INT           NOT NULL,
    [UserName]  VARCHAR (MAX) NULL,
    [Schedule]  DATETIME      NULL,
    [Time]      VARCHAR (MAX) NULL,
    PRIMARY KEY CLUSTERED ([MeetingId] ASC)
);