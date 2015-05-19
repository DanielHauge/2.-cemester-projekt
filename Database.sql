CREATE TABLE [dbo].[Booking] (
    
    [Bord]    INT           NOT NULL DEFAULT 1,
    [KundeID] NVARCHAR (50) NOT NULL DEFAULT 123,
    [Dato]    VARCHAR(50)      NOT NULL,
	[Id]      INT           IDENTITY (1, 1) NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

