using CarRental.Application.Common;
using CarRental.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CarRental.Infrastructure.Persistence.Configurations
{
    public class RentalConfiguration : IEntityTypeConfiguration<Rental>
    {
        public void Configure(EntityTypeBuilder<Rental> builder)
        {
            builder.Property(r => r.RenterFullName)
                .IsRequired()
                .HasMaxLength(Validation.Rental.RenterFullNameMaxLength);

            builder.Property(r => r.Notes)
                .HasMaxLength(Validation.Rental.NotesMaxLength);
        }
    }
}