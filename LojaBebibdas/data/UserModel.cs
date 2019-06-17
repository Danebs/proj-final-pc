using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Linq;
using LojaDeBebidas.data.entidades;

namespace LojaDeBebidas.data
{
    // Essa classe é responsável por armazenar o conjunto de usuários
    class UserModel
    {
        protected const string DATA_PATH = @"..\\..\\data/xml/Users.xml";

        // Array da Classe User
        protected User[] Users = new User[] { };

        public UserModel() { this.Users = this.LoadUsers(); }

        public User[] All() {
            return this.Users;
        }

        public User FindByID(int cod)
        {
            User user = null;

            for (int i = 0; i < this.Users.Length; i++) {
                if (this.Users[i].Codigo == cod) { 
                    return this.Users[i];
                }
            }

            return user;
        }

        public User FindByName(string nome) {
            User user = null;

            for (int i = 0; i < this.Users.Length; i++)
            {
                if (this.Users[i].Nome.ToLower() == nome.ToLower())
                    return this.Users[i];
                
            }

            return user;
        }
        public User FindByCpf(string Cpf) {
            User user = null;

            for (int i = 0; i < this.Users.Length; i++)
            {
                if (this.Users[i].Cpf == Cpf)
                    return this.Users[i];

            }

            return user;
        }

        // Aqui usamos um método pra carregar os dados do arquivo
        private User[] LoadUsers() {
            
            List<User> usersList = new List<User>();

            // Criamos um instância do (XElement) que é uma classe responsável por ler um arquivo xml e escrever nele
            XElement xml = XElement.Load(DATA_PATH);

            // Enquanto houver elementos no arquivo ele vai percorrendo e adicionando valores 
            foreach (XElement x in xml.Elements())
            {
                // Aqui eu crio o usuário baseado nas propriedades do arquivo
                User user = new User(int.Parse(x.Attribute("id").Value), x.Attribute("nome").Value, x.Attribute("cpf").Value);

                // Seta o email caso exista se não, seta vazio
                user.Email = ( x.Attribute("email") != null ) ? x.Attribute("email").Value.ToString() : null;
                user.Cidade = ( x.Attribute("cidade") != null ) ? x.Attribute("cidade").Value.ToString() : null;
                user.Senha = (x.Attribute("password") != null) ? x.Attribute("password").Value : "";
                user.Role = (x.Attribute("role") != null) ? x.Attribute("role").Value : null;

                // E adiciono ele a lista
                usersList.Add(user);
            }

            // Aqui eu transformo a lista num array
            User[] usersArray = usersList.ToArray();
            return usersArray;
        }

        public User Save(User user = null)
        {
            XDocument xmlDoc = XDocument.Load(DATA_PATH);
            var elems = from item in xmlDoc.Elements("Users").Elements("user")
                        where item != null && (Convert.ToInt32(item.Attribute("id").Value) == user.Codigo)
                        select item;
         
            foreach (XElement elem in elems) 
            {
                elem.Attribute("id").Value = user.Codigo.ToString();
                elem.Attribute("nome").Value = user.Nome;
                elem.Attribute("email").Value = user.Email;
                elem.Attribute("cpf").Value = user.Cpf;
                elem.Attribute("cidade").Value = user.Cidade;
            }

            xmlDoc.Save(DATA_PATH);

            return user;
        }

        public bool Create(User user)
        {
            XDocument xmlDoc = XDocument.Load(DATA_PATH);
            xmlDoc.Elements("Users").Last().Add(
                new XElement("user", new XAttribute("id", xmlDoc.Elements("Users").Elements("user").Count() + 1),
                     new XAttribute("nome", user.Nome),
                        new XAttribute("cpf", user.Cpf),
                          new XAttribute("password", user.Senha),
                            new XAttribute("cidade", user.Cidade),
                              new XAttribute("role", 0)
             ));

            try {
                xmlDoc.Save("d:/data.xml");
                return true;
            }
            catch (Exception ex) {
                Console.WriteLine(ex);
                return false;
            }
           
        }
    }
}
