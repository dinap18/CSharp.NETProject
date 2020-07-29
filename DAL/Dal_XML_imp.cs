using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Xml.Serialization;
using System.ComponentModel;
using DS;
using BE;
using System.Net;
using System.Xml;
using System.Globalization;

namespace DAL
{
    public class Dal_XML_imp : Idal
    {
        #region definitons
        /// <summary>
        /// roots and paths for xml files
        /// </summary>
        XElement orderRoot;
        XElement GuestRequestRoot;
        XElement configRoot;
        XElement hostingUnitRoot;
        XElement bankRoot;
        string guestRequestPath = @"GuestRequestXML.xml";
        string bankPath = @"atm.xml";
        string orderPath = @"OrderXML.xml";
        string HostingUnitPath = @"HostingUnitXML.xml";
        string configPath = @"ConfigXML.xml";
        BackgroundWorker bg = new BackgroundWorker();
        /// <summary>
        /// constuctor
        /// </summary>
        public Dal_XML_imp()
        {
            try
            {
                if (!File.Exists(orderPath))
                {
                    orderRoot = new XElement("orders");
                    orderRoot.Save(orderPath);
                }
                else
                    LoadDataOrder();

                if (!File.Exists(configPath))
                    CreateFilesCode();
                LoadDataCode();


                if (!File.Exists(guestRequestPath))
                {
                    GuestRequestRoot = new XElement("guestRequests");
                    GuestRequestRoot.Save(guestRequestPath);
                }
                else
                    LoadDataGuestRequest();

                if (!File.Exists(HostingUnitPath))
                {
                    hostingUnitRoot = new XElement("hostingUnits");
                    hostingUnitRoot.Save(HostingUnitPath);
                }
                else
                    LoadDataHostingUnit();
                bg.DoWork += Bg_DoWork;
                bg.RunWorkerAsync();

            }
            catch(Exception e)
            {
                throw e;
            }

        }

