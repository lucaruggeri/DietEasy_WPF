    using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

using DietEasy.Model;
using DietEasy.Database;

namespace DietEasy.ViewModel
{
    public class DietEasyViewModel : INotifyPropertyChanged
    {

        #region DATA BINDING STEP 1 - PropertyChanged event and handler
        // -------------------------------------- WPF --------------------------------------
        // This next region of code, is step ONE (of two) of what you need
        // to support the INotifyPropertyChanged interface.
        // I usually just copy it from a previous piece of code – it just works,
        // or, put it within a base-class.
        // -------------------------------------- WPF --------------------------------------

        public event PropertyChangedEventHandler PropertyChanged;

        public void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        #endregion

        #region DATA BINDING STEP 2 - Properties
        // -------------------------------------- WPF --------------------------------------
        // This is step TWO.
        // For each of your properties whose changes you want to track
        // (that is, to cause the data bindings to update),
        // add the call to NotifyPropertyChanged within the setter as I did below.
        // -------------------------------------- WPF --------------------------------------

        private DailyMealsTotals _totals;
        public DailyMealsTotals totals
        {
            get
            {
                return _totals;
            }
            set
            {
                _totals = value;
                NotifyPropertyChanged();
            }
        }

        private Food selectedFood;
        public Food SelectedFood
        {
            get
            {
                return selectedFood;
            }
            set
            {
                selectedFood = value;
                LoadSelectedFoodInfo();
                NotifyPropertyChanged();
            }
        }

        private Food selectedDatabaseFood;
        public Food SelectedDatabaseFood
        {
            get
            {
                return selectedDatabaseFood;
            }
            set
            {
                selectedDatabaseFood = value;
                LoadSelectedDatabaseFoodInfo();
                NotifyPropertyChanged();
            }
        }

        private DayMeal _selectedDailyMeal;
        public DayMeal selectedDailyMeal
        {
            get
            {
                return _selectedDailyMeal;
            }
            set
            {
                _selectedDailyMeal = value;
                NotifyPropertyChanged();
            }
        }

        public List<Food> _foodDatabase;
        public List<Food> foodDatabase
        {
            get
            {
                return _foodDatabase;
            }
            set
            {
                _foodDatabase = value;
                NotifyPropertyChanged();
            }
        }

        public List<DayMeal> _todayMeals;
        public List<DayMeal> todayMeals
        {
            get
            {
                return _todayMeals;
            }
            set
            {
                _todayMeals = value;
                UpdateTotals();
                NotifyPropertyChanged();
            }
        }

        public DayMeal _meal;
        public DayMeal meal
        {
            get
            {
                return _meal;
            }
            set
            {
                _meal = value;
                NotifyPropertyChanged();
            }
        }

        private DateTime mealSelectedDay;
        public DateTime MealSelectedDay
        {
            get
            {
                return mealSelectedDay;
            }
            set
            {
                mealSelectedDay = value;
                NotifyPropertyChanged();
                LoadDailyMealsByDate(mealSelectedDay);
                UpdateTotals();
            }
        }
        
        private decimal mealCalories;
        public decimal MealCalories { get { return mealCalories; } set { mealCalories = value; NotifyPropertyChanged(); } }
        private decimal mealCarbs;
        public decimal MealCarbs { get { return mealCarbs; } set { mealCarbs = value; NotifyPropertyChanged(); } }
        private decimal mealSugar;
        public decimal MealSugar { get { return mealSugar; } set { mealSugar = value; NotifyPropertyChanged(); } }
        private decimal mealFats;
        public decimal MealFats { get { return mealFats; } set { mealFats = value; NotifyPropertyChanged(); } }
        private decimal mealProteins;
        public decimal MealProteins { get { return mealProteins; } set { mealProteins = value; NotifyPropertyChanged(); } }
        private string mealGrams;
        public string MealGrams { get { return mealGrams; } set { mealGrams = value; NotifyPropertyChanged(); } }

