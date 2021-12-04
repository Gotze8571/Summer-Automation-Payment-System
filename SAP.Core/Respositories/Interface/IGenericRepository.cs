using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SAP.Domain.Respositories.Interface
{
    public interface IGenericRepository<T>
    {
        //Task<bool> CreateAsync(T item, params Expression<Func<T, object>>[] includes);
        Task<IEnumerable<T>> FindAllAsync();
        Task<IEnumerable<T>> FindAllAsync(Expression<Func<T, bool>> predicate);
        Task<T> FindByIdAsync(object id);
        Task<T> FindAsync(object id);
        Task<bool> InsertAsync(T item);
        Task<int> BulkInsertAsync(IEnumerable<T> items, IDbTransaction transanction = null);
        Task<bool> UpdateAsync(T item, params Expression<Func<T, object>>[] includes);
        Task<bool> DeleteAsync(T item);
        Task<bool> DeleteAsync(Expression<Func<T, bool>> predicate, IDbTransaction Transaction = null);
    }
}
