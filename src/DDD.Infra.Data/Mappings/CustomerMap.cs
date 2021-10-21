using DDD.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DDD.Infra.Data.Mappings
{
    public class CustomerMap : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.Property(c => c.Id)
                .HasColumnName("Id");

            builder.Property(c => c.FirstName)
                .HasColumnType("nvarchar(100)")
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(c => c.LastName)
             .HasColumnType("nvarchar(100)")
             .HasMaxLength(100)
             .IsRequired();

            builder.Property(c => c.Address)
             .HasColumnType("nvarchar(100)")
             .HasMaxLength(100);

            builder.Property(c => c.PostalCode)
             .HasColumnType("varchar(10)")
             .HasMaxLength(10);

            builder.Property(c => c.Email)
                .HasColumnType("varchar(100)")
                .HasMaxLength(100)
                .IsRequired();

            builder.HasQueryFilter(p => !p.IsDeleted);
        }
    }
}
