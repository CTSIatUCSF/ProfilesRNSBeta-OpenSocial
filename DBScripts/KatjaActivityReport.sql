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

-- test for overlap of removed and visible publications
select * from publications_include i join publications_exclude e on i.PMID = e.pmid and i.personid = e.personid
where i.pmid is not null;
select * from publications_add i join publications_exclude e on i.PMID = e.pmid and i.personid = e.personid
where i.pmid is not null;
-- historical
select * from publications_include i join cls.dbo.publications_exclude_snapshot e on i.PMID = e.pmid and i.personid = e.personid
where i.pmid is not null order by e.createddt desc;

select * from publications_include i join publications_exclude e on i.PubID = e.PubID;

-- new stuff
select c.* from cache_pm_author_position c join publications_exclude e on c.PMID = e.pmid and c.personid = e.personid;

select * from publications_add where (cast(pmid as varchar) + '.' + cast(personid as varchar)) not in 
(select (cast(pmid as varchar) + '.' + cast(personid as varchar)) from cache_pm_author_position);

select pubid, personid, pmid into tmp_pub_cache from publications_add where (cast(pmid as varchar) + '.' + cast(personid as varchar)) not in 
(select (cast(pmid as varchar) + '.' + cast(personid as varchar)) from cache_pm_author_position); --648

select d.* from disambiguation_pubmed d join publications_exclude e on d.PMID = e.pmid and d.personid = e.personid
where e.pmid is not null;

-- remove them!
--delete from cache_pm_author_position where personid = @PersonID and pmid = @pmid
--delete from publications_include where pubid in (select i.pubid from publications_include i join publications_exclude e on i.PMID = e.pmid and i.personid = e.personid
--where i.pmid is not null);

select 'exec usp_DeletePublication ' + cast(i.personid as varchar) + ' , ''' + cast(i.pubid as varchar(50)) + ''';' from publications_include i join publications_exclude e on i.PMID = e.pmid and i.personid = e.personid
where i.pmid is not null;
select 'exec usp_DeletePublication ' + cast(i.personid as varchar) + ' , ''' + cast(e.pubid as varchar(50)) + ''';' from publications_include i join publications_exclude e on i.PMID = e.pmid and i.personid = e.personid
where i.pmid is not null;

delete from disambiguation_pubmed where( cast(pmid as varchar) + '.' + cast(personid as varchar)) in 
(select (cast(pmid as varchar) + '.' + cast(personid as varchar)) from publications_exclude);

--select 'exec usp_cache_pm_author_position_add_one ' + cast(personid as varchar) + ', ' + cast(pmid as varchar) + ';' from
--tmp_pub_cache;


-- test
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


----
select * from vw_sna_summary;

select top 50 * from pm_all_xml order by pmid desc;

select * from pm_all_xml where pmid = 22238665;

select * from shindig_apps;


select * from vw_AHVSF_DEPDCH_A

select * from ucsf_person_activity order by date desc;

select * from cls.dbo.vw_UCSFPRO1 where surname like 'motion';

select * from sna_reach;;

select FirstName, LastName, count(*) from person group by FirstName, LastName order by count(*) desc;
select left(FirstName, 1), LastName, count(*) from person group by left(FirstName, 1), LastName order by count(*) desc;
