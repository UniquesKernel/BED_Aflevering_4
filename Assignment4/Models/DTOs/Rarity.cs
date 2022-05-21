using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
namespace Assignment4.Models.DTOs
{
	public class Rarity
	{
		[BsonId]
		[BsonRepresentation(BsonType.Int32)]
		public int Id { get; set; }
		[BsonElement("Name")]
		public String Name { get; set; }
	}
}
