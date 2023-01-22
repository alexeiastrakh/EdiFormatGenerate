using System.Xml.Serialization;
using System;
using System.Xml;
using System.Xml.Linq;

namespace EdiFileGenenator
{
    class XMLReadandParse
    {
        public static void Main(string[] args)
        {
            //Console.WriteLine("Please enter path to order file");
            // String pathOrderFile = Console.ReadLine();
            //if you want to set the file yourself recomment the line 12,13 and comment 15 line
            var doc = XDocument.Load(@"../../../OrderMessageBatch.xml");
            System.Xml.Serialization.XmlSerializer reader =
            new System.Xml.Serialization.XmlSerializer(typeof(OrderMessageBatch));
            System.IO.StreamReader file = new System.IO.StreamReader(
               @"../../../OrderMessageBatch.xml");
            OrderMessageBatch orderMessageBatch = (OrderMessageBatch)reader.Deserialize(file);
            file.Close();
            Console.WriteLine("Select the type of file you want to generate,press 1 if acknowledgment file , press 2 if shipment file," +
                " press 3 if invoice file, press 4 if update inventories file, press 5 if all files");
            string selection = Console.ReadLine();
            switch (selection)
            {
                    case "1": AcknowledgmentGenerator.acknowledgmentGenerate(orderMessageBatch); break;
                    case "2": ShipmentFileGenerator.shipmentFileGenerate(orderMessageBatch); break;
                    case "3": InvoiceFileGenerator.invoiceFileGenerate(orderMessageBatch); break;
                    case "4":  UpdateInventories.updateInventories(orderMessageBatch); break;
                    case "5": AcknowledgmentGenerator.acknowledgmentGenerate(orderMessageBatch);
                    ShipmentFileGenerator.shipmentFileGenerate(orderMessageBatch);
                    InvoiceFileGenerator.invoiceFileGenerate(orderMessageBatch);
                    UpdateInventories.updateInventories(orderMessageBatch); break;
            }

          


        }

    }
}
