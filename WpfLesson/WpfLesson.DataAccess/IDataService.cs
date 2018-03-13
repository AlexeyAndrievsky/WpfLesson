using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfLesson.DataAccess
{
    public interface IDataService
    {
        IList<Employee> GetEmployers();
        void UpdateEmployee(Employee employee);
    }
}
