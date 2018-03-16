using System.Collections.ObjectModel;
using WpfLesson.DataAccess;

namespace WpfLesson.Model
{
    /// <summary>
    /// Класс, описывающий модель коллекции отделений.
    /// Дочерний класс класса <see cref="EntitiesModel"/>
    /// </summary>
    public class DepartmentsModel : EntitiesModel
    {
        #region .ctor
        /// <summary>
        /// Конструктор класса DepartmentsModel.
        /// </summary>
        /// <param name="dataService">Сервис обмена данными с БД.</param>
        public DepartmentsModel(IDataService dataService)
        {
            Entities = new ObservableCollection<IEntity>();
            foreach (Department dpt in dataService.GetDepartments())
            {
                Entities.Add(dpt);
            }
        }
        #endregion
    }
}
