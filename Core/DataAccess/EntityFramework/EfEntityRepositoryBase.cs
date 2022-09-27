using Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Core.DataAccess.EntityFramework
{
    public class EfEntityRepositoryBase<TEntity,TContext>:IEntityRepository<TEntity>
        where TEntity : class,IEntity, new()  // referans kullan ,ientity ve reflerini kullan , newlenebilr clas olsun.
        where TContext:DbContext, new()  //databaseden dbconxtext bağlantımızı kullan , newlenebilir classları kullan. (interfaceler olmasın diye.)
    {
        public void Add(TEntity entity)
        {
            //using : context kullanımı bittiği anda belleği temizler. (performansı iyileştirmek için.) direk newlemede yapılabilirdi.


            using (TContext context = new TContext())
            {
                var addedEntity = context.Entry(entity);         // gönderdiğim entity clasının referansını(adresini)  nortwind context'e bağla . 
                addedEntity.State = EntityState.Added;          // bunu git ekle dedim
                context.SaveChanges();                          //kaydet.
            }
        }

     

        public void Delete(TEntity entity)
        {
            using (TContext context = new TContext())
            {
                var deletedEntity = context.Entry(entity);      // gönderdiğim entity clasının referansını(adresini)  nortwind context'e bağla . 
                deletedEntity.State = EntityState.Deleted;      // bunu git sil dedim
                context.SaveChanges();                          //kaydet.
            }
        }

        public TEntity Get(Expression<Func<TEntity, bool>> filter)
        {
            using (TContext context = new TContext())
            {
                return context.Set<TEntity>().SingleOrDefault(filter);       // veriitabanındaki productı filtrele ve tek bir deger getir.
            }
        }

        public List<TEntity> GetAll(Expression<Func<TEntity, bool>> filter)
        {
            using (TContext context = new TContext())
            {

                return filter == null
                    ? context.Set<TEntity>().ToList()                        //eğer null ise= veri tabanındaki produc'ı listeye çevir ver. 
                    : context.Set<TEntity>().Where(filter).ToList();         // null degilse  filtreleyip ver.
            }

        }

        public void Update(TEntity entity)
        {
            using (TContext context = new TContext())
            {
                var UpdatedEntity = context.Entry(entity);
                UpdatedEntity.State = EntityState.Modified;
                context.SaveChanges();
            }
        }
    }

}
