using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfLesson.DataAccess;

namespace WpfLesson
{
    class EmployeeViewModel : Notifier, IEmployeeViewModel
    {
        private int id;
        private string surname;
        private string name;
        private string secondName;
        private DateTime? birthday;
        private decimal? salary;
        private int id_Department;

        public DateTime? Birthday
        {
            get { return birthday; }
            set
            {
                birthday = value;
                NotifyPropertyChanged("Birthday");
            }
        }

        public int ID
        {
            get { return id; }
            set
            {
                id = value;
                NotifyPropertyChanged("ID");
            }
        }

        public int Id_Department
        {
            get { return id_Department; }
            set
            {
                id_Department = value;
                NotifyPropertyChanged("Id_Department");
            }
        }

        public string Name
        {
            get { return name; }
            set
            {
                name = value;
                NotifyPropertyChanged("Name");
            }
        }

        public decimal? Salary
        {
            get { return salary; }
            set
            {
                salary = value;
                NotifyPropertyChanged("Salary");
            }
        }

        public string SecondName
        {
            get { return secondName; }
            set
            {
                secondName = value;
                NotifyPropertyChanged("SecondName");
            }
        }

        public string Surname
        {
            get { return surname; }
            set
            {
                surname = value;
                NotifyPropertyChanged("Surname");
            }
        }

        public EmployeeViewModel(IEmployee employee)
        {
            if (employee == null)
                return;
            ID = employee.ID;
            Update(employee);
        }

        public void Update(IEmployee employee)
        {
            ID = employee.ID;
            Surname = employee.Surname;
            Name = employee.Name;
            SecondName = employee.SecondName;
            Birthday = employee.Birthday;
            Id_Department = employee.Id_Department;
            Salary = employee.Salary;
        }
    }
}
