using EventManagement.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EventManagement.ViewModels
{
    [Keyless]
    [NotMapped]
    public class BookingEventViewModel
    {
        public int BookingId { get; set; }
        [Required]
        public int EventId { get; set; }
        public int VenueId { get; set; }
        public int FoodId { get; set; }
        public string EventType { get; set; }
        public string VenueName { get; set; }
        public int VenueCost { get; set; }
        public string FoodType { get; set; }
        public string MealType { get; set; }
        public int FoodCost { get; set; }
        public int TotalCost { get; set; }
        public int NumberofPeople { get; set; }
        public string Status { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? Createdate { get; set; }
        public DateTime? BookingDate { get; set; }
    }
}
