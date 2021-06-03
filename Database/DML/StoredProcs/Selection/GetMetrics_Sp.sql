CREATE PROCEDURE GetMetrics()
BEGIN
    SELECT 
        Id,
        Name,
        ShortName
    FROM METRIC;
END;