using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryProductDal : IProductDal // IProductDal referans olarak product'ı tuttugu için inmemoryproductdal da referanslarına erişebileccek.
    {   // veritabanı oluşturalım liste şeklinde .
        List<Product> _products;  //list<product> degisken tipinde  bir _product tanımladım (tüm metotların dışında oldugu için bu classda heryerde kullanılabilecek)


        public InMemoryProductDal() //constructor. 
        {
            //proje çalıştırıldıgında bellekte böyle bir ürün oluşturmuş olduk. 
              _products = new List<Product> {
               new Product{ProductId=1,CategoryId=1,ProductName="Bardak",UnitPrice=15,UnitsInStock=15 },
               new Product{ProductId=2,CategoryId=1,ProductName="Kamera",UnitPrice=500,UnitsInStock=3 },
               new Product{ProductId=3,CategoryId=2,ProductName="Telefon",UnitPrice=1500,UnitsInStock=2 },
               new Product{ProductId=4,CategoryId=2,ProductName="Klavye",UnitPrice=150,UnitsInStock=65 },
               new Product{ProductId=5,CategoryId=2,ProductName="Fare",UnitPrice=85,UnitsInStock=1 },

            };
        }
        public void Add(Product product)
        {
            //veritabanına ürün ekleyelim
            _products.Add(product); 
        }

        public void Delete(Product product) 
        {
            //   _products.Remove(product); //şeklinde yazarsak silemez. (çünkü businessten gelen productun referansı ile
            //database listesi olan productun referansı aynı degil.database deki referansı bulup
            //silinmesi gerekli.
            //)
            //referansı bulmanın birinci yolu
             Product findRefDelete=null; // referansı olmasın diye null dedik.
            foreach (var p in _products)
            {
                if (product.ProductId == p.ProductId)
                {
                    findRefDelete = p;  
                }
            }
            //2.yol LİNQ SORGUSU   --- TERCİH EDİLEN.
            //singleordefault sorgusu=>foreach gibi çalışır. bir tane bir şey döndürür(bu yüzden id bazlı aramalarda kullan)
            findRefDelete = _products.SingleOrDefault(p =>p.ProductId==product.ProductId);
                       
            _products.Remove(findRefDelete); 
        
        }

        //public List<Product> GetAll()
        //{
        //    //veritabanındaki datayı business'e vermenlazım.
        //    return _products;
            
        //}

        

        public void Update(Product product) //ekrandan gelen data 
        { 
            //güncellenecek referansı bulmamız lazım. 
            //LİNQ sorgusu ile 
            Product productToUpdate; //güncellecek refrerans productToUpdate de olacak.
            productToUpdate = _products.SingleOrDefault(p => p.ProductId == product.ProductId);
            //referansı bulduk güncelleyelim
            productToUpdate.ProductId = product.ProductId;
            productToUpdate.ProductName = product.ProductName;
            productToUpdate.UnitPrice = product.UnitPrice;
            productToUpdate.UnitsInStock= product.UnitsInStock;
            //referansa businessden gelen güncelenecek bilgileri geçtik.
        }
        //public List<Product> GetAllByCategory(int categoryId) //ürünleri kategoriye göre filtrele.
        //{
        //    return _products.Where(p => p.CategoryId == categoryId).ToList();  //where koşulu ile categori idleri uyanları
        //    //liste olarak çektik.
        //}

        public List<Product> GetAll(Expression<Func<Product, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public Product Get(Expression<Func<Product, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<ProductDetailDto> GetProductDetails()
        {
            throw new NotImplementedException();
        }
    }
}
