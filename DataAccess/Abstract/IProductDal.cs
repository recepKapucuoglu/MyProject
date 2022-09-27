using Core.DataAccess;
using Entities.Concrete;   // entities katmanındaki product'i referans verdik.
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Abstract
{
    public interface IProductDal:IEntityRepository<Product>   // product classı ile ilgili extra operasyonları (join işlemleri vs.) içeren interface.(ekleme,listeleme vs.) 
   {     
        List<ProductDetailDto> GetProductDetails();
    }
}

