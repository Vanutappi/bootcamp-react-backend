﻿using System;
using System.Collections.Generic;

namespace Workhour_report_backend.Models
{
    public partial class HelperClass
    {
        public int WorkhourId { get; set; }
        public int? EmployeeId { get; set; }
        public int? ProjectId { get; set; }
        public DateTime? Date { get; set; }
        public int? Hours { get; set; }
        public string EmployeeName { get; set; }
        public string ProjectName { get; set; }
    }
}
