using BackendApg.Entities;

namespace BackendApg.Business
{
    public interface IEmployeeBusiness
    {
        Task<List<Employee>> GetAllEmployees();

        Task<List<Employee>> GetEmployeesByName(string name);

        Task AddEmployee(Employee employee);

        Task DeleteEmployee(string id);
    }
}
