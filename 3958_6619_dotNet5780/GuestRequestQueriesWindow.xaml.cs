using System;
using System.Collections;
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

namespace _3958_6619_dotNet5780
{
    /// <summary>
    /// Interaction logic for GuestRequestQueriesWindow.xaml
    /// </summary>
    public partial class GuestRequestQueriesWindow : Window
    {
        IBL bl;
      
        public GuestRequestQueriesWindow()
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
                
                    var x = bl.GetGroupedByArea();
                    foreach (var group in x)
                    {
                        foreach (var request in group)
                        {
                            groupingDataGrid.Items.Add(request);
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
                    var x = bl.GetGroupedByNumberOfVacations();
                    foreach (var group in x)
                    {
                        foreach (var request in group)
                        {
                            groupingDataGrid.Items.Add(request);
                        }
                        groupingDataGrid.Items.Add(0);
                    }
                 
                }
                if(groupbyComboBox.SelectedIndex==2)
                {
                    groupingDataGrid.Items.Clear();
                    groupingDataGrid.CanUserSortColumns = true;
                    groupingDataGrid.CanUserResizeColumns = false;
                    groupingDataGrid.CanUserResizeRows = false;
                    groupingDataGrid.CanUserReorderColumns = false;
                    foreach(var item in bl.GetGuestList())
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
    }
}
