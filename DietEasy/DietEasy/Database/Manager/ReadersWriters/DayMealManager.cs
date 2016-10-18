using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.IO;
using SQLite;
using DietEasy.Model;

namespace DietEasy.Database
{
    public static partial class DatabaseManager
    {

        public static DayMeal GetDayMeal(DateTime date)
        {
            List<DayMeal> list = (from x in db.Table<DayMeal>()
                                where x.Day.Equals(date)
                                select x
                                    ).ToList();

            return list[0];
        }

        public static List<Food> SearchFood(string searchString)
        {
            if (searchString.Trim() != null)
            {
                if (searchString.Trim() != string.Empty)
                {
                    return GetFilteredFoodList(searchString);
                }
                return GetFoodList();
            }
            return GetFoodList();
        }

        public static void DeleteDailyFood(DayMeal dayMeal)
        {
            try
            {
                db.Delete(dayMeal);
            }
            catch (Exception exception)
            {
            }
        }

        public static List<DayMeal> GetDayMealsList()
        {
            List<DayMeal> list = (from x in db.Table<DayMeal>()
                                  orderby x.Day descending
                                  select x
                                ).ToList();

            return list;
        }

        public static List<DayMeal> GetDayMealsList(DateTime date)
        {
            //List<DayMeal> list = (from x in db.Table<DayMeal>()
            //                      where x.Day.Year == date.Year
            //                      && x.Day.Month == date.Month
            //                      && x.Day.Day == date.Day                                   
            //                      orderby x.Day descending
            //                      select x
            //                    ).ToList();

            List<DayMeal> list = new List<DayMeal>();
            foreach (DayMeal dayMeal in db.Table<DayMeal>())
            {
                if (dayMeal.Day.Year == date.Year)
                {
                    if (dayMeal.Day.Month == date.Month)
                    {
                        if (dayMeal.Day.Day == date.Day)
                        {
                            list.Add(dayMeal);
                        }
                    }
                }
            }

            return list;
        }

        public static int GetLastDayMealId()
        {
            try
            {
                return db.Table<DayMeal>().OrderByDescending(x => x.Id).FirstOrDefault().Id;
            }
            catch
            {
                return 0;
            }
        }

        public static void AddDayMeal(Food food, decimal servingSize)
        {
            DayMeal dayMeal = new DayMeal();
            dayMeal.Id = DatabaseManager.GetLastDayMealId() + 1;
            dayMeal.Day = DateTime.Now.ToLocalTime();
            dayMeal.FoodId = food.Id;
            dayMeal.FoodName = food.Name;
            dayMeal.Grams = servingSize * food.ServingSizeGrams;
            dayMeal.Calories = food.CaloriesInServingSize(servingSize);
            dayMeal.Carbs = food.CarbsInServingSize(servingSize);
            dayMeal.Sugar = food.SugarsInServingSize(servingSize);
            dayMeal.Proteins = food.ProteinsInServingSize(servingSize);
            dayMeal.Fats = food.FatsInServingSize(servingSize);
            db.Insert(dayMeal);
        }

        public static int GetDayMealsNumber()
        {
            try
            {
                return (from x in db.Table<DayMeal>() select x).Count();
            }
            catch
            {
                return 0;
            }
        }

        public static DateTime GetLastDayOfMeals()
        {
            try
            {
                return db.Table<DayMeal>().OrderByDescending(x => x.Day).FirstOrDefault().Day;
            }
            catch
            {
                return DateTime.MinValue;
            }
        }

        public static decimal GetDayMealTotalCalories(DateTime date)
        {
            decimal total = 0;

            foreach(DayMeal dayMeal in GetDayMealsList(date))
            {
                Food food = GetFood(dayMeal.FoodId);
                total = total + food.CaloriesInGrams(dayMeal.Grams);                
            }

            return total;
        }

        public static decimal GetDayMealCarbsCalories(DateTime date)
        {
            return GetDayMealTotalCarbs(date) * 4;
        }
        public static decimal GetDayMealFatsCalories(DateTime date)
        {
            return GetDayMealTotalFats(date) * 9;
        }
        public static decimal GetDayMealProteinsCalories(DateTime date)
        {
            return GetDayMealTotalProteins(date) * 4;
        }

        public static decimal GetDayMealCarbsPercentage(DateTime date)
        {
            return (int)Math.Round((double)Decimal.Divide((100 * GetDayMealCarbsCalories(date)), GetDayMealTotalCalories(date)));
        }
        public static decimal GetDayMealFatsPercentage(DateTime date)
        {
            return (int)Math.Round((double)Decimal.Divide((100 * GetDayMealFatsCalories(date)), GetDayMealTotalCalories(date)));
        }
        public static decimal GetDayMealProteinsPercentage(DateTime date)
        {
            return (int)Math.Round((double)Decimal.Divide((100 * GetDayMealProteinsCalories(date)), GetDayMealTotalCalories(date)));
        }

        public static decimal GetDayMealTotalCarbs(DateTime date)
        {
            decimal total = 0;

            foreach (DayMeal dayMeal in GetDayMealsList(date))
            {
                Food food = GetFood(dayMeal.FoodId);
                total = total + food.CarbsInGrams(dayMeal.Grams);
            }

            return total;
        }

        public static decimal GetDayMealTotalSugar(DateTime date)
        {
            decimal total = 0;

            foreach (DayMeal dayMeal in GetDayMealsList(date))
            {
                Food food = GetFood(dayMeal.FoodId);
                total = total + food.SugarsInGrams(dayMeal.Grams);
            }

            return total;
        }

        public static decimal GetDayMealTotalFats(DateTime date)
        {
            decimal total = 0;

            foreach (DayMeal dayMeal in GetDayMealsList(date))
            {
                Food food = GetFood(dayMeal.FoodId);
                total = total + food.FatsInGrams(dayMeal.Grams);
            }

            return total;
        }

        public static decimal GetDayMealTotalProteins(DateTime date)
        {
            decimal total = 0;

            foreach (DayMeal dayMeal in GetDayMealsList(date))
            {
                Food food = GetFood(dayMeal.FoodId);
                total = total + food.ProteinsInGrams(dayMeal.Grams);
            }

            return total;
        }
    }
}