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

namespace DietEasy.View.UserControls
{
    /// <summary>
    /// Interaction logic for FoodInfo.xaml
    /// </summary>
    public partial class FoodInfo : UserControl
    {
        #region Properties
        public static readonly DependencyProperty TypeOfFoodInfoProperty = DependencyProperty.Register("TypeOfFoodInfo", typeof(string), typeof(FoodInfo), new UIPropertyMetadata(null));
        public string TypeOfFoodInfo
        {
            get { return (string)GetValue(TypeOfFoodInfoProperty); }
            set { SetValue(TypeOfFoodInfoProperty, value); }
        }
        #endregion

        public FoodInfo()
        {
            InitializeComponent();
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            UpdateGraphics();
        }

        private void UpdateGraphics()
        {
            if (TypeOfFoodInfo == "Database")
            {
                this.DatabaseZone.Visibility = Visibility.Visible;
                this.TotalZone.Visibility = Visibility.Collapsed;
                this.ServingZone.Visibility = Visibility.Collapsed;
            }
            else if (TypeOfFoodInfo == "Serving")
            {
                this.DatabaseZone.Visibility = Visibility.Collapsed;
                this.TotalZone.Visibility = Visibility.Collapsed;
                this.ServingZone.Visibility = Visibility.Visible;
            }
            else if (TypeOfFoodInfo == "Total")
            {
                this.DatabaseZone.Visibility = Visibility.Collapsed;
                this.TotalZone.Visibility = Visibility.Visible;
                this.ServingZone.Visibility = Visibility.Collapsed;
            }
        }
    }
}
