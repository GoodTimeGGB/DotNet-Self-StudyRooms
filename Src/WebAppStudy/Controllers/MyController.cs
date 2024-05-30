using Microsoft.AspNetCore.Mvc;
using WebApiStudy.Service.Interface;

namespace WebApiStudy.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
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
