DELIMITER ,,

CREATE PROCEDURE DeleteIngredient (
	IN $IngredientId INTEGER
)
BEGIN
	DELETE FROM INGREDIENT 
    WHERE Id = $IngredientId;
END;

,,