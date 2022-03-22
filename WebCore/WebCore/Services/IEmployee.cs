using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebCore.ModelsDC;

namespace WebCore.Services
{
    public interface IEmployee
    {
        Task<List<Employee>> GetEmployees();

        Task<Employee> GetEmployee(int? id);

        Task<Employee> SaveEmployee(Employee employee);

        Task<Employee> UpdateEmployee(int id, Employee employee);

        Task<Employee> DeleteEmployee(int id);
    }
}
