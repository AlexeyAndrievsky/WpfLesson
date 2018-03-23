using System;
using System.Windows.Input;

namespace WpfLesson.ViewModel
{
    internal class OpenViewCommand : ICommand
    {
        #region Fields
        /// <summary>
        /// Ссылка на модель-представление.
        /// </summary>
        private MainWindowViewModel vm;

        /// <summary>
        /// Метод открытия дочернего окна.
        /// </summary>
        private Action openMethod;
        #endregion

        #region .ctor
        /// <summary>
        /// Конструктор класса InsertCommand.
        /// </summary>
        /// <param name="viewModel">Ссылка на модель-представление.</param>
        public OpenViewCommand(MainWindowViewModel viewModel, Action openMethod)
        {
            vm = viewModel;
            this.openMethod = openMethod;
        }
        #endregion

        #region Methods
        /// <summary>
        /// Метод для реализации интерфейса <see cref="ICommand"/>
        /// определяющий возможность выполнения команды InsertCommand
        /// </summary>
        public bool CanExecute(object parameter)
        {
            return true;
        }

        /// <summary>
        /// Событие для реализации интерфейса <see cref="ICommand"/>.
        /// </summary>
        public event EventHandler CanExecuteChanged = delegate { };

        /// <summary>
        /// Метод для реализации интерфейса <see cref="ICommand"/>.
        /// Инициализация вызова метода InsertEntity в модель-представлении.
        /// </summary>
        public void Execute(object parameter)
        {
            openMethod();
        }
        #endregion
    }
}
