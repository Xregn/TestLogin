/*1 ������� ������ �����������, ���������� �� ������� ��� � �����������*/

select a.*
from emp a
where  salary>(select salary from emp where id = a.chief_id)