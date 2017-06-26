using System;
using System.Linq;

namespace CVEVulnDA
{
    using System.Threading.Tasks;

    public interface IGenericRepository<T> where T : class
    {
        IQueryable<T> GetAll();

        IQueryable<T> FindBy(System.Linq.Expressions.Expression<Func<T, bool>> predicate);

        void Add(T entity);

        void Delete(T entity);

        void Edit(T entity);

        Task Save();
    }
}
