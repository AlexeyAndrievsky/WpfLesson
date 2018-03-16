1. Необходимо создать базу данных WpfLessonData
2. Убедиться что в настройках проекта WpfLesson.DataAccess указанна корректная строка подключения к созданной базе данных
(WpfLesson.DataAccess -> Properties -> Settings -> WpfDataConnectionString)  
3. Для созданной базы данных необходимо по порядку выполнить скрипты из директории SqlScripts:
	dbo.1_CreateDepartments.sql
	dbo.2_CreateEmployers.sql
	dbo.3_FillData.sql


