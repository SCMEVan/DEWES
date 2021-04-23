using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace RemoteDataSourceTest.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TestController : ControllerBase
    {


        public TestController()
        {
        }

        [HttpGet]
        public List<(string,string)> GetFormats()
        {
            return null;
        }
    }
}