using System;
using System.Collections.Generic;

#nullable disable

namespace ApiNetCore.ModelsDC
{
    public partial class Employee
    {
        public Employee()
        {
            DepartmentsEmployees = new HashSet<DepartmentsEmployee>();
        }

        public int Id { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreateDate { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public int? StatusEmp { get; set; }
        public int? Age { get; set; }
        public string Email { get; set; }
        public string NameEmp { get; set; }
        public string Position { get; set; }
        public string Surname { get; set; }

        public virtual ICollection<DepartmentsEmployee> DepartmentsEmployees { get; set; }
    }
}
