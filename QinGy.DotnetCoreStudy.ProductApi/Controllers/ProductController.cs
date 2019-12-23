using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using QinGy.MarketPlatform.ProductCenterApi.Model;

namespace QinGy.MarketPlatform.ProductCenterApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly ILogger<ProductController> _logger;

        public ProductController(ILogger<ProductController> logger)
        {
            _logger = logger;
        }

        /// <summary>
        /// 获取产品
        /// </summary>
        /// <returns></returns>
        [HttpGet("getallproduct")]
        public List<Product> GetAllProduct()
        {
            var productList = new List<Product>();
            productList.Add(new Product() {
                Id = Guid.NewGuid(),
                Title = "My Book 移动硬盘8T/10T/12T/20T/24T 3.5英寸桌面硬盘加密 6TB",
                Description = "<p>My Book 移动硬盘8T/10T/12T/20T/24T 3.5英寸桌面硬盘加密 6TB",
                CategoryId = new Guid("D690F3AF-02AE-49E1-B148-6CAFBFA513B6"),
                Price=500,
                ProductType=ItemType.Variation,
                Created = new DateTime(2019, 12, 22, 11, 18,0),
                LastModified = new DateTime(2019, 12, 22, 11, 18,0),
            }) ;
            return productList;
        }
    }
}
