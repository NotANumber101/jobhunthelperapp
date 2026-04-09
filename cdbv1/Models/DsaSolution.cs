using System;
using System.Collections.Generic;
using System.Text;

namespace cdbv1.Models
{
    public class DsaSolution(string Solution)
    {
        public required int Id { get; set; }
        public int ProblemId {get; set; }
        public string Solution {get; set; } = Solution;
        public DateTime DateCompleted {get; set; }
    }
}