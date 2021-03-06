﻿namespace WpfLesson.DataAccess
{
    /// <summary>
    /// Класс, реализующий сущность Отделение.
    /// Реализует интерфейс <see cref="IDepartment"/>
    /// </summary>
    public class Department : IDepartment
    {
        #region Fields
        /// <summary>
        /// ID отделения.
        /// </summary>
        public int ID { get; set; }

        /// <summary>
        /// Название отделения.
        /// </summary>
        public string DeptName { get; set; }

        /// <summary>
        /// Дополнительная информация об отделении.
        /// </summary>
        public string DeptInfo { get; set; }
        #endregion

        #region .ctor
        /// <summary>
        /// Конструктор класса Department.
        /// </summary>
        /// <param name="id_Department">ID отделения.</param>
        /// <param name="deptName">Название отделения.</param>
        /// <param name="deptInfo">Дополнительная информация об отделении.</param>
        public Department(int id_Department, string deptName, string deptInfo)
        {
            ID = id_Department;
            DeptName = deptName;
            DeptInfo = deptInfo;
        }
        #endregion

        #region Methods
        /// <summary>
        /// Обновление информации отделения.
        /// </summary>
        /// <param name="department">Отделение, информацию которого следует обновить.</param>
        public async void Update(IEntity department)
        {
            ID = department.ID;
            DeptName = (department as Department).DeptName;
            DeptInfo = (department as Department).DeptInfo;

            DataServiceStub ds = new DataServiceStub();
            await ds.UpdateDepartment(this);
        }

        /// <summary>
        /// Добавление нового отделения.
        /// </summary>
        /// <param name="department">Отделение, которое следует добавить.</param>
        public async void Insert(IEntity department)
        {
            ID = department.ID;
            DeptName = (department as Department).DeptName;
            DeptInfo = (department as Department).DeptInfo;

            DataServiceStub ds = new DataServiceStub();
            await ds.InsertDepartment(this);
        }

        /// <summary>
        /// Удаление отделения.
        /// </summary>
        /// <param name="department">Отделение, которое следует удалить.</param>
        public async void Delete(IEntity department)
        {
            ID = department.ID;

            DataServiceStub ds = new DataServiceStub();
            await ds.DeleteDepartment(this);
        }
        #endregion
    }
}
