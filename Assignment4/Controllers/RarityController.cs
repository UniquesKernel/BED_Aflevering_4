using Assignment4.Models.DTOs;
using Assignment4.Services;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;

namespace Assignment4.Controllers
{
    [Route("/rarities")]
    [ApiController]
    public class RarityController : Controller
    {
        HeartstoneService db = new HeartstoneService();

        [HttpGet]
        public async Task<ActionResult<IEnumerable<string>>> Index()
        { 
            var metaData = await db._metaData.FindAsync<MetaData>(r => true);
            var data = metaData.First().Rarities;
            List<string> rarities = new List<string>();

            foreach (var r in data)
                rarities.Add(r.Name);
            return rarities;
        }
    }
}
