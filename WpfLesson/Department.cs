namespace WpfLesson
{
    public class Department
    {
        //TODO: Доступные для записи из вне поля - никуда не годится. Позже переделаю.
        public int DepartmentNumber { get; set; }
        public string DepartmentName { get; set; }
        public string Info { get; set; }

        public Department(int departmentNumber, string departmentName, string info)
        {
            DepartmentNumber = departmentNumber;
            DepartmentName = departmentName;
            Info = info;
        }
    }


}
