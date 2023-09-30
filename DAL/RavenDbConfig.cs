using Raven.Client.Documents;

namespace Boilerplate_GenericRepository_RavenDB.DAL
{
    public class RavenDbConfig
    {
        public static IDocumentStore Initialize()
        {
            var store = new DocumentStore
            {
                Urls = new[] { "http://localhost:8090" }, // Replace with your RavenDB server URL
                Database = "BoilerplateRepository", // Replace with your database name
                Conventions =
            {
                // Customize conventions if needed
                FindIdentityProperty = property => property.Name == "Id"
            }
            }.Initialize();

            return store;
        }
    }
}
