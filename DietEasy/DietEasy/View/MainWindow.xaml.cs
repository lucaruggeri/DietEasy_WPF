using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

using DietEasy.Model;
using DietEasy.Database;

namespace DietEasy
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void txtSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
        }

        private void FilterFoodDatabaseGrid(List<Food> foodList)
        {
            grdFoodDatabase.ItemsSource = foodList;
        }

        private void UpdateFoodItemGraphic(Food foodItem)
        {
            if (foodItem == null)
            {
                txtFoodName.Text = string.Empty;
                txtFoodName.IsEnabled = false;
                txtCalories.Text = string.Empty;
                txtCalories.IsEnabled = false;
                txtCarbs.Text = string.Empty;
                txtCarbs.IsEnabled = false;
                txtFats.Text = string.Empty;
                txtFats.IsEnabled = false;
                txtProteins.Text = string.Empty;
                txtProteins.IsEnabled = false;
                btnAddFood.IsEnabled = false;
            }
            else
            {
                txtFoodName.Text = foodItem.Name;
                txtFoodName.IsEnabled = true;
                txtCalories.Text = foodItem.Calories.ToString();
                txtCalories.IsEnabled = true;
                txtCarbs.Text = foodItem.Carbs.ToString();
                txtCarbs.IsEnabled = true;
                txtFats.Text = foodItem.Fats.ToString();
                txtFats.IsEnabled = true;
                txtProteins.Text = foodItem.Proteins.ToString();
                txtProteins.IsEnabled = true;
                btnAddFood.IsEnabled = true;
            }
        }

        private void InitializeDatabase()
        {
            //creating and populating database
            DatabaseManager.CreateAndPopulateFixedData();
            DatabaseManager.CreateAndPopulateChangingData();

            if (Database.DatabaseManager.GetDayMealsNumber() > 0)
            {
                LoadSelectedFoodList();
            }
        }

        private void LoadSelectedFoodList()
        {
            //EditText txtSearch = FindViewById<EditText>(Resource.Id.txtSearch);
            //string foodFilter = txtSearch.Text.Trim();

            List<DayMeal> dayMealsList = DatabaseManager.GetDayMealsList(Database.DatabaseManager.TODAY);

            //Utilities.SelectedFoodAdapter selectedFoodAdapterList = new Utilities.SelectedFoodAdapter(this, dayMealsList);

            //ListView lstSelectedFood = FindViewById<ListView>(Resource.Id.lstSelectedFood);
            //lstSelectedFood.SetAdapter(selectedFoodAdapterList);
            //lstSelectedFood.ItemClick += (object sender, Android.Widget.AdapterView.ItemClickEventArgs e) =>
            //{
            //    //SelectFood(lstSearchFood.GetItemAtPosition(e.Position).ToString());
            //};
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            InitializeDatabase();
            LoadFoodGrids();
        }

        private void LoadFoodGrids()
        {
            grdTodaysMeals.ItemsSource = DatabaseManager.GetFoodList();
            grdFoodDatabase.ItemsSource = DatabaseManager.GetFoodList();
        }

        private void txtSearchDatabase_TextChanged(object sender, TextChangedEventArgs e)
        {
            FilterFoodDatabaseGrid(DatabaseManager.SearchFood(txtSearchDatabase.Text.Trim()));
        }
    }
}
