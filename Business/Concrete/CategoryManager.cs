using Business.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;

namespace Business.Concrete
{       //dış dünyaya servis için iş kodlarının yazıldıgı kısım.
    public class CategoryManager : ICategoryService   
    {
        //Business katmanı DataAccese bağlılıgını minimalıze etmek için./(baska servislerede uyum için yani)
        //Bağımlılığı constructor ile yapıcaz. 
        ICategoryDal _categoryDal;

        public CategoryManager(ICategoryDal categoryDal)    
        {                                                   
            _categoryDal = categoryDal;
        }

        public IDataResult<List<Category>> GetAll()
        {
            return new SuccessDataResult<List<Category>>(_categoryDal.GetAll());
        }

        public  IDataResult<Category> GetById(int categoryId)
        {
            return new SuccessDataResult<Category> (_categoryDal.Get(c => c.CategoryId == categoryId));     
        }
    }
}
