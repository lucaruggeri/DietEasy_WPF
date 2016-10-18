using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DietEasy.Model
{
    public class DayMeal
    {
        public DateTime Day { get; set; }
        public int FoodId { get; set; }
        public int FoodQuantity { get; set; }
    }
}