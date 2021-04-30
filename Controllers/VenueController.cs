using EventManagement.Data;
using EventManagement.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventManagement.Controllers
{
    public class VenueController : Controller
    {
        private readonly IVenue _newVenue;
        public VenueController(IVenue newVenue)
        {
            _newVenue = newVenue;
        }
      
        // GET: VenueController
        public async Task<ViewResult> Index()
        {
            List<Venue> lstEvents = await _newVenue.GetAllVenue();
            return View(lstEvents);
        }

        // GET: VenueController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: VenueController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task< ActionResult> Create(Venue newVenue)
        {
            try
            {
                if (await _newVenue.CreateVenue(newVenue))
                {
                    return RedirectToAction("Index", "Venue");
                }
                else
                {
                    return View();
                }
            }
            catch
            {
                return View();
            }
        }

        // GET: VenueController/Edit/5
        public async Task< ActionResult> Edit(int id)
        {
            Venue newNenue = await _newVenue.GetVenueById(id);
            return View(newNenue);
        }

        // POST: VenueController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task< ActionResult> Edit(Venue newVenue)
        {
            try
            {
                if (await _newVenue.EditVenue(newVenue))
                {
                    return RedirectToAction("Index", "Venue");
                }
                else
                {
                    return RedirectToAction("Index", "Venue");
                }
            }
            catch
            {
                return View();
            }
        }

        // POST: VenueController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(int venueid)
        {
            try
            {
                if (await _newVenue.DeleteVenue(venueid))
                {
                    return RedirectToAction("Index", "Venue");
                }
                else
                {
                    return View();
                }
            }
            catch
            {
                return View();
            }
        }
    }
}
