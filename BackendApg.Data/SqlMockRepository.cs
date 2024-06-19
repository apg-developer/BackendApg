using BackendApg.Entities;

namespace BackendApg.Data
{

    ///<summary>
    /// Represents a mock SQL repository for managing employees in memory.
    /// </summary>
    public class SqlMockRepository : ISqlMockRepository
    {
        private List<Employee> _employees =
        [
         new Employee {Id="12345", Fullname="Andres Perez Garrido", Birth= DateTime.Now.AddYears(-37) },
             new Employee {Id="753159", Fullname="Angela Gonzalez Daza", Birth= DateTime.Now.AddYears(-26) },
             new Employee {Id="951357", Fullname="Andrea Donado Ariza", Birth= DateTime.Now.AddYears(-34) }
        ];

        /// <summary>
        /// Adds an employee to the mock repository.
        /// </summary>
        /// <param name="employee">The employee to add.</param>
        /// <returns>A task that represents the asynchronous operation, containing a boolean indicating success or failure.</returns>
        public async Task<bool> AddEmployee(Employee employee)
        {
            await Task.Delay(1000);
            if (employee == null) return false;

            this._employees.Add(employee);
            return true;
        }

        /// <summary>
        /// Deletes an employee from the mock repository.
        /// </summary>
        /// <param name="employee">The employee to delete.</param>
        /// <returns>A task that represents the asynchronous operation, containing a boolean indicating success or failure.</returns>
        public async Task<bool> DeleteEmployee(Employee employee)
        {
            await Task.Delay(1000);
            if (employee == null) return false;

            this._employees.Remove(employee);
            return true;
        }

        /// <summary>
        /// Gets all employees from the mock repository.
        /// </summary>
        /// <returns>A task that represents the asynchronous operation, containing a list of employees.</returns>
        public async Task<List<Employee>> GetEmployees()
        {
            await Task.Delay(1000);
            return _employees;
        }

        /// <summary>
        /// Gets an employee by ID from the mock repository.
        /// </summary>
        /// <param name="id">The ID of the employee to find.</param>
        /// <returns>A task that represents the asynchronous operation, containing the found employee or null.</returns>
        public async Task<Employee> GetEmployeesById(string id)
        {
            await Task.Delay(1000);
            var result = _employees.FirstOrDefault(x => x.Id.Equals(id, StringComparison.InvariantCultureIgnoreCase));
            return result;
        }

        /// <summary>
        /// Gets employees by name from the mock repository.
        /// </summary>
        /// <param name="name">The name to search for.</param>
        /// <returns>A task that represents the asynchronous operation, containing a list of employees that match the name.</returns>
        public async Task<List<Employee>> GetEmployeesByName(string name)
        {
            await Task.Delay(1000);
            return _employees.Where(x => x.Fullname.Contains(name, StringComparison.InvariantCultureIgnoreCase)).ToList();
        }
    }
}