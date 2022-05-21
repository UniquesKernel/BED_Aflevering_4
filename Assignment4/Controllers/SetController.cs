using Assignment4.Models.DTOs;
using Assignment4.Services;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;

namespace Assignment4.Controllers
{
    [Route("/sets")]
    [ApiController]
    public class SetController : Controller
    {
        HeartstoneService db = new HeartstoneService();
        
        [HttpGet]
        public async Task<ActionResult<IEnumerable<string>>> GetSet()
        {
            var metaData = await db._metaData.FindAsync<MetaData>(r => true);
            var set = metaData.First().Sets;
            List<string> sets = new List<string>();
            foreach (var item in set)
                sets.Add(item.Name);

            return sets;
            
        }
    }
}
