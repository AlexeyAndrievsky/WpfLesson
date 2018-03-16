using WpfLesson.DataAccess;
using WpfLesson.Model;

namespace WpfLesson.ViewModel
{
    public abstract class EntityViewModel : Notifier, IEntityViewModel
    {
        protected int id;

        public int ID
        {
            get { return id; }
            set
            {
                id = value;
                NotifyPropertyChanged("Id");
            }
        }

        public EntityViewModel()
        {
        }

        public EntityViewModel (IEntity entity)
        {
            if (entity == null)
                return;
            ID = entity.ID;
            Update(entity);
        }

        public abstract void Delete(IEntity entity);

        public abstract void Insert(IEntity entity);

        public abstract void Update(IEntity entity);
    }
}
