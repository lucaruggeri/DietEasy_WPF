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

        public static void AddDayMeal(int foodId, int quantity)
        {
            DayMeal dayMeal = new DayMeal();
            dayMeal.Day = DateTime.Now.ToLocalTime();
            dayMeal.FoodId = foodId;
            dayMeal.FoodQuantity = quantity;
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
                total = total + food.CaloriesInGrams(dayMeal.FoodQuantity);                
            }

            return total;
        }

        public static decimal GetDayMealTotalCarbs(DateTime date)
        {
            decimal total = 0;

            foreach (DayMeal dayMeal in GetDayMealsList(date))
            {
                Food food = GetFood(dayMeal.FoodId);
                total = total + food.CarbsInGrams(dayMeal.FoodQuantity);
            }

            return total;
        }

        public static decimal GetDayMealTotalFats(DateTime date)
        {
            decimal total = 0;

            foreach (DayMeal dayMeal in GetDayMealsList(date))
            {
                Food food = GetFood(dayMeal.FoodId);
                total = total + food.FatsInGrams(dayMeal.FoodQuantity);
            }

            return total;
        }

        public static decimal GetDayMealTotalProteins(DateTime date)
        {
            decimal total = 0;

            foreach (DayMeal dayMeal in GetDayMealsList(date))
            {
                Food food = GetFood(dayMeal.FoodId);
                total = total + food.ProteinsInGrams(dayMeal.FoodQuantity);
            }

            return total;
        }
    }
}