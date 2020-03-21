using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using QinGy.MarketPlatform.ProductCenterApi.Model;
using QinGy.MarketPlatform.ProductCenterService;

namespace QinGy.MarketPlatform.ProductCenterApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {
        //private readonly ILogger<ProductController> _logger;

        //public ProductController(ILogger<ProductController> logger)
        //{
        //    _logger = logger;
        //}

        private readonly ProductService _ProductService;

        public ProductController(ProductService service)
        {
            this._ProductService = service;
        }

        /// <summary>
        /// 获取产品
        /// </summary>
        /// <returns></returns>
        [HttpGet("getallproduct")]
        public List<ProductView> GetAllProduct()
        {
            var productList = new List<ProductView>();
            productList.Add(new ProductView()
            {
                Id = Guid.NewGuid(),
                Title = "My Book 移动硬盘8T/10T/12T/20T/24T 3.5英寸桌面硬盘加密 6TB",
                Description = "<p>My Book 移动硬盘8T/10T/12T/20T/24T 3.5英寸桌面硬盘加密 6TB",
                CategoryId = new Guid("D690F3AF-02AE-49E1-B148-6CAFBFA513B6"),
                Price = 500,
                ProductType = ItemType.Variation,
                Created = new DateTime(2019, 12, 22, 11, 18, 0),
                LastModified = new DateTime(2019, 12, 22, 11, 18, 0),
            });
            return productList;
        }
    }
}
