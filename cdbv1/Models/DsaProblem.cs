using System;
using System.Collections.Generic;
using System.Text;

namespace cdbv1.Models
{
    public class DsaProblem(int Id, string Name, string Difficulty, string Topic, string Description, DateTime DateCompleted)
    {
        public int Id { get; set; } = Id;
        public string Name { get; set; } = Name;
        public string Difficulty { get; set; } = Difficulty;
        public string Topic { get; set; } = Topic;
        public string Description { get; set; } = Description;
        public DateTime DateCompleted {get; set; } = DateCompleted;
    }
}