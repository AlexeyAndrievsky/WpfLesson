using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfLesson.DataAccess
{
    public class Employee : IEmployee
    {
        public int ID { get; set; }
        public string Surname { get; set; }
        public string Name { get; set; }
        public string SecondName { get; set; }
        public DateTime? Birthday { get; set; }
        public int Id_Department { get; set; }
        public decimal? Salary { get; set; }

        public Employee (int id, string surname, string name, string secondName, DateTime? birthday, int id_Department, decimal? salary)
        {
            ID = id;
            Surname = surname;
            Name = name;
            SecondName = secondName;
            Birthday = birthday;
            Id_Department = id_Department;
            Salary = salary;
        }

        public void Update(IEmployee employee)
        {
            ID = employee.ID;
            Surname = employee.Surname;
            Name = employee.Name;
            SecondName = employee.SecondName;
            Birthday = employee.Birthday;
            Id_Department = employee.Id_Department;
            Salary = employee.Salary;

            DataServiceStub ds = new DataServiceStub();
            ds.UpdateEmployee(this);
        }

        public static implicit operator Employee(DbEmployer emp)
        {
            return new Employee(emp.Id_Employee, emp.EmpSurname, emp.EmpName, emp.EmpSecondName, emp.Birthday, emp.Id_Department, emp.Salary);
        }
    }
}
