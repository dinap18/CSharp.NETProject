using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;
namespace DS
{
   public static class DataSource
    {
            
           // public static DataSource GetDSObject { get => instanceOfDS; }
            public static List<BE.GuestRequest> guestRequests = new List<BE.GuestRequest>();
        public static List<BE.Order> orders = new List<BE.Order>();
        public static List<BE.HostingUnit>hostingUnits = new List<BE.HostingUnit>();
        public static List<BE.BankBranches> bankBranches = new List<BE.BankBranches>();
        //{

        //    BankBranches.BankName = "Romema",
        //        bankbranch1.BranchNumber = 5689,
        //        bankbranch1.BranchAddress = "Shamgar 21 ";
        //        bankBranches.Add(bankbranch1);


        //        BE.BankBranches bankbranch2 = new BE.BankBranches();
        //bankbranch2.BankName = "Haifa Bank";
        //        bankbranch2.BranchNumber = 5209;
        //        bankbranch2.BranchAddress = "Natanzon 26";
        //        bankBranches.Add(bankbranch2);


        //        BE.BankBranches bankbranch3 = new BE.BankBranches();
        //bankbranch3.BankName = "Bnei brak";
        //        bankbranch3.BranchNumber = 2369;
        //        bankbranch3.BranchAddress = "Hazon Ish 2";
        //        bankBranches.Add(bankbranch3);



        //        BE.BankBranches bankbranch4 = new BE.BankBranches();
        //bankbranch4.BankName = "BeerSheva";
        //        bankbranch4.BranchNumber = 4259;
        //        bankbranch4.BranchAddress = "90 Hadasa St";
        //        bankBranches.Add(bankbranch4);


        //        BE.BankBranches bankbranch5 = new BE.BankBranches();
        //bankbranch5.BankName = "Nazareth";
        //        bankbranch5.BranchNumber = 4589;
        //        bankbranch5.BranchAddress = "2 mar even amar st.";
        //        bankBranches.Add(bankbranch5);
        //};

        //    static DataSource()
        //        {
        //            guestRequests = new List<BE.GuestRequest>();
        //            hosts = new List<BE.Host>();
        //            orders = new List<BE.Order>();
        //            hostingUnits = new List<BE.HostingUnit>();
        //            bankBranches = new List<BE.BankBranches>();


        //            BE.GuestRequest guestRequest = new BE.GuestRequest();

        //            guestRequest.PrivateName = "Dina";
        //            guestRequest.FamilyName = "Pinchuck";
        //            guestRequest.MailAddress = "dina@gmail.com";
        //            guestRequest.Status=RequestStatus.closed_by_website;
        //            guestRequest.RegistrationDate = new DateTime(01/30/2019);
        //            guestRequest.EntryDate = new DateTime(01/20/2019);
        //            guestRequest.ReleaseDate = new DateTime(25/01/2019);
        //            guestRequest.area = Area.jerusalem;
        //            guestRequest.type =BE.Type.hotel ;
        //            guestRequest.Adults = 1;
        //            guestRequest.Children = 0;
        //            guestRequest.pool= Pool.yes;
        //            guestRequest.jacuzzi =Jacuzzi.yes ;
        //            guestRequest.wifi =Wifi.yes;
        //            guestRequest.tv = Television.doesnt_matter;
        //            guestRequest.garden = Garden.no;
        //            guestRequest.childrensAttractions = ChildrensAttractions.no;
        //            guestRequest.publicTransportation = PublicTransportation.doesnt_matter;
        //            guestRequest.view = View.yes;
        //            guestRequest.smoking = Smoking.no;
        //            guestRequest.roomService = RoomService.doesnt_matter;
        //            guestRequest.snackBar = SnackBar.yes;
        //            guestRequests.Add(guestRequest);

        //            BE.GuestRequest guestRequest2 = new BE.GuestRequest();

        //guestRequest2.PrivateName = "Eve";
        //        guestRequest2.FamilyName = "Bibas";
        //        guestRequest2.MailAddress = "eve@gmail.com";
        //        guestRequest2.Status = RequestStatus.active;
        //    guestRequest2.RegistrationDate = new DateTime(05/02/2020);
        //guestRequest2.EntryDate = new DateTime(09/02/2020);
        //guestRequest2.ReleaseDate = new DateTime(25/02/2020);
        //guestRequest2.area = Area.south;
        //    guestRequest2.type = BE.Type.apartment;
        //    guestRequest2.Adults = 2;
        //        guestRequest2.Children = 5;
        //    guestRequest2.pool = Pool.no;
        //    guestRequest2.jacuzzi =Jacuzzi.yes;
        //    guestRequest2.wifi = Wifi.yes;
        //    guestRequest2.tv =Television.doesnt_matter;
        //    guestRequest2.garden = Garden.yes;
        //    guestRequest2.childrensAttractions = ChildrensAttractions.no;
        //    guestRequest2.publicTransportation = PublicTransportation.yes;
        //    guestRequest2.view = View.yes;
        //    guestRequest2.smoking = Smoking.yes;
        //    guestRequest2.roomService = RoomService.yes;
        //    guestRequest2.snackBar = SnackBar.yes;
        //    guestRequests.Add(guestRequest2);

