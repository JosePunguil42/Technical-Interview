using ApiNetCore.ModelsDC;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiNetCore.DataAccess
{
    public class EnterpriseDA
    {
        private readonly pr_canalesContext _context;

        public EnterpriseDA(pr_canalesContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Obtener todos
        /// </summary>
        /// <returns>Objeto respuesta</returns>
        public async Task<IEnumerable<Enterprise>> GetEnterprises()
        {
            return await _context.Enterprises.ToListAsync();
        }

        /// <summary>
        /// Obtener un objeto por id
        /// </summary>
        /// <param name="id">identificador</param>
        /// <returns>Objeto respuesta</returns>
        public async Task<Enterprise> GetEnterprise(int id)
        {
            return await _context.Enterprises.FindAsync(id);
        }

        /// <summary>
        /// Actulizar datos
        /// </summary>
        /// <param name="id">Identificador</param>
        /// <param name="enterprise">Objeto a procesar</param>
        /// <returns>Objeto respuesta</returns>
        public async Task<int> PutEnterprise(int id, Enterprise enterprise)
        {
            _context.Entry(enterprise).State = EntityState.Modified;
            return await _context.SaveChangesAsync();
        }

        /// <summary>
        /// Agregar un nuevo objeto
        /// </summary>
        /// <param name="enterprise">nuevo objeto</param>
        /// <returns>Objeto respuesta</returns>
        public async Task<Enterprise> PostEnterprise(Enterprise enterprise)
        {
            _context.Enterprises.Add(enterprise);
            await _context.SaveChangesAsync();
            return enterprise;
        }

        /// <summary>
        /// Eliminar un objeto
        /// </summary>
        /// <param name="id">Identificador</param>
        /// <returns>bjeto respuesta</returns>
        public async Task<int> DeleteEnterprise(int id)
        {
            var enterprise = await _context.Enterprises.FindAsync(id);
            _context.Enterprises.Remove(enterprise);
            return await _context.SaveChangesAsync();
        }
    }
}
