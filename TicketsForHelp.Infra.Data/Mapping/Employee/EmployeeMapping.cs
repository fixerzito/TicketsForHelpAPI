using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace TicketsForHelp.Infra.Data.Mapping.Employee;

public class EmployeeMapping : IEntityTypeConfiguration<Domain.Entities.Employee.Employee>
{
    public void Configure(EntityTypeBuilder<Domain.Entities.Employee.Employee> builder)
    {
        builder.ToTable("employees");
        builder.HasKey(x => x.Id);
        
        builder.Property(x => x.Name)
            .HasColumnType("varchar(150)")
            .IsRequired();
        
        builder.Property(x => x.CPF)
            .HasColumnType("varchar(14)")
            .IsRequired();
        
        builder.Property(x => x.Email)
            .HasColumnType("varchar(200)")
            .IsRequired();
        
        builder.Property(x => x.Login)
            .HasColumnType("varchar(50)")
            .IsRequired();
        
        builder.Property(x => x.Password)
            .HasColumnType("varchar(150)")
            .IsRequired();

        builder.Property(x => x.Photo)
            .HasColumnType("varchar(255)")
            .IsRequired(false);
            
        builder.Property(x => x.ActiveRegister)
            .HasColumnName("active_register")
            .HasColumnType("bit")
            .HasDefaultValue(true)
            .IsRequired();
    }
}