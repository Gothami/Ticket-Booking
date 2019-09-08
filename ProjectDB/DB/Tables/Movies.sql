CREATE TABLE [dbo].[Employee]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [MovieID] INT NOT NULL, 
    [MovieName] NCHAR(100) NOT NULL, 
    [MovieDescription] NCHAR(10) NULL, 
    CONSTRAINT [MovieID] FOREIGN KEY ([MovieID]) REFERENCES [Shows]([MovieID]) 
)
