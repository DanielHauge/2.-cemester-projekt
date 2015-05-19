CREATE TABLE [dbo].[Kunde] (
    [KundeID] INT        IDENTITY (1, 1) NOT NULL,
    [Navn]    NCHAR (10) NOT NULL,
    [Email]   NCHAR (10) NOT NULL,
    [Saldo]   NCHAR (10) NOT NULL,
    PRIMARY KEY CLUSTERED ([KundeID] ASC)
);

