using System;
using Repository.Entities.Contract;

namespace Repository.Configurations.Base
{
    public abstract class WithNameTableConfiguration<TEntity, TId> : BaseTableConfiguration<TEntity, TId>
        where TEntity : class, IWithNameEntity<TId>
        where TId : struct, IComparable<TId>
    {
        protected WithNameTableConfiguration(string tableName = null) : base(tableName)
        {
            Property(e => e.Name).IsRequired();
        }
    }
}
