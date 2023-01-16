using System;
using System.Xml;
using System.Xml.Linq;

namespace ConsoleApp1
{
    class ShipmentFileGenerator
    {
        public static void shipmentFileGenerate()
        {
 
            XmlDocument xdoc = new XmlDocument();
            xdoc.Load(@"../../../OrdersFile/NewOrders.xml");
            XmlNodeList listLineItemId = xdoc.SelectNodes("//lineItemId");
            XmlNodeList listOrderDate = xdoc.SelectNodes("//orderDate");
            XmlNodeList listSendersIdForReceiver = xdoc.SelectNodes("//sendersIdForReceiver");
            XmlNodeList listCustOrderNumber = xdoc.SelectNodes("//custOrderNumber");
            XmlNodeList listLineReqDelvDate = xdoc.SelectNodes("//lineReqDelvDate");
            XmlNodeList listShippingCode = xdoc.SelectNodes("//shippingCode");
            XmlNodeList listPostalCode = xdoc.SelectNodes("//postalCode");
            XmlNodeList listMerchantSKU = xdoc.SelectNodes("//merchantSKU");
            XmlNodeList listVendorSKU = xdoc.SelectNodes("//vendorSKU");
            XmlNodeList listOrderId = xdoc.SelectNodes("//orderId");
            List<String> ShipmentElements = new List<String>();
            List<String> StringShipmentTegs = new List<String>();
            int counter = 0;
           


            while (counter != listOrderId.Count)
            {
                ShipmentElements.Add(listOrderId.Item(counter).InnerText);
                ShipmentElements.Add(listOrderDate.Item(counter).InnerText);
                ShipmentElements.Add(listSendersIdForReceiver.Item(counter).InnerText);
                ShipmentElements.Add(listCustOrderNumber.Item(counter).InnerText);
                ShipmentElements.Add(listLineReqDelvDate.Item(counter).InnerText);
                ShipmentElements.Add(listShippingCode.Item(counter).InnerText);
                ShipmentElements.Add(listPostalCode.Item(counter).InnerText);
                ShipmentElements.Add(listMerchantSKU.Item(counter).InnerText);
                ShipmentElements.Add(listVendorSKU.Item(counter).InnerText);
                StringShipmentTegs.Add("lineItemId");
                StringShipmentTegs.Add("orderDate");
                StringShipmentTegs.Add("sendersIdForReceiver");
                StringShipmentTegs.Add("custOrderNumber");
                StringShipmentTegs.Add("lineReqDelvDate");
                StringShipmentTegs.Add("shippingCode");
                StringShipmentTegs.Add("postalCode");
                StringShipmentTegs.Add("merchantSKU");
                StringShipmentTegs.Add("vendorSKU");


                counter++;
               
            }
            int counterShipmentString = 0;
            List<String> data = ShipmentElements;
            XElement root = new XElement("DESADV",
                                        from item in data
                                        select new XElement(StringShipmentTegs[counterShipmentString++], item));

            root.Save(@"../../../EdiGeneratedFiles/Shipment.DESADV");


        }



    }
}