        private string caloriesTotal;
        public string CaloriesTotal { get { return caloriesTotal; } set { caloriesTotal = value; NotifyPropertyChanged(); } }
        private string carbsTotal;
        public string CarbsTotal { get { return carbsTotal; } set { carbsTotal = value; NotifyPropertyChanged(); } }
        private string sugarTotal;
        public string SugarTotal { get { return sugarTotal; } set { sugarTotal = value; NotifyPropertyChanged(); } }
        private string fatsTotal;
        public string FatsTotal { get { return fatsTotal; } set { fatsTotal = value; NotifyPropertyChanged(); } }
        private string proteinsTotal;
        public string ProteinsTotal { get { return proteinsTotal; } set { proteinsTotal = value; NotifyPropertyChanged(); } }
        private string carbsCalories;
        public string CarbsCalories { get { return carbsCalories; } set { carbsCalories = value; NotifyPropertyChanged(); } }
        private string _FatsCalories;
        public string FatsCalories { get { return _FatsCalories; } set { _FatsCalories = value; NotifyPropertyChanged(); } }
        private string _ProteinsCalories;
        public string ProteinsCalories { get { return _ProteinsCalories; } set { _ProteinsCalories = value; NotifyPropertyChanged(); } }
        private string _CarbsPercentage;
        public string CarbsPercentage { get { return _CarbsPercentage; } set { _CarbsPercentage = value; NotifyPropertyChanged(); } }
        private string _FatsPercentage;
        public string FatsPercentage { get { return _FatsPercentage; } set { _FatsPercentage = value; NotifyPropertyChanged(); } }
        private string _ProteinsPercentage;
        public string ProteinsPercentage { get { return _ProteinsPercentage; } set { _ProteinsPercentage = value; NotifyPropertyChanged(); } }

        private string _DatabaseFoodName;
        public string DatabaseFoodName { get { return _DatabaseFoodName; } set { _DatabaseFoodName = value; NotifyPropertyChanged(); } }
        private string _DatabaseFoodCalories;
        public string DatabaseFoodCalories { get { return _DatabaseFoodCalories; } set { _DatabaseFoodCalories = value; NotifyPropertyChanged(); } }
        private string _DatabaseFoodCarbs;
        public string DatabaseFoodCarbs { get { return _DatabaseFoodCarbs; } set { _DatabaseFoodCarbs = value; NotifyPropertyChanged(); } }
        private string _DatabaseFoodSugars;
        public string DatabaseFoodSugar { get { return _DatabaseFoodSugars; } set { _DatabaseFoodSugars = value; NotifyPropertyChanged(); } }
        private string _DatabaseFoodFats;
        public string DatabaseFoodFats { get { return _DatabaseFoodFats; } set { _DatabaseFoodFats = value; NotifyPropertyChanged(); } }
        private string _DatabaseFoodProteins;
        public string DatabaseFoodProteins { get { return _DatabaseFoodProteins; } set { _DatabaseFoodProteins = value; NotifyPropertyChanged(); } }
        private string _DatabaseFoodServingSizeGrams;
        public string DatabaseFoodServingSizeGrams { get { return _DatabaseFoodServingSizeGrams; } set { _DatabaseFoodServingSizeGrams = value; NotifyPropertyChanged(); } }
        private string _DatabaseFoodServingSizeDescription;
        public string DatabaseFoodServingSizeDescription { get { return _DatabaseFoodServingSizeDescription; } set { _DatabaseFoodServingSizeDescription = value; NotifyPropertyChanged(); } }

        private Decimal _selectedServingSize;
        public Decimal selectedServingSize
        {
            get
            {
                return _selectedServingSize;
            }
            set
            {
                _selectedServingSize = value;
                LoadSelectedFoodInfo();
                NotifyPropertyChanged();
            }
        }
        #endregion

        public DietEasyViewModel()
        {
            //DataContext initialization
            SelectedFood = new Food();
            selectedDailyMeal = new DayMeal();
            totals = new DailyMealsTotals();
            meal = new DayMeal();
            selectedServingSize = 1;
            MealSelectedDay = DateTime.Today;
            todayMeals = DatabaseManager.GetDayMealsList(MealSelectedDay);
            foodDatabase = DatabaseManager.GetFoodList();
        }

        public void EatTheFood()
        {
            if (SelectedFood != null)
            {
                DatabaseManager.AddDayMeal(SelectedFood, selectedServingSize);
                this.todayMeals = DatabaseManager.GetDayMealsList(MealSelectedDay);
            }
        }

