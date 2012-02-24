delete from proxies_default;

insert into proxies_default select  newid(), NULL, NULL, userid,  'Y', 1, 1, 1, 1, 1, 1, 1, 1, 1, 1
 from [user] where DisplayName in ('Maninder K Kahlon', 'Eric R Meeks', 'Kristine M Moss', 'Rachael A Sak');

insert into proxies_default select  newid(), NULL, NULL, userid,  'Y', 1, 1, 1, 1, 1, 1, 1, 1, 1, 1
 from [user] where DisplayName = 'Katja Reuter';


select * from proxies_default;

select * from [user] where DisplayName in ('Maninder K Kahlon', 'Eric R Meeks', 'Kristine M Moss', 'Rachael A Sak');
select * from [user] where LastName in ('Kahlon', 'Meeks', 'Moss', 'Reuter', 'Sak', 'Yuan', 'Piontkowski');


update [user] set personid = userid;


-- use this !


insert into proxies_default select  newid(), NULL, NULL, userid,  'Y', 1, 1, 1, 1, 1, 1, 1, 1, 1, 1
from [user] where userid in (4999751, 5138614, 5152811, 4699897, 5559273, 5419518, 4621800, 5529043)

delete from proxies_default where proxy = 5058766;  -- remove emelda
delete from proxies_default where proxy = 4621800;  -- remove leslie


--
(1430444, 1569307, 1583504, 1130590, 1989966, 1850211, 1052493)

select userid, DisplayName from person where LastName in ('Kahlon', 'Meeks', 'Moss', 'Reuter', 'Sak', 'Yuan', 'Piontkowski', 'Brennan', 'Funes-Duran');

select * from person where userid in (4999751, 5138614, 5152811, 4699897, 5559273, 5419518, 4621800, 5058766, 5529043)
