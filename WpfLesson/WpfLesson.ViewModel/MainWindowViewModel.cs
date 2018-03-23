using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows;
using System.Windows.Input;
using WpfLesson.DataAccess;
using WpfLesson.Model;

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

        private IDictionary<string, Window> windows;
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
        public MainWindowViewModel(IDictionary<string, Window> windows, Window mainWindow)
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
            Window view = windows["EmployersView"];
            if (view != null)
            {
                EmployersModel employersModel = new EmployersModel(new DataServiceStub());
                DepartmentsModel departmentsModel = new DepartmentsModel(new DataServiceStub());
                view.DataContext = new EmployersViewModel(employersModel, departmentsModel);
                view.Owner = mainWindow;
                view.Show();
            }
        }

        /// <summary>
        /// Метод, открывающий окно Отделения.
        /// </summary>
        private void ShowDepartments()
        {
            Window view = windows["DepartmentsView"];
            if (view != null)
            {
                EmployersModel employersModel = new EmployersModel(new DataServiceStub());
                DepartmentsModel departmentsModel = new DepartmentsModel(new DataServiceStub());
                view.DataContext = new DepartmentsViewModel(employersModel, departmentsModel);
                view.Owner = mainWindow;
                view.Show();
            }
        }

        /// <summary>
        /// Метод, открывающий окно Добавить отделение.
        /// </summary>
        private void ShowAddDepartment()
        {
            Window view = windows["AddDepartmentView"];
            if (view != null)
            {
                DepartmentModel departmentModel = new DepartmentModel(new DataServiceStub());
                AddDepartmentViewModel vm = new AddDepartmentViewModel(departmentModel);
                view.DataContext = vm;
                vm.CloseAction = new Action(view.Hide);
                view.Owner = mainWindow;
                view.Show();
            }
        }

        /// <summary>
        /// Метод, открывающий окно Добавить сотрудника.
        /// </summary>
        private void ShowAddEmployee()
        {
            Window view = windows["AddEmployeeView"];
            if (view != null)
            {
                EmployeeModel employeeModel = new EmployeeModel(new DataServiceStub());
                DepartmentsModel departmentsModel = new DepartmentsModel(new DataServiceStub());
                AddEmployeeViewModel vm = new AddEmployeeViewModel(employeeModel, departmentsModel);
                view.DataContext = vm;
                vm.CloseAction = new Action(view.Hide);
                view.Owner = mainWindow;
                view.Show();
            }
        }
        #endregion
    }
}
