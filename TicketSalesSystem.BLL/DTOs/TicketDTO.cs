using Microsoft.AspNetCore.Identity;

namespace TicketSalesSystem.BLL.DTOs
{
    public class TicketDTO
    {
        public int Id { get; set; }
        public int Place { get; set; }
        public Decimal Price { get; set; }
        public string UserId { get; set; } = string.Empty;
        public IdentityUser? User { get; set; } = null;
        public int FlightId { get; set; }
        public int SeatTypeId { get; set; }
        public bool IsConfirmed { get; set; }
        public FlightDTO? Flight { get; set; } = null;
    }
}
