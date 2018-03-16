using System;

namespace WpfLesson.DataAccess
{
    /// <summary>
    /// Интерфейс, описывающий сущность Сотрудник.
    /// Дочерний интерфейс интерфейса <see cref="IEntity"/>
    /// </summary>
    public interface IEmployee : IEntity
    {
        #region Fields
        /// <summary>
        /// Фамилия.
        /// </summary>
        string Surname { get; set; }

        /// <summary>
        /// Имя.
        /// </summary>
        string Name { get; set; }

        /// <summary>
        /// Отчество.
        /// </summary>
        string SecondName { get; set; }

        /// <summary>
        /// Дата рождения.
        /// </summary>
        DateTime? Birthday { get; set; }

        /// <summary>
        /// ID отделения.
        /// </summary>
        int Id_Department { get; set; }

        /// <summary>
        /// Заработная плата.
        /// </summary>
        decimal? Salary { get; set; }
        #endregion
    }
}