        public void RemoveDailyMeal()
        {
            DatabaseManager.DeleteDailyFood(selectedDailyMeal);
            this.todayMeals = DatabaseManager.GetDayMealsList(MealSelectedDay);
        }

        public void RemoveDatabaseFood()
        {
            DatabaseManager.DeleteFood(SelectedDatabaseFood);
            this.foodDatabase = DatabaseManager.GetFoodList();
        }

        public void AddDatabaseFood()
        {
            Food newFood = new Food();
            newFood.Id = DatabaseManager.GetLastFoodId() + 1;
            newFood.Name = DatabaseFoodName;
            newFood.Calories = Decimal.Parse(DatabaseFoodCalories.Replace(',', '.'));
            newFood.Carbs = Decimal.Parse(DatabaseFoodCarbs.Replace(',', '.'));
            newFood.Sugar = Decimal.Parse(DatabaseFoodSugar.Replace(',', '.'));
            newFood.Fats = Decimal.Parse(DatabaseFoodFats.Replace(',', '.'));
            newFood.Proteins = Decimal.Parse(DatabaseFoodProteins.Replace(',', '.'));
            newFood.ServingSizeGrams = Decimal.Parse(DatabaseFoodServingSizeGrams.Replace(',', '.'));
            newFood.ServingSizeDescription = DatabaseFoodServingSizeDescription;

            DatabaseManager.InsertFood(newFood);
            this.foodDatabase = DatabaseManager.GetFoodList();
        }

        public void UpdateDatabaseFood()
        {
            SelectedDatabaseFood.Name = DatabaseFoodName;
            SelectedDatabaseFood.Calories = Decimal.Parse(DatabaseFoodCalories.Replace(',', '.'));
            SelectedDatabaseFood.Carbs = Decimal.Parse(DatabaseFoodCarbs.Replace(',', '.'));
            SelectedDatabaseFood.Sugar = Decimal.Parse(DatabaseFoodSugar.Replace(',', '.'));
            SelectedDatabaseFood.Fats = Decimal.Parse(DatabaseFoodFats.Replace(',', '.'));
            SelectedDatabaseFood.Proteins = Decimal.Parse(DatabaseFoodProteins.Replace(',', '.'));
            SelectedDatabaseFood.ServingSizeGrams = Decimal.Parse(DatabaseFoodServingSizeGrams.Replace(',', '.'));
            SelectedDatabaseFood.ServingSizeDescription = DatabaseFoodServingSizeDescription;

            DatabaseManager.UpdateFood(SelectedDatabaseFood);

            this.foodDatabase = DatabaseManager.GetFoodList();
        }

        public void ClearSelectedDatabaseFood()
        {
            this.SelectedDatabaseFood = new Food();
        }

        private void UpdateTotals()
        {
            //update TOTALS            
            totals.CaloriesTotal = DatabaseManager.GetDayMealTotalCalories(MealSelectedDay);
            totals.CarbsTotal = DatabaseManager.GetDayMealTotalCarbs(MealSelectedDay);
            totals.SugarTotal = DatabaseManager.GetDayMealTotalSugar(MealSelectedDay);
            totals.FatsTotal = DatabaseManager.GetDayMealTotalFats(MealSelectedDay);
            totals.ProteinsTotal = DatabaseManager.GetDayMealTotalProteins(MealSelectedDay);
            totals.CarbsCaloriesTotal = DatabaseManager.GetDayMealCarbsCalories(MealSelectedDay);
            totals.FatsCaloriesTotal = DatabaseManager.GetDayMealFatsCalories(MealSelectedDay);
            totals.ProteinsCaloriesTotal = DatabaseManager.GetDayMealProteinsCalories(MealSelectedDay);
            totals.CarbsPercentage = DatabaseManager.GetDayMealCarbsPercentage(MealSelectedDay);
            totals.FatsPercentage = DatabaseManager.GetDayMealFatsPercentage(MealSelectedDay);
            totals.ProteinsPercentage = DatabaseManager.GetDayMealProteinsPercentage(MealSelectedDay);

            //updates VIEW fields
            CaloriesTotal = totals.CaloriesTotal.ToString();
            CarbsTotal = totals.CarbsTotal.ToString();
            SugarTotal = totals.SugarTotal.ToString();
            FatsTotal = totals.FatsTotal.ToString();
            ProteinsTotal = totals.ProteinsTotal.ToString();

            CarbsCalories = totals.CarbsCaloriesTotal.ToString();
            FatsCalories = totals.FatsCaloriesTotal.ToString();
            ProteinsCalories = totals.ProteinsCaloriesTotal.ToString();

            CarbsPercentage = totals.CarbsPercentage.ToString();
            FatsPercentage = totals.FatsPercentage.ToString();
            ProteinsPercentage = totals.ProteinsPercentage.ToString();
        }

