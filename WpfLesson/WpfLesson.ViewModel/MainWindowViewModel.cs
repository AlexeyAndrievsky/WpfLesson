using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows;
using System.Windows.Input;
using WpfLesson.DataAccess;
using WpfLesson.Model;
using System.Reflection;

namespace WpfLesson.ViewModel
{
    /// <summary>
    /// Класс, описывающий модель-представление главного окна.
    /// </summary>
    public class MainWindowViewModel : Notifier, INotifyPropertyChanged
    {
        #region Fields
        /// <summary>
        /// Ссылка на представление главного окна.
        /// </summary>
        private Window mainWindow;

        /// <summary>
        /// Команда на открытие окна Сотрудники.
        /// </summary>
        private readonly ICommand openEmployersViewCommand;

        /// <summary>
        /// Команда на открытие окна Отделения.
        /// </summary>
        private readonly ICommand openDepartmentsViewCommand;

        /// <summary>
        /// Команда на открытие окна Добавить отделение.
        /// </summary>
        private readonly ICommand openAddDepartmentViewCommand;

        /// <summary>
        /// Команда на открытие окна Добавить сотрудника.
        /// </summary>
        private readonly ICommand openAddEmployeeViewCommand;

        /// <summary>
        /// Словарь, содержащий набор представлений, которые можно открыть из главного окна.
        /// </summary>
        private IDictionary<string, IWindowView> windows;
        #endregion

        #region Properties
        /// <summary>
        /// Свойство для доступа к полю, содержащему команду на открытие окна Сотрудники.
        /// </summary>
        public ICommand OpenEmployersViewCommand
        {
            get { return openEmployersViewCommand; }
        }

        /// <summary>
        /// Свойство для доступа к полю, содержащему команду на открытие окна Отделения.
        /// </summary>
        public ICommand OpenDepartmentsViewCommand
        {
            get { return openDepartmentsViewCommand; }
        }

        /// <summary>
        /// Свойство для доступа к полю, содержащему команду на открытие окна Добавить отделение.
        /// </summary>
        public ICommand OpenAddDepartmentViewCommand
        {
            get { return openAddDepartmentViewCommand; }
        }

        /// <summary>
        /// Свойство для доступа к полю, содержащему команду на открытие окна Добавить сотрудника.
        /// </summary>
        public ICommand OpenAddEmployeeViewCommand
        {
            get { return openAddEmployeeViewCommand; }
        }
        #endregion

        #region .ctor
        /// <summary>
        /// Конструктор класса MainWindowViewModel.
        /// </summary>
        /// <param name="windows">Словарь, содержащий представления, которые открываются из главного окна.</param>
        /// <param name="mainWindow">Ссылка на представление.</param>
        public MainWindowViewModel(IDictionary<string, IWindowView> windows, Window mainWindow)
        {
            this.mainWindow = mainWindow;
            this.windows = windows;

            openEmployersViewCommand = new OpenViewCommand(this, ShowEmployers);
            openDepartmentsViewCommand = new OpenViewCommand(this, ShowDepartments);
            openAddDepartmentViewCommand = new OpenViewCommand(this, ShowAddDepartment);
            openAddEmployeeViewCommand = new OpenViewCommand(this, ShowAddEmployee);
        }
        #endregion

        #region Methods
        /// <summary>
        /// Метод, открывающий окно Сотрудники.
        /// </summary>
        private void ShowEmployers()
        {
            var v = windows["EmployersView"];
            if (v != null)
            {
                DataServiceStub ds = new DataServiceStub();
                Type t = v.GetType();
                ConstructorInfo ctor = t.GetConstructor(Type.EmptyTypes);
                object instance = ctor.Invoke(null);
                PropertyInfo fieldDataContext = t.GetProperty("DataContext");
                fieldDataContext.SetValue(instance, new EmployersViewModel(new EmployersModel(ds), new DepartmentsModel(ds)));
                PropertyInfo fieldOwner = t.GetProperty("Owner");
                fieldOwner.SetValue(instance, mainWindow);
                MethodInfo methodShow = t.GetMethod("Show");
                methodShow.Invoke(instance, null);
            }
        }

        /// <summary>
        /// Метод, открывающий окно Отделения.
        /// </summary>
        private void ShowDepartments()
        {
            var v = windows["DepartmentsView"];
            if (v != null)
            {
                DataServiceStub ds = new DataServiceStub();
                Type t = v.GetType();
                ConstructorInfo ctor = t.GetConstructor(Type.EmptyTypes);
                object instance = ctor.Invoke(null);
                PropertyInfo fieldDataContext = t.GetProperty("DataContext");
                fieldDataContext.SetValue(instance, new DepartmentsViewModel(new EmployersModel(ds), new DepartmentsModel(ds)));
                PropertyInfo fieldOwner = t.GetProperty("Owner");
                fieldOwner.SetValue(instance, mainWindow);
                MethodInfo methodShow = t.GetMethod("Show");
                methodShow.Invoke(instance, null);
            }
        }

        /// <summary>
        /// Метод, открывающий окно Добавить отделение.
        /// </summary>
        private void ShowAddDepartment()
        {
            var v = windows["AddDepartmentView"];
            if (v != null)
            {
                Type t = v.GetType();
                ConstructorInfo ctor = t.GetConstructor(Type.EmptyTypes);
                object instance = ctor.Invoke(null);
                PropertyInfo fieldDataContext = t.GetProperty("DataContext");
                fieldDataContext.SetValue(instance, new AddDepartmentViewModel(new DepartmentModel(new DataServiceStub())));
                PropertyInfo fieldOwner = t.GetProperty("Owner");
                fieldOwner.SetValue(instance, mainWindow);
                MethodInfo methodShow = t.GetMethod("Show");
                methodShow.Invoke(instance, null);
            }
        }

        /// <summary>
        /// Метод, открывающий окно Добавить сотрудника.
        /// </summary>
        private void ShowAddEmployee()
        {
            var v = windows["AddEmployeeView"];
            if (v != null)
            {
                DataServiceStub ds = new DataServiceStub();
                Type t = v.GetType();
                ConstructorInfo ctor = t.GetConstructor(Type.EmptyTypes);
                object instance = ctor.Invoke(null);
                PropertyInfo fieldDataContext = t.GetProperty("DataContext");
                fieldDataContext.SetValue(instance, new AddEmployeeViewModel(new EmployeeModel(ds), new DepartmentsModel(ds)));
                PropertyInfo fieldOwner = t.GetProperty("Owner");
                fieldOwner.SetValue(instance, mainWindow);
                MethodInfo methodShow = t.GetMethod("Show");
                methodShow.Invoke(instance, null);
            }
        }
        #endregion
    }
}
