﻿using clockECommerce.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace clockECommerce.Data.Configurations
{
    public class AppRoleConfiguration : IEntityTypeConfiguration<AppRole>
    {
        public void Configure(EntityTypeBuilder<AppRole> builder)
        {
            builder.ToTable("AppRoles");
            builder.Property(x => x.Id).HasMaxLength(200);
        }
    }
}
