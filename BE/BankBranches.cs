using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace BE
{
    [Serializable]
   
    public class BankBranches
    {
     
        public int BankNumber { get ; set ; }
        
        public string BankName { get ; set ; }
      
        public int BranchNumber { get; set ; }
       
        public string BranchAddress { get; set; }
        
        public string BranchCity { get ; set ; }
        public override string ToString()
        {
            return "Bank Number : " + BankNumber + " Bank Name: " + BankName +
                " Branch Number: " + BranchNumber + " Branch Address: " + BranchAddress
                + " Branch City: " + BranchCity;
        }
    }
}
