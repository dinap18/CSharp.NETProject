using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public enum Type { all, hotel, tent, apartment, house, treehouse, caravan }
    public enum Area { all, north, south, center, jerusalem, tel_aviv, golan, galil }
    public enum RequestStatus {active, closed_by_website, expired}
    public enum OrderStatus { not_dealt_with, email_sent, customer_accepted, customer_canceled }
    
    public enum CollectionClearance { yes, no }
    public enum Pool { yes, no, doesnt_matter }
    public enum Jacuzzi { yes, no, doesnt_matter }
    public enum Wifi { yes, no, doesnt_matter }
    public enum Television { yes, no, doesnt_matter }
    public enum Garden { yes, no, doesnt_matter }
    public enum ChildrensAttractions { yes, no, doesnt_matter }
    public enum PublicTransportation { yes, no, doesnt_matter }
    public enum View { yes, no, doesnt_matter }
    public enum Smoking { yes, no, doesnt_matter }
    public enum RoomService { yes, no, doesnt_matter }
    public enum SnackBar { yes, no, doesnt_matter }
    public enum PaymentClearance { yes,no}
    
}
