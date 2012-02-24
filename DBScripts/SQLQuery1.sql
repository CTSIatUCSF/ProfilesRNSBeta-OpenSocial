select * from disambiguation_pm_affiliations;

select [title code], [tci title nm abbrv], count(*) count from ucsfpro2 
where [cls unique id] in (select internalusername from vw_person where isactive = 1) 
group by [title code], [tci title nm abbrv]
order by count(*) desc;

select [title code], [tci title nm abbrv], ti.pretty_name, 
(CASE WHEN ISNULL(sec.title_name ,'')<>'' THEN '' ELSE 'Y' END) secondary_title, count(*) frequency from ucsfpro2 
left outer join titles_include_rs ti on ti.title_code = [title code] left outer join 
vw_person_secondary_title_codes sec on sec.title_code = [title code]
where [cls unique id] in (select internalusername from vw_person where isactive = 1) 
group by [title code], [tci title nm abbrv], ti.pretty_name, sec.title_name
order by count(*) desc;

create view vw_active_titles as select [title code] title_code, [tci title nm abbrv] title_name, ti.pretty_name, count(*) frequency from ucsfpro2 
left outer join titles_include_rs ti on ti.title_code = [title code] 
where [cls unique id] in (select internalusername from vw_person where isactive = 1) 
group by [title code], [tci title nm abbrv], ti.pretty_name
order by count(*) desc;

select at.*, (CASE WHEN at.title_code in (select title_code from
vw_person_secondary_title_codes) then 'Y' else '' end) is_secondary 
from vw_active_titles at order by frequency desc;

select primary_title from ucsfpro1 p1 where p1.id in (select internalusername from vw_person where isactive = 1) 
and primary_title not in (

select distinct [title code] from ucsfpro2 
where [cls unique id] in (select internalusername from vw_person where isactive = 1) 
and [title code]  not in (select  primary_title from ucsfpro1 p1 where p1.id in (select internalusername from vw_person where isactive = 1)  
)

select  * from vw_person_secondary_affiliations;
select  * from vw_person_secondary_title_codes order by id, pretty_name;

select * from vw_person_affiliations_all;
affiliations_all;
select disting
 
select * from profiles_100518.dbo._person_affiliations
where primaryaffiliation <> 1; 

select * from pm_all_xml where pmid not in (select pmid from pm_pubs_general);
-- 18489271

select * from disambiguation_pubmed where k is null and p is null;pmid = 18489271;

select * from profiles_100518.dbo.pm_all_xml where pmid = 18489271
select * from profiles_100518.dbo.publications_include where pmid = 18489271

delete from pm_all_xml where pmid = 18489271;
select * from profiles_100518_good.dbo.disambiguation_pubmed where pmid = 18489271;

insert publications_add select * from profiles_100518.dbo.publications_add;

insert publications_exclude select * from profiles_100518.dbo.publications_exclude;

select count(*) from pm_all_xml where ParseDT is null;  -- should be none
-- get missing pub
insert pm_all_xml 
select pmid, x, null from profiles_100518.dbo.pm_all_xml where pmid not in (select pmid from pm_all_xml);
-- parse missing pubs
exec usp_ParseAllPubMedXML;

insert publications_include 
select o.pubid, p.personid, o.pmid, o.mpid from profiles_100518.dbo.publications_include o join 
profiles_100518.dbo.person op on o.personid = op.personid join person p on p.internalusername = op.internalusername
where o.pmid is not null and op.internalusername  +
cast(o.pmid as varchar) not in (select internalusername + cast(pmid as varchar) from publications_include n join person p on
n.personid = p.personid where pmid is not null);

insert publications_include select * from profiles_100518.dbo.publications_include where pmid is null and 
mpid in (select mpid from publications_add);

select personid, count(*) from disambiguation_pubmed group by personid order by count(*) desc;

delete from publications_include where pmid is not null;
select * from publications_include;

exec usp_loadpmpublications_include;

select * from cls.dbo.ucsfpro1;