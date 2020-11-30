namespace PropertyInvestAuction.Common
{
    public static class ValidationMessages
    {
        public const string PageNumberErrorMessage = "Page number can not be less than zero.";
        public const string PageSizeErrorMessage = "Page size can not be less than one.";

        public const string CityNameLengthErrorMessage = "City name must be between {0} and {1} characters.";
        public const string NeighborhoodNameLengthErrorMessage = "Neighborhood name must be between {0} and {1} characters.";
    }
}
