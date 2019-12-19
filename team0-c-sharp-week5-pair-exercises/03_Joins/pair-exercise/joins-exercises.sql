-- Write queries to return the following:
-- The following queries utilize the "world" database.

-- 1. The city name, country name, and city population of all cities in Europe with population greater than 1 million
-- (36 rows)
SELECT city.name, country.name, city.population FROM city 
JOIN country ON city.countrycode = country.code
WHERE continent ='Europe' AND city.population > 1000000
-- 2. The city name, country name, and city population of all cities in countries where 
      --French is an official language and the city population is greater than 1 million
-- (2 rows)

SELECT city.name CityName, country.name CountryName, city.population CityPopulation FROM city
JOIN countrylanguage ON city.countrycode = countrylanguage.countrycode
JOIN country ON city.countrycode = country.code
WHERE countrylanguage.language = 'French'
AND countrylanguage.isofficial = 1
AND city.population > 1000000


-- 3. The name of the countries and continents where the language Javanese is spoken
-- (1 row)
SELECT country.name, continent FROM country
JOIN countrylanguage ON country.code = countrylanguage.countrycode
WHERE countrylanguage.language = 'Javanese'

-- 4. The names of all of the countries in Africa that speak French as an official language
-- (5 row)
SELECT country.name, continent FROM country
JOIN countrylanguage ON country.code = countrylanguage.countrycode
WHERE countrylanguage.language = 'French'
AND countrylanguage.isofficial = 1
AND continent = 'AFRICA'

-- 5. The average city population of cities in Europe
-- (average city population in Europe: 287,684)
SELECT AVG(city.population) AVG FROM city
JOIN country ON city.countrycode = country.code
WHERE continent = 'Europe'


-- 6. The average city population of cities in Asia
-- (average city population in Asia: 395,019)
SELECT AVG(city.population) avg FROM city
JOIN country ON city.countrycode = country.code
WHERE continent = 'Asia'


-- 7. The number of cities in countries where English is an official language
-- (number of cities where English is official language: 523)

SELECT * FROM city
JOIN countrylanguage ON city.countrycode = countrylanguage.countrycode
WHERE countrylanguage.language = 'English'
AND countrylanguage.isofficial = '1'

-- 8. The average population of cities in countries where the official language is English
-- (average population of cities where English is official language: 285,809)

SELECT AVG(city.population) avg FROM city
JOIN countrylanguage ON city.countrycode = countrylanguage.countrycode
WHERE countrylanguage.language = 'English'
AND countrylanguage.isofficial = '1'

-- 9. The names of all of the continents and the population of the continent’s largest city
-- (6 rows, largest population for North America: 8,591,309)

SELECT MAX(city.population) POP, continent FROM city
JOIN country ON city.countrycode = country.code
GROUP BY continent
ORDER BY POP DESC


-- 10. The names of all of the cities in South America that have a population of more than 1
-- million people and the official language of each city’s country
-- (29 rows)

SELECT city.name, language FROM city
JOIN countrylanguage ON city.countrycode = countrylanguage.countrycode
JOIN country ON city.countrycode = country.code
WHERE isofficial = '1'
AND continent = 'South America'
AND city.population > 1000000
