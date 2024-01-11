

CREATE DATABASE MyStock;

USE MyStock;

CREATE TABLE Cars
(
	CarId INT PRIMARY KEY,
	CarName VARCHAR(50) NOT NULL,
	Manufacturer VARCHAR(50) NOT NULL,
	Price MONEY NOT NULL,
	ReleasedYear INT NOT NULL
)

INSERT INTO Cars(CarId, CarName, Manufacturer, Price, ReleasedYear) VALUES(1, 'Accord', 'Honda Motor Company', 24970, 2021)
INSERT INTO Cars(CarId, CarName, Manufacturer, Price, ReleasedYear) VALUES(2, 'BMW 8 Series', 'BMW', 85000, 2021) 
INSERT INTO Cars(CarId, CarName, Manufacturer, Price, ReleasedYear) VALUES(3, 'Clarity', 'Honda Motor Company', 33400, 2021) 
INSERT INTO Cars(CarId, CarName, Manufacturer, Price, ReleasedYear) VALUES(4, 'Audi A6', 'Audi', 14000, 2021) 
INSERT INTO Cars(CarId, CarName, Manufacturer, Price, ReleasedYear) VALUES(5, 'Everest Titanium 2.0L AT 4WD', 'Ford', 60000, 2021) 
INSERT INTO Cars(CarId, CarName, Manufacturer, Price, ReleasedYear) VALUES(6, 'Ranger Wildtrak 2.0L AT 4x4', 'Ford', 40000, 2021) 
INSERT INTO Cars(CarId, CarName, Manufacturer, Price, ReleasedYear) VALUES(7, 'Lexus IS', 'Lexus', 100000, 2021) 
INSERT INTO Cars(CarId, CarName, Manufacturer, Price, ReleasedYear) VALUES(8, 'Lexus IS 300h', 'Lexus', 220000, 2021) 




