using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using LojaDeBebidas.data.entidades;

namespace LojaDeBebidas.data
{
    class HelpModel
    {
        protected const string DATA_PATH = @"..\\..\\data/xml/Helps.xml";

        // Array da Classe User
        protected Help[] HelpArray = null;

        public HelpModel() { this.HelpArray = this.LoadHelps(); }

        public Help[] All()
        {
            return this.HelpArray;
        }

        public Help FindByID(int cod)
        {
            Help help = null;

            for (int i = 0; i < this.HelpArray.Length; i++)
            {
                if (this.HelpArray[i].ID == cod)
                {
                    return this.HelpArray[i];
                }
            }

            return help;
        }

        public Help FindByTitle(string title)
        {
            Help help = null;

            for (int i = 0; i < this.HelpArray.Length; i++)
            {
                if (this.HelpArray[i].Title.ToLower() == title.ToLower())
                    return this.HelpArray[i];

            }

            return help;
        }
        public Help FindByCategory(int category)
        {
            Help user = null;

            for (int i = 0; i < this.HelpArray.Length; i++)
            {
                if (this.HelpArray[i].Category == category)
                    return this.HelpArray[i];

            }

            return user;
        }


        // Aqui usamos um método pra carregar os dados do arquivo
        private Help[] LoadHelps()
        {

            List<Help> helpList = new List<Help>();

            // Criamos um instância do (XElement) que é uma classe responsável por ler um arquivo xml e escrever nele
            XElement xml = XElement.Load(DATA_PATH);

            // Enquanto houver elementos no arquivo ele vai percorrendo e adicionando valores 
            foreach (XElement x in xml.Elements())
            {
                // Aqui eu crio o usuário baseado nas propriedades do arquivo
                Help help = new Help(Convert.ToInt32(x.Attribute("id").Value), x.Attribute("title").Value);

                help.Category = (x.Attribute("category") != null) ? Convert.ToInt32(x.Attribute("category").Value) : 0; 
                help.Content = (x.Value != null) ? Convert.ToString(x.Value) : "";

                // E adiciono ele a lista
                helpList.Add(help);
            }

            // Aqui eu transformo a lista num array
            Help[] helpsArray = helpList.ToArray();
            return helpsArray;
        }

        public Help Save(Help help = null)
        {
            XDocument xmlDoc = XDocument.Load(DATA_PATH);
            var elems = from item in xmlDoc.Elements("Helps").Elements("question")
                        where item != null && (Convert.ToInt32(item.Attribute("id").Value) == help.ID)
                        select item;

            foreach (XElement elem in elems)
            {
                elem.Attribute("id").Value = help.ID.ToString();
                elem.Attribute("title").Value = help.Title;
                elem.Attribute("category").Value = help.Category.ToString();
                elem.Value = help.Content;
            }

            xmlDoc.Save(DATA_PATH);

            return help;
        }

        public bool Create(Help help)
        {
            XDocument xmlDoc = XDocument.Load(DATA_PATH);
            xmlDoc.Elements("Helps").Last().Add(
                new XElement("question", new XAttribute("id", xmlDoc.Elements("Helps").Elements("question").Count() + 1),
                     new XAttribute("id", xmlDoc.Elements("Helps").Elements("question").Count() + 1),
                        new XAttribute("title", help.Title),
                          new XAttribute("category", help.Category),
                            new XText(help.Content)
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
