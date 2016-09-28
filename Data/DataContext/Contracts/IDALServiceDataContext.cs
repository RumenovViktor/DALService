﻿namespace Data.DataContext
{
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Threading.Tasks;

    using DTOs.Models;

    public interface IDALServiceDataContext
    {
        IDbSet<User> Users { get; set; }

        IDbSet<Skill> Skills { get; set; }

        DbSet<TEntity> Set<TEntity>() where TEntity : class;

        DbEntityEntry Entry(object entity);

        Task<int> SaveChangesAsync();
    }
}
