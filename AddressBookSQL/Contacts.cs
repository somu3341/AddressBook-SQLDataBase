using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBookSQL
{
    public class Contacts
    {
        public int Id { get; set; }
        public string FirstName {  get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public Double Zip { get; set; }
        public Double PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
    }
}
