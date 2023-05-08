create database goodsReceived
create table goods(
	ID varchar(10),
	nameG varchar(100),
	dateRe date,
	supplier varchar(50),
	quantity int,
	brand varchar(20),
	price varchar(50)
)

create table delivery(
	deliveryID varchar(10),
	deliveryDate date,
	agentID varchar(10),
	productID varchar(10),
	phoneNumber varchar(15),
	streetAddress varchar(100),
	city varchar(20),
	quantity int,
	status varchar(20),
	paymentMethods varchar(20),
	paymentStatus varchar(50),
	orderStatus varchar(30),
	price varchar(100)
)

create table brand(
	 ID varchar(10),
	 name varchar(100),
	 description varchar(100)
)
insert into goods values ('G01','Iphone 13 Promax' ,'2023/04/17','Company A',3000000,2, 'Apple')
insert into brand values ('G01','Apple', 'Yellow Gold')
select * from goods
insert into delivery values ('D01','2023/04/23','E01','G01','0703784971','19 Nguyen Huu Tho','Ho Chi Minh',10,'Not transfer','Momo','Not Complete','Not successful',2000000)
select * from delivery

alter table delivery
alter column paymentMethods varchar(30);

alter table delivery
alter column paymentStatus varchar(50);
 
 drop table delivery;
 drop table goods;
