-- CUT AND PASTE RESULTS FROM QUERY INTO THESE COMMENTS!

--
--<?xml version="1.0" encoding="UTF-8"?>
--<urlset
--      xmlns="http://www.sitemaps.org/schemas/sitemap/0.9"
--      xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance"
--      xsi:schemaLocation="http://www.sitemaps.org/schemas/sitemap/0.9
--            http://www.sitemaps.org/schemas/sitemap/0.9/sitemap.xsd">
--<url>
--  <loc>http://profiles.ucsf.edu/</loc>
--</url>
--<url>
--  <loc>http://profiles.ucsf.edu/SearchOptions.aspx</loc>
--</url>
--<url>
--  <loc>http://profiles.ucsf.edu/HowProfilesWorks.aspx</loc>
--</url>
--<url>
--  <loc>http://profiles.ucsf.edu/AboutUCSFProfiles.aspx</loc>
--</url>
--<url>
--  <loc>http://profiles.ucsf.edu/UCSF_Profiles_Introduction.pptx</loc>
--</url>
select 
'<url>
	<loc>http://profiles.ucsf.edu/ProfileDetails.aspx?Person='  
+ cast(personId as varchar) + 
	'</loc>
</url>' from person where IsActive = 1
--</urlset>