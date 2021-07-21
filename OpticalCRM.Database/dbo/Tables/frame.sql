CREATE TABLE [dbo].[frame] (
    [Id]                     INT             IDENTITY (1, 1) NOT NULL,
    [productCode]            VARCHAR (50)    NOT NULL,
    [name]                   VARCHAR (50)    NULL,
    [color]                  VARCHAR (50)    NULL,
    [size]                   VARCHAR (50)    NULL,
    [type]                   VARCHAR (50)    NULL,
    [shape]                  VARCHAR (50)    NULL,
    [material]               VARCHAR (50)    NULL,
    [company]                VARCHAR (50)    NULL,
    [gender]                 VARCHAR (50)    NULL,
    [trackInventory]         VARCHAR (50)    NULL,
    [allowNegativeInventory] VARCHAR (50)    NULL,
    [purchaseBasePrice]      DECIMAL (18, 2) NULL,
    [purchasePrice]          DECIMAL (18, 2) NULL,
    [retailPrice]            DECIMAL (18, 2) NULL,
    [flag]                   INT             NULL,
    [createdby]              INT             NULL,
    [createdDate]            DATETIME        NULL,
    [updatedby]              INT             NULL,
    [updatedDate]            DATETIME        CONSTRAINT [DF_frame] DEFAULT ('0001-01-01 00:00:00') NULL,
    PRIMARY KEY CLUSTERED ([productCode] ASC)
);

