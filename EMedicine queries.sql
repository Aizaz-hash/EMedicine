create table users
(id int GENERATED ALWAYS AS IDENTITY primary key, 
firstName varchar(30) not null , lastName varchar(30) not null , 
password varchar(30) not null, email varchar (50) not null ,
phone numeric (11) not null , dob DATE NOT NULL , address varchar (100) ,
fund decimal (18,2)	, typeOfUser varchar(10) , status int , 
createdOn timestamp);

create table medicines 
(id int GENERATED ALWAYS AS IDENTITY primary key , name varchar(100) not null , 
manufacturer varchar(50) not null , unitPrice decimal (18,2) not null, 
 discount decimal (18,2) , quantity int , ExpiryDate Date , ImageURL varchar (250) , status int  );
 
 
create table cart
(id int GENERATED ALWAYS AS IDENTITY primary key , 
 unitPrice decimal (18,2) , discount decimal (18,2) , quantity int , totalPrice decimal (18,2));
 
 create table orders 
 (id int GENERATED ALWAYS AS IDENTITY primary key ,
 orderNo int not null , orderTotal decimal (18,2) , orderStatus varchar (100)  );
 
 create table orderItems 
 (id int GENERATED ALWAYS AS IDENTITY primary key ,
 unitPrice decimal (18,2) not null , discount decimal (18,2) , quantity int , totalPrice decimal(18,2));
 
 select * from users;
 select * from medicines;
 select* from cart ;
 select * from orders;
 select * from orderItems;
 
 
  