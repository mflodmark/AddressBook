using System.Collections.Generic;

namespace AddressBook.UI
{
    public class Contact
    {
        public string Name { get; set; }
        public string Type { get; set; }
        public List<EmailAddress> Email { get; set; } = new List<EmailAddress>();
        public List<Address> Addresses { get; set; } = new List<Address>();
        public List<Telephone> Telephones { get; set; } = new List<Telephone>();
    }
}