CREATE TABLE [dbo].[Movies]
(
    [MovieID] INT NOT NULL, 
    [MovieName] NCHAR(100) NOT NULL, 
    [MovieDescription] NCHAR(10) NULL, 
    CONSTRAINT [PK_Movies] PRIMARY KEY ([MovieID]) 
)
