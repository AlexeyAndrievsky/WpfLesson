using WpfLesson.DataAccess;

namespace WpfLesson.Model
{
    public class EmployeeModel : EntityModel
    {
        public EmployeeModel(IDataService dataService)
        {
            Entity = new Employee(-1, "", "", "", null, -1, null);
        }
    }
}
