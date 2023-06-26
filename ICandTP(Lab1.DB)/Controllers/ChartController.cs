using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ICandTP_Lab1.DB_.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChartController : ControllerBase
    {
        private readonly DbcarsSearchContext _context;

        public ChartController(DbcarsSearchContext context)
        {
            _context = context;
        }
        [HttpGet("JsonData")]

        public JsonResult JsonData()
        {
            var countries =_context.Countries.ToList();
            List<object> counBrand = new List<object>();
            counBrand.Add(new[] { "Країна", "Марка" });
            foreach (var c in countries) 
            { 
                counBrand.Add(new object[] { c.CountryName, c.Brands.Count() });
            }
            return new JsonResult(counBrand);
        }
    }
}
