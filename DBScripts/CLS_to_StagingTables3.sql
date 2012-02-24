delete from _person;
delete from _person_affiliations;
delete from _person_filter_flags;
delete from _user;

-- if doing a reload, do this as well;
truncate table person_filter_relationships;
truncate table person_affiliations;

delete from person_affiliations;
delete from person_filter_relationships;
delete from person_filters;
delete from department_fullname;
delete from department;
delete from institution_fullname;
delete from institution;
delete from division;
delete from division_fullname;
delete from faculty_rank;
--- stop here to just reload fresh _person data
update person set userid = null;
delete from [user];
delete from person_add;
delete from person;
---
--
--
-- start here 
--
insert disambiguation_pm_affiliations select * from cls.dbo.disambiguation_pm_affiliations;
insert google_keys  select * from cls.dbo.google_keys;
insert google_map_preferences  select * from cls.dbo.google_map_preferences;

insert _person select * from cls.dbo.vw_person;
insert _person_affiliations select * from cls.dbo.vw_person_affiliations;
insert _person_affiliations select * from cls.dbo.vw_person_secondary_affiliations;
insert _person_filter_flags select * from cls.dbo.vw_person_filter_flags;
--insert _person_filter_flags select internalusername, 1, persontypeflag from cls.dbo.vw_person_type_flags;
--update _person_affiliations set facultyrank = facultyrankfullname;

select * from profiles_parameters;
update profiles_parameters set [Value] = 'http://dev-profiles.ucsf.edu/ucsf_100810/ProfileDetails.aspx?Person=' where ParameterName = 'ProfilesURL';

--update _person_affiliations set affiliationorder = 3 where internalusername = '022512305' and title like 'Inter%';
--update _person_affiliations set title = 'Vice Provost' where internalusername = '025297870' and primaryaffiliation = 1;

-- see who is new
select * from _person where internalusername not in (select internalusername from person) order by isactive desc;

-- see who is gone
select * from person where internalusername not in (select internalusername from _person) order by isactive desc;

-- deactivate people who are now gone
update person set isactive = 0 where internalusername not in (select internalusername from _person) and isactive = 1;

EXEC dbo.usp_LoadProfilesData 1;

select internalid, count(*) from _person group by internalid order by count(*) desc;

--select * from cls.dbo.vw_person where internalid = '1614741';
--select * from cls.dbo.vw_all where ID = '026147413'
--select * from cls.dbo.vip_include_rs where [employee_id] = '026147413'
--select * from cls.dbo.vw_all where LAST = 'Arron'; 022612162

--EXEC dbo.usp_LoadProfilesData 'University of California at San Francisco','UCSF', 'http://dev.profiles.ucsf.edu/harvard_v4/', 'http://www.ncbi.nlm.nih.gov/pubmed/';

--update department set Visible = 1;
--update department set Visible = 0 where DepartmentAbbreviation = 'Other';

select * from disambiguation_pm_affiliations;

-- check a few things
select * from faculty_rank;
select * from institution;
select * from institution_fullname;
select * from division;
select * from department;
select * from department_fullname;

select * from person_filters;
select * from person_filter_relationships;

select * from person;
select * from [user];
select * from person_affiliations;

-- cleanup faculty rank, this step is not always needed
update f set f.facultyrankfullname = t.title_description, f.facultyrank = t.title_description from
faculty_rank f inner join cls.dbo.titles_detail t on f.facultyrankcode = title_rank;

-- update person fields;
UPDATE t
   SET 
	  t.FirstName = s.FirstName,
      t.LastName = s.LastName,
      t.MiddleName = s.MiddleName,
      t.DisplayName = s.DisplayName,
      t.DegreeList = s.Degree,
      t.Suffix = s.Suffix,
      t.IsActive = s.IsActive, 
      t.EmailAddr = s.EmailAddr,
      t.Phone = s.Phone, 
      t.Fax = s.Fax, 
      t.AddressLine1 = s.AddressLine1, 
      t.AddressLine2 = s.AddressLine2, 
      t.AddressLine3 = s.AddressLine3, 
      t.AddressLine4 = s.AddressLine4, 
      t.City = s.City, 
      t.State = s.State, 
      t.Zip = s.Zip, 
      t.Building = s.Building,
      t.[Floor] = s.[Floor], 
      t.Room = s.Room,
      t.AddressString = s.AddressString, 
      t.Latitude = s.Latitude, 
      t.Longitude = s.Longitude, 
--      t.GeoScore = s.GeoScore, 
      t.AssistantName = s.AssistantName,
      t.AssistantPhone = s.AssistantPhone, 
      t.AssistantEmail = s.AssistantEmail,
      t.AssistantAddress = s.AssistantAddress, 
      t.AssistantFax = s.AssistantFax, 
      t.Title = s.Title,
