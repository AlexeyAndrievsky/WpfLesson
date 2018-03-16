using System;
using WpfLesson.DataAccess;

namespace WpfLesson.Model
{
    /// <summary>
    /// Класс реализующий аргументы события изменения свойства.
    /// </summary>
    public class EntityEventArgs : EventArgs
    {
        #region Fields
        /// <summary>
        /// Сущность, чье свойство изменено.
        /// </summary>
        public IEntity Entity { get; set; }
        #endregion

        #region .ctor
        /// <summary>
        /// Конструктор класса EntityEventArgs
        /// </summary>
        /// <param name="entity">Сущность, чье свойство изменено.</param>
        public EntityEventArgs(IEntity entity)
        {
            Entity = entity;
        }
        #endregion
    }
}
