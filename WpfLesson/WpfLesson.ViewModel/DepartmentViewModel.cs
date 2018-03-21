using WpfLesson.DataAccess;
using WpfLesson.Model;

namespace WpfLesson.ViewModel
{
    /// <summary>
    /// Класс, реализующий модель представление Отделение.
    /// Дочерний класс класса <see cref="EntityViewModel"/>
    /// Реализует интерфейс <see cref="IDepartment"/>
    /// </summary>
    public class DepartmentViewModel : EntityViewModel, IDepartment
    {
        #region Fields
        /// <summary>
        /// Название отделения.
        /// </summary>
        private string deptName;

        /// <summary>
        /// Дополнительная информация об отделении.
        /// </summary>
        private string deptInfo;
        #endregion

        #region Properties
        /// <summary>
        /// Свойство, реализующее доступ к полю, содержащему название отделения.
        /// </summary>
        public string DeptName
        {
            get { return deptName; }
            set
            {
                deptName = value;
                NotifyPropertyChanged("DeptName");
            }
        }

        /// <summary>
        /// Свойство, реализующее доступ к полю, содержащему дополнительную информацию об отделении.
        /// </summary>
        public string DeptInfo
        {
            get { return deptInfo; }
            set
            {
                deptInfo = value;
                NotifyPropertyChanged("DeptInfo");
            }
        }
        #endregion

        #region .ctor
        /// <summary>
        /// Конструктор класса DepartmentViewModel.
        /// </summary>
        /// <param name="department">Сущность Отделение</param>
        public DepartmentViewModel(IDepartment department)
        {
            if (department == null)
                return;
            ID = department.ID;
            Update(department);
        }
        #endregion

        #region Methods
        /// <summary>
        /// Обновление информации отделения.
        /// </summary>
        /// <param name="entity">Отделение, информацию которого следует обновить.</param>
        public override void Update(IEntity entity)
        {
            ID = entity.ID;
            DeptName = (entity as IDepartment).DeptName;
            DeptInfo = (entity as IDepartment).DeptInfo;
        }

        /// <summary>
        /// Добавление нового отделения.
        /// </summary>
        /// <param name="entity">Отделение, которое следует добавить.</param>
        public override void Insert(IEntity entity)
        {
            ID = entity.ID;
            DeptName = (entity as IDepartment).DeptName;
            DeptInfo = (entity as IDepartment).DeptInfo;
        }

        /// <summary>
        /// Удаление отделения.
        /// </summary>
        /// <param name="entity">Отделение, которое следует удалить.</param>
        public override void Delete(IEntity entity)
        {
            ID = entity.ID;
            DeptName = (entity as IDepartment).DeptName;
            DeptInfo = (entity as IDepartment).DeptInfo;
        }
        #endregion
    }
}
