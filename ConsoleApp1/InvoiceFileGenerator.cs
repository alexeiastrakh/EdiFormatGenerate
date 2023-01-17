using System;
using System.Xml;
using System.Xml.Linq;

namespace ConsoleApp1
{
    class InvoiceFileGenerator
    {
        public static void invoiceFileGenerate(XmlDocument xdoc)
        {
  
            
            XmlNodeList listLineReqDelvDate = xdoc.SelectNodes("//lineReqDelvDate");
            XmlNodeList listOfferCurrency = xdoc.SelectNodes("//offerCurrency");
            XmlNodeList listName1 = xdoc.SelectNodes("//name1");
            XmlNodeList listAddress1 = xdoc.SelectNodes("//address1");
            XmlNodeList listCity = xdoc.SelectNodes("//city");
            XmlNodeList listState = xdoc.SelectNodes("//state");
            XmlNodeList listCountry = xdoc.SelectNodes("//country");
            XmlNodeList listMerchandiseTypeCode = xdoc.SelectNodes("//merchandiseTypeCode");
            XmlNodeList listFreightPaymentTermsCode = xdoc.SelectNodes("//freightPaymentTermsCode");
            XmlNodeList listSalesAgent = xdoc.SelectNodes("//salesAgent");
            XmlNodeList listOrderId = xdoc.SelectNodes("//orderId");
            List<String> InvoiceElements = new List<String>();
           List<String> StringInvoiceTegs = new List<String>();

            int counter = 0;
            


            while (counter != listOrderId.Count)
            {
                InvoiceElements.Add(listLineReqDelvDate.Item(counter).InnerText);
                InvoiceElements.Add(listOfferCurrency.Item(counter).InnerText);
                InvoiceElements.Add(listName1.Item(counter).InnerText);
                InvoiceElements.Add(listAddress1.Item(counter).InnerText);
                InvoiceElements.Add(listCity.Item(counter).InnerText);
                InvoiceElements.Add(listState.Item(counter).InnerText);
                InvoiceElements.Add(listCountry.Item(counter).InnerText);
                InvoiceElements.Add(listMerchandiseTypeCode.Item(counter).InnerText);
                InvoiceElements.Add(listFreightPaymentTermsCode.Item(counter).InnerText);
                InvoiceElements.Add(listSalesAgent.Item(counter).InnerText);
                StringInvoiceTegs.Add("lineReqDelvDate");
                StringInvoiceTegs.Add("offerCurrency");
                StringInvoiceTegs.Add("name1");
                StringInvoiceTegs.Add("address1");
                StringInvoiceTegs.Add("city");
                StringInvoiceTegs.Add("state");
                StringInvoiceTegs.Add("country");
                StringInvoiceTegs.Add("merchandiseTypeCode");
                StringInvoiceTegs.Add("freightPaymentTermsCode");
                StringInvoiceTegs.Add("salesAgent");


                counter++;
                
            }
            int counterInvoiceString = 0;
            List<String> data = InvoiceElements;
            XElement root = new XElement("INVOIC",
                                        from item in data
                                        select new XElement(StringInvoiceTegs[counterInvoiceString++], item));

            root.Save(@"../../../EdiGeneratedFiles/Invoice.INVOIC");

        }



    }
}
