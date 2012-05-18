select IsActive, count(*) from [Profile.Data].[Person] group by IsActive; -- 5135 at 0, 4806 at 1

select * from [Profile.Data].[Person] where LastName in ('Yuan', 'Meeks', 'Kahlon');

select IsActive, count(*) from [User.Account].[User] group by IsActive;

select IsActive, count(*) from profiles_100810.dbo.person group by IsActive;


SELECT id, hash FROM [profiles_100RC1].[RDF.SemWeb].vwPublic_literals WHERE hash IN (N'+nz2QpCjYuclfcfCvvC4FYZUnms=' , N'dR0IoA0fUefnVXqcOQV56k5zrnU=');

SELECT id, hash FROM [profiles_100RC1].[RDF.SemWeb].vwPublic_literals WHERE hash IN (N'+nz2QpCjYuclfcfCvvC4FYZUnms=' , N'dR0IoA0fUefnVXqcOQV56k5zrnU=');

select * from [Rdf.].[Node] where NodeID in (175218);
select * from [Rdf.].[Alias] where NodeID = 175218;
select * from [Rdf.].[Triple] where Subject = 175218;
select * from [Rdf.].[vwTripleValue] where Subject = 175218;
select * from [Rdf.].[vwTripleValue] where ObjectValue = 'http://xmlns.com/foaf/0.1/Person' and sPublic = 1
select * from [Rdf.].[vwTripleValue] where ObjectValue  like 'eric.meeks@ucsf.edu'; -- 175218
select top 10 * from [Rdf.Security].[NodeAccess];
select top 10 * from [Rdf.Security].[TripleAccess] where Subject in (497587, 425376);

select * from [Ontology.].[DataMap] where SubjectNode in (497587, 425376);


select * from [Rdf.SemWeb].[vwPublic_Entities] where id = 425376;
select * from [Rdf.SemWeb].[vwPublic_Literals] where id = 425376;
select * from [Rdf.SemWeb].[vwPublic_Statements] where subject = 425376;



select top 10 * from [Rdf.].[Node] 
select top 10 * from [Rdf.].[Triple] 

select * from [profiles_100RC1].[Rdf.].[vwTripleValue] where PredicateValue = 'http://vivoweb.org/ontology/core#email';  --283

select p.personid, tv.subject, p.emailaddr  from person p join [profiles_100RC1].[Rdf.].[vwTripleValue] tv on 
tv.ObjectValue = p.emailaddr where PredicateValue = 'http://vivoweb.org/ontology/core#email';  --283

insert RDF 
select p.personid, tv.subject  from person p join [profiles_100RC1].[Rdf.].[vwTripleValue] tv on 
tv.ObjectValue = p.emailaddr where PredicateValue = 'http://vivoweb.org/ontology/core#email';  --283


select * from RDF; 

update RDF set URL = 'http://dev-profiles.ucsf.edu/profiles_100rc1/profile/' + cast(nodeId as varchar)+ '/' + cast(nodeId as varchar) 
+ '.rdf';