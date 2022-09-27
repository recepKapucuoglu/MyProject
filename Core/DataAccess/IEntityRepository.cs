
using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
namespace Core.DataAccess
{  //Generic Constraint =Generic kısılandırma işlemi.
    //class:referans değer olmalı.
    //IEntity:IEntity olabilir ve IEntity'i iplemente eden class olabilir.
    //new(): newlenebilir olmalı.
 
    
    
    
    
    
    
    public interface IEntityRepository<T> where T : class, IEntity, new() //T=  seçilen entity nesnesi(product,category, vb.)
    
    {   //(Expression<Func<T,bool>>filter=null); = GET EDİLEN LİSTENİN FİLTRELENMESİ SAGLAMAK 
    
        List<T> GetAll(Expression<Func<T, bool>> filter= null);  //filtre=null  filtre vermeyedebilirsin demek.
        
        T Get(Expression<Func<T, bool>>filter); //Tek bir nesneyi(clası) getirmek için.s
        void Add(T entity);

        void Update(T entity);
        void Delete(T entity);
        

    }
}
