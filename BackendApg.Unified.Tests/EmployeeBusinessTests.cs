using BackendApg.Business;
using BackendApg.Data;
using BackendApg.Entities;
using Moq;

namespace BackendApg.Unified.Tests
{
    [TestClass]
    public class EmployeeBusinessTests
    {
        private Mock<ISqlMockRepository> _mockRepository;
        private EmployeeBusiness _employeeBusiness;

        [TestInitialize]
        public void Setup()
        {
            _mockRepository = new Mock<ISqlMockRepository>();
            _employeeBusiness = new EmployeeBusiness(_mockRepository.Object);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public async Task AddEmployee_NullEmployee_ThrowsException()
        {
            await _employeeBusiness.AddEmployee(null);
        }

        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public async Task AddEmployee_ExistingId_ThrowsException()
        {
            var employee = new Employee { Id = "12345", Fullname = "xxxx xxxx" };
            _mockRepository.Setup(repo => repo.GetEmployeesById("12345")).ReturnsAsync(employee);

            await _employeeBusiness.AddEmployee(employee);
        }

        [TestMethod]
        public async Task AddEmployee_ValidEmployee_AddsSuccessfully()
        {
            var employee = new Employee { Id = "newId", Fullname = "xxxx xxxx" };
            _mockRepository.Setup(repo => repo.AddEmployee(It.IsAny<Employee>())).ReturnsAsync(true);

            await _employeeBusiness.AddEmployee(employee);

            _mockRepository.Verify(repo => repo.AddEmployee(It.IsAny<Employee>()), Times.Once);
        }

        [TestMethod]
        public async Task DeleteEmployee_ExistingEmployee_DeletesSuccessfully()
        {
            var employee = new Employee { Id = "existingId", Fullname = "xxxx xxxx" };
            _mockRepository.Setup(repo => repo.GetEmployeesById("existingId")).ReturnsAsync(employee);
            _mockRepository.Setup(repo => repo.DeleteEmployee(It.IsAny<Employee>())).ReturnsAsync(true);

            await _employeeBusiness.DeleteEmployee("existingId");

            _mockRepository.Verify(repo => repo.DeleteEmployee(It.IsAny<Employee>()), Times.Once);
        }

        [TestMethod]
        public async Task GetAllEmployees_ReturnsAllEmployees()
        {
            var employees = new List<Employee> { new Employee { Id = "1", Fullname = "xxxx xxxx" }, new Employee { Id = "2", Fullname = "abcd xyz" } };
            _mockRepository.Setup(repo => repo.GetEmployees()).ReturnsAsync(employees);

            var result = await _employeeBusiness.GetAllEmployees();

            Assert.AreEqual(2, result.Count);
        }

        [TestMethod]
        public async Task GetEmployeesByName_ReturnsCorrectEmployees()
        {
            var employees = new List<Employee> { new Employee { Id = "1", Fullname = "Test Name" } };
            _mockRepository.Setup(repo => repo.GetEmployeesByName("Test Name")).ReturnsAsync(employees);

            var result = await _employeeBusiness.GetEmployeesByName("Test Name");

            Assert.AreEqual(1, result.Count);
            Assert.AreEqual("Test Name", result[0].Fullname);
        }
    }
}