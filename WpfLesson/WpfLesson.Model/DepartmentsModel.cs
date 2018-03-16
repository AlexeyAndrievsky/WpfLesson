using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfLesson.DataAccess;

namespace WpfLesson.Model
{
    public class DepartmentsModel : EntitiesModel
    {
        public DepartmentsModel(IDataService dataService)
        {
            Entities = new ObservableCollection<IEntity>();
            foreach (Department dpt in dataService.GetDepartments())
            {
                Entities.Add(dpt);
            }
        }
    }
}
