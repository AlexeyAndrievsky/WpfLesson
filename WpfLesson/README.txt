�������� Wep Api ������.


� ������� WpfLesson.Services ����������� EntityFramework v6.1.3 
� ������� WpfLesson.DataAccess ����������� Microsoft.AspNet.WebApi.Client v5.2.4 


��� ������� ������� ����������:

1. C������ ���� ������ WpfLessonData

2. ��������� ��� � ����� Web.Config ������� WpfLesson.Services �������� ���������� ������ ����������� � ��������� ���� ������ (����� ����������� � �� �������������� ��� ������ EntityFramework). 

3. ��� ��������� ���� ������ ���������� �� ������� ��������� ������� �� ���������� SqlScripts:
	dbo.1_CreateDepartments.sql
	dbo.2_CreateEmployers.sql
	dbo.3_FillData.sql

4. ������ WpfLesson.Services ���������� ��������� ��������� ����������� ���������� VisualStudio ����� ��������� ���-������ (WpfLesson.Services ������ ���� ���������� ��� StartUp project).

5. � ������� WpfLesson.DataAccess � ����� app.config (��� � ���������� �������) � ��������� ServiceUrl ���������� ������� URL �� �������� ����� �������� ������ � �������.

6. �� ������������ ���������� ������ WpfLesson.Services, ������ ����������� ���������� VisualStudio ��������� ������ WpfLesson (WpfLesson ������ ���� ���������� ��� StartUp project).


