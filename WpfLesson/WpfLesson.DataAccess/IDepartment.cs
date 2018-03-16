namespace WpfLesson.DataAccess
{
    /// <summary>
    /// Интерфейс, описывающий сущность Отделение.
    /// Дочерний интерфейс интерфейса <see cref="IEntity"/>
    /// </summary>
    public interface IDepartment : IEntity
    {
        #region Properties
        /// <summary>
        /// Название отделения.
        /// </summary>
        string DeptName { get; set; }

        /// <summary>
        /// Дополнительная информация об отделении.
        /// </summary>
        string DeptInfo { get; set; }
        #endregion
    }
}
