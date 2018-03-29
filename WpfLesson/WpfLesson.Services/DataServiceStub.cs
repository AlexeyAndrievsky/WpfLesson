using System.Collections.Generic;
using System.Linq;
using WpfLesson.Services.Models;

namespace WpfLesson.Services
{
    /// <summary>
    /// Класс, осуществляющий обмен данными с базой данных.
    /// </summary>
    public class DataServiceStub
    {
        #region Public methods
        #region Employers data
        /// <summary>
        /// Получение списка сотрудников.
        /// </summary>
        /// <returns>Список сотрудников.</returns>
        public IList<Employee> GetEmployers()
        {
            List<Employee> employers = new List<Employee>();
            WpfLessonDataEntities db = new WpfLessonDataEntities();
            foreach (Employers e in db.Employers)
            {
                employers.Add(new Employee(e.Id_Employee, e.EmpSurname, e.EmpName, e.EmpSecondName, e.Birthday.Value, e.Departments.Id_Department, e.Salary.Value));
            }
            return employers;
        }

        /// <summary>
        /// Обновление данных сотрудника.
        /// </summary>
        /// <param name="employee">Сотрудник, данные которого требуется обновить.</param>
        public void UpdateEmployee(Employee employee)
        {
            WpfLessonDataEntities db = new WpfLessonDataEntities();
            var emp = db.Employers.FirstOrDefault(e => e.Id_Employee == employee.ID);
            emp.EmpSurname = employee.Surname;
            emp.EmpName = employee.Name;
            emp.EmpSecondName = employee.SecondName;
            if (employee.Birthday.HasValue)
                emp.Birthday = employee.Birthday;
            emp.Departments = db.Departments.FirstOrDefault(d => d.Id_Department == employee.Id_Department);
            if (employee.Salary.HasValue)
                emp.Salary = employee.Salary;
            db.SaveChanges();
        }

        /// <summary>
        /// Добавление нового сотрудника в БД.
        /// </summary>
        /// <param name="employee">Сотрудник, которого следует добавить.</param>
        public void InsertEmployee(Employee employee)
        {
            WpfLessonDataEntities db = new WpfLessonDataEntities();
            var emp = new Employers();
            emp.EmpSurname = employee.Surname;
            emp.EmpName = employee.Name;
            emp.EmpSecondName = employee.SecondName;
            if (employee.Birthday.HasValue)
                emp.Birthday = employee.Birthday;
            emp.Departments = db.Departments.FirstOrDefault(d => d.Id_Department == employee.Id_Department);
            if (employee.Salary.HasValue)
                emp.Salary = employee.Salary;
            db.Employers.Add(emp);
            db.SaveChanges();
        }

        /// <summary>
        /// Удаление сотрудника из БД.
        /// </summary>
        /// <param name="id">ID удаляемого сотрудника.</param>
        public void DeleteEmployee(int id)
        {
            WpfLessonDataEntities db = new WpfLessonDataEntities();
            var emp = db.Employers.FirstOrDefault(e => e.Id_Employee == id);
            db.Employers.Remove(emp);
            db.SaveChanges();
        }
        #endregion

        #region Departments data
        /// <summary>
        /// Получение списка отделений.
        /// </summary>
        /// <returns>Список отделений.</returns>
        public IList<Department> GetDepartments()
        {
            List<Department> departments = new List<Department>();
            WpfLessonDataEntities db = new WpfLessonDataEntities();
            foreach (Departments d in db.Departments)
            {
                departments.Add(new Department(d.Id_Department, d.DeptName, d.DeptInfo));
            }
            return departments;
        }

        /// <summary>
        /// Обновление данных отделения.
        /// </summary>
        /// <param name="department">отделение, данные которого требуется обновить.</param>
        public void UpdateDepartment(Department department)
        {
            WpfLessonDataEntities db = new WpfLessonDataEntities();
            var dpt = db.Departments.FirstOrDefault(e => e.Id_Department == department.ID);
            dpt.DeptName = department.DeptName;
            dpt.DeptInfo = department.DeptInfo;
            db.SaveChanges();
        }

        /// <summary>
        /// Добавление нового отделения в БД.
        /// </summary>
        /// <param name="department">Отделение, которое следует добавить в БД.</param>
        public void InsertDepartment(Department department)
        {
            WpfLessonDataEntities db = new WpfLessonDataEntities();
            var dpt = new Departments();
            dpt.DeptName = department.DeptName;
            dpt.DeptInfo = department.DeptInfo;
            db.Departments.Add(dpt);
            db.SaveChanges();
        }

        /// <summary>
        /// Удаление отделения из БД.
        /// </summary>
        /// <param name="id">ID удаляемого отделения.</param>
        public void DeleteDepartment(int id)
        {
            WpfLessonDataEntities db = new WpfLessonDataEntities();
            var dpt = db.Departments.FirstOrDefault(e => e.Id_Department == id);
            db.Departments.Remove(dpt);
            db.SaveChanges();
        }
        #endregion
        #endregion
    }
}
