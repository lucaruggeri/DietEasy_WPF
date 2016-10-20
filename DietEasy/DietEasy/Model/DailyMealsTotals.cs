using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DietEasy.Model
{
    public class DailyMealsTotals
    {
        public decimal CaloriesTotal {get; set; }
        public decimal CarbsTotal { get; set; }
        public decimal SugarTotal { get; set; } 
        public decimal FatsTotal { get; set; } 
        public decimal ProteinsTotal { get; set; } 

        public decimal CarbsCaloriesTotal { get; set; } 
        public decimal FatsCaloriesTotal { get; set; } 
        public decimal ProteinsCaloriesTotal { get; set; } 

        public decimal CarbsPercentage { get; set; } 
        public decimal FatsPercentage { get; set; } 
        public decimal ProteinsPercentage { get; set; } 
   }
}