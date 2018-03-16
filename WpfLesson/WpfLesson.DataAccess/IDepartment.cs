namespace WpfLesson.DataAccess
{
    public interface IDepartment : IEntity
    {
        string DeptName { get; set; }
        string DeptInfo { get; set; }
    }
}
