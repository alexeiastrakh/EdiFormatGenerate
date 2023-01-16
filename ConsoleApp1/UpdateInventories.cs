using System;
using System.Xml;
using System.Xml.Linq;

namespace ConsoleApp1
{
    class UpdateInventories
    {
        public static void updateInventories()
        {
         
            XmlDocument xdoc = new XmlDocument();
            xdoc.Load(@"../../../OrdersFile/NewOrders.xml");
            XmlNodeList listQtyOdered = xdoc.SelectNodes("//qtyOrdered");
            XmlNodeList listDescription = xdoc.SelectNodes("//description");
            XmlNodeList listUnitCost = xdoc.SelectNodes("//unitCost");
            List<String> UpdateInventoriesElements = new List<String>();
            List<String> StringUpdateInventoriesTegs = new List<String>();
            int counter = 0;

            while (counter != listQtyOdered.Count)
            {
                UpdateInventoriesElements.Add(listQtyOdered.Item(counter).InnerText);
                UpdateInventoriesElements.Add(listDescription.Item(counter).InnerText);
                UpdateInventoriesElements.Add(listUnitCost.Item(counter).InnerText);

                StringUpdateInventoriesTegs.Add("qtyOrdered");
                StringUpdateInventoriesTegs.Add("description");
                StringUpdateInventoriesTegs.Add("unitCost");
              



                counter++;
            }
            int counterUpdateInventoriesString = 0;
            List<String> data = UpdateInventoriesElements;
            XElement root = new XElement("INVRPT",
                                        from item in data
                                        select new XElement(StringUpdateInventoriesTegs[counterUpdateInventoriesString++], item));

            root.Save(@"../../../EdiGeneratedFiles/UpdateInventories.INVRPT");



        }
    }



    }

