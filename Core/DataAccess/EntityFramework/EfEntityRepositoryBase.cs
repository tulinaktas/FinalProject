using Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

//EFProductDal icerisinde olan kodlari copy-paste
//ondan sonra product ve northwindcontext i evrensel hale getirdik.
//her yerde kullanabilmek icin
namespace Core.DataAccess.EntityFramework
{
    //bana bir context ve entiity ver onunla calisayim classi 
    //evrensel kod
    public class EfEntityRepositoryBase<TEntity,TContext>:IEntityRepository<TEntity>
        where  TEntity : class, IEntity, new()
        where TContext : DbContext, new()
    {
        // NuGet --> baskalarinin yazdigi kodlar -- entityframework

        public void Add(TEntity entity)
        {
            //using kullanarak daha performansli bir hale getiriyor, c#a ozel
            //using bittigi anda garbage collector calisiyor -- bellegi hizlica temizleme
            using (TContext context = new TContext())
            {
                var addedEntity = context.Entry(entity);
                addedEntity.State = EntityState.Added;
                context.SaveChanges();
            }
        }

        public void Delete(TEntity entity)
        {
            using (TContext context = new TContext())
            {
                var delitedEntity = context.Entry(entity);
                delitedEntity.State = EntityState.Deleted;
                context.SaveChanges();
            }
        }

        public TEntity Get(Expression<Func<TEntity, bool>> filter)
        {
            using (TContext context = new TContext())
            {
                // bir adet product dondurucek
                return context.Set<TEntity>().SingleOrDefault(filter);
            }
        }
        public List<TEntity> GetAll(Expression<Func<TEntity, bool>> filter = null)
        {
            using (TContext context = new TContext())
            {
                //select * from products ı liste ceviriyor
                //filtreye ve filtre olmadan gore getiriyor
                //aslinda linq ile db islemlerini yapiyoruz
                return filter == null
                    ? context.Set<TEntity>().ToList()
                    : context.Set<TEntity>().Where(filter).ToList();
            }
        }

        public List<TEntity> GetAllByCategory(int categoryId)
        {
            throw new NotImplementedException();
        }

        public void Update(TEntity entity)
        {
            using (TContext context = new TContext())
            {
                var updatedEntity = context.Entry(entity);
                updatedEntity.State = EntityState.Modified;
                context.SaveChanges();
            }
        }

    }
}
