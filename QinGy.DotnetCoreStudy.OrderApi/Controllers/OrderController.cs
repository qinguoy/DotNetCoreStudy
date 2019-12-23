using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using QinGy.MarketPlatform.OrderApi.Model;

namespace QinGy.MarketPlatform.OrderApi.Controllers
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

        [HttpGet("GetAllOrder")]
        public List<OrderInfo> GetAllOrder()
        {
            return null;
        }
        [HttpPost("addorder")]
        public void AddOrder()
        { 
        
        }
        [HttpPost("editorder")]
        public void EditOrder()
        { 
        
        }
        [HttpPost("combineorder")]
        public void CombineOrder() { 
        
        }
    }
}
