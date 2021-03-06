﻿using System;

namespace WpfLesson.DataAccess
{
    /// <summary>
    /// Класс, реализующий сущность Сотрудник.
    /// Реализует интерфейс <see cref="IEmployee"/>
    /// </summary>
    public class Employee : IEmployee
    {
        #region fields
        /// <summary>
        /// ID сотрудника.
        /// </summary>
        public int ID { get; set; }

        /// <summary>
        /// Фамилия.
        /// </summary>
        public string Surname { get; set; }

        /// <summary>
        /// Имя.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Отчество.
        /// </summary>
        public string SecondName { get; set; }

        /// <summary>
        /// Дата рождения.
        /// </summary>
        public DateTime? Birthday { get; set; }

        /// <summary>
        /// ID отделения.
        /// </summary>
        public int Id_Department { get; set; }

        /// <summary>
        /// Заработная плата.
        /// </summary>
        public decimal? Salary { get; set; }
        #endregion

        #region .ctor
        /// <summary>
        /// Конструктор класса Employee.
        /// </summary>
        /// <param name="id">ID сотрудника.</param>
        /// <param name="surname">Фамилия.</param>
        /// <param name="name">Имя.</param>
        /// <param name="secondName">Отчество.</param>
        /// <param name="birthday">Дата рождения.</param>
        /// <param name="id_Department">ID отделения.</param>
        /// <param name="salary">Заработная плата.</param>
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
        #endregion

        #region Methods
        /// <summary>
        ///Обновление данных сотрудника.
        /// </summary>
        /// <param name="employee">Сотрудник, данные которого следует обновить.</param>
        public async void Update(IEntity employee)
        {
            ID = employee.ID;
            Surname = (employee as IEmployee).Surname;
            Name = (employee as IEmployee).Name;
            SecondName = (employee as IEmployee).SecondName;
            Birthday = (employee as IEmployee).Birthday;
            Id_Department = (employee as IEmployee).Id_Department;
            Salary = (employee as IEmployee).Salary;

            DataServiceStub ds = new DataServiceStub();
            await ds.UpdateEmployee(this);
        }

        /// <summary>
        /// Добавление нового сотрудника.
        /// </summary>
        /// <param name="employee">Сотрудник, которого следует добавить.</param>
        public async void Insert(IEntity employee)
        {
            ID = employee.ID;
            Surname = (employee as Employee).Surname;
            Name = (employee as Employee).Name;
            SecondName = (employee as Employee).SecondName;
            Birthday = (employee as Employee).Birthday;
            Id_Department = (employee as Employee).Id_Department;
            Salary = (employee as Employee).Salary;

            DataServiceStub ds = new DataServiceStub();
            await ds.InsertEmployee(this);
        }

        /// <summary>
        /// Удаление сотрудника.
        /// </summary>
        /// <param name="employee">Сотрудник, которого следует удалить.</param>
        public async void Delete(IEntity employee)
        {
            ID = employee.ID;
            DataServiceStub ds = new DataServiceStub();
            await ds.DeleteEmployee(this);
        }
        #endregion
    }
}
