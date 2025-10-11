using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace TicketsForHelp.Infra.Data.Mapping.Ticket;

public class TicketMapping : IEntityTypeConfiguration<Domain.Entities.Ticket.Ticket>
{
    public void Configure(EntityTypeBuilder<Domain.Entities.Ticket.Ticket> builder)
    {
        builder.ToTable("ticket");
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Name)
            .HasColumnType("varchar(150)")
            .IsRequired();

        builder.Property(x => x.Issue)
            .HasColumnType("varchar(max)")
            .IsRequired();
        
        builder.Property(x => x.Status)
            .IsRequired()
            .HasColumnType("BIT");

        builder.HasOne(x => x.Customer)
            .WithMany()
            .HasForeignKey(x => x.IdCustomer)
            .OnDelete(DeleteBehavior.Restrict);

        builder.Property(x => x.ActiveRegister)
            .HasColumnName("active_register")
            .HasDefaultValue(true)
            .HasColumnType("bit")
            .IsRequired();
    }
}