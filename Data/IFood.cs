using EventManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventManagement.Data
{
    public interface IFood
    {
        Task<List<Food>> GetAllFood();
        Task<Food> GetFoodById(int id);
        Task<bool> CreateFood(Food food);
        Task<bool> EditFood(Food newFood);
        Task<bool> DeleteFood(int id);
    }
}
