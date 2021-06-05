CREATE PROCEDURE GetTrackingDataForDateAndUser(
    IN $UserId INTEGER,
    IN $Date DATE
)
BEGIN
    SELECT 
	    t.Id,
	    t.UserId,
		t.IngredientId,
	    t.MetricId,
	    t.Quantity,
        t.`DateTime`,
		i.Name IngredientName,
	    m.ShortName MetricShortName
	FROM TRACKING t
	INNER JOIN METRIC m ON t.MetricId = m.Id
	INNER JOIN INGREDIENT i ON t.IngredientId = i.Id 
	WHERE UserId = $UserId
    AND DATE(`DateTime`) = $Date ;
END;