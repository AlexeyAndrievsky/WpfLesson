using System.ComponentModel;

namespace WpfLesson.Model
{
    /// <summary>
    /// Класс, реализующий интерфейс <see cref="INotifyPropertyChanged"/>
    /// служащий для уведомления об изменениях.
    /// </summary>
    public class Notifier : INotifyPropertyChanged
    {
        #region Fields
        /// <summary>
        /// Событие, возникающее при изменении свойства объекта.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged = delegate { };
        #endregion

        #region Methods
        /// <summary>
        /// Метод, обрабатывающий событие изменения свойства объекта.
        /// </summary>
        /// <param name="propertyName">Название свойства.</param>
        protected void NotifyPropertyChanged(string propertyName)
        {
            PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }
}
