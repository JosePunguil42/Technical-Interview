using ApiNetCore.ModelsDC;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiNetCore.DataAccess
{
    /// <summary>
    /// Clase que contiene el crud para departamentos
    /// </summary>
    public class DepartmentDA
    {
        private readonly pr_canalesContext _context;

        public DepartmentDA(pr_canalesContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Obtener todos
        /// </summary>
        /// <returns>Objeto respuesta</returns>
        public async Task<IEnumerable<Department>> GetDepartments()
        {
            return await _context.Departments.ToListAsync();
        }

        /// <summary>
        /// Obtener un objeto por id
        /// </summary>
        /// <param name="id">identificador</param>
        /// <returns>Objeto respuesta</returns>
        public async Task<Department> GetDepartment(int id)
        {
            return await _context.Departments.FindAsync(id);
        }

        /// <summary>
        /// Actulizar datos de un departamento
        /// </summary>
        /// <param name="id">Identificador</param>
        /// <param name="department">Objeto a procesar</param>
        /// <returns>Objeto respuesta</returns>
        public async Task<int> PutDepartment(int id, Department department)
        {
            _context.Entry(department).State = EntityState.Modified;
            return await _context.SaveChangesAsync();
        }

        /// <summary>
        /// Agregar un nuevo objeto
        /// </summary>
        /// <param name="department">nuevo objeto</param>
        /// <returns>Objeto respuesta</returns>
        public async Task<Department> PostDepartment(Department department)
        {
            _context.Departments.Add(department);
            await _context.SaveChangesAsync();
            return department;
        }

        /// <summary>
        /// Eliminar un objeto
        /// </summary>
        /// <param name="id">Identificador</param>
        /// <returns>bjeto respuesta</returns>
        public async Task<int> DeleteDepartment(int id)
        {
            var department = await _context.Departments.FindAsync(id);
            _context.Departments.Remove(department);
            return await _context.SaveChangesAsync();
        }

        private bool DepartmentExists(int id)
        {
            return _context.Departments.Any(e => e.Id == id);
        }
    }
}
