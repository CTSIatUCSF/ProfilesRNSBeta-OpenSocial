-- added photots
insert ucsf_person_activity select distinct personid, 'Added Photo', CONVERT(VARCHAR(10),GETDATE(),111)
from photo ph where personid not in (select personid from ucsf_person_activity where activity = 'Added Photo');

-- added awards
select distinct internalusername, displayname
from person p join awards aw on aw.personid = p.personid;

-- added narratives
select distinct internalusername, displayname
from person p join narratives nar on nar.personid = p.personid;

-- edited publications
select distinct internalusername, displayname
from person p join [my_pubs_general] my on my.personid = p.personid union
select distinct internalusername, displayname
from person p join publications_add pa on pa.personid = p.personid union
select distinct internalusername, displayname
from person p join publications_exclude pe on pe.personid = p.personid;

SELECT CONVERT(VARCHAR(10),GETDATE(),111);

alter view vw_ucsf_person_activity as select internalusername, displayname, activity, CONVERT(VARCHAR(10),[date],111) [day]
from person p join ucsf_person_activity a on p.personid = a.personid;

select * from vw_ucsf_person_activity;

truncate table ucsf_person_activity;

DECLARE @Date datetime;
SELECT @Date = CONVERT(VARCHAR(10),GETDATE(),111);

-- added photos
insert ucsf_person_activity select distinct personid, 'Added Photo', @Date
from photo where personid not in (select personid from ucsf_person_activity where activity = 'Added Photo');

-- added narratives
insert ucsf_person_activity select distinct personid, 'Added Narrative', @Date
from narratives where personid not in (select personid from ucsf_person_activity where activity = 'Added Narrative');

-- edited publications
insert ucsf_person_activity select distinct personid, 'Edited Publications', @Date
from [my_pubs_general] 
where personid not in (select personid from ucsf_person_activity where activity = 'Edited Publications')
union select distinct personid, 'Edited Publications', @Date from publications_add 
where personid not in (select personid from ucsf_person_activity where activity = 'Edited Publications')
union select distinct personid, 'Edited Publications', @Date
from publications_exclude
where personid not in (select personid from ucsf_person_activity where activity = 'Edited Publications');

select * from cls.dbo.vw_person where internalusername = '023988587';  --023988587 Marlene Berro

select * from cls.dbo.vip_include_rs where Employee_ID = '023988587';

select * from person where internalusername = '023988587'; 



select * from [user] where userid = 4968165;

select * from person where lastname like 'wynden';

select * from vw_ucsf_person_activity order by [day] desc;

;