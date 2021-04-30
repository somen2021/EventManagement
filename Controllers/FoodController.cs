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
    public class FoodController : Controller
    {
        private readonly IFood _newFood;
        public FoodController(IFood newFood)
        {
            _newFood = newFood;
        }
        // GET: FoodController
        public async Task<ActionResult> Index()
        {
            List<Food> lstEvents = await _newFood.GetAllFood();
            return View(lstEvents);
        }

        // GET: FoodController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: FoodController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(Food newFood)
        {
            try
            {
                if (await _newFood.CreateFood(newFood))
                {
                    return RedirectToAction("Index", "Food");
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

        // GET: FoodController/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            Food newVenue = await _newFood.GetFoodById(id);
            return View(newVenue);
        }

        // POST: FoodController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(Food newFood)
        {
            try
            {
                if (await _newFood.EditFood(newFood))
                {
                    return RedirectToAction("Index", "Food");
                }
                else
                {
                    return RedirectToAction("Index", "Food");
                }
            }
            catch
            {
                return View();
            }
        }


        // POST: FoodController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(int foodid)
        {
            try
            {
                if (await _newFood.DeleteFood(foodid))
                {
                    return RedirectToAction("Index", "Food");
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
