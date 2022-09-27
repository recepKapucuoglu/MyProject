using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfProductDal : EfEntityRepositoryBase<Product, NorthwindContext>, IProductDal // ıproductdal= joinler için.
    {
        public List<ProductDetailDto> GetProductDetails() 
        {
            using (NorthwindContext context=new NorthwindContext())  // database katmanına bağlan
            {
                var result = from p in context.Products   // products ları p diye 
                             join c in context.Categories // categoriesleri c diye kısalttık
                             on p.CategoryId equals c.CategoryId  // aynıysalar
                             select new ProductDetailDto // yeni bir clas sablonuna aşsagıdakileri yaz 
                             {
                                 ProductId = p.ProductId,
                                 ProductName = p.ProductName,
                                 CategoryName = c.CategoryName,
                                 UnitsInStock = p.UnitsInStock
                             };

                return result.ToList();
            }
        }
    }
}