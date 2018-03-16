using System;
using System.Collections.ObjectModel;
using System.Linq;
using WpfLesson.DataAccess;

namespace WpfLesson.Model
{
    /// <summary>
    /// Класс, реализующий интерфейс <see cref="IEntitiesModel"/>
    /// служащий для описания прототипа модели коллекции сущностей.
    /// </summary>
    public class EntitiesModel : IEntitiesModel
    {
        #region Fields
        /// <summary>
        /// Коллекция экземпляров сущностей.
        /// </summary>
        public ObservableCollection<IEntity> Entities { get; set; }

        /// <summary>
        /// Событие, возникающее при обновлении свойств экземпляра сущности.
        /// </summary>
        public event EventHandler<EntityEventArgs> EntityUpdated = delegate { };
        #endregion

        #region Methods
        /// <summary>
        /// Обновление данных экземпляра сущности.
        /// </summary>
        /// <param name="updatedEntity">Экземпляр сущности.</param>
        public void UpdateEntity(IEntity updatedEntity)
        {
            GetEntitiy(updatedEntity.ID).Update(updatedEntity);
            EntityUpdated(this, new EntityEventArgs(updatedEntity));
        }

        /// <summary>
        /// Нахождение экземпляра сущности в коллекции по его ID.
        /// </summary>
        /// <param name="entityId">ID экземпляра сущности.</param>
        /// <returns>Найденный экземпляр сущности.</returns>
        private IEntity GetEntitiy(int entityId)
        {
            return Entities.FirstOrDefault(e => e.ID == entityId);
        }
        #endregion
    }
}
