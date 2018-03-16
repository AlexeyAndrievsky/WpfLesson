using WpfLesson.DataAccess;
using WpfLesson.Model;

namespace WpfLesson.ViewModel
{
    public class DepartmentViewModel : EntityViewModel, IDepartment
    {
        private string deptName;
        private string deptInfo;

        public string DeptName
        {
            get { return deptName; }
            set
            {
                deptName = value;
                NotifyPropertyChanged("DeptName");
            }
        }

        public string DeptInfo
        {
            get { return deptInfo; }
            set
            {
                deptInfo = value;
                NotifyPropertyChanged("DeptInfo");
            }
        }

        public DepartmentViewModel(IDepartment department)
        {
            if (department == null)
                return;
            ID = department.ID;
            Update(department);
        }

        public DepartmentViewModel(DepartmentModel departmentModel)
        {
            if (departmentModel == null)
                return;
            if (departmentModel.Entity == null)
                return;
            ID = departmentModel.Entity.ID;
            Update(departmentModel.Entity);
        }

        public override void Update(IEntity entity)
        {
            ID = entity.ID;
            DeptName = (entity as IDepartment).DeptName;
            DeptInfo = (entity as IDepartment).DeptInfo;
        }

        public override void Insert(IEntity entity)
        {
            ID = entity.ID;
            DeptName = (entity as IDepartment).DeptName;
            DeptInfo = (entity as IDepartment).DeptInfo;
        }

        public override void Delete(IEntity entity)
        {
            ID = entity.ID;
            DeptName = (entity as IDepartment).DeptName;
            DeptInfo = (entity as IDepartment).DeptInfo;
        }
    }
}
