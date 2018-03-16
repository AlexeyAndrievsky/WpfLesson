namespace WpfLesson.DataAccess
{
    public class Department : IDepartment
    {
        public int ID { get; set; }
        public string DeptName { get; set; }
        public string DeptInfo { get; set; }

        public Department(int id_Department, string deptName, string deptInfo)
        {
            ID = id_Department;
            DeptName = deptName;
            DeptInfo = deptInfo;
        }

        public void Update(IEntity department)
        {
            ID = (department as Department).ID;
            DeptName = (department as Department).DeptName;
            DeptInfo = (department as Department).DeptInfo;

            DataServiceStub ds = new DataServiceStub();
            ds.UpdateDepartment(this);
        }

        public void Insert(IEntity department)
        {
            ID = (department as Department).ID;
            DeptName = (department as Department).DeptName;
            DeptInfo = (department as Department).DeptInfo;

            DataServiceStub ds = new DataServiceStub();
            ds.InsertDepartment(this);
        }

        public void Delete(IEntity department)
        {
            ID = (department as Department).ID;

            DataServiceStub ds = new DataServiceStub();
            ds.DeleteDepartment(this);
        }

        public static implicit operator Department(DbDepartment dpt)
        {
            return new Department(dpt.Id_Department, dpt.DeptName, dpt.DeptInfo);
        }
    }
}
