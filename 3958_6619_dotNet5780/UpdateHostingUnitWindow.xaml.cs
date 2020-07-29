using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Text.RegularExpressions;
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
    /// Interaction logic for UpdateHostingUnitWindow.xaml
    /// </summary>
    public partial class UpdateHostingUnitWindow : Window
    {
        BE.HostingUnit unit;
        BE.Host host;
        BL.IBL bl;
        public UpdateHostingUnitWindow()
        {
            InitializeComponent();
            unit = new BE.HostingUnit();
            bl = BL.FactoryBL.GetBL();
            this.DataContext = unit;
            this.JacuzziComboxBox.ItemsSource = Enum.GetValues(typeof(BE.Jacuzzi));
            this.PoolComboxBox.ItemsSource = Enum.GetValues(typeof(BE.Pool));
            this.SnackBarComboxBox.ItemsSource = Enum.GetValues(typeof(BE.SnackBar));
            this.WifiComboxBox.ItemsSource = Enum.GetValues(typeof(BE.Wifi));
            this.TvComboxBox.ItemsSource = Enum.GetValues(typeof(BE.Television));
            this.GardenComboxBox.ItemsSource = Enum.GetValues(typeof(BE.Garden));
            this.RoomServiceComboxBox.ItemsSource = Enum.GetValues(typeof(BE.RoomService));
            this.ChildrensAttractionComboxBox.ItemsSource = Enum.GetValues(typeof(BE.ChildrensAttractions));
            this.PublicTransportationComboxBox.ItemsSource = Enum.GetValues(typeof(BE.PublicTransportation));
            this.SmokingComboxBox.ItemsSource = Enum.GetValues(typeof(BE.Smoking));
            this.collectionclearanceComboBox.ItemsSource = Enum.GetValues(typeof(BE.PaymentClearance));
            this.HostingUnitKeyComboBox.ItemsSource = bl.GetHostingUnitList();
        }

        
        

        private void updatehostingunitButton_Click(object sender, RoutedEventArgs e)
        {

            try
            {
                if (PoolComboxBox.SelectedItem == null  || PublicTransportationComboxBox.SelectedItem == null || JacuzziComboxBox.SelectedItem == null  || SmokingComboxBox.SelectedItem == null ||
                RoomServiceComboxBox.SelectedItem == null  || GardenComboxBox.SelectedItem == null || ChildrensAttractionComboxBox.SelectedItem == null || WifiComboxBox.SelectedItem == null ||
                TvComboxBox.SelectedItem == null || SnackBarComboxBox.SelectedItem == null  || sizeTextBox.Text == "" ||
                floorsTextBox.Text ==  ""|| HostingUnitNameTextBox.Text == "" || collectionclearanceComboBox.SelectedItem == null)
                    throw new NullReferenceException("please fill out all of the fields");
                if (!Regex.IsMatch(this.sizeTextBox.Text.ToString(), @"^\d+$"))
                    throw new InvalidOperationException("invaild size");
                if (!Regex.IsMatch(this.floorsTextBox.Text.ToString(), @"^\d+$"))
                    throw new InvalidOperationException("invaild number of floors");
                unit =(BE.HostingUnit) this.HostingUnitKeyComboBox.SelectedItem;
                 var x =( from hostingunit in bl.GetHostingUnitList()
                    where hostingunit.HostingUnitKey == unit.HostingUnitKey
                    select hostingunit).FirstOrDefault();
                unit.HostingUnitName = this.HostingUnitNameTextBox.Text;
                unit.Owner = x.Owner;
                unit.Owner.CollectionClearance = (BE.PaymentClearance)collectionclearanceComboBox.SelectedIndex;
                unit.jacuzzi = (BE.Jacuzzi)this.JacuzziComboxBox.SelectedItem;
                unit.pool = (BE.Pool)this.PoolComboxBox.SelectedItem;
                unit.snackBar = (BE.SnackBar)this.SnackBarComboxBox.SelectedItem;
                unit.wifi = (BE.Wifi)this.WifiComboxBox.SelectedItem;
                unit.tv = (BE.Television)this.TvComboxBox.SelectedItem;
                unit.garden = (BE.Garden)this.GardenComboxBox.SelectedItem;
                unit.roomService = (BE.RoomService)this.RoomServiceComboxBox.SelectedItem;
                unit.childrensAttractions = (BE.ChildrensAttractions)this.ChildrensAttractionComboxBox.SelectedItem;
                unit.publicTransportation = (BE.PublicTransportation)this.PublicTransportationComboxBox.SelectedItem;
                unit.smoking = (BE.Smoking)this.SmokingComboxBox.SelectedItem;
                unit.Size = int.Parse(sizeTextBox.Text);
                unit.Floors = int.Parse(floorsTextBox.Text);
                this.DataContext = unit;

                bl.UpdateHostingUnit(unit);
                unit = new BE.HostingUnit();
                MessageBoxResult result = MessageBox.Show("Thank You, your unit has been updated. Would you like to update another unit?", "Status", MessageBoxButton.YesNo , MessageBoxImage.Question);
                switch (result)
                {
                    case MessageBoxResult.Yes:
                        this.Close();
                        Window UpdateHostingUnitWindow = new UpdateHostingUnitWindow();
                        UpdateHostingUnitWindow.Show();
                        break;
                    case MessageBoxResult.No:
                        this.Close();
                        Window window = new PersonnalAreaWindow();
                        window.Show();
                        break;
                }
            }


            catch (Exception ex)
            {
                MessageBox.Show(ex.Message,"Error",MessageBoxButton.OK,MessageBoxImage.Error);
            }
        }


     

            private void gobackButton_Click(object sender, RoutedEventArgs e)
            {
                MessageBoxResult result = MessageBox.Show("Are you sure that you are finished?", "Exit", MessageBoxButton.YesNo,MessageBoxImage.Question);
                switch (result)
                {
                    case MessageBoxResult.Yes:
                        this.Close();
                    Window window = new PersonnalAreaWindow();
                    window.Show();
                    break;
                    case MessageBoxResult.No:

                        break;
                }
            }
        

        private  void HostingUnitKeyComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            unit = this.HostingUnitKeyComboBox.SelectedValue as BE.HostingUnit;
            collectionclearanceComboBox.SelectedItem = unit.Owner.CollectionClearance;
            PoolComboxBox.SelectedItem = unit.pool;
            JacuzziComboxBox.SelectedItem = unit.jacuzzi;
            ChildrensAttractionComboxBox.SelectedItem = unit.childrensAttractions;
            GardenComboxBox.SelectedItem = unit.garden;
            PublicTransportationComboxBox.SelectedItem = unit.publicTransportation;
            WifiComboxBox.SelectedItem = unit.wifi;
            TvComboxBox.SelectedItem = unit.tv;
            RoomServiceComboxBox.SelectedItem = unit.roomService;
            SnackBarComboxBox.SelectedItem = unit.snackBar;
            SmokingComboxBox.SelectedItem = unit.smoking;
            HostingUnitNameTextBox.Text = unit.HostingUnitName;
            floorsTextBox.Text = unit.Floors.ToString();
            sizeTextBox.Text = unit.Size.ToString();


        }

    }
}
