using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DietEasy.Model
{
    public class DayMeal
    {
        //PRIMARY KEY
        [SQLite.PrimaryKey]
        public int Id { get; set; }

        public DateTime Day { get; set; }
        public int FoodId { get; set; }
        public string FoodName { get; set; }
        public decimal Grams { get; set; }
        public decimal ServingSizes { get; set; }
        public decimal Calories { get; set; }
        public decimal Carbs { get; set; }
        public decimal Sugar { get; set; }
        public decimal Fats { get; set; }
        public decimal Proteins { get; set; }
    }
}