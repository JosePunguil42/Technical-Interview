using System;
using System.Collections.Generic;

#nullable disable

namespace ApiNetCore.ModelsDC
{
    public partial class DepartmentsEmployee
    {
        public int Id { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreateDate { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public int? StatusDep { get; set; }
        public int? IdDepartment { get; set; }
        public int? IdEmployee { get; set; }

        public virtual Department IdDepartmentNavigation { get; set; }
        public virtual Employee IdEmployeeNavigation { get; set; }
    }
}
