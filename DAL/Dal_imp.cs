using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;
using DS;
namespace DAL
{
  //  public class Dal_imp : Idal
  //  {
    //    #region Add Guest Request
    //    /// <summary>
    //    /// adds a new guest request
    //    /// </summary>
    //    /// <param name="guest"></param>
    //    public void AddGuestRequest(GuestRequest guest)
    //    {

    //        var it = (from newGuest in GetGuestList()
    //                  let x = newGuest.GuestRequestKey
    //                  where x == guest.GuestRequestKey
    //                  select new { GuestRequestKey = x }).FirstOrDefault();
    //        if (it != null)
    //            throw new DuplicateWaitObjectException("request already exists");


    //        else
    //        {

    //            guest.GuestRequestKey = Configuration.GuestRequestKey++;
    //            guest.Status = RequestStatus.active;
    //            guest.RegistrationDate = DateTime.Now;
    //            DataSource.guestRequests.Add(guest.Clone());
    //        }
    //    }
    //    #endregion
    //    #region Add Bank Branch
    //    /// <summary>
    //    /// adds a new bank branch
    //    /// </summary>
    //    /// <param name="bank"></param>
    //    public void AddBankBranch(BankBranches bank)
    //    {
    //        var it = (from newBranch in GetBranches()
    //                  where newBranch.BankNumber == bank.BankNumber
    //                  select newBranch).FirstOrDefault();
    //        if (it != null)
    //            throw new DuplicateWaitObjectException("bank already exists");


    //        else
    //        {

    //            DataSource.bankBranches.Add(bank.Clone());
    //        }
    //    }

    //    #endregion
    //    #region Add Hosting Unit
    //    /// <summary>
    //    /// adds a new hosting unit
    //    /// </summary>
    //    /// <param name="unit"></param>
    //    public void AddHostingUnit(HostingUnit unit)
    //    {

    //        var it = (from newUnit in GetHostingUnitList()
    //                  let x = newUnit
    //                  where x.HostingUnitKey == unit.HostingUnitKey
    //                  select x).FirstOrDefault();
    //        if (it != null)
    //            throw new InvalidOperationException("Unit already exists");
    //        else
    //        {

    //            unit.HostingUnitKey = Configuration.HostingUnitKey++;
    //            DataSource.hostingUnits.Add(unit.Clone());
    //        }
    //    }
    //    #endregion
    //    #region Add Order
    //    /// <summary>
    //    /// adds a new order
    //    /// </summary>
    //    /// <param name="order"></param>
    //    public void AddOrder(Order order)
    //    {
    //        var it = (from newOrder in GetOrderList()
    //                  where newOrder.OrderKey == order.OrderKey
    //                  select newOrder).FirstOrDefault();
    //        var unit = DataSource.hostingUnits.Find(x => x.HostingUnitKey == order.HostingUnitKey);
    //        if (it != null)
    //        {
    //            throw new DuplicateWaitObjectException("Order already exists");
    //        }
    //        else

    //            if (unit == null)
    //            throw new DuplicateWaitObjectException("This Hosting Unit doesn't exist");

    //        else
    //        {
    //            order.OrderKey = Configuration.OrderKey++;
    //            DataSource.orders.Add(order.Clone());
    //        }
    //    }
    //    #endregion
    //    #region Delete Hosting Unit
    //    /// <summary>
    //    /// deletes a hosting unit
    //    /// </summary>
    //    /// <param name="unit"></param>
    //    public void DeleteHostingUnit(HostingUnit unit)
    //    {
    //        var it = (from newUnit in GetHostingUnitList()
    //                  where newUnit.HostingUnitKey == unit.HostingUnitKey
    //                  select newUnit).FirstOrDefault();
    //        if (it != null)
    //        {
    //            DataSource.hostingUnits.Remove(DataSource.hostingUnits.Find(x => x.HostingUnitKey == unit.HostingUnitKey));
    //        }
    //        else
    //        {
    //            throw new KeyNotFoundException("This unit doesn't exist");
    //        }
    //    }
    //    #endregion
    //    #region Get Branches
    //    /// <summary>
    //    /// returns list of bank branches
    //    /// </summary>
    //    /// <returns></returns>
    //    public List<BE.BankBranches> GetBranches()
    //    {
    //        List<BankBranches> list = new List<BankBranches>();
    //        BE.BankBranches bankbranch1 = new BE.BankBranches();
    //        bankbranch1.BankName = "Romema";
    //        bankbranch1.BranchNumber = 5689;
    //        bankbranch1.BranchAddress = "Shamgar 21 ";
    //        bankbranch1.BranchCity = Area.jerusalem;
    //        bankbranch1.BankNumber = 1;

