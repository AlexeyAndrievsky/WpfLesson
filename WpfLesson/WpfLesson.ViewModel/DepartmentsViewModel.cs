using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using WpfLesson.DataAccess;
using WpfLesson.Model;

namespace WpfLesson.ViewModel
{
    /// <summary>
    /// Класс, реализующий модель-представление отображения коллекции отделений.
    /// Дочерний класс класса <see cref="Notifier"/>
    /// Реализует интерфейс <see cref="IEntitiesViewModel"/>
    /// </summary>
    public class DepartmentsViewModel : Notifier, IEntitiesViewModel
    {
        #region Const
        /// <summary>
        /// Название выбранного объекта модели-представления. 
        /// </summary>
        public const string SELECTED_DEPARTMENT_PROPERRTY_NAME = "SelectedEntity";
        #endregion

        #region Fields
        /// <summary>
        /// Модель коллекции сотрудников.
        /// </summary>
        private readonly IEntitiesModel empModel;

        /// <summary>
        /// Модель коллекции отделений.
        /// </summary>
        private readonly IEntitiesModel deptsModel;

        /// <summary>
        /// Модель-представление выбранной в данный момент сущности.
        /// </summary>
        private DepartmentViewModel selectedEntity;

        /// <summary>
        /// Поле, определяющее доступность элементов управления.
        /// Если false то контролы неактивны.
        /// Если true то контролы активны.
        /// </summary>
        private bool detailsEnabled;

        /// <summary>
        /// Команда на обновление информации об отделении.
        /// </summary>
        private readonly ICommand updateCommand;
        #endregion

        #region Properties
        /// <summary>
        /// Коллекция отделений.
        /// </summary>
        public ObservableCollection<IEntity> Departments { get { return deptsModel.Entities; } }

        /// <summary>
        /// Коллекция сотрудников.
        /// </summary>
        //Коллекция сотрудников добавлена для дальнейшей реализации удаления отделения - для запрета удалять отделение, если в нем есть хоть один сотрудник
        public ObservableCollection<IEntity> Employers { get { return empModel.Entities; } }

        /// <summary>
        /// Свойство, реализующее доступ к модель-представлению выбранной в данный момент сущности.
        /// </summary>
        public int? SelectedValue
        {
            set
            {
                if (value == null)
                    return;
                Department department = GetDepartment((int)value);
                if (SelectedEntity == null)
                {
                    SelectedEntity = new DepartmentViewModel(department);
                }
                else
                {
                    SelectedEntity.Update(department);
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
                    selectedEntity = value as DepartmentViewModel;
                    DetailsEnabled = false;
                }
                else
                {
                    if (selectedEntity == null)
                    {
                        selectedEntity = new DepartmentViewModel(value as Department);
                    }
                    selectedEntity.Update(value);
                    DetailsEnabled = true;
                    NotifyPropertyChanged(SELECTED_DEPARTMENT_PROPERRTY_NAME);
                }
            }
        }

        /// <summary>
        /// Название выбранного объекта модели-представления. 
        /// </summary>
        public string SelectedPropertyName { get; } = SELECTED_DEPARTMENT_PROPERRTY_NAME;

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
        /// Конструктор класса DepartmentsViewModel.
        /// </summary>
        /// <param name="employeeModel">Модель коллекции сотрудников</param>
        /// <param name="departmentsModel">Модель коллекции отделений</param>
        public DepartmentsViewModel(IEntitiesModel employeeModel, IEntitiesModel departmentsModel)
        {
            empModel = employeeModel;
            deptsModel = departmentsModel;
            deptsModel.EntityUpdated += model_DepartmentUpdated;
            updateCommand = new UpdateCommand(this);
        }
        #endregion

        #region Public methods
        /// <summary>
        /// Метод, обновляющий детали представления.
        /// </summary>
        public void UpdateEntity()
        {
            deptsModel.UpdateEntity(new Department(SelectedEntity.ID, (SelectedEntity as DepartmentViewModel).DeptName, (SelectedEntity as DepartmentViewModel).DeptInfo));
        }
        #endregion

        #region Private methods
        /// <summary>
        /// Метод, обрабатывающий событие, возникающее при обновляющий детали представления.
        /// </summary>
        private void model_DepartmentUpdated(object sender, EntityEventArgs e)
        {
            GetDepartment(e.Entity.ID).Update(e.Entity);
            if (SelectedEntity != null && e.Entity.ID == SelectedEntity.ID)
            {
                SelectedEntity.Update(e.Entity);
            }
        }

        /// <summary>
        /// Метод, находящий нужное отделение в коллекции по его ID.
        /// </summary>
        /// <param name="id_Department">Id отделения</param>
        /// <returns>Найденное отделение</returns>
        private Department GetDepartment(int id_Department)
        {
            return Departments.FirstOrDefault(e => e.ID == id_Department) as Department;
        }
        #endregion
    }
}
