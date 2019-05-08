/*3 вывести список id отделов, количество сотрудников которых не превышает 3 человек*/

select a.dep_id
from emp a
where 3 > (select COUNT(dep_id) from emp b where a.dep_id = b.dep_id ) 
