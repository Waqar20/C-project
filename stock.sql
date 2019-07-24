
create table Stock(
item_id int unique identity(01,1),
item_name varchar(100),
item_price int ,
item_quantity bigint,
company_name varchar(100),
item_expire varchar(100)
)

insert into Stock values('cup',50 , 100,'abc','11,5,17')
select * from Stock item_name from Stock
update Stock 
set item_price=4, item_quantity=1 where item_name='saf'

select * from Stock where item_name like 'p%'
