﻿using System.Collections.Generic;

namespace WpfLesson.DataAccess
{
    /// <summary>
    /// Интерфейс, описывающий сервис для обмена данными с базой данных.
    /// </summary>
    public interface IDataService
    {
        #region Methods
        /// <summary>
        /// Получение списка сотрудников.
        /// </summary>
        /// <returns>Список сотрудников.</returns>
        IList<Employee> GetEmployers();

        /// <summary>
        /// Получение списка отделений.
        /// </summary>
        /// <returns>Список отделений.</returns>
        IList<Department> GetDepartments();

        /// <summary>
        /// Обновление данных сотрудника.
        /// </summary>
        /// <param name="employee">Сотрудник, данные которого требуется обновить.</param>
        void UpdateEmployee(Employee employee);

        /// <summary>
        /// Обновление данных отделения.
        /// </summary>
        /// <param name="department">отделение, данные которого требуется обновить.</param>
        void UpdateDepartment(Department department);

        /// <summary>
        /// Добавление нового сотрудника в БД.
        /// </summary>
        /// <param name="employee">Сотрудник, которого следует добавить.</param>
        void InsertEmployee(Employee employee);

        /// <summary>
        /// Добавление нового отделения в БД.
        /// </summary>
        /// <param name="department">Отделение, которое следует добавить в БД.</param>
        void InsertDepartment(Department department);

        /// <summary>
        /// Удаление сотрудника из БД.
        /// </summary>
        /// <param name="employee">Сотрудник, которого требуется удалить.</param>
        void DeleteEmployee(Employee employee);

        /// <summary>
        /// Удаление отделения из БД.
        /// </summary>
        /// <param name="department">Отделение, которое следует удалить из БД.</param>
        void DeleteDepartment(Department department);
        #endregion
    }
}
