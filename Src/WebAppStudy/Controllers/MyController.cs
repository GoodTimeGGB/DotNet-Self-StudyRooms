using Microsoft.AspNetCore.Mvc;
using WebApiStudy.Api.Filter;
using WebApiStudy.Service.Interface;

namespace WebApiStudy.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [ServiceFilter(typeof(MyFilter))]
    public class MyController : ControllerBase
    {
        private readonly IMyService  _myService;

        public MyController(IMyService myService)
        {
            _myService = myService;
        }

        [HttpGet]
        public IActionResult DoSomething()
        {
            var result = _myService.DoSomething();
            return Content(result);
        }
    }
}
