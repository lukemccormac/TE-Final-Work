-- Write queries to return the following:
-- The following changes are applied to the "dvdstore" database.**

-- 1. Add actors, Hampton Avenue, and Lisa Byway to the actor table.
SELECT * FROM actor


INSERT INTO actor (first_name, last_name)

VALUES ('Hampton', 'Avenue'), ('Lisa', 'Byway')

-- 2. Add "Euclidean PI", "The epic story of Euclid as a pizza delivery boy in
-- ancient Greece", to the film table. The movie was released in 2008 in English.
-- Since its an epic, the run length is 3hrs and 18mins. There are no special
-- features, the film speaks for itself, and doesn't need any gimmicks.

SELECT * FROM film
where title = 'Euclidean PI'

INSERT INTO film (title, description, release_year, language_id, length)
VALUES ('Euclidean PI', 'The epic story of Euclid as a pizza delivery boy in ancient Greece', 2008, 1, 198)

-- 3. Hampton Avenue plays Euclid, while Lisa Byway plays his slightly
-- overprotective mother, in the film, "Euclidean PI". Add them to the film.
SELECT * FROM film_actor

INSERT INTO film_actor(actor_id, film_id)
VALUES (202, 1001)

-- 4. Add Mathmagical to the category table.
SELECT * FROM category

INSERT INTO category(name)
VALUES ('Mathmagical')

-- 5. Assign the Mathmagical category to the following films, "Euclidean PI",
-- "EGG IGBY", "KARATE MOON", "RANDOM GO", and "YOUNG LANGUAGE"
--karate moon film id 494, eucidean pi is 1001, egg igby is 274, RANDOM GO 714, YOUNG LANGUAGE 996
SELECT * FROM film_category

INSERT INTO film_category(film_id, category_id)
VALUES (494, 17), (1001, 17), (274, 17), (714,17), (996, 17)


-- 6. Mathmagical films always have a "G" rating, adjust all Mathmagical films
-- accordingly.
-- (5 rows affected)
SELECT * FROM film
JOIN film_category ON film.film_id = film_category.film_id
WHERE film_category.category_id = 17


SELECT * FROM film
JOIN film_category ON film.film_id = film_category.film_id
WHERE film_category.category_id = 17
UPDATE film
SET rating = 'G'

-- 7. Add a copy of "Euclidean PI" to all the stores.

SELECT * FROM inventory

INSERT INTO inventory (film_id, store_id)
VALUES (1001, 1), (1001, 2)


-- 8. The Feds have stepped in and have impounded all copies of the pirated film,
-- "Euclidean PI". The film has been seized from all stores, and needs to be
-- deleted from the film table. Delete "Euclidean PI" from the film table.
-- (Did it succeed? Why?)
-- <No, there was a conflict because the film is in the inventory section so there was reference constraints. >

DELETE FROM film

WHERE film_id = 1001





-- 9. Delete Mathmagical from the category table.
-- (Did it succeed? Why?)
-- <NO, it did not work because Mathmagical occurs in the dvdstore" database and "film_category" so there was a conflict with the reference constraint. >

DELETE FROM category

WHERE category_id = 17




-- 10. Delete all links to Mathmagical in the film_category tale.
-- (Did it succeed? Why?)
-- <Yes it worked because there were no files dependant on this table, it was not the originl source.>

DELETE FROM film_category
WHERE category_id = 17


-- 11. Retry deleting Mathmagical from the category table, followed by retrying
-- to delete "Euclidean PI".
-- (Did either deletes succeed? Why?)
-- <Mathmagical was able to be deleted because the reference in the table category_film had been deleted, where as Euclidean was not able to be deted in the film table because there are still references >
DELETE FROM category

WHERE category_id = 17

DELETE FROM film

WHERE film_id = 1001
-- 12. Check database metadata to determine all constraints of the film id, and
-- describe any remaining adjustments needed before the film "Euclidean PI" can
-- be removed from the film table.
--We would need to remove the actor reference to the film_id"Euclidean PI" and the 2 references in the inventory table. 
