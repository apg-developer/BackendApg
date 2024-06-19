using BackendApg.Data;
using BackendApg.Entities;

namespace BackendApg.Business
{
    public class EmployeeBusiness : IEmployeeBusiness
    {
        private readonly ISqlMockRepository _sqlRepository;

        public EmployeeBusiness(ISqlMockRepository sqlRepository)
        {
            _sqlRepository = sqlRepository;
        }

        public async Task AddEmployee(Employee employee)
        {
            if (employee == null) throw new Exception("bad argument employee");
            
            var result = await GetEmployeeById(employee.Id);
            if (result != null) throw new NullReferenceException("Employee id already is registered");

            var isSuccesful = await _sqlRepository.AddEmployee(employee);

            if (!isSuccesful)
                throw new Exception("An error has ocurred creating the employee");
        }

        public async Task DeleteEmployee(string id)
        {
            var employee = await GetEmployeeById(id);
            if (employee == null) throw new NullReferenceException("Employee id not registered");

            var isSuccesful = await _sqlRepository.DeleteEmployee(employee);

            if (!isSuccesful)
                throw new Exception("An error has ocurred deleting the employee");
        }

        public async Task<List<Employee>> GetAllEmployees()
        {
            return await _sqlRepository.GetEmployees();
        }

        public async Task<List<Employee>> GetEmployeesByName(string name)
        {
            return await _sqlRepository.GetEmployeesByName(name);
        }

        private async Task<Employee> GetEmployeeById(string id)
        {
            if (string.IsNullOrEmpty(id)) return null;
            var employee = await _sqlRepository.GetEmployeesById(id);
            return employee;
        }
    }
}
