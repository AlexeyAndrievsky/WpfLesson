using System;
using WpfLesson.DataAccess;

namespace WpfLesson.Model
{
    /// <summary>
    /// Интерфейс, описывающий прототип модели сущности.
    /// </summary>
    public interface IEntityModel
    {
        #region Fields
        /// <summary>
        /// Экземпляр сущности.
        /// </summary>
        IEntity Entity { get; set; }

        /// <summary>
        /// Событие, возникающее при добавлении нового экземпляра сущности.
        /// </summary>
        event EventHandler<EntityEventArgs> EntityInserted;
        #endregion

        #region Methods
        /// <summary>
        /// Метод добавления нового экземпляра сущности.
        /// </summary>
        /// <param name="insertEntity">Экземпляр сущности.</param>
        void InsertEntity(IEntity insertEntity);
        #endregion
    }
}
