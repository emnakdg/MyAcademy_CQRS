using CQRSProject.Entities;

namespace CQRSProject.CQRSPattern.Results.ContactResults
{
    public class GetContactQueryResult
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Subject { get; set; }
        public string Message { get; set; }
        public DateTime CreatedAt { get; set; }
        public bool IsRead { get; set; } // Assuming IsRead exists, if not I'll remove it later
    }
}
