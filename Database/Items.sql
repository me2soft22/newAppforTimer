CREATE TABLE [dbo].[Items] (
    [Id]          INT        NOT NULL,
    [ItemName] NCHAR (20) NOT NULL,
    [Quantity]        INT NOT NULL,
    [PurchasePrice]   SMALLMONEY        NOT NULL,
    [Discount]   NCHAR(10)   NOT NULL,
    [SellPrice] SMALLMONEY NOT NULL, 
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

