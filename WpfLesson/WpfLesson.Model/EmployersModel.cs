using System.Collections.ObjectModel;
using WpfLesson.DataAccess;

namespace WpfLesson.Model
{
    public class EmployersModel : EntitiesModel
    {
        public EmployersModel(IDataService dataService)
        {
            Entities = new ObservableCollection<IEntity>();
            foreach (Employee emp in dataService.GetEmployers())
            {
                Entities.Add(emp);
            }
        }
    }
}
