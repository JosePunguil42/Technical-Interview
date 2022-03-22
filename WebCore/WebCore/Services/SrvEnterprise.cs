using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebCore.ModelsDC;

namespace WebCore.Services
{
    public class SrvEnterprise : IEnterprise
    {
        public SrvEnterprise()
        {
        }

        public async Task<List<Enterprise>> GetEnterprises()
        {
            return await ApiRest.GetRestAsync<List<Enterprise>>("Enterprise").ConfigureAwait(false);
        }

        public async Task<Enterprise> GetEnterprise(int? id)
        {
            return await ApiRest.GetRestAsync<Enterprise>($"Enterprise/{id}").ConfigureAwait(false);
        }

        public async Task<Enterprise> SaveEnterprise(Enterprise enterprise)
        {
            return await ApiRest.PostRestAsync<Enterprise>("Enterprise", enterprise).ConfigureAwait(false);
        }

        public async Task<Enterprise> UpdateEnterprise(int id, Enterprise enterprise)
        {
            return await ApiRest.PutRestAsync<Enterprise>($"Enterprise/{id}", enterprise).ConfigureAwait(false);
        }

        public async Task<Enterprise> DeleteEnterprise(int id)
        {
            return await ApiRest.DeleteRestAsync<Enterprise>($"Enterprise/{id}").ConfigureAwait(false);
        }
    }
}
