select * from shindig_appdata where appId = 3779 ;

update shindig_appdata set [value] = substring([value], 2, len([value])-2) where keyname = 'mentor_data'
and userId in (5543338, 4669955, 5419518)
and [value] like '[%]';


update li set li.status = 'E' from cls.dbo.tmp_linkImport li where [profiles id] in 
(select userId from shindig_appdata where appId = 103 and keyname='links');

select sa.* from shindig_appdata sa join cls.dbo.tmp_linkImport li on li.[profiles id] = sa.userId
where sa.appId = 103 and sa.keyname = 'links'; -- 67 people

update li set li.status = 'R' from shindig_appdata sa join cls.dbo.tmp_linkImport li on li.[profiles id] = sa.userId
where sa.appId = 103 and sa.keyname = 'links' and sa.[value] like '%' + li.[link URL] + '%';

select 'http://profiles.ucsf.edu/ProfileDetails.aspx?Person=' + cast(sa.userId as varchar) from shindig_appdata sa join cls.dbo.tmp_linkImport li on li.[profiles id] = sa.userId
where sa.appId = 103 and sa.keyname = 'links'; -- 67 people

--delete from shindig_appdata where appId = 103 and userId = 4669955;
select * from shindig_apps

select [profiles id], count(*) from cls.dbo.tmp_linkImport group by [profiles id]

-- update link  data 
update sa set sa.[value] = 
--select charindex('"},{"', sa.[value]),
'[{"link_name":"' + li.[Link title] + '","link_url":"' + li.[Link URL] + '"},' + substring(sa.[value], charindex('"},{"', sa.[value])+3, 255)
from shindig_appdata sa join cls.dbo.tmp_linkImport li on li.[profiles id] = sa.userId
where sa.appId = 103 and sa.keyname = 'links' and sa.value  like '%"},{"%';

-- to add link  data 
insert into shindig_appdata (userId, appId, keyname, [value]) 
select [profiles id], 103, 'links', '[{"link_name":"' + [Link title] + '","link_url":"' + [Link url] + '"}]'
from cls.dbo.tmp_linkImport where [status] is null;

insert shindig_app_registry (appId, personId) 
select 103, [profiles id] from cls.dbo.tmp_linkImport  where [Profiles id] is not null and [Profiles id] not in (select userId from shindig_appdata where appId = 103 and keyname = 'VISIBLE');

insert shindig_appdata (userId, appId, keyname, [value]) 
select [profiles id], 103, 'VISIBLE', 'Y'
from cls.dbo.tmp_linkImport  where [Profiles id] is not null and [Profiles id] not in (select userId from shindig_appdata where appId = 103 and keyname = 'VISIBLE');
----
select * from shindig_appdata where appid = 103 and 
userId in (5138614, 4657770)

select * from shindig_appdata where appid = 103 and keyname = 'links' and [value]
like '[\{"link_name":%"'

select * from shindig_appdata where appid = 103 and keyname = 'links' and [value]
not like '%"link_url":"http%';
--like '[[]{"link_name":"http:%';

select sa.userId, sa.[value] into tmplinks 
select sa.* from shindig_appdata sa join cls.dbo.tmp_linkImport li on li.[profiles id] = sa.userId
where sa.appId = 103 and sa.keyname = 'links'; -- 67 people

select * from tmplinks where [value] like '[[]{"link_name":"http:%';

update cls.dbo.tmp_linkImport set f = '[{"link_name":"' + [Link title] + '","link_url":"' + [Link URL] + '"}'

select * from cls.dbo.tmp_linkImport

update sa set sa.[value] = 
'[' + right(value, len(value) - len(f) - 1) from shindig_appdata sa join cls.dbo.tmp_linkImport li on li.[profiles id] =
sa.userId 
where sa.appid = 103 and sa.keyname = 'links' and 

len([value]) != len(f) +1;

select * 
delete from shindig_appdata where appId = 103 and keyname = 'links' and value = '[';