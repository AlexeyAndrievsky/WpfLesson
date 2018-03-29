using System;
using System.Runtime.Serialization;

namespace WpfLesson.Services.Models
{
    /// <summary>
    /// Класс, реализующий сущность Сотрудник.
    /// </summary>
    [DataContract]
    public class Employee
    {
        #region fields
        /// <summary>
        /// ID сотрудника.
        /// </summary>
        [DataMember]
        public int ID { get; set; }

        /// <summary>
        /// Фамилия.
        /// </summary>
        [DataMember]
        public string Surname { get; set; }

        /// <summary>
        /// Имя.
        /// </summary>
        [DataMember]
        public string Name { get; set; }

        /// <summary>
        /// Отчество.
        /// </summary>
        [DataMember]
        public string SecondName { get; set; }

        /// <summary>
        /// Дата рождения.
        /// </summary>
        [DataMember]
        public DateTime? Birthday { get; set; }

        /// <summary>
        /// ID отделения.
        /// </summary>
        [DataMember]
        public int Id_Department { get; set; }

        /// <summary>
        /// Заработная плата.
        /// </summary>
        [DataMember]
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
    }
}
