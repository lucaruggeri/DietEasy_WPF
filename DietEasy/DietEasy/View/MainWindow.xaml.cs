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
            InitializeComponent();

            //DataContext initialization
            viewModel = new DietEasyViewModel();
            this.DataContext = viewModel;

            LoadFoodControls();
        }

        private void LoadFoodControls()
        {
            this.UCFoodInfoDatabase.TypeOfFoodInfo = "Database";
            this.UCFoodInfoTotal.TypeOfFoodInfo = "Total";
            this.UCFoodInfoServing.TypeOfFoodInfo = "Serving";
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
            List<DayMeal> dayMealsList = DatabaseManager.GetDayMealsList(Database.DatabaseManager.TODAY);
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

        private void btnUpdateFood_Click(object sender, RoutedEventArgs e)
        {
            viewModel.UpdateDatabaseFood();
        }

        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            viewModel.ClearSelectedDatabaseFood();
        }

        private void btnAddFood_Click(object sender, RoutedEventArgs e)
        {
            viewModel.AddDatabaseFood();
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

        private void UCFoodInfoDatabase_Loaded(object sender, RoutedEventArgs e)
        {
        }
    }
}
