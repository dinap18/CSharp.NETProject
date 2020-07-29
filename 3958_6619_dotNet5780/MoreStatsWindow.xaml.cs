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
    /// Interaction logic for MoreStatsWindow.xaml
    /// </summary>
    public partial class MoreStatsWindow : Window
    {
        BL.IBL bl;
        public MoreStatsWindow()
        {
            InitializeComponent();
            bl = BL.FactoryBL.GetBL();
            requestLabel.Content = bl.GetGuestList().Count().ToString();
            unitLabel.Content = bl.GetHostingUnitList().Count().ToString();
            orderLabel.Content = bl.GetOrderList().Count().ToString();
            canceledLabel.Content = bl.numberOfCanceledOrders().ToString();
            approvedLabel.Content = bl.numberOfAcceptedOrders().ToString();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Are you sure that you are finished?", "Exit", MessageBoxButton.YesNo, MessageBoxImage.Question);
            switch (result)
            {
                case MessageBoxResult.Yes:
                    this.Close();
                    Window window = new WebSiteAdminWindow();
                    window.Show();
                    break;
                case MessageBoxResult.No:

                    break;
            }
        }
    }
}
