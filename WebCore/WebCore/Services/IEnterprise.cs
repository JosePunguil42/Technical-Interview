using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebCore.ModelsDC;

namespace WebCore.Services
{
    public interface IEnterprise
    {
        Task<List<Enterprise>> GetEnterprises();

        Task<Enterprise> GetEnterprise(int? id);

        Task<Enterprise> SaveEnterprise(Enterprise enterprise);

        Task<Enterprise> UpdateEnterprise(int id, Enterprise enterprise);

        Task<Enterprise> DeleteEnterprise(int id);
    }
}
