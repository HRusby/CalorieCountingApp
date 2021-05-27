CREATE PROCEDURE CheckLogin (
	IN $UserName VARCHAR(255),
    IN $EncodedPassword VARCHAR(1000),
    OUT $ValidLogin INTEGER
)
BEGIN
    DECLARE userCount INTEGER;

	SELECT COUNT(*) INTO userCount
    FROM USER
    WHERE Name = $UserName
    AND EncodedPassword = $EncodedPassword;

    IF userCount = 1 THEN
        SET $ValidLogin := TRUE;
    ELSE
        SET $ValidLogin := FALSE;
    END IF;
END;