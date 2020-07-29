using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;
namespace DAL
{
    public static class Cloning
    {
        public static BankBranches Clone(this BankBranches original)
        {
            BankBranches target = new BE.BankBranches();
            target.BankNumber = original.BankNumber;
            target.BankName = original.BankName;
            target.BranchNumber = original.BranchNumber;
            target.BranchAddress = original.BranchAddress;
            target.BranchCity = original.BranchCity; 

            return target;
        }
        public static Host Clone(this Host original)
        {
            Host target = new BE.Host();
            target.HostKey = original.HostKey;
            target.PrivateName = original.PrivateName;
            target.FamilyName = original.FamilyName;
            target.PhoneNumber = original.PhoneNumber;
            target.MailAddress = original.PhoneNumber;
            target.Age = original.Age;
            target.BankAccountNumber = original.BankAccountNumber;

            target.BankBranchDetails = original.BankBranchDetails.Clone();
            target.CollectionClearance = original.CollectionClearance;
            target.PaymentOwed = original.PaymentOwed;

            return target;
        }
        public static HostingUnit Clone(this HostingUnit original)
        {
            HostingUnit target = new BE.HostingUnit();
            target.HostingUnitKey = original.HostingUnitKey;
            target.Owner = original.Owner.Clone();
            target.area = original.area;
            target.type = original.type;
            target.Size = original.Size;
            target.Floors = original.Floors;
            target.pool = original.pool;
            target.jacuzzi = original.jacuzzi;
            target.wifi = original.wifi;
            target.tv = original.tv;
            target.garden = original.garden;
            target.childrensAttractions = original.childrensAttractions;
            target.publicTransportation = original.publicTransportation;
            target.view = original.view;
            target.smoking = original.smoking;
            target.roomService = original.roomService;
            target.snackBar = original.snackBar;
            target.HostingUnitName = original.HostingUnitName;
            for (int i = 0; i < 12; i++)
                for (int j = 0; j < 31; j++)
                    target.Diary[i, j] = original.Diary[i, j];
           // target.Diary = original.Diary;
            return target;
        }
        public static Order Clone(this Order original)
        {
            Order target = new BE.Order();
            target.HostingUnitKey = original.HostingUnitKey;
            target.GuestRequestKey = original.GuestRequestKey;
            target.OrderKey = original.OrderKey;
            target.Status = original.Status;
            target.CreateDate = original.CreateDate;
            target.OrderDate = original.OrderDate;

            return target;
        }
        public static GuestRequest Clone(this GuestRequest original)
        {
            GuestRequest target = new BE.GuestRequest();
            target.GuestRequestKey = original.GuestRequestKey;
            target.PrivateName = original.PrivateName;
            target.FamilyName = original.FamilyName;
            target.MailAddress = original.MailAddress;
            target.Status = original.Status;
            target.RegistrationDate = original.RegistrationDate;
            target.EntryDate = original.EntryDate;
            target.ReleaseDate = original.ReleaseDate;
            target.area = original.area;
            target.type = original.type;
            target.Adults = original.Adults;
            target.Children = original.Children;
            target.pool = original.pool;
            target.jacuzzi = original.jacuzzi;
            target.wifi = original.wifi;
            target.tv = original.tv;
            target.garden = original.garden;
            target.childrensAttractions = original.childrensAttractions;
            target.publicTransportation = original.publicTransportation;
            target.view = original.view;
            target.smoking = original.smoking;
            target.roomService = original.roomService;
            target.snackBar = original.snackBar;

            return target;
        }
    }
}
