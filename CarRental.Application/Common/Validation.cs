namespace CarRental.Application.Common
{
    public static class Validation
    {
        public static class Car
        {
            public const int MakeMaxLength = 50;
            public const int ModelMaxLength = 50;
            public const int RegistrationNumberMaxLength = 20;
            public const int ProductionYearMin = 1800;
        }

        public static class Rental
        {
            public const int RenterFullNameMaxLength = 100;
            public const int NotesMaxLength = 2000;
        }
    }
}