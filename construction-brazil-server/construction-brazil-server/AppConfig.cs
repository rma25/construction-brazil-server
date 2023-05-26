namespace construction_brazil_server
{
    public class AppConfig
    {
        public class ConnectionStringsConfig
        {
            public string DefaultConnection { get; set; }
            public int ConnectionTimeout { get; set; }
        }

        public class ElasticsearchConfig
        {
            public Uri Uri { get; set; }
            public string Username { get; set; }
            public string Password { get; set; }
            public int TimeoutMinutes { get; set; }
        }

        public class StorageAccountConfig
        {
            public string ConnectionString { get; set; }
            public string ContainerName { get; set; }
        }

        public class CorsPolicyConfig
        {
            public int TimeoutInMinutes { get; set; }
        }

        #region Properties
        public ConnectionStringsConfig ConnectionStrings { get; set; }
        public ElasticsearchConfig Elasticsearch { get; set; }
        public StorageAccountConfig StorageAccount { get; set; }
        public CorsPolicyConfig CorsPolicy { get; set; }
        #endregion
    }
}
