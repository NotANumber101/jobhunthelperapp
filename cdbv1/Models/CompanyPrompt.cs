using System;
using System.Collections.Generic;
using System.Text;

namespace cdbv1.Models
{
    public class CompanyPrompt
    {
        public int Id { get; set; }
        public int CompanyId { get; set; }
        public string? Prompt { get; set; }
        public string? Response { get; set; }
    }
}