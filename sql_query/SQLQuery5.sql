/*5 ����� ������ id ������� � ����������� ��������� ��������� �����������*/

with tableSum as  
(select dep_id, SUM(salary) as sumsal from emp group by dep_id)
select *
from tableSum
where sumsal = (select max(sumsal) from tableSum)
