using CQRSProject.Entities;

namespace CQRSProject.CQRSPattern.Results.OrderResults
{
    public class GetOrderQueryResult
    {
        public int Id { get; set; }
        public decimal TotalAmount { get; set; }
        public DateTime CreatedAt { get; set; }
        public string Status { get; set; }

        public string CustomerName { get; set; }
        public string CustomerEmail { get; set; }
    }
}
