using Assignment4.Models.DTOs;
using Assignment4.Services;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;

namespace Assignment4.Controllers
{
    [Route("/types")]
    [ApiController]
    public class TypeController : Controller
    {
        HeartstoneService db = new HeartstoneService();

        [HttpGet]
        public async Task<ActionResult<IEnumerable<string>>> Index()
        {
            var metaData = await db._metaData.FindAsync(r => true);
            var data = metaData.First().CardTypes;
            var types = new List<string>();

            foreach (var type in data)
                types.Add(type.Name);
            return types;
        }
    }
}
