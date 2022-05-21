using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.Text.Json.Serialization;

namespace Assignment4.Models.DTOs
{
    public class Set
	{
		[BsonId]
		[BsonRepresentation(BsonType.Int32)]
		public int Id { get; set; }
		[BsonElement("Name")]
		public String Name { get; set; }
		[BsonElement("Type")]
		public String Type { get; set; }
		[BsonElement("CollectibleCount")]
		[JsonPropertyName("CollectibleCount")]
		public int CardCount { get; set; }
	}
}