        //        BE.GuestRequest guestRequest3 = new BE.GuestRequest();

        //guestRequest.PrivateName = "Sarah";
        //        guestRequest.FamilyName = "Cohen";
        //        guestRequest.MailAddress = "scohen@gmail.com";
        //        guestRequest.Status = RequestStatus.active;
        //    guestRequest.RegistrationDate = new DateTime(17/03/2020);
        //guestRequest.EntryDate = new DateTime(20/03/2020);
        //guestRequest.ReleaseDate = new DateTime(29/03/2020);
        //guestRequest.area = Area.north;
        //    guestRequest.type = BE.Type.caravan;
        //    guestRequest.Adults = 7;
        //        guestRequest.Children = 0;
        //    guestRequest.pool = Pool.no;
        //    guestRequest.jacuzzi = Jacuzzi.no;
        //    guestRequest.wifi = Wifi.yes;
        //    guestRequest.tv = Television.yes;
        //    guestRequest.garden = Garden.doesnt_matter;
        //    guestRequest.childrensAttractions = ChildrensAttractions.no;
        //    guestRequest.publicTransportation = PublicTransportation.no;
        //    guestRequest.view = View.yes;
        //    guestRequest.smoking = Smoking.yes;
        //    guestRequest.roomService = RoomService.doesnt_matter;
        //    guestRequest.snackBar = SnackBar.yes;

        //        guestRequests.Add(guestRequest3);


        //BE.Host myhost = new BE.Host();
        //myhost.HostKey = 3255289;
        //            myhost.PrivateName = "Leah";
        //            myhost.FamilyName = "Levy";
        //            myhost.PhoneNumber = "0589865896";
        //            myhost.MailAddress = "leahlv55@gmail.com";
        //            myhost.Age = 29;
        //            myhost.BankBranchDetails.BankNumber = 895987;
        //            myhost.BankBranchDetails.BankName = "Hapoalim";
        //            myhost.BankBranchDetails.BranchNumber = 897;
        //            myhost.BankBranchDetails.BranchAddress = "Kanfey Necharim 5";
        //            myhost.BankBranchDetails.BranchCity = Area.jerusalem;
        //            myhost.BankAccountNumber = 823700207;
        //            myhost.CollectionClearance = "yes";
        //            hosts.Add(myhost);

        //            BE.Host myhost1 = new BE.Host();
        //            myhost1.HostKey = 3255289;
        //            myhost1.PrivateName = "Yaakov";
        //            myhost1.FamilyName = "Amselem";
        //            myhost1.PhoneNumber = " 0589658884";
        //            myhost1.MailAddress = "yams@gmail.com";
        //            myhost1.Age = 58;
        //            myhost1.BankBranchDetails.BankNumber = 893047;
        //            myhost1.BankBranchDetails.BankName = "Doar";
        //            myhost1.BankBranchDetails.BranchNumber = 522;
        //            myhost1.BankBranchDetails.BranchAddress = "Ouziel 75";
        //            myhost1.BankBranchDetails.BranchCity = Area.tel_aviv;
        //            myhost1.BankAccountNumber = 454555210;
        //            myhost1.CollectionClearance = "no";
        //            hosts.Add(myhost1);


        //            BE.Host myhost2 = new BE.Host();
        //            myhost2.HostKey = 589666;
        //            myhost2.PrivateName = "Israel";
        //            myhost2.FamilyName = "Fhima";
        //            myhost2.PhoneNumber = " 0525658995";
        //            myhost2.MailAddress = "israelf@gmail.com";
        //            myhost2.Age = 62;
        //            myhost2.BankBranchDetails.BankNumber = 549440;
        //            myhost2.BankBranchDetails.BankName = "Leumi";
        //            myhost2.BankBranchDetails.BranchNumber = 401;
        //            myhost2.BankBranchDetails.BranchAddress = "Ben Yeuda 105";
        //            myhost2.BankBranchDetails.BranchCity = Area.south;
        //            myhost2.BankAccountNumber = 48450237;
        //            myhost2.CollectionClearance = "yes";
        //            hosts.Add(myhost2);





        //        BE.HostingUnit myhostingUnit1 = new BE.HostingUnit();

        //        myhostingUnit1.Owner = myhost;
        //            myhostingUnit1.area = Area.south;
        //            myhostingUnit1.type = BE.Type.apartment;
        //            myhostingUnit1.Size = 45;
        //            myhostingUnit1.Floors = 1;
        //            myhostingUnit1.pool = Pool.yes;
        //            myhostingUnit1.jacuzzi = Jacuzzi.no;
        //            myhostingUnit1.wifi = Wifi.yes;
        //            myhostingUnit1.tv = Television.yes;
        //            myhostingUnit1.garden = Garden.yes;
        //            myhostingUnit1.childrensAttractions = ChildrensAttractions.yes;
        //            myhostingUnit1.publicTransportation = PublicTransportation.yes;
        //            myhostingUnit1.view = View.no;
        //            myhostingUnit1.smoking = Smoking.no;
        //            myhostingUnit1.roomService = RoomService.yes;
        //            myhostingUnit1.snackBar = SnackBar.doesnt_matter;
        //            myhostingUnit1.HostingUnitName = "BestAppartment";
        //                bool[,] Diary3 = new bool[12, 31];
        //                for (int i = 8; i< 10; i++)
        //                    for (int j = 8; j< 31; j++)
        //                    {
        //                        Diary3[i, j] = true;
        //                    }
        //    hostingUnits.Add(myhostingUnit1);



