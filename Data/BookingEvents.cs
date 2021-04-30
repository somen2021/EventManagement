using EventManagement.Models;
using EventManagement.ViewModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventManagement.Data
{
    public class BookingEvents : IBookingEvents
    {
        private readonly ApplicationDbContext _dbContext;
        public BookingEvents(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<bool> CreateBookingEvents(BookingEventViewModel bookingEvents)
        {
            var checkbookingdate = _dbContext.tblBookingEvent.Where(x => x.BookingDate.Value.Date.CompareTo(bookingEvents.BookingDate.Value.Date)!=0);
            var a = DateTime.Now.Date.CompareTo(bookingEvents.BookingDate.Value.Date);

            if (checkbookingdate.ToList().Count() == 0)
            {
                BookingEvent bkEvent = new BookingEvent();
                bkEvent.NumberofPeople = bookingEvents.NumberofPeople;
                bkEvent.TotalCost = bookingEvents.TotalCost;
                bkEvent.EventId = bookingEvents.EventId;
                bkEvent.FoodId = bookingEvents.FoodId;
                bkEvent.VenueId = bookingEvents.VenueId;
                bkEvent.Createdate = DateTime.Now;
                bkEvent.Createdby = bookingEvents.CreatedBy;
                bkEvent.BookingDate = bookingEvents.BookingDate;
                var food = await _dbContext.tblFood.FindAsync(bookingEvents.FoodId);
                var venue = await _dbContext.tblVenue.FindAsync(bookingEvents.VenueId);
                bkEvent.TotalCost = Convert.ToInt32(food.FoodCost * bookingEvents.NumberofPeople + venue.VenueCost);
                bkEvent.Status = "P";
                await _dbContext.tblBookingEvent.AddAsync(bkEvent);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            else
            {
                return false;
            }
        }

        public async Task<bool> DeleteBookingEvents(int id)
        {
            var rvenue = await _dbContext.tblBookingEvent.FindAsync(id);
            _dbContext.Remove(rvenue);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> EditBookingEvents(BookingEventViewModel bookingEvents)
        {
            BookingEvent editevent = await _dbContext.tblBookingEvent.FindAsync(bookingEvents.BookingId);
            editevent.EventId = bookingEvents.EventId;
            editevent.VenueId = bookingEvents.VenueId;
            var venue = await _dbContext.tblVenue.FindAsync(bookingEvents.VenueId);
            editevent.FoodId = bookingEvents.FoodId;
            var food = await _dbContext.tblFood.FindAsync(bookingEvents.FoodId);
            editevent.TotalCost= Convert.ToInt32((food.FoodCost * bookingEvents.NumberofPeople) + venue.VenueCost);
            editevent.NumberofPeople = bookingEvents.NumberofPeople;
            editevent.Createdate = DateTime.Now;
            editevent.BookingDate = bookingEvents.BookingDate;
            _dbContext.Update(editevent);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> UpdateStatus(int bookingId,string status)
        {
            BookingEvent bkEvent = await _dbContext.tblBookingEvent.FindAsync(bookingId);
            bkEvent.Status = status;
            _dbContext.tblBookingEvent.Update(bkEvent);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<List<BookingEvent>> GetAllBookingEvents()
        {
            var allBookingEvents = await _dbContext.tblBookingEvent.ToListAsync();
            return allBookingEvents;
        }

        public async Task<BookingEvent> GetBookingEventsById(int id)
        {
            var rfood = await _dbContext.tblBookingEvent.FindAsync(id);
            return rfood;
        }
       

        public async Task<List<BookingEvent>> GetBookingEventsByCreatedBy(string createdBy)
        {
            var bookEvents =await _dbContext.tblBookingEvent.Where(x=>x.Createdby==createdBy)
                                                            .OrderByDescending(x=>x.BookingId).ToListAsync();
            return bookEvents;
        }
    }
}
