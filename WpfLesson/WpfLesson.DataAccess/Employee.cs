using System;

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

        public Employee(int id, string surname, string name, string secondName, DateTime? birthday, int id_Department, decimal? salary)
        {
            ID = id;
            Surname = surname;
            Name = name;
            SecondName = secondName;
            Birthday = birthday;
            Id_Department = id_Department;
            Salary = salary;
        }

        public void Update(IEntity employee)
        {
            ID = (employee as IEmployee).ID;
            Surname = (employee as IEmployee).Surname;
            Name = (employee as IEmployee).Name;
            SecondName = (employee as IEmployee).SecondName;
            Birthday = (employee as IEmployee).Birthday;
            Id_Department = (employee as IEmployee).Id_Department;
            Salary = (employee as IEmployee).Salary;

            DataServiceStub ds = new DataServiceStub();
            ds.UpdateEmployee(this);
        }

        public void Insert(IEntity employee)
        {
            ID = (employee as Employee).ID;
            Surname = (employee as Employee).Surname;
            Name = (employee as Employee).Name;
            SecondName = (employee as Employee).SecondName;
            Birthday = (employee as Employee).Birthday;
            Id_Department = (employee as Employee).Id_Department;
            Salary = (employee as Employee).Salary;

            DataServiceStub ds = new DataServiceStub();
            ds.InsertEmployee(this);
        }

        public void Delete(IEntity employee)
        {
            ID = (employee as Employee).ID;
            DataServiceStub ds = new DataServiceStub();
            ds.DeleteEmployee(this);
        }
        public static implicit operator Employee(DbEmployer emp)
        {
            return new Employee(emp.Id_Employee, emp.EmpSurname, emp.EmpName, emp.EmpSecondName, emp.Birthday, emp.Id_Department, emp.Salary);
        }
    }
}
