namespace EasyWallet.Entries.Business.Models.Reports
{
    public struct MonthlyReportCategory
    {
        public int CategoryId { get; set; }
        public decimal Total { get; set; }

        public MonthlyReportCategory(int categoryId, decimal total)
        {
            CategoryId = categoryId;
            Total = total;
        }
    }
}
