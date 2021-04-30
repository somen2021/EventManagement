using EventManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventManagement.Data
{
    public interface IVenue
    {
        Task<List<Venue>> GetAllVenue();
        Task<Venue> GetVenueById(int id);
        Task<bool> CreateVenue(Venue venue);
        Task<bool> EditVenue(Venue newEvent);
        Task<bool> DeleteVenue(int id);
    }
}
