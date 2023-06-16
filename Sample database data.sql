/*signing up new customers*/
insert into Customer (Address,cname,Cpassword ,username)
values ('Haram-Giza', 'Mohamed','54521','amaterus');
insert into Customer (Address,cname,Cpassword ,username)
values ('Gizera-Giza', 'Omar','1112335','naruto');
insert into Customer (Address,cname,Cpassword ,username)
values ('Maadi-Cairo', 'Nour','154212521','hitler');
insert into Customer (Address,cname,Cpassword ,username)
values ('madinetnasr-Cairo', 'Ahmed','5233211sfa','reddragon');
insert into Customer (Address,cname,Cpassword ,username)
values ('Fesall-Giza', 'Ahmed','5452dsfa1','freezer');
insert into Customer (Address,cname,Cpassword ,username)
values ('moneeb-Giza', 'Mohamed','544454dsfa1','Goko');


/*update customer data*/
UPDATE Customer
SET Address = 'Embaba-Giza'
WHERE cId = 2;

UPDATE Customer
SET username = 'soonic'
WHERE cId = 3;


/*Remove customer*/
DELETE FROM Customer WHERE cId=1;


/*add new product*/
insert into Product (Price,Quantity,Restock_quantity,Category,Pname)
values (6,200,20,'food','tomato');
insert into Product (Price,Quantity,Restock_quantity,Category,Pname)
values (150,100,10,'clothes','t-shirt');
insert into Product (Price,Quantity,Restock_quantity,Category,Pname)
values (300,100,10,'clothes','pants');
insert into Product (Price,Quantity,Restock_quantity,Category,Pname)
values (100,200,10,'clothes','short');
insert into Product (Price,Quantity,Restock_quantity,Category,Pname)
values (10000,500,50,'appliance','iphone 12');

/*Remove product*/
DELETE FROM Product WHERE pid=3;

/*udate product details*/
UPDATE Product
SET Price = 20000
WHERE pid = 5;



/*insert into orders and Has table*/

insert into Orders (Cid,Month,Year)
values (2,3,2005);

insert into Orders (Cid,Month,Year)
values (2,4,2006);
insert into Orders (Cid,Month,Year)
values (3,1,2005);
insert into Orders (Cid,Month,Year)
values (4,12,2010);
insert into Orders (Cid,Month,Year)
values (6,4,2001);
insert into Orders (Cid,Month,Year)
values (5,3,2007);

insert into Orders (Cid,Month,Year)
values (4,4,2007);

insert into Has(pid,Orderid,Number)
values(2,2,5);

insert into Has(pid,Orderid,Number)
values(4,4,15);

insert into Has(pid,Orderid,Number)
values(3,2,15);

insert into Has(pid,Orderid,Number)
values(4,3,5);

insert into Has(pid,Orderid,Number)
values(2,4,5);

insert into Has(pid,Orderid,Number)
values(2,5,5);

insert into Has(pid,Orderid,Number)
values(2,6,5);

insert into Has(pid,Orderid,Number)
values(1,7,5);

insert into Has(pid,Orderid,Number)
values(5,7,2);



insert into Admins (Name,Apassword)
values ('admin','admin');


