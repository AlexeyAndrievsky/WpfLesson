using System;
using System.Collections.Generic;
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
            FillDepartmentsList(dataService);
        }
        #endregion

        #region Methods
        /// <summary>
        /// Метод, заполняющий коллекцию отделений.
        /// </summary>
        /// <param name="dataService">Сервис обмена данными с БД.</param>
        private async void FillDepartmentsList(IDataService dataService)
        {
            var res = await dataService.GetDepartments();
            List<Department> depts = res;
            foreach (Department dpt in depts)
            {
                Entities.Add(dpt);
            }
        }
        #endregion
    }
}
