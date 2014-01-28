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
