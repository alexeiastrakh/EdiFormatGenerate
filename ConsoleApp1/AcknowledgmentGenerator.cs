using System;
using System.Xml;
using System.Xml.Linq;

namespace ConsoleApp1
{
  class AcknowledgmentGenerator
    {
        public static void acknowledgmentGenerate()
        {
 
            xdoc.Load(@"../../../OrdersFile/NewOrders.xml");
            XmlNodeList listOrderId = xdoc.SelectNodes("//orderId");
            XmlNodeList listCustOrderNumber = xdoc.SelectNodes("//custOrderNumber");
            XmlNodeList listSendersIdForReceiver = xdoc.SelectNodes("//sendersIdForReceiver");
            XmlNodeList listOrderDate = xdoc.SelectNodes("//orderDate");
            XmlNodeList listQtyOrdered = xdoc.SelectNodes("//qtyOrdered");
            XmlNodeList listDescription = xdoc.SelectNodes("//description");
            XmlNodeList listUnitCost = xdoc.SelectNodes("//unitCost");
            List<String> AcknowledgmentElements = new List<String>();
            List<String> StringAcknowledgmentTegs = new List<String>();

            int counter = 0;
            int counterQtyOdered = 0;

            while (counter != listOrderId.Count)
            {
                AcknowledgmentElements.Add(listOrderId.Item(counter).InnerText);
                AcknowledgmentElements.Add(listCustOrderNumber.Item(counter).InnerText);
                AcknowledgmentElements.Add(listSendersIdForReceiver.Item(counter).InnerText);
                AcknowledgmentElements.Add(listOrderDate.Item(counter).InnerText);
                AcknowledgmentElements.Add(listQtyOrdered.Item(counter).InnerText);
                AcknowledgmentElements.Add(listDescription.Item(counter).InnerText);
                AcknowledgmentElements.Add(listUnitCost.Item(counter).InnerText);
                StringAcknowledgmentTegs.Add("orderId");
                StringAcknowledgmentTegs.Add("custOrderNumber");
                StringAcknowledgmentTegs.Add("sendersIdForReceiver");
                StringAcknowledgmentTegs.Add("orderDate");
                StringAcknowledgmentTegs.Add("qtyOrdered");
                StringAcknowledgmentTegs.Add("description");
                StringAcknowledgmentTegs.Add("unitCost");



                counter++;

            }
            int counterAcknowledgmentString = 0;
            List<String> data = AcknowledgmentElements;
            XElement root = new XElement("ORDRSP",
                                        from item in data
                                        select new XElement(StringAcknowledgmentTegs[counterAcknowledgmentString++], item)) ; 

             root.Save(@"../../../EdiGeneratedFiles/Acknowledgment.ODRSP");

        }     

    }

}
