select distinct activity from vw_ucsf_person_activity;

select * from vw_ucsf_person_activity;

------- Activity Report ---
select per.DisplayName, per.emailaddr , isnull(n.[day],'') [Added Narrative], isnull(ph.[day],'') [Added Photo], isnull(p.[day],'') [Edited Publications],
isnull(aw.[day],'') [Added Awards], isnull(CONVERT(VARCHAR(10),lnks.createdDT,111), '') [Added Links], isnull(CONVERT(VARCHAR(10),prs.createdDT,111), '') [Added Presentations],
aff.title, dept.departmentname, inst.institutionname, fr.facultyrankfullname
from ((((((((select distinct internalusername from vw_ucsf_person_activity) as a join person per on a.internalusername = per.internalusername)
 left outer join vw_ucsf_person_activity n on a.internalusername = n.internalusername and n.activity = 'Added Narrative')
 left outer join vw_ucsf_person_activity ph on a.internalusername = ph.internalusername and ph.activity = 'Added Photo')
 left outer join vw_ucsf_person_activity p on a.internalusername = p.internalusername and p.activity = 'Edited Publications')
 left outer join vw_ucsf_person_activity aw on a.internalusername = aw.internalusername and aw.activity = 'Added Awards')
 left outer join shindig_app_registry lnks on lnks.personid = per.personid and lnks.appId = 103) -- Websites
 left outer join shindig_app_registry prs on prs.personid = per.personid and prs.appId = 101) -- Presentations
join person_affiliations aff on aff.personid = per.personid
join department_fullname dfn on dfn.departmentfullnameid = aff.departmentfullnameid
join department dept on dept.departmentid = dfn.departmentid 
join institution_fullname ifn on ifn.institutionfullnameid = aff.institutionfullnameid
join institution inst on inst.institutionid = ifn.institutionid
join faculty_rank fr on fr.facultyrankid = aff.facultyrankid
where aff.isprimary = 1
order by isnull(isnull(isnull(n.[day], ph.[day]), p.[day]), ph.[day]);  


----- CLS data for Rachael
select name from syscolumns where id=object_id('vw_ucsfpro1');
select * from vw_ucsfpro1;
select name from syscolumns where id=object_id('vw_ucsfpro2');
select * from vw_ucsfpro2;
select name from syscolumns where id=object_id('vw_ahvsf_depdch_a');
select * from vw_ahvsf_depdch_a;
-- Profiles Data
select name from syscolumns where id=object_id('vw_person');
select * from vw_person;
select name from syscolumns where id=object_id('vw_person_affiliations');
select * from vw_person_affiliations;

--- List for Clay
select * from api_query_history order by querydate desc;

select 'biological data mining', r.personid, p.displayname, p.emailaddr, f.facultyrank, d.departmentname, d.departmentabbreviation
from api_query_results r join person p on r.personid = p.personid join person_affiliations pa on 
r.personid = pa.personid join faculty_rank f on pa.facultyrankid = f.facultyrankid join
department_fullname da on pa.departmentfullnameid = da.departmentfullnameid join 
department d on d.departmentid = da.departmentid where
pa.isPrimary = 1 and r.queryid = 'A437E766-3A8E-46B7-BDD4-8622AF265633';


--- CRS Publications
select p.InternalUsername, p.EmailAddr, p.DisplayName, pubs.* from person p join publications_include i on p.personid = i.personid 
join [vw_CRS_APR] pubs on i.PMID = pubs.PMID where pubs.[ReportingPeriod] = 'Yr4' and p.InternalUsername in 
(
) order by PMID;
