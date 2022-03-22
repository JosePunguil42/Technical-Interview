using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebCore.ModelsDC;

namespace WebCore.Services
{
    public class SrvDepartment: IDepartment
    {
        public SrvDepartment()
        {
        }

        public async Task<List<Department>> GetDepartments()
        {
            return await ApiRest.GetRestAsync<List<Department>>("Department").ConfigureAwait(false);
        }

        public async Task<Department> GetDepartment(int? id)
        {
            return await ApiRest.GetRestAsync<Department>($"Department/{id}").ConfigureAwait(false);
        }

        public async Task<Department> SaveDepartment(Department department)
        {
            return await ApiRest.PostRestAsync<Department>("Department", department).ConfigureAwait(false);
        }

        public async Task<Department> UpdateDepartment(int id, Department department)
        {
            return await ApiRest.PutRestAsync<Department>($"Department/{id}", department).ConfigureAwait(false);
        }

        public async Task<Department> DeleteDepartment(int id)
        {
            return await ApiRest.DeleteRestAsync<Department>($"Department/{id}").ConfigureAwait(false);
        }
    }
}
