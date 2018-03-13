using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfLesson.DataAccess
{
    public class DataServiceStub : IDataService
    {
        public IList<Employee> GetEmployers()
        {
            WpfLessonDataContextDataContext db = new WpfLessonDataContextDataContext();
            List<Employee> employers = db.DbEmployers.Select<DbEmployer, Employee>(x => x).ToList();
            return employers;
        }

        public void UpdateEmployee(Employee employee)
        {
            WpfLessonDataContextDataContext db = new WpfLessonDataContextDataContext();
            var emp = db.DbEmployers.FirstOrDefault(e => e.Id_Employee == employee.ID);
            emp.EmpSurname = employee.Surname;
            emp.EmpName = employee.Name;
            emp.EmpSecondName = employee.SecondName;
            if (employee.Birthday.HasValue)
                emp.Birthday = employee.Birthday.Value.Date;
            emp.Id_Department = employee.Id_Department;
            if (employee.Salary.HasValue)
                emp.Salary = employee.Salary;
            db.SubmitChanges();
        }
    }
}
