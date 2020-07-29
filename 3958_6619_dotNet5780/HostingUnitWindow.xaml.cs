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
    /// Interaction logic for HostingUnitWindow.xaml
    /// </summary>
    public partial class HostingUnitWindow : Window
    {
        public HostingUnitWindow()
        {
            InitializeComponent();
        }

        private void PersonalAreaClick(object sender, RoutedEventArgs e)
        {
            Window HostingUnitPasswordWindow = new HostingUnitPasswordWindow();
            HostingUnitPasswordWindow.ShowDialog();
            if (HostingUnitPasswordWindow.DialogResult == true)
            {
                this.Close();
                Window PersonnalAreaWindow = new PersonnalAreaWindow();
                PersonnalAreaWindow.Show();
            }
        }
        private void AddHostingUnitClick(object sender, RoutedEventArgs e)
        {
            this.Close();
            try
            {
                Window AddHostingUnitWindow = new AddHostingUnitWindow();
                AddHostingUnitWindow.Show();
            }
            catch(Exception ex)
            {
                MessageBox.Show("Please try again , loading the bank list takes time");
            }
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
    }
}
