/*4 ������� ������ ����������� �� ������� ������������ ������������ � ��� �� ������*/


select a.*
from emp a, emp d
where (d.id = a.chief_id and d.dep_id != a.dep_id) 
/* �� ������� � null*/
