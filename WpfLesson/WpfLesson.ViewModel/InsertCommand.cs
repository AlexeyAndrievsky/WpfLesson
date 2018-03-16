using System;
using System.Windows.Input;

namespace WpfLesson.ViewModel
{
    /// <summary>
    /// Класс, реализующий интерфейс <see cref="ICommand"/>
    /// служащий для обработки нажатия на кнопку добавления нового экземпляра сущности.
    /// </summary>
    internal class InsertCommand : ICommand
    {
        #region Fields
        /// <summary>
        /// Ссылка на модель-представление.
        /// </summary>
        private IAddNewEntityViewModel vm;
        #endregion

        #region .ctor
        /// <summary>
        /// Конструктор класса InsertCommand.
        /// </summary>
        /// <param name="viewModel">Ссылка на модель-представление.</param>
        public InsertCommand(IAddNewEntityViewModel viewModel)
        {
            vm = viewModel;
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
            vm.InsertEntity();
        }
        #endregion
    }
}
