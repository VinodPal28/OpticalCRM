CREATE TABLE [dbo].[userMaster] (
    [Id]          INT           IDENTITY (1, 1) NOT NULL,
    [CustomerId]  VARCHAR (50)  NOT NULL,
    [password]    VARCHAR (50)  NULL,
    [GSTNumber]   VARCHAR (50)  NULL,
    [ShopName]    VARCHAR (50)  NULL,
    [UserName]    VARCHAR (50)  NULL,
    [UserEmail]   VARCHAR (50)  NULL,
    [MobNumber]   VARCHAR (50)  NULL,
    [State]       INT           NULL,
    [City]        INT           NULL,
    [Pincode]     VARCHAR (10)  NULL,
    [Address]     VARCHAR (255) NULL,
    [LogoName]    VARCHAR (50)  NULL,
    [status]      INT           NULL,
    [roleType]    INT           NULL,
    [createdBy]   INT           NULL,
    [createdDate] DATETIME      NULL,
    [UpdatedBy]   INT           NULL,
    [updatedDate] DATETIME      NULL,
    PRIMARY KEY CLUSTERED ([CustomerId] ASC)
);

