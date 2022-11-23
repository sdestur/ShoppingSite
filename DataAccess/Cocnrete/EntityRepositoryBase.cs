using DataAccess.Abstract;
using Entities.Abstract;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Cocnrete
{
    public class EfEntityRepositoryBase<TEntity, TContext> : IEntityRepository<TEntity>
         where TEntity : class, IEntity, new()
         where TContext : DbContext, new()
    {
        public void Add(TEntity entity)
        {
            //DbContext nesnesi biraz fazla memory kullanır
            //using blogu görevini tamamladıktan sonra garbage collector ile 
            //garbage olarak toplanir, hafizadan nesneyi atariz.

            //IDisposable pattern implementation of C#
            using (TContext context = new TContext())
            {
                var addedEntity = context.Entry(entity); //entitynin referansını al, veri kaynağıyla ilişkilendir
                addedEntity.State = EntityState.Added; //ve ekle
                context.SaveChanges(); //işlemleri kaydet
            }
        }

        public void Delete(TEntity entity)
        {
            using (TContext context = new TContext())
            {
                var deletedEntity = context.Entry(entity); //entitynin referansını al, veri kaynağıyla ilişkilendir
                deletedEntity.State = EntityState.Deleted;
                context.SaveChanges();
            }
        }

        public TEntity GetById(Expression<Func<TEntity, bool>> filter)
        {
            using (TContext context = new TContext())
            {
                return context.Set<TEntity>().SingleOrDefault(filter);
            }
        }

        public List<TEntity> GetAll(Expression<Func<TEntity, bool>> filter = null)
        {
            //Bu kısımda hata var, buraya tekrar döneceğim!
            using (TContext context = new TContext())
            {
                return filter == null
                    ? context.Set<TEntity>().ToList() //filtre null ise bunu yap
                    : context.Set<TEntity>().Where(filter).ToList(); //filtre null degil ise listeyi filtreleyip ver
            }
        }

        public void Update(TEntity entity)
        {
            using (TContext context = new TContext())
            {
                var updatedEntity = context.Entry(entity); //entitynin referansını al, veri kaynağıyla ilişkilendir
                updatedEntity.State = EntityState.Modified;
                context.SaveChanges();
            }
        }

        
    }
}
