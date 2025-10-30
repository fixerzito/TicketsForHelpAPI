using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TicketsForHelp.Domain.Entities.Ticket;

namespace TicketsForHelp.Infra.Data.Mapping.Ticket;

public class TicketCategoryMapping : IEntityTypeConfiguration<TicketCategory>
{
    public void Configure(EntityTypeBuilder<TicketCategory> builder)
    {
        builder.ToTable("ticket_category");
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Name)
            .HasColumnType("varchar(150)")
            .IsRequired();
        
        builder.HasOne(x => x.Ticket)
            .WithMany(x => x.TicketCategories)
            .HasForeignKey(x => x.IdTicket)
            .OnDelete(DeleteBehavior.Restrict)
            .IsRequired(false);

        builder.Property(x => x.ActiveRegister)
            .HasColumnName("active_register")
            .HasDefaultValue(true)
            .HasColumnType("bit")
            .IsRequired();
    }
}