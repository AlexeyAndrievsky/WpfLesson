using System.Collections.Generic;
using System.Linq;

namespace WpfLesson.DataAccess
{
    /// <summary>
    /// Класс, осуществляющий обмен данными с базой данных.
    /// Наследник интерфейса <see cref="IDataService"/>
    /// </summary>
    public class DataServiceStub : IDataService
    {
        #region Public methods
        /// <summary>
        /// Получение списка сотрудников.
        /// </summary>
        /// <returns>Список сотрудников.</returns>
        public IList<Employee> GetEmployers()
        {
            WpfLessonDBClassesDataContext db = new WpfLessonDBClassesDataContext();
            List<Employee> employers = db.DbEmployers.Select<DbEmployer, Employee>(x => x).ToList();
            return employers;
        }

        /// <summary>
        /// Получение списка отделений.
        /// </summary>
        /// <returns>Список отделений.</returns>
        public IList<Department> GetDepartments()
        {
            WpfLessonDBClassesDataContext db = new WpfLessonDBClassesDataContext();
            List<Department> department = db.DbDepartments.Select<DbDepartment, Department>(x => x).ToList();
            return department;
        }

        /// <summary>
        /// Обновление данных сотрудника.
        /// </summary>
        /// <param name="employee">Сотрудник, данные которого требуется обновить.</param>
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

        /// <summary>
        /// Добавление нового сотрудника в БД.
        /// </summary>
        /// <param name="employee">Сотрудник, которого следует добавить.</param>
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

        /// <summary>
        /// Удаление сотрудника из БД.
        /// </summary>
        /// <param name="employee">Сотрудник, которого требуется удалить.</param>
        public void DeleteEmployee(Employee employee)
        {
            WpfLessonDBClassesDataContext db = new WpfLessonDBClassesDataContext();
            var emp = db.DbEmployers.FirstOrDefault(e => e.Id_Employee == employee.ID);
            db.DbEmployers.DeleteOnSubmit(emp);
            db.SubmitChanges();
        }

        /// <summary>
        /// Обновление данных отделения.
        /// </summary>
        /// <param name="department">отделение, данные которого требуется обновить.</param>
        public void UpdateDepartment(Department department)
        {
            WpfLessonDBClassesDataContext db = new WpfLessonDBClassesDataContext();
            var dpt = db.DbDepartments.FirstOrDefault(e => e.Id_Department == department.ID);
            dpt.DeptName = department.DeptName;
            dpt.DeptInfo = department.DeptInfo;
            db.SubmitChanges();
        }

        /// <summary>
        /// Добавление нового отделения в БД.
        /// </summary>
        /// <param name="department">Отделение, которое следует добавить в БД.</param>
        public void InsertDepartment(Department department)
        {
            WpfLessonDBClassesDataContext db = new WpfLessonDBClassesDataContext();
            var dpt = new DbDepartment();
            dpt.DeptName = department.DeptName;
            dpt.DeptInfo = department.DeptInfo;
            db.DbDepartments.InsertOnSubmit(dpt);
            db.SubmitChanges();
        }

        /// <summary>
        /// Удаление отделения из БД.
        /// </summary>
        /// <param name="department">Отделение, которое следует удалить из БД.</param>
        public void DeleteDepartment(Department department)
        {
            WpfLessonDBClassesDataContext db = new WpfLessonDBClassesDataContext();
            var dpt = db.DbDepartments.FirstOrDefault(e => e.Id_Department == department.ID);
            db.DbDepartments.DeleteOnSubmit(dpt);
            db.SubmitChanges();
        }
        #endregion
    }
}
