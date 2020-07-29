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
    /// Interaction logic for HostingUnitPasswordWindow.xaml
    /// </summary>
    public partial class HostingUnitPasswordWindow : Window
    {
        public HostingUnitPasswordWindow()
        {
            InitializeComponent();
        }

        private void SignInButtonClick_Click(object sender, RoutedEventArgs e)
        {
            if (HostingUnitPasswordBox.Password.ToString() == "1111")
            {
                this.DialogResult = true;
                this.Close();
            }
            else
            {
                MessageBox.Show("please try again");
            }
        }
    }
}
