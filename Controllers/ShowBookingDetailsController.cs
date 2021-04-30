using EventManagement.Data;
using EventManagement.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventManagement.Controllers
{
    public class ShowBookingDetailsController : Controller
    {
        private readonly IBookingEvents _bookingEvent;
        private readonly IManageEvent _manageEvent;
        private readonly IVenue _manageVenue;
        private readonly IFood _manageFood;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public ShowBookingDetailsController(IBookingEvents bookingEvent, IManageEvent manageEvent, IVenue manageVenue, IFood manageFood, IHttpContextAccessor httpContextAccessor)
        {
            _bookingEvent = bookingEvent;
            _manageEvent = manageEvent;
            _manageVenue = manageVenue;
            _manageFood = manageFood;
            _httpContextAccessor = httpContextAccessor;
        }
        // GET: ShowBookingDetailsController
        public async Task<ActionResult> Index()
        {
            List<BookingEventViewModel> bkViewModel = new List<BookingEventViewModel>();
            var lstevent = await _manageEvent.GetAllEvents();
            var lstvenue = await _manageVenue.GetAllVenue();
            var lstfood = await _manageFood.GetAllFood();
            var bkEvents = await _bookingEvent.GetAllBookingEvents();
            foreach (var item in bkEvents)
            {
                BookingEventViewModel obBkViewModel = new BookingEventViewModel();
                obBkViewModel.BookingDate = item.BookingDate;
                obBkViewModel.BookingId = item.BookingId;
                //obBkViewModel.Createdate = item.Createdate;
                obBkViewModel.CreatedBy = item.Createdby;
                obBkViewModel.EventId = item.EventId;
                obBkViewModel.EventType = lstevent.Where(x => x.EventID == item.EventId)
                                                    .Select(x => x.EventType).Single();
                obBkViewModel.VenueId = item.VenueId;
                obBkViewModel.VenueName = lstvenue.Where(x => x.VenueID == item.VenueId)
                                                    .Select(x => x.VenueName).Single();
                //obBkViewModel.VenueCost = Convert.ToInt32(lstvenue.Where(x => x.VenueID == item.VenueId)
                //.Select(x => x.VenueCost));
                obBkViewModel.FoodId = item.FoodId;
                obBkViewModel.FoodType = lstfood.Where(x => x.FoodID == item.FoodId)
                                                .Select(x => x.FoodType).Single();
                //obBkViewModel.FoodCost = Convert.ToInt32(lstfood.Where(x => x.FoodID == item.FoodId)
                //                                                .Select(x => x.FoodCost));
                obBkViewModel.MealType = lstfood.Where(x => x.FoodID == item.FoodId)
                                                .Select(x => x.MealType).Single();
                obBkViewModel.NumberofPeople = item.NumberofPeople;
                obBkViewModel.TotalCost = item.TotalCost;
                obBkViewModel.Status = item.Status;
                bkViewModel.Add(obBkViewModel);
            }
            return View(bkViewModel);
        }

        // GET: ShowBookingDetailsController/Details/5
        public async Task<ActionResult> Details(int id)
        {
            BookingEventViewModel obBkViewModel = new BookingEventViewModel();
            var lstevent = await _manageEvent.GetAllEvents();
            var lstvenue = await _manageVenue.GetAllVenue();
            var lstfood = await _manageFood.GetAllFood();
            var bkEvents = await _bookingEvent.GetBookingEventsById(id);
            obBkViewModel.BookingDate = bkEvents.BookingDate;
            obBkViewModel.BookingId = bkEvents.BookingId;
            obBkViewModel.Createdate = bkEvents.Createdate;
            obBkViewModel.CreatedBy = bkEvents.Createdby;
            obBkViewModel.EventId = bkEvents.EventId;
            obBkViewModel.EventType = lstevent.Where(x => x.EventID == bkEvents.EventId)
                                                .Select(x => x.EventType).Single();
            obBkViewModel.VenueId = bkEvents.VenueId;
            obBkViewModel.VenueName = lstvenue.Where(x => x.VenueID == bkEvents.VenueId)
                                                .Select(x => x.VenueName).Single();
            obBkViewModel.VenueCost =Convert.ToInt32( lstvenue.Where(x => x.VenueID == bkEvents.VenueId)
                                                                .Select(x => x.VenueCost).Single());
            obBkViewModel.FoodId = bkEvents.FoodId;
            obBkViewModel.FoodType = lstfood.Where(x => x.FoodID == bkEvents.FoodId)
                                            .Select(x => x.FoodType).Single();
            obBkViewModel.FoodCost = Convert.ToInt32(lstfood.Where(x => x.FoodID == bkEvents.FoodId)
                                                            .Select(x => x.FoodCost).Single());
            obBkViewModel.MealType = lstfood.Where(x => x.FoodID == bkEvents.FoodId)
                                                .Select(x => x.MealType).Single();
            obBkViewModel.NumberofPeople = bkEvents.NumberofPeople;
            obBkViewModel.TotalCost = bkEvents.TotalCost;
            obBkViewModel.Status = bkEvents.Status;
            return View(obBkViewModel);
        }
        [HttpPost]
        public async Task< ActionResult> Details(int id,string submit)
        {
            submit=submit == "Approve" ? "A" : "R";
            if (await _bookingEvent.UpdateStatus(id, submit))
            {
                return RedirectToAction("Index", "ShowBookingDetails");
            }
            else
            {
                return View();
            }
            
        }
    }
}
