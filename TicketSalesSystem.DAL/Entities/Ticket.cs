using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketSalesSystem.DAL.Entities
{
    public class Ticket
    {
        public int Id { get; set; }
        public int Place { get; set; }
        public Decimal Price { get; set; }
        public bool IsConfirmed { get; set; }
        public string UserId { get; set; } = String.Empty;
        public IdentityUser? User { get; set; } = null;
        public int FlightId { get; set; }
        public Flight? Flight { get; set; } = null;
        public int SeatTypeId { get; set; }
        public SeatType? SeatType { get; set; } = null;
    }
}
