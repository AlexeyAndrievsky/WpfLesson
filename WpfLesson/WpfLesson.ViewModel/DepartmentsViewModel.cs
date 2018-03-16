using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using WpfLesson.DataAccess;
using WpfLesson.Model;

namespace WpfLesson.ViewModel
{
    public class DepartmentsViewModel : Notifier, IEntitiesViewModel
    {
        public const string SELECTED_DEPARTMENT_PROPERRTY_NAME = "SelectedEntity";

        private readonly IEntitiesModel empModel;
        private readonly IEntitiesModel deptsModel;
        private DepartmentViewModel selectedEntity;
        private bool detailsEnabled;
        private readonly ICommand updateCommand;

        public ObservableCollection<IEntity> Departments { get { return deptsModel.Entities; } }
        public ObservableCollection<IEntity> Employers { get { return empModel.Entities; } }

        public int? SelectedValue
        {
            set
            {
                if (value == null)
                    return;
                Department department = GetDepartment((int)value);
                if (SelectedEntity == null)
                {
                    SelectedEntity = new DepartmentViewModel(department);
                }
                else
                {
                    SelectedEntity.Update(department);
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
                    selectedEntity = value as DepartmentViewModel;
                    DetailsEnabled = false;
                }
                else
                {
                    if (selectedEntity == null)
                    {
                        selectedEntity = new DepartmentViewModel(value as Department);
                    }
                    selectedEntity.Update(value);
                    DetailsEnabled = true;
                    NotifyPropertyChanged(SELECTED_DEPARTMENT_PROPERRTY_NAME);
                }
            }
        }

        public string SelectedPropertyName { get; set; } = SELECTED_DEPARTMENT_PROPERRTY_NAME;

        public ICommand UpdateCommand
        {
            get { return updateCommand; }
        }

        public DepartmentsViewModel(IEntitiesModel employeeModel, IEntitiesModel departmentsModel)
        {
            empModel = employeeModel;
            deptsModel = departmentsModel;
            deptsModel.EntityUpdated += model_DepartmentUpdated;
            updateCommand = new UpdateCommand(this);
        }

        public void UpdateEntity()
        {
            deptsModel.UpdateEntity(SelectedEntity);
        }

        private void model_DepartmentUpdated(object sender, EntityEventArgs e)
        {
            GetDepartment(e.Entity.ID).Update(e.Entity);
            if (SelectedEntity != null && e.Entity.ID == SelectedEntity.ID)
            {
                SelectedEntity.Update(e.Entity);
            }
        }

        private Department GetDepartment(int id_Department)
        {
            return Departments.FirstOrDefault(e => e.ID == id_Department) as Department;
        }
    }
}
