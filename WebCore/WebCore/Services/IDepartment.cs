using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebCore.ModelsDC;

namespace WebCore.Services
{
    public interface IDepartment
    {
        Task<List<Department>> GetDepartments();

        Task<Department> GetDepartment(int? id);
        Task<Department> SaveDepartment(Department department);

        Task<Department> UpdateDepartment(int id, Department department);

        Task<Department> DeleteDepartment(int id);
    }
}
