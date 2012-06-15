using Raven.Abstractions.Data;
using Raven.Client.Document;
using Raven.Client.Extensions;
using Raven.Client.Indexes;

namespace MiniCms.Services.RavenDb
{
    public class RavenInitializer
    {
        private RavenInitializer() { }
        private static readonly DocumentStore _instance = GetDocumentStore();
        public static DocumentStore Instance
        {
            get { return _instance; }
        }

        private static DocumentStore GetDocumentStore()
        {
            var parser = ConnectionStringParser<RavenConnectionStringOptions>.FromConnectionStringName("RavenDB");
            parser.Parse();
            var store = new DocumentStore
                            {
                                ApiKey = parser.ConnectionStringOptions.ApiKey,
                                Url = parser.ConnectionStringOptions.Url,
                            };
            //_store = new DocumentStore { ConnectionStringName = DatabaseName };
            store.Initialize();
            store.Conventions.IdentityPartsSeparator = "-";
            //store.DatabaseCommands.EnsureDatabaseExists("RavenDb");
            //Raven.Client.MvcIntegration.RavenProfiler.InitializeFor(store);
            return store;
        }

        public static void BuildIndexes()
        {
            IndexCreation.CreateIndexes(typeof(SearchIndex).Assembly, GetDocumentStore());
        }
    }
}
