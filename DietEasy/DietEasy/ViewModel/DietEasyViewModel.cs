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
        public List<DayMeal> foodDailyMeals { get; set; }
        public List<DayMeal> todayFoodDailyMeals { get; set; }

        public DietEasyViewModel()
        {
            //DataContext initialization
            selectedFood = new Food();
            meal = new DayMeal();
            selectedServingSize = 1;
            foodDatabase = DatabaseManager.GetFoodList();
            foodDailyMeals = DatabaseManager.GetDayMealsList();
            todayFoodDailyMeals = DatabaseManager.GetDayMealsList(DateTime.Today);
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

        #region PropertyChanged event and handler
        public event PropertyChangedEventHandler PropertyChanged;

        // This method is called by the Set accessor of each property.
        // The CallerMemberName attribute that is applied to the optional propertyName
        // parameter causes the property name of the caller to be substituted as an argument.
        public void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        #endregion
    }
}
