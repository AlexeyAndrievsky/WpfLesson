Добавлен Wep Api сервис.


В проекте WpfLesson.Services использован EntityFramework v6.1.3 
В проекте WpfLesson.DataAccess использован Microsoft.AspNet.WebApi.Client v5.2.4 


Для запуска проекта необходимо:

1. Cоздать базу данных WpfLessonData

2. Убедиться что в файле Web.Config проекта WpfLesson.Services указанна корректная строка подключения к созданной базе данных (обмен информацией с БД осуществляется при помощи EntityFramework). 

3. Для созданной базы данных необходимо по порядку выполнить скрипты из директории SqlScripts:
	dbo.1_CreateDepartments.sql
	dbo.2_CreateEmployers.sql
	dbo.3_FillData.sql

4. Проект WpfLesson.Services необходимо запустить отдельным экземпляром приложения VisualStudio чтобы захостить веб-сервис (WpfLesson.Services должен быть установлен как StartUp project).

5. В проекте WpfLesson.DataAccess в файле app.config (или в настройках проекта) в параметре ServiceUrl необходимо указать URL по которому можно получить доступ к сервису.

6. Не останавливая запущенный проект WpfLesson.Services, другим экземпляром приложения VisualStudio запустить проект WpfLesson (WpfLesson должен быть установлен как StartUp project).