    //        list.Add(bankbranch1);

    //        BE.BankBranches bankbranch2 = new BE.BankBranches();
    //        bankbranch2.BankName = "Haifa Bank";
    //        bankbranch2.BranchNumber = 5209;
    //        bankbranch2.BranchAddress = "Natanzon 26";
    //        bankbranch2.BranchCity = Area.north;
    //        bankbranch2.BankNumber = 2;

    //        list.Add(bankbranch2);
    //        BE.BankBranches bankbranch3 = new BE.BankBranches();
    //        bankbranch3.BankName = "Bnei brak";
    //        bankbranch3.BranchNumber = 2369;
    //        bankbranch3.BranchAddress = "Hazon Ish 2";
    //        bankbranch3.BranchCity = Area.center;
    //        bankbranch3.BankNumber = 3;


    //        list.Add(bankbranch3);
    //        BE.BankBranches bankbranch4 = new BE.BankBranches();
    //        bankbranch4.BankName = "BeerSheva";
    //        bankbranch4.BranchNumber = 4259;
    //        bankbranch4.BranchAddress = "90 Hadasa St";
    //        bankbranch4.BranchCity = Area.south;
    //        bankbranch4.BankNumber = 4;
    //        list.Add(bankbranch4);

    //        BE.BankBranches bankbranch5 = new BE.BankBranches();
    //        bankbranch5.BankName = "Nazareth";
    //        bankbranch5.BranchNumber = 4589;
    //        bankbranch5.BranchAddress = "2 mar even amar st.";
    //        bankbranch5.BranchCity = Area.north;
    //        bankbranch5.BankNumber = 5;
    //        list.Add(bankbranch5);
    //        //foreach(var bank in DataSource.bankBranches)
    //        //{
    //        //    list.Add(bank.Clone());
    //        //}
    //        return list;

    //    }
    //    #endregion
    //    #region Get Guest List
    //    /// <summary>
    //    /// returns list of guest requests
    //    /// </summary>
    //    /// <returns></returns>
    //    public List<GuestRequest> GetGuestList()
    //    {
    //        BE.GuestRequest guestRequest = new BE.GuestRequest();

    //        guestRequest.PrivateName = "Dina";
    //        guestRequest.FamilyName = "Pinchuck";
    //        guestRequest.MailAddress = "dina@gmail.com";
    //        guestRequest.RegistrationDate = new DateTime(2019, 03, 08);
    //        guestRequest.EntryDate = new DateTime(2019, 03, 28);
    //        guestRequest.ReleaseDate = new DateTime(2019, 04, 08);
    //        guestRequest.area = Area.jerusalem;
    //        guestRequest.type = BE.Type.hotel;
    //        guestRequest.Adults = 1;
    //        guestRequest.Children = 0;
    //        guestRequest.pool = Pool.yes;
    //        guestRequest.jacuzzi = Jacuzzi.yes;
    //        guestRequest.wifi = Wifi.yes;
    //        guestRequest.tv = Television.doesnt_matter;
    //        guestRequest.garden = Garden.no;
    //        guestRequest.childrensAttractions = ChildrensAttractions.no;
    //        guestRequest.publicTransportation = PublicTransportation.doesnt_matter;
    //        guestRequest.view = View.yes;
    //        guestRequest.smoking = Smoking.no;
    //        guestRequest.roomService = RoomService.doesnt_matter;
    //        guestRequest.snackBar = SnackBar.yes;

    //        List<GuestRequest> list = new List<GuestRequest>();

    //        foreach (var guest in DataSource.guestRequests)
    //        {
    //            list.Add(guest.Clone());
    //        }
    //        return list;


    //    }
    //    #endregion
    //    #region Get Hosting Unit List
    //    /// <summary>
    //    /// returns list of hosting units
    //    /// </summary>
    //    /// <returns></returns>
    //    public List<HostingUnit> GetHostingUnitList()
    //    {

    //        List<HostingUnit> list = new List<HostingUnit>();

    //        foreach (var unit in DataSource.hostingUnits)
    //        {
    //            list.Add(unit.Clone());
    //        }
    //        return list;
    //    }
    //    #endregion
    //    #region Get Order List
    //    /// <summary>
    //    /// returns list of orders
    //    /// </summary>
    //    /// <returns></returns>
    //    public List<Order> GetOrderList()
    //    {
    //        List<Order> list = new List<Order>();
    //        foreach (var order in DataSource.orders)
    //        {
    //            list.Add(order.Clone());
    //        }
    //        return list;

