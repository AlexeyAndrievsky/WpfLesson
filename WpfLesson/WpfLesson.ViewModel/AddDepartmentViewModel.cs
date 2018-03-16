using System;
using System.Windows.Input;
using WpfLesson.DataAccess;
using WpfLesson.Model;

namespace WpfLesson.ViewModel
{
    public class AddDepartmentViewModel : Notifier, IAddNewEntityViewModel
    {
        private readonly IEntityModel deptModel;
        private readonly ICommand insertCommand;
        public Action CloseAction;
        public IEntity Department { get { return deptModel.Entity; } }

        public AddDepartmentViewModel(IEntityModel departmentModel)
        {
            deptModel = departmentModel;
            insertCommand = new InsertCommand(this);
        }

        public ICommand InsertCommand
        {
            get { return insertCommand; }
        }

        public void InsertEntity()
        {
            if ((Department as IDepartment).DeptName != string.Empty && (Department as IDepartment).DeptInfo != string.Empty)
            {
                deptModel.InsertEntity(Department);
                CloseAction();
            }
        }
    }
}