        private void Bg_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                LoadBankData();
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
        #endregion
        #region create and load files
        /// <summary>
        /// creates xml file for orders
        /// </summary>
        private void CreateFilesOrder()
        {
            try
            {


                orderRoot = new XElement("orders");
                orderRoot.Save(orderPath);
            }
            catch(Exception e)
            {
                throw e;
            }
        }
        /// <summary>
        /// creates xml file for config
        /// </summary>
        private void CreateFilesCode()
        {
            try
            {


                XElement requestCode = new XElement("RequestKey", "1000000");
                XElement unitCode = new XElement("UnitKey", "2000000");
                XElement orderCode = new XElement("OrderKey", "3000000");
                XElement comissionCode = new XElement("commision", "10");
                XElement EmailAddress = new XElement("EmailAddress", "dinaandevecsharpproject@gmail.com");
                XElement emailPassword = new XElement("emailPassword", "dinaandeve");
                DateTime date = new DateTime(2019, 8, 3);
                string dateString = date.ToString();
                XElement OrderChecker = new XElement("OrderChecker", dateString);
                configRoot = new XElement("Config", requestCode, unitCode, orderCode, comissionCode, EmailAddress, emailPassword, OrderChecker);
                configRoot.Save(configPath);
            }
            catch(Exception e)
            {
                throw e;
            }
            
        }
        /// <summary>
        /// loads content of order file
        /// </summary>
        private void LoadDataOrder()
        {
            try
            {
                orderRoot = XElement.Load(orderPath);

            }
            catch
            {
                throw new InvalidOperationException("problem uploading file");
            }
        }
        /// <summary>
        /// loads content of guest request file
        /// </summary>
        private void LoadDataGuestRequest()
        {
            try
            {
                GuestRequestRoot = XElement.Load(guestRequestPath);

            }
            catch
            {
                throw new InvalidOperationException("problem uploading file");
            }
        }
        /// <summary>
        /// loads content of hosting unit file
        /// </summary>
        private void LoadDataHostingUnit()
        {
            try
            {
                hostingUnitRoot = XElement.Load(HostingUnitPath);

            }
            catch
            {
                throw new InvalidOperationException("problem uploading file");
            }
        }
        /// <summary>
        /// loads content of config file
        /// </summary>
        private void LoadDataCode()
        {
            try
            {
                configRoot = XElement.Load(configPath);
                Configuration.commision = int.Parse(configRoot.Element("commision").Value);
                Configuration.emailAddress = configRoot.Element("EmailAddress").Value;
                Configuration.emailPassword = configRoot.Element("emailPassword").Value;
                string date = configRoot.Element("OrderChecker").Value;
                Configuration.orderChecker = Convert.ToDateTime(date);
            }
            catch
            {
                throw new InvalidOperationException("problem uploading file");
            }
        }
        /// <summary>
        /// loads bank data
        /// </summary>
        const string xmlLocalPath = @"atm.xml";
        WebClient wc = new WebClient();
        void LoadBankData()
        {
            if (!File.Exists(bankPath))
            {
                try
                {

                    string xmlServerPath = @"http://www.boi.org.il/he/BankingSupervision/BanksAndBranchLocations/Lists/BoiBankBranchesDocs/atm.xml";
                    wc.DownloadFile(xmlServerPath, xmlLocalPath);



                }
                catch (Exception)
                {
                    string xmlServerPath = @"http://www.jct.ac.il/~coshri/atm.xml";
                    wc.DownloadFile(xmlServerPath, xmlLocalPath);
                }
                finally
                {
                    wc.Dispose();
                }
            }
                bankRoot = XElement.Load(xmlLocalPath);
        }

     

      
        #endregion
        #region bank functions
        /// <summary>
        /// returns list of all banks
        /// </summary>
        /// <returns></returns>
        public List<BankBranches> GetBranches()
        {
            try
            {


                if (bankRoot == null)
                    throw new InvalidOperationException("list is loading");
                var it = (from item in bankRoot.Elements()
                          select ConvertBank(item).Clone()).ToList();
                return it;
            }
            catch(Exception e)
            {
                throw e;
            }
        }
        /// <summary>
        /// converts bank to type of bank branches from xml
        /// </summary>
        /// <param name="element"></param>
        /// <returns></returns>
        BankBranches ConvertBank(XElement element)
        {
            try
            {

                BankBranches bank = new BankBranches();
                bank.BankName = element.Element("שם_בנק").Value;
                bank.BankNumber = int.Parse(element.Element("קוד_בנק").Value);
                bank.BranchNumber = int.Parse(element.Element("קוד_סניף").Value);
                bank.BranchAddress = element.Element("כתובת_ה-ATM").Value;
                bank.BranchCity = element.Element("ישוב").Value;
                return bank;
            }
            catch(Exception e)
            {
                throw e;
            }
        }
        #endregion
        #region order functions
        /// <summary>
        /// converts order to xml element
        /// </summary>
        /// <param name="order"></param>
        /// <returns></returns>
        XElement ConvertOrder(BE.Order order)
        {
            try
            {
                XElement OrderElement = new XElement("order");
            OrderElement.Add(new XElement("GuestRequestKey", order.GuestRequestKey));
            OrderElement.Add(new XElement("HostingUnitKey", order.HostingUnitKey));
            OrderElement.Add(new XElement("OrderKey", order.OrderKey));
            OrderElement.Add(new XElement("Status", order.Status));
            OrderElement.Add(new XElement("CreateDate", order.CreateDate));
            OrderElement.Add(new XElement("OrderDate", order.OrderDate));
            return OrderElement;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        /// <summary>
        /// converts xml element to an order
        /// </summary>
        /// <param name="element"></param>
        /// <returns></returns>
         BE.Order ConvertOrder(XElement element)
        {
            try
            {
                BE.Order order = new BE.Order();

                order.GuestRequestKey = int.Parse((element.Element("GuestRequestKey").Value));
                order.HostingUnitKey = int.Parse((element.Element("HostingUnitKey").Value));
                order.OrderKey = int.Parse((element.Element("OrderKey").Value));
                order.Status = (BE.OrderStatus)Enum.Parse(typeof(BE.OrderStatus), element.Element("Status").Value);
                order.OrderDate = Convert.ToDateTime((element.Element("OrderDate").Value));
                order.CreateDate = Convert.ToDateTime((element.Element("CreateDate").Value));

                return order;
            
             }
            catch(Exception e)
            {
                throw e;
            }
        }
        /// <summary>
        /// adds an order
        /// </summary>
        /// <param name="order"></param>
        public void AddOrder(BE.Order order)
        {
            try 
            { 
            LoadDataCode();
                XElement it = (from item in orderRoot.Elements()
                                     where int.Parse(item.Element("OrderKey").Value) == order.OrderKey
                                     select item).FirstOrDefault();
                if (it != null)
                    throw new InvalidOperationException("order already exists");
                int code = int.Parse(configRoot.Element("OrderKey").Value);
            order.OrderKey = code++;     
            configRoot.Element("OrderKey").Value = code.ToString();
            configRoot.Save(configPath);

         

            orderRoot.Add(ConvertOrder(order.Clone()));
            orderRoot.Save(orderPath);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        /// <summary>
        /// updates an order
        /// </summary>
        /// <param name="order"></param>
        public void UpdateOrderStatus(BE.Order order)
        {
            try
            {

            XElement toUpdate = (from item in orderRoot.Elements()
                                 where int.Parse(item.Element("OrderKey").Value) == order.OrderKey
                                 select item).FirstOrDefault();
            if (toUpdate == null)
                throw new NullReferenceException("Order with the same order key not found...");

            XElement updateOrder = ConvertOrder(order.Clone());

            toUpdate.ReplaceNodes(updateOrder.Elements());

            orderRoot.Save(orderPath);
            }
            catch (Exception e)
            {
                throw e;
            }

        }
     
        /// <summary>
        /// returns order list
        /// </summary>
        /// <returns></returns>


        public List<BE.Order> GetOrderList()
        {
            try
            { 
            LoadDataOrder();
            var it = (from item in orderRoot.Elements()
                      select ConvertOrder(item).Clone()).ToList();
            return it;
            }
            catch (Exception e)
            {
                throw new InvalidDataException("problem loading order list");
            }
        }

        #endregion
        #region guest request functions
        /// <summary>
        /// converts a guest request to xml element
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        XElement ConvertGuestRequest(GuestRequest request)
        {
            try 
            { 
            XElement requestElement = new XElement("guestRequest");
            requestElement.Add(  new XElement("GuestRequestKey", request.GuestRequestKey));
            requestElement.Add( new XElement("PrivateName",request.PrivateName));
            requestElement.Add(new XElement("FamilyName", request.FamilyName));
            requestElement.Add(new XElement("MailAddress", request.MailAddress));
            requestElement.Add(new XElement("Status", request.Status));
            requestElement.Add(new XElement("RegistrationDate", request.RegistrationDate));
            requestElement.Add(new XElement("EntryDate", request.EntryDate));
            requestElement.Add(new XElement("ReleaseDate", request.ReleaseDate));
            requestElement.Add(new XElement("area", request.area));
            requestElement.Add(new XElement("type", request.type));
            requestElement.Add(new XElement("Adults", request.Adults));
            requestElement.Add(new XElement("Children", request.Children));
            requestElement.Add(new XElement("pool", request.pool));
            requestElement.Add(new XElement("jacuzzi", request.jacuzzi));
            requestElement.Add( new XElement("wifi", request.wifi));
            requestElement.Add(new XElement("tv", request.tv));
            requestElement.Add(  new XElement("garden", request.garden));
            requestElement.Add(new XElement("childrensAttractions", request.childrensAttractions));
            requestElement.Add(new XElement("publicTransportation", request.publicTransportation));
            requestElement.Add(new XElement("view", request.view));
            requestElement.Add(new XElement("smoking", request.smoking));
            requestElement.Add(new XElement("roomService", request.roomService));
            requestElement.Add(new XElement("snackBar", request.snackBar));
         
            return requestElement;
            }
            catch (Exception e)
            {
                throw new InvalidDataException("problem coverting guest request for xml file");
            }
        }
        /// <summary>
        /// converts xml element to guest request
        /// </summary>
        /// <param name="element"></param>
        /// <returns></returns>
        GuestRequest ConvertGuestRequest(XElement element)
        {
            try
            { 
            GuestRequest request = new GuestRequest();
            request.GuestRequestKey = int.Parse(element.Element("GuestRequestKey").Value);
            request.PrivateName = element.Element("PrivateName").Value;
            request.FamilyName = element.Element("FamilyName").Value;
            request.MailAddress = element.Element("MailAddress").Value;
            request.Status =(BE.RequestStatus)Enum.Parse(typeof(RequestStatus),element.Element("Status").Value);
             request.RegistrationDate=  DateTime.Parse(element.Element("RegistrationDate").Value, CultureInfo.CreateSpecificCulture("he-IL"));
             request.EntryDate = DateTime.Parse(element.Element("EntryDate").Value, CultureInfo.CreateSpecificCulture("he-IL"));
             request.ReleaseDate = DateTime.Parse(element.Element("ReleaseDate").Value, CultureInfo.CreateSpecificCulture("he-IL"));

                // string regDate = element.Element("RegistrationDate").Value;
                //   request.RegistrationDate = Convert.ToDateTime(element.Element("RegistrationDate").Value);
                //  string eDate = element.Element("EntryDate").Value;
                //  request.EntryDate = Convert.ToDateTime(element.Element("EntryDate").Value);
                //   string rDate = element.Element("ReleaseDate").Value;
                // request.ReleaseDate= Convert.ToDateTime(element.Element("ReleaseDate").Value);
                request.area = (BE.Area)Enum.Parse(typeof(Area), element.Element("area").Value);
            request.type = (BE.Type)Enum.Parse(typeof(BE.Type), element.Element("type").Value);
            request.Adults = int.Parse(element.Element("Adults").Value);
            request.Children = int.Parse(element.Element("Children").Value);
            request.pool = (BE.Pool)Enum.Parse(typeof(Pool), element.Element("pool").Value);
            request.jacuzzi = (BE.Jacuzzi)Enum.Parse(typeof(Jacuzzi), element.Element("jacuzzi").Value);
            request.wifi = (BE.Wifi)Enum.Parse(typeof(Wifi), element.Element("wifi").Value);
            request.tv = (BE.Television)Enum.Parse(typeof(Television), element.Element("tv").Value);
            request.garden = (BE.Garden)Enum.Parse(typeof(Garden), element.Element("garden").Value);
            request.childrensAttractions = (BE.ChildrensAttractions)Enum.Parse(typeof(ChildrensAttractions), element.Element("childrensAttractions").Value);
            request.publicTransportation = (BE.PublicTransportation)Enum.Parse(typeof(PublicTransportation), element.Element("publicTransportation").Value);
            request.view = (BE.View)Enum.Parse(typeof(View), element.Element("view").Value);
            request.smoking = (BE.Smoking)Enum.Parse(typeof(Smoking), element.Element("smoking").Value);
            request.roomService = (BE.RoomService)Enum.Parse(typeof(RoomService), element.Element("roomService").Value);
            request.snackBar = (BE.SnackBar)Enum.Parse(typeof(SnackBar), element.Element("snackBar").Value);

            return request;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        /// <summary>
        /// adds a guest request
        /// </summary>
        /// <param name="guestrequest"></param>
        public void AddGuestRequest(GuestRequest guestrequest)
        {
            try
            { 
            XElement toAdd = (from item in GuestRequestRoot.Elements()
                              where int.Parse(item.Element("GuestRequestKey").Value) == guestrequest.GuestRequestKey
                              select item).FirstOrDefault();
            if (toAdd != null)
                throw new InvalidOperationException(string.Format("Attempt failed! Guest request with guest request key: {0} already exists.", guestrequest.GuestRequestKey));
            int code = int.Parse(configRoot.Element("RequestKey").Value);
            guestrequest.GuestRequestKey = code++;
            guestrequest.RegistrationDate = DateTime.Now;
            GuestRequestRoot.Add(ConvertGuestRequest(guestrequest.Clone()));
            GuestRequestRoot.Save(guestRequestPath);
            configRoot.Element("RequestKey").Value = code.ToString();
            configRoot.Save(configPath);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        /// <summary>
        /// updates a guest request
        /// </summary>
        /// <param name="guestRequest"></param>
        public void UpdateGuestRequest(BE.GuestRequest guestRequest)
        {
            try
            { 
            XElement toUpdate = (from item in GuestRequestRoot.Elements()
                                 where int.Parse(item.Element("GuestRequestKey").Value) == guestRequest.GuestRequestKey
                                 select item).FirstOrDefault();
            if (toUpdate == null)
                throw new InvalidOperationException(string.Format("Attempt failed! guest request: {0} doesnt exist.", guestRequest.GuestRequestKey));
            toUpdate.Element("GuestRequestKey").Value = guestRequest.GuestRequestKey.ToString();

            toUpdate.Element("PrivateName").Value = guestRequest.PrivateName;
            toUpdate.Element("FamilyName").Value = guestRequest.FamilyName;
            toUpdate.Element("MailAddress").Value = guestRequest.MailAddress;
            toUpdate.Element("Status").Value = guestRequest.Status.ToString();
            toUpdate.Element("RegistrationDate").Value = guestRequest.RegistrationDate.ToString();
            toUpdate.Element("EntryDate").Value = guestRequest.EntryDate.ToString();
            toUpdate.Element("ReleaseDate").Value = guestRequest.ReleaseDate.ToString();
            toUpdate.Element("area").Value = guestRequest.area.ToString();
            toUpdate.Element("type").Value = guestRequest.type.ToString();
            toUpdate.Element("Adults").Value = guestRequest.Adults.ToString();
            toUpdate.Element("Children").Value = guestRequest.Children.ToString();
            toUpdate.Element("pool").Value = guestRequest.pool.ToString();
            toUpdate.Element("jacuzzi").Value = guestRequest.jacuzzi.ToString();
            toUpdate.Element("wifi").Value = guestRequest.wifi.ToString();
            toUpdate.Element("tv").Value = guestRequest.tv.ToString();
            toUpdate.Element("garden").Value = guestRequest.garden.ToString();
            toUpdate.Element("childrensAttractions").Value = guestRequest.childrensAttractions.ToString();
            toUpdate.Element("publicTransportation").Value = guestRequest.publicTransportation.ToString();
            toUpdate.Element("view").Value = guestRequest.view.ToString();
            toUpdate.Element("smoking").Value = guestRequest.smoking.ToString();
            toUpdate.Element("roomService").Value = guestRequest.roomService.ToString();
            toUpdate.Element("snackBar").Value = guestRequest.snackBar.ToString();
            GuestRequestRoot.Save(guestRequestPath);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        /// <summary>
        /// returns guest request list
        /// </summary>
        /// <returns></returns>
        public List<BE.GuestRequest> GetGuestList()
        {
            LoadDataGuestRequest();
            var it = (from item in GuestRequestRoot.Elements()
                      select ConvertGuestRequest(item).Clone()).ToList();
            return it;

        }
        #endregion
        #region save and load from xml
        public static void SaveToXML<T>(T source, string path)
        {
            FileStream file = new FileStream(path, FileMode.Create);
            XmlSerializer xmlSer = new XmlSerializer(source.GetType());
            xmlSer.Serialize(file, source);
            file.Close();
        }
        public static T LoadFromXML<T>(string path)
        {
            FileStream file = new FileStream(path, FileMode.Open);
            XmlSerializer xmlSer = new XmlSerializer(typeof(T));
            T result = (T)xmlSer.Deserialize(file);
            file.Close();
            return result;
        }
        #endregion
        #region hosting unit functions
        /// <summary>
        /// converts hosting unit to xml element
        /// </summary>
        /// <param name="unit"></param>
        /// <returns></returns>
        XElement xConvertHostingUnit(HostingUnit unit)
        {
            try
            {
                var doc = new XDocument();
                using (XmlWriter writer = doc.CreateWriter())
                {
                    XmlSerializer ser = new XmlSerializer(unit.GetType());
                    ser.Serialize(writer, unit);
                }
                return doc.Root;

            }
            catch(Exception e)

            {
                throw e;
            }          
        }
        /// <summary>
        /// converts xml element to a hosting unit
        /// </summary>
        /// <param name="element"></param>
        /// <returns></returns>
        BE.HostingUnit ConvertHostingUnit(XElement element)
        {
            try
            {
                HostingUnit unit = new HostingUnit();
                var ser = new XmlSerializer(typeof(HostingUnit));
                return (HostingUnit)ser.Deserialize(element.CreateReader());

            }
            catch(Exception e)
            {
                throw e;
            }
        }
   
   
       /// <summary>
       /// adds a hosting unit
       /// </summary>
       /// <param name="unit"></param>
        public void AddHostingUnit(BE.HostingUnit unit)
        {
            try
            {
                var it = (from item in hostingUnitRoot.Elements()
                          where int.Parse(item.Element("HostingUnitKey").Value) == unit.HostingUnitKey
                          select item).FirstOrDefault();
                if (it != null)
                    throw new InvalidOperationException(string.Format("Attempt failed! hosting unit with key: {0} already exists.", unit.HostingUnitKey));
                int code = int.Parse(configRoot.Element("UnitKey").Value);
                unit.HostingUnitKey = code++;
                hostingUnitRoot.Add(xConvertHostingUnit(unit.Clone()));
                hostingUnitRoot.Save(HostingUnitPath);
                configRoot.Element("UnitKey").Value = code.ToString();
                configRoot.Save(configPath);
            }
            catch(Exception e)
            {
                throw e;
            }
        }
        /// <summary>
        /// deletes a hosting unit
        /// </summary>
        /// <param name="unit"></param>
        public void DeleteHostingUnit(BE.HostingUnit unit)
        {
            try
            {
                LoadDataHostingUnit();
                var it = (from item in hostingUnitRoot.Elements()
                          where int.Parse(item.Element("HostingUnitKey").Value) == unit.HostingUnitKey
                          select item).FirstOrDefault();
              
                it.Remove();
                hostingUnitRoot.Save(HostingUnitPath);
            }
            catch (Exception e)
            {
                throw new KeyNotFoundException(" cannot delete hosting unit");
            }
        }
        /// <summary>
        /// adds an updated hosting unit
        /// </summary>
        /// <param name="unit"></param>
        void AddUpdatedUnit(HostingUnit unit)
        {
            try
            {
                hostingUnitRoot.Add(xConvertHostingUnit(unit.Clone()));
                hostingUnitRoot.Save(HostingUnitPath);
            }
            catch(Exception e)
            {
                throw e;
            }
        }
        /// <summary>
        /// updates a hosting unit
        /// </summary>
        /// <param name="unit"></param>
        public void UpdateHostingUnit(BE.HostingUnit unit)
        {
            try
            {
                XElement toUpdate = (from item in hostingUnitRoot.Elements()
                                     where int.Parse(item.Element("HostingUnitKey").Value) == unit.HostingUnitKey
                                     select item).FirstOrDefault();
                if (toUpdate == null)
                    throw new InvalidOperationException(string.Format("Attempt failed! hosting unit: {0} doesnt exist.", unit.HostingUnitKey));
                DeleteHostingUnit(ConvertHostingUnit(toUpdate));
                AddUpdatedUnit(unit.Clone());
            }
            catch(Exception e)
            {
                throw e;
            }
        }
        /// <summary>
        /// returns list of hosting units
        /// </summary>
        /// <returns></returns>
        public List<BE.HostingUnit> GetHostingUnitList()
        {
            try
            {
                LoadDataHostingUnit();
                var it = (from item in hostingUnitRoot.Elements()
                          select ConvertHostingUnit(item).Clone()).ToList();
                return it;
            }
            catch(Exception e)
            {
                throw e;
            }

        }
        #endregion

        #region more functions

        /// <summary>
        /// updates a hosts first name
        /// </summary>
        /// <param name="host"></param>
        /// <param name="newName"></param>
        public void UpdateHostPrivateName(BE.Host host,string newName)
        {
            try
            {
                var it = (from item in hostingUnitRoot.Elements()
                          where int.Parse(item.Element("Host").Element("HostKey").Value) == host.HostKey
                          select ConvertHostingUnit( item)).FirstOrDefault();
               it.Owner.PrivateName = newName;
                UpdateHostingUnit(it.Clone());
            }
            catch(Exception e)
            {
                throw e;
            }
        }
        /// <summary>
        /// updates a host's last name
        /// </summary>
        /// <param name="host"></param>
        /// <param name="newName"></param>
        public void UpdateHostFamilyName(BE.Host host, string newName)
        {
            try
            {
                var it = (from item in hostingUnitRoot.Elements()
                          where int.Parse(item.Element("Host").Element("HostKey").Value) == host.HostKey
                          select ConvertHostingUnit(item)).FirstOrDefault();
                it.Owner.FamilyName = newName;
                UpdateHostingUnit(it.Clone());
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        /// <summary>
        /// updates a guests first name
        /// </summary>
        /// <param name="guest"></param>
        /// <param name="newName"></param>
        public void UpdateGuestPrivateName(BE.GuestRequest guest, string newName)
        {
            try
            {
                
                guest.PrivateName = newName;
                UpdateGuestRequest(guest.Clone());
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        /// <summary>
        /// updates a guest's last name
        /// </summary>
        /// <param name="guest"></param>
        /// <param name="newName"></param>
        public void UpdateGuestFamilyName(BE.GuestRequest guest, string newName)
        {
            try
            {

                guest.FamilyName = newName;
                UpdateGuestRequest(guest.Clone());
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        /// <summary>
        /// updates a hosting unit's size
        /// </summary>
        /// <param name="unit"></param>
        /// <param name="size"></param>
        public void UpdateHostingUnitSize(BE.HostingUnit unit, int size)
        {
            try
            {

                unit.Size = size;
                UpdateHostingUnit(unit.Clone());
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        /// <summary>
        /// updates date for config file to know if to check for expired orders
        /// </summary>
        /// <param name="date"></param>
        public void updateOrderCheckerDate(DateTime date)
        {
            try
            {
                configRoot.Element("OrderChecker").Value = date.ToString();
                configRoot.Save(configPath);
            }
            catch(Exception e)
            {
                throw e;
            }
        }
        #endregion
    }
}

