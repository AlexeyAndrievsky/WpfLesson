using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace WpfLesson.DataAccess
{
    /// <summary>
    /// Класс, осуществляющий обмен данными с базой данных.
    /// Реализует интерфейс <see cref="IDataService"/>
    /// </summary>
    public class DataServiceStub : IDataService
    {
        #region Fields
        /// <summary>
        /// Поле, хранящее настройки http клиента для отправки и получения запросов.
        /// </summary>
        HttpClient client = new HttpClient();
        #endregion

        #region .ctor
        /// <summary>
        /// Конструктор класса DataServiceStub, инициализирующий поле HttpClient.
        /// </summary>
        public DataServiceStub()
        {
            client = new HttpClient();
            client.BaseAddress = new Uri(Properties.Settings.Default.ServiceUrl);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }
        #endregion

        #region Public methods
        #region Employee Data Service
        /// <summary>
        /// Получение списка сотрудников.
        /// </summary>
        /// <returns>Список сотрудников.</returns>
        public async Task<List<Employee>> GetEmployers()
        {
            List<Employee> employers = null;
            try
            {
                HttpResponseMessage response = await client.GetAsync("api/Employee");
                if (response.IsSuccessStatusCode)
                {
                    employers = await response.Content.ReadAsAsync<List<Employee>>();
                }
            }
            catch (Exception)
            {
            }
            return employers;
        }

        /// <summary>
        /// Обновление данных сотрудника.
        /// </summary>
        /// <param name="employee">Сотрудник, данные которого требуется обновить.</param>
        public async Task<Uri> UpdateEmployee(Employee employee)
        {
            HttpResponseMessage response = await client.PutAsJsonAsync("api/Employee", employee);
            response.EnsureSuccessStatusCode();
            return response.Headers.Location;
        }

        /// <summary>
        /// Добавление нового сотрудника в БД.
        /// </summary>
        /// <param name="employee">Сотрудник, которого следует добавить.</param>
        public async Task<Uri> InsertEmployee(Employee employee)
        {
            HttpResponseMessage response = await client.PostAsJsonAsync("api/Employee", employee);
            response.EnsureSuccessStatusCode();
            return response.Headers.Location;
        }

        /// <summary>
        /// Удаление сотрудника из БД.
        /// </summary>
        /// <param name="employee">Сотрудник, которого требуется удалить.</param>
        public async Task<Uri> DeleteEmployee(Employee employee)
        {
            HttpResponseMessage response = await client.DeleteAsync($"api/Employee/{employee.ID}");
            response.EnsureSuccessStatusCode();
            return response.Headers.Location;
        }
        #endregion

        #region Department Data Service
        /// <summary>
        /// Получение списка отделений.
        /// </summary>
        /// <returns>Список отделений.</returns>
        public async Task<List<Department>> GetDepartments()
        {
            List<Department> departments = null;
            try
            {
                HttpResponseMessage response = await client.GetAsync("api/Department");
                if (response.IsSuccessStatusCode)
                {
                    departments = await response.Content.ReadAsAsync<List<Department>>();
                }
            }
            catch (Exception)
            {
            }
            return departments;
        }

        /// <summary>
        /// Обновление данных отделения.
        /// </summary>
        /// <param name="department">отделение, данные которого требуется обновить.</param>
        public async Task<Uri> UpdateDepartment(Department department)
        {
            HttpResponseMessage response = await client.PutAsJsonAsync("api/Department", department);
            response.EnsureSuccessStatusCode();
            return response.Headers.Location;
        }

        /// <summary>
        /// Добавление нового отделения в БД.
        /// </summary>
        /// <param name="department">Отделение, которое следует добавить в БД.</param>
        public async Task<Uri> InsertDepartment(Department department)
        {
            HttpResponseMessage response = await client.PostAsJsonAsync("api/Department", department);
            response.EnsureSuccessStatusCode();
            return response.Headers.Location;
        }

        /// <summary>
        /// Удаление отделения из БД.
        /// </summary>
        /// <param name="department">Отделение, которое следует удалить из БД.</param>
        public async Task<Uri> DeleteDepartment(Department department)
        {
            HttpResponseMessage response = await client.DeleteAsync($"api/Department/{department.ID}");
            response.EnsureSuccessStatusCode();
            return response.Headers.Location;
        }
        #endregion
        #endregion
    }
}
