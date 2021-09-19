using System;
using System.Collections.Generic;

namespace CarRental.Domain.Entities
{
    public class Car
    {
        public Guid Id { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public string RegistrationNumber { get; set; }
        public int ProductionYear { get; set; }
        public bool IsDeleted { get; set; }

        public ICollection<Rental> Rentals { get; set; } = new List<Rental>();
    }
}