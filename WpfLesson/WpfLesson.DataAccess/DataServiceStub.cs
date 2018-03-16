using System;
using System.Collections.Generic;
using System.Linq;

namespace WpfLesson.DataAccess
{
    public class DataServiceStub : IDataService
    {
        public IList<Employee> GetEmployers()
        {
            WpfLessonDBClassesDataContext db = new WpfLessonDBClassesDataContext();
            List<Employee> employers = db.DbEmployers.Select<DbEmployer, Employee>(x => x).ToList();
            return employers;
        }

        public IList<Department> GetDepartments()
        {
            WpfLessonDBClassesDataContext db = new WpfLessonDBClassesDataContext();
            List<Department> department = db.DbDepartments.Select<DbDepartment, Department>(x => x).ToList();
            return department;
        }

        public void UpdateEmployee(Employee employee)
        {
            WpfLessonDBClassesDataContext db = new WpfLessonDBClassesDataContext();
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

        public void InsertEmployee(Employee employee)
        {
            WpfLessonDBClassesDataContext db = new WpfLessonDBClassesDataContext();
            var emp = new DbEmployer();
            emp.EmpSurname = employee.Surname;
            emp.EmpName = employee.Name;
            emp.EmpSecondName = employee.SecondName;
            if (employee.Birthday.HasValue)
                emp.Birthday = employee.Birthday.Value.Date;
            emp.Id_Department = employee.Id_Department;
            if (employee.Salary.HasValue)
                emp.Salary = employee.Salary;
            db.DbEmployers.InsertOnSubmit(emp);
            db.SubmitChanges();
        }

        public void DeleteEmployee(Employee employee)
        {
            WpfLessonDBClassesDataContext db = new WpfLessonDBClassesDataContext();
            var emp = db.DbEmployers.FirstOrDefault(e => e.Id_Employee == employee.ID);
            db.DbEmployers.DeleteOnSubmit(emp);
            db.SubmitChanges();
        }

        public void UpdateDepartment(Department department)
        {
            WpfLessonDBClassesDataContext db = new WpfLessonDBClassesDataContext();
            var dpt = db.DbDepartments.FirstOrDefault(e => e.Id_Department == department.ID);
            dpt.DeptName = department.DeptName;
            dpt.DeptInfo = department.DeptInfo;
            db.SubmitChanges();
        }

        public void InsertDepartment(Department department)
        {
            WpfLessonDBClassesDataContext db = new WpfLessonDBClassesDataContext();
            var dpt = new DbDepartment();
            dpt.DeptName = department.DeptName;
            dpt.DeptInfo = department.DeptInfo;
            db.DbDepartments.InsertOnSubmit(dpt);
            db.SubmitChanges();
        }

        public void DeleteDepartment(Department department)
        {
            WpfLessonDBClassesDataContext db = new WpfLessonDBClassesDataContext();
            var dpt = db.DbDepartments.FirstOrDefault(e => e.Id_Department == department.ID);
            db.DbDepartments.DeleteOnSubmit(dpt);
            db.SubmitChanges();
        }
    }
}
