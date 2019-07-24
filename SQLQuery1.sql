create database mart_system
use mart_system

create table log_in(
username varchar(50),
father varchar(50),
date_of_birth varchar(50),
gender varchar(50),
nic varchar(50),
addres varchar(100),
password varchar(50),
)

insert into log_in values('waqar','shoaib','1996.07.20','mail','42401','D block','12345')
select * from log_in
insert into log_in values('noman','khan')
select username, password from log_in where username='waqar' and password='khan'

update log_in set  father='" + price + "', date_of_birth='" + qun + "',addres='',password='' where username='" + comboBox1.SelectedItem + "'