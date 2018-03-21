using System;
using WpfLesson.DataAccess;

namespace WpfLesson.ViewModel
{
    /// <summary>
    /// Класс, реализующий модель представление Сотрудник.
    /// Дочерний класс класса <see cref="EntityViewModel"/>
    /// Реализует интерфейс <see cref="IEmployee"/>
    /// </summary>
    public class EmployeeViewModel : EntityViewModel, IEmployee
    {
        #region Fields
        /// <summary>
        /// Фамилия.
        /// </summary>
        private string surname;

        /// <summary>
        /// Имя.
        /// </summary>
        private string name;

        /// <summary>
        /// Отчество.
        /// </summary>
        private string secondname;

        /// <summary>
        /// Дата рождения.
        /// </summary>
        private DateTime? birthday;

        /// <summary>
        /// ID отделения.
        /// </summary>
        private int id_Department;

        /// <summary>
        /// Заработная плата.
        /// </summary>
        private decimal? salary;
        #endregion

        #region Properties
        /// <summary>
        /// Свойство, реализующее доступ к полю, содержащему фамилию.
        /// </summary>
        public string Surname
        {
            get { return surname; }
            set
            {
                surname = value;
                NotifyPropertyChanged("Surname");
            }
        }

        /// <summary>
        /// Свойство, реализующее доступ к полю, содержащему имя.
        /// </summary>
        public string Name
        {
            get { return name; }
            set
            {
                name = value;
                NotifyPropertyChanged("Name");
            }
        }

        /// <summary>
        /// Свойство, реализующее доступ к полю, содержащему отчество.
        /// </summary>
        public string SecondName
        {
            get { return secondname; }
            set
            {
                secondname = value;
                NotifyPropertyChanged("SecondName");
            }
        }

        /// <summary>
        /// Свойство, реализующее доступ к полю, содержащему дату рождения.
        /// </summary>
        public DateTime? Birthday
        {
            get { return birthday; }
            set
            {
                birthday = value;
                NotifyPropertyChanged("Birthday");
            }
        }

        /// <summary>
        /// Свойство, реализующее доступ к полю, содержащему ID отделения.
        /// </summary>
        public int Id_Department
        {
            get { return id_Department; }
            set
            {
                id_Department = value;
                NotifyPropertyChanged("Id_Department");
            }
        }

        /// <summary>
        /// Свойство, реализующее доступ к полю, содержащему заработную плату.
        /// </summary>
        public decimal? Salary
        {
            get { return salary; }
            set
            {
                salary = value;
                NotifyPropertyChanged("Salary");
            }
        }
        #endregion

        #region .ctor
        /// <summary>
        /// Конструктор класса EmployeeViewModel.
        /// </summary>
        /// <param name="employee">Сущность Сотрудник</param>
        public EmployeeViewModel(IEmployee employee)
        {
            if (employee == null)
                return;
            ID = employee.ID;
            Update(employee);
        }
        #endregion

        #region Methods
        /// <summary>
        /// Обновление информации о сотруднике.
        /// </summary>
        /// <param name="entity">Сотрудник, информацию которого следует обновить.</param>
        public override void Update(IEntity entity)
        {
            ID = entity.ID;
            Surname = (entity as IEmployee).Surname;
            Name = (entity as IEmployee).Name;
            SecondName = (entity as IEmployee).SecondName;
            Birthday = (entity as IEmployee).Birthday;
            Id_Department = (entity as IEmployee).Id_Department;
            Salary = (entity as IEmployee).Salary;
        }

        /// <summary>
        /// Добавление нового сотрудника.
        /// </summary>
        /// <param name="entity">Сотрудник, которого следует добавить.</param>
        public override void Insert(IEntity entity)
        {
            ID = entity.ID;
            Surname = (entity as IEmployee).Surname;
            Name = (entity as IEmployee).Name;
            SecondName = (entity as IEmployee).SecondName;
            Birthday = (entity as IEmployee).Birthday;
            Id_Department = (entity as IEmployee).Id_Department;
            Salary = (entity as IEmployee).Salary;
        }

        /// <summary>
        /// Удаление сотрудника.
        /// </summary>
        /// <param name="entity">Сотрудник, которого следует удалить.</param>
        public override void Delete(IEntity entity)
        {
            ID = entity.ID;
            Surname = (entity as IEmployee).Surname;
            Name = (entity as IEmployee).Name;
            SecondName = (entity as IEmployee).SecondName;
            Birthday = (entity as IEmployee).Birthday;
            Id_Department = (entity as IEmployee).Id_Department;
            Salary = (entity as IEmployee).Salary;
        }
        #endregion
    }
}
