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
    /// Interaction logic for GuestsRequestsListWindow.xaml
    /// </summary>
    public partial class GuestsRequestsListWindow : Window
    {
        BL.IBL bl;
        public GuestsRequestsListWindow()
        {
            InitializeComponent();
            guestrequestListBox.ItemsSource = bl.GetGuestList();
        }

        private void guestrequestListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void exitButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Are you sure that you are finished?", "Exit", MessageBoxButton.YesNo, MessageBoxImage.Question);
            switch (result)
            {
                case MessageBoxResult.Yes:
                    this.Close();
                    break;
                case MessageBoxResult.No:

                    break;
            }
        }
    }
}
