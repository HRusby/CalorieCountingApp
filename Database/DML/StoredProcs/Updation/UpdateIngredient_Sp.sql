DELIMITER ,,

CREATE PROCEDURE UpdateIngredient (
    IN $IngredientId INTEGER,
	IN $Name VARCHAR(255),
    IN $CaloriesPerMetric DECIMAL(10,5),
    IN $MetricId INTEGER
)
BEGIN
	UPDATE INGREDIENT SET
    Name = IFNULL($Name, Name),
    CaloriesPerMetric = IFNULL($CaloriesPerMetric, CaloriesPerMetric),
    MetricId = IFNULL($MetricId, MetricId)
    WHERE Id = $IngredientId;
END;

,,