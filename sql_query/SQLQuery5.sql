/*5 найти список id отделов с максиальной суммарной зарплатой сотрудников*/

with tableSum as  
(select dep_id, SUM(salary) as sumsal from emp group by dep_id)
select *
from tableSum
where sumsal = (select max(sumsal) from tableSum)
