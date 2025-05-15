using System;
using SQLite;

namespace Nutrition.Model;

// This class represents a food item in the database
public class FoodItem
{
   [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Name { get; set; }
        public int Calories {get; set;}
        public string MealType { get; set; }
        
}
