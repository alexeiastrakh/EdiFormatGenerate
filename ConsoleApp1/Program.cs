using System;
using System.Xml;
using System.Xml.Linq;

namespace ConsoleApp1
{
    class XMLReadandParse
    {
       public static Main(string[] args)
        {
            XmlDocument xdoc = new XmlDocument();
            xdoc.Load(@"../../../OrdersFile/NewOrders.xml");
            AcknowledgmentGenerator.acknowledgmentGenerate();
            ShipmentFileGenerator.shipmentFileGenerate();
            InvoiceFileGenerator.invoiceFileGenerate();
            UpdateInventories.updateInventories();
          

        }

    }
    }
