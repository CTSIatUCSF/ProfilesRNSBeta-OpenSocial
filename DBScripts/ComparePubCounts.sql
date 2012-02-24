select o.internalusername, op.displayname, 
o.num_publications [95_percent], 
a.num_publications [98_percent], 
o.num_publications - a.num_publications diff
from 
-- b.num_publications, 
--c.num_publications from 
profiles_100620.dbo.vw_pub_stats o join profiles_100620.dbo.person op on o.internalusername = op.internalusername 
join profiles_100620_98.dbo.vw_pub_stats a on a.internalusername = o.internalusername 
--join profiles_v2_dev.dbo.vw_pub_stats b on b.internalusername = a.internalusername 
--join profiles_100518.dbo.vw_pub_stats c on c.internalusername = a.internalusername 
--left outer join profiles.dbo.person prod on prod.internalusername = o.internalusername
--where (o.num_publications - a.num_publications) <> 0
order by diff desc;

--
select count(*) from disambiguation_pubmed where personid = 1429232;

select pmid from disambiguation_pubmed where personid = 1429232 and pmid not in 
(select pmid from profiles_100518_pubs.dbo.disambiguation_pubmed where personid = 1429232);


select * from publications_exclude where pmid is null

select * from publications_exclude where pubid not in (select pubid from publications_include);

select * from publications_exclude where personid = 1989966

select * from publications_include where personid = 1989966 and pmid not in 
(select pmid from profiles_100518.dbo.publications_include where personid = 1989966)

select count(*) from disambiguation_pubmed union select count(*) from pm_all_xml;

select * from cls.dbo.vw_all where ID = '022895767';

select * from person where internalusername = '022895767';

select * from cls.dbo.titles_include_rs where Pretty_Name like '%resid%';

select * from cls.dbo.vw_joined;


exec usp_cache_clear_api;


-- check to see that no excluded publications are being shown
select * from publications_include where mpid is not null and 
cast(personid as varchar) + '.' + cast(mpid as varchar) in
(select cast(personid as varchar) + '.' + cast(mpid as varchar) from publications_exclude where
mpid is not null);

delete from publications_include where pmid is not null and 
cast(personid as varchar) + '.' + cast(pmid as varchar) in
(select cast(personid as varchar) + '.' + cast(pmid as varchar) from publications_exclude where
pmid is not null)

select * from publications_add where pmid is not null and pmid not in (select pmid from pm_pubs_general)