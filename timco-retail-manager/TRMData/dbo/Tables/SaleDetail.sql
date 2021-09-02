CREATE TABLE [dbo].[SaleDetail]
(
	[Id] INT NOT NULL IDENTITY , 
    [SaleId] INT NOT NULL, 
    [ProductId] INT NOT NULL,
    [Quantity] INT NOT NULL DEFAULT 1,
    [PurchasePrice] MONEY NOT NULL, 
    [Tax] MONEY NOT NULL DEFAULT 0, 
    CONSTRAINT [PK_SaleDetail] PRIMARY KEY ([Id]) 
)
