using Assignment4.Models.DTOs;

namespace Assignment4.Models.Entities
{
    public class efCard
    {	
		public int Id { get; set; }
		public string? ClassId { get; set; }
		public string? TypeId { get; set; }
		public string? SetId { get; set; }
		public int? SpellSchoolId { get; set; }
		public string? RarityId { get; set; }
		public int? Health { get; set; }
		public int? Attack { get; set; }
		public int ManaCost { get; set; }
		public string Artist { get; set; }
		public string Text { get; set; }
		public string FlavorText { get; set; }
		public string Name { get; set; }
		
		public efCard(Card card)
        {
			Id = card.Id;
			SpellSchoolId = card.SpellSchoolId;
			Health = card.Health;
			Attack = card.Attack;
			ManaCost = card.ManaCost;
			Artist = card.ArtistName;
			Text = card.Text;
			FlavorText = card.FlavorText;
			Name = card.Name;
        }
	
    }
}
