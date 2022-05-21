using Assignment4.Models.DTOs;
using Assignment4.Services;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;

namespace Assignment4.Controllers
{
    [Route("/classes")]
    [ApiController]
    public class ClassController : Controller
    {
        HeartstoneService db = new HeartstoneService();

        [HttpGet]
        public async Task<ActionResult<IEnumerable<string>>> Index()
        {
            var metaData = await db._metaData.FindAsync(r => true);
            var data = metaData.First().Classes;
            var classes = new List<string>();

            foreach (var item in data)
                classes.Add(item.Name);
            Console.WriteLine(classes);

            return classes;
        }
    }
}
