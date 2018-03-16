using System;

namespace WpfLesson.DataAccess
{
    public interface IEmployee : IEntity
    {
        string Surname { get; set; }
        string Name { get; set; }
        string SecondName { get; set; }
        DateTime? Birthday { get; set; }
        int Id_Department { get; set; }
        decimal? Salary { get; set; }
    }
}
