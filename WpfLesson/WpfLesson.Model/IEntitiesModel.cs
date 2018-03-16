using System;
using System.Collections.ObjectModel;
using WpfLesson.DataAccess;

namespace WpfLesson.Model
{
    public interface IEntitiesModel
    {
        ObservableCollection<IEntity> Entities { get; set; }
        event EventHandler<EntityEventArgs> EntityUpdated;
        void UpdateEntity(IEntity updatedEntity);
    }
}
