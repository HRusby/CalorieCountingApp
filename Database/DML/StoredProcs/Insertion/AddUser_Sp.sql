DELIMITER ,,

CREATE PROCEDURE AddUser (
	IN $UserName VARCHAR(255),
    IN $EncodedPassword VARCHAR(1000),
    OUT $GeneratedId INTEGER
)
BEGIN
	INSERT INTO USER (Name, EncodedPassword)
    VALUES ($UserName, $EncodedPassword);

    SELECT LAST_INSERT_ID() INTO $GeneratedId; 
END;

,,