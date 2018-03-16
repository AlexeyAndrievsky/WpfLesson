using System.Collections.Generic;

namespace WpfLesson.DataAccess
{
    public interface IDataService
    {
        IList<Employee> GetEmployers();
        IList<Department> GetDepartments();
        void UpdateEmployee(Employee employee);
    }
}
