using Boilerplate_GenericRepository_RavenDB.Model.Common;

namespace Boilerplate_GenericRepository_RavenDB.Model.Entity
{
    public class Customer : AggregateRoot
    {
        public string CompanyName { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;
        public string Region { get; set; } = string.Empty;
        public string PostalCode { get; set; } = string.Empty;
        public string Country { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public List<Contact> Contacts { get; set; } = new List<Contact>();

        public void AddContact(Contact contact)
        {
            Contacts.Add(contact);
        }
    }
}
