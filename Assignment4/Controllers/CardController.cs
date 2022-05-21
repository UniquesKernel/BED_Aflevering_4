using Assignment4.Models.DTOs;
using Assignment4.Models.Entities;
using Assignment4.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MongoDB.Driver;

namespace Assignment4.Controllers
{
    [Route("cards")]
    [ApiController]
    public class CardController : Controller
    {
        HeartstoneService db = new HeartstoneService();

        [HttpGet]
        public async Task<ActionResult<IEnumerable<efCard>>> GetCards(
            string? setid = "",
            string? artist = "",
            string? classid = "",
            string? rarityid = "",
            int page = 1)
        {
            var cards = await db._card.FindAsync(c => c.Id > 0);
            var cardList = cards.ToList();

            var result = ConvertCard(cardList);
            
            if (setid != "")
                result = result.Where(result => result.SetId == setid).ToList();

            if (artist != "")
                result = result.Where(result => result.Artist == artist).ToList();

            if (classid != "")
                result = result.Where(result => result.ClassId == classid).ToList();

            if (rarityid != "")
                result = result.Where(result => result.RarityId == rarityid).ToList();
            
            var perPage = 100;
            int maxPage = result.Count() / perPage;
            var minPerPage = result.Count() % perPage ;

            if (page > maxPage)
            {
                page = (maxPage + 1);
                perPage = minPerPage;
            }

            var newList = result.GetRange((--page)*perPage,(perPage));

            return newList;
        }
        
        private List<efCard> ConvertCard(List<Card> cards)
        {
            var result = new List<efCard>();
            var metaData = db._metaData.Find(r => true).First();

            int i = 0;
            foreach (var card in cards)
            {
                i++;
                efCard tempEfCard = new efCard(card);
                tempEfCard.ClassId = metaData.Classes.Find(r => r.Id == card.ClassId).Name;
                tempEfCard.TypeId = metaData.CardTypes.Find(r => r.Id == card.CardTypeId).Name;
                
                // This is specifically put in place to work around the missing set data.
                if (metaData.Sets.Exists(r => r.Id == card.CardSetId))
                {
                    tempEfCard.SetId = metaData.Sets.Find(r => r.Id == card.CardSetId).Name;
                }
                else
                {
                    tempEfCard.SetId = "Missing Set";
                }

                tempEfCard.RarityId = metaData.Rarities.Find(r => r.Id == card.RarityId).Name;

                result.Add(tempEfCard);
            }

            return result;
        }


    }
}
