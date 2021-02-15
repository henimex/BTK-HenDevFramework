SELECT * FROM Products P 
LEFT JOIN Categories C ON P.CategoryID = C.CategoryID
WHERE C.CategoryID = 1

SELECT COUNT(*) FROM Categories
SELECT COUNT(*) FROM Products