using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StaySync.Domain.Entities;

namespace StaySync.Infrastructure.Persistence.Configurations;

/// <summary>
/// Configuration for ReservationService entity.
/// </summary>
public class ReservationServiceConfiguration : IEntityTypeConfiguration<ReservationServices>
{
    public void Configure(EntityTypeBuilder<ReservationServices> builder)
    {
        builder.HasKey(rs => new
        {
            rs.ReservationId,
            rs.AdditionalServiceId
        });

        builder.HasOne(rs => rs.Reservation)
            .WithMany(r => r.ReservationServices)
            .HasForeignKey(rs => rs.ReservationId);

        builder.HasOne(rs => rs.AdditionalService)
            .WithMany(s => s.ReservationServices)
            .HasForeignKey(rs => rs.AdditionalServiceId);
    }
}