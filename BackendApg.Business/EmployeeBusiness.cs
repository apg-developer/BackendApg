using BackendApg.Data;
using BackendApg.Entities;

namespace BackendApg.Business
{
    /// <summary>
    /// Provides business logic for employee operations.
    /// </summary>
    public class EmployeeBusiness : IEmployeeBusiness
    {
        private readonly ISqlMockRepository _sqlRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="EmployeeBusiness"/> class.
        /// </summary>
        /// <param name="sqlRepository">The SQL repository to interact with the database.</param>
        public EmployeeBusiness(ISqlMockRepository sqlRepository)
        {
            _sqlRepository = sqlRepository;
        }

        /// <summary>
        /// Adds a new employee to the database.
        /// </summary>
        /// <param name="employee">The employee to add.</param>
        /// <exception cref="Exception">Thrown when the employee is null or the ID is already registered.</exception>
        public async Task AddEmployee(Employee employee)
        {
            if (employee == null) throw new Exception("bad argument employee");

            var result = await GetEmployeeById(employee.Id);
            if (result != null) throw new NullReferenceException("Employee id already is registered");

            var isSuccesful = await _sqlRepository.AddEmployee(employee);

            if (!isSuccesful)
                throw new Exception("An error has ocurred creating the employee");
        }

        /// <summary>
        /// Deletes an employee from the database.
        /// </summary>
        /// <param name="id">The ID of the employee to delete.</param>
        /// <exception cref="Exception">Thrown when the employee ID is not registered or an error occurs during deletion.</exception>
        public async Task DeleteEmployee(string id)
        {
            var employee = await GetEmployeeById(id);
            if (employee == null) throw new NullReferenceException("Employee id not registered");

            var isSuccesful = await _sqlRepository.DeleteEmployee(employee);

            if (!isSuccesful)
                throw new Exception("An error has ocurred deleting the employee");
        }

        /// <summary>
        /// Retrieves all employees from the database.
        /// </summary>
        /// <returns>A list of all employees.</returns>
        public async Task<List<Employee>> GetAllEmployees()
        {
            return await _sqlRepository.GetEmployees();
        }

        /// <summary>
        /// Retrieves employees by name from the database.
        /// </summary>
        /// <param name="name">The name of the employees to retrieve.</param>
        /// <returns>A list of employees with the specified name.</returns>
        public async Task<List<Employee>> GetEmployeesByName(string name)
        {
            return await _sqlRepository.GetEmployeesByName(name);
        }

        /// <summary>
        /// Retrieves an employee by ID from the database.
        /// </summary>
        /// <param name="id">The ID of the employee to retrieve.</param>
        /// <returns>The employee with the specified ID, or null if not found.</returns>
        private async Task<Employee> GetEmployeeById(string id)
        {
            if (string.IsNullOrEmpty(id)) return null;
            var employee = await _sqlRepository.GetEmployeesById(id);
            return employee;
        }
    }
}