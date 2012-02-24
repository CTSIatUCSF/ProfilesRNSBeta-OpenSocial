--- Step 1.  Add raw email to opt_in_campaign
-- =CONCATENATE("insert opt_in_campaign ([Email Address]) values ('", A2, "');")

-- Step 2 test counts, see that most everyon has null on everythign
-- ingore Jasmine Nirody
select * from opt_in_campaign where INDIVIDUAL_ID is null;

-- Step 3, join in from vw_UCSFPRO1 and set optin date reason
update o set o.[First Name] = v.GIVEN_NAME, o.[Last Name] = v.SURNAME,
o.[Optin Date Reason] = 'opt in - Feb 14, 2012', 
o.INDIVIDUAL_ID = v.INDIVIDUAL_ID
from  opt_in_campaign o join vw_UCSFPRO1 v on
o.[email address] = v.e_mail_address where o.individual_id is null; 

-- step 4, find stragglers, report to Katja and Brian
select * from opt_in_campaign where [Last Name] is null;

-- step 5, find dupes and fix
select individual_id, count(*) from opt_in_campaign where [Optin Date Reason] = 'opt in - Feb 14, 2012' AND
 individual_id is not null
group by individual_id order by count(*) desc;

-- step 6, add to VIP 
insert vip_include_rs select [Last Name], [First Name], INDIVIDUAL_ID, getdate(), [Optin Date Reason] from opt_in_campaign
where [Optin Date Reason] = 'opt in - Feb 14, 2012' AND
INDIVIDUAL_ID is not null and INDIVIDUAL_ID not in (select Employee_ID from vip_include_rs) ;

-- find whose missing
select * from opt_in_campaign where individual_id is null;
select * from vw_UCSFPRO1 where surname in (select [last name] from opt_in_campaign where individual_id is null);
