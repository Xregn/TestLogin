/*4 вывести список сотрудников не имеющих назначенного руководител€ в том же отделе*/


select a.*
from emp a, emp d
where (d.id = a.chief_id and d.dep_id != a.dep_id) 
/* не находит с null*/
