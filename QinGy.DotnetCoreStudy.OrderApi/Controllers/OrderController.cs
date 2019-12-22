using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using QinGy.DotnetCoreStudy.OrderApi.Model;

namespace QinGy.DotnetCoreStudy.OrderApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrderController : ControllerBase
    {
 

        private readonly ILogger<OrderController> _logger;

        public OrderController(ILogger<OrderController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public List<OrderInfo> GetAllOrder()
        {
            return null;
        }

        public void AddOrder()
        { 
        
        }
    }
}
