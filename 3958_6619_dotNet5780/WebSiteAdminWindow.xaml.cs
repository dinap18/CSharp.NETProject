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
    /// Interaction logic for WebSiteAdminWindow.xaml
    /// </summary>
    public partial class WebSiteAdminWindow : Window
    {
        BL.IBL bl;
        public WebSiteAdminWindow()
        {
            InitializeComponent();
            bl = BL.FactoryBL.GetBL();
            paymentLabel.Content = bl.PayDay().ToString();
        }

        private void exitButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Are you sure that you are finished?", "Exit", MessageBoxButton.YesNo,MessageBoxImage.Question);
            switch (result)
            {
                case MessageBoxResult.Yes:
                    this.Close();
                    break;
                case MessageBoxResult.No:

                    break;
            }
        }

        private void guestrequestsqueriesButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            Window GuestRequestQueriesWindow = new GuestRequestQueriesWindow();
            GuestRequestQueriesWindow.Show();
        }

        private void hostingunitqueriesButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            Window HostingUnitQueriesWindow = new HostingUnitQueriesWindow();
            HostingUnitQueriesWindow.Show();
        }

        private void morequeriesButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            Window MoreQueriesWindow = new MoreQueriesWindow();
            MoreQueriesWindow.Show();
        }

        private void orderlistqueriesButton1_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            Window OrderListQueries = new OrderListQueries();
            OrderListQueries.Show();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            Window MoreStatsWindow = new MoreStatsWindow();
            MoreStatsWindow.Show();
        }
    }
}
