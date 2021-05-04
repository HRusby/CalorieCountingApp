CREATE PROCEDURE UpdateFood (
    IN $FoodId INTEGER,
	IN $Name VARCHAR(255),
    IN $CaloriesPerMetric DECIMAL(10,5),
    IN $MetricId INTEGER
)
BEGIN
	UPDATE FOOD SET
    Name = IFNULL($Name, Name),
    CaloriesPerMetric = IFNULL($CaloriesPerMetric, CaloriesPerMetric),
    MetricId = IFNULL($MetricId, MetricId)
    WHERE Id = $FoodId;
END;