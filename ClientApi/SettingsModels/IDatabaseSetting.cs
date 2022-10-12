namespace ClientApi.SettingsModels
{

    public class DatabaseSettings
    {
        public string ConnectionURI { get; set; } = null!;
        public string CollectionName { get; set; } = null!;
        public string DatabaseName { get; set; } = null!;
        public string PostCollection { get; set; } = null!;
        public string CategoryCollection { get; set; } = null!;
    }
}
