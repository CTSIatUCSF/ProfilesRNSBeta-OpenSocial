select * from tmp_photo where photo is null;
delete from tmp_photo where photo is null;

select * from 

-- List all files in a directory - T-SQL parse string for date and filename 
-- Microsoft SQL Server command shell statement - xp_cmdshell
DECLARE  @PathName       VARCHAR(256) , 
         @CMD            VARCHAR(512) 
 
CREATE TABLE #CommandShell ( Line VARCHAR(512)) 
 
SET @PathName = 'C:\import\pictures\School_of_Nursing_photos_by_id /B' 
 
SET @CMD = 'DIR ' + @PathName + ' ' 
 
PRINT @CMD -- test & debug
-- DIR F:\data\download\microsoft /TC
 
-- MSSQL insert exec - insert table from stored procedure execution
INSERT INTO #CommandShell 
EXEC MASTER..xp_cmdshell   @CMD 

select * from #CommandShell

delete from #CommandShell where [Line] is null;

drop table  #CommandShell

DIR F:\data\download\microsoft /TC

EXEC xp_cmdshell 'dir C:\import\pictures\3-6-12 /B'

insert tmp_photo ([filename]) 
select 'C:\import\pictures\School_of_Nursing_photos_by_id\' + Line from #CommandShell where Line is not null

-- build queries
select [filename] from  tmp_photo where photo is null;
--
select 
'UPDATE tmp_photo
SET photo = 
(SELECT * FROM 
OPENROWSET(BULK N''' + [filename] +''', SINGLE_BLOB) AS x)
WHERE [filename] = ''' + [filename] + ''';' from tmp_photo where photo is null;

-- results cut and paste below

--UPDATE tmp_photo  SET photo =   (SELECT * FROM   OPENROWSET(BULK N'C:\import\pictures\School_of_Nursing_photos_by_id\20095428.jpg', SINGLE_BLOB) AS x)  WHERE [filename] = 'C:\import\pictures\School_of_Nursing_photos_by_id\20095428.jpg';
--UPDATE tmp_photo  SET photo =   (SELECT * FROM   OPENROWSET(BULK N'C:\import\pictures\School_of_Nursing_photos_by_id\20334363.jpg', SINGLE_BLOB) AS x)  WHERE [filename] = 'C:\import\pictures\School_of_Nursing_photos_by_id\20334363.jpg';

insert photo
select p.personid, 1, ph.photo, null from  cls.dbo.tmp_photo ph join cls.dbo.medcntr_disam d on d.id + '.jpg' = ph.filename 
join person p on 
p.internalusername = d.employee_id where ph.imported is null and p.personid  not in (select personid from photo);  --573
--422
select * from photo where personid in (
select p.personid from  cls.dbo.tmp_photo ph join cls.dbo.medcntr_disam d on d.id + '.jpg' = ph.filename 
join person p on 
p.internalusername = d.employee_id where ph.imported is null)

select * from  cls.dbo.tmp_photo where imported is null and [filename] not like 'C:%' and [filename] not like '02%'; --579

select * from photo where photousagetypeid != 1

select * from  cls.dbo.tmp_photo ph join person p on p.internalusername = left(ph.[filename], 9) where ph.imported is null;

select * from cls.dbo.tmp_photo ph where ph.[filename] like '%School_of_Nursing_photos_by_%' --103

insert photo
select p.personid, 1, ph.photo, null from  cls.dbo.tmp_photo ph join person p on 
 ph.[filename] like '%' + right(p.internalusername, 8)  + '%' where ph.[filename] like '%School_of_Nursing_photos_by_%' and
p.personid  not in (select personid from photo) ; --84
and p.personid not in (select personid from display_prefs where ShowPhoto = 'Y'); -- 84

select * from photo where personid in (
select p.personid from  cls.dbo.tmp_photo ph join person p on p.internalusername = left(ph.[filename], 9) where ph.imported is null) order by personid;

delete from photo where photoid = 880; --4965667

select * from display_prefs where personid in (
select p.personid from  cls.dbo.tmp_photo ph join person p 
on ph.[filename] like '%' + right(p.internalusername, 8)  + '%' where ph.[filename] like '%School_of_Nursing_photos_by_%') order by ShowPhoto;

update display_prefs set ShowPhoto = 'Y', PhotoPreference = 9 where personid in (
select p.personid from  cls.dbo.tmp_photo ph join person p on 
ph.[filename] like '%' + right(p.internalusername, 8)  + '%' where ph.[filename] like '%School_of_Nursing_photos_by_%')

(5555132

select d.* from display_prefs d join  person p on p.personid = d.personid join cls.dbo.tmp_photo ph on 
 ph.[filename] like '%' + right(p.internalusername, 8)  + '%' where ph.[filename] like '%School_of_Nursing_photos_by_%' and d.personid in 
(select personid from photo);


select * from photo where personid in (4965667, 5552696, 4729416);

select * from person where internalusername in 
('020593638', '020536678');