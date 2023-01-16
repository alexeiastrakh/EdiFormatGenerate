using System;
using System.Xml;
using System.Xml.Linq;

namespace ConsoleApp1
{
    class XMLReadandParse
    {
        static async Task Main(string[] args)
        {
            AcknowledgmentGenerator.acknowledgmentGenerate();
            ShipmentFileGenerator.shipmentFileGenerate();
            InvoiceFileGenerator.invoiceFileGenerate();
            UpdateInventories.updateInventories();
          

        }

    }
    }
