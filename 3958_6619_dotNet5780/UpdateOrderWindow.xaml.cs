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
using System.Threading;

namespace _3958_6619_dotNet5780
{
    /// <summary>
    /// Interaction logic for UpdateOrderWindow.xaml
    /// </summary>
    public partial class UpdateOrderWindow : Window
    {
        BE.Order order;
        BL.IBL bl;
        public UpdateOrderWindow()
        {
            InitializeComponent();
            order = new BE.Order();
            bl = BL.FactoryBL.GetBL();
            this.DataContext = order;
            OrderComBox.ItemsSource = bl.GetOrderList();
            emailDatePicker.SelectedDate = DateTime.Now;
        }
 
     
        private void UpdateOrderButton_Click(object sender, RoutedEventArgs e)
        {

            try
            {
                if (OrderComBox.SelectedItem == null)
                    throw new NullReferenceException("please select order to update");
              
                order = OrderComBox.SelectedValue as BE.Order;
             

                this.DataContext = order;

                bl.UpdateOrderStatus(order, BE.OrderStatus.email_sent, Convert.ToDateTime(emailDatePicker.SelectedDate));
                var itUnit = (from newUnit in bl.GetHostingUnitList()
                              where newUnit.HostingUnitKey == order.HostingUnitKey
                              select newUnit).FirstOrDefault();
                var itGuest = (from newGuest in bl.GetGuestList()
                               where newGuest.GuestRequestKey == order.GuestRequestKey
                               select newGuest).FirstOrDefault();
                string to = itGuest.MailAddress;
                string subject = "Your Vacation is Being Scheduled";
                string body = string.Format("a vacation is in the process of being scheduled for  " + itGuest.PrivateName + " "+ itGuest.FamilyName + " for the dates of " + itGuest.EntryDate + "  - " + itGuest.ReleaseDate
                    + " at : "+ itUnit.HostingUnitName + " which is located in the : " + itUnit.area  +" area. Please contact the host directly at: "  + itUnit.Owner.PhoneNumber + " to finalize the reservation");
                Thread thread = new Thread(() => bl.SendMail(to, subject, body));
                thread.Start();
                order = new BE.Order();
                MessageBoxResult result = MessageBox.Show("An email has been sent. Would you like to update another order?", "Status", MessageBoxButton.YesNo,MessageBoxImage.Question);
                switch (result)
                {
                    case MessageBoxResult.Yes:
                        this.Close();
                        Window UpdateOrderWindow = new UpdateOrderWindow();
                        UpdateOrderWindow.Show();
                        break;
                    case MessageBoxResult.No:
                        this.Close();
                        Window window = new OrderWindow();
                        window.Show();
                        break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

       
        private void exitButton_Click(object sender, RoutedEventArgs e)
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

        private void approveOrderButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (OrderComBox.SelectedItem == null)
                    throw new NullReferenceException("please select order to update");
                order = OrderComBox.SelectedValue as BE.Order;
                this.DataContext = order;
                bl.UpdateOrderStatus(order, BE.OrderStatus.customer_accepted,DateTime.Now);
                order = new BE.Order();
                MessageBoxResult result = MessageBox.Show("The order has been approved. Would you like to update another order?", "Status", MessageBoxButton.YesNo);
                switch (result)
                {
                    case MessageBoxResult.Yes:
                        this.Close();
                        Window UpdateOrderWindow = new UpdateOrderWindow();
                        UpdateOrderWindow.Show();
                        break;
                    case MessageBoxResult.No:
                        this.Close();
                        Window window = new OrderWindow();
                        window.Show();
                        break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message,"error",MessageBoxButton.OK,MessageBoxImage.Error);
            }
        }

        private void cancelorderButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (OrderComBox.SelectedItem == null)
                    throw new NullReferenceException("please select order to update");
                order = OrderComBox.SelectedValue as BE.Order;
                this.DataContext = order;
                bl.UpdateOrderStatus(order, BE.OrderStatus.customer_canceled,DateTime.Now);
                order = new BE.Order();
                MessageBoxResult result = MessageBox.Show("This Order has been canceled. Would you like to update another order?", "Status", MessageBoxButton.YesNo);
                switch (result)
                {
                    case MessageBoxResult.Yes:
                        this.Close();
                        Window UpdateOrderWindow = new UpdateOrderWindow();
                        UpdateOrderWindow.Show();
                        break;
                    case MessageBoxResult.No:
                        this.Close();
                        Window window = new OrderWindow();
                        window.Show();
                        break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
