using System;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace EdiFileGenenator
{
   public class ShipmentFileGenerator
    {
        [XmlAttribute(AttributeName = "transactionID")]
        public string TransactionID { get; set; }
        [XmlElement(ElementName = "orderDate")]
        public string OrderDate { get; set; }
        [XmlElement(ElementName = "sendersIdForReceiver")]
        public string SendersIdForReceiver { get; set; }
        [XmlElement(ElementName = "shippingCode")]
        public string ShippingCode { get; set; }
        [XmlElement(ElementName = "custOrderNumber")]
        public string CustOrderNumber { get; set; }
        [XmlElement(ElementName = "merchantSKU")]
        public string MerchantSKU { get; set; }
        [XmlElement(ElementName = "expectedShipDate")]
        public string ExpectedShipDate { get; set; }

        public static void shipmentFileGenerate(OrderMessageBatch orderMessageBatch)
        {
            
            List<HubOrder> hubOrders = orderMessageBatch.HubOrder;
            List<ShipmentFileGenerator> ShipmentFileElements = new List<ShipmentFileGenerator>();
            List<LineItem> lineItems = new List<LineItem>();

            foreach (HubOrder hubOrder in hubOrders)
            {
                ShipmentFileGenerator shipmentFileGenerator = new ShipmentFileGenerator();
                shipmentFileGenerator.TransactionID = hubOrder.TransactionID;
                shipmentFileGenerator.SendersIdForReceiver = hubOrder.SendersIdForReceiver;
                shipmentFileGenerator.CustOrderNumber = hubOrder.CustOrderNumber;
                shipmentFileGenerator.OrderDate = hubOrder.OrderDate;
               lineItems = hubOrder.LineItem;
                foreach(LineItem lineItem in lineItems)
                {
                    shipmentFileGenerator.MerchantSKU = lineItem.MerchantSKU;
                    shipmentFileGenerator.ExpectedShipDate = lineItem.ExpectedShipDate;
                    shipmentFileGenerator.ShippingCode = lineItem.ShippingCode;
                }

                ShipmentFileElements.Add(shipmentFileGenerator);

            }
            var xmlWriterSettings = new XmlWriterSettings() { Indent = true };
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<ShipmentFileGenerator>));

            using (XmlWriter xmlWriter = XmlWriter.Create(@"../../../Shipment.DESADV", xmlWriterSettings))
            {
                xmlSerializer.Serialize(xmlWriter, ShipmentFileElements);

                Console.WriteLine("File has been generated");
            }

        }


    }
   
}
