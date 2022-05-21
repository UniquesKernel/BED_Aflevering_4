using Assignment4.Models.DTOs;
using MongoDB.Driver;
using System.Text.Json;
using Microsoft.Extensions.Configuration;

namespace Assignment4.Services
{
    public class HeartstoneService
    {
        public IMongoCollection<Card> _card { get; }
        public IMongoCollection<MetaData> _metaData { get; }
        public DatabaseAccessModel settings = new DatabaseAccessModel();

        public HeartstoneService()
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);
            _card = database.GetCollection<Card>(settings.CardCollection);
            _metaData = database.GetCollection<MetaData>(settings.MetaDataCollection);

            if (!DatabaseExist(client, settings.DatabaseName))
            {
                client.DropDatabase(settings.DatabaseName);
                SeedMetaData();
                SeedDB();
            }
       }

        private bool DatabaseExist(MongoClient client, string databaseName)
        {
            var it = client.ListDatabaseNames().ToEnumerable().GetEnumerator();
            while (it.MoveNext())
            {
                if (it.Current == databaseName)
                { 
                    return true; }
            }
            return false;
        }
        public void clearDB()
        {
            
            _card.DeleteMany(c => true);
            _metaData.DeleteMany(c => true);
        }

        public void SeedDB()
        {
            SeedCards();
            SeedMetaData();
        }
                   

        private void SeedCards()
        {
            using (var file = new StreamReader("C:\\Users\\UniquesKernel\\Desktop\\BEDAssignment4\\HeartstoneDB\\HeartstoneDB\\Resources\\cards.json"))
            {
                var cards = JsonSerializer.Deserialize<List<Card>>(file.ReadToEnd(),
                    new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
                _card.InsertMany(cards);
            }

        }

        private void SeedMetaData()
        {
            using (var file = new StreamReader("C:\\Users\\UniquesKernel\\Desktop\\BEDAssignment4\\HeartstoneDB\\HeartstoneDB\\Resources\\metadata.json"))
            {
                var metaData = JsonSerializer.Deserialize<Dictionary<string, JsonElement>>(file.ReadToEnd(),
                    new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

                var setList = JsonSerializer.Deserialize<List<Set>>(metaData["Sets"], new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
                var cardTypeList = JsonSerializer.Deserialize<List<CardType>>(metaData["Types"], new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
                var rarityList = JsonSerializer.Deserialize<List<Rarity>>(metaData["Rarities"], new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
                var classList = JsonSerializer.Deserialize<List<Class>>(metaData["Classes"], new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
    
                var metaDataList = new MetaData(cardTypeList, setList, rarityList, classList);
                _metaData.InsertOne(metaDataList);
            }
        }
    }
}
