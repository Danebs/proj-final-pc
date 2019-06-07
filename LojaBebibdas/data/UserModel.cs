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
    // Essa classe é responsável por armazenar o conjunto de usuários
    class UserModel
    {
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
            XElement xml = XElement.Load(@"..\\..\\data/xml/Users.xml");

            // Enquanto houver elementos no arquivo ele vai percorrendo e adicionando valores 
            foreach (XElement x in xml.Elements())
            {
                // Aqui eu crio o usuário baseado nas propriedades do arquivo
                User user = new User(int.Parse(x.Attribute("id").Value), x.Attribute("nome").Value, x.Attribute("cpf").Value);

                // Seta o email caso exista se não, seta vazio
                user.Email = ( x.Attribute("email") != null ) ? x.Attribute("email").Value.ToString() : null;
                user.Cidade = ( x.Attribute("cidade") != null ) ? x.Attribute("cidade").Value.ToString() : null;
                user.Password = (x.Attribute("password") != null) ? x.Attribute("password").Value : "";

                // E adiciono ele a lista
                usersList.Add(user);
            }

            // Aqui eu transformo a lista num array
            User[] usersArray = usersList.ToArray();
            return usersArray;
        }


      


    }
}
