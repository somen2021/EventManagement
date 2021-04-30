using EventManagement.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventManagement.Data
{
    public class ManageEvent : IManageEvent
    {
        private readonly ApplicationDbContext _dbContext;
        public ManageEvent(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<bool> CreateEvent(Event events)
        {
            await _dbContext.tblEvent.AddAsync(events);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteEvent(int id)
        {
            var revent = await _dbContext.tblEvent.FindAsync(id);
            _dbContext.Remove(revent);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> EditEvent(Event newEvent)
        {
            Event obEvent = await _dbContext.tblEvent.FindAsync(newEvent.EventID);
            obEvent.EventType = newEvent.EventType;
            obEvent.Status = newEvent.Status;
             _dbContext.Update(obEvent);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<List<Event>> GetAllEvents()
        {
            var revent = await _dbContext.tblEvent.ToListAsync();
            return revent;
        }

        public async Task<Event> GetEventById(int id)
        {
            var revent = await _dbContext.tblEvent.FindAsync(id);
            return revent;
        }
    }
}