        //                BE.HostingUnit myhostingUnit2 = new BE.HostingUnit();

        //    myhostingUnit2.Owner = myhost;
        //            myhostingUnit2.area = Area.tel_aviv;
        //            myhostingUnit2.type = BE.Type.caravan;
        //            myhostingUnit2.Size = 95;
        //                myhostingUnit2.Floors = 2;
        //            myhostingUnit2.pool = Pool.yes;
        //            myhostingUnit2.jacuzzi = Jacuzzi.no;
        //            myhostingUnit2.wifi = Wifi.yes;
        //            myhostingUnit2.tv = Television.yes;
        //            myhostingUnit2.garden = Garden.no;
        //            myhostingUnit2.childrensAttractions = ChildrensAttractions.no;
        //            myhostingUnit2.publicTransportation = PublicTransportation.yes;
        //            myhostingUnit2.view = View.no;
        //            myhostingUnit2.smoking = Smoking.no;
        //            myhostingUnit2.roomService = RoomService.no;
        //            myhostingUnit2.snackBar = SnackBar.no;
        //            myhostingUnit2.HostingUnitName = "CaravanTLV";
        //                bool[,] Diary4 = new bool[12, 31];
        //                for (int i = 4; i< 8; i++)
        //                    for (int j = 5; j< 24; j++)
        //                    {
        //                        Diary4[i, j] = true;
        //                    }
        //hostingUnits.Add(myhostingUnit2);




        //                BE.HostingUnit myhostingUnit3 = new BE.HostingUnit();

        //myhostingUnit3.Owner = myhost;
        //            myhostingUnit3.area =Area.galil;
        //            myhostingUnit3.type = BE.Type.treehouse;
        //            myhostingUnit3.Size = 205;
        //                myhostingUnit3.Floors = 3;
        //            myhostingUnit3.pool = Pool.yes;
        //            myhostingUnit3.jacuzzi = Jacuzzi.yes;
        //            myhostingUnit3.wifi = Wifi.no;
        //            myhostingUnit3.tv = Television.yes;
        //            myhostingUnit3.garden = Garden.yes;
        //            myhostingUnit3.childrensAttractions = ChildrensAttractions.yes;
        //            myhostingUnit3.publicTransportation = PublicTransportation.no;
        //            myhostingUnit3.view = View.yes;
        //            myhostingUnit3.smoking =Smoking.yes;
        //            myhostingUnit3.roomService = RoomService.no;
        //            myhostingUnit3.snackBar = SnackBar.no;
        //            myhostingUnit3.HostingUnitName = "TreeHouseCenter";
        //            bool[,] Diary5 = new bool[12, 31];
        //                for (int i = 10; i< 11; i++)
        //                    for (int j = 0; j< 14; j++)
        //                    {
        //                        Diary5[i, j] = true;
        //                    }

        //                hostingUnits.Add(myhostingUnit3);



        //BE.BankBranches bankbranch1 = new BE.BankBranches();
        //bankbranch1.BankName = "Romema";
        //        bankbranch1.BranchNumber = 5689;
        //        bankbranch1.BranchAddress = "Shamgar 21 ";
        //        bankBranches.Add(bankbranch1);


        //        BE.BankBranches bankbranch2 = new BE.BankBranches();
        //bankbranch2.BankName = "Haifa Bank";
        //        bankbranch2.BranchNumber = 5209;
        //        bankbranch2.BranchAddress = "Natanzon 26";
        //        bankBranches.Add(bankbranch2);


        //        BE.BankBranches bankbranch3 = new BE.BankBranches();
        //bankbranch3.BankName = "Bnei brak";
        //        bankbranch3.BranchNumber = 2369;
        //        bankbranch3.BranchAddress = "Hazon Ish 2";
        //        bankBranches.Add(bankbranch3);



        //        BE.BankBranches bankbranch4 = new BE.BankBranches();
        //bankbranch4.BankName = "BeerSheva";
        //        bankbranch4.BranchNumber = 4259;
        //        bankbranch4.BranchAddress = "90 Hadasa St";
        //        bankBranches.Add(bankbranch4);


        //        BE.BankBranches bankbranch5 = new BE.BankBranches();
        //bankbranch5.BankName = "Nazareth";
        //        bankbranch5.BranchNumber = 4589;
        //        bankbranch5.BranchAddress = "2 mar even amar st.";
        //        bankBranches.Add(bankbranch5);




    //        }


       }
    }
