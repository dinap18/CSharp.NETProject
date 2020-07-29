using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.ComponentModel;
using BE;
using DAL;
using System.ComponentModel.DataAnnotations;
using System.Threading;
using System.Threading.Tasks;
using System.Net.Mail;
using System.Net;

namespace BL
{
    public class IBLDefinitions : IBL
    {
        protected Idal dalAccess;
        public IBLDefinitions()
        {
            dalAccess = FactoryDAL.GetInstance();
            Thread thread = new Thread(() =>checkForExpiredOrders());
            thread.Start();
        }
        #region check for expired orders
        /// <summary>
        /// checks for orders that a month has gone by since an email was sent and no response was recevied
        /// </summary>
        void checkForExpiredOrders()
        {
            try
            {
                if (Configuration.orderChecker.Day != DateTime.Now.Day)
                {
                    foreach (var order in GetOrderList())
                    {
                        if (Math.Abs(order.OrderDate.Day - DateTime.Now.Day) > 31 && order.Status==OrderStatus.email_sent)
                        {
                            order.Status = OrderStatus.customer_canceled;
                            dalAccess.UpdateOrderStatus(order);
                        }
                    }
                    Configuration.orderChecker = DateTime.Now;
                    dalAccess.updateOrderCheckerDate(Configuration.orderChecker);
                }
            }
            catch(Exception e)
            {
                throw e;
            }
        }
        #endregion
       
