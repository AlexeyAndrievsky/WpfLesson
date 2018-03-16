using System;
using System.Collections.ObjectModel;
using System.Linq;
using WpfLesson.DataAccess;

namespace WpfLesson.Model
{
    public class EntitiesModel : IEntitiesModel
    {
        public ObservableCollection<IEntity> Entities { get; set; }

        public event EventHandler<EntityEventArgs> EntityUpdated = delegate { };

        public void UpdateEntity(IEntity updatedEntity)
        {
            GetEntitiy(updatedEntity.ID).Update(updatedEntity);
            EntityUpdated(this, new EntityEventArgs(updatedEntity));
        }

        private IEntity GetEntitiy(int entityId)
        {
            return Entities.FirstOrDefault(e => e.ID == entityId);
        }
    }
}
