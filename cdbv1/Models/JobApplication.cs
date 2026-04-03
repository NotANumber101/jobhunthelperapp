using System;
using System.Collections.Generic;
using System.Text;

namespace cdbv1.Models
{
    public class JobApplication(int Id, int CompanyId, string CurrentStatus, string CurrentStatusDate, string JobLocation, string JobTitle, string JobDescription)
    {
        public int Id { get; set; } = Id;
        public int CompanyId { get; set; } = CompanyId;
        public string CurrentStatus { get; set; } = CurrentStatus;
        public string CurrentStatusDate { get; set; } = CurrentStatusDate;
        public string JobLocation { get; set; } = JobLocation;
        public string JobTitle { get; set; } = JobTitle;
        public string JobDescription { get; set; } = JobDescription;
    }
    enum CurrentStatus
    {
        Applied,
        Rejected,
        InterviewScheduled
    }
}