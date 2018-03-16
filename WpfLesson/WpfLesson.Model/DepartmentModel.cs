using WpfLesson.DataAccess;

namespace WpfLesson.Model
{
    /// <summary>
    /// Класс, описывающий модель отделения.
    /// Дочерний класс класса <see cref="EntityModel"/>
    /// </summary>
    public class DepartmentModel : EntityModel
    {
        #region .ctor
        /// <summary>
        /// Конструктор класса DepartmentModel.
        /// </summary>
        /// <param name="dataService">Сервис обмена данными с БД.</param>
        public DepartmentModel(IDataService dataService)
        {
            Entity = new Department(-1, "", "");
        }
        #endregion
    }
}
