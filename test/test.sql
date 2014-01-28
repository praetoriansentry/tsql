-- test a very simple statement

select 1, 2.0, '3 ', 444  , col_name from [tname] t with (nolock)
where t.foo = 'bar'

-- try something nested
select 1, 2.0, '3 ', 444  , col_name from [tname] t with (nolock)
join (
select id from [tname2] with (nolock)
) x
on x.id = t.col_name
where t.foo = 'bar'

-- testing declarations out
DECLARE
@startDate datetime, @endDate datetime

set @startDate = '2014-01-27'

set @endDate = @startDate + 7


select
col_name,
other_col_name

from
tname with (nolock)

where
datetime_created > @startDate
and datetime_created < @endDate


-- test out some join logic

select * from tname t with (nolock)
join tname2 t2 with (nolock)
on t2.id = t.id
left join tname3 t3 with (nolock)
on t3.id = t.id
right join tname4 t4 with (nolock)
on t4.id = t.id
left outer join tname5 t5 with (nolock)
on t5.id = t.id
right outer join tname6 t6 with (nolock)
on t6.id = t.id
full join tname7 t7 with (nolock)
on t7.id = t.id
cross join tname8 t8 with (nolock)
on t8.id = t.id

-- Testing some functions

select count(1), cast(2), getdate() + getdate(), isnull(1)
from tname


-- Example from http://technet.microsoft.com/en-us/library/ms182717.aspx
DECLARE @compareprice money, @cost money
EXECUTE Production.uspGetList '%Bikes%', 700,
    @compareprice OUT,
    @cost OUTPUT
IF @cost <= @compareprice
BEGIN
    PRINT 'These products can be purchased for less than
    $'+RTRIM(CAST(@compareprice AS varchar(20)))+'.'
END
ELSE
    PRINT 'The prices for all products in this category exceed
    $'+ RTRIM(CAST(@compareprice AS varchar(20)))+'.'


-- Example from http://technet.microsoft.com/en-us/library/ms182587.aspx
USE AdventureWorks2012;
GO
DECLARE @AvgWeight decimal(8,2), @BikeCount int
IF
(SELECT COUNT(*) FROM Production.Product WHERE Name LIKE 'Touring-3000%' ) > 5
BEGIN
   SET @BikeCount =
        (SELECT COUNT(*)
         FROM Production.Product
         WHERE Name LIKE 'Touring-3000%');
   SET @AvgWeight =
        (SELECT AVG(Weight)
         FROM Production.Product
         WHERE Name LIKE 'Touring-3000%');
   PRINT 'There are ' + CAST(@BikeCount AS varchar(3)) + ' Touring-3000 bikes.'
   PRINT 'The average weight of the top 5 Touring-3000 bikes is ' + CAST(@AvgWeight AS varchar(8)) + '.';
END
ELSE
BEGIN
SET @AvgWeight =
        (SELECT AVG(Weight)
         FROM Production.Product
         WHERE Name LIKE 'Touring-3000%' );
   PRINT 'Average weight of the Touring-3000 bikes is ' + CAST(@AvgWeight AS varchar(8)) + '.' ;
END ;
GO


-- Make sure is/not/null works fine
IF object_id('tempdb..#foo') IS NOT NULL
BEGIN
    DROP TABLE
        #foo
END
CREATE TABLE
    #foo
    (
        bucket    VARCHAR(50),
        sent      bigint,
        delivered bigint,
        failed    bigint,
        bounced   bigint
    )
