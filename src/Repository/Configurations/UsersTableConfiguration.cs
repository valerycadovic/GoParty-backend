﻿using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Infrastructure.Annotations;
using Repository.Configurations.Base;
using Repository.Contract.Entities;

namespace Repository.Configurations
{
    public class UsersTableConfiguration : WithNameTableConfiguration<UserEntity, Guid>
    {
        public UsersTableConfiguration() : base("Users")
        {
            Property(p => p.UserName)
                .HasColumnAnnotation("Index", new IndexAnnotation(new[] {
                        new IndexAttribute("Index") { IsUnique = true }
                    }
                ))
                .HasMaxLength(50);

            Property(e => e.Surname).IsRequired();
            Property(e => e.UserName).IsRequired();
            Property(e => e.Email).IsRequired();
            HasMany(e => e.Contacts).WithRequired(e => e.User);
            HasRequired(e => e.City).WithMany(e => e.Users);
            HasMany(e => e.Roles).WithMany(e => e.Users);
        }
    }
}
