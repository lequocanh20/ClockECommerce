using clockECommerce.Data.Entities;
using clockECommerce.Data.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace clockECommerce.Data.Configurations
{
    public class ReviewConfiguration : IEntityTypeConfiguration<Review>
    {
        public void Configure(EntityTypeBuilder<Review> builder)
        {
            builder.ToTable("Reviews");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).UseIdentityColumn();

            builder.Property(x => x.Comments).IsRequired().HasMaxLength(500).HasColumnType("nvarchar");

            builder.Property(x => x.Rating).IsRequired();

            builder.Property(x => x.Status).IsRequired().HasDefaultValue((Status)0);

            builder.HasOne(x => x.Product).WithMany(x => x.Reviews).HasForeignKey(x => x.ProductId);

            builder.HasOne(x => x.AppUser).WithMany(x => x.Reviews).HasForeignKey(x => x.UserId);
        }
    }
}