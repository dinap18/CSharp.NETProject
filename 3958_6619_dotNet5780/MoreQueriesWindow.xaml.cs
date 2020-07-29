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
using BL;

namespace _3958_6619_dotNet5780
{
    /// <summary>
    /// Interaction logic for MoreQueriesWindow.xaml
    /// </summary>
    public partial class MoreQueriesWindow : Window
    {
        BL.IBL bl;
        public MoreQueriesWindow()
        {
            InitializeComponent();
            bl = BL.FactoryBL.GetBL();
        }

        private void chooselistComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                if(chooselistComboBox.SelectedIndex==0)
                {
                    listview.Items.Clear();
                    foreach (var item in bl.GetGuestList())
                    {
                        listview.Items.Add(item);
                    }
                }
                if (chooselistComboBox.SelectedIndex == 1)
                {
                    listview.Items.Clear();
                    foreach (var item in bl.GetHostingUnitList())
                    {
                        listview.Items.Add(item);
                    }
                }
                if (chooselistComboBox.SelectedIndex == 2)
                {
                    listview.Items.Clear();
                    foreach (var item in bl.GetOrderList())
                    {
                        listview.Items.Add(item);
                    }
                }
                if (chooselistComboBox.SelectedIndex == 3)
                {
                    listview.Items.Clear();
                    foreach (var item in bl.GetBranches())
                    {
                        listview.Items.Add(item);
                    }
                }
                if (chooselistComboBox.SelectedIndex == 4)
                {
                    listview.Items.Clear();
                    foreach (var item in bl.GetUnitsInTelAvivWithPoolAndJacuzzi())
                    {
                        listview.Items.Add(item);
                    }
                }
                if (chooselistComboBox.SelectedIndex == 5)
                {
                    listview.Items.Clear();
                    foreach (var item in bl.GetGuestsWithChildrenAndWantToSmoke())
                    {
                        listview.Items.Add(item);
                    }
                }
                if (chooselistComboBox.SelectedIndex == 6)
                {
                    listview.Items.Clear();
                    foreach (var item in bl.GetBankInJerusalem())
                    {
                        listview.Items.Add(item);
                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message,"error",MessageBoxButton.OK,MessageBoxImage.Error);
            }
        }

        private void exitButton_Click(object sender, RoutedEventArgs e)
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
