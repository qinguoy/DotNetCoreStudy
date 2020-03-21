using QinGy.MarketPlatform.ProductCenterEntity;
using System;
using System.Collections.Generic;
using System.Linq;

namespace QinGy.MarketPlatform.ProductCenterService
{
    public class ProductService
    {
        private readonly ProductCenterContext _DbContext = null;
        public ProductService(ProductCenterContext context)
        {
            this._DbContext = context;
        }


        /// <summary>
        /// get product by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Product GetProductById(Guid id)
        {
            return _DbContext.Product.FirstOrDefault(p => p.Id == id);
        }


        public List<Product> GetProductList()
        {
            return null;
        }

        public void AddProduct()
        {
            //TODO Add product
        }

        public void EditProduct()
        {
            //TODO edit product
        }

        public void DeleteProduct(Guid id)
        {
            var product = _DbContext.Product.FirstOrDefault(p => p.Id == id);
            _DbContext.Remove(product);
            _DbContext.SaveChanges();
        }

    }
}
