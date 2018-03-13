using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfLesson.DataAccess;

namespace WpfLesson
{
    class EmployersModel : IEmployersModel
    {
        public ObservableCollection<Employee> Employers { get; set; }
        public event EventHandler<EmployeeEventArgs> EmployeeUpdated = delegate { };

        public EmployersModel(IDataService dataService)
        {
            Employers = new ObservableCollection<Employee>();
            foreach (Employee emp in dataService.GetEmployers())
            {
                Employers.Add(emp);
            }
        }

        public void UpdateEmployee(IEmployee updatedEmployee)
        {
            GetEmployee(updatedEmployee.ID).Update(updatedEmployee);
            EmployeeUpdated(this, new EmployeeEventArgs(updatedEmployee));
        }

        private Employee GetEmployee(int id_Employee)
        {
            return Employers.FirstOrDefault(e => e.ID == id_Employee);
        }
    }
}