--      t.JobCode = s.JobCode, 
      t.InternalLDAPUserName = s.InternalLDAPUserName,
      t.InternalPersonType = s.InternalPersonType, 
      t.InternalFullPartTime = s.InternalFullPartTime,
      t.InternalAdminTitle = s.InternalAdminTitle, 
      t.InternalDeptType = s.InternalDeptType,
	  t.FacultyRankId = f.facultyRankID
FROM person t
INNER JOIN _person s on t.internalusername = s.internalusername
inner join _person_affiliations a on s.internalusername = a.internalusername 
inner join faculty_rank f on f.facultyrankcode = a.facultyrankcode;

-- update user fields
UPDATE u
   SET 
	  u.FirstName = p.FirstName,
      u.LastName = p.LastName,
      u.DisplayName = p.DisplayName,
      u.InstitutionFullName = i.institutionfullname,
      u.DepartmentFullName = d.departmentfullname
FROM [user] u
inner join person p on p.personid = u.personid
INNER JOIN person_affiliations a on a.personid = u.personid
inner join institution_fullname i on a.institutionfullnameid = i.institutionfullnameid
inner join department_fullname d on a.departmentfullnameid = d.departmentfullnameid;

update person set visible = 1 where visible is null;

exec usp_processcachetables;
exec usp_cache_top_search_kw 'm';
exec usp_cache_top_search_kw 'd';
exec usp_cache_top_search_kw 'w';
exec usp_cache_top_views 'm';
exec usp_cache_top_views 'd';
exec usp_cache_top_views 'w';
exec usp_cache_word2mesh_all;
exec usp_cache_mesh;
exec usp_cache_pub_mesh;
exec usp_cache_word2mesh;
exec usp_CacheSimilarPeople;

-- stop

select * from person where lastname = 'Meeks';
select * from _person_affiliations where internalusername = '021410204';

select * from profiles_copy_bak.dbo.person_affiliations;

select * from titles_include_rs where title_code = '1744'

select * from [user];
select * from profiles.dbo.faculty_rank;

select degreelist, degree, len(degree) from person p , _person _p where p.internalusername = _p.internalusername order by len(degree) desc;

select * from person where lastname = 'Chesney' or lastname = 'Bass';

select * from person_affiliations where facultyrankid  where personid = 3537 or person;
select * from vw_sna_summary;

select * from profiles.dbo.person_affiliations where personid = 3537 or personid = 979;

select count(*) from person where isactive = 1;
select count(*) from profiles.dbo.person where isactive = 1;

select * from publications_add;

select * from profiles.dbo.publications_add;

select * from publications_exclude order by personid;
select * from profiles.dbo.publications_exclude order by personid;


select * from publications_exclude where pubid not in (select pubid from profiles.dbo.publications_exclude);
select * from publications_add where pubid not in (select pubid from profiles.dbo.publications_add);
select * from profiles.dbo.publications_exclude where pubid not in (select pubid from publications_exclude);
select * from profiles.dbo.publications_add where pubid not in (select pubid from publications_add);

insert publications_add select * from profiles.dbo.publications_add where pubid not in (select pubid from publications_add);

select * from publications_include2 where personid = 11588;

select * from vw_person;
select * from vw_clsaddress;

insert geo_CLSAddress select addressline1, addressline2, city, state, zip, null, uniqueaddressstring from 
vw_clsaddress where uniqueaddressstring not in (select uniqueaddressstring from geo_CLSAddress);

select * from geo_CLSAddress where clsaddressid not in (select clsaddressid from geo_alteredaddress where geoscore is null or geoscore >= 4);

select clsaddressid from geo_alteredaddress where geoscore is null or geoscore >= 4

select * from geo_alteredaddress;

select * from geo_alteredaddress order by clsaddressid desc;

update geo_AlteredAddress set profilesscore = geoscore*100 +
(case alteration
when 'CLEAN' then 9
when 'SIMPLE THOROUGHFARE' then 8
when 'SWAP THOROUGHFARE' then 7
when 'FORCE SAN FRANCISCO' then 6
when 'SWAP CITY' then 5
when 'DROP CITY' then 4
else 0 END
)
where profilesscore is null

update geo_alteredaddress set profilesscore = 0 where len(zip) <> 5

select distinct(state) from geo_alteredaddress where profilesscore = 0;

select * from geo_alteredaddress where state = 'AB';

select isactive, count(*) from vw_person group by isactive;

select * from profiles_copy_new.dbo._person where internalusername not in (select internalusername from vw_person) order by isactive desc;
select * from vw_person where internalusername not in (select internalusername from profiles_copy_new.dbo._person) order by isactive desc;