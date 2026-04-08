using System;
using System.Collections.Generic;
using System.Text;

namespace cdbv1.Models
{
    public class DsaSolution(string Solution)
    {
        public int Id { get; set; }
        public int ProblemId {get; set; }
        public string Solution {get; set; } = Solution;
        public DateTime DateCompleted {get; set; }
    }
}


// namespace cdbv1.Models
// {
//     public class DsaSolution
//     {
//         public int Id { get; set; }
//         public int ProblemId { get; set; }
//         public string Solution { get; set; }
//         public DateTime DateCompleted { get; set; }
//     }
// }

// using System;
// using System.Collections.Generic;
// using System.Text;

// namespace ConsoleApp1.Models
// {
//     public class Item
//     {
//         public int Id { get; set; }
//         public string Name { get; set; }
//         public string Description { get; set; }
//     }
// }