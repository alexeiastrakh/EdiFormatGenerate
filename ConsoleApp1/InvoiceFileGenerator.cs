using System;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace EdiFileGenenator
{
   public class InvoiceFileGenerator
    {
        [XmlAttribute(AttributeName = "transactionID")]
        public string TransactionID { get; set; }
        [XmlElement(ElementName = "invoiceTo")]
        public InvoiceTo InvoiceTo { get; set; }
        [XmlElement(ElementName = "offerCurrency")]
        public string OfferCurrency { get; set; }
      
        [XmlElement(ElementName = "personPlace")]
        public List<PersonPlace> PersonPlace { get; set; }
        public string PostalCode { get; set; }
        [XmlElement(ElementName = "merchandiseTypeCode")]
        public string MerchandiseTypeCode { get; set; }
     
        [XmlElement(ElementName = "freightPaymentTermsCode")]
        public string FreightPaymentTermsCode { get; set; }
        public static void invoiceFileGenerate(OrderMessageBatch orderMessageBatch)
        {
            
            List<HubOrder> hubOrders = orderMessageBatch.HubOrder;
            List<InvoiceFileGenerator> invoiceFileElements = new List<InvoiceFileGenerator>();
          
            PoHdrData poHdrData = new PoHdrData();
           foreach (HubOrder hubOrder in hubOrders)
            {
                InvoiceFileGenerator invoiceGenerator = new InvoiceFileGenerator();
                invoiceGenerator.TransactionID = hubOrder.TransactionID;
                invoiceGenerator.InvoiceTo = hubOrder.InvoiceTo;
                invoiceGenerator.PersonPlace = hubOrder.PersonPlace;            
                poHdrData = hubOrder.PoHdrData;
                invoiceGenerator.OfferCurrency = poHdrData.OfferCurrency;
                invoiceGenerator.MerchandiseTypeCode = poHdrData.MerchandiseTypeCode;
                invoiceGenerator.FreightPaymentTermsCode = poHdrData.FreightPaymentTermsCode;
                invoiceFileElements.Add(invoiceGenerator);
            }

            var xmlWriterSettings = new XmlWriterSettings() { Indent = true };
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<InvoiceFileGenerator>));

            using (XmlWriter xmlWriter = XmlWriter.Create(@"../../../Invoice.INVOIC", xmlWriterSettings))
            {
                xmlSerializer.Serialize(xmlWriter, invoiceFileElements);

                Console.WriteLine("File has been generated");
            }



        }



    }
}
