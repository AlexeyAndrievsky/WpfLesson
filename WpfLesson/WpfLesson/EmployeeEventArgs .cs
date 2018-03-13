using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfLesson.DataAccess;

namespace WpfLesson
{
    class EmployeeEventArgs : EventArgs
    {
        public IEmployee Employee { get; set; }
        public EmployeeEventArgs(IEmployee employee)
        {
            Employee = employee;
        }
    }
}
