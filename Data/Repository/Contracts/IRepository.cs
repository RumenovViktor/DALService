namespace Data.Repository
{
    using System;
    using System.Linq.Expressions;
    using System.Threading.Tasks;

    public interface IRepository<T>
    {
        void AddEntity(T entity);

        Task<T> FindEntity(Expression<Func<T, bool>> expression);

        void UpdateEntity(T entity);

        void DeleteEntity(T entity);

        void SaveChanges();
    }
}
