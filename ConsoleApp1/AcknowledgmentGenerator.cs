using System;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;
using EdiFileGenenator;

namespace EdiFileGenenator
{
   public class AcknowledgmentGenerator
    {
        [XmlAttribute(AttributeName = "transactionID")]
        public string TransactionID { get; set; }
        [XmlElement(ElementName = "orderId")]
        public string OrderId { get; set; }
        [XmlElement(ElementName = "sendersIdForReceiver")]
        public string SendersIdForReceiver { get; set; }
        [XmlElement(ElementName = "custOrderNumber")]
        public string CustOrderNumber { get; set; }
        [XmlElement(ElementName = "lineItemAcknowledgment")]
        public List<LineItem> LineItemAcknowledgments { get; set; }

        public static void acknowledgmentGenerate(OrderMessageBatch orderMessageBatch)
        {

            List<HubOrder> hubOrders = orderMessageBatch.HubOrder;
            List<AcknowledgmentGenerator> AcknowledgmentElements = new List<AcknowledgmentGenerator>();
          
           
            foreach (HubOrder hubOrder in hubOrders)
            {
                AcknowledgmentGenerator acknowledgmentGenerator = new AcknowledgmentGenerator();
                acknowledgmentGenerator.TransactionID = hubOrder.TransactionID;
                acknowledgmentGenerator.OrderId = hubOrder.OrderId;
                acknowledgmentGenerator.SendersIdForReceiver = hubOrder.SendersIdForReceiver;
                acknowledgmentGenerator.CustOrderNumber = hubOrder.CustOrderNumber;
                acknowledgmentGenerator.LineItemAcknowledgments = hubOrder.LineItem;
                AcknowledgmentElements.Add(acknowledgmentGenerator);

            }
            var xmlWriterSettings = new XmlWriterSettings() { Indent = true };
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<AcknowledgmentGenerator>));

            using (XmlWriter xmlWriter = XmlWriter.Create(@"../../../Acknowledgment.ODRSP", xmlWriterSettings))
            {
                xmlSerializer.Serialize(xmlWriter, AcknowledgmentElements);

                Console.WriteLine("File has been generated");
            }


        }

    }
  
}
