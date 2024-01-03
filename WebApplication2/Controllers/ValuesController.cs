using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication2.Services;

namespace WebApplication2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        /*
         Padarykite kad irasius nauja reiksme per POST ji butu issaugoma ir grazinama per GET metoda
         - Duomenu bazes nenaudoti
         - Sukurkite servisa ir naudokite Dependency Injection
        */
        //List<string> values = new List<string> { "value1", "value2" };

        private readonly IUzduotisValuesServices _service;

        public ValuesController(IUzduotisValuesServices service)
        {
            _service = service;
        }



        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return _service.Values;
        }
        [HttpPost]
        public ActionResult Post([FromBody] string value)
        {
            _service.Values.Add(value);
            Console.WriteLine(string.Join(", ", _service.Values));
            return Ok();
        }
    }
}