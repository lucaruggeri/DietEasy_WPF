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
using DietEasy.ViewModel;

namespace DietEasy
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //DataContext declaration
        DietEasyViewModel viewModel { get; set; }

        public MainWindow()
        {
            //DataContext initialization
            viewModel = new DietEasyViewModel();
            this.DataContext = viewModel;

            InitializeComponent();
        }

        private void txtSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            FilterFoodDatabaseReferenceGrid(DatabaseManager.SearchFood(txtSearch.Text.Trim()));
        }

        private void FilterFoodDatabaseGrid(List<Food> foodList)
        {
            grdFoodDatabase.ItemsSource = foodList;
        }

        private void FilterFoodDatabaseReferenceGrid(List<Food> foodList)
        {
            grdFoodDatabaseReference.ItemsSource = foodList;
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
            grdTodaysMeals.ItemsSource = DatabaseManager.GetDayMealsList(DateTime.Today);
            grdFoodDatabase.ItemsSource = DatabaseManager.GetFoodList();
            grdFoodDatabaseReference.ItemsSource = DatabaseManager.GetFoodList();
            UpdateTotals();
        }

        private void txtSearchDatabase_TextChanged(object sender, TextChangedEventArgs e)
        {
            FilterFoodDatabaseGrid(DatabaseManager.SearchFood(txtSearchDatabase.Text.Trim()));
        }

        private void grdFoodDatabase_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (grdFoodDatabase.SelectedItem != null)
            {
                if (grdFoodDatabase.SelectedItem.GetType() == typeof(Food))
                {
                    LoadFoodItem((Food)grdFoodDatabase.SelectedItem);
                }
                else
                {
                    ClearFoodFields();
                }
            }
            else
            {
                ClearFoodFields();
            }
        }

        private void LoadFoodItem(Food item)
        {
            if (item != null)
            {
                txtCalories.Text = item.Calories.ToString();
                txtCarbs.Text = item.Carbs.ToString();
                txtFats.Text = item.Fats.ToString();
                txtFoodName.Text = item.Name;
                txtProteins.Text = item.Proteins.ToString();
                txtSugar.Text = item.Sugar.ToString();
                txtServingSizeGrams.Text = item.ServingSizeGrams.ToString();

                if (item.ServingSizeDescription != null)
                    txtServingSizeDescription.Text = item.ServingSizeDescription.ToString();

                btnUpdateFood.IsEnabled = true;
            }
            else
            {
                ClearFoodFields();
                btnUpdateFood.IsEnabled = false;
            }
        }

        private Food GetUserFoodItem()
        {
            Food food = new Food();

            food.Id = DatabaseManager.GetLastFoodId() + 1;

            if (txtCalories.Text != string.Empty)
                food.Calories = Decimal.Parse(txtCalories.Text.Replace(',', '.'));
            if (txtCarbs.Text != string.Empty)
                food.Carbs = Decimal.Parse(txtCarbs.Text.Replace(',', '.'));
            if (txtFats.Text != string.Empty)
                food.Fats = Decimal.Parse(txtFats.Text.Replace(',', '.'));
            if (txtFoodName.Text != string.Empty)
                food.Name = txtFoodName.Text;
            if (txtProteins.Text != string.Empty)
                food.Proteins = Decimal.Parse(txtProteins.Text.Replace(',', '.'));
            if (txtSugar.Text != string.Empty)
                food.Sugar = Decimal.Parse(txtSugar.Text.Replace(',', '.'));
            if (txtServingSizeGrams.Text != string.Empty)
                food.ServingSizeGrams = Decimal.Parse(txtServingSizeGrams.Text.Replace(',', '.'));
            if (txtServingSizeDescription.Text != string.Empty)
                food.ServingSizeDescription = txtServingSizeDescription.Text;

            return food;
        }

        private void ClearFoodFields()
        {
            txtCalories.Text = string.Empty;
            txtCarbs.Text = string.Empty;
            txtFats.Text = string.Empty;
            txtFoodName.Text = string.Empty;
            txtProteins.Text = string.Empty;
            txtSugar.Text = string.Empty;
            txtServingSizeGrams.Text = string.Empty;
            txtServingSizeDescription.Text = string.Empty;
        }

        private void ClearFoodFieldsToAdd()
        {
            txtCaloriesToAdd.Text = string.Empty;
            txtCarbsToAdd.Text = string.Empty;
            txtFatsToAdd.Text = string.Empty;
            txtProteinsToAdd.Text = string.Empty;
            txtSugarToAdd.Text = string.Empty;
        }

        private void btnUpdateFood_Click(object sender, RoutedEventArgs e)
        {
        }

        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            ClearFoodFields();
        }

        private void btnAddFood_Click(object sender, RoutedEventArgs e)
        {
            DatabaseManager.InsertFood(GetUserFoodItem());
            grdFoodDatabase.ItemsSource = DatabaseManager.GetFoodList();
        }

        private void btnDeleteDatabaseFood_Click(object sender, RoutedEventArgs e)
        {
            viewModel.RemoveDatabaseFood();
        }

        private void grdFoodDatabaseReference_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
        }

        private void txtServingSizeToAdd_TextChanged(object sender, TextChangedEventArgs e)
        {
        }

        private void btnEat_Click(object sender, RoutedEventArgs e)
        {
            viewModel.EatTheFood();
        }

        private void UpdateTotals()
        {
        }

        private void grdTodaysMeals_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void btnDeleteDailyFood_Click(object sender, RoutedEventArgs e)
        {
            viewModel.RemoveDailyMeal();
        }
    }
}
