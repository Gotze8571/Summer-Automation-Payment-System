using MicroOrm.Dapper.Repositories;
using SAP.Domain.Respositories.Interface;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SAP.Domain.Respositories.Concrete
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected DapperRepository<T> repository;

        protected GenericRepository(DapperRepository<T> repo)
        {
            repository = repo;
        }
        public virtual async Task<int> BulkInsertAsync(IEnumerable<T> items, IDbTransaction transanction = null)
        {
            return await repository.BulkInsertAsync(items, transanction);
        }

        public virtual async Task<bool> DeleteAsync(T item)
        {
            return await repository.DeleteAsync(item);
        }

        public virtual async Task<bool> DeleteAsync(Expression<Func<T, bool>> predicate, IDbTransaction Transaction = null)
        {
            return await repository.DeleteAsync(predicate, Transaction);
        }

        public virtual async Task<IEnumerable<T>> FindAllAsync()
        {
            return await repository.FindAllAsync();
        }

        public virtual async Task<IEnumerable<T>> FindAllAsync(Expression<Func<T, bool>> predicate)
        {
            return await repository.FindAllAsync(predicate);
        }

        public virtual async Task<T> FindAsync(object id)
        {
            return await repository.FindAsync();
        }

        public virtual async Task<T> FindByIdAsync(object id)
        {
            return await repository.FindByIdAsync(id);
        }

        public virtual async Task<bool> InsertAsync(T item)
        {
            return await repository.InsertAsync(item);
        }

        public virtual async Task<bool> UpdateAsync(T item, params Expression<Func<T, object>>[] includes)
        {
            return await repository.UpdateAsync(item, includes);
        }
    }
}
