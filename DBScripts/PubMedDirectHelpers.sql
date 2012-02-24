
-- the PUB in question
select * from pm_pubs_general where PMID = 20530312;
select * from profiles_100810.dbo.pm_all_xml where PMID = 20530312;
select * from profiles_100810_pm.dbo.pm_pubs_general  where PMID = 20530312;

select * from pm_pubs_general where PMID = 20530312;

select * from pm_pubs_mesh where PMID = 20530312;

select * from pm_pubs_mesh where PMID in ( 20182122, 20530312);
select * from pm_pubs_general where PMID = 20182122;

exec usp_GetPMIDList; --92659

select * from pm_test;
select TOP(25) * from pm_all_xml where parsedt > cast('2011-05-12' as datetime) order by parsedt desc;

-- see how many we have done today of 151925 total
select count(*), count(*)*100.0/191925 from pm_all_xml where parsedt > cast('2011-05-12' as datetime);

select CONVERT(xml, x, 2).value('(//MedlineCitation)[1]', 'nvarchar(max)') from pm_test where x like '<?%';

update pm_test set xm =  CONVERT(xml, x, 2).query('(//MedlineCitation)[1]') where x like '<?%';

select cast('2011-05-12' as datetime);

select 151925/3.0/60/60




