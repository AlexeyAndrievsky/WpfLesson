using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfLesson.DataAccess;

namespace WpfLesson.Model
{
    public interface IEntityModel
    {
        IEntity Entity { get; set; }
        event EventHandler<EntityEventArgs> EntityInserted;
        void InsertEntity(IEntity insertEntity);
    }
}
