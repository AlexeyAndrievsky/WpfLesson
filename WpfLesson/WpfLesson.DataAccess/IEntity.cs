namespace WpfLesson.DataAccess
{
    /// <summary>
    /// Интерфейс, описывающий Сущность.
    /// </summary>
    public interface IEntity
    {
        #region Fields
        /// <summary>
        /// ID экземпляра сущности.
        /// </summary>
        int ID { get; set; }
        #endregion

        #region Methods
        /// <summary>
        /// Обновление данных экземпляра сущности.
        /// </summary>
        /// <param name="data">Данные для обновления.</param>
        void Update(IEntity data);

        /// <summary>
        /// Добавление нового экземпляра.
        /// </summary>
        /// <param name="data">Данные для добавления.</param>
        void Insert(IEntity data);

        /// <summary>
        /// Удаление экземпляра.
        /// </summary>
        /// <param name="data">Экземпляр для удаления.</param>
        void Delete(IEntity data);
        #endregion
    }
}
