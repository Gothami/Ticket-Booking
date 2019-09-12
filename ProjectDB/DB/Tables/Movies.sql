CREATE TABLE [dbo].[Movies]
(
	[MovieID] INT NOT NULL PRIMARY KEY identity(1,1), 
    [MovieName] NCHAR(100) NOT NULL, 
    [MovieDescription] NCHAR(2000) NULL
)
