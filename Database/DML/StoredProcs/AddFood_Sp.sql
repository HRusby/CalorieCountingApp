CREATE PROCEDURE `AddFood` (
    IN $Name VARCHAR(255),
    IN $CaloriesPerMetric DECIMAL(10,5),
    IN $MetricId INTEGER,
    OUT GeneratedId INTEGER
)
BEGIN
	INSERT INTO FOOD (
        Name, 
        $CaloriesPerMetric, 
        $MetricId
    )
    VALUES 
    (
        $Name,
        $CaloriesPerMetric,
        $MetricId
    );

    SELECT LAST_INSERT_ID() INTO GeneratedId; 
END;