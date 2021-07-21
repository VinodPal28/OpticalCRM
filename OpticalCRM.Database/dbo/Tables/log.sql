CREATE TABLE [dbo].[log] (
    [Id]            INT           IDENTITY (1, 1) NOT NULL,
    [RequestMethod] VARCHAR (255) NULL,
    [RequestUri]    VARCHAR (255) NULL,
    [Message]       VARCHAR (MAX) NULL,
    [CreatedDate]   DATETIME      NULL
);

