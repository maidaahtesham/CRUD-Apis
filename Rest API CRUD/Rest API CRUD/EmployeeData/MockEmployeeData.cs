using Rest_API_CRUD.Models;

namespace Rest_API_CRUD.EmployeeData
{
    public class MockEmployeeData : IEmployee
    {
        private List<Employee> employees = new List<Employee>()
        {
            new Employee()
            {
                Id=Guid.NewGuid(),
                Name="Maida"
            },
            new Employee()
            {
                Id = Guid.NewGuid(),
                Name="Mehwish"
            }
        };
        public Employee AddEmployee(Employee employee)
        {
        employee.Id = Guid.NewGuid();
        employees.Add(employee);
            return employee;
        }

        public void DeleteEmployee(Employee employee)
        {
            employees.Remove(employee);
        }

        public Employee GetEmployee(Guid id)
        {
            return employees.SingleOrDefault(x => x.Id == id);
        }

        public List<Employee> GetEmployees()
        {
         return employees;
        }

        public Employee EditEmployee(Employee employee)
        {
          var existingEmployee= GetEmployee (employee.Id);
            existingEmployee.Name=employee.Name;
            return existingEmployee;
                }
    }
}
