using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace WpfLesson.ViewModel
{
    internal class UpdateCommand : ICommand
    {
        private const int ARE_EQUAL = 0;
        private const int NONE_SELECTED = -1;
        private IEntitiesViewModel vm;

        public UpdateCommand(IEntitiesViewModel viewModel)
        {
            vm = viewModel;
            vm.PropertyChanged += vm_PropertyChanged;
        }

        private void vm_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (string.Compare(e.PropertyName, vm.SelectedPropertyName) == ARE_EQUAL)
            {
                CanExecuteChanged(this, new EventArgs());
            }
        }

        public bool CanExecute(object parameter)
        {
            if (vm.SelectedEntity == null)
                return false;
            return ((EntityViewModel)vm.SelectedEntity).ID > NONE_SELECTED;
        }

        public event EventHandler CanExecuteChanged = delegate { };

        public void Execute(object parameter)
        {
            vm.UpdateEntity();
        }
    }
}
