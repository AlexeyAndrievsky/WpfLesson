using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfLesson.DataAccess
{
    public interface IEmployee
    {
        int ID { get; set; }
        string Surname { get; set; }
        string Name { get; set; }
        string SecondName { get; set; }
        DateTime? Birthday { get; set; }
        int Id_Department { get; set; }
        decimal? Salary { get; set; }

        void Update(IEmployee employee);
    }
}
