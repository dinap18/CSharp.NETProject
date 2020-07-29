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
    /// Interaction logic for AddOrderWindow.xaml
    /// </summary>
   

    public partial class AddOrderWindow : Window
    {
        BE.Order order;
        BE.HostingUnit hostingunit;
        BE.GuestRequest guestrequest;
        BL.IBL bl;
        public AddOrderWindow()
        {
            InitializeComponent();
            order = new BE.Order();
            bl = BL.FactoryBL.GetBL();
            this.DataContext = order;
            this.GuestrequestComboBox.ItemsSource = bl.GetGuestList();
           this.HostingUnitComboBox.ItemsSource = bl.GetHostingUnitList();
        }

        private void AddOrderButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {   
                guestrequest = GuestrequestComboBox.SelectedValue as BE.GuestRequest;
                if (guestrequest == null)
                    throw new NullReferenceException("please choose a guest request");
              
                hostingunit = HostingUnitComboBox.SelectedValue as BE.HostingUnit;
                if (hostingunit == null)
                    throw new NullReferenceException("please choose a hosting unit");
                order.GuestRequestKey = guestrequest.GuestRequestKey;
                order.HostingUnitKey = hostingunit.HostingUnitKey;
                this.DataContext = order;
              
                bl.AddOrder(order.GuestRequestKey,order.HostingUnitKey);
                order = new BE.Order();
                MessageBoxResult result = MessageBox.Show("Thank You, your order has been added. Would you like to add another order?", "Status", MessageBoxButton.YesNo,MessageBoxImage.Information);
                switch (result)
                {
                    case MessageBoxResult.Yes:
                        this.Close();
                        Window AddOrderWindow = new AddOrderWindow();
                        AddOrderWindow.Show();
                        break;
                    case MessageBoxResult.No:
                        this.Close();
                        Window OrderWindow = new OrderWindow();
                        OrderWindow.Show();
                        break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message,"error",MessageBoxButton.OK,MessageBoxImage.Error);
            }
        }


        private void ExitButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Are you sure that you are finished?", "Exit", MessageBoxButton.YesNo,MessageBoxImage.Stop);
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
