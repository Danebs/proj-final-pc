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

namespace LojaBebibdas.data
{
    class UserModel
    {
        protected User[] Users = new User[] { };

        public UserModel() { this.Users = this.LoadUsers(); }

        public User[] All() {
            return this.Users;
        }

        public User Find(int cod, string nome = "")
        {
            User user = null;

            for (int i = 0; i < this.Users.Length; i++) {
                if (this.Users[i].Codigo == cod || (string.IsNullOrEmpty(nome) && this.Users[i].Nome == nome)) { 
                    return this.Users[i];
                }
            }

            return user;
        }


        private User[] LoadUsers() {
            
            List<User> usersList = new List<User>();

            XElement xml = XElement.Load(@"..\\..\\data/xml/Users.xml");

            foreach (XElement x in xml.Elements())
            {
                User user = new User(int.Parse(x.Attribute("id").Value), x.Attribute("nome").Value, x.Attribute("cpf").Value);

                usersList.Add(user);
            }

            User[] usersArray = usersList.ToArray();
            return usersArray;
        }


      


    }
}
