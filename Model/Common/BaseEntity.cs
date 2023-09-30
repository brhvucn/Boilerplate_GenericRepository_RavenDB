namespace Boilerplate_GenericRepository_RavenDB.Model.Common
{
    public class BaseEntity
    {
        public BaseEntity()
        {
            this.Id = new Guid().ToString();
        }
        public string Id { get; set; }
    }
}
