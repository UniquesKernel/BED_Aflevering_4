using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.Text.Json.Serialization;

namespace Assignment4.Models.DTOs
{
	public class Card
	{
		[BsonId]
		[BsonRepresentation(BsonType.Int32)]
		public int Id { get; set; }
		[BsonElement("ClassId")]
		public int ClassId { get; set; }
		[BsonElement("TypeId")]
		public int CardTypeId { get; set; }
		[BsonElement("SetId")]
		public int CardSetId { get; set; }
		[BsonElement("SpellSchoolId")]
		public int? SpellSchoolId { get; set; }
		[BsonElement("RarityId")]
		public int RarityId { get; set; }
		[BsonElement("Health")]
		public int? Health { get; set; }
		[BsonElement("Attack")]
		public int? Attack { get; set; }
		[BsonElement("ManaCost")]
		public int ManaCost { get; set; }
		[BsonElement("Artist")]
		public String ArtistName { get; set; }
		[BsonElement("Text")]
		public String Text { get; set; }
		[BsonElement("Flavor Text")]
		public String FlavorText { get; set; }
		[BsonElement("Name")]
		public String Name { get; set; }
	}
}
