using CordycepsServices.Models;
using CordycepsServices.Services.InfectedService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CordycepsServices.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InfectedController : ControllerBase
    {
        // Singleton Stores objects during the whole lifetime of the web api. _infectedService and
        // _infectedService2 are treated as the same service when you register this as a singleton.
        // So both return the same number on count (6). For the lifetime of the request, you have an instance of the service.
        // Because it lives throughout the lifetime of your api, if it crashes, could be the case that memory leaks occur.

        // Scoped service is created for every single HTTP request. Since List<Infected> InfectedList in InfectedServices
        // isn't static, the list is created again and again with every web service call(Post will only create a list of 4, renewing 4 every post).
        // (New instance with every call or request)_infectedService and _infectedService2 are the same instance.
        // To actually increase List size beyond 4, the list needs to be made static. Should probably use scoped. For get methods,
        // they return the original 3 elements. Scoped will be created with web service call and then shut down.

        // Transient gives you a new instance of service every time you call a method of the service. Because of this, every method returned 3.
        // Even the post method. If calling to many methods, could add up to lots of extra memory that is not needed.
        private readonly IInfectedService _infectedService;
        private readonly IInfectedService _infectedService2;

        public InfectedController(IInfectedService infectedService, IInfectedService infectedService2)
        {
            _infectedService = infectedService;
            _infectedService2 = infectedService2;
        }

        [HttpGet("/count")]
        public ActionResult<int> GetInfectedCount()
        {
            return _infectedService.GetInfectedCount();
        }

        [HttpGet]
        public ActionResult<List<Infected>> GetInfectedList()
        {
            return _infectedService.GetInfectedList();
        }

        [HttpPost]
        public ActionResult<List<Infected>> IncreaseInfected()
        {
            _infectedService.IncreaseInfected();
            return _infectedService2.GetInfectedList();
        }
    }
}
