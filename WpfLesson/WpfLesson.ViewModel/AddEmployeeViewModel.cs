using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WpfLesson.DataAccess;
using WpfLesson.Model;

namespace WpfLesson.ViewModel
{
    public class AddEmployeeViewModel : Notifier, IAddNewEntityViewModel
    {
        private readonly IEntityModel empModel;
        private readonly ICommand insertCommand;
        public Action CloseAction;
        private readonly IEntitiesModel deptsmodel;

        public ObservableCollection<IEntity> Departments { get { return deptsmodel.Entities; } }
        public IEntity Employee { get { return empModel.Entity; } }

        public AddEmployeeViewModel(IEntityModel employeeModel, IEntitiesModel departmentsModel)
        {
            empModel = employeeModel;
            deptsmodel = departmentsModel;
            insertCommand = new InsertCommand(this);
        }

        public ICommand InsertCommand
        {
            get { return insertCommand; }
        }

        public void InsertEntity()
        {
            if ((Employee as IEmployee).Surname != string.Empty && (Employee as IEmployee).Name != string.Empty && (Employee as IEmployee).SecondName != string.Empty && (Employee as IEmployee).Birthday.HasValue && (Employee as IEmployee).Id_Department != -1 && (Employee as IEmployee).Salary.HasValue)
            {
                empModel.InsertEntity(Employee);
                CloseAction();
            }
        }
    }
}
