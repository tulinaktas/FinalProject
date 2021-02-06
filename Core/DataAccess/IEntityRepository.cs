using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

//namespace -- classları intefaceleri vs belirli bir isim uzayında
//ulasmak icin
namespace Core.DataAccess
{//generic constraint
    //class: referans tip ve
    //IEntity: IEntity ve ya IEntity implement nesnelerine ulasir
    // new() : newlenebilir olmalı
    public interface IEntityRepository<T> where T:class,IEntity,new()
    {
        //ICategoryDal ve IProductDal icerisindekileri topladik
        List<T> GetAll(Expression<Func<T,bool>> filter = null);
        //filtreleme yapma islemi saglanıyor
        T Get(Expression<Func<T, bool>> filter);
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
        List<T> GetAllByCategory(int categoryId);
    }
}
