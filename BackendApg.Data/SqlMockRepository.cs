using BackendApg.Entities;
using System.Xml.Linq;

namespace BackendApg.Data
{
    
    public class SqlMockRepository : ISqlMockRepository
    {
        private List<Employee> _employees =
        [
         new Employee {Id="12345", Fullname="Andres Perez Garrido", Birth= DateTime.Now.AddYears(-37) },
         new Employee {Id="753159", Fullname="Angela Gonzalez Daza", Birth= DateTime.Now.AddYears(-26) },
         new Employee {Id="951357", Fullname="Andrea Donado Ariza", Birth= DateTime.Now.AddYears(-34) }
        ];

        public async Task<bool> AddEmployee(Employee employee)
        {
            await Task.Delay(1000);
            if (employee == null) return false;

            this._employees.Add(employee);
            return true;
        }

        public async Task<bool> DeleteEmployee(Employee employee)
        {
            await Task.Delay(1000);
            if (employee == null) return false;

            this._employees.Remove(employee);
            return true;
        }

        public async Task<List<Employee>> GetEmployees()
        {
            await Task.Delay(1000);
            return _employees;
        }

        public async Task<Employee> GetEmployeesById(string id)
        {
            await Task.Delay(1000);
            var result = _employees.FirstOrDefault(x => x.Id.Equals(id, StringComparison.InvariantCultureIgnoreCase));
            return result;
        }

        public async Task<List<Employee>> GetEmployeesByName(string name)
        {
            await Task.Delay(1000);
            return _employees.Where(x=> x.Fullname.Contains(name, StringComparison.InvariantCultureIgnoreCase)).ToList();
        }
    }
}
