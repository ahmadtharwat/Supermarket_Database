/*==============================================================*/
/* DBMS name:      Microsoft SQL Server 2014                    */
/* Created on:     27/05/2022 05:00:38 ã                        */

create database s2;
if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('Has') and o.name = 'FK_HAS_HAS_PRODUCT')
alter table Has
   drop constraint FK_HAS_HAS_PRODUCT
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('Has') and o.name = 'FK_HAS_HAS2_ORDERS')
alter table Has
   drop constraint FK_HAS_HAS2_ORDERS
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('Orders') and o.name = 'FK_ORDERS_MAKE_CUSTOMER')
alter table Orders
   drop constraint FK_ORDERS_MAKE_CUSTOMER
go

if exists (select 1
            from  sysobjects
           where  id = object_id('Admins')
            and   type = 'U')
   drop table Admins
go

if exists (select 1
            from  sysobjects
           where  id = object_id('Customer')
            and   type = 'U')
   drop table Customer
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('Has')
            and   name  = 'Has_FK'
            and   indid > 0
            and   indid < 255)
   drop index Has.Has_FK
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('Has')
            and   name  = 'Has2_FK'
            and   indid > 0
            and   indid < 255)
   drop index Has.Has2_FK
go

if exists (select 1
            from  sysobjects
           where  id = object_id('Has')
            and   type = 'U')
   drop table Has
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('Orders')
            and   name  = 'Make_FK'
            and   indid > 0
            and   indid < 255)
   drop index Orders.Make_FK
go

if exists (select 1
            from  sysobjects
           where  id = object_id('Orders')
            and   type = 'U')
   drop table Orders
go

if exists (select 1
            from  sysobjects
           where  id = object_id('Product')
            and   type = 'U')
   drop table Product
go

/*==============================================================*/
/* Table: Admins                                                */
/*==============================================================*/
create table Admins (
   Id                   int        Identity(1,1)          not null,
   Name                 varchar(255)         not null,
   Apassword            varchar(255)         not null,
   constraint PK_ADMINS primary key (Id)
)
go

/*==============================================================*/
/* Table: Customer                                              */
/*==============================================================*/
create table Customer (
   cId                  int   Identity(1,1)               not null,
   Address              varchar(255)         not null,
   Discount_voucher     varchar(255)         null,
   cname                varchar(255)         not null,
   Cpassword            varchar(255)         not null,
   username             varchar(255)  Unique        not null,
   constraint PK_CUSTOMER primary key (cId)
)
go

/*==============================================================*/
/* Table: Has                                                   */
/*==============================================================*/
create table Has (
   pid                  int                 not null,
   Orderid              int                  not null,
   Number               int                  not null,
   constraint PK_HAS primary key (pid, Orderid)
)
go

/*==============================================================*/
/* Index: Has2_FK                                               */
/*==============================================================*/




create nonclustered index Has2_FK on Has (Orderid ASC)
go

/*==============================================================*/
/* Index: Has_FK                                                */
/*==============================================================*/




create nonclustered index Has_FK on Has (pid ASC)
go

/*==============================================================*/
/* Table: Orders                                                */
/*==============================================================*/
create table Orders (
   Orderid              int    Identity(1,1)              not null,
   cId                  int                  not null,
   Month                int                  not null,
   Year                 int                  not null,
   constraint PK_ORDERS primary key (Orderid)
)
go

/*==============================================================*/
/* Index: Make_FK                                               */
/*==============================================================*/




create nonclustered index Make_FK on Orders (cId ASC)
go

/*==============================================================*/
/* Table: Product                                               */
/*==============================================================*/
create table Product (
   pid                  int   Identity(1,1)               not null,
   Price                decimal              not null,
   Quantity             int                  not null,
   Restock_quantity     int                  not null,
   Category             varchar(255)         not null,
   Pname                varchar(255)         not null,
   constraint PK_PRODUCT primary key (pid)
)
go

alter table Has
   add constraint FK_HAS_HAS_PRODUCT foreign key (pid)
      references Product (pid)
go

alter table Has
   add constraint FK_HAS_HAS2_ORDERS foreign key (Orderid)
      references Orders (Orderid)
go

alter table Orders
   add constraint FK_ORDERS_MAKE_CUSTOMER foreign key (cId)
      references Customer (cId)
go

alter table Has
   add constraint validation_constraint check(Number>0)
go

alter table Product
   add constraint Negative_constraint check(price>0 and Quantity>0 and Restock_quantity>0)
go

alter table Orders
   add constraint Date_constraint check(Month>0 and Month<12 and Year>2000 and Year<9999)
go
