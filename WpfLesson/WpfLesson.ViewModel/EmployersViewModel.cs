using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using WpfLesson.DataAccess;
using WpfLesson.Model;

namespace WpfLesson.ViewModel
{
    /// <summary>
    /// Класс, реализующий модель-представление отображения коллекции сотрудников.
    /// Дочерний класс класса <see cref="Notifier"/>
    /// Реализует интерфейс <see cref="IEntitiesViewModel"/>
    /// </summary>
    public class EmployersViewModel : Notifier, IEntitiesViewModel
    {
        #region Const
        /// <summary>
        /// Название выбранного объекта модели-представления. 
        /// </summary>
        public const string SELECTED_EMPLOYEE_PROPERRTY_NAME = "SelectedEntity";
        #endregion

        #region Fields
        /// <summary>
        /// Модель коллекции сотрудников.
        /// </summary>
        private readonly IEntitiesModel model;

        /// <summary>
        /// Модель коллекции отделений.
        /// </summary>
        private readonly IEntitiesModel deptsmodel;

        /// <summary>
        /// Модель-представление выбранной в данный момент сущности.
        /// </summary>
        private EmployeeViewModel selectedEntity;

        /// <summary>
        /// Поле, определяющее доступность элементов управления.
        /// Если false то контролы неактивны.
        /// Если true то контролы активны.
        /// </summary>
        private bool detailsEnabled;

        /// <summary>
        /// Команда на обновление информации о сотруднике.
        /// </summary>
        private readonly ICommand updateCommand;
        #endregion

        #region Properties
        /// <summary>
        /// Коллекция отделений.
        /// </summary>
        public ObservableCollection<IEntity> Departments { get { return deptsmodel.Entities; } }

        /// <summary>
        /// Коллекция сотрудников.
        /// </summary>
        public ObservableCollection<IEntity> Employers { get { return model.Entities; } }

        /// <summary>
        /// Свойство, реализующее доступ к модель-представлению выбранной в данный момент сущности.
        /// </summary>
        public int? SelectedValue
        {
            set
            {
                if (value == null)
                    return;
                Employee employee = GetEmployee((int)value);
                if (SelectedEntity == null)
                {
                    SelectedEntity = new EmployeeViewModel(employee);
                }
                else
                {
                    SelectedEntity.Update(employee);
                }
            }
        }

        /// <summary>
        /// Свойство, реализующее доступ к полю, определяющее доступность элементов управления.
        /// Если false то контролы неактивны.
        /// Если true то контролы активны.
        /// </summary>
        public bool DetailsEnabled
        {
            get { return detailsEnabled; }
            set
            {
                detailsEnabled = value;
                NotifyPropertyChanged("DetailsEnabled");
            }
        }

        /// <summary>
        /// Свойство, реализующее доступ к модель-представлению выбранной в данный момент сущности.
        /// </summary>
        public IEntityViewModel SelectedEntity
        {
            get { return selectedEntity; }

            set
            {
                if (value == null)
                {
                    selectedEntity = value as EmployeeViewModel;
                    DetailsEnabled = false;
                }
                else
                {
                    if (selectedEntity == null)
                    {
                        selectedEntity = new EmployeeViewModel(value as Employee);
                    }
                    selectedEntity.Update(value);
                    DetailsEnabled = true;
                    NotifyPropertyChanged(SELECTED_EMPLOYEE_PROPERRTY_NAME);
                }
            }
        }

        /// <summary>
        /// Название выбранного объекта модели-представления. 
        /// </summary>
        public string SelectedPropertyName { get; } = SELECTED_EMPLOYEE_PROPERRTY_NAME;

        /// <summary>
        /// Свойство, реализующее доступ к полю, содержащему команду на обновление информации об отделении.
        /// </summary>
        public ICommand UpdateCommand
        {
            get { return updateCommand; }
        }
        #endregion

        #region .ctor
        /// <summary>
        /// Конструктор класса EmployersViewModel.
        /// </summary>
        /// <param name="employeeModel">Модель коллекции сотрудников</param>
        /// <param name="departmentsModel">Модель коллекции отделений</param>
        public EmployersViewModel(IEntitiesModel employeeModel, IEntitiesModel departmentsModel)
        {
            model = employeeModel;
            deptsmodel = departmentsModel;
            model.EntityUpdated += model_EmployeeUpdated;
            updateCommand = new UpdateCommand(this);
        }
        #endregion

        #region Public methods
        /// <summary>
        /// Метод, обновляющий детали представления.
        /// </summary>
        public void UpdateEntity()
        {
            model.UpdateEntity(SelectedEntity);
        }
        #endregion

        #region Private methods
        /// <summary>
        /// Метод, обрабатывающий событие, возникающее при обновляющий детали представления.
        /// </summary>
        private void model_EmployeeUpdated(object sender, EntityEventArgs e)
        {
            GetEmployee(e.Entity.ID).Update(e.Entity);
            if (SelectedEntity != null && e.Entity.ID == SelectedEntity.ID)
            {
                SelectedEntity.Update(e.Entity);
            }
        }

        /// <summary>
        /// Метод, находящий нужного сотрудника в коллекции по его ID.
        /// </summary>
        /// <param name="id_Employee">Id сотрудника</param>
        /// <returns>Найденный сотрудник</returns>
        private Employee GetEmployee(int id_Employee)
        {
            return Employers.FirstOrDefault(e => e.ID == id_Employee) as Employee;
        }
        #endregion
    }
}
