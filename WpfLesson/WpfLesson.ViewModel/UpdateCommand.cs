using System;
using System.ComponentModel;
using System.Windows.Input;

namespace WpfLesson.ViewModel
{
    /// <summary>
    /// Класс, реализующий интерфейс <see cref="ICommand"/>
    /// служащий для обработки нажатия на кнопку обновлении экземпляра сущности.
    /// </summary>
    internal class UpdateCommand : ICommand
    {
        #region Const
        /// <summary>
        /// Константа для определения состояния равенства значений.
        /// </summary>
        private const int ARE_EQUAL = 0;

        /// <summary>
        /// Константа для определения состояния "ничего не выбрано".
        /// </summary>
        private const int NONE_SELECTED = -1;
        #endregion

        #region Fields
        /// <summary>
        /// Ссылка на модель-представление.
        /// </summary>
        private IEntitiesViewModel vm;
        #endregion

        #region .ctor
        /// <summary>
        /// Конструктор класса UpdateCommand.
        /// </summary>
        /// <param name="viewModel">Ссылка на модель-представление.</param>
        public UpdateCommand(IEntitiesViewModel viewModel)
        {
            vm = viewModel;
            vm.PropertyChanged += vm_PropertyChanged;
        }
        #endregion

        #region Methods
        /// <summary>
        /// Обработчик события изменения значения свойства.
        /// </summary>
        private void vm_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (string.Compare(e.PropertyName, vm.SelectedPropertyName) == ARE_EQUAL)
            {
                CanExecuteChanged(this, new EventArgs());
            }
        }

        /// <summary>
        /// Метод для реализации интерфейса <see cref="ICommand"/>
        /// определяющий возможность выполнения команды UpdateCommand
        /// </summary>
        public bool CanExecute(object parameter)
        {
            if (vm.SelectedEntity == null)
                return false;
            return ((EntityViewModel)vm.SelectedEntity).ID > NONE_SELECTED;
        }

        /// <summary>
        /// Событие для реализации интерфейса <see cref="ICommand"/>.
        /// </summary>
        public event EventHandler CanExecuteChanged = delegate { };

        /// <summary>
        /// Метод для реализации интерфейса <see cref="ICommand"/>.
        /// Инициализация вызова метода UpdateEntity в модель-представлении.
        /// </summary>
        public void Execute(object parameter)
        {
            vm.UpdateEntity();
        }
        #endregion
    }
}
