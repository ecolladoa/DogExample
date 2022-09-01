using DogExample.Models;
using DogExample.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace DogExample.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HomeController : ControllerBase
    {
        private readonly DogExampleContext _context;

        public HomeController(DogExampleContext context)
        {
            _context = context;
        }

        [HttpGet("GetList")]
        public ActionResult<DogViewModel[]> GetList()
        {
            var result = (from dog in _context.Dogs
                          orderby dog.BirthDate ascending, dog.DogNavigation.Name ascending
                          select new DogViewModel()
                          {
                              DogID = dog.DogId,
                              Name = dog.Name,
                              BreedName = dog.DogNavigation.Name,
                              BirthDate = dog.BirthDate
                          }).ToArray();

            return Ok(result);
        }
    }
}