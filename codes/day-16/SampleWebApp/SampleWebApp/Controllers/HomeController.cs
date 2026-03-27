using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using SampleWebApp.Data;
using SampleWebApp.Models;

namespace SampleWebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly IPeopleRepository repository;
        private readonly ILogger<HomeController> logger;

        public HomeController(IPeopleRepository repository, ILogger<HomeController> logger)
        {
            this.repository = repository;
            this.logger = logger;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var people = repository.People;

            //var dynamicObject = this.ViewBag;
            //dynamicObject.Data = people;

            //ViewDataDictionary dictionary = this.ViewData;
            //dictionary["Data"] = people;

            this.ViewData["Value"] = 100;

            ViewResult viewResult = this.View(people);
            return viewResult;
        }

        [HttpGet]
        public IActionResult About()
        {
            ViewResult viewResult = this.View();
            return viewResult;
        }

        [HttpGet]
        public IActionResult AddPerson()
        {
            return this.View();
        }

        [HttpPost]
        public IActionResult AddPerson([FromForm] Person person)
        {
            //logger.LogInformation(person.Name);
            try
            {
                //throw new Exception("error occurred");
                repository.People.Add(person);
                return this.RedirectToAction("Index");
            }
            catch (Exception e)
            {
                return RedirectToPage("Error");
            }
        }
    }
}
