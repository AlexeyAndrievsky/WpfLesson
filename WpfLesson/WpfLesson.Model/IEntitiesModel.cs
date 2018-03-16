using System;
using System.Collections.ObjectModel;
using WpfLesson.DataAccess;

namespace WpfLesson.Model
{
    /// <summary>
    /// Интерфейс, описывающий прототип модели коллекции сущностей.
    /// </summary>
    public interface IEntitiesModel
    {
        #region Fields
        /// <summary>
        /// Коллекция экземпляров сущностей.
        /// </summary>
        ObservableCollection<IEntity> Entities { get; set; }

        /// <summary>
        /// Событие, возникающее при обновлении свойств экземпляра сущности.
        /// </summary>
        event EventHandler<EntityEventArgs> EntityUpdated;
        #endregion

        #region Methods
        /// <summary>
        /// Обновление данных экземпляра сущности.
        /// </summary>
        /// <param name="updatedEntity">Экземпляр сущности.</param>
        void UpdateEntity(IEntity updatedEntity);
        #endregion
    }
}
