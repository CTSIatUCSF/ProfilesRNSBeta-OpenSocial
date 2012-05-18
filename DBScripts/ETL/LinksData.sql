select * from shindig_appdata where appId = 3779 ;

update shindig_appdata set [value] = substring([value], 2, len([value])-2) where keyname = 'mentor_data'
and userId in (5543338, 4669955, 5419518)
and [value] like '[%]';


select * from cls.dbo.tmp_linkImport where [profiles id] in (select userId from shindig_appdata where appId = 103);

--delete from shindig_appdata where appId = 103 and userId = 4669955;


select 

-- to add link  data 
insert into shindig_appdata (userId, appId, keyname, [value]) 
select [profiles id], 103, 'links', '[{"link_name":"' + [Link title] + '","link_url":"' + [Link url] + '"}]'
from cls.dbo.tmp_linkImport where [Profiles id] is not null ;

insert shindig_appdata (userId, appId, keyname, [value]) 
select [profiles id], 103, 'VISIBLE', 'Y'
from cls.dbo.tmp_linkImport  where [Profiles id] is not null ;

insert shindig_app_registry (appId, personId) 
select 103, [profiles id] from cls.dbo.tmp_linkImport  where [Profiles id] is not null ;