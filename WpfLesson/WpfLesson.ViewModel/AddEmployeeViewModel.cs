using System;
using System.Collections.ObjectModel;
using System.Windows.Input;
using WpfLesson.DataAccess;
using WpfLesson.Model;

namespace WpfLesson.ViewModel
{
    /// <summary>
    /// Класс, реализующий модель-представление для добавлении нового сотрудника.
    /// Дочерний класс класса <see cref="Notifier"/>
    /// Реализует интерфейс <see cref="IAddNewEntityViewModel"/>
    /// </summary>
    public class AddEmployeeViewModel : Notifier, IAddNewEntityViewModel
    {
        #region Fields
        /// <summary>
        /// Поле, хранящее модель Сотрудник.
        /// </summary>
        private readonly IEntityModel empModel;

        /// <summary>
        /// Команда на добавление сотрудника.
        /// </summary>
        private readonly ICommand insertCommand;

        /// <summary>
        /// Модель коллекции отделений.
        /// </summary>
        private readonly IEntitiesModel deptsmodel;

        /// <summary>
        /// Делегат, служащий для закрытия текущего окна.
        /// </summary>
        public Action CloseAction;
        #endregion

        #region Properties
        /// <summary>
        /// Сущность "Сотрудник" для последующего добавления, поля которой должны быть заполнены.
        /// </summary>
        public IEntity Employee { get { return empModel.Entity; } }

        /// <summary>
        /// Коллекция отделений.
        /// </summary>
        public ObservableCollection<IEntity> Departments { get { return deptsmodel.Entities; } }

        /// <summary>
        /// Свойство для доступа к полю, содержащему команду на добавление сотрудника.
        /// </summary>
        public ICommand InsertCommand
        {
            get { return insertCommand; }
        }
        #endregion

        #region .ctor
        /// <summary>
        /// Конструктор класса AddEmployeeViewModel.
        /// </summary>
        /// <param name="departmentModel">Модель Отделение</param>
        /// <param name="departmentsModel">Модель коллекции отделений</param>
        public AddEmployeeViewModel(IEntityModel employeeModel, IEntitiesModel departmentsModel)
        {
            empModel = employeeModel;
            deptsmodel = departmentsModel;
            insertCommand = new InsertCommand(this);
        }
        #endregion

        #region Methods
        /// <summary>
        /// Метод добавления нового сотрудника.
        /// </summary>
        public void InsertEntity()
        {
            if ((Employee as IEmployee).Surname != string.Empty && (Employee as IEmployee).Name != string.Empty && (Employee as IEmployee).SecondName != string.Empty && (Employee as IEmployee).Birthday.HasValue && (Employee as IEmployee).Id_Department != -1 && (Employee as IEmployee).Salary.HasValue)
            {
                empModel.InsertEntity(Employee);
                CloseAction();
            }
        }
        #endregion
    }
}
