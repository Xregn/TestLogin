/*2 вывести список сотрудников. получающих максимальную зп в своем отделе*/

select a.* 
from emp a
where a.salary = (select max(b.salary) from emp b where a.dep_id = b.dep_id)  