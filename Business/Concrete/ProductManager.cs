using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspect.Autofac.Caching;
using Core.Aspect.Autofac.Performance;
using Core.Aspect.Autofac.Transaction;
using Core.Aspect.Autofac.Validation;
using Core.CrossCuttingConcerns.Validation;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
 //busines birtek IPRODUCTDAL UZERİNDEN GİDER
namespace Business.Concrete
{// somut iş sınıfı kodları.
    public class ProductManager : IProductService
    {
        IProductDal _productDal; //  (interfacesini)referansını kullandık.cünkü başka bir yerden
        ICategoryService _categoryService;
      

        // başka zaman bir veri aktarımı gerekirse interface ile direk o referansa bağlı kalabiliriz.


        public ProductManager(IProductDal productDal,ICategoryService categoryService)  // constructor ile clas newlendiginde verileri direk oluştrudugumuz _productDal referansına gönderdik..
        {
            _productDal = productDal;
            _categoryService = categoryService;
        }

        [CacheRemoveAspect("IProductService.Get")]
        [SecuredOperation("product.add,admin")]
        //ATTRİBUTE =METOTA ANLAM KATMAYA CALISTIGIN YAPI. //ADD METOTUNA SENIN BİR VALİDATİONASPECTİN VAR DEMİŞ OLDUK. ONUDA AUTOFAC DEVREYE SOKUYOR .
        [ValidationAspect(typeof(ProductValidator))]   //ProductValidatoru kullanarak Add metunu  .
        public IResult Add(Product product)
        {
            var result=        BusinessRules.Run(CheckIfProductCountOfCategoryCorrent(product.CategoryId), CheckIfProductNameExists(product.ProductName),CheckIfCategoryLimitExceded());
            
            if(result != null)
            {
                return result;
            }
            _productDal.Add(product);
            return new SuccessResult(Messages.ProductAdded);
        }

        [PerformanceAspect(1)]

        [CacheAspect]
        public IDataResult<List<Product>> GetAll()
        {
            //iş kodları...
            //yetkiler...
            //if kodları...  tümünü geçerse ;
            if (DateTime.Now.Hour == 24)
            {
                return new ErrorDataResult<List<Product>>(Messages.MaintenanceTime);  // maintenancetime bakım zamanı
            }           
            
            return new SuccessDataResult<List<Product>> (_productDal.GetAll(),Messages.ProductsListed);  //hepsini içeren.
        }

        public IDataResult<List<Product>> GetAllByCategoryId(int id)
        {
            return new SuccessDataResult< List<Product> >(_productDal.GetAll(p=>p.CategoryId == id)); // siteden gelen id benim databasemideki idile eşleşiyosa filtrele.
        }

        [PerformanceAspect(1)]

        [CacheAspect]
        public IDataResult<Product> GetById(int productId)
        {
            return new SuccessDataResult<Product> (_productDal.Get(p => p.ProductId == productId));
        }

        public IDataResult<List<Product>> GetByUnitPrice(decimal min, decimal max)
        {
            return new SuccessDataResult< List<Product> >(_productDal.GetAll(p => p.UnitPrice >= min && p.UnitPrice <= max));
        }

        public IDataResult<List<ProductDetailDto>> GetProductDetails()
        {
            if (DateTime.Now.Hour == 04)
            {
                return new ErrorDataResult<List<ProductDetailDto>>(Messages.MaintenanceTime);  // maintenancetime bakım zamanı
            }


            return new SuccessDataResult< List<ProductDetailDto> > (_productDal.GetProductDetails());
        }


      private IResult  CheckIfProductCountOfCategoryCorrent(int categoryId)
        {
          var result=  _productDal.GetAll(p => p.CategoryId == categoryId).Count;
            if (result >= 15)
            {
                return new ErrorResult(Messages.ProductCountOfCategoryError);
            }
            return new SuccessResult();
                    
        }
        private IResult CheckIfProductNameExists(string productName)
        {
            var result = _productDal.GetAll(p => p.ProductName == productName).Any();
            if(result)
            {
                return new ErrorResult(Messages.ProductCountOfCategoryError);

            }
            return new SuccessResult();
        }
        private IResult CheckIfCategoryLimitExceded()
        {
            var result = _categoryService.GetAll();
            if (result.Data.Count >= 15)
            {
                return new ErrorResult(Messages.CategoryLimitExceded);
            }
            return new SuccessResult();
        }


        [TransactionScopeAspect]
        public IResult AddTransactionalTest(Product product)
        {
            return Add(product);
        }
    }
}
