using System;
using System.Collections.Generic;
using System.Text;

namespace cdbv1.Models
{
    public class ContactMessage
    {
        public int Id { get; set; }
        public int ContactId {get; set; }
        public string? Title { get; set; }
        public string? Body { get; set; }
        public string? DateOfMessage { get; set; }
        public string? Platform { get; set; }
    }
}