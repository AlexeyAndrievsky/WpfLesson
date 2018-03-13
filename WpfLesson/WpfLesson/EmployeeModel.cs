using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfLesson.DataAccess;

namespace WpfLesson
{
    class EmployeeModel : IEmployersModel
    {
        public ObservableCollection<Employee> Employers { get; set; }
        public event EventHandler<EmployeeEventArgs> EmployeeUpdated = delegate { };

        public EmployeeModel(IDataService dataService)
        {
            Employers = new ObservableCollection<Employee>();
            foreach (Employee emp in dataService.GetEmployers())
            {
                Employers.Add(emp);
            }
        }

        public void UpdateEmployee(IEmployee updatedEmployee)
        {
            GetProject(updatedEmployee.ID).Update(updatedEmployee);
            EmployeeUpdated(this, new EmployeeEventArgs(updatedEmployee));
        }

        private Employee GetProject(int id_Employer)
        {
            return Employers.FirstOrDefault(emp => emp.ID == id_Employer);
        }
    }
}
