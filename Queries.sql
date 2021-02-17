SELECT * FROM Products P 
LEFT JOIN Categories C ON P.CategoryID = C.CategoryID
WHERE C.CategoryID = 1

SELECT COUNT(*) FROM Categories
SELECT COUNT(*) FROM Products

CREATE TABLE [dbo].[Logs]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Detail] NVARCHAR(MAX) NOT NULL, 
    [Date] DATETIME NOT NULL, 
    [Audit] NVARCHAR(50) NOT NULL
)
