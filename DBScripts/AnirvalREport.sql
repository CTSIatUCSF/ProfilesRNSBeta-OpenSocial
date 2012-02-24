select * from shindig_activity;

select * from pm_all_xml where PMID in 
(select PMID from cls.dbo.disambiguation_pubmed_conflict) where PMID;

select personid, pmid from publications_include where PMID is not null;

select p.personid, p.displayname, p.emailaddr, p.phone, p.addressline1, p.addressline2, p.city,
p.state, p.zip, p.latitude, p.longitude, pa.title, inst.InstitutionName, dept.DepartmentName,
(case when photo.personid is not null then 'http://profiles.ucsf.edu/Thumbnail.ashx?id=' + cast(photo.personid as varchar)
else null end)
FROM (person p join person_affiliations pa on pa.personid = p.personid 
join institution_fullname inf on inf.institutionfullnameid = pa.institutionfullnameid
join institution inst on inst.institutionid = inf.institutionid
join department_fullname deptf on deptf.departmentfullnameid = pa.departmentfullnameid
join department dept on dept.departmentid = deptf.departmentid) left outer join photo on
photo.personid = p.personid
where pa.isprimary = 1;


ISNULL 

--
select distinct(keyname) from shindig_appdata where appid = 102;
select * from shindig_appdata where appid = 102;
