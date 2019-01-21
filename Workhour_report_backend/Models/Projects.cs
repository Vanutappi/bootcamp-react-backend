using System;
using System.Collections.Generic;

namespace Workhour_report_backend.Models
{
    public partial class Projects
    {
        public Projects()
        {
            Workhours = new HashSet<Workhours>();
        }

        public int ProjectId { get; set; }
        public string ProjectName { get; set; }

        public ICollection<Workhours> Workhours { get; set; }
    }
}
