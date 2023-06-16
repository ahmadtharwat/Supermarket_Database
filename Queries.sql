
/**a**/
select top 1 Product.Pname
from product,Customer,Has,Orders
where Has.Orderid=Orders.Orderid AND Has.pid=Product.pid AND Orders.cId=Customer.cId
group by Product.Pname
order by COUNT(Customer.cId) desc

/**b**/
select Product.Pname,Product.pid
from product
where Product.pid in (select Product.pid
			   from product
			   except
			   (select Has.pid
			   from Has,Orders
			   where Orders.Orderid=Has.Orderid AND Month= 4 And Orders.Year=2007))

/**c**/
select distinct Customer.cname
from Customer,Orders
where Customer.cId not in(select cid from Orders where Year >=(select max(Orders.Year)-1
			  from Orders))
/*******d*******************/

select c.cId,c.cname,Total
from Customer c, (select cId,Total
						 from Orders o join(
									select  Top 1 OrderId,Sum(h.Number*p.Price)as Total
									from Has h Join Product p
									on h.pid=p.pid
									where h.Orderid in( Select Orderid from Orders Where Month=(select max(Orders.Month)from Orders)
									 and Year = (select max(Orders.Year)from Orders))
									Group by OrderId
									order by Total Desc) as p
						 on o.Orderid=p.Orderid) o
where c.cId=o.cId
/**e*/
select Top 2 p.Category,Sum(h.Number)as Total
from Has h,Product p
where h.pid=p.pid and( p.Category='food' or p.Category='appliance') 
Group by p.Category
order by Total Desc



/** f**/
select p.*,total
from Product p LEFT JOIN (select h.pid,count(DISTINCT  o.cid)as total
	from Has h,Orders o
	where h.Orderid=o.Orderid
	group by h.pid) o
on p.pid=o.pid
	


