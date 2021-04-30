using EventManagement.Data;
using EventManagement.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventManagement.Controllers
{
    //[Authorize]
    //[Authorize(Roles ="Customer")]
    public class EventController : Controller
    {
        private readonly IManageEvent _newEvent;

        public EventController(IManageEvent newEvent)
        {
            _newEvent = newEvent;
        }
        // GET: EventController
        public async Task<ViewResult> Index()
        {
            List<Event> lstEvents = await _newEvent.GetAllEvents();

            return View(lstEvents);
        }

        // GET: EventController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: EventController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(Event newEvent)
        {

            try
            {
                if (await _newEvent.CreateEvent(newEvent))
                {
                    return RedirectToAction("Index", "Event");
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

        // GET: EventController/Edit/5
        [HttpGet]
        public async Task<ActionResult> Edit(int id)
        {
            Event newEvent = await _newEvent.GetEventById(id);
            return View(newEvent);
        }

        // POST: EventController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(Event newEvent)
        {
            try
            {
                if (await _newEvent.EditEvent(newEvent))
                {
                    return RedirectToAction("Index", "Event");
                }
                else
                {
                    return RedirectToAction("Index", "Event");
                }
            }
            catch
            {
                return View();
            }
        }

        // POST: EventController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(int eventId)
        {
            try
            {
                if( await _newEvent.DeleteEvent(eventId))
                {
                    return RedirectToAction("Index","Event");
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
