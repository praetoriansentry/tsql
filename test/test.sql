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
