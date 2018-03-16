using System.ComponentModel;

namespace WpfLesson.ViewModel
{
    /// <summary>
    /// Интерфейс, реализующий интерфейс <see cref="INotifyPropertyChanged"/>
    /// описывающий прототип модели-представления отображения коллекции сущностей.
    /// </summary>
    public interface IEntitiesViewModel : INotifyPropertyChanged
    {
        #region Fields
        /// <summary>
        /// Название выбранного объекта модели-представления. 
        /// </summary>
        string SelectedPropertyName { get; set; }

        /// <summary>
        /// Cсылка на выбранный объект модели-представления.
        /// </summary>
        IEntityViewModel SelectedEntity { get; set; }
        #endregion

        #region Methods
        /// <summary>
        /// Метод, обновляющий детали представления.
        /// </summary>
        void UpdateEntity();
        #endregion
    }
}
