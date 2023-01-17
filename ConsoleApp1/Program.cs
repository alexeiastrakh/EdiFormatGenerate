using EdiFileGenerator;
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
            String pathOrderFile = @"../../../NewOrders.xml";
            XmlDocument xdoc = new XmlDocument();
            xdoc.Load($@"{pathOrderFile}");
            ParserEdi.ParseEdi(pathOrderFile);
            AcknowledgmentGenerator.acknowledgmentGenerate(xdoc);
            ShipmentFileGenerator.shipmentFileGenerate(xdoc);
            InvoiceFileGenerator.invoiceFileGenerate(xdoc);
            UpdateInventories.updateInventories(xdoc);


        }

    }
}
