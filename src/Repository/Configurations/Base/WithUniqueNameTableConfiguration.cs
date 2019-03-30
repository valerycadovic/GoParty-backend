using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Infrastructure.Annotations;
using Repository.Contract.Entities.Contract;

namespace Repository.Configurations.Base
{
    public class WithUniqueNameTableConfiguration<TEntity, TId> : WithNameTableConfiguration<TEntity, TId>
        where TEntity : class, IWithUniqueNameEntity<TId>
        where TId : IEquatable<TId>
    {
        public WithUniqueNameTableConfiguration(string name = null) : base(name)
        {
            Property(p => p.Name)
                .HasColumnAnnotation("Index", new IndexAnnotation(new[] {
                        new IndexAttribute("Index") { IsUnique = true }
                    }
                ))
                .HasMaxLength(50);
        }
    }
}
