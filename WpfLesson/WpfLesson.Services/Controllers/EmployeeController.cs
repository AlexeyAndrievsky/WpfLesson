using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WpfLesson.Services.Models;

namespace WpfLesson.Services.Controllers
{
    /// <summary>
    /// Контроллер Сотрудник.
    /// Наследник класса <see cref="ApiController"/>
    /// </summary>
    public class EmployeeController : ApiController
    {
        /// <summary>
        /// Получение списка сотрудников.
        /// </summary>
        /// <returns>Список сотрудников.</returns>
        public List<Employee> Get()
        {
            return new DataServiceStub().GetEmployers().ToList(); ;
        }

        /// <summary>
        /// Получение сотрудника по Id.
        /// </summary>
        /// <param name="id">Id сотрудника</param>
        /// <returns>Сотрудник.</returns>
        public Employee Get(int id)
        {
            return new DataServiceStub().GetEmployers().FirstOrDefault(e => e.ID == id);
        }

        /// <summary>
        /// Обновление данных сотрудника.
        /// </summary>
        /// <param name="employee">Сотрудник, данные которого требуется обновить.</param>
        /// <returns>Статус выполнения запроса</returns>
        public HttpResponseMessage Put([FromBody]Employee employee)
        {
            try
            {
                DataServiceStub ds = new DataServiceStub();
                ds.UpdateEmployee(employee);
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex);
            }
        }

        /// <summary>
        /// Добавление нового сотрудника в БД.
        /// </summary>
        /// <param name="employee">Сотрудник, которого следует добавить.</param>
        /// <returns>Статус выполнения запроса</returns>
        public HttpResponseMessage Post([FromBody]Employee employee)
        {
            try
            {
                DataServiceStub ds = new DataServiceStub();
                ds.InsertEmployee(employee);
                return Request.CreateResponse(HttpStatusCode.Created);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex);
            }
        }

        /// <summary>
        /// Удаление сотрудника из БД.
        /// </summary>
        /// <param name="employee">Сотрудник, которого требуется удалить.</param>
        /// <returns>Статус выполнения запроса</returns>
        public HttpResponseMessage Delete(int id)
        {
            try
            {
                DataServiceStub ds = new DataServiceStub();
                ds.DeleteEmployee(id);
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex);
            }
        }
    }
}
