using System;
using System.Data.Entity.ModelConfiguration;
using Repository.Entities.Contract;

namespace Repository.Configurations.Base
{
    public abstract class BaseTableConfiguration<TEntity, TId> : EntityTypeConfiguration<TEntity>
        where TEntity : class, IEntity<TId> 
        where TId : struct, IComparable<TId>
    {
        protected BaseTableConfiguration(string tableName = null)
        {
            var name = string.IsNullOrEmpty(tableName) ? typeof(TEntity).Name : tableName;
            
            ToTable(name).HasKey(e => e.Id);
        }
    }
}
