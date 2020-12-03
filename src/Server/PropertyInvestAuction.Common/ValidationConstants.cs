namespace PropertyInvestAuction.Common
{
    public static class ValidationConstants
    {
        public const int CategoryNameMinLength = 4;
        public const int CategoryNameMaxLength = 50;

        public const int AddressNameMinLength = 5;
        public const int AddressNameMaxLength = 100;

        public const string BidMinPrice = "0.0";
        public const string BidMaxPrice = "100000000M";

        public const int BidCommentMaxLength = 2500;

        public const int CityNameMinLength = 2;
        public const int CityNameMaxLength = 50;

        public const int CountryNameMinLength = 4;
        public const int CountryNameMaxLength = 50;

        public const int MessageTittleMinLength = 3;
        public const int MessageTitleMaxLength = 50;

        public const int MessageContentMinLength = 10;
        public const int MessageContentMaxLength = 2500;

        public const int NeighborhoodNameMinLength = 2;
        public const int NeighborhoodNameMaxLength = 50;

        public const string OfferStartingBidPrice = "0.0";
        public const string OfferBidOutPrice = "100_000_000M";

        public const int PropertyDescriptionMinLength = 10;
        public const int PropertyDescriptionMaxLength = 50;

        public const int PageMinNumber = 0;
        public const int PageMinSize = 1;
    }
}
