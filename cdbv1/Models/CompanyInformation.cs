using System;
using System.Collections.Generic;
using System.Text;

namespace cdbv1.Models
{
    public class CompanyInformation()
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public required string JobBoardLink { get; set; }
        public required string CompanyDescription { get; set; }
    }
}