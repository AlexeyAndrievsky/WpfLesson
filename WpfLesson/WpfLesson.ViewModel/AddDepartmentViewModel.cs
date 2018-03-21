using System;
using System.Windows.Input;
using WpfLesson.DataAccess;
using WpfLesson.Model;

namespace WpfLesson.ViewModel
{
    /// <summary>
    /// Класс, реализующий модель-представление для добавлении нового отделения.
    /// Дочерний класс класса <see cref="Notifier"/>
    /// Реализует интерфейс <see cref="IAddNewEntityViewModel"/>
    /// </summary>
    public class AddDepartmentViewModel : Notifier, IAddNewEntityViewModel
    {
        #region Fields
        /// <summary>
        /// Поле, хранящее модель Отделение.
        /// </summary>
        private readonly IEntityModel deptModel;

        /// <summary>
        /// Команда на добавление отделения.
        /// </summary>
        private readonly ICommand insertCommand;

        /// <summary>
        /// Делегат, служащий для закрытия текущего окна.
        /// </summary>
        public Action CloseAction;
        #endregion

        #region Properties
        /// <summary>
        /// Сущность "Отделение" для последующего добавления, поля которой должны быть заполнены.
        /// </summary>
        public IEntity Department { get { return deptModel.Entity; } }

        /// <summary>
        /// Свойство для доступа к полю, содержащему команду на добавление отделения.
        /// </summary>
        public ICommand InsertCommand
        {
            get { return insertCommand; }
        }
        #endregion

        #region .ctor
        /// <summary>
        /// Конструктор класса AddDepartmentViewModel.
        /// </summary>
        /// <param name="departmentModel">Модель Отделение</param>
        public AddDepartmentViewModel(IEntityModel departmentModel)
        {
            deptModel = departmentModel;
            insertCommand = new InsertCommand(this);
        }
        #endregion

        #region Methods
        /// <summary>
        /// Метод добавления нового отделения.
        /// </summary>
        public void InsertEntity()
        {
            if ((Department as IDepartment).DeptName != string.Empty && (Department as IDepartment).DeptInfo != string.Empty)
            {
                deptModel.InsertEntity(Department);
                CloseAction();
            }
        }
        #endregion
    }
}
