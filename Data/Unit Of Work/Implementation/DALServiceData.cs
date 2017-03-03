namespace Data.Unit_Of_Work
{
    using System;
    using System.Collections.Generic;

    using Data.Repository;
    using DTOs.Models;
    using DataContext;

    public class DALServiceData : IDALServiceData
    {
        #region Private Members

        private readonly IDictionary<Type, object> repositories;
        private readonly IDALServiceDataContext m_DalServiceDataContext;

        #endregion

        #region Ctor(s)

        public DALServiceData(IDALServiceDataContext dalServiceDataContext)
        {
            m_DalServiceDataContext = dalServiceDataContext;
            repositories = new Dictionary<Type, object>();
        }

        #endregion

        #region Public Methods

        public IRepository<Skill> Skills
        {
            get
            {
                return this.GetRepository<Skill>();
            }
        }

        public IRepository<User> Users
        {
            get
            {
                return this.GetRepository<User>();
            }
        }

        public IRepository<Sector> Sectors
        {
            get
            {
                return this.GetRepository<Sector>();
            }
        }

        public IRepository<Company> Companies
        {
            get
            {
                return this.GetRepository<Company>();
            }
        }

        public IRepository<File> Files
        {
            get
            {
                return this.GetRepository<File>();
            }
        }

        public IRepository<Experience> Experience
        {
            get
            {
                return this.GetRepository<Experience>();
            }
        }

        public IRepository<Position> Positions
        {
            get
            {
                return this.GetRepository<Position>();
            }
        }

        public IRepository<Country> Countries
        {
            get
            {
                return this.GetRepository<Country>();
            }
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// Creates a repository on demand.
        /// </summary>
        /// <returns>The created repository</returns>
        private IRepository<T> GetRepository<T>() where T : class
        {
            var repositoryType = typeof(T);

            if (!this.repositories.ContainsKey(repositoryType))
            {
                var type = typeof(Repository<T>);

                this.repositories.Add(repositoryType, Activator.CreateInstance(type, this.m_DalServiceDataContext));
            }

            return (IRepository<T>)this.repositories[repositoryType];
        }

        #endregion
    }
}
