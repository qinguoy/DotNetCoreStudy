using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace QinGy.DotnetCore.ApiGateWay.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SampleController : ControllerBase
    {
        [HttpGet]
        public string GetInformation()
        {
            return DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
        }
    }
}