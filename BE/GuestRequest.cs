using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
 namespace BE
{
    public class GuestRequest
    {
        public int GuestRequestKey { get ; set ; }
        public string PrivateName { get ; set; }
        public string FamilyName { get ; set ; }
        public string MailAddress { get ; set ; }
        public RequestStatus Status { get ; set ; }
        public DateTime RegistrationDate { get ; set ; }
        public DateTime EntryDate { get ; set ; }
        public DateTime ReleaseDate { get ; set ; }
        public Area area { get ; set ; }
        public Type type { get ; set ; }
        public int Adults { get ; set ; }
        public int Children { get ; set ; }
        public Pool pool { get ; set ; } 
        public Jacuzzi jacuzzi { get ; set ; }
        public Wifi wifi { get ; set ; }
        public Television tv { get; set ; }
        public Garden garden { get ; set ; }
        public ChildrensAttractions childrensAttractions { get ; set ; }
        public PublicTransportation publicTransportation { get ; set ; }
        public View view { get ; set ; }
        public Smoking smoking { get ; set ; }
        public RoomService roomService { get ; set; }
        public SnackBar snackBar { get ; set ; }

      //  public int CancellationFee { get ; set ; }
     


        public override string ToString()
        {
            return "request key: " + GuestRequestKey + " Last Name: " + FamilyName + " First Name: " + PrivateName +
                " Email Address: " + MailAddress + " Status:" + Status + " Registration Date " + RegistrationDate +
                " Entry Date: " + EntryDate + " Release Date: " + ReleaseDate + " Area: " + area + " Type: " + type
                + " Number of Adults: " + Adults + " Number of Children: " + Children + " Pool: " + pool + " Jaccuzi: "
                + jacuzzi + " Wifi: " + wifi + " Tv: " + tv + " Garden: " + garden + " Children's Attractions: "
                + childrensAttractions + " Public Transportation: " + publicTransportation + " View: " + view + " Smoking: "
                + smoking + " Room Service: " + " Snack Bar: " + snackBar  ;
        }
    }
}