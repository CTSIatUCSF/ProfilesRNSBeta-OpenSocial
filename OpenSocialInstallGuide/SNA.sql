select * from cache_person where betweenness <> 0;

select * from sna_distance;

select * from vw_sna_summary;

select * from department

select * from department_fullname

select * from vw_sna_summary where hassna = 1 order by closeness desc;

select * from sna_distance;

select * from sna_betweenness;

select * from cache_process_audit where processname like '%betweenness%';


-- person level
select institutionname, departmentname, facultyrank, displayname, title, reach1, reach2, closeness, betweenness from
cache_person where hassna = 1 order by closeness desc;

-- school level
select institutionname,  avg(reach1), avg(reach2), avg(closeness), avg(betweenness) from
vw_sna_summary where hassna = 1 group by institutionname  order by institutionname;

-- department level
select institutionname, departmentname, avg(reach1), avg(reach2), avg(closeness), avg(betweenness) from
vw_sna_summary where hassna = 1 group by institutionname, departmentname order by institutionname, departmentname;

-- by faculty type
select facultyrank, avg(reach1), avg(reach2), avg(closeness), avg(betweenness) from
vw_sna_summary where hassna = 1 group by facultyrank order by facultyrank;

-- cross department
select * from sna_distance where distance = 1;

select d1.departmentname, s.personid1, d2.departmentname, s.personid2, s.distance 
from sna_distance s 
join person_affiliations p1 on p1.personid = s.personid1 
join department_fullname df1 on df1.departmentfullnameid = p1.departmentfullnameid
join department d1 on d1.departmentid = df1.departmentid
join person_affiliations p2 on p2.personid = s.personid2
join department_fullname df2 on df2.departmentfullnameid = p2.departmentfullnameid
join department d2 on d2.departmentid = df2.departmentid
where s.distance = 1 and p1.isprimary = 1 and p2.isprimary = 1;

select d1.departmentname, d2.departmentname, sum(s.distance)
from sna_distance s 
join person_affiliations p1 on p1.personid = s.personid1 
join department_fullname df1 on df1.departmentfullnameid = p1.departmentfullnameid
join department d1 on d1.departmentid = df1.departmentid
join person_affiliations p2 on p2.personid = s.personid2
join department_fullname df2 on df2.departmentfullnameid = p2.departmentfullnameid
join department d2 on d2.departmentid = df2.departmentid
where s.distance = 1 and p1.isprimary = 1 and p2.isprimary = 1
group by d1.departmentname, d2.departmentname 
--order by sum(s.distance) desc;
order by  d1.departmentname, d2.departmentname ;


--- dept sizes
select d.departmentname, f.facultyrankfullname, count(*) from person p join person_affiliations a on p.personid = a.personid 
join department_fullname df on df.departmentfullnameid = a.departmentfullnameid 
join department d on df.departmentid = d.departmentid 
join faculty_rank f on a.facultyrankid = f.facultyrankid 
where a.isprimary = 1 and 
p.isactive = 1
group by departmentname, facultyrankfullname
order by departmentname, facultyrankfullname;


