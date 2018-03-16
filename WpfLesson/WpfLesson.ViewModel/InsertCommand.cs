using System;
using System.Windows.Input;

namespace WpfLesson.ViewModel
{
    internal class InsertCommand : ICommand
    {
        private IAddNewEntityViewModel vm;

        public InsertCommand(IAddNewEntityViewModel viewModel)
        {
            vm = viewModel;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public event EventHandler CanExecuteChanged = delegate { };

        public void Execute(object parameter)
        {
            vm.InsertEntity();
        }
    }
}
