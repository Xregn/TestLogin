/*1 вывести список сотрудников, получающих зп большую чем у руководиеля*/

select a.*
from emp a
where  salary>(select salary from emp where id = a.chief_id)