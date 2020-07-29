using System;
using System.Collections.Generic;
using System.Linq;
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
using BE;

namespace _3958_6619_dotNet5780
{
    /// <summary>
    /// Interaction logic for AddGuestRequestWindow.xaml
    /// </summary>
    public partial class AddGuestRequestWindow : Window
    {

   
        BE.GuestRequest request;
        BL.IBL bl;
        public AddGuestRequestWindow()
        {
            InitializeComponent();
            request = new BE.GuestRequest();
            bl = BL.FactoryBL.GetBL();
            this.DataContext = request;
            this.JacuzziComboxBox.ItemsSource = Enum.GetValues(typeof(BE.Jacuzzi));
            this.PoolComboxBox.ItemsSource = Enum.GetValues(typeof(BE.Pool));
            this.SnackBarComboxBox.ItemsSource = Enum.GetValues(typeof(BE.SnackBar));
            this.smokingComboxBox.ItemsSource = Enum.GetValues(typeof(BE.Smoking));
            this.AreaComboxBox.ItemsSource = Enum.GetValues(typeof(BE.Area));
            this.WifiComboxBox.ItemsSource = Enum.GetValues(typeof(BE.Wifi));
            this.TelevisionComboxBox.ItemsSource = Enum.GetValues(typeof(BE.Television));
            this.GardenComboxBox.ItemsSource = Enum.GetValues(typeof(BE.Garden));
            this.RoomServiceComboxBox.ItemsSource = Enum.GetValues(typeof(BE.RoomService));
            this.ChildrensAttractionComboxBox.ItemsSource = Enum.GetValues(typeof(BE.ChildrensAttractions));
            this.PublicTransportationComboxBox.ItemsSource = Enum.GetValues(typeof(BE.PublicTransportation));
            this.ViewComboxBox.ItemsSource = Enum.GetValues(typeof(BE.View));
            
        }

        private void AddRequest(object sender, RoutedEventArgs e)
        {
            try
            {
                if (PoolComboxBox.SelectedItem == null || PublicTransportationComboxBox.SelectedItem == null || JacuzziComboxBox.SelectedItem == null || ViewComboxBox.SelectedItem == null || smokingComboxBox.SelectedItem == null ||
                    RoomServiceComboxBox.SelectedItem == null || AreaComboxBox.SelectedItem == null || GardenComboxBox.SelectedItem == null || ChildrensAttractionComboxBox.SelectedItem == null || WifiComboxBox.SelectedItem == null ||
                    TelevisionComboxBox.SelectedItem == null || SnackBarComboxBox.SelectedItem == null || LastNameTextBox.Text == "" || FirstNameTextBox.Text=="" || EmailTextBox.Text == "" || AdultTextBox.Text == "" ||
                    ChildrenTextBox.Text == "" || EntryDateDatePicker.SelectedDate == null || RealeaseDateDatePicker.SelectedDate==null)
                    throw new NullReferenceException("please fill out all of the fields");
                if (!Regex.IsMatch(this.AdultTextBox.Text.ToString(), @"^\d+$"))
                    throw new InvalidOperationException("invaild number of adults");
                if (!Regex.IsMatch(this.ChildrenTextBox.Text.ToString(), @"^\d+$"))
                    throw new InvalidOperationException("invaild number of Children");
                request.pool = (BE.Pool)PoolComboxBox.SelectedItem;
                request.publicTransportation = (BE.PublicTransportation)PublicTransportationComboxBox.SelectedItem;
                request.jacuzzi = (BE.Jacuzzi)JacuzziComboxBox.SelectedItem;
                request.view = (BE.View)ViewComboxBox.SelectedItem;
                request.smoking = (BE.Smoking)smokingComboxBox.SelectedItem;
                request.roomService = (BE.RoomService)RoomServiceComboxBox.SelectedItem;
                request.area = (BE.Area)AreaComboxBox.SelectedItem;
                request.garden = (BE.Garden)GardenComboxBox.SelectedItem;
                request.childrensAttractions = (BE.ChildrensAttractions)ChildrensAttractionComboxBox.SelectedItem;
                request.wifi = (BE.Wifi)WifiComboxBox.SelectedItem;
                request.tv = (BE.Television)TelevisionComboxBox.SelectedItem;
                request.snackBar = (BE.SnackBar)SnackBarComboxBox.SelectedItem;
                //request.area = (BE.Area)AreaComboxBox.SelectedItem;
                request.FamilyName = this.LastNameTextBox.Text;
                request.PrivateName = this.FirstNameTextBox.Text;
                request.MailAddress = this.EmailTextBox.Text;
               
                request.Adults = int.Parse(this.AdultTextBox.Text);
                request.Children = int.Parse(this.ChildrenTextBox.Text);
                string date1, date2;
             //   date1 = EntryDateDatePicker.SelectedDate.ToString();
                request.EntryDate = Convert.ToDateTime(EntryDateDatePicker.SelectedDate.ToString());
             //   date2 = RealeaseDateDatePicker.SelectedDate.ToString();
                request.ReleaseDate = Convert.ToDateTime(RealeaseDateDatePicker.SelectedDate.ToString());
                this.DataContext = request;
               
                bl.AddGuestRequest(request);
                request = new BE.GuestRequest();
                MessageBoxResult result=MessageBox.Show("Thank You, your request has been received. Would you like to make another request?", "Status",MessageBoxButton.YesNo,MessageBoxImage.Information);
                switch(result)
                {
                    case MessageBoxResult.Yes:
                        this.Close();
                         Window AddGuestRequestWindow = new AddGuestRequestWindow();
                         AddGuestRequestWindow.Show();
                        break;
                    case MessageBoxResult.No:
                        this.Close();
                       
                       
                        break;
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message,"Error",MessageBoxButton.OK,MessageBoxImage.Error);
            }
        }

        

        private void gobackButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Are you sure that you are finished?", "Exit", MessageBoxButton.YesNo);
            switch (result)
            {
                case MessageBoxResult.Yes:
                    this.Close();
                    break;
                case MessageBoxResult.No:
                    
                    break;
            }
        }

        private void EntryDateDatePicker_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            RealeaseDateDatePicker.DisplayDateStart = EntryDateDatePicker.SelectedDate;
        }
    }

    

}
