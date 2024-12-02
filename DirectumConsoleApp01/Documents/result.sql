--Задание 1. Вариант 2. 
select 
emp.Id, emp.SurName, emp.[Name], SUM(pd.Price * sl.Quantity) as SelVolume from 
Sellers emp
left join Sales sl ON (emp.Id = sl.IdSel)
left join Products pd ON (sl.IdProd = pd.Id)
where sl.[Date] between '2013-10-01' and '2013-10-07'
group by emp.Id, emp.SurName, emp.[Name]
order by emp.SurName asc, emp.[Name] asc

;with production as 
(
	--Продукция(не поступления?), поступившая за период с 07.09.2013 по 07.10.2013.
	select distinct IdProd from Arrivals where[Date] between '2013-09-07' and '2013-10-07'
), empSales as 
(
	select 
	emp.Id as [EmployeeId], pd.Id as [ProductionId], emp.SurName, emp.[Name], SUM(pd.Price * sl.Quantity) as SaleSum 
	from 
	Sellers emp
	left join Sales sl ON (emp.Id = sl.IdSel)
	left join Products pd ON (sl.IdProd = pd.Id)
	where sl.[Date] between '2013-10-01' and '2013-10-07'
	and sl.IdProd IN (select IdProd from production)
	group by emp.Id, pd.Id, emp.SurName, emp.[Name]
)
--Объем закупок по продукции
, productSum as
(
	select 
	pd.[Id] as [ProductionId],
	pd.[Name] as [ProductionName],
	SUM(pd.Price * sl.Quantity) as 'SaleSum'
	from
	Products pd 
	left join Sales sl ON (pd.Id = sl.IdProd)
	where (sl.[Date] between '2013-10-01' and '2013-10-07')
	and sl.IdProd IN (select IdProd from production)
	group by pd.[Id],pd.[Name]
)
select 
ps.ProductionId,
ps.ProductionName,
emp.[Surname],
emp.[Name],
(case when isnull(ps.SaleSum,0) = 0 then 0 else 100.0 * emp.SaleSum / ps.SaleSum  end) as ProdSalesPercent
from empSales emp
left join productSum ps ON (emp.ProductionId = ps.[ProductionId])
order by ps.ProductionName, emp.[Surname], emp.[Name]