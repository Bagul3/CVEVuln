using System;
using System.Data.Entity;
using System.Linq;

namespace CVEVulnDA
{
    using System.Threading.Tasks;

    public abstract class GenericRepository<C, T> : IGenericRepository<T> where T : class where C : DbContext, new()
    {

        private C entities = new C();
        public C Context
        {

            get { return this.entities; }
            set { this.entities = value; }
        }

        public virtual IQueryable<T> GetAll()
        {
            IQueryable<T> query = this.entities.Set<T>();
            return query;
        }

        public IQueryable<T> FindBy(System.Linq.Expressions.Expression<Func<T, bool>> predicate)
        {

            IQueryable<T> query = this.entities.Set<T>().Where(predicate);
            return query;
        }

        public virtual void Add(T entity)
        {
            this.entities.Set<T>().Add(entity);
        }

        public virtual void Delete(T entity)
        {
            this.entities.Set<T>().Remove(entity);
        }

        public virtual void Edit(T entity)
        {
            this.entities.Entry(entity).State = EntityState.Modified;
        }

        public virtual async Task Save()
        {
            await this.entities.SaveChangesAsync();
        }
    }
}
