namespace EasyWallet.Entries.Api.Requests
{
    public class GetBalanceReportRequest : GetReportRequest
    {
        public int IncomeCategoryId { get; set; }
    }
}
