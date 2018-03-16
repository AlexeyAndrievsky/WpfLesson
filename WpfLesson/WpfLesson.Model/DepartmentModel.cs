using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfLesson.DataAccess;

namespace WpfLesson.Model
{
    public class DepartmentModel : EntityModel
    {
        public DepartmentModel(IDataService dataService)
        {
            Entity = new Department(-1, "", "");
        }
    }
}
