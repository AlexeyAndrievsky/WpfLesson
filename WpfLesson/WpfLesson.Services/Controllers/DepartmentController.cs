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
    /// Контроллер Отделение.
    /// Наследник класса <see cref="ApiController"/>
    /// </summary>
    public class DepartmentController : ApiController
    {
        /// <summary>
        /// Получение списка отделений.
        /// </summary>
        /// <returns>Список отделений.</returns>
        public List<Department> Get()
        {
            return new DataServiceStub().GetDepartments().ToList();
        }

        /// <summary>
        /// Получение отделения по Id.
        /// </summary>
        /// <param name="id">Id отделения</param>
        /// <returns>Отделение.</returns>
        public Department Get(int id)
        {
            return new DataServiceStub().GetDepartments().FirstOrDefault(e => e.ID == id);
        }

        /// <summary>
        /// Обновление данных отделения.
        /// </summary>
        /// <param name="department">отделение, данные которого требуется обновить.</param>
        /// <returns>Статус выполнения запроса</returns>
        public HttpResponseMessage Put([FromBody]Department department)
        {
            try
            {
                DataServiceStub ds = new DataServiceStub();
                ds.UpdateDepartment(department);
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex);
            }
        }

        /// <summary>
        /// Добавление нового отделения в БД.
        /// </summary>
        /// <param name="department">Отделение, которое следует добавить в БД.</param>
        /// <returns>Статус выполнения запроса</returns>
        public HttpResponseMessage Post([FromBody]Department department)
        {
            try
            {
                DataServiceStub ds = new DataServiceStub();
                ds.InsertDepartment(department);
                return Request.CreateResponse(HttpStatusCode.Created);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex);
            }
        }

        /// <summary>
        /// Удаление отделения из БД.
        /// </summary>
        /// <param name="department">Отделение, которое следует удалить из БД.</param>
        /// <returns>Статус выполнения запроса</returns>
        public HttpResponseMessage Delete(int id)
        {
            try
            {
                DataServiceStub ds = new DataServiceStub();
                ds.DeleteDepartment(id);
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex);
            }
        }
    }
}
