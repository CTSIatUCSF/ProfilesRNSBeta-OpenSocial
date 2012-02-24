
-- find missing VIP's
select * from vip_include_rs where employee_id  in 
(select internalusername from profiles_100810_prod.dbo.person where visible != 1)  

select * from vip_include_rs where employee_id  not in 
(select internalusername from profiles_100810_prod.dbo.person where visible = 1)  

select * from profiles_100810_prod.dbo.person where lastname = 'bryant'

-- make the change
update p set p.isactive = 1, p.visible = 1 from profiles_100810_prod.dbo.person p join vip_include_rs
v on p.internalusername = v.employee_id where v.employee_id  in 
(select internalusername from profiles_100810_prod.dbo.person where visible != 1)  


select v.* from profiles_100810_prod.dbo.person p join vip_include_rs
v on p.internalusername = v.employee_id where v.employee_id  in 
(select internalusername from profiles_100810_prod.dbo.person where visible != 1)  