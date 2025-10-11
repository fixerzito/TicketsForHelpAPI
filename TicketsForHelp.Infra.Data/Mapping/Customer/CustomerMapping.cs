using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace TicketsForHelp.Infra.Data.Mapping.Customer;

public class CustomerMapping : IEntityTypeConfiguration<Domain.Entities.Customers.Customer>

{
    public void Configure(EntityTypeBuilder<Domain.Entities.Customers.Customer> builder)
    {
        builder.ToTable("customer");
        builder.HasKey(x => x.Id);
        
        builder.Property(x => x.Name)
            .HasColumnType("varchar(150)")
            .IsRequired();
        
        builder.Property(x => x.Email)
            .HasColumnType("varchar(200)")
            .IsRequired();
        
        builder.Property(x => x.CNPJ)
            .HasColumnType("varchar(18)")
            .IsRequired();
            
        builder.Property(x => x.ActiveRegister)
            .HasColumnName("active_register")
            .HasDefaultValue(true)
            .HasColumnType("bit")
            .IsRequired();
    }
}