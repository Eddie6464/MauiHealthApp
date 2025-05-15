using System;
using SQLite;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Nutrition.Model; // Import FoodItem model

namespace Nutrition.Services
{
    public class DatabaseService
    {
        private readonly SQLiteAsyncConnection _database;

        // Database connection
        public DatabaseService()
        {
            SQLitePCL.Batteries_V2.Init();

            var dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "database.db3");
            _database = new SQLiteAsyncConnection(dbPath);

            // Create FoodItem table (Handles all meal types)
            _database.CreateTableAsync<FoodItem>().Wait();
        }

        // Add food with meal type
        public async  Task AddFoodAsync(string foodName, int calories, string mealType)
        {
            var foodItem = new FoodItem 
            { 
                Name = foodName, 
                Calories = calories, 
                MealType = mealType // Specify if it's Breakfast, Lunch, or Dinner
            };
            await _database.InsertAsync(foodItem);
        }

        // Delete a food item
        public async Task DeleteFoodAsync(FoodItem food)
        {
            if (food != null)
            {
                await _database.DeleteAsync(food);
            }
        }

        // Get all food items
        public  Task<List<FoodItem>> GetFoodsAsync()
        {
            return _database.Table<FoodItem>().ToListAsync();
        }

        // Get food items based on meal type (Breakfast, Lunch, Dinner)
        public async Task<List<FoodItem>> GetFoodsByMealTypeAsync(string mealType)
        {
            return await _database.Table<FoodItem>()
                                 .Where(f => f.MealType == mealType)
                                 .ToListAsync();
        }

        // Get total calories for all food items
        public async Task<int> GetTotalCaloriesAsync()
        {
            var foods = await _database.Table<FoodItem>().ToListAsync();
            return foods.Sum(f => f.Calories);
        }

        // Water count
        public async Task<int> GetWaterCountAsync()
        {
            return await _database.Table<FoodItem>()
                                .Where(f => f.Name == "250ml of Water")
                                .CountAsync();
        }

        // Get the count of fruit and vegetables for 5 a day chart
         public async Task<int> GetHealthCountAsync()
        {
            return await _database.Table<FoodItem>()
                                .Where(f => f.Name == "Banana Weighted without skin 100g" || f.Name == "5 x Cherry Tomatoes" || f.Name == "Blueberries 100g" || f.Name == "Red grapes 100g" || f.Name == "Satsumas 90g" )
                                .CountAsync();
        }

    }
}
