using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
namespace BE
{
    [Serializable]
 
    public class HostingUnit
    {
      
        public int HostingUnitKey { get; set ; }

     
        public Host Owner { get ; set ; }
       
        public Area area { get ; set ; }
     
        public Type type { get ; set ; }
       
        public View view { get; set; }
    
        public int Size { get ; set ; }
     
        public int Floors { get ; set ; }
     
        public Pool pool { get ; set ; }
        public Jacuzzi jacuzzi { get ; set ; }
        public Wifi wifi { get ; set ; }
        public Television tv { get ; set ; }
        public Garden garden { get ; set ; }
        public ChildrensAttractions childrensAttractions { get ; set ; }
        public PublicTransportation publicTransportation { get ; set ; }
        public Smoking smoking { get; set ; }
        public RoomService roomService { get; set ; }
        public SnackBar snackBar { get ; set ; }
        public string HostingUnitName { get ; set ; }
        [XmlIgnore]
        public bool[,] Diary  = new bool[12, 31];
        [XmlArray("Diary")]
        public bool[] DiaryForXML
        {
            get { return Diary.Flatten(); }
            set { Diary = value.Expand(12); }
        }
        public override string ToString()
        {
            return "Hosting Unit Key: " + HostingUnitKey + " Hosting Unit Name: " + HostingUnitName +
                " Owner: " + Owner + "Area: " + area + " Type: " + type + " Size: " + Size + " Floors: " + Floors
               + " Pool: " + pool + " Jacuzzi: "
               + jacuzzi + " Wifi: " + wifi + " Tv: " + tv + " Garden: " + garden + " Children's Attractions: "
               + childrensAttractions + " Public Transportation: " + publicTransportation + " View: " + view + " Smoking: "
               + smoking + " Room Service: " + " Snack Bar: " + snackBar ;
        }

       
    }
}