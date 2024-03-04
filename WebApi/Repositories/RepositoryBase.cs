using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace WebApi.Repositories
{
    public class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        protected HeroContext HeroContext { get; set; }
        public RepositoryBase(HeroContext heroContext)
        {
            HeroContext = heroContext;
        }
        public IQueryable<T> FindAll() =>
             HeroContext.Set<T>()
                .AsNoTracking()
                .AsQueryable();
        public IQueryable<T> FindByCondition(Expression<Func<T, bool>> condition) =>
            HeroContext.Set<T>()
            .Where(condition)
            .AsNoTracking()
            .AsQueryable();
        public void Create(T entity) => HeroContext.Set<T>().Add(entity);
        public void Update(T entity) => HeroContext.Set<T>().Update(entity);
        public void Delete(T entity) => HeroContext.Set<T>().Remove(entity);

        public void Dispose()
        {
            HeroContext?.Dispose();
        }
    }
}
