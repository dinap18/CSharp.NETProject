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
    /// Interaction logic for OrdersListWindow.xaml
    /// </summary>
    public partial class OrdersListWindow : Window
    {
        BL.IBL bl;
        public OrdersListWindow()
        {
            InitializeComponent();
            bl = BL.FactoryBL.GetBL();
            this.orderlistListBox.ItemsSource = bl.GetOrderList();
        }

        private void UpdateOrderButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            Window UpdateOrderWindow = new UpdateOrderWindow();
            new UpdateOrderWindow().Show();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Are you sure that you are finished?", "Exit", MessageBoxButton.YesNo,MessageBoxImage.Question);
            switch (result)
            {
                case MessageBoxResult.Yes:
                    this.Close();
                    Window window = new OrderWindow();
                    window.Show();
                    break;
                case MessageBoxResult.No:

                    break;
            }

        }
   


    }
}
