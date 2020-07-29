using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public interface IBL
    {
        /// <summary>
        /// adds a guest request
        /// </summary>
        /// <param name="guest"></param>
        void AddGuestRequest(BE.GuestRequest guest);
        /// <summary>
        /// updates a guest request
        /// </summary>
        /// <param name="guest"></param>
        void UpdateGuestRequest(BE.GuestRequest guest);
        /// <summary>
        /// adds a hosting unit
        /// </summary>
        /// <param name="unit"></param>
        void AddHostingUnit(BE.HostingUnit unit);
        /// <summary>
        /// deletes a hosting unit
        /// </summary>
        /// <param name="unit"></param>
        void DeleteHostingUnit(BE.HostingUnit unit);
        /// <summary>
        /// updates a hosting unit
        /// </summary>
        /// <param name="unit"></param>
        void UpdateHostingUnit(BE.HostingUnit unit);
        /// <summary>
        /// adds an order
        /// </summary>
        /// <param name="guestRequestKey"></param>
        /// <param name="hostingUnitKey"></param>
        void AddOrder(int guestRequestKey, int hostingUnitKey);
        /// <summary>
        /// updates an order's status
        /// </summary>
        /// <param name="order"></param>
        void UpdateOrderStatus(BE.Order order , BE.OrderStatus status,DateTime date);
        /// <summary>
        /// returns hosting unit list
        /// </summary>
        /// <returns></returns>
        List<BE.HostingUnit> GetHostingUnitList();
        /// <summary>
        /// returns guest request list
        /// </summary>
        /// <returns></returns>
        List<BE.GuestRequest> GetGuestList();
        /// <summary>
        /// returns order list
        /// </summary>
        /// <returns></returns>
        List<BE.Order> GetOrderList();
        /// <summary>
        /// returns bank branches list
        /// </summary>
        /// <returns></returns>
        List<BE.BankBranches> GetBranches();
        /// <summary>
        /// adds a bank branch
        /// </summary>
        /// <param name="bank"></param>
       // void AddBankBranch(BE.BankBranches bank);
        /// <summary>
        /// updates a host's first name
        /// </summary>
        /// <param name="host"></param>
        /// <param name="newName"></param>
        void UpdateHostPrivateName(BE.Host host, string newName);
        /// <summary>
        /// updates a host's last name
        /// </summary>
        /// <param name="host"></param>
        /// <param name="newName"></param>
        void UpdateHostFamilyName(BE.Host host, string newName);
        /// <summary>
        /// updates a guest's last name
        /// </summary>
        /// <param name="guest"></param>
        /// <param name="newName"></param>
        void UpdateGuestPrivateName(BE.GuestRequest guest, string newName);
        /// <summary>
        /// updates a guest's last name
        /// </summary>
        /// <param name="guest"></param>
        /// <param name="newName"></param>
        void UpdateGuestFamilyName(BE.GuestRequest guest, string newName);
        /// <summary>
        /// updates a hosting unit's size
        /// </summary>
        /// <param name="unit"></param>
        /// <param name="size"></param>
        void UpdateHostingUnitSize(BE.HostingUnit unit, int size);
        /// <summary>
        /// returns list of availble units for a requested amount of days
        /// </summary>
        /// <param name="a"></param>
        /// <param name="VacationDays"></param>
        /// <returns></returns>
        List<BE.HostingUnit> GetAvailableUnits(DateTime a, int VacationDays);
        /// <summary>
        /// returns the amount of days in between two dates
        /// </summary>
        /// <param name="dates"></param>
        /// <returns></returns>
        int GetDays(params DateTime[] dates);
        /// <summary>
        /// returns list of open orders
        /// </summary>
        /// <param name="days"></param>
        /// <returns></returns>
        List<BE.Order> OpenOrders(int days);
        /// <summary>
        /// recieves delegate and returns partial guest list
        /// </summary>
        /// <param name="func"></param>
        /// <returns></returns>
        List<BE.GuestRequest> GetGuestsPartialListByPredicate(Func<BE.GuestRequest, bool> func);
        /// <summary>
        /// returns the number of orders a guest has
        /// </summary>
        /// <param name="g"></param>
        /// <returns></returns>
        int NumberOfGuestOrders(BE.GuestRequest g);
        /// <summary>
        /// returns the number of orders a unit has
        /// </summary>
        /// <param name="unit"></param>
        /// <returns></returns>
        int NumberOfUnitOrders(BE.HostingUnit unit);
        /// <summary>
        /// returns the amount of successful orders a unit has taken part of
        /// </summary>
        /// <param name="h"></param>
        /// <returns></returns>
        int NumberOfSuccessfullOrders(BE.HostingUnit h);
        /// <summary>
        /// groups units by area
        /// </summary>
        /// <returns></returns>
        IEnumerable<IGrouping<BE.Area, BE.HostingUnit>> GetGroupedByUnitArea();
        /// <summary>
        /// groups hosts by the number of units they have
        /// </summary>
        /// <returns></returns>
        IEnumerable<IGrouping<int, BE.HostingUnit>> GetGroupedByNumberOfUnits();
        /// <summary>
        /// returns list of units in tel aviv that have a pool and a jacuzzi
        /// </summary>
        /// <returns></returns>
        List<BE.HostingUnit> GetUnitsInTelAvivWithPoolAndJacuzzi();
        /// <summary>
        /// groups banks by their name
        /// </summary>
        /// <returns></returns>
        IEnumerable<IGrouping<string, BE.BankBranches>> GetGroupedByBankName();
        /// <summary>
        /// returns list of guests that have children and want  to smoke
        /// </summary>
        /// <returns></returns>
        List<BE.GuestRequest> GetGuestsWithChildrenAndWantToSmoke();
        /// <summary>
        /// recieves a delegate and returns partial host list
        /// </summary>
        /// <param name="func"></param>
        /// <returns></returns>
        List<BE.HostingUnit> GetHostsPartialListByPredicate(Func<BE.Host, bool> func);
        /// <summary>
        /// groups units by having tv and wifi
        /// </summary>
        /// <returns></returns>
        IEnumerable<IGrouping<bool, BE.HostingUnit>> GetGroupedByNoTelevisionAndWifi();
        /// <summary>
        /// returns list of banks in jerusalem
        /// </summary>
        /// <returns></returns>
        List<BE.BankBranches> GetBankInJerusalem();
        /// <summary>
        /// groups units by their popularity
        /// </summary>
        /// <returns></returns>
        IEnumerable<IGrouping<int, BE.Order>> GetGroupedByUnitPopularity();
        /// <summary>
        /// groups units by their area
        /// </summary>
        /// <returns></returns>
        IEnumerable<IGrouping<BE.Area, BE.GuestRequest>> GetGroupedByArea();
        /// <summary>
        /// groups guests by their number of orders
        /// </summary>
        /// <returns></returns>
        IEnumerable<IGrouping<int, BE.GuestRequest>> GetGroupedByNumberOfVacations();
        /// <summary>
        /// returns amount of money website made
        /// </summary>
        /// <returns></returns>
        int PayDay();
        /// <summary>
        /// sends email
        /// </summary>
        /// <param name="to"></param>
        /// <param name="subject"></param>
        /// <param name="body"></param>
        void SendMail(string to, string subject, string body);
        /// <summary>
        /// gets branch numbers based on name
        /// </summary>
        /// <param name="bankName"></param>
        /// <returns></returns>
        List<int> GetBranchNumbers(string bankName);
        /// <summary>
        /// gets bank names
        /// </summary>
        /// <returns></returns>
        List<string> getBankNames();
        /// <summary>
        /// gets information on bank based on name and branch number
        /// </summary>
        /// <param name="num"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        BE.BankBranches GetBranchByNumberAndName(int num, string name);
        /// <summary>
        /// returns the number of canceled orders
        /// </summary>
        /// <returns></returns>
        int numberOfCanceledOrders();
        /// <summary>
        /// returns the number of approved orders
        /// </summary>
        /// <returns></returns>
      int numberOfAcceptedOrders();

    }
}
