using System;
using System.Collections.Generic;

#nullable disable

namespace ApiNetCore.ModelsDC
{
    public partial class Enterprise
    {
        public Enterprise()
        {
            Departments = new HashSet<Department>();
        }

        public int Id { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreateDate { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public int? StatusEnt { get; set; }
        public string AddressEnt { get; set; }
        public string NameEnt { get; set; }
        public string Phone { get; set; }

        public virtual ICollection<Department> Departments { get; set; }
    }
}
