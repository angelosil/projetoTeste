declare @pessoas table(
	id int,
	FirstName varchar(50),
	Lastname varchar(50),
	ReportsTo varchar(50),
	Position  varchar(50),
	age int
)

insert into @pessoas values 
	(1, 'Daniel', 'Smith', 'Bob Boss', 'Enginner', 25)
insert into @pessoas values 	
	(2, 'Mike', 'White', 'Bob Boss', 'Contractor', 22)
insert into @pessoas values 
	(3, 'Jenny', 'Richards', null, 'CEO', 45)
insert into @pessoas values 
	(4, 'Robert', 'Black', 'Daniel Smith', 'Sales', 22)

insert into @pessoas values 
	(5, 'Noah', 'Fritz', 'Jenny Richards', 'Assistant', 30)

insert into @pessoas values 
	(6, 'David', '5', 'Jenny Richards', 'Director', 32)

insert into @pessoas values 
	(7, 'Ashley', 'Wells', 'David s', 'Assistant', 25)

insert into @pessoas values 
	(8, 'Ashley', 'Johnson', null, 'Intern', 25)


select R.ReportsTo,  count(R.age) TotalMembros,  cast((sum(R.age) / count(R.age)) as int) mediaIdade from @pessoas R 
where R.ReportsTo in (select distinct R.ReportsTo from @pessoas R where R.ReportsTo is not null)
group by R.ReportsTo 
order by R.ReportsTo
