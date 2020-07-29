using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using BE;
using System.ComponentModel;

namespace _3958_6619_dotNet5780
{
    /// <summary>
    /// Interaction logic for OrderListQueries.xaml
    /// </summary>
    public partial class OrderListQueries : Window
    {
        IBL bl;
       
        public OrderListQueries()
        {
            
            InitializeComponent();
            bl = FactoryBL.GetBL();
        }

        private void groupbyComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {

                if (groupbyComboBox.SelectedIndex == 0)
                {
                    groupedordersGrid.Items.Clear();
                    groupedordersGrid.CanUserResizeColumns = false;
                    groupedordersGrid.CanUserResizeRows = false;
                    groupedordersGrid.CanUserReorderColumns = false;
                    groupedordersGrid.CanUserSortColumns = false;
                    var x = bl.GetGroupedByUnitPopularity();
                    foreach (var group in x)
                    {
                        foreach (var order in group)
                        {
                            groupedordersGrid.Items.Add(order);
                        }
                        groupedordersGrid.Items.Add(0);
                    }


                }
                if(groupbyComboBox.SelectedIndex==1)
                {
                    groupedordersGrid.Items.Clear();
                    groupedordersGrid.CanUserSortColumns = true;
                    groupedordersGrid.CanUserResizeColumns = false;
                    groupedordersGrid.CanUserResizeRows = false;
                    groupedordersGrid.CanUserReorderColumns = false;
                    foreach (var item in bl.GetOrderList())
                    {
                        groupedordersGrid.Items.Add(item);
                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message,"Error",MessageBoxButton.OK,MessageBoxImage.Error);
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
