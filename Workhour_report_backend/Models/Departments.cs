using System;
using System.Collections.Generic;

namespace Workhour_report_backend.Models
{
    public partial class Departments
    {
        public Departments()
        {
            Employees = new HashSet<Employees>();
        }

        public int DepartmentId { get; set; }
        public string DepartmentName { get; set; }

        public ICollection<Employees> Employees { get; set; }
    }
}
