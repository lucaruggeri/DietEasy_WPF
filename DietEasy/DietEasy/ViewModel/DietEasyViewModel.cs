﻿    using System;
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

        private Food _selectedFood;
        public Food selectedFood
        {
            get
            {
                return _selectedFood;
            }
            set
            {
                _selectedFood = value;
                LoadSelectedFoodInfo();
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

        private decimal _mealCalories;
        public decimal mealCalories { get { return _mealCalories; } set { _mealCalories = value; NotifyPropertyChanged(); } }
        private decimal _mealCarbs;
        public decimal mealCarbs { get { return _mealCarbs; } set { _mealCarbs = value; NotifyPropertyChanged(); } }
        private decimal _mealSugar;
        public decimal mealSugar { get { return _mealSugar; } set { _mealSugar = value; NotifyPropertyChanged(); } }
        private decimal _mealFats;
        public decimal mealFats { get { return _mealFats; } set { _mealFats = value; NotifyPropertyChanged(); } }
        private decimal _mealProteins;
        public decimal mealProteins { get { return _mealProteins; } set { _mealProteins = value; NotifyPropertyChanged(); } }
        private string _mealGrams;
        public string mealGrams { get { return _mealGrams; } set { _mealGrams = value; NotifyPropertyChanged(); } }

        private string _CaloriesTotal;
        public string CaloriesTotal { get { return _CaloriesTotal; } set { _CaloriesTotal = value; NotifyPropertyChanged(); } }
        private string _CarbsTotal;
        public string CarbsTotal { get { return _CarbsTotal; } set { _CarbsTotal = value; NotifyPropertyChanged(); } }
        private string _SugarTotal;
        public string SugarTotal { get { return _SugarTotal; } set { _SugarTotal = value; NotifyPropertyChanged(); } }
        private string _FatsTotal;
        public string FatsTotal { get { return _FatsTotal; } set { _FatsTotal = value; NotifyPropertyChanged(); } }
        private string _ProteinsTotal;
        public string ProteinsTotal { get { return _ProteinsTotal; } set { _ProteinsTotal = value; NotifyPropertyChanged(); } }
        private string _CarbsCalories;
        public string CarbsCalories { get { return _CarbsCalories; } set { _CarbsCalories = value; NotifyPropertyChanged(); } }
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

        public List<Food> foodDatabase { get; set; }
        #endregion

        public DietEasyViewModel()
        {
            //DataContext initialization
            selectedFood = new Food();
            selectedDailyMeal = new DayMeal();
            totals = new DailyMealsTotals();
            meal = new DayMeal();
            selectedServingSize = 1;
            todayMeals = DatabaseManager.GetDayMealsList(DateTime.Today);
            foodDatabase = DatabaseManager.GetFoodList();
        }

        public void EatTheFood()
        {
            if (selectedFood != null)
            {
                DatabaseManager.AddDayMeal(selectedFood, selectedServingSize);
                this.todayMeals = DatabaseManager.GetDayMealsList(DateTime.Today);
            }
        }

        public void RemoveDailyMeal()
        {
            DatabaseManager.DeleteDailyFood(selectedDailyMeal);
            this.todayMeals = DatabaseManager.GetDayMealsList(DateTime.Today);
        }

        public void RemoveDatabaseFood()
        {
            DatabaseManager.DeleteFood(selectedFood);
            this.foodDatabase = DatabaseManager.GetFoodList();
        }

        private void UpdateTotals()
        {
            //update TOTALS            
            totals.CaloriesTotal = DatabaseManager.GetDayMealTotalCalories(DateTime.Today);
            totals.CarbsTotal = DatabaseManager.GetDayMealTotalCarbs(DateTime.Today);
            totals.SugarTotal = DatabaseManager.GetDayMealTotalSugar(DateTime.Today);
            totals.FatsTotal = DatabaseManager.GetDayMealTotalFats(DateTime.Today);
            totals.ProteinsTotal = DatabaseManager.GetDayMealTotalProteins(DateTime.Today);
            totals.CarbsCaloriesTotal = DatabaseManager.GetDayMealCarbsCalories(DateTime.Today);
            totals.FatsCaloriesTotal = DatabaseManager.GetDayMealFatsCalories(DateTime.Today);
            totals.ProteinsCaloriesTotal = DatabaseManager.GetDayMealProteinsCalories(DateTime.Today);
            totals.CarbsPercentage = DatabaseManager.GetDayMealCarbsPercentage(DateTime.Today);
            totals.FatsPercentage = DatabaseManager.GetDayMealFatsPercentage(DateTime.Today);
            totals.ProteinsPercentage = DatabaseManager.GetDayMealProteinsPercentage(DateTime.Today);

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
            if (selectedFood.Name != null)
            {
                if (selectedFood.Name != string.Empty)
                {
                    //updates MEAL
                    meal.FoodId = selectedFood.Id;
                    meal.FoodName = selectedFood.Name;
                    meal.Calories = selectedFood.CaloriesInServingSize(selectedServingSize);
                    meal.Carbs = selectedFood.CarbsInServingSize(selectedServingSize);
                    meal.Sugar = selectedFood.SugarsInServingSize(selectedServingSize);
                    meal.Fats = selectedFood.FatsInServingSize(selectedServingSize);
                    meal.Proteins = selectedFood.ProteinsInServingSize(selectedServingSize);
                    meal.ServingSizes = selectedServingSize;
                    meal.Grams = selectedFood.ServingSizeGrams * selectedServingSize;

                    //updates VIEW fields
                    mealCalories = meal.Calories;
                    mealCarbs = meal.Carbs;
                    mealSugar = meal.Sugar;
                    mealFats = meal.Fats;
                    mealProteins = meal.Proteins;
                    mealGrams = "(" + meal.Grams.ToString() + " grams)";
                }
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
}
