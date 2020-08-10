using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace InventoryManegementSystemCore.View
{
    public abstract class EfCoreRepository<TEntity, TContext> : IRepository<TEntity>
        where TEntity : class
        where TContext : DbContext
        {
            private readonly TContext context;
            public EfCoreRepository(TContext context)
            {
                this.context = context;
            }
            public async Task<TEntity> Add(TEntity entity)
            {
                context.Set<TEntity>().Add(entity);
                await context.SaveChangesAsync();
                return entity;
            }

            public async Task<TEntity> Delete(long id)
            {
                var entity = await context.Set<TEntity>().FindAsync(id);
                if (entity == null)
                {
                    return entity;
                }

                context.Set<TEntity>().Remove(entity);
                await context.SaveChangesAsync();

                return entity;
            }
        

            public async Task<TEntity> Get(long id)
            {
                return await context.Set<TEntity>().FindAsync(id);
            }

          public async Task<TEntity> GetbyId(int id)
            {
            return await context.Set<TEntity>().FindAsync(id);
             }

           public TEntity GetEntitybyId(int id)
            {
            return  context.Set<TEntity>().Find(id);
            }
             public async Task<List<TEntity>> GetAll()
            {
                return await context.Set<TEntity>().ToListAsync();
            }

            public async Task<TEntity> Update(TEntity entity)
            {
                context.Entry(entity).State = EntityState.Modified;
                await context.SaveChangesAsync();
                return entity;
            }

        }
}

