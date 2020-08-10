using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace InventoryManegementSystemCore.View
{
   public  interface IRepository<TEntity> where TEntity : class
    {
        Task<List<TEntity>> GetAll();
        Task<TEntity> Get(long id);
        Task<TEntity> GetbyId(int id);
        Task<TEntity> Add(TEntity entity);
        Task<TEntity> Update(TEntity entity);
        Task<TEntity> Delete(long id);
    }
}

