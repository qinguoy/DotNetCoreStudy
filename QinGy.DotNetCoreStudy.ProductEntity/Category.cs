using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace QinGy.MarketPlatform.ProductCenterEntity
{
    /// <summary>
    /// 
    /// </summary>
    public class Category
    {
        [Key]
        public Guid Id { get; set; }
        [MaxLength(50)]
        public string Name { get; set; }
        public Guid? ParentId { get; set; }
        public int Level { get; set; }
        public bool Isleaf { get; set; }
        public DateTime Created { get; set; }
        public DateTime LastModified { get; set; }
    }
}
