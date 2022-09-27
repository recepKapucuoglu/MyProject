using Autofac;
using Autofac.Extras.DynamicProxy;
using Business.Abstract;
using Business.Concrete;
using Castle.DynamicProxy;
using Core.Utilities.Interceptors;
using Core.Utilities.Security.JWT1;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.DependencyResolvers.Autofac
{
    public class AutofacBusinessModule :Module 
    {                                           //Amac business de yapıp her defasında tanımlama yapmamak. VE AOP YAPABİLMEK
        protected override void Load(ContainerBuilder builder)  // proje çalıştırıldında (ayağa kalktıgında)
        {
            builder.RegisterType<ProductManager>().As<IProductService>().SingleInstance(); 
            builder.RegisterType<EfProductDal>().As<IProductDal>().SingleInstance();  
                                                                                      //newlemeye gerek kalmıyor. burası onun karşılıgını veriyor.

            builder.RegisterType<CategoryManager>().As<ICategoryService>().SingleInstance();  
            builder.RegisterType<EfCategoryDal>().As<ICategoryDal>().SingleInstance(); 
                                                                                        


            builder.RegisterType<UserManager>().As<IUserService>();
            builder.RegisterType<EfUserDal>().As<IUserDal>();

            builder.RegisterType<AuthManager>().As<IAuthService>();
            builder.RegisterType<JwtHelper>().As<ITokenHelper>();




            // attribute da git bak aspect varmı . 
            var assembly = System.Reflection.Assembly.GetExecutingAssembly();

            builder.RegisterAssemblyTypes(assembly).AsImplementedInterfaces()
                .EnableInterfaceInterceptors(new ProxyGenerationOptions()
                {
                    Selector = new AspectInterceptorSelector()
                }).SingleInstance();



        }
        
    }
}
