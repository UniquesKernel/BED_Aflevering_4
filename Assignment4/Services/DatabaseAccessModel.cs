namespace Assignment4.Services
{
    public class DatabaseAccessModel
    {
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
        public string CardCollection { get; set; }
        public string MetaDataCollection { get; set; }

        public DatabaseAccessModel()
        {
            var _configuration = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build().GetSection("DatabaseSetting");
            ConnectionString = _configuration["ConnectionString"];
            DatabaseName = _configuration["HeartstoneDB"];
            CardCollection = _configuration["CardCollection"];
            MetaDataCollection = _configuration["MetaCollection"];
        }
    }
}