        private void LoadSelectedFoodInfo()
        {
            if (SelectedFood != null)
            {
                if (SelectedFood.Name != null)
                {
                    if (SelectedFood.Name != string.Empty)
                    {
                        //updates MEAL
                        meal.FoodId = SelectedFood.Id;
                        meal.FoodName = SelectedFood.Name;
                        meal.Calories = SelectedFood.CaloriesInServingSize(selectedServingSize);
                        meal.Carbs = SelectedFood.CarbsInServingSize(selectedServingSize);
                        meal.Sugar = SelectedFood.SugarsInServingSize(selectedServingSize);
                        meal.Fats = SelectedFood.FatsInServingSize(selectedServingSize);
                        meal.Proteins = SelectedFood.ProteinsInServingSize(selectedServingSize);
                        meal.ServingSizes = selectedServingSize;
                        meal.Grams = SelectedFood.ServingSizeGrams * selectedServingSize;

                        //updates VIEW fields
                        MealCalories = meal.Calories;
                        MealCarbs = meal.Carbs;
                        MealSugar = meal.Sugar;
                        MealFats = meal.Fats;
                        MealProteins = meal.Proteins;
                        MealGrams = "(" + meal.Grams.ToString() + " grams)";
                    }
                }
            }
        }

        private void LoadSelectedDatabaseFoodInfo()
        {
            if (SelectedDatabaseFood != null)
            {
                if (SelectedDatabaseFood.Name != null)
                    DatabaseFoodName = SelectedDatabaseFood.Name;
                else
                    DatabaseFoodName = string.Empty;

                DatabaseFoodCalories = SelectedDatabaseFood.Calories.ToString();
                DatabaseFoodCarbs = SelectedDatabaseFood.Carbs.ToString();
                DatabaseFoodSugar = SelectedDatabaseFood.Sugar.ToString();
                DatabaseFoodFats = SelectedDatabaseFood.Fats.ToString();
                DatabaseFoodProteins = SelectedDatabaseFood.Proteins.ToString();
                DatabaseFoodServingSizeGrams = SelectedDatabaseFood.ServingSizeGrams.ToString();

                if (SelectedDatabaseFood.ServingSizeDescription != null)
                    DatabaseFoodServingSizeDescription = SelectedDatabaseFood.ServingSizeDescription;
                else
                    DatabaseFoodServingSizeDescription = string.Empty;
            }
        }

        private void LoadDailyMealsByDate(DateTime mealSelectedDay)
        {
            todayMeals = DatabaseManager.GetDayMealsList(mealSelectedDay);
        }


        //LoadFoodItemToAdd((Food)grdFoodDatabaseReference.SelectedItem);

        //if (item != null)
        //{
        //    txtCaloriesToAdd.Text = item.Calories.ToString();
        //    txtCarbsToAdd.Text = item.Carbs.ToString();
        //    txtFatsToAdd.Text = item.Fats.ToString();
        //    txtProteinsToAdd.Text = item.Proteins.ToString();
        //    txtSugarToAdd.Text = item.Sugar.ToString();
        //    btnEat.IsEnabled = true;
        //}
        //else
        //{
        //    ClearFoodFieldsToAdd();
        //    btnEat.IsEnabled = false;
        //}

        //if (grdFoodDatabaseReference.SelectedItem != null)
        //{
        //    if (grdFoodDatabaseReference.SelectedItem.GetType() == typeof(Food))
        //    {
        //        LoadFoodItemToAdd((Food)grdFoodDatabaseReference.SelectedItem);
        //        //TODO UpdateServingsNutritionalValue();
        //    }
        //    else
        //    {
        //        ClearFoodFieldsToAdd();
        //    }
        //}
        //else
        //{
        //    ClearFoodFieldsToAdd();
        //}

    }
}
