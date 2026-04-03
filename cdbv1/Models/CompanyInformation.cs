using System;
using System.Collections.Generic;
using System.Text;

namespace cdbv1.Models
{
    public class CompanyInformation()
    {
        // the required keyword mandates that callers must
        // set those properties as part of a new expression:
        public required int Id { get; set; }
        public required string Name { get; set; }
        public required string Description { get; set; }
        public required string JobBoardLink { get; set; }
    }
}


// var companyInfo = new CompanyInformation() { 
// Id = 1, Name = "SpaceX", Description = "a space company", JobBoardLink = "www.spacex.com/career"
// };