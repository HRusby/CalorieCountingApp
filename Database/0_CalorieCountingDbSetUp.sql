CREATE DATABASE CalorieCounting;

USE CalorieCounting;

CREATE USER 'DataAccess'@'%' IDENTIFIED BY 'DataAccess';

GRANT ALL PRIVILEGES ON CalorieCounting.* TO 'DataAccess'@'%';

FLUSH PRIVILEGES;