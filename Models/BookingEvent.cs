using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EventManagement.Models
{
    public class BookingEvent
    {
        [Key]
        public int BookingId { get; set; }
        public int EventId { get; set; }
        public int  VenueId { get; set; }
        public int FoodId { get; set; }
        public int NumberofPeople { get; set; }
        public int TotalCost { get; set; }
        public string Createdby { get; set; }
        public DateTime? Createdate { get; set; }
        public DateTime? BookingDate { get; set; }
        public string Status { get; set; }
    }
}
