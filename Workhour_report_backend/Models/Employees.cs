using System;
using System.Collections.Generic;

namespace Workhour_report_backend.Models
{
    public partial class Employees
    {
        public Employees()
        {
            Workhours = new HashSet<Workhours>();
        }

        public int EmployeeId { get; set; }
        public int? DepartmentId { get; set; }
        public string EmployeeName { get; set; }
        public DateTime? StartDate { get; set; }

        public Departments Department { get; set; }
        public ICollection<Workhours> Workhours { get; set; }
    }
}
