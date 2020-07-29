using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class Order
    {
        public int HostingUnitKey { get ; set; }
        public int GuestRequestKey { get ; set ; }
        public int OrderKey { get ; set ; }
        public OrderStatus Status { get; set ; }
        public DateTime CreateDate { get ; set ; }
        public DateTime OrderDate { get ; set ; }
        public override string ToString()
        {
            return " Order Key: " + OrderKey + "Hosting Unit Key: " + HostingUnitKey + " Guest Request Key: " +
            GuestRequestKey + " Order Status: " + Status
            + " Create Date: " + CreateDate + " Order Date: " + OrderDate;
        }
       
    }
  
}