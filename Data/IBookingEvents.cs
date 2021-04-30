using EventManagement.Models;
using EventManagement.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventManagement.Data
{
    public interface IBookingEvents
    {
        Task<List<BookingEvent>> GetAllBookingEvents();
        Task<BookingEvent> GetBookingEventsById(int id);
        Task<bool> CreateBookingEvents(BookingEventViewModel bookingEvents);
        Task<bool> EditBookingEvents(BookingEventViewModel bookingEvents);
        Task<bool> DeleteBookingEvents(int id);

        Task<List<BookingEvent>> GetBookingEventsByCreatedBy(string createdBy);
        Task<bool> UpdateStatus(int bookingId, string status);
    }
}
