using System;
using System.Collections.Generic;
using System.Text;

namespace cdbv1.Models
{
    // public class JobApplication(string CompanyName, string CurrentStatus, string CurrentStatusDate, string JobLocation, string JobTitle, string JobDescription)
    public class JobApplication()
    {
        public int Id { get; set; }
        public string CompanyName { get; set; }
        public string CurrentStatus { get; set; }
        public DateTime CurrentStatusDate { get; set; }
        public string JobLocation { get; set; }
        public string JobTitle { get; set; }
        public string JobDescription { get; set; }
    }
    // enum CurrentStatus
    // {
    //     Applied,
    //     Rejected,
    //     InterviewScheduled
    // }
}