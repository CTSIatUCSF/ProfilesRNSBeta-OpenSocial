select * from shindig_activity where chatterFlag is null order by createdDt desc;  --241854
select * from shindig_activity where chatterFlag = 'S' order by createdDt desc;  --241854

select chatterFlag, count(*) from shindig_activity group by chatterFlag;


select * from shindig_activity where cast(activity as varchar(max)) like '%created this%'

--update shindig_activity set activity = cast( REPLACE(cast(activity as varchar(max)), 'thier', 'their') as xml)
where cast(activity as varchar(max)) like '%thier%';


--update shindig_activity set chatterFlag = 'H' where chatterFlag is null;



exec sp_ExportActivitiesToChatter 
	    'https://login.salesforce.com/services/Soap/c/22.0', 
	    'ctsiapi@oneorg.ucsf.edu', 
	    'IheartCTSI!12', 
	    '5UFwm4lElcLbTP50f5awnpCXa'


--
select * from shindig_apps; -- 106
select * from shindig_app_views;
select * from shindig_app_registry;

insert shindig_app_registry (appId, personId) values (106, 5138614)
insert shindig_app_registry (appId, personId) values (106, 5333232) -- brian
insert shindig_app_registry (appId, personId) values (106, 4621800) -- leslie
insert shindig_app_registry (appId, personId) values (106, 4999751) -- mini
insert shindig_app_registry (appId, personId) values (106, 5419518)  -- rachael

insert shindig_app_registry (appId, personId) values (106, 5152811)  -- kristine
insert shindig_app_registry (appId, personId) values (106, 4699897)  -- cynthia
insert shindig_app_registry (appId, personId) values (106, 4701285)  -- cynthia

5396511

---

select * from cls.dbo.vw_ucsfpro1 where surname = 'thomson'; --021319785

select * from [user] where username = '021319785'

select * from publications_include where personid = 4754887;
select * from publications_exclude where personid = 4754887;
select * from publications_add where personid = 4754887;

select * from person_filter_relationships where personid = 4754887

select * from person_filters;


--delete 
select * from cls.dbo.publications_trusted where concatid in 
(select cast(personid as varchar) + cast(pmid as varchar) from publications_exclude where pmid is not null);

--delete 
select * from publications_include where pmid is not null and cast(personid as varchar) + cast(pmid as varchar) in 
(select cast(personid as varchar) + cast(pmid as varchar) from publications_exclude where pmid is not null);

-- 709
			SELECT d.personid, '<activity xmlns="http://ns.opensocial.org/2008/opensocial"><postedTime>' + 
				cast(getdate() as varchar) + 
				'</postedTime><title>Profiles automatically added a publication to a profile</title><body>automatically had PubMed publication PMID = ' + 
				cast(d.pmid as varchar) + ' added to their profile</body></activity>', 'PMID', cast(d.pmid as nvarchar)
			FROM disambiguation_pubmed d 
			WHERE NOT EXISTS (SELECT *
								 FROM publications_include p
								WHERE p.personid = d.personid
								AND p.pmid = d.pmid) UNION
								SELECT *
								 FROM publications_exclude p
								WHERE p.personid = d.personid);

select * from publications_exclude where personid = 4651297 and pmid in (8632515
,10999578
,11180607
,11384791);