using EventManagement.Data;
using EventManagement.Models;
using EventManagement.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventManagement.Controllers
{
    public class BookingEventController : Controller
    {
        private readonly IBookingEvents _bookingEvent;
        private readonly IManageEvent _manageEvent;
        private readonly IVenue _manageVenue;
        private readonly IFood _manageFood;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public BookingEventController(IBookingEvents bookingEvent, IManageEvent manageEvent, IVenue manageVenue, IFood manageFood, IHttpContextAccessor httpContextAccessor)
        {
            _bookingEvent = bookingEvent;
            _manageEvent = manageEvent;
            _manageVenue = manageVenue;
            _manageFood = manageFood;
            _httpContextAccessor = httpContextAccessor;
        }
        // GET: BookingEventController
        public async Task<ActionResult> Index()
        {
            List<BookingEventViewModel> lstbkviewmodel = new List<BookingEventViewModel>();
            var user = _httpContextAccessor.HttpContext.User;
            var bookedEvent = await _bookingEvent.GetBookingEventsByCreatedBy(user.Identity.Name);
            foreach (var item in bookedEvent)
            {
                BookingEventViewModel bkviwmodel = new BookingEventViewModel();
                bkviwmodel.BookingId = item.BookingId;
                bkviwmodel.EventId = item.EventId;
                var selectevent = await _manageEvent.GetEventById(item.EventId);
                bkviwmodel.EventType = selectevent.EventType;
                bkviwmodel.VenueId = item.VenueId;
                var selectvenue = await _manageVenue.GetVenueById(item.VenueId);
                bkviwmodel.VenueName = selectvenue.VenueName;
                bkviwmodel.FoodId = item.FoodId;

                var selectfood = await _manageFood.GetFoodById(item.FoodId);
                bkviwmodel.FoodType = selectfood.FoodType == "1" ? "Veg" : "Non-Veg";
                bkviwmodel.MealType = selectfood.MealType == "1" ? "Lunch" : "Dinner";
                bkviwmodel.NumberofPeople = item.NumberofPeople;
                bkviwmodel.TotalCost = item.TotalCost;
                bkviwmodel.Createdate = item.Createdate;
                bkviwmodel.Status = item.Status == "P" ? "Processing" : (item.Status == "A" ? "Approved" : "Rejected");
                lstbkviewmodel.Add(bkviwmodel);
            }
            return View(lstbkviewmodel);
        }

        // GET: BookingEventController/Details/5
        public async Task<ActionResult> Details(int id)
        {
            BookingEvent bkevent = await _bookingEvent.GetBookingEventsById(id);
            BookingEventViewModel bkeventviewmodel = new BookingEventViewModel();
            var events = await _manageEvent.GetEventById(bkevent.EventId);
            bkeventviewmodel.EventType = events.EventType;
            var venue = await _manageVenue.GetVenueById(bkevent.VenueId);
            bkeventviewmodel.VenueName = venue.VenueName;
            bkeventviewmodel.VenueCost = Convert.ToInt32(venue.VenueCost);

            var food = await _manageFood.GetFoodById(bkevent.FoodId);
            bkeventviewmodel.FoodType = food.FoodType == "1" ? "Veg" : "Non-Veg";
            bkeventviewmodel.MealType = food.MealType == "1" ? "Lunch" : "Dinner";
            bkeventviewmodel.FoodCost = Convert.ToInt32(food.FoodCost);
            bkeventviewmodel.Status = bkevent.Status == "P" ? "Processing" : bkevent.Status == "A" ? "Approved" : "Rejected";

            bkeventviewmodel.TotalCost = bkevent.TotalCost;
            bkeventviewmodel.NumberofPeople = bkevent.NumberofPeople;
            bkeventviewmodel.BookingDate = bkevent.BookingDate;
            bkeventviewmodel.Createdate = bkevent.Createdate;

            return View(bkeventviewmodel);
        }

        // GET: BookingEventController/Create
        public async Task<ActionResult> Create()
        {
            var events = await _manageEvent.GetAllEvents();
            List<SelectListItem> lstevent = new List<SelectListItem>();
            for (int i = 0; i < events.Count; i++)
            {
                lstevent.Add(new SelectListItem { Text = events[i].EventType, Value = Convert.ToString(events[i].EventID) });
            }
            ViewBag.Eventlist = lstevent;

            var venue = await _manageVenue.GetAllVenue();
            List<SelectListItem> lstvenue = new List<SelectListItem>();
            for (int i = 0; i < venue.Count; i++)
            {
                lstvenue.Add(new SelectListItem { Text = venue[i].VenueName, Value = Convert.ToString(venue[i].VenueID) });
            }
            ViewBag.Venuelist = lstvenue;

            var food = await _manageFood.GetAllFood();
            List<SelectListItem> lstFoodType = new List<SelectListItem>();
            for (int i = 0; i < food.Count; i++)
            {
                lstFoodType.Add(new SelectListItem
                {
                    Text = (Convert.ToString(food[i].FoodType) == "1" ? "Veg" : "Non-Veg") + "/" + (Convert.ToString(food[i].MealType) == "1" ? "Lunch" : "Dinner"),
                    Value = Convert.ToString(food[i].FoodID)
                });

            }
            ViewBag.FoodTypelist = lstFoodType;
            BookingEventViewModel ob = new BookingEventViewModel();
            return View(ob);
        }

        // POST: BookingEventController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(BookingEventViewModel bookingEventViewModel, IFormCollection form)
        {
            try
            {
                string selectevent = form["Eventlist"].ToString();
                string selectvenue = form["Venuelist"].ToString();
                string selectfood = form["FoodTypelist"].ToString();
                bookingEventViewModel.EventId = Convert.ToInt32(selectevent);
                bookingEventViewModel.VenueId = Convert.ToInt32(selectvenue);
                bookingEventViewModel.FoodId = Convert.ToInt32(selectfood);
                bookingEventViewModel.Createdate = DateTime.Now;
                if (await _bookingEvent.CreateBookingEvents(bookingEventViewModel))
                {
                    return RedirectToAction("Index", "BookingEvent");
                }
                else
                {
                    var events = await _manageEvent.GetAllEvents();
                    List<SelectListItem> lstevent = new List<SelectListItem>();
                    for (int i = 0; i < events.Count; i++)
                    {
                        lstevent.Add(new SelectListItem { Text = events[i].EventType, Value = Convert.ToString(events[i].EventID) });
                    }
                    ViewBag.Eventlist = lstevent;

                    var venue = await _manageVenue.GetAllVenue();
                    List<SelectListItem> lstvenue = new List<SelectListItem>();
                    for (int i = 0; i < venue.Count; i++)
                    {
                        lstvenue.Add(new SelectListItem { Text = venue[i].VenueName, Value = Convert.ToString(venue[i].VenueID) });
                    }
                    ViewBag.Venuelist = lstvenue;

                    var food = await _manageFood.GetAllFood();
                    List<SelectListItem> lstFoodType = new List<SelectListItem>();
                    for (int i = 0; i < food.Count; i++)
                    {
                        lstFoodType.Add(new SelectListItem
                        {
                            Text = (Convert.ToString(food[i].FoodType) == "1" ? "Veg" : "Non-Veg") + "/" + (Convert.ToString(food[i].MealType) == "1" ? "Lunch" : "Dinner"),
                            Value = Convert.ToString(food[i].FoodID)
                        });

                    }
                    ViewBag.FoodTypelist = lstFoodType;
                    return View(bookingEventViewModel);
                }
            }
            catch
            {
                return View(bookingEventViewModel);
            }
        }

        // GET: BookingEventController/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            BookingEvent bkevent = await _bookingEvent.GetBookingEventsById(id);
            BookingEventViewModel bkeventviewmodel = new BookingEventViewModel();
            var events = await _manageEvent.GetAllEvents();
            List<SelectListItem> lstevent = new List<SelectListItem>();
            for (int i = 0; i < events.Count; i++)
            {
                lstevent.Add(new SelectListItem { Text = events[i].EventType, Value = Convert.ToString(events[i].EventID) });
            }
            lstevent.Find(x => x.Value == bkevent.EventId.ToString()).Selected = true;
            ViewBag.Eventlist = lstevent;

            var venue = await _manageVenue.GetAllVenue();
            List<SelectListItem> lstvenue = new List<SelectListItem>();
            for (int i = 0; i < venue.Count; i++)
            {
                lstvenue.Add(new SelectListItem { Text = venue[i].VenueName, Value = Convert.ToString(venue[i].VenueID) });
            }
            lstvenue.Find(x => x.Value == bkevent.VenueId.ToString()).Selected = true;
            ViewBag.Venuelist = lstvenue;

            var food = await _manageFood.GetAllFood();
            var lstfood = food.GroupBy(x => x.FoodID).ToList();
            List<SelectListItem> lstFoodType = new List<SelectListItem>();
            for (int i = 0; i < lstfood.Count; i++)
            {
                lstFoodType.Add(new SelectListItem
                {
                    Text = (Convert.ToString(food[i].FoodType) == "1" ? "Veg" : "Non-Veg") + "/" + (Convert.ToString(food[i].MealType) == "1" ? "Lunch" : "Dinner"),
                    Value = Convert.ToString(food[i].FoodID)
                });
            }
            lstFoodType.Find(x => x.Value == bkevent.FoodId.ToString()).Selected = true;
            ViewBag.FoodTypelist = lstFoodType;

            bkeventviewmodel.Status = bkevent.Status == "P" ? "Processing" : bkevent.Status == "A" ? "Approved" : "Rejected";
            bkeventviewmodel.TotalCost = bkevent.TotalCost;
            bkeventviewmodel.NumberofPeople = bkevent.NumberofPeople;
            bkeventviewmodel.BookingDate = bkevent.BookingDate;

            return View(bkeventviewmodel);
        }

        // POST: BookingEventController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, IFormCollection form)
        {
            try
            {
                BookingEventViewModel bookingEventViewModel = new BookingEventViewModel();
                string selectevent = form["Eventlist"].ToString();
                string selectvenue = form["Venuelist"].ToString();
                string selectfood = form["FoodTypelist"].ToString();
                bookingEventViewModel.EventId = Convert.ToInt32(selectevent);
                bookingEventViewModel.VenueId = Convert.ToInt32(selectvenue);
                bookingEventViewModel.FoodId = Convert.ToInt32(selectfood);
                bookingEventViewModel.BookingId = id;
                bookingEventViewModel.NumberofPeople = Convert.ToInt32(form["NumberofPeople"].ToString());
                bookingEventViewModel.Createdate = DateTime.Now;
                bookingEventViewModel.BookingDate = Convert.ToDateTime(form["BookingDate"]);
                if (await _bookingEvent.EditBookingEvents(bookingEventViewModel))
                {
                    return RedirectToAction("Index", "BookingEvent");
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

        // POST: BookingEventController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                if (await _bookingEvent.DeleteBookingEvents(id))
                {
                    return RedirectToAction("Index", "BookingEvent");
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
