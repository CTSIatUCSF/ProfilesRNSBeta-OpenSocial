-- narratives, photos, prefs

SET IDENTITY_INSERT photo ON;
insert into photo (photoid, personid, photousagetypeid, photo, photolink)
 select photoid, n.personid, photousagetypeid, photo, photolink from person n inner join profiles_100708_prod.dbo.person o on
n.internalusername = o.internalusername inner join profiles_100708_prod.dbo.photo p on o.personid = p.personid;
SET IDENTITY_INSERT photo OFF;
--
SET IDENTITY_INSERT awards ON;
insert into awards (awardid, personid, yr, yr2, awardnm, awardinginst)
select awardid, n.personid, yr, yr2, awardnm, awardinginst from person n inner join profiles_100708_prod.dbo.person o on
n.internalusername = o.internalusername inner join profiles_100708_prod.dbo.awards p on o.personid = p.personid;
SET IDENTITY_INSERT awards OFF;
--
insert narratives select n.personid, narrativemain from person n inner join profiles_100708_prod.dbo.person o on
n.internalusername = o.internalusername inner join profiles_100708_prod.dbo.narratives p on o.personid = p.personid;
--
insert into display_prefs select n.personid, ShowPhoto, ShowPublications, ShowAwards, ShowNarrative, ShowAddress, ShowEmail,
ShowPhone, ShowFax, PhotoPreference from person n inner join profiles_100708_prod.dbo.person o on 
n.internalusername = o.internalusername inner join profiles_100708_prod.dbo.display_prefs p on o.personid = p.personid;
--
-- move designated proxies
insert into proxies_designated select n.personid, nu.userid from profiles_100708_prod.dbo.proxies_designated op join
profiles_100708_prod.dbo.person o on op.personid = o.personid join profiles_100708_prod.dbo.[user] ou on op.proxy = ou.userid join
person n on n.internalusername = o.internalusername join [user] nu on nu.internalusername = ou.internalusername;

--- add pub metadata BEGIN
insert pm_all_xml select * from profiles_100708_prod.dbo.pm_all_xml where pmid not in (select pmid from pm_all_xml);
insert pm_pubs_general select * from profiles_100708_prod.dbo.pm_pubs_general where pmid not in (select pmid from pm_pubs_general);
insert pm_pubs_chemicals select * from profiles_100708_prod.dbo.pm_pubs_chemicals where pmid not in (select pmid from pm_pubs_chemicals);
insert pm_pubs_databanks select * from profiles_100708_prod.dbo.pm_pubs_databanks where pmid not in (select pmid from pm_pubs_databanks);
insert pm_pubs_grants select * from profiles_100708_prod.dbo.pm_pubs_grants where pmid not in (select pmid from pm_pubs_grants);
insert pm_pubs_keywords select * from profiles_100708_prod.dbo.pm_pubs_keywords where pmid not in (select pmid from pm_pubs_keywords);
insert pm_pubs_mesh select * from profiles_100708_prod.dbo.pm_pubs_mesh where pmid not in (select pmid from pm_pubs_mesh);
insert pm_pubs_pubtypes select * from profiles_100708_prod.dbo.pm_pubs_pubtypes where pmid not in (select pmid from pm_pubs_pubtypes);
insert pm_pubs_accessions select * from profiles_100708_prod.dbo.pm_pubs_accessions where pmid not in (select pmid from pm_pubs_accessions);
--
SET IDENTITY_INSERT pm_pubs_authors ON;
INSERT INTO [pm_pubs_authors]
           (PmPubsAuthorID, [PMID]
           ,[ValidYN]
           ,[LastName]
           ,[FirstName]
           ,[ForeName]
           ,[Suffix]
           ,[Initials]
           ,[Affiliation])
     select * from profiles_100708_prod.dbo.pm_pubs_authors;
