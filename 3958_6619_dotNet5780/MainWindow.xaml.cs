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

namespace _3958_6619_dotNet5780
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public class MyData : DependencyObject
    {
        public string Date
        {
            get { return (string)GetValue(DateProperty); }
            set { SetValue(DateProperty, value); }
        }

        public static readonly DependencyProperty DateProperty =
            DependencyProperty.Register("Date",
            typeof(string), typeof(MyData), new UIPropertyMetadata(""));

    }
    public partial class MainWindow : Window
    {
        private MyData myData;
        BL.IBL bl;
        public MainWindow()
        {
            InitializeComponent();

           bl = BL.FactoryBL.GetBL();
            myData = new MyData()
            {
                Date = DateTime.Now.ToString()
            };
            date_label.DataContext = myData;
        }




        private void GuestRequestButtonClick(object sender, RoutedEventArgs e)
        {
            Window AddGuestRequestWindow = new AddGuestRequestWindow();
            AddGuestRequestWindow.Show();

        }

        private void HostingUnitButtonClick(object sender, RoutedEventArgs e)
        {
            Window HostingUnitWindow = new HostingUnitWindow();
            new HostingUnitWindow().Show();
            // Close();
        }

        private void WebSiteAdminButtonClick(object sender, RoutedEventArgs e)
        {
            Window AdminPasswordWindow = new AdminPasswordWindow();
            AdminPasswordWindow.ShowDialog();
            if (AdminPasswordWindow.DialogResult == true)
            {
                Window WebSiteAdminWindow = new WebSiteAdminWindow();
                new WebSiteAdminWindow().Show();
            }
            //  Close();
        }

        private void exitButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Are you sure that you want to leave?", "Exit", MessageBoxButton.YesNo, MessageBoxImage.Question);
            switch (result)
            {
                case MessageBoxResult.Yes:
                    this.Close();
                    break;
                case MessageBoxResult.No:

                    break;
            }

        }

   

        private void udpatedateButton_Click(object sender, RoutedEventArgs e)
        {
            myData.Date = DateTime.Now.ToString();
        }



    }
}

