using System;
using WpfLesson.DataAccess;

namespace WpfLesson.Model
{
    public class EntityEventArgs:EventArgs
    {
        public IEntity Entity { get; set; }
        public EntityEventArgs(IEntity entity)
        {
            Entity = entity;
        }
    }
}
