using CarRental.Application.Common;
using CarRental.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CarRental.Infrastructure.Persistence.Configurations
{
    public class CarConfiguration : IEntityTypeConfiguration<Car>
    {
        public void Configure(EntityTypeBuilder<Car> builder)
        {
            builder.Property(c => c.Make)
                .IsRequired()
                .HasMaxLength(Validation.Car.MakeMaxLength);

            builder.Property(c => c.Model)
                .IsRequired()
                .HasMaxLength(Validation.Car.ModelMaxLength);

            builder.Property(c => c.RegistrationNumber)
                .IsRequired()
                .HasMaxLength(Validation.Car.RegistrationNumberMaxLength);
        }
    }
}