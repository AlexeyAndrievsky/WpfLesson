using System;

namespace WpfLesson
{
    public class Employee
    {
        //TODO: Доступные для записи из вне поля - никуда не годится. Позже переделаю.
        public string Surname { get; set; }
        public string Name { get; set; }
        public string SecondName { get; set; }
        public DateTime Birthday { get; set; }
        public string Passport { get; set; }
        public string Addres { get; set; }
        public int DepartmentNumber { get; set; }

        public Employee(string surname, string name, string secondName, DateTime birthday, string passport, string addres, int departmentNumber)
        {
            Name = name;
            Surname = surname;
            SecondName = secondName;
            Birthday = birthday;
            Passport = passport;
            Addres = addres;
            DepartmentNumber = departmentNumber;
        }
    }

    
}
