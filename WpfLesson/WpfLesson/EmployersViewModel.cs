using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WpfLesson.DataAccess;

namespace WpfLesson
{
    class EmployersViewModel : Notifier, IEmployersViewModel
    {
        public const string SELECTED_EMPLOYEE_PROPERRTY_NAME = "SelectedEmployee";

        private readonly IEmployersModel model;
        private IEmployeeViewModel selectedEmployee;
        private bool detailsEnabled;
        private readonly ICommand updateCommand;


        public ObservableCollection<Employee> Employers
        {
            get { return model.Employers; }
        }

        public int? SelectedValue
        {
            set
            {
                if (value == null)
                    return;
                Employee emp = GetEmployee((int)value);
                if (SelectedEmployee == null)
                {
                    SelectedEmployee = new EmployeeViewModel(emp);
                }
                else
                {
                    SelectedEmployee.Update(emp);
                }
            }
        }

        public IEmployeeViewModel SelectedEmployee
        {
            get { return selectedEmployee; }
            set
            {
                if (value == null)
                {
                    selectedEmployee = value;
                    DetailsEnabled = false;
                }
                else
                {
                    if (selectedEmployee == null)
                    {
                        selectedEmployee = new EmployeeViewModel(value);
                    }
                    selectedEmployee.Update(value);
                    DetailsEnabled = true;
                    NotifyPropertyChanged(SELECTED_EMPLOYEE_PROPERRTY_NAME);
                }
            }
        }

        public bool DetailsEnabled
        {
            get { return detailsEnabled; }
            set
            {
                detailsEnabled = value;
                NotifyPropertyChanged("DetailsEnabled");
            }
        }

        public ICommand UpdateCommand
        {
            get { return updateCommand; }
        }

        public EmployersViewModel(IEmployersModel employersModel)
        {
            model = employersModel;
            model.EmployeeUpdated += model_EmployeeUpdated;
            updateCommand = new UpdateCommand(this);
        }

        public void UpdateEmployee()
        {
            model.UpdateEmployee(selectedEmployee);
        }

        private void model_EmployeeUpdated(object sender, EmployeeEventArgs e)
        {
            GetEmployee(e.Employee.ID).Update(e.Employee);
            if (SelectedEmployee != null
                && e.Employee.ID == SelectedEmployee.ID)
            {
                SelectedEmployee.Update(e.Employee);
            }
        }

        private Employee GetEmployee(int id_Employee)
        {
            Employee emp = Employers.FirstOrDefault(e => e.ID == id_Employee);
            return emp;
        }
    }
}
