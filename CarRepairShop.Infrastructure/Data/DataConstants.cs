namespace CarRepairShop.Infrastructure.Data
{
    public static class DataConstants
    {
        public const int CarModelMax = 30;
        public const int CarModelMin = 2;
        public const int ReservationDescriptionMax = 200;
        public const int ReservationDescriptionMin = 10;
        public const int VINMax = 17;

        public const string RequiredErrorMessage = "The field is required.";
        public const string StringLenghtErrorMessage = "The field must be between {2} and {1} long.";
        public const string VINLengthErrorMessage = "The VIN number must be 17 characters long.";

        public const string DateFormat = "yyyy-MM-dd";

    }
}
