CREATE TABLE [dbo].[Brands] (
    [BrandId]   INT           IDENTITY (100, 1) NOT NULL,
    [BrandName] NVARCHAR (50) NULL,
    PRIMARY KEY CLUSTERED ([BrandId] ASC)
);

