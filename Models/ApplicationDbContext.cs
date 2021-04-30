using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EventManagement.ViewModels;
using EventManagement.Models;

namespace EventManagement.Models
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        public DbSet<Event> tblEvent { get; set; }
        public DbSet<Venue> tblVenue { get; set; }
        public DbSet<Food> tblFood { get; set; }
        public DbSet<BookingEvent> tblBookingEvent { get; set; }
    }
}
