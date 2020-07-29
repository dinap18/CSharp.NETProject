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
using System.Windows.Shapes;

namespace _3958_6619_dotNet5780
{
    /// <summary>
    /// Interaction logic for OrderWindow.xaml
    /// </summary>
    public partial class OrderWindow : Window
    {
        public OrderWindow()
        {
            InitializeComponent();
        }
        private void AddOrderButton_Click(object sender, RoutedEventArgs e)
        {
            Window AddOrderWindow = new AddOrderWindow();
            AddOrderWindow.Show();
            this.Close();
        }


       

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Are you sure that you are finished?", "Exit", MessageBoxButton.YesNo,MessageBoxImage.Question);
            switch (result)
            {
                case MessageBoxResult.Yes:
                    this.Close();
                    Window window = new PersonnalAreaWindow();
                    window.Show();
                    break;
                case MessageBoxResult.No:

                    break;
            }
        }

        private void updateOrderButton_Click_1(object sender, RoutedEventArgs e)
        {
            Window UpdateOrderWindow = new UpdateOrderWindow();
            UpdateOrderWindow.Show();
            this.Close();
        }

        private void OrderListButton_Click(object sender, RoutedEventArgs e)
        {

            Window OrdersListWindow = new OrdersListWindow();
            OrdersListWindow.Show();
            this.Close();
        }
    }
}
