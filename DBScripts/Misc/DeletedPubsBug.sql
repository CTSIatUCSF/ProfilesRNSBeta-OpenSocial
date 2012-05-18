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

delete from disambiguation_pubmed where( cast(pmid as varchar) + '.' + cast(personid as varchar)) in 
(select (cast(pmid as varchar) + '.' + cast(personid as varchar)) from publications_exclude);

--select 'exec usp_cache_pm_author_position_add_one ' + cast(personid as varchar) + ', ' + cast(pmid as varchar) + ';' from
--tmp_pub_cache;

