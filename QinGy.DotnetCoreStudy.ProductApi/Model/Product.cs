using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QinGy.DotnetCoreStudy.ProductApi.Model
{
    /// <summary>
    /// 产品
    /// </summary>
    public class Product
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public ItemType ProductType { get; set; }
        public Guid CategoryId { get; set; }
        public int Verison { get;  set; }
        public DateTime Created { get; set; }
        public DateTime LastModified { get; set; }
    }
    /// <summary>
    /// 新增产品
    /// </summary>
    public class AddProductRequest
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; } 
        public ItemType ProductType { get; set; }
        public Guid CategoryId { get; set; }
    }

    /// <summary>
    /// 编辑产品
    /// </summary>
    public class EditProductRequest {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public ItemType ProductType { get; set; }
        public Guid CategoryId { get; set; }
    }
  
}
