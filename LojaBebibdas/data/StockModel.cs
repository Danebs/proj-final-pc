using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using LojaDeBebidas.data.entidades;


namespace LojaDeBebidas.data
{
    class StockModel
    {
        protected const string DATA_PATH = @"..\\..\\data/xml/Products.xml";
        protected Product[] Prods = new Product[] { };

        public StockModel() { this.Prods = this.LoadProducts(); }

        public Product[] All() { return this.Prods; }

        public Product FindByID(int cod)
        {
            Product product = null;

            for (int i = 0; i < this.Prods.Length; i++)
            {
                if (this.Prods[i].ID == cod)
                {
                    return this.Prods[i];
                }
            }

            return product;
        }

        public Product FindByName(string nome)
        {
            Product product = null;

            for (int i = 0; i < this.Prods.Length; i++)
            {
                if (this.Prods[i].Name.ToLower() == nome.ToLower())
                    return this.Prods[i];

            }

            return product;
        }

        private Product[] LoadProducts()
        {
            List<Product> productList = new List<Product>();

            XElement xml = XElement.Load(DATA_PATH);
     
            foreach (XElement x in xml.Elements())
            {
                Product prod = new Product(Convert.ToInt32(x.Attribute("id").Value), x.Attribute("name").Value, Convert.ToDouble(x.Attribute("price").Value));
                prod.Quantity = (x.Attribute("quantity") != null) ? Convert.ToInt32(x.Attribute("quantity").Value) : 1;
                prod.Description = (x.Attribute("description") != null) ? x.Attribute("description").Value : "";
                
                productList.Add(prod);
            }
         
            return productList.ToArray();
        }

        public Product Save(Product product = null)
        {
            XDocument xmlDoc = XDocument.Load("..\\..\\data/xml/Products.xml");
            var elems = from item in xmlDoc.Elements("Products").Elements("product")
                        where item != null && (Convert.ToInt32(item.Attribute("id").Value) == product.ID) && (Convert.ToInt32(item.Attribute("quantity").Value) == product.Quantity) && (Convert.ToDouble(item.Attribute("price").Value) == product.Price)
                        select item;

            foreach (XElement elem in elems)
            {
                elem.Attribute("id").Value = product.ID.ToString();
                elem.Attribute("category").Value = product.Category;
                elem.Attribute("name").Value = product.Name;
                elem.Attribute("stock").Value = product.Quantity.ToString();
                elem.Attribute("price").Value = product.Price.ToString();
            }

            xmlDoc.Save("..\\..\\data/xml/Products.xml");

            return product;
        }

        public bool Create(Product product)
        {
            XDocument xmlDoc = XDocument.Load(DATA_PATH);
            xmlDoc.Elements("Products").Last().Add(
                new XElement("products", new XAttribute("id", xmlDoc.Elements("Products").Elements("product").Count() + 1),
                     new XAttribute("category", product.Category),
                        new XAttribute("name", product.Name),
                          new XAttribute("description", product.Description),
                            new XAttribute("quantity", product.Quantity),
                              new XAttribute("price", product.Price)

            ));
            try
            {
                xmlDoc.Save(DATA_PATH);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return false;
            }
        }

    }
}
