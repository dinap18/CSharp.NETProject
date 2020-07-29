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
    /// Interaction logic for HostingUnitQueriesWindow.xaml
    /// </summary>
    public partial class HostingUnitQueriesWindow : Window
    {
        IBL bl;
        public HostingUnitQueriesWindow()
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
                    groupingDataGrid.Items.Clear();
                    groupingDataGrid.CanUserResizeColumns = false;
                    groupingDataGrid.CanUserResizeRows = false;
                    groupingDataGrid.CanUserReorderColumns = false;
                    groupingDataGrid.CanUserSortColumns = false;

                    var x = bl.GetGroupedByUnitArea();
                    foreach (var group in x)
                    {
                        foreach (var unit in group)
                        {
                            groupingDataGrid.Items.Add(unit);
                        }
                        groupingDataGrid.Items.Add(0);
                    }

                }
                
                if (groupbyComboBox.SelectedIndex == 1)
                {
                    groupingDataGrid.Items.Clear();
                    groupingDataGrid.CanUserResizeColumns = false;
                    groupingDataGrid.CanUserResizeRows = false;
                    groupingDataGrid.CanUserReorderColumns = false;
                    groupingDataGrid.CanUserSortColumns = false;
                    var x = bl.GetGroupedByNumberOfUnits();
                    foreach (var group in x)
                    {
                        foreach (var unit in group)
                        {
                            groupingDataGrid.Items.Add(unit);
                        }
                        groupingDataGrid.Items.Add(0);
                    }
                }
               
                if (groupbyComboBox.SelectedIndex == 2)
                {
                    groupingDataGrid.Items.Clear();
                    groupingDataGrid.CanUserResizeColumns = false;
                    groupingDataGrid.CanUserResizeRows = false;
                    groupingDataGrid.CanUserReorderColumns = false;
                    groupingDataGrid.CanUserSortColumns = false;
                    var x = bl.GetGroupedByNoTelevisionAndWifi();
                    foreach (var group in x)
                    {
                        foreach (var unit in group)
                        {
                            groupingDataGrid.Items.Add(unit);
                        }
                        groupingDataGrid.Items.Add(0);
                    }
                  
                }
                if(groupbyComboBox.SelectedIndex==3)
                {
                    groupingDataGrid.Items.Clear();
                    groupingDataGrid.CanUserSortColumns = true;
                    groupingDataGrid.CanUserResizeColumns = false;
                    groupingDataGrid.CanUserResizeRows = false;
                    groupingDataGrid.CanUserReorderColumns = false;
                    foreach (var item in bl.GetHostingUnitList())
                    {
                        groupingDataGrid.Items.Add(item);
                    }
                }
            }
            catch (Exception ex)
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
