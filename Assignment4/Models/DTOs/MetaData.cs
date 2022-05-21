using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
namespace Assignment4.Models.DTOs
{
    public class MetaData
    {
        [BsonId]
        [BsonRepresentation(BsonType.Int32)]
        public int Id { get; set; }
        [BsonElement("CardTypes")]
        public List<CardType> CardTypes { get; set; }
        [BsonElement("Sets")]
        public List<Set> Sets { get; set; }
        [BsonElement("Rarities")]
        public List<Rarity> Rarities { get; set; }
        [BsonElement("Classes")]
        public List<Class> Classes { get; set; }
	
        public MetaData(List<CardType> cardTypes, List<Set> sets, List<Rarity> rarities, List<Class> classes)
        {
            CardTypes = cardTypes;
			Sets = sets;
			Rarities = rarities;
            Classes = classes;
        }
    }
}
