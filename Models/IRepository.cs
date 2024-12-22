using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Linq.Expressions;

namespace LibraryManagement.Models
{
    public interface IRepository<T> where T : class
    {
        IEnumerable<T> GetAll(string? includeProps = null);

        T Get(Expression<Func<T, bool>> filtre, string? includeProps = null);

        void Add(T entity);
        void Delete(T entity);
        void DeleteRange(IEnumerable<T> entities);
        
    }
}