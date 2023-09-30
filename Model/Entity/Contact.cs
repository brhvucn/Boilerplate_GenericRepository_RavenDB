using Boilerplate_GenericRepository_RavenDB.Model.Common;

namespace Boilerplate_GenericRepository_RavenDB.Model.Entity
{
    public class Contact : BaseEntity
    {
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
    }
}
