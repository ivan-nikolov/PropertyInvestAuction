namespace PropertyInvestAuction.Server.Models.Identity
{
    using System.ComponentModel.DataAnnotations;

    using static PropertyInvestAuction.Common.ValidationMessages;
    using static PropertyInvestAuction.Common.ValidationConstants;

    public class PageRequestModel
    {
        [Range(PageMinNumber, int.MaxValue, ErrorMessage = PageNumberErrorMessage)]
        public int Page { get; set; }

        [Range(PageMinSize, int.MaxValue, ErrorMessage = PageSizeErrorMessage)]
        public int PageSize { get; set; }

        public string Query { get; set; }
    }
}
