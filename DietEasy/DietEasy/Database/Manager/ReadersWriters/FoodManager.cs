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

        public static void PopulateFoodTable()
        {
            //drop, create and populate FOOD table
            db.DropTable<Food>();
            db.CreateTable<Food>();

            db.Insert(new Food { Id = GenerateNewFoodId(), Name = "Uovo sodo", Calories = 65, Carbs = 4.37m, Fats = 0.34m, Proteins = 5.54m });
            db.Insert(new Food { Id = GenerateNewFoodId(), Name = "Petto di pollo", Calories = 195, Carbs = 0m, Fats = 7.72m, Proteins = 29.55m });
            db.Insert(new Food { Id = GenerateNewFoodId(), Name = "Broccoli", Calories = 34, Carbs = 6.64m, Fats = 0.37m, Proteins = 2.82m });
            db.Insert(new Food { Id = GenerateNewFoodId(), Name = "Calvé Peanut Butter", Calories = 664, Carbs = 11m, Fats = 58m, Proteins = 21m });
            db.Insert(new Food { Id = GenerateNewFoodId(), Name = "Pringles Sour Cream & Onion", Calories = 515, Carbs = 51m, Fats = 33m, Proteins = 4m });
            db.Insert(new Food { Id = GenerateNewFoodId(), Name = "Pringles Original", Calories = 522, Carbs = 51m, Fats = 34m, Proteins = 3.8m });
            db.Insert(new Food { Id = GenerateNewFoodId(), Name = "Pringles Paprika", Calories = 503, Carbs = 52m, Fats = 31m, Proteins = 4.7m });
            db.Insert(new Food { Id = GenerateNewFoodId(), Name = "Braciola di maiale (griglia o forno)", Calories = 240, Carbs = 0m, Fats = 13.8m, Proteins = 27.09m });
            db.Insert(new Food { Id = GenerateNewFoodId(), Name = "Cavoletti di Bruxelles", Calories = 47, Carbs = 5.4m, Fats = 0.7m, Proteins = 2.8m });
            db.Insert(new Food { Id = GenerateNewFoodId(), Name = "Tacchino al forno Aia Aequilibrium", Calories = 97, Carbs = 3.10m, Fats = 1m, Proteins = 19m });
            db.Insert(new Food { Id = GenerateNewFoodId(), Name = "Sottilette Light Kraft", Calories = 216, Carbs = 9.6m, Fats = 9.6m, Proteins = 20.4m });
            db.Insert(new Food { Id = GenerateNewFoodId(), Name = "Salsa tartara Conad", Calories = 643, Carbs = 2.9m, Fats = 69.5m, Proteins = 1.4m });
            db.Insert(new Food { Id = GenerateNewFoodId(), Name = "Millefoglie Matilde Vincenzi", Calories = 548, Carbs = 54.4m, Fats = 33.2m, Proteins = 6.4m });
            db.Insert(new Food { Id = GenerateNewFoodId(), Name = "Grisbì limone e ginseng", Calories = 539, Carbs = 57.48m, Fats = 31.14m, Proteins = 5.99m });
            db.Insert(new Food { Id = GenerateNewFoodId(), Name = "Hamburger di tacchino con erbette Amadori", Calories = 132, Carbs = 1.9m, Fats = 6.5m, Proteins = 16m });
            db.Insert(new Food { Id = GenerateNewFoodId(), Name = "Cordonbleu pizzaiola Aia", Calories = 213, Carbs = 11m, Fats = 13m, Proteins = 13m });
            db.Insert(new Food { Id = GenerateNewFoodId(), Name = "Crema di carciofi Alberti", Calories = 302, Carbs = 1.7m, Fats = 31m, Proteins = 1.8m });
            db.Insert(new Food { Id = GenerateNewFoodId(), Name = "Bigger Aia cotoletta di petto di tacchino", Calories = 223, Carbs = 12.5m, Fats = 12.5m, Proteins = 15m });
            db.Insert(new Food { Id = GenerateNewFoodId(), Name = "Zucchine", Calories = 21, Carbs = 3.11m, Fats = 0.4m, Proteins = 2.71m });
            db.Insert(new Food { Id = GenerateNewFoodId(), Name = "Prosciutto cotto alta qualità Aia Aequilibrium", Calories = 96, Carbs = 0m, Fats = 1.8m, Proteins = 20m });
        }

        public static void CreateFood(string name, string calories, string carbs, string fats, string proteins)
        {
            try 
            {
                Food newFood = new Food();
                newFood.Id = GenerateNewFoodId();
                newFood.Name = Convert.ToString(name);
                newFood.Calories = Convert.ToDecimal(calories);
                newFood.Carbs = Convert.ToDecimal(carbs);
                newFood.Fats = Convert.ToDecimal(fats);
                newFood.Proteins = Convert.ToDecimal(proteins);
            
                db.Insert(newFood);
            }
            catch
            {
            }
        }

        public static Food GetFood(int id)
        {
            List<Food> list = (from x in db.Table<Food>()
                               where x.Id.Equals(id)
                               select x
                                   ).ToList();

            return list[0];
        }

        public static List<Food> GetFoodList()
        {
            List<Food> list = (from x in db.Table<Food>()
                               orderby x.Name
                               select x
                                ).ToList();

            return list;
        }

        public static List<Food> GetFilteredFoodList(string searchString)
        {
            var list = (from x in db.Table<Food>()
                        orderby x.Name ascending
                        where x.Name.Contains(searchString)
                        select x
                        ).ToList();

            return list;
        }

        public static List<Food> GetFoodList(string foodName)
        {
            List<Food> list = (from x in db.Table<Food>()
                               where x.Name.Contains(foodName)
                               orderby x.Name 
                               select x
                                ).ToList();

            return list;
        }

        public static int GetFoodNumber()
        {
            try
            {
                return (from x in db.Table<Food>() select x).Count();
            }
            catch
            {
                return 0;
            }
        }

        public static int GenerateNewFoodId()
        {
            return GetLastFoodId() + 1;
        }

        public static int GetLastFoodId()
        {
            try
            {
                return db.Table<Food>().OrderByDescending(x => x.Id).FirstOrDefault().Id;
            }
            catch
            {
                return 0;
            }
        }

        public static void InsertFood(Food food)
        {
            try
            {
                db.Insert(food);
            }
            catch(Exception exception)
            {
            }
        }

        public static void UpdateFood(Food food)
        {
            try
            {
                db.Update(food);
            }
            catch (Exception exception)
            {
            }
        }

        public static void DeleteFood(Food food)
        {
            try
            {
                db.Delete(food);
            }
            catch (Exception exception)
            {
            }
        }

    }
}