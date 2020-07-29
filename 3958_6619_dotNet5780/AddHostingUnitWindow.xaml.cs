using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
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
    /// Interaction logic for AddHostingUnitWindow.xaml
    /// </summary>
    /// 

    public class Terms : IValueConverter
    {
        public object Convert(
          object value,
          Type targetType,
          object parameter,
          CultureInfo culture)
        {
           

            bool boolValue = (bool)value;
            if (boolValue)
            {
                return Visibility.Visible;
               
            }
            else
            {
                return Visibility.Collapsed;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
        public partial class AddHostingUnitWindow : Window
    {
        BE.HostingUnit unit;
        BE.Host host;
        BL.IBL bl;
        BackgroundWorker bgWorker = new System.ComponentModel.BackgroundWorker();
        public AddHostingUnitWindow()
        {
            try
            {
                InitializeComponent();
                unit = new BE.HostingUnit();
                host = new BE.Host();
                bl = BL.FactoryBL.GetBL();
                this.DataContext = unit;
                this.jacuzziComboBox.ItemsSource = Enum.GetValues(typeof(BE.Jacuzzi));
                //jacuzziComboBox.TabIndex = 0;
                this.poolComboBox.ItemsSource = Enum.GetValues(typeof(BE.Pool));
                this.snackBarComboBox.ItemsSource = Enum.GetValues(typeof(BE.SnackBar));
                this.smokingComboBox.ItemsSource = Enum.GetValues(typeof(BE.Smoking));
                this.areaComboBox.ItemsSource = Enum.GetValues(typeof(BE.Area));
                this.wifiComboBox.ItemsSource = Enum.GetValues(typeof(BE.Wifi));
                this.typeComboBox.ItemsSource = Enum.GetValues(typeof(BE.Type));
                this.tvComboBox.ItemsSource = Enum.GetValues(typeof(BE.Television));
                this.gardenComboBox.ItemsSource = Enum.GetValues(typeof(BE.Garden));
                this.roomServiceComboBox.ItemsSource = Enum.GetValues(typeof(BE.RoomService));
                this.childrensAttractionsComboBox.ItemsSource = Enum.GetValues(typeof(BE.ChildrensAttractions));
                this.publicTransportationComboBox.ItemsSource = Enum.GetValues(typeof(BE.PublicTransportation));
                this.viewComboBox.ItemsSource = Enum.GetValues(typeof(BE.View));
                this.collectionClearanceComboBox.ItemsSource = Enum.GetValues(typeof(BE.PaymentClearance));
                this.banknameComboBox.ItemsSource = bl.getBankNames();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message,"error",MessageBoxButton.OK,MessageBoxImage.Error);

                 this.Close();
                Window HostingUnitWindow = new HostingUnitWindow();
                HostingUnitWindow.Show();

            }

       

        }


        private void addhostingunitbutton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (poolComboBox.SelectedItem == null|| typeComboBox.SelectedItem == null || publicTransportationComboBox.SelectedItem == null || jacuzziComboBox.SelectedItem == null || viewComboBox.SelectedItem == null || smokingComboBox.SelectedItem == null ||
                 roomServiceComboBox.SelectedItem == null || areaComboBox.SelectedItem == null || gardenComboBox.SelectedItem == null || childrensAttractionsComboBox.SelectedItem == null || wifiComboBox.SelectedItem == null ||
                 tvComboBox.SelectedItem == null || snackBarComboBox.SelectedItem == null || familyNameTextBox.Text == "" || privateNameTextBox.Text == "" || mailAddressTextBox.Text == "" || sizeTextBox.Text == "" ||
                 floorsTextBox.Text == "" || ageTextBox.Text == "" || bankAccountNumberTextBox.Text == "" || phoneNumberTextBox.Text == "" || hostKeyTextBox.Text == "" || hostingUnitNameTextBox.Text == ""|| collectionClearanceComboBox.SelectedItem == null|| banknameComboBox.SelectedItem==null || branchnumberComboBox.SelectedItem==null)
                    throw new NullReferenceException("please fill out all of the fields");
                if (!Regex.IsMatch(this.sizeTextBox.Text.ToString(), @"^\d+$"))
                    throw new InvalidOperationException("invaild size");
                if (!Regex.IsMatch(this.floorsTextBox.Text.ToString(), @"^\d+$"))
                    throw new InvalidOperationException("invaild number of floors");
                if (!Regex.IsMatch(this.bankAccountNumberTextBox.Text.ToString(), @"^\d+$"))
                    throw new InvalidOperationException("invaild bank account number");
                if (!Regex.IsMatch(this.hostKeyTextBox.Text.ToString(), @"^\d+$"))
                    throw new InvalidOperationException("invaild host key");
                if (!Regex.IsMatch(this.ageTextBox.Text.ToString(), @"^\d+$"))
                    throw new InvalidOperationException("invaild age");
                
                if (!Regex.IsMatch(phoneNumberTextBox.Text, @"^(\d{10})$"))
                    throw new InvalidOperationException("invaild phone number");
                unit.garden = (BE.Garden)gardenComboBox.SelectedItem;
                unit.area = (BE.Area)areaComboBox.SelectedItem;
                unit.publicTransportation = (BE.PublicTransportation)publicTransportationComboBox.SelectedItem;
                unit.pool = (BE.Pool)poolComboBox.SelectedItem;
                unit.wifi = (BE.Wifi)wifiComboBox.SelectedItem;
                unit.roomService = (BE.RoomService)roomServiceComboBox.SelectedItem;
                unit.smoking = (BE.Smoking)smokingComboBox.SelectedItem;
                unit.snackBar = (BE.SnackBar)snackBarComboBox.SelectedItem;
                unit.tv = (BE.Television)tvComboBox.SelectedItem;
                unit.type = (BE.Type)typeComboBox.SelectedItem;
                unit.view = (BE.View)viewComboBox.SelectedItem;
                unit.jacuzzi = (BE.Jacuzzi)jacuzziComboBox.SelectedItem;
                host.CollectionClearance = (BE.PaymentClearance)collectionClearanceComboBox.SelectedItem;
                
                unit.Size = int.Parse(this.sizeTextBox.Text);
                unit.Floors = int.Parse(this.floorsTextBox.Text);
                unit.HostingUnitName = (this.hostingUnitNameTextBox.Text);
                host.PrivateName = (this.privateNameTextBox.Text);
                host.PhoneNumber = (this.phoneNumberTextBox.Text);
                host.FamilyName = (this.familyNameTextBox.Text);
                host.BankAccountNumber = int.Parse(this.bankAccountNumberTextBox.Text);
                host.Age = int.Parse(this.ageTextBox.Text);
                host.MailAddress = (this.mailAddressTextBox.Text);
                host.HostKey = int.Parse(this.hostKeyTextBox.Text);
                host.BankBranchDetails = bl.GetBranchByNumberAndName(int.Parse(branchnumberComboBox.Text), banknameComboBox.Text);
            unit.Owner = host;
                this.DataContext = unit;
                bl.AddHostingUnit(unit);
                unit = new BE.HostingUnit();

                MessageBoxResult result = MessageBox.Show("Thank You, your unit has been added. Would you like to add another hosting unit?", "Status", MessageBoxButton.YesNo,MessageBoxImage.Question);
                switch (result)
                {
                    case MessageBoxResult.Yes:
                        this.Close();
                        Window AddHostingUnitWindow = new AddHostingUnitWindow();
                        AddHostingUnitWindow.Show();
                        break;
                    case MessageBoxResult.No:
                        this.Close();
                        break;
                }
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        private void ExitButton_Click(object sender, RoutedEventArgs e)
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

        private void banknameComboBox_MouseLeave(object sender, MouseEventArgs e)
        {
            this.branchnumberComboBox.ItemsSource = bl.GetBranchNumbers(banknameComboBox.Text);
        }

        private void banknameComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
            branchnumberLabel.Visibility = Visibility.Visible;
            branchnumberComboBox.Visibility = Visibility.Visible;
        }

        private void phoneNumberTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }

    
}
