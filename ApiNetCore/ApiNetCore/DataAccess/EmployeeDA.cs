using ApiNetCore.ModelsDC;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiNetCore.DataAccess
{
    public class EmployeeDA
    {
        private readonly pr_canalesContext _context;

        public EmployeeDA(pr_canalesContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Obtener todos
        /// </summary>
        /// <returns>Objeto respuesta</returns>
        public async Task<IEnumerable<Employee>> GetEmployees()
        {
            return await _context.Employees.ToListAsync();
        }

        /// <summary>
        /// Obtener un objeto por id
        /// </summary>
        /// <param name="id">identificador</param>
        /// <returns>Objeto respuesta</returns>
        public async Task<Employee> GetEmployee(int id)
        {
            return await _context.Employees.FindAsync(id);
        }

        /// <summary>
        /// Actulizar datos
        /// </summary>
        /// <param name="id">Identificador</param>
        /// <param name="employee">Objeto a procesar</param>
        /// <returns>Objeto respuesta</returns>
        public async Task<int> PutEmployee(int id, Employee employee)
        {
            _context.Entry(employee).State = EntityState.Modified;
            return await _context.SaveChangesAsync();
        }

        /// <summary>
        /// Agregar un nuevo objeto
        /// </summary>
        /// <param name="employee">nuevo objeto</param>
        /// <returns>Objeto respuesta</returns>
        public async Task<Employee> PostEmployee(Employee employee)
        {
            _context.Employees.Add(employee);
            await _context.SaveChangesAsync();
            return employee;
        }

        /// <summary>
        /// Eliminar un objeto
        /// </summary>
        /// <param name="id">Identificador</param>
        /// <returns>bjeto respuesta</returns>
        public async Task<int> DeleteEmployee(int id)
        {
            var employee = await _context.Employees.FindAsync(id);
            _context.Employees.Remove(employee);
            return await _context.SaveChangesAsync();
        }
    }
}
