using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
   public interface Idal
    {
        /// <summary>
        /// adds a guest request to the data source
        /// </summary>
        /// <param name="guest"></param>
        void AddGuestRequest(BE.GuestRequest guest);
        /// <summary>
        /// updates a guest request
        /// </summary>
        /// <param name="guest"></param>
        void UpdateGuestRequest(BE.GuestRequest guest);
        /// <summary>
        /// updates a hosting unit
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
        /// <param name="order"></param>
        void AddOrder(BE.Order order);
        /// <summary>
        /// updates an order's status
        /// </summary>
        /// <param name="order"></param>
        void UpdateOrderStatus(BE.Order order);
        /// <summary>
        /// returns the list of hosting units
        /// </summary>
        /// <returns></returns>
        List<BE.HostingUnit> GetHostingUnitList();
        /// <summary>
        /// returns the list of guest requests
        /// </summary>
        /// <returns></returns>
        List<BE.GuestRequest> GetGuestList();
        /// <summary>
        /// returns the list of orders
        /// </summary>
        /// <returns></returns>
        List<BE.Order> GetOrderList();
        /// <summary>
        /// returns the list of bank branches
        /// </summary>
        /// <returns></returns>
        /// //Func<BE.BankBranches, bool> predicate = null)
        List<BE.BankBranches> GetBranches();
        /// <summary>
        /// adds a bank branch
        /// </summary>
        /// <param name="bank"></param>
   //     void AddBankBranch(BE.BankBranches bank);
        /// <summary>
        /// updates a host's first name
        /// </summary>
        /// <param name="host"></param>
        /// <param name="newName"></param>
       void UpdateHostPrivateName(BE.Host host , string newName);
        /// <summary>
        /// updates a host's last name
        /// </summary>
        /// <param name="host"></param>
        /// <param name="newName"></param>
        void UpdateHostFamilyName(BE.Host host, string newName);
        /// <summary>
        /// updates a guest's first name
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
        void updateOrderCheckerDate(DateTime date);
    }
}
