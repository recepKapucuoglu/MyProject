﻿using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using System;
using System.ComponentModel;
using System.Runtime.ConstrainedExecution;

namespace ConsoleUI
{
    internal class Program
    {
        static void Main(string[] args)
        {   //PRODUCT MANAGER ÜZERİNDEN İNMEMORYPRODUCTDAL DATASINDAN CALISMAYI SEÇTİK.(BAŞKA BİR DATA TÜRÜ EKLERSEK İNTERFACE SAYESİNDE BURADAN ONU SEÇEBLİRZ.)
            //inmememory
            //  ProductManager productManager = new ProductManager(new InMemoryProductDal());
            //entityframework 
            //  ProductTest();
            //    CategoryTest();

       
        }

        private static void CategoryTest()
        {
    /*        CategoryManager categoryManager = new CategoryManager(new EfCategoryDal());
            foreach (var category in categoryManager.GetAll())
            {
                Console.WriteLine(category.CategoryName);
            }
        }*/

       /* private static void ProductTest()
        {
            ProductManager productManager = new ProductManager(new EfProductDal());

            var result = productManager.GetProductDetails();

            if (result.Success == true)
            {
                foreach (var product in result.Data)
            {
                Console.WriteLine(product.ProductName + "---------" + product.CategoryName);
            }

            }
            else
            {
                Console.WriteLine(result.Message);
            }*/

            
        }
    }
}
