namespace Data.Repository
{
    using System;
    using System.Linq;
    using System.Linq.Expressions;

    public interface IRepository<T>
    {
        IQueryable<T> All();

        void AddEntity(T entity);

        T FindEntity(Expression<Func<T, bool>> expression);

        void UpdateEntity(T entity);

        void DeleteEntity(T entity);

        void SaveChanges();
    }
}
