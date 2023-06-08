using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IFSConsole.Models
{
    public class LeadClass
    {
        public string LeadId { get; set; }
        public string Subject { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Company { get; set; }
        public string Website { get; set; }
        public Address Address { get; set; }
    }
    public class Address
    {
        public string Address_Line1 { get; set; }
        public string Address_Line2 { get; set; }
        public string Address_Line3 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Postal_Code { get; set; }
        public string Country { get; set; }
    }
}
