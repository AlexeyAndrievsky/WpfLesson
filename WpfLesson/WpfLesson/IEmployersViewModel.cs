using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfLesson
{
    interface IEmployersViewModel : INotifyPropertyChanged
    {
        IEmployeeViewModel SelectedEmployee { get; set; }
        void UpdateEmployee();
    }
}
