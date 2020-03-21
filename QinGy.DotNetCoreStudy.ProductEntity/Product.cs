using System;
using System.ComponentModel.DataAnnotations;

namespace QinGy.MarketPlatform.ProductCenterEntity
{
    /// <summary>
    /// 产品
    /// </summary>
    public class Product
    {
        public Guid Id { get; set; }
        [MaxLength(50)]
        public string Sku { get; set; }
        [MaxLength(80)]
        public string ProductId { get; set; }
        [MaxLength(250)]
        public string Title { get; set; }
        [MaxLength(2000)]
        public string Description { get; set; }
        [MaxLength(250)]
        public string Tags { get; set; } 
        public Guid CategoryId { get; set; }
        public decimal Price { get; set; }
        [MaxLength(100)]
        public string Msrp { get; set; }
        [MaxLength(250)]
        public string MainImage { get; set; }
        [MaxLength(250)]
        public string CleanImage { get; set; }
        [MaxLength(500)]
        public string ExtraImage { get; set; }
        [MaxLength(80)]
        public string Brand { get; set; }
        [MaxLength(80)]
        public string Upc { get; set; }
        public double Length { get; set; }
        public double Width { get; set; }
        public double Height { get; set; }
        public ProductTypeEnum Status { get; set; }
        public int ProductType { get; set; }
        public DateTime Created { get; set; }
        public DateTime LastModified { get; set; }

    }
}
