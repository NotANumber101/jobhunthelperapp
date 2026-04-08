using System;
using System.Collections.Generic;
using System.Text;

namespace cdbv1.Models
{
    public class PostMortem()
    {
        public int Id { get; set; }
        public int SolutionId { get; set; }
        public int DesignTimeMs { get; set; }
        public int CodeTimeMs { get; set; }
        public string Mistakes { get; set; } = "";
        public string Analysis { get; set; } = "";
        public int RubricProblemSolvingScore { get; set; }
        public int RubricCodingScore { get; set; }
        public int RubricVerificationScore { get; set; }
        public int RubricCommunicationScore { get; set; }
    }
}



