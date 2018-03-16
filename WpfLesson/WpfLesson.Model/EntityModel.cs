using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfLesson.DataAccess;

namespace WpfLesson.Model
{
    /// <summary>
    /// Класс, реализующий интерфейс <see cref="IEntityModel"/>
    /// служащий для описания прототипа модели сущности.
    /// </summary>
    public class EntityModel : IEntityModel
    {
        #region Fields
        /// <summary>
        /// Экземпляр сущности.
        /// </summary>
        public IEntity Entity { get; set; }

        /// <summary>
        /// Событие, возникающее при добавлении нового экземпляра сущности.
        /// </summary>
        public event EventHandler<EntityEventArgs> EntityInserted = delegate { };
        #endregion

        #region Methods
        /// <summary>
        /// Метод добавления нового экземпляра сущности.
        /// </summary>
        /// <param name="insertEntity">Экземпляр сущности.</param>
        public void InsertEntity(IEntity insertedEntity)
        {
            Entity.Insert(insertedEntity);
            EntityInserted(this, new EntityEventArgs(insertedEntity));
        }
        #endregion
    }
}
