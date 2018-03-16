using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfLesson.DataAccess;

namespace WpfLesson.Model
{
    public class EntityModel : IEntityModel
    {
        public IEntity Entity { get; set; }

        public event EventHandler<EntityEventArgs> EntityInserted = delegate { };

        public void InsertEntity(IEntity insertedEntity)
        {
            Entity.Insert(insertedEntity);
            EntityInserted(this, new EntityEventArgs(insertedEntity));
        }
    }
}
