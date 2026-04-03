using System;
using System.Collections.Generic;
using System.Text;

namespace cdbv1.Models
{
    public class CompanyContact
    {
        public int Id { get; set; }
        public int CompanyId {get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
    }
}
