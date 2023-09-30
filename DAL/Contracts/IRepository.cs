using Boilerplate_GenericRepository_RavenDB.Model.Common;

namespace Boilerplate_GenericRepository_RavenDB.DAL.Contracts
{
    public interface IRepository<T> where T : BaseEntity
    {
        void Add(T entity);
        void Update(T entity);
        void Delete(string id);
        T GetById(string id);
        IEnumerable<T> GetAll();
    }
}
