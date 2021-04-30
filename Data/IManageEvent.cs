using EventManagement.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventManagement.Data
{
    public interface IManageEvent
    {
        Task<List<Event>> GetAllEvents();
        Task<Event> GetEventById(int id);
        Task<bool> CreateEvent(Event events);
        Task<bool> EditEvent(Event newEvent);
        Task<bool> DeleteEvent(int id);
    }
}