SET IDENTITY_INSERT pm_pubs_authors OFF;
--
SET IDENTITY_INSERT pm_pubs_investigators ON;
INSERT INTO pm_pubs_investigators
           (PmPubsInvestigatorID, [PMID]
           ,[LastName]
           ,[FirstName]
           ,[ForeName]
           ,[Suffix]
           ,[Initials]
           ,[Affiliation])
     select * from profiles_100708_prod.dbo.pm_pubs_investigators;
SET IDENTITY_INSERT pm_pubs_investigators OFF;
--
insert pm_authors2username select n.personid, PmPubsAuthorId from person n inner join profiles_100708_prod.dbo.person o on
n.internalusername = o.internalusername inner join profiles_100708_prod.dbo.pm_authors2username a on a.personid = o.personid;
--
insert pm_disambiguation_audit select d.batchid, d.batchcount, n.personid, d.servicecallstart, d.servicecallend, d.servicecallpubsfound,
d.servicecallnewpubs, d.servicecallexistingpubs, d.servicecallpubsadded, d.processend, d.success, d.errortext from person n 
inner join profiles_100708_prod.dbo.person o on
n.internalusername = o.internalusername inner join profiles_100708_prod.dbo.pm_disambiguation_audit d on d.personid = o.personid;
--- add pub metadata END

-- manually added publications
INSERT INTO [my_pubs_general]
           ([mpid]
           ,n.[PersonID]
           ,[PMID]
           ,[HmsPubCategory]
           ,[NlmPubCategory]
           ,[PubTitle]
           ,[ArticleTitle]
           ,[ArticleType]
           ,[ConfEditors]
           ,[ConfLoc]
           ,[EDITION]
           ,[PlaceOfPub]
           ,[VolNum]
           ,[PartVolPub]
           ,[IssuePub]
           ,[PaginationPub]
           ,[AdditionalInfo]
           ,[PUBLISHER]
           ,[SecondaryAuthors]
           ,[ConfNm]
           ,[ConfDTs]
           ,[ReptNumber]
           ,[ContractNum]
           ,[DissUnivNm]
           ,[NewspaperCol]
           ,[NewspaperSect]
           ,[PublicationDT]
           ,[ABSTRACT]
           ,[AUTHORS]
           ,[URL]
           ,[CreatedDT]
           ,[CreatedBy]
           ,[UpdatedDT]
           ,[UpdatedBy])
SELECT [mpid]
      ,n.[PersonID]
      ,[PMID]
      ,[HmsPubCategory]
      ,[NlmPubCategory]
      ,[PubTitle]
      ,[ArticleTitle]
      ,[ArticleType]
      ,[ConfEditors]
      ,[ConfLoc]
      ,[EDITION]
      ,[PlaceOfPub]
      ,[VolNum]
      ,[PartVolPub]
      ,[IssuePub]
      ,[PaginationPub]
      ,[AdditionalInfo]
      ,[PUBLISHER]
      ,[SecondaryAuthors]
      ,[ConfNm]
      ,[ConfDTs]
      ,[ReptNumber]
      ,[ContractNum]
      ,[DissUnivNm]
      ,[NewspaperCol]
      ,[NewspaperSect]
      ,[PublicationDT]
      ,[ABSTRACT]
      ,[AUTHORS]
      ,[URL]
      ,[CreatedDT]
      ,[CreatedBy]
      ,[UpdatedDT]
      ,[UpdatedBy]
  FROM person n inner join profiles_100708_prod.dbo.person o on n.internalusername = o.internalusername inner join
profiles_100708_prod.[dbo].[my_pubs_general] p on o.personid = p.personid;

-- the publications themselves
insert publications_add select PubID, n.personid, pmid, mpid from person n inner join profiles_100708_prod.dbo.person o on 
n.internalusername = o.internalusername inner join profiles_100708_prod.dbo.publications_add p on o.personid = p.personid
where PubID not in (select PubID from publications_add);
--
insert publications_exclude select PubID, n.personid, pmid, mpid from person n inner join profiles_100708_prod.dbo.person o on 
n.internalusername = o.internalusername inner join profiles_100708_prod.dbo.publications_exclude p on o.personid = p.personid
where PubID not in (select PubID from publications_exclude);

