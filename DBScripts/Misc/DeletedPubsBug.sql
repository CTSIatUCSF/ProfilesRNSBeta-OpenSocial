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

select 'delete from publications_add where PubID = ''' + cast(a.pubId as varchar(max)) +  ''';' from publications_add a join
publications_exclude e on a.PMID = e.pmid and a.personid = e.personid
where a.pmid is not null and e.PMID is not null;

delete from disambiguation_pubmed where( cast(pmid as varchar) + '.' + cast(personid as varchar)) in 
(select (cast(pmid as varchar) + '.' + cast(personid as varchar)) from publications_exclude);

--select 'exec usp_cache_pm_author_position_add_one ' + cast(personid as varchar) + ', ' + cast(pmid as varchar) + ';' from
--tmp_pub_cache;

--- multi ones
select a.pubid, b.pubid,a.personid, a.pmid from publications_exclude a join
publications_exclude b on a.personid = b.personid and a.pmid = b.pmid where a.pmid is not null and cast(a.pubid as varchar(max)) > cast(b.pubid as varchar(max));

delete from publications_exclude where pubid in (
	select b.pubid from publications_exclude a join
	publications_exclude b on a.personid = b.personid and a.pmid = b.pmid where a.pmid is not null and cast(a.pubid as varchar(max)) > cast(b.pubid as varchar(max)));
--
select a.pubid, b.pubid,a.personid, a.pmid from publications_include a join
publications_include b on a.personid = b.personid and a.pmid = b.pmid where a.pmid is not null and cast(a.pubid as varchar(max)) > cast(b.pubid as varchar(max));

delete from publications_include where pubid in (
	select b.pubid from publications_include a join
	publications_include b on a.personid = b.personid and a.pmid = b.pmid where a.pmid is not null and cast(a.pubid as varchar(max)) > cast(b.pubid as varchar(max)));
--
select a.pubid, b.pubid,a.personid, a.pmid from publications_add a join
publications_add b on a.personid = b.personid and a.pmid = b.pmid where a.pmid is not null and cast(a.pubid as varchar(max)) > cast(b.pubid as varchar(max));

delete from publications_add where pubid in (
	select b.pubid from publications_add a join
	publications_add b on a.personid = b.personid and a.pmid = b.pmid where a.pmid is not null and cast(a.pubid as varchar(max)) > cast(b.pubid as varchar(max)));
--
select personid, pmid, count(*) from publications_exclude where pmid is not null group by personid, pmid order by count(*) desc;
select personid, pmid, count(*) from publications_add where pmid is not null group by personid, pmid order by count(*) desc;
select personid, pmid, count(*) from publications_include where pmid is not null group by personid, pmid order by count(*) desc;
