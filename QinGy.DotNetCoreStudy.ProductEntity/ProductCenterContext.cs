﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace QinGy.MarketPlatform.ProductCenterEntity
{
    public class ProductCenterContext : DbContext
    {

        //public ProductCenterContext()
        //{
        //    //  Database.EnsureCreated();  //确保数据库已生成（存在） 
        //}
        public ProductCenterContext(DbContextOptions<ProductCenterContext> options)
      : base(options)
        {
        }
        /// <summary>
        /// 配置
        /// </summary>
        /// <param name="optionsBuilder"></param>
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //string connectionString = "Server=127.0.0.1;DataBase=ProductCenter;User Id=root;password=123456";
            //optionsBuilder.UseMySql(connectionString);
            base.OnConfiguring(optionsBuilder);
        }

        #region Entity
        public virtual DbSet<Product> Product { get; set; }
        public virtual DbSet<Category> Category { get; set; }
        #endregion
    }
}