-- only add those that A) are in publications_add and B) are not already in publications_include and C) are in the source
-- publications_include
insert publications_include 
select newid(), personid, pmid, mpid from publications_add where 
ltrim(cast(personid as nvarchar)) + ltrim(isnull(cast(pmid as nvarchar), 'pmid')) + ltrim(isnull(cast(mpid as nvarchar), 'mpid')) 
not in 
(select ltrim(cast(personid as nvarchar)) + ltrim(isnull(cast(pmid as nvarchar), 'pmid')) + ltrim(isnull(cast(mpid as nvarchar), 'mpid')) from publications_include)
and
ltrim(cast(personid as nvarchar)) + ltrim(isnull(cast(pmid as nvarchar), 'pmid')) + ltrim(isnull(cast(mpid as nvarchar), 'mpid')) 
in 
(select ltrim(cast(n.personid as nvarchar)) + ltrim(isnull(cast(i.pmid as nvarchar), 'pmid')) + ltrim(isnull(cast(i.mpid as nvarchar), 'mpid')) from profiles_100810_prod_new.dbo.publications_include i
inner join profiles_100810_prod_new.dbo.person o on i.personid = o.personid inner join person n on  n.internalusername = o.internalusername);

-----------------------------------------------------------------

-- add all publications from source that are not already present but filter out if pmid is not in pm_pubs_general
insert publications_include 
select o.pubid, p.personid, o.pmid, o.mpid from profiles_100810_prod_new.dbo.publications_include o join 
profiles_100810_prod_new.dbo.person op on o.personid = op.personid join person p on p.internalusername = op.internalusername
where o.pmid is not null and o.pmid in (select pmid from pm_pubs_general) and 
op.internalusername  +
cast(o.pmid as varchar) not in (select internalusername + cast(pmid as varchar) from publications_include n join person p on
n.personid = p.personid where pmid is not null);

-- end publications 
----------------------
--
-- 
-- TO ONLY ADD MANUAL EDITS START HERE!!!!!
--
--
select pmid from publications_add where pmid not in (select distinct pmid from publications_include) and pmid is not null
and pmid not in (select distinct pmid from disambiguation_pubmed);


-- add missing pubs


--
-- get more pubs
--insert pm_pubs_general select * from profiles.dbo.pm_pubs_general where mpid not in (select mpid from pm_pubs_general);
--

--
-- synch up pm_pubs_general with publications_add by running PubMedDisambiguation_GetPubMEDXML

--
--
--
--  Add other non-manual  pubs from other db
-- make sure all pubs are currenlty parsed
select count(*) from pm_all_xml where ParseDT is null;  -- should be none
-- get missing pub
insert pm_all_xml 
select pmid, x, null from profiles.dbo.pm_all_xml where pmid not in (select pmid from pm_all_xml);
-- parse missing pubs
exec usp_ParseAllPubMedXML;


select pmid from profiles.dbo.pm_pubs_general where pmid not in (select pmid from pm_pubs_general);




---- general test queries
select mpid from publications_add where mpid is not null and mpid not in (select mpid from my_pubs_general)
select pmid from publications_add where pmid is not null and pmid not in (select pmid from pm_pubs_general);

select pmid from publications_add where pmid not in (select pmid from pm_pubs_general);
select * from pm_pubs_general where pmid = 120906;
select * from publications_add where pmid = 120906;
select * from publications_include where pmid = 120906;

select distinct pmid from publications_add where pmid not in (select pmid from disambiguation_pubmed);

select distinct pmid from publications_add where pmid not in (select pmid from publications_include where pmid is not null);

select distinct pmid from publications_add where pmid not in (select pmid from pm_pubs_general);

select * from pm_pubs_general where pmid not in (select pmid from disambiguation_pubmed);

select * from pm_pubs_general;


select * from publications_add e, publications_include i where e.pubid = i.pubid;

select pubid, pmid, personid, str(pmid) + '_' + str(personid) from publications_add where
select str(pmid) + '_' + str(personid) from publications_include



