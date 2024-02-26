## Infrastructure Project


1.- Run the script that are at the end of this file on MySQL workspace like MySQLWorkBranch.
2.- Configure Clean.Architecture.Web project as startup Program.
3.- Run the API and start to use CRUD operations.




## Script DataBase
CREATE DATABASE organisms;

USE organisms;

CREATE TABLE Person
(
	Pk_Person INT NOT NULL PRIMARY KEY auto_increment,    
	FullName VARCHAR(50),
	Phone_Number VARCHAR(50),
	Gender VARCHAR(10),
	Age TINYINT,      
	Email VARCHAR(100),
	Nationality VARCHAR(30),
    Last_Updated_Date  TIMESTAMP DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP
);

SELECT * FROM Person LIMIT 10;

