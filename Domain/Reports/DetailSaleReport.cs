namespace Domain.Reports
{
    public class DetailSaleReport
    {
        public string description { get; set; }
        public decimal price { get; set; }
        public int quantity { get; set; }
        public decimal total { get; set; }
    }
}