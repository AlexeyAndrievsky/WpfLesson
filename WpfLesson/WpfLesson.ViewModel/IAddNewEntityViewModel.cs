using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfLesson.ViewModel
{
    public interface IAddNewEntityViewModel : INotifyPropertyChanged
    {
        void InsertEntity();
    }
}
