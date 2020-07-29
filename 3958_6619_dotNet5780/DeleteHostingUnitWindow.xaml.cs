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
    /// Interaction logic for DeleteHostingUnitWindow.xaml
    /// </summary>
    public partial class DeleteHostingUnitWindow : Window
    {
        BE.HostingUnit unit;
        BL.IBL bl;
        public DeleteHostingUnitWindow()
        {
            InitializeComponent();
            unit = new BE.HostingUnit();
            bl = BL.FactoryBL.GetBL();
            this.DataContext = unit;
            this.hostingunitComboBox.ItemsSource = bl.GetHostingUnitList();
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
                    Window window = new PersonnalAreaWindow();
                    window.Show();
                    break;
            }
        }

        private void deleteHostingUnitButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {


                if (hostingunitComboBox.SelectedItem == null)
                    throw new NullReferenceException("please select hosting unit to delete");
                unit = this.hostingunitComboBox.SelectedValue as BE.HostingUnit;

                this.DataContext = unit;
                bl.DeleteHostingUnit(unit);
                unit = new BE.HostingUnit();

                MessageBoxResult result = MessageBox.Show("Your Hosting Unit has been deleted. Would you like to delete another hosting unit?", "Status", MessageBoxButton.YesNo, MessageBoxImage.Question);
                switch (result)
                {
                    case MessageBoxResult.Yes:
                        this.Close();
                        Window DeleteHostingUnitWindow = new DeleteHostingUnitWindow();
                        DeleteHostingUnitWindow.Show();
                        break;
                    case MessageBoxResult.No:
                        this.Close();
                        break;
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void hostingunitComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
