CREATE OR REPLACE PROCEDURE GetTrackingDataForDateAndUser(
	IN $UserId INTEGER, 
	IN $Date DATE) 
BEGIN
	SELECT mt.Id TrackingId,
		mt.MealId MealOrIngredientId,
		t.UserId,
		tt.Id TypeId,
		tt.`Type` Type,
		m.Name MealOrIngredientName,
		t.Quantity,
		t.Calories,
		m2.ShortName MetricShortName,
		t.DateTime
	FROM TRACKING t
		INNER JOIN MEAL_TRACKING mt ON t.Id = mt.TrackingId
		INNER JOIN MEAL m ON mt.MealId = m.Id
		INNER JOIN TRACKING_TYPE tt ON t.TrackingTypeId = tt.Id
		INNER JOIN METRIC m2 ON m.CookedWeightMetricId = m2.Id
	WHERE t.UserId = 1
		AND t.TrackingTypeId = 1
		AND DATE(t.`DateTime`) = $Date
	UNION ALL
	SELECT it.Id TrackingId,
		it.IngredientId MealOrIngredientId,
		t.UserId,
		tt.Id TypeId,
		tt.`Type` Type,
		i.Name MealOrIngredientName,
		t.Quantity,
		t.Calories,
		m.ShortName MetricShortName,
		t.DateTime
	FROM TRACKING t
		INNER JOIN INDIVIDUAL_TRACKING it ON t.Id = it.TrackingId
		INNER JOIN INGREDIENT i ON it.IngredientId = i.Id
		INNER JOIN TRACKING_TYPE tt ON t.TrackingTypeId = tt.Id
		INNER JOIN METRIC m ON i.MetricId = m.Id
	WHERE t.UserId = 1
		AND t.TrackingTypeId = 2
		AND DATE(t.`DateTime`) = $Date;
END;