using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebCore.ModelsDC;

namespace WebCore.Services
{
    public class SrvEmployee: IEmployee
    {
        public SrvEmployee()
        {
        }

        public async Task<List<Employee>> GetEmployees()
        {
            return await ApiRest.GetRestAsync<List<Employee>>("Employee").ConfigureAwait(false);
        }

        public async Task<Employee> GetEmployee(int? id)
        {
            return await ApiRest.GetRestAsync<Employee>($"Employee/{id}").ConfigureAwait(false);
        }

        public async Task<Employee> SaveEmployee(Employee employee)
        {
            return await ApiRest.PostRestAsync<Employee>("Employee", employee).ConfigureAwait(false);
        }

        public async Task<Employee> UpdateEmployee(int id, Employee employee)
        {
            return await ApiRest.PutRestAsync<Employee>($"Employee/{id}", employee).ConfigureAwait(false);
        }

        public async Task<Employee> DeleteEmployee(int id)
        {
            return await ApiRest.DeleteRestAsync<Employee>($"Employee/{id}").ConfigureAwait(false);
        }
    }
}
