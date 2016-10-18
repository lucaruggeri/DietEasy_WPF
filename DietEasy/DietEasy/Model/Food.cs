using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DietEasy.Model
{
    public class Food
    {
        //PRIMARY KEY
        [SQLite.PrimaryKey]
        public int Id { get; set; }

        //personal data
        public string Name { get; set; }
        public decimal Calories { get; set; }
        public decimal Carbs { get; set; }
        public decimal Sugar { get; set; }
        public decimal Fats { get; set; }
        public decimal Proteins { get; set; }
        public decimal ServingSizeGrams { get; set; }
        public string ServingSizeDescription { get; set; }

        public decimal CaloriesInGrams(decimal grams)
        {
            return GetNutritionalValueForGrams(this.Calories, grams);
        }
        public decimal CaloriesInServingSize(decimal servingSizes)
        {
            return GetNutritionalValueForGrams(this.Calories, this.ServingSizeGrams * servingSizes);
        }
        public decimal CarbsInGrams(decimal grams)
        {
            return GetNutritionalValueForGrams(this.Carbs, grams);
        }
        public decimal CarbsInServingSize(decimal servingSizes)
        {
            return GetNutritionalValueForGrams(this.Carbs, this.ServingSizeGrams * servingSizes);
        }
        public decimal SugarsInGrams(decimal grams)
        {
            return GetNutritionalValueForGrams(this.Sugar, grams);
        }
        public decimal SugarsInServingSize(decimal servingSizes)
        {
            return GetNutritionalValueForGrams(this.Sugar, this.ServingSizeGrams * servingSizes);
        }
        public decimal FatsInGrams(decimal grams)
        {
            return GetNutritionalValueForGrams(this.Fats, grams);
        }
        public decimal FatsInServingSize(decimal servingSizes)
        {
            return GetNutritionalValueForGrams(this.Fats, this.ServingSizeGrams * servingSizes);
        }
        public decimal ProteinsInGrams(decimal grams)
        {
            return GetNutritionalValueForGrams(this.Proteins, grams);
        }
        public decimal ProteinsInServingSize(decimal servingSizes)
        {
            return GetNutritionalValueForGrams(this.Proteins, this.ServingSizeGrams * servingSizes);
        }

        private decimal GetNutritionalValueForGrams(decimal value, decimal grams)
        {
            decimal result = 0;
            decimal valuesInOneGram = 0;

            if (value > 0)
            {
                valuesInOneGram = Decimal.Divide(value, 100);
                result = Decimal.Multiply(valuesInOneGram, grams);

                if (result < 0)
                {
                    result = 0;
                }
            }
            else
            {
                result = 0;
            }

            return result;
        }
    }
}