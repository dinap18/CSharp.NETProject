using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BL;
using BE;
using System.IO;
//Dina Pinchuck 337593958 Eve Bibas
namespace PL
{
    class Program
    {
        static void Main(string[] args)
        {
            IBL blAccess;
            blAccess = FactoryBL.GetBL();
            
            foreach (var bank in blAccess.GetBranches())
               
             Console.WriteLine(bank);
            //   #region adding guest requests
            //   BE.GuestRequest guestRequest = new BE.GuestRequest();

            //   guestRequest.PrivateName = "Dina";
            //   guestRequest.FamilyName = "Pinchuck";
            //   guestRequest.MailAddress = "dina@gmail.com";
            //  // guestRequest.RegistrationDate = new DateTime(2019, 03, 08);
            //   guestRequest.EntryDate = new DateTime(2020, 03, 28);
            //   guestRequest.ReleaseDate = new DateTime(2020, 04, 08);
            //   guestRequest.area = Area.jerusalem;
            //   guestRequest.type = BE.Type.hotel;
            //   guestRequest.Adults = 1;
            //   guestRequest.Children = 0;
            //   guestRequest.pool = Pool.yes;
            //   guestRequest.jacuzzi = Jacuzzi.yes;
            //   guestRequest.wifi = Wifi.yes;
            //   guestRequest.tv = Television.doesnt_matter;
            //   guestRequest.garden = Garden.no;
            //   guestRequest.childrensAttractions = ChildrensAttractions.no;
            //   guestRequest.publicTransportation = PublicTransportation.doesnt_matter;
            //   guestRequest.view = View.yes;
            //   guestRequest.smoking = Smoking.no;
            //   guestRequest.roomService = RoomService.doesnt_matter;
            //   guestRequest.snackBar = SnackBar.yes;

            //   try
            //   {
            //       blAccess.AddGuestRequest(guestRequest);
            //   }
            //   catch (Exception e)
            //   {
            //       Console.WriteLine(e);
            //   }

            //   BE.GuestRequest guestRequest2 = new BE.GuestRequest();
            //   guestRequest2.PrivateName = "Eve";
            //   guestRequest2.FamilyName = "Bibas";
            //   guestRequest2.MailAddress = "eve@gmail.com";
            ////   guestRequest2.RegistrationDate = new DateTime(2019, 04, 08);
            //   guestRequest2.EntryDate = new DateTime(2020, 05, 08);
            //   guestRequest2.ReleaseDate = new DateTime(2020, 05, 18);
            //   guestRequest2.area = Area.south;
            //   guestRequest2.type = BE.Type.apartment;
            //   guestRequest2.Adults = 2;
            //   guestRequest2.Children = 5;
            //   guestRequest2.pool = Pool.no;
            //   guestRequest2.jacuzzi = Jacuzzi.yes;
            //   guestRequest2.wifi = Wifi.yes;
            //   guestRequest2.tv = Television.doesnt_matter;
            //   guestRequest2.garden = Garden.yes;
            //   guestRequest2.childrensAttractions = ChildrensAttractions.no;
            //   guestRequest2.publicTransportation = PublicTransportation.yes;
            //   guestRequest2.view = View.yes;
            //   guestRequest2.smoking = Smoking.yes;
            //   guestRequest2.roomService = RoomService.yes;
            //   guestRequest2.snackBar = SnackBar.yes;
            //   try
            //   {
            //       blAccess.AddGuestRequest(guestRequest2);
            //   }
            //   catch (Exception e)
            //   {
            //       Console.WriteLine(e);
            //   }

            //   BE.GuestRequest guestRequest3 = new BE.GuestRequest();

            //   guestRequest3.PrivateName = "Sarah";
            //   guestRequest3.FamilyName = "Cohen";
            //   guestRequest3.MailAddress = "scohen@gmail.com";
            //  // guestRequest3.RegistrationDate = new DateTime(2019, 01, 01);
            //   guestRequest3.EntryDate = new DateTime(2020   , 02, 02);
            //   guestRequest3.ReleaseDate = new DateTime(2020, 02, 08);
            //   guestRequest3.area = Area.north;
            //   guestRequest3.type = BE.Type.caravan;
            //   guestRequest3.Adults = 7;
            //   guestRequest3.Children = 0;
            //   guestRequest3.pool = Pool.no;
            //   guestRequest3.jacuzzi = Jacuzzi.no;
            //   guestRequest3.wifi = Wifi.yes;
            //   guestRequest3.tv = Television.yes;
            //   guestRequest3.garden = Garden.doesnt_matter;
            //   guestRequest3.childrensAttractions = ChildrensAttractions.no;
            //   guestRequest3.publicTransportation = PublicTransportation.no;
            //   guestRequest3.view = View.yes;
            //   guestRequest3.smoking = Smoking.yes;
            //   guestRequest3.roomService = RoomService.doesnt_matter;
            //   guestRequest3.snackBar = SnackBar.yes;
            //   try
            //   {
            //       blAccess.AddGuestRequest(guestRequest3);
            //   }
            //   catch (Exception e)
            //   {
            //       Console.WriteLine(e);
            //   }


            //   foreach (var guest in blAccess.GetGuestList())
            //   {
            //       Console.WriteLine(guest);
            //   }
            //   #endregion
            //   try
            //   {
            //       blAccess.UpdateGuestFamilyName(guestRequest, "abcd");

            //   }
            //   catch (Exception e)
            //   {
            //       Console.WriteLine(e);
            //   }
            //   #region add banks
            //   BE.BankBranches bankbranch1 = new BE.BankBranches();
            //   bankbranch1.BankName = "Romema";
            //   bankbranch1.BranchNumber = 5689;
            //   bankbranch1.BranchAddress = "Shamgar 21 ";
            //   bankbranch1.BranchCity = "jerusalem";
            //   bankbranch1.BankNumber = 1;



            //   BE.BankBranches bankbranch2 = new BE.BankBranches();
            //   bankbranch2.BankName = "Haifa Bank";
            //   bankbranch2.BranchNumber = 5209;
            //   bankbranch2.BranchAddress = "Natanzon 26";
            //   bankbranch2.BranchCity ="north";
            //   bankbranch2.BankNumber = 2;


            //   BE.BankBranches bankbranch3 = new BE.BankBranches();
            //   bankbranch3.BankName = "Bnei brak";
            //   bankbranch3.BranchNumber = 2369;
            //   bankbranch3.BranchAddress = "Hazon Ish 2";
            //   bankbranch3.BranchCity = "center";
            //   bankbranch3.BankNumber = 3;



            //   BE.BankBranches bankbranch4 = new BE.BankBranches();
            //   bankbranch4.BankName = "BeerSheva";
            //   bankbranch4.BranchNumber = 4259;
            //   bankbranch4.BranchAddress = "90 Hadasa St";
            //   bankbranch4.BranchCity = "south";
            //   bankbranch4.BankNumber = 4;


            //   BE.BankBranches bankbranch5 = new BE.BankBranches();
            //   bankbranch5.BankName = "Nazareth";
            //   bankbranch5.BranchNumber = 4589;
            //   bankbranch5.BranchAddress = "2 mar even amar st.";
            //   bankbranch5.BranchCity = "north";
            //   bankbranch5.BankNumber = 5;
            //   #endregion
            //   try
            //   {
            //       //blAccess.AddBankBranch(bankbranch5);
            //       //blAccess.AddBankBranch(bankbranch1);
            //       //blAccess.AddBankBranch(bankbranch2);
            //       //blAccess.AddBankBranch(bankbranch3);
            //       //blAccess.AddBankBranch(bankbranch4);

            //   }

            //   catch (Exception e)
            //   {
            //       Console.WriteLine(e);
            //   }
            //   foreach (var bank in blAccess.GetBranches())
            //   {
            //       Console.WriteLine(bank);
            //   }

            #region add hosting units
            BE.HostingUnit myhostingUnit1 = new BE.HostingUnit();

            myhostingUnit1.Owner = new BE.Host()

            {
                HostKey = 3255289,
                PrivateName = "Leah",
                FamilyName = "Levy",
                PhoneNumber = "0589865896",
                MailAddress = "leahlv55@gmail.com",
                Age = 29,
                //BankBranchDetails = new BE.BankBranches()
                //{
                //    BankNumber = 895987,
                //    BankName = "Hapoalim",
                //    BranchNumber = 897,
                //    BranchAddress = "Kanfey Necharim 5",
                //    BranchCity = "jerusalem",
                //},
                BankAccountNumber = 823700207,
                CollectionClearance = PaymentClearance.yes,
            };
            myhostingUnit1.area = Area.south;
            myhostingUnit1.type = BE.Type.apartment;
            myhostingUnit1.Size = 45;
            myhostingUnit1.Floors = 1;
            myhostingUnit1.pool = Pool.yes;
            myhostingUnit1.jacuzzi = Jacuzzi.no;
            myhostingUnit1.wifi = Wifi.yes;
            myhostingUnit1.tv = Television.yes;
            myhostingUnit1.garden = Garden.yes;
            myhostingUnit1.childrensAttractions = ChildrensAttractions.yes;
            myhostingUnit1.publicTransportation = PublicTransportation.yes;
            myhostingUnit1.view = View.no;
            myhostingUnit1.smoking = Smoking.no;
            myhostingUnit1.roomService = RoomService.yes;
            myhostingUnit1.snackBar = SnackBar.doesnt_matter;
            myhostingUnit1.HostingUnitName = "BestAppartment";
            bool[,] Diary1 = new bool[12, 31];

            try
            {
                blAccess.AddHostingUnit(myhostingUnit1);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }


            BE.HostingUnit myhostingUnit2 = new BE.HostingUnit();
            myhostingUnit2.HostingUnitKey = 2;
            myhostingUnit2.Owner = new BE.Host()

            {
                HostKey = 3256685,
                PrivateName = "Yaakov",
                FamilyName = "Amselem",
                PhoneNumber = " 0589658884",
                MailAddress = "yams@gmail.com",
                Age = 58,
                BankBranchDetails = new BE.BankBranches()
                {
                    BankNumber = 893047,
                    BankName = "Doar",
                    BranchNumber = 522,
                    BranchAddress = "Ouziel 75",
                    BranchCity = "tel_aviv",
                },
                BankAccountNumber = 454555210,
                CollectionClearance = PaymentClearance.yes,
            };
            myhostingUnit2.area = Area.tel_aviv;
            myhostingUnit2.type = BE.Type.caravan;
            myhostingUnit2.Size = 95;
            myhostingUnit2.Floors = 2;
            myhostingUnit2.pool = Pool.yes;
            myhostingUnit2.jacuzzi = Jacuzzi.yes;
            myhostingUnit2.wifi = Wifi.yes;
            myhostingUnit2.tv = Television.yes;
            myhostingUnit2.garden = Garden.no;
            myhostingUnit2.childrensAttractions = ChildrensAttractions.no;
            myhostingUnit2.publicTransportation = PublicTransportation.yes;
            myhostingUnit2.view = View.no;
            myhostingUnit2.smoking = Smoking.no;
            myhostingUnit2.roomService = RoomService.no;
            myhostingUnit2.snackBar = SnackBar.no;
            myhostingUnit2.HostingUnitName = "CaravanTLV";
            bool[,] Diary2 = new bool[12, 31];

            try
            {
                blAccess.AddHostingUnit(myhostingUnit2);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

            BE.HostingUnit myhostingUnit3 = new BE.HostingUnit();
            myhostingUnit3.HostingUnitKey = 3;
            myhostingUnit3.Owner = new BE.Host()

            {
                HostKey = 3255289,
                PrivateName = "Leah",
                FamilyName = "Levy",
                PhoneNumber = "0589865896",
                MailAddress = "leahlv55@gmail.com",
                Age = 29,
                BankBranchDetails = new BE.BankBranches()
                {
                    BankNumber = 895987,
                    BankName = "Hapoalim",
                    BranchNumber = 897,
                    BranchAddress = "Kanfey Necharim 5",
                    BranchCity ="jerusalem",
                },
                BankAccountNumber = 823700207,
                CollectionClearance = PaymentClearance.yes,
            };
            myhostingUnit3.area = Area.galil;
            myhostingUnit3.type = BE.Type.treehouse;
            myhostingUnit3.Size = 205;
            myhostingUnit3.Floors = 3;
            myhostingUnit3.pool = Pool.yes;
            myhostingUnit3.jacuzzi = Jacuzzi.yes;
            myhostingUnit3.wifi = Wifi.no;
            myhostingUnit3.tv = Television.yes;
            myhostingUnit3.garden = Garden.yes;
            myhostingUnit3.childrensAttractions = ChildrensAttractions.yes;
            myhostingUnit3.publicTransportation = PublicTransportation.no;
            myhostingUnit3.view = View.yes;
            myhostingUnit3.smoking = Smoking.yes;
            myhostingUnit3.roomService = RoomService.no;
            myhostingUnit3.snackBar = SnackBar.no;
            myhostingUnit3.HostingUnitName = "TreeHouseCenter";
            bool[,] Diary3 = new bool[12, 31];


            try
            {
                blAccess.AddHostingUnit(myhostingUnit3);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            #endregion
            foreach (var unit in blAccess.GetHostingUnitList())
            {
                Console.WriteLine(unit);
            }
            try
            {
                myhostingUnit3.view = View.doesnt_matter;
                blAccess.UpdateHostingUnit(myhostingUnit3);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            try
            {
                blAccess.DeleteHostingUnit(myhostingUnit3);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            foreach (var unit in blAccess.GetHostingUnitList())
            {
                Console.WriteLine(unit);
            }

            #region add and update orders



            try
            {
                //blAccess.AddOrder(guestRequest.GuestRequestKey, myhostingUnit1.HostingUnitKey);
                //blAccess.AddOrder(guestRequest.GuestRequestKey, myhostingUnit2.HostingUnitKey);
                //blAccess.AddOrder(guestRequest2.GuestRequestKey, myhostingUnit1.HostingUnitKey);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            try
            {
                foreach (var order in blAccess.GetOrderList())
                {
               //     blAccess.UpdateOrderStatus(order, OrderStatus.email_sent);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            //try
            //{
            //    foreach (var order in blAccess.GetOrderList())
            //    {
            //        blAccess.UpdateOrderStatus(order, OrderStatus.customer_canceled);
            //    }
            //}
            //catch (InvalidOperationException e)
            //{
            //    Console.WriteLine(e);
            //}
            try
            {
                foreach (var order in blAccess.GetOrderList())
                {
                //    blAccess.UpdateOrderStatus(order, OrderStatus.customer_accepted);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            try
            {
                foreach (var order in blAccess.GetOrderList())
                    Console.WriteLine("ORDER: " + order);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

            #endregion


            try
            {
                foreach (var order in blAccess.OpenOrders(40))
                    Console.WriteLine(order);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }


            //try
            //{
            //    Console.WriteLine("number of guest orders: " + blAccess.NumberOfGuestOrders(guestRequest));
            //}
            //catch (Exception e)
            //{
            //    Console.WriteLine(e);
            //}


            try
            {
                Console.WriteLine("number of orders that unit has: " + blAccess.NumberOfUnitOrders(myhostingUnit1));
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

            try
            {
                Console.WriteLine("number of successful orders that unit has: " + blAccess.NumberOfSuccessfullOrders(myhostingUnit2));

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }




            try
            {
                foreach (var unit in blAccess.GetHostingUnitList())
                {
                    blAccess.UpdateHostFamilyName(unit.Owner, "abc");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }





            try
            {
                foreach (var unit in blAccess.GetAvailableUnits(new DateTime(2019, 5, 3), 20))
                {
                    Console.WriteLine("unit is available:" + unit);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            Console.WriteLine("tests of get days function");
            Console.WriteLine(blAccess.GetDays(new DateTime(2020, 8, 2), new DateTime(2020, 1, 5)));

            Console.WriteLine(blAccess.GetDays(new DateTime(2020, 1, 2)));



            try
            {
                foreach (var unit in blAccess.GetUnitsInTelAvivWithPoolAndJacuzzi())
                    Console.WriteLine("unit in tel aviv with pool and jacuzzi: " + unit);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }


            try
            {
                foreach (var guest in blAccess.GetGuestsWithChildrenAndWantToSmoke())
                    Console.WriteLine("wants to smoke and has kids: " + guest);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

            try
            {
                foreach (var host in blAccess.GetHostingUnitList())
                    Console.WriteLine(blAccess.NumberOfSuccessfullOrders(host));
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }


            try
            {
                foreach (var bank in blAccess.GetBankInJerusalem())
                    Console.WriteLine("Bank in jerusalem:" + bank);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            #region Grouping Tests
            try
            {
                foreach (var unit in blAccess.GetGroupedByUnitPopularity())
                {
                    Console.WriteLine("Units grouped by popularity:");
                    foreach (var item in unit)
                    {
                        Console.WriteLine($"\t{item}");
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            try
            {
                foreach (var unit in blAccess.GetGroupedByNoTelevisionAndWifi())
                {
                    Console.WriteLine("Units grouped by having wifi and tv:");
                    foreach (var item in unit)
                    {
                        Console.WriteLine($"\t{item}");
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            try
            {
                foreach (var bank in blAccess.GetGroupedByBankName())
                {
                    Console.WriteLine("Banks grouped by their names:");
                    foreach (var item in bank)
                    {
                        Console.WriteLine($"\t{item}");
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            try
            {
                foreach (var unit in blAccess.GetGroupedByUnitArea())
                {
                    Console.WriteLine("groups units by their area:");
                    foreach (var item in unit)
                    {
                        Console.WriteLine($"\t{item}");
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            try
            {
                foreach (var unit in blAccess.GetGroupedByNumberOfUnits())
                {
                    Console.WriteLine("groups units by their host:");
                    foreach (var item in unit)
                    {
                        Console.WriteLine($"\t{item}");
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

            try
            {
                foreach (var guest in blAccess.GetGroupedByNumberOfVacations())
                {
                    Console.WriteLine("groups guests by their vacations:");
                    foreach (var item in guest)
                    {
                        Console.WriteLine($"\t{item}");
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            #endregion
            Console.ReadKey();
        }
    }
}
/* guest added successfully
 guest added successfully
 guest added successfully
request key: 10000000 Last Name: Pinchuck First Name: Dina Email Address: dina@gmail.com Status:active Registration Date 3/8/2019 12:00:00 AM Entry Date: 3/28/2019 12:00:00 AM Release Date: 4/8/2019 12:00:00 AM Area: jerusalem Type: hotel Number of Adults: 1 Number of Children: 0 Pool: yes Jaccuzi: yes Wifi: yes Tv: doesnt_matter Garden: no Children's Attractions: no Public Transportation: doesnt_matter View: yes Smoking: no Room Service:  Snack Bar: yes
request key: 10000001 Last Name: Bibas First Name: Eve Email Address: eve@gmail.com Status:active Registration Date 4/8/2019 12:00:00 AM Entry Date: 5/8/2019 12:00:00 AM Release Date: 5/18/2019 12:00:00 AM Area: south Type: apartment Number of Adults: 2 Number of Children: 5 Pool: no Jaccuzi: yes Wifi: yes Tv: doesnt_matter Garden: yes Children's Attractions: no Public Transportation: yes View: yes Smoking: yes Room Service:  Snack Bar: yes
request key: 10000002 Last Name: Cohen First Name: Sarah Email Address: scohen@gmail.com Status:active Registration Date 1/1/2019 12:00:00 AM Entry Date: 2/2/2019 12:00:00 AM Release Date: 2/8/2019 12:00:00 AM Area: north Type: caravan Number of Adults: 7 Number of Children: 0 Pool: no Jaccuzi: no Wifi: yes Tv: yes Garden: doesnt_matter Children's Attractions: no Public Transportation: no View: yes Smoking: yes Room Service:  Snack Bar: yes
request updated successfully
bank added successfully
bank added successfully
bank added successfully
bank added successfully
bank added successfully
Bank Number : 1 Bank Name: Romema Branch Number: 5689 Branch Address: Shamgar 21  Branch City: jerusalem
Bank Number : 2 Bank Name: Haifa Bank Branch Number: 5209 Branch Address: Natanzon 26 Branch City: north
Bank Number : 3 Bank Name: Bnei brak Branch Number: 2369 Branch Address: Hazon Ish 2 Branch City: center
Bank Number : 4 Bank Name: BeerSheva Branch Number: 4259 Branch Address: 90 Hadasa St Branch City: south
Bank Number : 5 Bank Name: Nazareth Branch Number: 4589 Branch Address: 2 mar even amar st. Branch City: north
hosting unit added successfully
hosting unit added successfully
hosting unit added successfully
Hosting Unit Key: 20000000 Hosting Unit Name: BestAppartment Owner: Host Key: 3255289 First Name: Leah Last Name: Levy Phone Number: 0589865896 Email Address: 0589865896 Age: 29 Bank Branch Details: Bank Number : 895987 Bank Name: Hapoalim Branch Number: 897 Branch Address: Kanfey Necharim 5 Branch City: jerusalem  Bank Account Number 823700207 Collection Clearance: yes Payment Owed: 0 shekel Area: south Type: apartment Size: 45 Floors: 1 Pool: yes Jacuzzi: no Wifi: yes Tv: yes Garden: yes Children's Attractions: yes Public Transportation: yes View: no Smoking: no Room Service:  Snack Bar: doesnt_matter
Hosting Unit Key: 20000001 Hosting Unit Name: CaravanTLV Owner: Host Key: 3256685 First Name: Yaakov Last Name: Amselem Phone Number:  0589658884 Email Address:  0589658884 Age: 58 Bank Branch Details: Bank Number : 893047 Bank Name: Doar Branch Number: 522 Branch Address: Ouziel 75 Branch City: tel_aviv  Bank Account Number 454555210 Collection Clearance: yes Payment Owed: 0 shekel Area: tel_aviv Type: caravan Size: 95 Floors: 2 Pool: yes Jacuzzi: yes Wifi: yes Tv: yes Garden: no Children's Attractions: no Public Transportation: yes View: no Smoking: no Room Service:  Snack Bar: no
Hosting Unit Key: 20000002 Hosting Unit Name: TreeHouseCenter Owner: Host Key: 3255289 First Name: Leah Last Name: Levy Phone Number: 0589865896 Email Address: 0589865896 Age: 29 Bank Branch Details: Bank Number : 895987 Bank Name: Hapoalim Branch Number: 897 Branch Address: Kanfey Necharim 5 Branch City: jerusalem  Bank Account Number 823700207 Collection Clearance: yes Payment Owed: 0 shekel Area: galil Type: treehouse Size: 205 Floors: 3 Pool: yes Jacuzzi: yes Wifi: no Tv: yes Garden: yes Children's Attractions: yes Public Transportation: no View: yes Smoking: yes Room Service:  Snack Bar: no
System.InvalidOperationException: cannot change this information
   at BL.IBLDefinitions.UpdateHostingUnit(HostingUnit unit) in C:\Users\dp18\Downloads\LOOKATTHIS\BL\IBLDefinitions.cs:line 181
   at PL.Program.Main(String[] args) in C:\Users\dp18\Downloads\LOOKATTHIS\PL\Program.cs:line 348
unit deleted successfully
Hosting Unit Key: 20000000 Hosting Unit Name: BestAppartment Owner: Host Key: 3255289 First Name: Leah Last Name: Levy Phone Number: 0589865896 Email Address: 0589865896 Age: 29 Bank Branch Details: Bank Number : 895987 Bank Name: Hapoalim Branch Number: 897 Branch Address: Kanfey Necharim 5 Branch City: jerusalem  Bank Account Number 823700207 Collection Clearance: yes Payment Owed: 0 shekel Area: south Type: apartment Size: 45 Floors: 1 Pool: yes Jacuzzi: no Wifi: yes Tv: yes Garden: yes Children's Attractions: yes Public Transportation: yes View: no Smoking: no Room Service:  Snack Bar: doesnt_matter
Hosting Unit Key: 20000001 Hosting Unit Name: CaravanTLV Owner: Host Key: 3256685 First Name: Yaakov Last Name: Amselem Phone Number:  0589658884 Email Address:  0589658884 Age: 58 Bank Branch Details: Bank Number : 893047 Bank Name: Doar Branch Number: 522 Branch Address: Ouziel 75 Branch City: tel_aviv  Bank Account Number 454555210 Collection Clearance: yes Payment Owed: 0 shekel Area: tel_aviv Type: caravan Size: 95 Floors: 2 Pool: yes Jacuzzi: yes Wifi: yes Tv: yes Garden: no Children's Attractions: no Public Transportation: yes View: no Smoking: no Room Service:  Snack Bar: no
order added successfully
order added successfully
order added successfully
Email sent
order updated successfully
Email sent
order updated successfully
Email sent
order updated successfully
order updated successfully
order updated successfully
order updated successfully
request updated successfully
System.DuplicateWaitObjectException: Duplicate objects in argument.
Parameter name: Dates are already taken
   at BL.IBLDefinitions.UpdateOrderStatus(Order order, OrderStatus status) in C:\Users\dp18\Downloads\LOOKATTHIS\BL\IBLDefinitions.cs:line 333
   at PL.Program.Main(String[] args) in C:\Users\dp18\Downloads\LOOKATTHIS\PL\Program.cs:line 407
ORDER:  Order Key: 30000000Hosting Unit Key: 20000000 Guest Request Key: 10000000 Order Status: customer_accepted Create Date: 12/31/2019 2:08:34 PM Order Date: 12/31/2019 2:08:34 PM
ORDER:  Order Key: 30000001Hosting Unit Key: 20000001 Guest Request Key: 10000000 Order Status: customer_accepted Create Date: 12/31/2019 2:08:34 PM Order Date: 12/31/2019 2:08:34 PM
ORDER:  Order Key: 30000002Hosting Unit Key: 20000000 Guest Request Key: 10000001 Order Status: customer_canceled Create Date: 12/31/2019 2:08:34 PM Order Date: 12/31/2019 2:08:34 PM
number of guest orders: 2
number of orders that unit has: 2
number of successful orders that unit has: 1
hosting unit updated successfully
hosting unit updated successfully
tests of get days function
210
1
unit in tel aviv with pool and jacuzzi: Hosting Unit Key: 20000001 Hosting Unit Name: CaravanTLV Owner: Host Key: 3256685 First Name: Yaakov Last Name: abc Phone Number:  0589658884 Email Address:  0589658884 Age: 58 Bank Branch Details: Bank Number : 893047 Bank Name: Doar Branch Number: 522 Branch Address: Ouziel 75 Branch City: tel_aviv  Bank Account Number 454555210 Collection Clearance: yes Payment Owed: 0 shekel Area: tel_aviv Type: caravan Size: 95 Floors: 2 Pool: yes Jacuzzi: yes Wifi: yes Tv: yes Garden: no Children's Attractions: no Public Transportation: yes View: no Smoking: no Room Service:  Snack Bar: no
wants to smoke and has kids: request key: 10000001 Last Name: Bibas First Name: Eve Email Address: eve@gmail.com Status:closed_by_website Registration Date 4/8/2019 12:00:00 AM Entry Date: 5/8/2019 12:00:00 AM Release Date: 5/18/2019 12:00:00 AM Area: south Type: apartment Number of Adults: 2 Number of Children: 5 Pool: no Jaccuzi: yes Wifi: yes Tv: doesnt_matter Garden: yes Children's Attractions: no Public Transportation: yes View: yes Smoking: yes Room Service:  Snack Bar: yes
1
1
Bank in jerusalem:Bank Number : 1 Bank Name: Romema Branch Number: 5689 Branch Address: Shamgar 21  Branch City: jerusalem
Units grouped by popularity:
         Order Key: 30000000Hosting Unit Key: 20000000 Guest Request Key: 10000000 Order Status: customer_accepted Create Date: 12/31/2019 2:08:34 PM Order Date: 12/31/2019 2:08:34 PM
         Order Key: 30000002Hosting Unit Key: 20000000 Guest Request Key: 10000001 Order Status: customer_canceled Create Date: 12/31/2019 2:08:34 PM Order Date: 12/31/2019 2:08:34 PM
Units grouped by popularity:
         Order Key: 30000001Hosting Unit Key: 20000001 Guest Request Key: 10000000 Order Status: customer_accepted Create Date: 12/31/2019 2:08:34 PM Order Date: 12/31/2019 2:08:34 PM
Units grouped by having wifi and tv:
        Hosting Unit Key: 20000000 Hosting Unit Name: BestAppartment Owner: Host Key: 3255289 First Name: Leah Last Name: abc Phone Number: 0589865896 Email Address: 0589865896 Age: 29 Bank Branch Details: Bank Number : 895987 Bank Name: Hapoalim Branch Number: 897 Branch Address: Kanfey Necharim 5 Branch City: jerusalem  Bank Account Number 823700207 Collection Clearance: yes Payment Owed: 0 shekel Area: south Type: apartment Size: 45 Floors: 1 Pool: yes Jacuzzi: no Wifi: yes Tv: yes Garden: yes Children's Attractions: yes Public Transportation: yes View: no Smoking: no Room Service:  Snack Bar: doesnt_matter
        Hosting Unit Key: 20000001 Hosting Unit Name: CaravanTLV Owner: Host Key: 3256685 First Name: Yaakov Last Name: abc Phone Number:  0589658884 Email Address:  0589658884 Age: 58 Bank Branch Details: Bank Number : 893047 Bank Name: Doar Branch Number: 522 Branch Address: Ouziel 75 Branch City: tel_aviv  Bank Account Number 454555210 Collection Clearance: yes Payment Owed: 0 shekel Area: tel_aviv Type: caravan Size: 95 Floors: 2 Pool: yes Jacuzzi: yes Wifi: yes Tv: yes Garden: no Children's Attractions: no Public Transportation: yes View: no Smoking: no Room Service:  Snack Bar: no
Banks grouped by their names:
        Bank Number : 4 Bank Name: BeerSheva Branch Number: 4259 Branch Address: 90 Hadasa St Branch City: south
Banks grouped by their names:
        Bank Number : 3 Bank Name: Bnei brak Branch Number: 2369 Branch Address: Hazon Ish 2 Branch City: center
Banks grouped by their names:
        Bank Number : 2 Bank Name: Haifa Bank Branch Number: 5209 Branch Address: Natanzon 26 Branch City: north
Banks grouped by their names:
        Bank Number : 5 Bank Name: Nazareth Branch Number: 4589 Branch Address: 2 mar even amar st. Branch City: north
Banks grouped by their names:
        Bank Number : 1 Bank Name: Romema Branch Number: 5689 Branch Address: Shamgar 21  Branch City: jerusalem
groups units by their area:
        Hosting Unit Key: 20000000 Hosting Unit Name: BestAppartment Owner: Host Key: 3255289 First Name: Leah Last Name: abc Phone Number: 0589865896 Email Address: 0589865896 Age: 29 Bank Branch Details: Bank Number : 895987 Bank Name: Hapoalim Branch Number: 897 Branch Address: Kanfey Necharim 5 Branch City: jerusalem  Bank Account Number 823700207 Collection Clearance: yes Payment Owed: 0 shekel Area: south Type: apartment Size: 45 Floors: 1 Pool: yes Jacuzzi: no Wifi: yes Tv: yes Garden: yes Children's Attractions: yes Public Transportation: yes View: no Smoking: no Room Service:  Snack Bar: doesnt_matter
groups units by their area:
        Hosting Unit Key: 20000001 Hosting Unit Name: CaravanTLV Owner: Host Key: 3256685 First Name: Yaakov Last Name: abc Phone Number:  0589658884 Email Address:  0589658884 Age: 58 Bank Branch Details: Bank Number : 893047 Bank Name: Doar Branch Number: 522 Branch Address: Ouziel 75 Branch City: tel_aviv  Bank Account Number 454555210 Collection Clearance: yes Payment Owed: 0 shekel Area: tel_aviv Type: caravan Size: 95 Floors: 2 Pool: yes Jacuzzi: yes Wifi: yes Tv: yes Garden: no Children's Attractions: no Public Transportation: yes View: no Smoking: no Room Service:  Snack Bar: no
groups units by their host:
        Hosting Unit Key: 20000000 Hosting Unit Name: BestAppartment Owner: Host Key: 3255289 First Name: Leah Last Name: abc Phone Number: 0589865896 Email Address: 0589865896 Age: 29 Bank Branch Details: Bank Number : 895987 Bank Name: Hapoalim Branch Number: 897 Branch Address: Kanfey Necharim 5 Branch City: jerusalem  Bank Account Number 823700207 Collection Clearance: yes Payment Owed: 0 shekel Area: south Type: apartment Size: 45 Floors: 1 Pool: yes Jacuzzi: no Wifi: yes Tv: yes Garden: yes Children's Attractions: yes Public Transportation: yes View: no Smoking: no Room Service:  Snack Bar: doesnt_matter
groups units by their host:
        Hosting Unit Key: 20000001 Hosting Unit Name: CaravanTLV Owner: Host Key: 3256685 First Name: Yaakov Last Name: abc Phone Number:  0589658884 Email Address:  0589658884 Age: 58 Bank Branch Details: Bank Number : 893047 Bank Name: Doar Branch Number: 522 Branch Address: Ouziel 75 Branch City: tel_aviv  Bank Account Number 454555210 Collection Clearance: yes Payment Owed: 0 shekel Area: tel_aviv Type: caravan Size: 95 Floors: 2 Pool: yes Jacuzzi: yes Wifi: yes Tv: yes Garden: no Children's Attractions: no Public Transportation: yes View: no Smoking: no Room Service:  Snack Bar: no
groups guests by their vacations:
        request key: 10000002 Last Name: Cohen First Name: Sarah Email Address: scohen@gmail.com Status:active Registration Date 1/1/2019 12:00:00 AM Entry Date: 2/2/2019 12:00:00 AM Release Date: 2/8/2019 12:00:00 AM Area: north Type: caravan Number of Adults: 7 Number of Children: 0 Pool: no Jaccuzi: no Wifi: yes Tv: yes Garden: doesnt_matter Children's Attractions: no Public Transportation: no View: yes Smoking: yes Room Service:  Snack Bar: yes
groups guests by their vacations:
        request key: 10000001 Last Name: Bibas First Name: Eve Email Address: eve@gmail.com Status:closed_by_website Registration Date 4/8/2019 12:00:00 AM Entry Date: 5/8/2019 12:00:00 AM Release Date: 5/18/2019 12:00:00 AM Area: south Type: apartment Number of Adults: 2 Number of Children: 5 Pool: no Jaccuzi: yes Wifi: yes Tv: doesnt_matter Garden: yes Children's Attractions: no Public Transportation: yes View: yes Smoking: yes Room Service:  Snack Bar: yes
groups guests by their vacations:
        request key: 10000000 Last Name: abcd First Name: Dina Email Address: dina@gmail.com Status:active Registration Date 3/8/2019 12:00:00 AM Entry Date: 3/28/2019 12:00:00 AM Release Date: 4/8/2019 12:00:00 AM Area: jerusalem Type: hotel Number of Adults: 1 Number of Children: 0 Pool: yes Jaccuzi: yes Wifi: yes Tv: doesnt_matter Garden: no Children's Attractions: no Public Transportation: doesnt_matter View: yes Smoking: no Room Service:  Snack Bar: yes
*/
