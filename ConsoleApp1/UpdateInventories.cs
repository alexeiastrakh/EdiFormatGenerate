using System;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace EdiFileGenenator
{
    public class UpdateInventories
    {
        [XmlElement(ElementName = "qtyOrdered")]
        public string QtyOrdered { get; set; }
        [XmlElement(ElementName = "description")]
        public string Description { get; set; }
        [XmlElement(ElementName = "unitCost")]
        public string UnitCost { get; set; }

        public static void updateInventories(OrderMessageBatch orderMessageBatch)
        {
    
            List<HubOrder> hubOrders = orderMessageBatch.HubOrder;
            List<UpdateInventories> UpdateInventoriesFileElements = new List<UpdateInventories>();
            List<LineItem> lineItems = new List<LineItem>();
            foreach (HubOrder hubOrder in hubOrders)
            {
              
                lineItems = hubOrder.LineItem;
                foreach(LineItem lineItem in lineItems)
                {
                    UpdateInventories updateInventories = new UpdateInventories();
                    updateInventories.QtyOrdered = lineItem.QtyOrdered;
                    updateInventories.Description = lineItem.Description;
                    updateInventories.UnitCost = lineItem.UnitCost;
                    UpdateInventoriesFileElements.Add(updateInventories);
                }
    
            }

            var xmlWriterSettings = new XmlWriterSettings() { Indent = true };
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<UpdateInventories>));

            using (XmlWriter xmlWriter = XmlWriter.Create(@"../../../UpdateInventories.INVRPT", xmlWriterSettings))
            {
                xmlSerializer.Serialize(xmlWriter, UpdateInventoriesFileElements);

                Console.WriteLine("File has been generated");
            }


        }
    }

}
