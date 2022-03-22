using System;
using System.Collections.Generic;

#nullable disable

namespace ApiNetCore.ModelsDC
{
    public partial class Department
    {
        public Department()
        {
            DepartmentsEmployees = new HashSet<DepartmentsEmployee>();
        }

        public int Id { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreateDate { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public int? StatusDep { get; set; }
        public string DescriptionDep { get; set; }
        public string NameDep { get; set; }
        public string Phone { get; set; }
        public int? IdEnterprise { get; set; }

        public virtual Enterprise IdEnterpriseNavigation { get; set; }
        public virtual ICollection<DepartmentsEmployee> DepartmentsEmployees { get; set; }
    }
}
