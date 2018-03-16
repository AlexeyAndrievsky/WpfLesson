using System;
using System.Collections.ObjectModel;
using WpfLesson.DataAccess;
using WpfLesson.Model;

namespace WpfLesson.ViewModel
{
    public class EmployeeViewModel : EntityViewModel, IEmployee
    {
        private string surname;
        private string name;
        private string secondname;
        private DateTime? birthday;
        private int id_Department;
        private decimal? salary;

        public string Surname
        {
            get { return surname; }
            set
            {
                surname = value;
                NotifyPropertyChanged("Surname");
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

        public string SecondName
        {
            get { return secondname; }
            set
            {
                secondname = value;
                NotifyPropertyChanged("SecondName");
            }
        }

        public DateTime? Birthday
        {
            get { return birthday; }
            set
            {
                birthday = value;
                NotifyPropertyChanged("Birthday");
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

        public decimal? Salary
        {
            get { return salary; }
            set
            {
                salary = value;
                NotifyPropertyChanged("Salary");
            }
        }

        public EmployeeViewModel(IEmployee employee)
        {
            if (employee == null)
                return;
            ID = employee.ID;
            Update(employee);
        }

        public override void Update(IEntity entity)
        {
            ID = entity.ID;
            Surname = (entity as IEmployee).Surname;
            Name = (entity as IEmployee).Name;
            SecondName = (entity as IEmployee).SecondName;
            Birthday = (entity as IEmployee).Birthday;
            Id_Department = (entity as IEmployee).Id_Department;
            Salary = (entity as IEmployee).Salary;
        }

        public override void Insert(IEntity entity)
        {
            ID = entity.ID;
            Surname = (entity as IEmployee).Surname;
            Name = (entity as IEmployee).Name;
            SecondName = (entity as IEmployee).SecondName;
            Birthday = (entity as IEmployee).Birthday;
            Id_Department = (entity as IEmployee).Id_Department;
            Salary = (entity as IEmployee).Salary;
        }

        public override void Delete(IEntity entity)
        {
            ID = entity.ID;
            Surname = (entity as IEmployee).Surname;
            Name = (entity as IEmployee).Name;
            SecondName = (entity as IEmployee).SecondName;
            Birthday = (entity as IEmployee).Birthday;
            Id_Department = (entity as IEmployee).Id_Department;
            Salary = (entity as IEmployee).Salary;
        }
    }
}
