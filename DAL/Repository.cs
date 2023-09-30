using Boilerplate_GenericRepository_RavenDB.DAL.Contracts;
using Boilerplate_GenericRepository_RavenDB.Model.Common;
using Raven.Client.Documents;

namespace Boilerplate_GenericRepository_RavenDB.DAL
{
    public class Repository<T> : IRepository<T> where T : BaseEntity
    {
        private readonly IDocumentStore _documentStore;

        public Repository(IDocumentStore documentStore)
        {
            _documentStore = documentStore ?? throw new ArgumentNullException(nameof(documentStore));
        }

        public void Add(T entity)
        {
            using var session = _documentStore.OpenSession();
            session.Store(entity);
            session.SaveChanges();
        }

        public void Update(T entity)
        {
            using var session = _documentStore.OpenSession();
            session.Store(entity);
            session.SaveChanges();
        }

        public void Delete(string id)
        {
            using var session = _documentStore.OpenSession();
            var entity = session.Load<T>(id);
            if (entity != null)
            {
                session.Delete(entity);
                session.SaveChanges();
            }
        }

        public T GetById(string id)
        {
            using var session = _documentStore.OpenSession();
            return session.Load<T>(id);
        }

        public IEnumerable<T> GetAll()
        {
            using var session = _documentStore.OpenSession();
            return session.Query<T>().ToList();
        }
    }
}
