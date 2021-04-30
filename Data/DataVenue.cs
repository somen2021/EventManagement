using EventManagement.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventManagement.Data
{
    public class DataVenue : IVenue
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly UserManager<IdentityUser> _userManager;
        public DataVenue(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<bool> CreateVenue(Venue venue)
        {

            venue.Createdate = DateTime.Now;
            await _dbContext.tblVenue.AddAsync(venue);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteVenue(int id)
        {
            var rvenue = await _dbContext.tblVenue.FindAsync(id);
            _dbContext.Remove(rvenue);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> EditVenue(Venue newVenue)
        {
            Venue obVenue = await _dbContext.tblVenue.FindAsync(newVenue.VenueID);
            obVenue.VenueName = newVenue.VenueName;
            obVenue.VenueCost = newVenue.VenueCost;
            _dbContext.Update(obVenue);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<List<Venue>> GetAllVenue()
        {
            var rvenue = await _dbContext.tblVenue.ToListAsync();
            return rvenue;
        }

        public async Task<Venue> GetVenueById(int id)
        {
            var rvenue = await _dbContext.tblVenue.FindAsync(id);
            return rvenue;
        }
    }
}
