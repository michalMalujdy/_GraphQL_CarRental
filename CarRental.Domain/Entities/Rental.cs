using System;

namespace CarRental.Domain.Entities
{
    public class Rental
    {
        public Guid Id { get; set; }
        public DateTimeOffset StartsAt { get; set; }
        public DateTimeOffset EndsAt { get; set; }
        public string RenterFullName { get; set; }
        public string Notes { get; set; }
        public bool IsDeleted { get; set; }

        public RentalState State { get; set; }

        public Guid CarId { get; set; }
        public Car Car { get; set; }
    }
}