using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace BE
{ 
    [Serializable]
   
    public class Host
    {
        
        public int HostKey { get ; set; }
        
        public string PrivateName { get ; set ; }
        
        public string FamilyName { get ; set; }
       
        public string PhoneNumber { get ; set; }
      
        public string MailAddress { get; set; }
      
        public int Age { get; set ; }
    
        public int BankAccountNumber { get; set; }
      
        public BankBranches BankBranchDetails { get; set; }
        
        public PaymentClearance CollectionClearance { get ; set ; }
       
        public int PaymentOwed { get; set; }
        public override string ToString()
        {
            return "Host Key: " + HostKey + " First Name: " + PrivateName + " Last Name: " +
              FamilyName + " Phone Number: " + PhoneNumber + " Email Address: " + MailAddress + 
              " Age: " + Age + " Bank Branch Details: " + BankBranchDetails +"  Bank Account Number "+ BankAccountNumber+
              " Collection Clearance: " + CollectionClearance + " Payment Owed: "+ PaymentOwed +" shekel ";
        }



    }
}
