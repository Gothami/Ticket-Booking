CREATE TABLE [dbo].[Theatres]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [TheatreID] INT NOT NULL, 
    [TheatreName] NCHAR(50) NOT NULL, 
    CONSTRAINT [TheatreID] FOREIGN KEY ([TheatreID]) REFERENCES [Shows]([TheatreID])
)
