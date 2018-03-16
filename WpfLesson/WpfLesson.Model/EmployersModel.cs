using System.Collections.ObjectModel;
using WpfLesson.DataAccess;

namespace WpfLesson.Model
{
    /// <summary>
    /// Класс, описывающий модель коллекции сотрудников.
    /// Дочерний класс класса <see cref="EntitiesModel"/>
    /// </summary>
    public class EmployersModel : EntitiesModel
    {
        #region .ctor
        /// <summary>
        /// Конструктор класса EmployersModel.
        /// </summary>
        /// <param name="dataService">Сервис обмена данными с БД.</param>
        public EmployersModel(IDataService dataService)
        {
            Entities = new ObservableCollection<IEntity>();
            foreach (Employee emp in dataService.GetEmployers())
            {
                Entities.Add(emp);
            }
        }
        #endregion
    }
}
