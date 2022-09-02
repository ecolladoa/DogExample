using DogExample.Models;
using DogExample.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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
            var result = _context.Dogs
                        .OrderBy(dog => dog.DogNavigation.Name)
                        .ThenBy(dog => dog.BirthDate)
                        .Select(dog => new DogViewModel
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