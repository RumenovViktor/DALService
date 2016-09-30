namespace Data.Repository
{
    using System;
    using System.Linq.Expressions;
    using System.Data.Entity;
    using System.Threading.Tasks;

    using DataContext;

    public class Repository<T> : IRepository<T> where T : class
    {
        #region Private Members

        private readonly IDALServiceDataContext m_DataContext;

        #endregion

        #region Ctor(s)

        public Repository(IDALServiceDataContext dataContext)
        {
            m_DataContext = dataContext;
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Adds a new record to the databse.
        /// </summary>
        /// <param name="entity">Entity to be added.</param>
        public void AddEntity(T entity)
        {
            this.ValidateEntity(entity);

            var entityState = this.GetEntityState(entity);

            if (entityState != EntityState.Detached)
            {
                m_DataContext.Entry(entity).State = EntityState.Added;
            }
            else
            {
                m_DataContext.Set<T>().Add(entity);
            }
        }

        /// <summary>
        /// Deletes entity from the database.
        /// </summary>
        /// <param name="entity">Entity to be deleted.</param>
        public void DeleteEntity(T entity)
        {
            this.ValidateEntity(entity);

            var entityState = this.GetEntityState(entity);

            if (entityState != EntityState.Detached)
            {
                m_DataContext.Entry(entity).State = EntityState.Deleted;
            }
            else
            {
                m_DataContext.Set<T>().Attach(entity);
                m_DataContext.Set<T>().Remove(entity);
            }            
        }

        /// <summary>
        /// Find entity by expression (asynchronous)
        /// </summary>
        /// <param name="expression">Expression.</param>
        /// <returns>Found entity.</returns>
        public Task<T> FindEntity(Expression<Func<T, bool>> expression)
        {
            Task<T> entity = null;

            if (expression == null)
            {
                throw new ArgumentNullException("Expression can not be null!");
            }

            entity = m_DataContext.Set<T>().FindAsync(expression);
            
            return entity;
        }

        /// <summary>
        /// Update an existing entity.
        /// </summary>
        /// <param name="entity">Entity to be updated.</param>
        public void UpdateEntity(T entity)
        {
            this.ValidateEntity(entity);

            var entityState = this.GetEntityState(entity);

            m_DataContext.Set<T>().Attach(entity);
        }

        public void SaveChanges()
        {
            m_DataContext.SaveChangesAsync();
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// Validates if the passed entity is not null.
        /// </summary>
        /// <param name="entity">Current entity</param>
        private void ValidateEntity(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("Entity can not be null!");
            }
        }

        /// <summary>
        /// Gets the current entity state.
        /// </summary>
        /// <param name="entity">Passed entity</param>
        /// <param name="dataContext">Current data context</param>
        /// <returns></returns>
        private EntityState GetEntityState(T entity)
        {
            return m_DataContext.Entry(entity).State;
        }

        #endregion
    }
}
