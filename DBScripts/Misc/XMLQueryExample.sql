-- this one works!
WITH XMLNAMESPACES ('http://ns.opensocial.org/2008/opensocial' as pd)
select per.displayname, act.activity.value('(//pd:title)[1]', 'nvarchar(max)') activity_type, 
CONVERT(VARCHAR(10),act.createdDT,111) [day], aff.title, dept.departmentname, inst.institutionname, fr.facultyrankfullname from shindig_activity act
join person per on act.userId = per.personid
join person_affiliations aff on aff.personid = per.personid
join department_fullname dfn on dfn.departmentfullnameid = aff.departmentfullnameid
join department dept on dept.departmentid = dfn.departmentid 
join institution_fullname ifn on ifn.institutionfullnameid = aff.institutionfullnameid
join institution inst on inst.institutionid = ifn.institutionid
join faculty_rank fr on fr.facultyrankid = aff.facultyrankid
where act.activity.value('(//pd:title)[1]', 'nvarchar(max)') != 'profile was viewed'
and act.activity.value('(//pd:title)[1]', 'nvarchar(max)') not like 'Profiles%'
and act.activity.value('(//pd:title)[1]', 'nvarchar(max)') != 'Added to Profiles'
and act.activity.value('(//pd:title)[1]', 'nvarchar(max)') not like 'Profiles%'
and aff.isprimary = 1;

-- raw one
--select top 100 * from shindig_activity;
WITH XMLNAMESPACES ('http://ns.opensocial.org/2008/opensocial' as pd)
select per.displayname, act.createdDT, act.activity.value('(//pd:title)[1]', 'nvarchar(max)') activity_type, 
--cast(act.activity as nvarchar(max)), 
act.xtraId1Type, act.xtraId1Value
from shindig_activity act
join person per on act.userId = per.personid
where act.activity.value('(//pd:title)[1]', 'nvarchar(max)') != 'profile was viewed'
and act.activity.value('(//pd:title)[1]', 'nvarchar(max)') not like 'Profiles%'
and act.activity.value('(//pd:title)[1]', 'nvarchar(max)') != 'Added to Profiles'
and act.activity.value('(//pd:title)[1]', 'nvarchar(max)') not like 'Profiles%'
and act.activity.value('(//pd:title)[1]', 'nvarchar(max)') not like 'gadget was viewed'
order by act.createdDT desc;


