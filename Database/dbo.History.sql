CREATE TABLE [dbo].[History] (
    [Id]           INT           IDENTITY (1, 1) NOT NULL,
    [PhoneNumber]  NCHAR (10)    NOT NULL,
    [NumberOfKids] INT           NOT NULL,
    [InDate] NVARCHAR(30) NOT NULL, 
    [StartTime]    NVARCHAR (50) NULL,
    [EndTime]      NVARCHAR (50) NULL,
    [HoursPlayed]  NVARCHAR (20) NULL,
    [TotalAmount] NUMERIC NOT NULL, 
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

