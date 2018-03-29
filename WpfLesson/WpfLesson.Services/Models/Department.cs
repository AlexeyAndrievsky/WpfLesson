using System.Runtime.Serialization;

namespace WpfLesson.Services.Models
{
    /// <summary>
    /// Класс, реализующий сущность Отделение.
    /// </summary>
    [DataContract]
    public class Department
    {
        #region Fields
        /// <summary>
        /// ID отделения.
        /// </summary>
        [DataMember]
        public int ID { get; set; }

        /// <summary>
        /// Название отделения.
        /// </summary>
        [DataMember]
        public string DeptName { get; set; }

        /// <summary>
        /// Дополнительная информация об отделении.
        /// </summary>
        [DataMember]
        public string DeptInfo { get; set; }
        #endregion

        #region .ctor
        /// <summary>
        /// Конструктор класса Department.
        /// </summary>
        /// <param name="id_Department">ID отделения.</param>
        /// <param name="deptName">Название отделения.</param>
        /// <param name="deptInfo">Дополнительная информация об отделении.</param>
        public Department(int id_Department, string deptName, string deptInfo)
        {
            ID = id_Department;
            DeptName = deptName;
            DeptInfo = deptInfo;
        }
        #endregion
    }
}
