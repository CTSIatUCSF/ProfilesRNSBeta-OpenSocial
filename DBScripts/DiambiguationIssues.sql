select p.displayname, d.*, i.* from disambiguation_pubmed d join person p on p.personid = d.personid 
left outer join publications_include i on i.personid = p.personid and i.pmid = d.pmid  where 
d.personid in (4675625, 5509686) and i.pmid is null