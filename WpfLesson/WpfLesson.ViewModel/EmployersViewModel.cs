using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using WpfLesson.DataAccess;
using WpfLesson.Model;

namespace WpfLesson.ViewModel
{
    public class EmployersViewModel : Notifier, IEntitiesViewModel
    {
        public const string SELECTED_EMPLOYEE_PROPERRTY_NAME = "SelectedEntity";

        private readonly IEntitiesModel model;
        private readonly IEntitiesModel deptsmodel;
        private EmployeeViewModel selectedEntity;
        private bool detailsEnabled;
        private readonly ICommand updateCommand;
        
        public ObservableCollection<IEntity> Departments { get { return deptsmodel.Entities; } }
        public ObservableCollection<IEntity> Employers { get { return model.Entities; } }

        public int? SelectedValue
        {
            set
            {
                if (value == null)
                    return;
                Employee employee = GetEmployee((int)value);
                if (SelectedEntity == null)
                {
                    SelectedEntity = new EmployeeViewModel(employee);
                }
                else
                {
                    SelectedEntity.Update(employee);
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

        public IEntityViewModel SelectedEntity
        {
            get { return selectedEntity; }

            set
            {
                if (value == null)
                {
                    selectedEntity = value as EmployeeViewModel;
                    DetailsEnabled = false;
                }
                else
                {
                    if (selectedEntity == null)
                    {
                        selectedEntity = new EmployeeViewModel(value as Employee);
                    }
                    selectedEntity.Update(value);
                    DetailsEnabled = true;
                    NotifyPropertyChanged(SELECTED_EMPLOYEE_PROPERRTY_NAME);
                }
            }
        }

        public string SelectedPropertyName { get; set; } = SELECTED_EMPLOYEE_PROPERRTY_NAME;

        public ICommand UpdateCommand
        {
            get { return updateCommand; }
        }

        public EmployersViewModel(IEntitiesModel employeeModel, IEntitiesModel departmentsModel)
        {
            model = employeeModel;
            deptsmodel = departmentsModel;
            model.EntityUpdated += model_EmployeeUpdated;
            updateCommand = new UpdateCommand(this);
        }

        public void UpdateEntity()
        {
            model.UpdateEntity(SelectedEntity);
        }

        private void model_EmployeeUpdated(object sender, EntityEventArgs e)
        {
            GetEmployee(e.Entity.ID).Update(e.Entity);
            if (SelectedEntity != null && e.Entity.ID == SelectedEntity.ID)
            {
                SelectedEntity.Update(e.Entity);
            }
        }

        private Employee GetEmployee(int id_Employee)
        {
            return Employers.FirstOrDefault(e => e.ID == id_Employee) as Employee;
        }
    }
}
