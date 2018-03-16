using WpfLesson.DataAccess;

namespace WpfLesson.Model
{
    /// <summary>
    /// Класс, описывающий модель сотрудника.
    /// Дочерний класс класса <see cref="EntityModel"/>
    /// </summary>
    public class EmployeeModel : EntityModel
    {
        #region .ctor
        /// <summary>
        /// Конструктор класса EmployeeModel.
        /// </summary>
        /// <param name="dataService">Сервис обмена данными с БД.</param>
        public EmployeeModel(IDataService dataService)
        {
            Entity = new Employee(-1, "", "", "", null, -1, null);
        }
        #endregion
    }
}
