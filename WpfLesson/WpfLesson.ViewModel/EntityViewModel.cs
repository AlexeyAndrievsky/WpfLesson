using WpfLesson.DataAccess;
using WpfLesson.Model;

namespace WpfLesson.ViewModel
{
    /// <summary>
    /// Абстрактный класс, описывающий модель представление. 
    /// Дочерний класс класса <see cref="Notifier"/> для поддержки уведомлений об изменениях.
    /// Реализует интерфейс <see cref="IEntityViewModel"/>.
    /// </summary>
    public abstract class EntityViewModel : Notifier, IEntityViewModel
    {
        #region Fields
        /// <summary>
        /// Id экземпляра сущности.
        /// </summary>
        protected int id;
        #endregion

        #region Properties
        /// <summary>
        /// Свойство, реализующее доступ к полю id
        /// </summary>
        public int ID
        {
            get { return id; }
            set
            {
                id = value;
                NotifyPropertyChanged("Id");
            }
        }
        #endregion

        #region .ctor
        /// <summary>
        /// Конструктор класса EntityViewModel по умолчанию.
        /// </summary>
        public EntityViewModel()
        {
        }

        /// <summary>
        /// Конструктор класса EntityViewModel
        /// </summary>
        /// <param name="entity">Экземпляр сущности.</param>
        public EntityViewModel (IEntity entity)
        {
            if (entity == null)
                return;
            ID = entity.ID;
            Update(entity);
        }
        #endregion

        #region Methods
        /// <summary>
        /// Удаление экземпляра сущности.
        /// </summary>
        /// <param name="entity">Экземпляр на удаление.</param>
        public abstract void Delete(IEntity entity);

        /// <summary>
        /// Добавление нового экземпляра сущности.
        /// </summary>
        /// <param name="entity">Экземпляр для добавления.</param>
        public abstract void Insert(IEntity entity);

        /// <summary>
        /// Обновление экземпляра сущности.
        /// </summary>
        /// <param name="entity">Экземпляр для обновления.</param>
        public abstract void Update(IEntity entity);
        #endregion
    }
}
