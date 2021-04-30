using EventManagement.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventManagement.Data
{
    public class DataFood : IFood
    {
        private readonly ApplicationDbContext _dbContext;
        public DataFood(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<bool> CreateFood(Food food)
        {
           
            food.Createdate = DateTime.Now;
            await _dbContext.tblFood.AddAsync(food);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteFood(int id)
        {
            var rvenue = await _dbContext.tblFood.FindAsync(id);
            _dbContext.Remove(rvenue);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> EditFood(Food newFood)
        {
            Food obFood = await _dbContext.tblFood.FindAsync(newFood.FoodID);
            obFood.FoodTypeName = newFood.FoodTypeName;
            obFood.FoodCost = newFood.FoodCost;
            obFood.FoodType = newFood.FoodType;
            obFood.Createdby = newFood.Createdby;
            obFood.Createdate = DateTime.Now;
            _dbContext.Update(obFood);
            await _dbContext.SaveChangesAsync();
            return true;
        }


        public async Task<List<Food>> GetAllFood()
        {
            var rfood = await _dbContext.tblFood.ToListAsync();
            return rfood;
        }

        public async Task<Food> GetFoodById(int id)
        {
            var rfood = await _dbContext.tblFood.FindAsync(id);
            return rfood;
        }
    }
}
