using System.ComponentModel;

namespace WpfLesson.ViewModel
{
    /// <summary>
    /// Интерфейс, реализующий интерфейс <see cref="INotifyPropertyChanged"/>
    /// описывающий прототип модели-представления добавление нового экземпляра сущности.
    /// </summary>
    public interface IAddNewEntityViewModel : INotifyPropertyChanged
    {
        #region Methods
        /// <summary>
        /// Добавление нового экземпляра сущности.
        /// </summary>
        void InsertEntity();
        #endregion
    }
}
