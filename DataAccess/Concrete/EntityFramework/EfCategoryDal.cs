using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{   
    //ICategoryDal ın referans olmasının nedeni= ozel sorguları gerçekleştirecek operasyonlary  yazmak.
    public class EfCategoryDal:EfEntityRepositoryBase<Category,NorthwindContext>,ICategoryDal   
    {
      
    }
}
 