    //    }
    //    #endregion
    //    #region Update Guest Request
    //    /// <summary>
    //    /// updates a guest request
    //    /// </summary>
    //    /// <param name="guest"></param>
    //    public void UpdateGuestRequest(GuestRequest guest)
    //    {
    //        int index = DataSource.guestRequests.FindIndex(x => x.GuestRequestKey == guest.GuestRequestKey);
    //        if (index > -1)
    //        {
    //            DataSource.guestRequests[index] = guest.Clone();
    //        }
    //        else
    //        {
    //            throw new KeyNotFoundException("this order doesn't exists ");
    //        }

    //    }
    //    #endregion
    //    #region Update Hosting Unit
    //    /// <summary>
    //    /// updates a hosting unit
    //    /// </summary>
    //    /// <param name="unit"></param>
    //    public void UpdateHostingUnit(HostingUnit unit)
    //    {
    //        int index = DataSource.hostingUnits.FindIndex(x => x.HostingUnitKey == unit.HostingUnitKey);
    //        if (index > -1)
    //        {
    //            DataSource.hostingUnits[index] = unit.Clone();
    //        }
    //        else
    //        {
    //            throw new KeyNotFoundException("this unit doesn't exists ");
    //        }

    //    }

    //    #endregion
    //    #region Update Order Status
    //    /// <summary>
    //    /// updates an order status
    //    /// </summary>
    //    /// <param name="order"></param>
    //    public void UpdateOrderStatus(Order order)
    //    {
    //        int index = DataSource.orders.FindIndex(x => x.OrderKey == order.OrderKey);
    //        if (index > -1)
    //        {
    //            DataSource.orders[index] = order.Clone();
    //        }
    //        else
    //        {
    //            throw new KeyNotFoundException("this order doesn't exists ");
    //        }

    //    }
    //    #endregion
    //    #region Update Host Private Name
    //    /// <summary>
    //    /// updates a host's private name
    //    /// </summary>
    //    /// <param name="host"></param>
    //    /// <param name="newName"></param>
    //    public void UpdateHostPrivateName(Host host, string newName)
    //    {
    //        var y = DataSource.hostingUnits.FirstOrDefault(x => x.Owner.HostKey == host.HostKey);
    //        y.Owner.PrivateName = newName;
    //        UpdateHostingUnit(y);
    //    }
    //    #endregion
    //    #region Update Host Family Name
    //    /// <summary>
    //    /// updates a host's family name
    //    /// </summary>
    //    /// <param name="host"></param>
    //    /// <param name="newName"></param>
    //    public void UpdateHostFamilyName(Host host, string newName)
    //    {
    //        var y = DataSource.hostingUnits.FirstOrDefault(x => x.Owner.HostKey == host.HostKey);
    //        y.Owner.FamilyName = newName;
    //        UpdateHostingUnit(y);
    //    }
    //    #endregion
    //    #region Update Guest Private Name
    //    /// <summary>
    //    /// updates a guest's private name
    //    /// </summary>
    //    /// <param name="guest"></param>
    //    /// <param name="newName"></param>
    //    public void UpdateGuestPrivateName(GuestRequest guest, string newName)
    //    {
    //        var y = DataSource.guestRequests.FirstOrDefault(x => x.GuestRequestKey == guest.GuestRequestKey);
    //        y.PrivateName = newName;
    //        UpdateGuestRequest(y);
    //    }
    //    #endregion
    //    #region Update Guest Family Name
    //    /// <summary>
    //    /// updates a guest's family name
    //    /// </summary>
    //    /// <param name="guest"></param>
    //    /// <param name="newName"></param>
    //    public void UpdateGuestFamilyName(GuestRequest guest, string newName)
    //    {
    //        var y = DataSource.guestRequests.FirstOrDefault(x => x.GuestRequestKey == guest.GuestRequestKey);
    //        y.FamilyName = newName;
    //        UpdateGuestRequest(y);
    //    }
    //    #endregion
    //    #region Update Hosting Unit Size
    //    /// <summary>
    //    /// updates a hosting unit's size
    //    /// </summary>
    //    /// <param name="unit"></param>
    //    /// <param name="size"></param>
    //    public void UpdateHostingUnitSize(HostingUnit unit, int size)
    //    {
    //        var y = DataSource.hostingUnits.FirstOrDefault(x => x.HostingUnitKey == unit.HostingUnitKey);
    //        y.Size = size;
    //        UpdateHostingUnit(y);

    //    }
    //    #endregion

    //}
}