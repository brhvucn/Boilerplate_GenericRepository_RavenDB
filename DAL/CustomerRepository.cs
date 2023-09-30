using Boilerplate_GenericRepository_RavenDB.DAL.Contracts;
using Boilerplate_GenericRepository_RavenDB.Model.Entity;
using Raven.Client.Documents;

namespace Boilerplate_GenericRepository_RavenDB.DAL
{
    public class CustomerRepository : Repository<Customer>, ICustomerRepository
    {
        public CustomerRepository(IDocumentStore documentStore) : base(documentStore)
        {
        }
    }
}
