-- Write queries to return the following:
-- Make the following changes in the "world" database.

-- 1. Add Superman's hometown, Smallville, Kansas to the city table. The 
-- countrycode is 'USA', and population of 45001. (Yes, I looked it up on 
-- Wikipedia.)
SELECT * FROM city
WHERE countrycode = 'USA'
ORDER BY district


INSERT INTO city
(name, countrycode, district, population)
VALUES ('Smallville', 'USA', 'Kansas', 45001)

-- 2. Add Kryptonese to the countrylanguage table. Kryptonese is spoken by 0.0001
-- percentage of the 'USA' population.

SELECT * FROM countrylanguage
WHERE language = 'Kryptonese'


INSERT INTO countrylanguage
(countrycode, language, isofficial, percentage)
VALUES ('USA', 'Kryptonese', 0, 0.0001)

-- 3. After heated debate, "Kryptonese" was renamed to "Krypto-babble", change 
-- the appropriate record accordingly.
SELECT * FROM countrylanguage
WHERE language = 'Krypto-Babble'

UPDATE countrylanguage 
SET language = 'Krypto-babble'
WHERE countrycode = 'USA' AND language = 'Kryptonese'


-- 4. Set the US captial to Smallville, Kansas in the country table.

SELECT * FROM country
WHERE continent = 'North America'
SELECT * from city where name LIKE 'kan%'

UPDATE country 
SET capital = 4080
WHERE country.code = 'USA'

-- 5. Delete Smallville, Kansas from the city table. (Did it succeed? Why?)

DELETE FROM city

WHERE countrycode = 'USA' AND id = 4080

 -- No. The DELETE statement conflicted with the REFERENCE constraint "FK__country__capital__3E52440B". The conflict occurred in database "World", table "dbo.country", column 'capital'.
-- The statement has been terminated.

-- 6. Return the US captial to Washington.


SELECT * FROM country
WHERE continent = 'North America'
AND code ='USA'

UPDATE country 
SET capital = 3813
WHERE country.code = 'USA'

-- 7. Delete Smallville, Kansas from the city table. (Did it succeed? Why?)
DELETE FROM city

WHERE countrycode = 'USA' AND id = 4080

--Yes it did succeeed because Smallville was no longer located in country table after we changed the captial back to Washington. 


-- 8. Reverse the "is the official language" setting for all languages where the
-- country's year of independence is within the range of 1800 and 1972 
-- (exclusive). 
-- (590 rows affected)
SELECT isofficial FROM countrylanguage

JOIN country ON countrylanguage.countrycode = country.code
WHERE indepyear BETWEEN 1800 AND 1972




UPDATE countrylanguage
SET isofficial =
CASE isofficial  
when 1 then 0
when 0 then 1 
end
From country
JOIN countrylanguage ON country.code = countrylanguage.countrycode
WHERE indepyear BETWEEN 1800 AND 1972




-- 9. Convert population so it is expressed in 1,000s for all cities. (Round to
-- the nearest integer value greater than 0.)
-- (4079 rows affected)
SELECT population FROM city

BEGIN TRANSACTION 

UPDATE city
SET population = population / 1000



-- 10. Assuming a country's surfacearea is expressed in square miles, convert it to 
-- square meters for all countries where French is spoken by more than 20% of the 
-- population.
-- (7 rows affected)

SELECT * 
FROM countrylanguage
JOIN country ON country.code = countrylanguage.countrycode
WHERE language = 'French' AND percentage > 20
UPDATE country
SET surfacearea = surfacearea / 0.00000038610