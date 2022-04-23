DECLARE @FlightType AS TABLE 
(
 [FlightTypeID] INT NOT NULL PRIMARY KEY,
 [Type] VARCHAR(50) NOT NULL
)
INSERT INTO @FlightType ([FlightTypeID], [Type])
VALUES (1, 'One Way');
INSERT INTO @FlightType ([FlightTypeID], [Type])
VALUES (2, 'Round Trip');
--------------------------------------------------------------------------------------------
DECLARE @MealType AS TABLE 
(
 [MealTypeID] INT NOT NULL PRIMARY KEY,
 [Type] VARCHAR(50) NOT NULL
)
INSERT INTO @MealType ([MealTypeID], [Type])
VALUES (1, 'Chicken');
INSERT INTO @MealType ([MealTypeID], [Type])
VALUES (2, 'Beef');
INSERT INTO @MealType ([MealTypeID], [Type])
VALUES (3, 'Vegetarian');
-------------------------------------------------------------------------------------------
DECLARE @Flight AS TABLE 
(
 [FlightID] INT NOT NULL PRIMARY KEY,
 [FlightTypeID] INT NOT NULL,
 [MealTypeID] INT ,
 [PassengerName] VARCHAR(50) NOT NULL,
 [FlightNumber] VARCHAR(50) NOT NULL
)
INSERT INTO @Flight ([FlightID], [FlightTypeID],[MealTypeID],[PassengerName],[FlightNumber])
VALUES (1,1,1,'John','AA123');
INSERT INTO @Flight ([FlightID], [FlightTypeID],[MealTypeID],[PassengerName],[FlightNumber])
VALUES (2,2,2,'Wendy','UA471');
INSERT INTO @Flight ([FlightID], [FlightTypeID],[MealTypeID],[PassengerName],[FlightNumber])
VALUES (3,2,NULL,'Sarah','DL111');
INSERT INTO @Flight ([FlightID], [FlightTypeID],[MealTypeID],[PassengerName],[FlightNumber])
VALUES (4,2,3,'Paul','AC99');
---------------------------------------------------------------------------------------------

SELECT [flight].[FlightID] , 
[flight].[PassengerName],
[flight].[FlightNumber],
[flightType].[Type] AS FlightType,
ISNULL([mealType].[Type], 'Not Specified') AS MealType 
FROM @Flight flight
INNER JOIN @FlightType flightType ON flight.FlightTypeID = flightType.FlightTypeID
LEFT JOIN @MealType mealType ON flight.MealTypeID = mealType.MealTypeID











