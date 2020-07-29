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
    /// Interaction logic for PersonnalAreaWindow.xaml
    /// </summary>
    public partial class PersonnalAreaWindow : Window
    {
        public PersonnalAreaWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Window UpdateHostingUnitWindow = new UpdateHostingUnitWindow();
            UpdateHostingUnitWindow.Show();
            this.Close();
        }

        private void DeleteHostingUnitButton_Click(object sender, RoutedEventArgs e)
        {
            Window DeleteHostingUnitWindow = new DeleteHostingUnitWindow();
            DeleteHostingUnitWindow.Show();
            this.Close();
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

        private void OrderButton_Click(object sender, RoutedEventArgs e)
        {
            Window OrderWindow = new OrderWindow();
            OrderWindow.Show();
            this.Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Window GuestRequestQueriesWindow = new GuestRequestQueriesWindow();
            GuestRequestQueriesWindow.Show();
            this.Close();
        }
    }
}
