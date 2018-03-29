using System.Collections.Generic;
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
            FillEmployersList(dataService);
        }
        #endregion

        #region Methods
        /// <summary>
        /// Метод, заполняющий коллекцию сотрудников.
        /// </summary>
        /// <param name="dataService">Сервис обмена данными с БД.</param>
        private async void FillEmployersList(IDataService dataService)
        {
            var res = await dataService.GetEmployers();
            List<Employee> empls = res;
            foreach (Employee emp in empls)
            {
                Entities.Add(emp);
            }
        }
        #endregion
    }
}
