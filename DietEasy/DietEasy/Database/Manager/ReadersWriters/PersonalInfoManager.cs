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

        public static void SetPersonalInfo(string name, string calories, string carbs, string fats, string proteins)
        {
            try 
            {
                PersonalInfo newPersonalInfo = new PersonalInfo();
                //TODO
                //newPersonalInfo.DailyCalories = Convert.ToDecimal(calories);
                //newPersonalInfo.DailyCarbs = Convert.ToDecimal(carbs);
                //newPersonalInfo.DailyFats = Convert.ToDecimal(fats);
                //newPersonalInfo.DailyProteins = Convert.ToDecimal(proteins);

                db.Insert(newPersonalInfo);
            }
            catch
            {
            }
        }

        public static PersonalInfo GetPersonalInfo()
        {
            try
            {
                List<PersonalInfo> list = (from x in db.Table<PersonalInfo>()
                                           select x
                                    ).ToList();

                return list[0];
            }
            catch
            {
                return null;
            }

        }

    }
}