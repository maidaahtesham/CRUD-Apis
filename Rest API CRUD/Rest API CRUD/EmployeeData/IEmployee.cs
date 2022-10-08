using Rest_API_CRUD.Models;

namespace Rest_API_CRUD.EmployeeData
{
    public interface IEmployee
    {
        List<Employee> GetEmployees();

        Employee GetEmployee(Guid id);



        Employee AddEmployee(Employee employee);



        Employee EditEmployee(Employee employee);



        void DeleteEmployee(Employee employee);
    }
}
