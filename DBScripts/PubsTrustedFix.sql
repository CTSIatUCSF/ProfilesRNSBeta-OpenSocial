select i.*, d.personid, d.pmid, a.personid, a.pmid from publications_include i left outer join disambiguation_pubmed d on 
i.personid = d.personid and i.pmid = d.pmid left outer join publications_add a on
i.pubid = a.pubid --i.personid = a.personid and i.pmid = a.pmid
where i.pmid is not null and d.pmid is null --2757;


select i.*, a.personid, a.pmid from publications_include i 
join publications_add a on i.pubid = a.pubid --i.personid = a.personid and i.pmid = a.pmid
where i.pmid is not null; --0

select i.*, a.personid, a.pmid from publications_include i 
join publications_add a on i.personid = a.personid and i.pmid = a.pmid
where i.pmid is not null; --1297
-- PubId shoudl be uniique even when data is the same!

-- in publications include but not in publications_add or disambiguation_pubmed
select i.*, d.personid, d.pmid, a.personid, a.pmid from publications_include i left outer join disambiguation_pubmed d on 
i.personid = d.personid and i.pmid = d.pmid left outer join publications_add a on
i.personid = a.personid and i.pmid = a.pmid
where i.pmid is not null and d.pmid is null and a.pmid is null and a.mpid is null; --2741;

-- in publications include and in publications_add and disambiguation_pubmed
select i.*, d.personid, d.pmid, a.personid, a.pmid from publications_include i left outer join disambiguation_pubmed d on 
i.personid = d.personid and i.pmid = d.pmid left outer join publications_add a on
i.personid = a.personid and i.pmid = a.pmid
where i.pmid is not null and d.pmid is not null and a.pmid is not null; --4406;


select * from publications_add where pmid is not null; --1411

select * from publications_add where pubid not in (select pubid from publications_include); --1528
select * from publications_add where pubid  in (select pubid from publications_include); --3365

and i.pubid 