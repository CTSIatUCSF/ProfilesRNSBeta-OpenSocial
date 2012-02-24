--------------------------------------------------------------------------------------------------
--- This will put the correct information in the DB prior to loading HR data and publications
insert disambiguation_pm_affiliations select * from cls.dbo.disambiguation_pm_affiliations;
insert google_keys  select * from cls.dbo.google_keys;
insert google_map_preferences  select * from cls.dbo.google_map_preferences;

-- see what URL is set up now.  Update to point to correct RUL
select * from profiles_parameters;
update profiles_parameters set [Value] = 'http://dev-profiles.ucsf.edu/ucsf_100810/ProfileDetails.aspx?Person=' where ParameterName = 'ProfilesURL';
--------------------------------------------------------------------------------------------------

--------------------------------------------------------------------------------------------------
--- After running this script run the right parts of ProfilesSetUserPermissions.sql, which you can
--- find in the latest code drop
--------------------------------------------------------------------------------------------------

--------------------------------------------------------------------------------------------------
--- Load HR data by running the VERSION_AdhocImport of VERSION_ProfileFullNightly SQL Server Agent Job.  
--- You may need to create a new one based on the prior version.
--- Run Nightly, Weekly, Monthly, Yearly, Nightly jobs
--------------------------------------------------------------------------------------------------

--------------------------------------------------------------------------------------------------
--- Create default proxies
select * from proxies_default;

insert into proxies_default values(  newid(), NULL, NULL, 5419518,  'Y', 1, 1, 1, 1, 1, 1, 1, 1, 1, 1); -- Rachael
insert into proxies_default values(  newid(), NULL, NULL, 5138614,  'Y', 1, 1, 1, 1, 1, 1, 1, 1, 1, 1); -- Eric
insert into proxies_default values(  newid(), NULL, NULL, 5152811,  'Y', 1, 1, 1, 1, 1, 1, 1, 1, 1, 1); -- Kristine
insert into proxies_default values(  newid(), NULL, NULL, 4699897,  'Y', 1, 1, 1, 1, 1, 1, 1, 1, 1, 1); -- Cynthia
insert into proxies_default values(  newid(), NULL, NULL, 4621800,  'Y', 1, 1, 1, 1, 1, 1, 1, 1, 1, 1); -- Leslie
insert into proxies_default values(  newid(), NULL, NULL, 5559273,  'Y', 1, 1, 1, 1, 1, 1, 1, 1, 1, 1); -- Katja
insert into proxies_default values(  newid(), NULL, NULL, 4999751,  'Y', 1, 1, 1, 1, 1, 1, 1, 1, 1, 1); -- Mini
insert into proxies_default values(  newid(), NULL, NULL, 5529043,  'Y', 1, 1, 1, 1, 1, 1, 1, 1, 1, 1); -- Melanie
insert into proxies_default values(  newid(), NULL, NULL, 5058766,  'Y', 1, 1, 1, 1, 1, 1, 1, 1, 1, 1); -- Emelda
--------------------------------------------------------------------------------------------------
GO
/****** Object:  Table [dbo].[ucsf_person_activity]    Script Date: 09/23/2010 14:00:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ucsf_person_activity](
	[PersonID] [int] NOT NULL,
	[Activity] [nvarchar](255) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[Date] [datetime] NOT NULL
) ON [PRIMARY]

GO
/****** Object:  View [dbo].[vw_ucsf_person_activity]    Script Date: 09/23/2010 14:01:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE view [dbo].[vw_ucsf_person_activity] as select internalusername, displayname, activity, CONVERT(VARCHAR(10),[date],111) [day]
from person p join ucsf_person_activity a on p.personid = a.personid;

/**********************************************************************************************
----------------------- ADD THE FOLLOWING AS A STEP IN A NIGHTLY SCRIPT -----------------------
DECLARE @Date datetime;
SELECT @Date = getdate();

-- added photos
insert ucsf_person_activity select distinct personid, 'Added Photo', @Date
from photo where personid not in (select personid from ucsf_person_activity where activity = 'Added Photo');

-- added narratives
insert ucsf_person_activity select distinct personid, 'Added Narrative', @Date
from narratives where personid not in (select personid from ucsf_person_activity where activity = 'Added Narrative');

-- edited publications
insert ucsf_person_activity select distinct personid, 'Edited Publications', @Date
from [my_pubs_general] 
where personid not in (select personid from ucsf_person_activity where activity = 'Edited Publications')
union select distinct personid, 'Edited Publications', @Date from publications_add 
where personid not in (select personid from ucsf_person_activity where activity = 'Edited Publications')
union select distinct personid, 'Edited Publications', @Date
from publications_exclude
where personid not in (select personid from ucsf_person_activity where activity = 'Edited Publications');
**********************************************************************************************/