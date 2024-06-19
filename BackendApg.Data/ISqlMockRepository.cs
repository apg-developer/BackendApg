using BackendApg.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackendApg.Data
{
    public interface ISqlMockRepository
    {
        Task<List<Employee>> GetEmployees();

        Task<Employee> GetEmployeesById(string id);

        Task<List<Employee>> GetEmployeesByName(string name);

        Task<bool> AddEmployee(Employee employee);

        Task<bool> DeleteEmployee(Employee employee);
    }
}