        #region Add Guest Request
        /// <summary>
        /// adds a guest request
        /// </summary>
        /// <param name="guest"></param>
        public void AddGuestRequest(BE.GuestRequest guest)
        {
            try
            {
                if (GetGuestList().Any(x => x.GuestRequestKey == guest.GuestRequestKey))
                throw new InvalidOperationException(string.Format("Guest " + guest.GuestRequestKey + " already exists"));
            if (guest.EntryDate >= guest.ReleaseDate || DateTime.Now > guest.EntryDate)
            {
                throw new InvalidOperationException("Invalid date range");
            }
            var isValid = new EmailAddressAttribute().IsValid(guest.MailAddress);
            if (!isValid)
                throw new InvalidOperationException("invalid email address");
           
                guest.Status = RequestStatus.active;
                dalAccess.AddGuestRequest(guest);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        #endregion
        #region Update Guest Request
        /// <summary>
        /// updates a guest request
        /// </summary>
        /// <param name="guest"></param>
        public void UpdateGuestRequest(BE.GuestRequest guest)
        {
            try
            {
                var itGuest = (from newGuest in dalAccess.GetGuestList()
                           where newGuest.GuestRequestKey == guest.GuestRequestKey
                           select newGuest).FirstOrDefault();

            if (itGuest == null)
                throw new NullReferenceException(" Guest doesn't exist");


            int difference = itGuest.RegistrationDate.Day - DateTime.Now.Day;
            if (difference >= 14)
                itGuest.Status = RequestStatus.expired;

            int timeOfStay = (itGuest.ReleaseDate - itGuest.EntryDate).Days;
            if (timeOfStay <= 0)
                throw new InvalidOperationException("vacation has to be at least a day long");

            //if (guest.Status == RequestStatus.closed_by_website || guest.Status == RequestStatus.expired)
            //{
            //    var itOrder = (from newGuest in dalAccess.GetOrderList()
            //                   where newGuest.GuestRequestKey == guest.GuestRequestKey
            //                   select newGuest).FirstOrDefault();
            //    if (itOrder == null)
            //        throw new NullReferenceException("this guest doesnt have an order");




            //}

            if (guest.PrivateName != itGuest.PrivateName || guest.FamilyName != itGuest.FamilyName)
                throw new InvalidOperationException(string.Format("cannot change basic information"));
          
                dalAccess.UpdateGuestRequest(guest);
            }
            catch (Exception e)
            {
                throw e;
            }



        }
        #endregion
        #region Add Hosting Unit
        /// <summary>
        /// adds a hosting unit
        /// </summary>
        /// <param name="unit"></param>
        public void AddHostingUnit(BE.HostingUnit unit)
        {
            try
            {
                if (dalAccess.GetHostingUnitList().Any(x => x.HostingUnitKey == unit.HostingUnitKey))
                    throw new InvalidOperationException(string.Format("Hosting Unit " + unit.HostingUnitKey + " already exists"));
                var isValid = new EmailAddressAttribute().IsValid(unit.Owner.MailAddress);
                if (!isValid)
                    throw new InvalidOperationException("invalid email address");
                if (unit.Owner.Age > 120)
                    throw new InvalidOperationException("invaild age");
                if (unit.Floors < 0)
                    throw new InvalidOperationException("invaild amount of floors");
                if (unit.Size < 0)
                    throw new InvalidOperationException("invaild size");
                dalAccess.AddHostingUnit(unit);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        #endregion
        #region Delete Hosting Unit
        /// <summary>
        /// deletes a hosting unit
        /// </summary>
        /// <param name="unit"></param>
        public void DeleteHostingUnit(BE.HostingUnit unit)
        {
            try
            {
                var it = from newUnit in dalAccess.GetHostingUnitList()
                     let x = newUnit.HostingUnitKey
                     where x == unit.HostingUnitKey
                     select new { HostingUnitKey = x };
            if (it == null)
                throw new NullReferenceException(string.Format("Hosting Unit " + unit.HostingUnitKey + " doesn't exist"));
            //if (dalAccess.GetOrderList().Any(y => y.HostingUnitKey == unit.HostingUnitKey && (y.Status != OrderStatus.customer_canceled)))
            //    throw new InvalidOperationException("cannot delete a hosting unit with active orders");
           foreach(var order in GetOrderList())
                {
                    if(order.HostingUnitKey==unit.HostingUnitKey && order.Status!=OrderStatus.customer_canceled)
                          throw new InvalidOperationException("cannot delete a hosting unit with active orders");
                }
                    dalAccess.DeleteHostingUnit(unit);
            }
            catch (Exception e)
            {
                throw e;
            }

        }
        #endregion
        #region Update Hosting Unit
        /// <summary>
        /// updates a hosting unit
        /// </summary>
        /// <param name="unit"></param>
        public void UpdateHostingUnit(BE.HostingUnit unit)
        {
            try
            {
                var itUnit = (from newUnit in dalAccess.GetHostingUnitList()
                          where newUnit.HostingUnitKey == unit.HostingUnitKey
                          select newUnit).FirstOrDefault();

            if (itUnit == null)
                throw new NullReferenceException(string.Format("unit " + unit.HostingUnitKey + " doesn't exist"));
            if (itUnit.area != unit.area || itUnit.type != unit.type || itUnit.view != unit.view)
                throw new InvalidOperationException("cannot change this information");
            if (unit.Floors < 0)
                throw new InvalidOperationException("invaild amount of floors");
            if (unit.Size < 0)
                throw new InvalidOperationException("invaild size");
            if (itUnit.Owner.CollectionClearance != unit.Owner.CollectionClearance )
            {
                var itOrder = (from newOrder in dalAccess.GetOrderList()
                               where newOrder.HostingUnitKey == unit.HostingUnitKey
                               select newOrder).FirstOrDefault();
                if (itOrder == null)
                    throw new NullReferenceException("order doesnt exist");
              
                    if (unit.Owner.CollectionClearance == PaymentClearance.no)
                        foreach (var order in GetOrderList())
                         {
                             if (order.HostingUnitKey == itUnit.HostingUnitKey && order.Status==OrderStatus.not_dealt_with || order.Status==OrderStatus.email_sent )
                            { 
                                throw new InvalidOperationException("cannot remove clearance on a unit with open orders");
                            }
                         }
                
            }

         
                dalAccess.UpdateHostingUnit(unit);
            }
            catch (Exception e)
            {
                throw e;
            }

        }
        #endregion
        #region Add Order
        /// <summary>
        /// adds an order
        /// </summary>
        /// <param name="order"></param>
        public void AddOrder(int guestRequestKey, int hostingUnitKey)
        {

            try
            {
                Order order = new Order();

                var itUnit = (from newUnit in dalAccess.GetHostingUnitList()
                              let x = newUnit
                              where x.HostingUnitKey == hostingUnitKey
                              select x).FirstOrDefault();
                if (itUnit == null)
                {
                    throw new NullReferenceException("Hosting Unit doesn't exist");
                }

                else
                {
                    var itGuest = (from newGuest in dalAccess.GetGuestList()
                                   where newGuest.GuestRequestKey == guestRequestKey
                                   select newGuest).FirstOrDefault();
                    if (itGuest == null)
                        throw new NullReferenceException("guest doesnt exist");
                    if (itGuest.Status != RequestStatus.active)
                        throw new InvalidOperationException("an order cannot be opened for a inactive request");
                    foreach(var x in GetOrderList())
                    {
                        if (x.HostingUnitKey == itUnit.HostingUnitKey && itGuest.GuestRequestKey == x.GuestRequestKey)
                            throw new InvalidOperationException("an order like this already exists");
                    }
                    if (itGuest.RegistrationDate.Day - DateTime.Now.Day > 14)
                    {
                        UpdateGuestRequest(itGuest);
                        throw new InvalidOperationException("request expired");
                    }
                    if((itGuest.Adults+itGuest.Children) > itUnit.Size)
                    {
                        throw new InvalidOperationException("unit not big enough for amount of people");
                    }
                    int helper = 0;
                    int timeOfStay = (itGuest.ReleaseDate - itGuest.EntryDate).Days;
                    for (int i = itGuest.EntryDate.Month - 1; i < 12; i++)// checks if the dates are taken
                        for (int j = 0; j < 31; j++)
                        {
                            if (helper < timeOfStay)
                            {
                                if ((j >= (itGuest.EntryDate.Day - 1)) || (helper > 0 && helper < timeOfStay))
                                {
                                    if (helper < timeOfStay)
                                    {
                                        if (itUnit.Diary[i, j] == true)

                                        {
                                            throw new DuplicateWaitObjectException("Dates are already taken");
                                        }
                                    }
                                }


                            }
                            helper++;
                            if (helper == timeOfStay)
                                break;
                        }

                    order.CreateDate = DateTime.Now;
                    order.GuestRequestKey = guestRequestKey;
                    order.HostingUnitKey = hostingUnitKey;
                    order.Status = OrderStatus.not_dealt_with;
                    dalAccess.AddOrder(order);
                }
            }
            catch (Exception e)
            {
                throw e;
            }
   



        }
        #endregion
        #region Update Order Status
        /// <summary>
        /// updates an order status
        /// </summary>
        /// <param name="order"></param>
        public void UpdateOrderStatus(BE.Order order, BE.OrderStatus status,DateTime date)
        {

            try

            {
                var itOrder = (from newOrder in GetOrderList()
                               where newOrder.OrderKey == order.OrderKey
                               select newOrder).FirstOrDefault();
                if (itOrder == null)
                {
                    throw new NullReferenceException("order doesn't exist");
                }
                var itUnit = (from newOrder in GetHostingUnitList()
                              where newOrder.HostingUnitKey == order.HostingUnitKey
                              select newOrder).FirstOrDefault();
                var itGuest = (from newGuest in GetGuestList()
                               where newGuest.GuestRequestKey == order.GuestRequestKey
                               select newGuest).FirstOrDefault();

                if (order.Status == OrderStatus.customer_canceled)
                {
                    throw new InvalidOperationException("order was already canceled and cannot be updated");
                }
                if (order.Status == OrderStatus.customer_accepted)
                {
                    throw new InvalidOperationException("order was already approved and cannot be updated");
                }
                int timeOfStay = (itGuest.ReleaseDate - itGuest.EntryDate).Days;
                if (itOrder.Status == status)
                    throw new InvalidOperationException("there is nothing to update");
                if (itOrder.Status == OrderStatus.not_dealt_with && status == OrderStatus.customer_accepted)
                    throw new InvalidOperationException("an email must be sent before an order can be approved");
                if (status != OrderStatus.customer_canceled)
                {
                    int helper = 0;

                    for (int i = itGuest.EntryDate.Month - 1; i < 12; i++)// checks if the dates are taken
                        for (int j = 0; j < 31; j++)
                        {
                            if (helper < timeOfStay)
                            {
                                if ((j >= (itGuest.EntryDate.Day - 1)) || (helper > 0 && helper < timeOfStay))
                                {
                                    if (helper < timeOfStay)
                                    {
                                        if (itUnit.Diary[i, j] == true)

                                        {
                                            itOrder.Status = OrderStatus.customer_canceled;
                                            dalAccess.UpdateOrderStatus(itOrder);
                                            throw new DuplicateWaitObjectException("Dates are already taken");
                                        }
                                    }
                                }


                            }
                            helper++;
                        }
                }
                if (status == OrderStatus.customer_accepted && itOrder.Status == OrderStatus.email_sent)
                { 

                    int helper = 0;
                    for (int i = itGuest.EntryDate.Month - 1; i < 12; i++)
                        for (int j = 0; j < 31; j++)
                        {
                            if (helper < timeOfStay)
                            {
                                if ((j >= (itGuest.EntryDate.Day - 1)) || (helper > 0 && helper < timeOfStay))
                                {
                                    if (helper < timeOfStay)
                                    {
                                        itUnit.Diary[i, j] = true;

                                    }
                                }


                            }
                            helper++;
                        }
                   
                    foreach (var request in GetOrderList())
                    {
                        if (request.GuestRequestKey == itGuest.GuestRequestKey && request != order)
                        {

                            request.Status = OrderStatus.customer_canceled;
                            dalAccess.UpdateOrderStatus(request);

                        }
                    }
                    itGuest.Status = RequestStatus.closed_by_website;
                    UpdateGuestRequest(itGuest);
                    if (itUnit.Owner.CollectionClearance == PaymentClearance.yes)
                    {

                        itUnit.Owner.PaymentOwed +=  timeOfStay * Configuration.commision;

                    }
                    UpdateHostingUnit(itUnit);
                }

                if (status == OrderStatus.email_sent && order.Status != OrderStatus.email_sent)
                {
                    if (itUnit.Owner.CollectionClearance != PaymentClearance.yes)
                        throw new InvalidOperationException("cannot charge in case of cancellation");
                    itOrder.OrderDate = date;
                }
                if (status == OrderStatus.customer_canceled)
                {


                    int helper = 0;
                    for (int i = itGuest.EntryDate.Month - 1; i < 12; i++)
                        for (int j = 0; j < 31; j++)
                        {
                            if (helper < timeOfStay)
                            {
                                if ((j >= (itGuest.EntryDate.Day - 1)) || (helper > 0 && helper < timeOfStay))
                                {
                                    if (helper < timeOfStay)
                                    {
                                        itUnit.Diary[i, j] = false;

                                    }

                                }


                            }
                            helper++;

                        }
                    UpdateHostingUnit(itUnit); ;
                }
                itOrder.Status = status;
                dalAccess.UpdateOrderStatus(itOrder);

            }
            catch(Exception e)
            {
                throw e;
            }

        }
        #endregion
        #region Get Hosting Unit list
        /// <summary>
        /// returns list of hosting units
        /// </summary>
        /// <returns></returns>
        public List<BE.HostingUnit> GetHostingUnitList()
        {
            try
            {
               

                var unitList = from newUnit in dalAccess.GetHostingUnitList()
                               orderby newUnit.HostingUnitKey
                               select newUnit;
               return unitList.ToList();

            }
            catch (Exception e)
            {
                throw e;
            }
        }
        #endregion
        #region Get Guest Request List
        /// <summary>
        /// returns guest request list
        /// </summary>
        /// <returns></returns>
        public List<BE.GuestRequest> GetGuestList()
        {
            try
            {
                

                var requestList = from newRequest in dalAccess.GetGuestList()
                                  orderby newRequest.GuestRequestKey
                                  select newRequest;
              return requestList.ToList();


            }
            catch (Exception e)
            {
                throw e;
            }
        }
        #endregion
        #region Get Order List
        /// <summary>
        /// returns order list
        /// </summary>
        /// <returns></returns>
        public List<BE.Order> GetOrderList()
        {
            try
            {
              


                var orderList = from newOrder in dalAccess.GetOrderList()
                                orderby newOrder.OrderKey
                                select newOrder;
               return orderList.ToList();


            }
            catch (Exception e)
            {
                throw e;
            }
        }
        #endregion
        #region Get Branches
        /// <summary>
        /// returns list of bank branches
        /// </summary>
        /// <returns></returns>
        public List<BE.BankBranches> GetBranches()
        {
            try
            {

                var bankList = (from newBank in dalAccess.GetBranches()
                                orderby newBank.BankNumber
                                select newBank);

                var banks = bankList.GroupBy(i => new
                {
                    i.BranchNumber,
                    i.BankNumber,
                    i.BankName
                }).Select(i => i.First()).ToList();
                return banks;


            }
            catch (Exception e)
            {
                throw e;
            }
        }
        #endregion
        #region Update Host Private Name
        /// <summary>
        /// updates a host's private name
        /// </summary>
        /// <param name="host"></param>
        /// <param name="newName"></param>
        public void UpdateHostPrivateName(BE.Host host, string newName)
        {
            if (!dalAccess.GetHostingUnitList().Any(y => y.Owner.HostKey == host.HostKey))
                throw new NullReferenceException("the host doesn't exist ");
            var x = (from newHost in dalAccess.GetHostingUnitList()
                     where newHost.Owner.HostKey == host.HostKey
                     select newHost).FirstOrDefault();
            if (x.Owner.PrivateName == newName)
                throw new InvalidDataException("the host already has that name");
            try
            {
                dalAccess.UpdateHostPrivateName(x.Owner, newName);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        #endregion
        #region Update Host Family Name 
        /// <summary>
        /// uodates a host's family name
        /// </summary>
        /// <param name="host"></param>
        /// <param name="newName"></param>
        public void UpdateHostFamilyName(BE.Host host, string newName)
        {
            if (!GetHostingUnitList().Any(y => y.Owner.HostKey == host.HostKey))
                throw new NullReferenceException("the host doesn't exist ");
            var x = (from newHost in dalAccess.GetHostingUnitList()
                     where newHost.Owner.HostKey == host.HostKey
                     select newHost).FirstOrDefault();
            if (x.Owner.FamilyName == newName)
                throw new InvalidDataException("the host already has that name");
            try
            {
                dalAccess.UpdateHostFamilyName(x.Owner, newName);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        #endregion
        #region Update Guest Private Name
        /// <summary>
        /// updates a guests private name
        /// </summary>
        /// <param name="guest"></param>
        /// <param name="newName"></param>
        public void UpdateGuestPrivateName(BE.GuestRequest guest, string newName)
        {

            if (!dalAccess.GetGuestList().Any(x => x.GuestRequestKey == guest.GuestRequestKey))
                throw new NullReferenceException("the guest doesn't exist ");
            var y = (from newGuest in dalAccess.GetGuestList()
                     where newGuest.GuestRequestKey == guest.GuestRequestKey
                     select newGuest).FirstOrDefault();
            if (y.PrivateName == newName)
                throw new InvalidDataException("the guest already has that name");
            try
            {
                dalAccess.UpdateGuestPrivateName(y, newName);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        #endregion
        #region Update Guest Family Name
        /// <summary>
        /// updates a guests family name
        /// </summary>
        /// <param name="guest"></param>
        /// <param name="newName"></param>
        public void UpdateGuestFamilyName(BE.GuestRequest guest, string newName)
        {
            if (!dalAccess.GetGuestList().Any(y => y.GuestRequestKey == guest.GuestRequestKey))
                throw new NullReferenceException("the guest doesn't exist ");
            var x = (from newGuest in dalAccess.GetGuestList()
                     where newGuest.GuestRequestKey == guest.GuestRequestKey
                     select newGuest).FirstOrDefault();
            if (x.PrivateName == newName)
                throw new InvalidDataException("the guest already has that name");
            try
            {
                dalAccess.UpdateGuestFamilyName(x, newName);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        #endregion
        #region Update Hosting Unit Size
        public void UpdateHostingUnitSize(BE.HostingUnit unit, int size)
        {
            try
            {
                if (!GetHostingUnitList().Any(y => y.HostingUnitKey == unit.HostingUnitKey))
                throw new NullReferenceException("the unit doesn't exist ");
            var x = (from hostingUnit in GetHostingUnitList()
                     where hostingUnit.HostingUnitKey == unit.HostingUnitKey
                     select hostingUnit).FirstOrDefault();
            if (x.Size == size)
                throw new InvalidDataException("the hosting unit is already that size");
          
                dalAccess.UpdateHostingUnitSize(x, size);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        #endregion
        #region Get Available Units
        /// <summary>
        /// returns list of available units for requested amount of days
        /// </summary>
        /// <param name="date"></param>
        /// <param name="VacationDays"></param>
        /// <returns></returns>
        public List<BE.HostingUnit> GetAvailableUnits(DateTime date, int VacationDays)
        {
            try
            {
                List<HostingUnit> list = new List<HostingUnit>();
                int helper = 0;
                bool flag = true;
                foreach (var unit in GetHostingUnitList())
                {
                    helper = 0;
                    flag = true;
                    for (int i = date.Month - 1; i < 12; i++)// checks if the dates are taken
                        for (int j = 0; j < 31; j++)
                        {
                            if (helper < VacationDays)
                            {
                                if ((j >= (date.Day - 1)) || (helper > 0 && helper < VacationDays))
                                {
                                    if (helper < VacationDays)
                                    {
                                        if (unit.Diary[i, j] == true)

                                        {
                                            flag = false;
                                        }
                                    }
                                }


                            }
                            helper++;
                        }
                    if (flag == true)
                        list.Add(unit);
                }
                return list;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        #endregion
        #region Get Days
        /// <summary>
        /// returns number of days between two dates
        /// </summary>
        /// <param name="dates"></param>
        /// <returns></returns>
        public int GetDays(params DateTime[] dates)
        {
            try
            {
                if (dates.Length <= 0 || dates.Length > 2)
                    throw new InvalidDataException("invalid amount of dates");
                if (dates.Length == 1)
                {
                    return Math.Abs((dates[0] - DateTime.Now).Days);

                }
                else
                if (dates.Length == 2)
                {

                    return Math.Abs((dates[1] - dates[0]).Days);

                }
                else
                {
                    return 0;
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        #endregion
        #region Open Orders
        /// <summary>
        /// returns list of open orders
        /// </summary>
        /// <param name="days"></param>
        /// <returns></returns>
        public List<BE.Order> OpenOrders(int days)
        {
            try
            {
                List<Order> list = new List<Order>();
                foreach (var order in dalAccess.GetOrderList())
                {
                    if (order.Status == OrderStatus.email_sent || order.Status == OrderStatus.not_dealt_with)
                    {
                        if (DateTime.Now.Day - order.CreateDate.Day >= days || DateTime.Now.Day - order.OrderDate.Day >= days)
                        {
                            list.Add(order);
                        }
                    }

                }
                return list;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        #endregion
        #region Get Guests Partial List By Predicate
        /// <summary>
        /// returns partial guest list by using a predicate
        /// </summary>
        /// <param name="func"></param>
        /// <returns></returns>
        public List<BE.GuestRequest> GetGuestsPartialListByPredicate(Func<GuestRequest, bool> func)
        {
            try
            {
                var patialGuestList = (from item in dalAccess.GetGuestList() where func(item) orderby item.FamilyName, item.PrivateName select item).ToList();
                return patialGuestList;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        #endregion
        #region Number Of Guest Orders
        /// <summary>
        /// returns the number of orders the selected guest has received
        /// </summary>
        /// <param name="guest"></param>
        /// <returns></returns>
        public int NumberOfGuestOrders(BE.GuestRequest guest)
        {
            try
            {
                //int sum = 0;
                //foreach(var order in GetOrderList())
                //{
                //    if (order.GuestRequestKey == guest.GuestRequestKey)
                //        sum++;
                //}
                //return sum;
               return dalAccess.GetOrderList().Count(y => y.GuestRequestKey == guest.GuestRequestKey);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        #endregion
        #region Number Of Unit Orders
        /// <summary>
        /// returns the number of orders the requested unit has
        /// </summary>
        /// <param name="unit"></param>
        /// <returns></returns>
        public int NumberOfUnitOrders(BE.HostingUnit unit)
        {
            try
            {
                return dalAccess.GetOrderList().Count(y => y.HostingUnitKey == unit.HostingUnitKey);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        #endregion
        #region  Number Of Successful Orders
        /// <summary>
        /// returns the number of successful orders a hosting unit has
        /// </summary>
        /// <param name="unit"></param>
        /// <returns></returns>
        public int NumberOfSuccessfullOrders(BE.HostingUnit unit)
        {
            try
            {
                return dalAccess.GetOrderList().Count(y => y.HostingUnitKey == unit.HostingUnitKey && y.Status == OrderStatus.customer_accepted);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        #endregion
        #region Get Grouped By Area
        /// <summary>
        /// groups guest requests by the desired area
        /// </summary>
        /// <returns></returns>
        public IEnumerable<IGrouping<Area, GuestRequest>> GetGroupedByArea()
        {
            try
            {
                return from request in dalAccess.GetGuestList()
                       orderby request.GuestRequestKey
                       group request by request.area
                            into g
                       orderby g.Key
                       select g;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        #endregion
        #region Get Grouped By Number Of Vacations
        /// <summary>
        /// groups guest requests by the of vacations they ordered
        /// </summary>
        /// <returns></returns>
        public IEnumerable<IGrouping<int, GuestRequest>> GetGroupedByNumberOfVacations()
        {
            try
            {
                return from request in dalAccess.GetGuestList()
                       orderby request.GuestRequestKey
                       group request by NumberOfGuestOrders(request)
                            into g
                       orderby g.Key
                       select g;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        #endregion
        #region Get Grouped By Number Of Units
        /// <summary>
        /// groups hosting units by their owner
        /// </summary>
        /// <returns></returns>
        public IEnumerable<IGrouping<int, HostingUnit>> GetGroupedByNumberOfUnits()
        {
            try
            {
                return from host in dalAccess.GetHostingUnitList()
                       orderby host.Owner.HostKey
                       group host by host.Owner.HostKey
                            into g
                       orderby g.Key
                       select g;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        #endregion
        #region Get Grouped By Unit Area
        /// <summary>
        /// groups hosting units by their area
        /// </summary>
        /// <returns></returns>
        public IEnumerable<IGrouping<Area, HostingUnit>> GetGroupedByUnitArea()
        {
            try
            {
                return from unit in dalAccess.GetHostingUnitList()
                       orderby unit.HostingUnitKey
                       group unit by unit.area
                            into g
                       orderby g.Key
                       select g;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        #endregion
        #region Get Units In Tel Aviv With Pool And Jacuzzi
        /// <summary>
        /// returns a list of units in tel aviv that have  a pool and jacuzzi
        /// </summary>
        /// <returns></returns>
        public List<HostingUnit> GetUnitsInTelAvivWithPoolAndJacuzzi()
        {
            try
            {
                List<HostingUnit> list = new List<HostingUnit>();
                foreach (var unit in dalAccess.GetHostingUnitList())
                {
                    if (unit.pool == Pool.yes && unit.jacuzzi == Jacuzzi.yes && unit.area == Area.tel_aviv)
                        list.Add(unit);

                }


                if (list == null)
                    throw new InvalidOperationException("there are no units in tel aviv that have a pool and a jacuzzi");
                return list;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        #endregion
        #region Get Grouped By Bank Name
        /// <summary>
        /// groups bank by their names
        /// </summary>
        /// <returns></returns>
        public IEnumerable<IGrouping<string, BankBranches>> GetGroupedByBankName()
        {
            try
            {
                return from bank in dalAccess.GetBranches()
                       orderby bank.BankNumber
                       group bank by bank.BankName
                            into g
                       orderby g.Key
                       select g;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        #endregion
        #region Get Guests That Want To Smoke and Have Children
        /// <summary>
        /// gets list of guests that want to smoke and have children
        /// </summary>
        /// <returns></returns>
        public List<GuestRequest> GetGuestsWithChildrenAndWantToSmoke()
        {
            try
            {
                List<GuestRequest> list = new List<GuestRequest>();
                foreach (var guest in dalAccess.GetGuestList())
                {
                    if (guest.smoking == Smoking.yes && guest.Children > 0)
                        list.Add(guest);
                }
                if (list == null)
                    throw new NullReferenceException("there are no guests that want to smoke and have children");
                return list;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        #endregion
        #region Get Hosts Partial List By Predicate
        /// <summary>
        /// gets a partial list of hosts by using a predicate
        /// </summary>
        /// <param name="func"></param>
        /// <returns></returns>
        public List<BE.HostingUnit> GetHostsPartialListByPredicate(Func<Host, bool> func)
        {
            try
            {
                var partialUnitList = (from item in dalAccess.GetHostingUnitList()
                                       where func(item.Owner)
                                       orderby item.Owner.FamilyName, item.Owner.PrivateName
                                       select item).ToList();
                return partialUnitList;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        #endregion

        #region Get Grouped By No Tv and No Wifi
        /// <summary>
        /// groups hosting units by if they have tv and or wifi
        /// </summary>
        /// <returns></returns>
        public IEnumerable<IGrouping<bool, HostingUnit>> GetGroupedByNoTelevisionAndWifi()
        {
            try
            {
                return from unit in dalAccess.GetHostingUnitList()
                       orderby unit.HostingUnitKey
                       group unit by unit.wifi == Wifi.no && unit.tv == Television.no
                            into g
                       orderby g.Key
                       select g;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        #endregion
        
        #region Get Banks In Jerusalem
        /// <summary>
        /// returns list of banks that are in jerusalem
        /// </summary>
        /// <returns></returns>
        public List<BankBranches> GetBankInJerusalem()
        {
            try
            {
                List<BankBranches> list = new List<BankBranches>();
                foreach (var bank in GetBranches())
                {
                    if (bank.BranchCity == "ירושלים")
                        list.Add(bank);
                }
                if (list == null)
                    throw new NullReferenceException("there are no banks in Jerusalem");
                return list;
            }
            catch(Exception e)
            {
                throw e;
            }
        }
        #endregion
        
        #region Get Grouped By Unit Popularity
        /// <summary>
        /// groups units by the amount of times they have been ordered
        /// </summary>
        /// <returns></returns>
        public IEnumerable<IGrouping<int, Order>> GetGroupedByUnitPopularity()
        {
            try
            {
                return from order in dalAccess.GetOrderList()
                       orderby order.OrderKey
                       group order by order.HostingUnitKey
                            into g
                       orderby g.Key
                       select g;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        #endregion
        #region pay day
        /// <summary>
        /// returns the amount of money website made
        /// </summary>
        /// <returns></returns>
        public int PayDay()
        {
            int sum = 0;
            foreach (var host in dalAccess.GetHostingUnitList())

            {
                sum += host.Owner.PaymentOwed;
            }
            return sum;
        }
        #endregion
        #region get branch numbers
        /// <summary>
        /// gets branch numbers based on a bank name
        /// </summary>
        /// <param name="bankName"></param>
        /// <returns></returns>
        public List<int> GetBranchNumbers(string bankName)
        {
            try
            {
                var v = from branch in GetBranches()
                        where branch.BankName == bankName
                        select branch.BranchNumber;

                List<int> l = v.ToList().Distinct().ToList();
                l.Sort();
                return l;
            }
            catch(Exception e)
            {
                throw e;
            }
        }
        #endregion
        #region get bank names
        /// <summary>
        /// returns the names of the banks
        /// </summary>
        /// <returns></returns>
        public List<string> getBankNames()
        {
            try
            {
                var v = from branch in GetBranches() select branch.BankName;
                return v.ToList().Distinct().ToList();
            }
            catch(Exception e)
            {
                throw e;
            }

        }
        #endregion
        #region get bank by name and branch number
        /// <summary>
        /// finds and returns a bank based on the name and branch number recieved
        /// </summary>
        /// <param name="num"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        public BE.BankBranches GetBranchByNumberAndName(int num,string name)
        {
            try
            {
                foreach (BE.BankBranches b in GetBranches())
                    if (b.BranchNumber == num && b.BankName == name)
                        return b;
                return new BE.BankBranches();
            }
            catch(Exception e)
            {
                throw e;
            }
        }
        #endregion
        #region email
        /// <summary>
        /// function to send an email to a guest
        /// </summary>
        /// <param name="to"></param>
        /// <param name="subject"></param>
        /// <param name="body"></param>
        public void SendMail(string to, string subject, string body)
        {
            try
            {
                MailMessage message = new MailMessage();
                message.Subject = subject;
                message.From = new MailAddress(Configuration.emailAddress);
                message.Body = body;
                message.To.Add(to);
                SmtpClient smtp = new SmtpClient("smtp.Gmail.com");
                smtp.UseDefaultCredentials = false;
                smtp.EnableSsl = true;
                smtp.DeliveryMethod = SmtpDeliveryMethod.Network;

                smtp.Credentials = new NetworkCredential(Configuration.emailAddress, Configuration.emailPassword);
                smtp.EnableSsl = true;
                smtp.Port = 587;
                smtp.Send(message);
            }
            catch(Exception e)
            {
                throw e;
            }
        }

        #endregion
        #region number of canceled orders
        /// <summary>
        /// returns the number of canceled orders
        /// </summary>
        /// <returns></returns>
        public int numberOfCanceledOrders()
        {
            try
            {
                int sum = 0;
                foreach(var x in GetOrderList())
                {
                    if(x.Status==OrderStatus.customer_canceled)
                    {
                        sum++;
                    }
                }
                return sum;
            }
            catch(Exception e)
            {
                throw e;
            }
        }
        #endregion
        #region number of accepted orders
        /// <summary>
        /// returns the number of approved orders
        /// </summary>
        /// <returns></returns>
        public int numberOfAcceptedOrders()
        {
            try
            {
                int sum = 0;
                foreach (var x in GetOrderList())
                {
                    if (x.Status == OrderStatus.customer_accepted)
                    {
                        sum++;
                    }
                }
                return sum;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        #endregion

    }

}

