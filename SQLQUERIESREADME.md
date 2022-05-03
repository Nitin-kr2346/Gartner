# SQL Test Assignment

Attached is a mysqldump of a database to be used during the test.

Below are the questions for this test. Please enter a full, complete, working SQL statement under each question. We do not want the answer to the question. We want the SQL command to derive the answer. We will copy/paste these commands to test the validity of the answer.

**Example:**

_Q. Select all users_

- Please return at least first_name and last_name

SELECT first_name, last_name FROM users;


------

**— Test Starts Here —**

1. Select users whose id is either 3,2 or 4
- Please return at least: all user fields

Ans: SELECT * FROM users WHERE id IN (3, 2, 4);

2. Count how many basic and premium listings each active user has
- Please return at least: first_name, last_name, basic, premium

Ans: SELECT USR.id,
			USR.first_name, 
			USR.last_name,
			SUM(CASE WHEN LST.status = 2 THEN 1 ELSE 0 END) AS basic,
			SUM(CASE WHEN LST.status = 3 THEN 1 ELSE 0 END) AS premium
	 FROM users USR join listings LST 
	 ON USR.id = LST.user_id
	 WHERE USR.status = 2
	 GROUP BY USR.id, USR.first_name, USR.last_name;


3. Show the same count as before but only if they have at least ONE premium listing
- Please return at least: first_name, last_name, basic, premium

Ans: SELECT USR.id,
			USR.first_name, 
			USR.last_name,
			SUM(CASE WHEN LST.status = 2 THEN 1 ELSE 0 END) AS basic,
			SUM(CASE WHEN LST.status = 3 THEN 1 ELSE 0 END) AS premium
	 FROM users USR JOIN listings LST 
	 ON USR.id = LST.user_id
	 WHERE USR.status = 2
	 GROUP BY USR.id, USR.first_name, USR.last_name
	 HAVING SUM(CASE WHEN LST.status = 3 THEN 1 ELSE 0 END) > 0;


4. How much revenue has each active vendor made in 2013
- Please return at least: first_name, last_name, currency, revenue

Ans: SELECT USR.id,
			USR.first_name, 
			USR.last_name,
			CLK.currency,
			SUM(CLK.price) AS premium
	 FROM users USR JOIN listings LST ON USR.id = LST.user_id
	 JOIN clicks CLK ON LST.id = CLK.listing_id
	 WHERE USR.status = 2 AND DATEPART(YEAR, CLK.created) = 2013;
	 GROUP BY USR.id, USR.first_name, USR.last_name, CLK.currency 
	 HAVING SUM(CASE WHEN LST.status = 3 THEN 1 ELSE 0 END) > 0;


5. Insert a new click for listing id 3, at $4.00
- Find out the id of this new click. Please return at least: id

Ans: INSERT INTO clicks VALUES (3, 4.00, 'USD', GETDATETIME());
     SET @LASTID = IDENT_CURRENT('dbo.clicks')


6. Show listings that have not received a click in 2013
- Please return at least: listing_name

Ans: SELECT LST.id,
			LST.listing_name
	 FROM clicks CLK JOIN listings LST
	 ON LST.id = CLK.listing_id
	 WHERE DATEPART(YEAR, CLK.created) <> 2013


7. For each year show number of listings clicked and number of vendors who owned these listings
- Please return at least: date, total_listings_clicked, total_vendors_affected

Ans: SELECT DATEPART(YEAR, CLK.created) AS date,
			COUNT(CLK.id) AS total_listings_clicked
			COUNT(USR.id) AS total_vendors_affected
	 FROM users USR JOIN listings LST ON USR.id = LST.user_id
	 JOIN clicks CLK ON LST.id = CLK.listing_id
	 GROUP BY DATEPART(YEAR, CLK.created) 

8. Return a comma separated string of listing names for all active vendors
- Please return at least: first_name, last_name, listing_names

Ans: SELECT USR.id,
			USR.first_name, 
			USR.last_name, 
			STUFF((SELECT ', ' + CAST(INNERLST.name AS VARCHAR(10)) [text()]
         FROM listings INNERLST
         WHERE INNERLST.id = LST.id
         FOR XML PATH(''), TYPE)
        .value('.','NVARCHAR(MAX)'),1,2,' ') listing_names
	FROM users USR JOIN listings LST ON USR.id = LST.user_id
	GROUP BY USR.id, USR.first_name,USR.last_name