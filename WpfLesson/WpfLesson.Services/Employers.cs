//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WpfLesson.Services
{
    using System;
    using System.Collections.Generic;
    
    public partial class Employers
    {
        public int Id_Employee { get; set; }
        public string EmpSurname { get; set; }
        public string EmpName { get; set; }
        public string EmpSecondName { get; set; }
        public Nullable<System.DateTime> Birthday { get; set; }
        public Nullable<decimal> Salary { get; set; }
    
        public virtual Departments Departments { get; set; }
    }
}