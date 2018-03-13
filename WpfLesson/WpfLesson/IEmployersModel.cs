using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfLesson.DataAccess;

namespace WpfLesson
{
    interface IEmployersModel
    {
        ObservableCollection<Employee> Employers { get; set; }
        event EventHandler<EmployeeEventArgs> EmployeeUpdated;
        void UpdateEmployee(IEmployee updatedEmployee);
    }
}
