select * from cls.dbo.vip_include_rs;

select * from [user] where internalusername not in (select employee_id from cls.dbo.vip_include_rs);

update [person] set UserID = NULL where internalusername not in (select employee_id from cls.dbo.vip_include_rs);
update [user] set PersonID = NULL where PersonID not in (select PersonID from [person] where userId is not null);
delete from publications_add where personid not in (select personid from [person] where userid is not null);
delete from publications_exclude where personid not in (select personid from [person] where userid is not null);
delete from publications_include where personid not in (select personid from [person] where userid is not null);
delete from my_pubs_general where personid not in (select personid from [person] where userid is not null);
delete from photo where personid not in (select personid from [person] where userid is not null);
delete from awards where personid not in (select personid from [person] where userid is not null);
delete from narratives where personid not in (select personid from [person] where userid is not null);
delete from shindig_appdata where userId not in (select personid from [person] where userid is not null);
delete from shindig_app_registry where personid not in (select personid from [person] where userid is not null);
delete from proxies_designated where personid not in (select personid from [person] where userid is not null);
delete from display_prefs where personid not in (select personid from [person] where userid is not null);
delete from person_affiliations where personid not in (select personid from [person] where userid is not null);
delete from search_history where personid not in (select personid from [person] where userid is not null);
delete from search_history where userId not in (select userId from [person] where userid is not null);
delete from sna_betweenness where personid not in (select personid from [person] where userid is not null);
delete from sna_coauthors where personid1 not in (select personid from [person] where userid is not null);
delete from sna_coauthors where personid2 not in (select personid from [person] where userid is not null);
delete from sna_reach where personid not in (select personid from [person] where userid is not null);
delete from cache_top_views where personid not in (select personid from [person] where userid is not null);
delete from [user] where personid is null;
delete from [person] where userId is null;
update person set isActive = 1, visible = 1;

select * from [user];
select * from [person];