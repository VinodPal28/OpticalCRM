CREATE TABLE [dbo].[userAuthentication] (
    [Id]          INT          IDENTITY (1, 1) NOT NULL,
    [customerId]  VARCHAR (50) NULL,
    [username]    VARCHAR (50) NOT NULL,
    [password]    VARCHAR (50) NULL,
    [status]      INT          NULL,
    [createdBy]   INT          NULL,
    [createdDate] DATETIME     NULL,
    [updatedBy]   INT          NULL,
    [updatedDate] DATETIME     NULL,
    PRIMARY KEY CLUSTERED ([username] ASC)
);

