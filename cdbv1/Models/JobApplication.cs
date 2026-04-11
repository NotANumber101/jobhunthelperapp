using System;
using System.Collections.Generic;
using System.Text;

namespace cdbv1.Models
{
    public class JobApplication()
    {
        public int Id { get; set; }
        public required string CompanyName { get; set; }
        public required string CurrentStatus { get; set; }
        public DateTime CurrentStatusDate { get; set; }
        // public DateTime CurrentStatusDate { get; set; }
        public required string JobDescription { get; set; }
    }
    // enum CurrentStatus
    // {
    //     Applied,
    //     Rejected,
    //     InterviewScheduled
    // }
}