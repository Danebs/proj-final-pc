using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LojaDeBebidas.data.entidades;

namespace LojaDeBebidas.data
{
    class ClientsModel
    {
        public User[] Clients;

        public User[] All()
        {
            List<User> userList = new List<User>();
                 

            UserModel usermodel = new UserModel();

            Console.WriteLine(usermodel.All());

            

            foreach (User usuario in usermodel.All())
            {
                if (usuario.Role == "Client")
                {
                    Console.WriteLine(usuario.Nome);

                    userList.Add(usuario);
                }
            }

            this.Clients = userList.ToArray();

            return usermodel.All();
        }

        public User FindByName(string name)
        {
            User userFounded = null;

            UserModel userModel = new UserModel();

            foreach (User usuario in userModel.All())
            {
                if (usuario.Nome == name)
                {
                    return usuario;
                    
                   
                }
            }

            return userFounded;

        }

        public User FindByCpf(string cpf)
        {
            User userFounded = null;

            UserModel userModel = new UserModel();

            foreach (User usuario in userModel.All())
            {
                if (usuario.Cpf == cpf)
                {
                    return usuario;


                }
            }

            return userFounded;

        }

        public User Create(string cpf,string name, string phone, string city, string email)
        {
            UserModel userModel = new UserModel();

            User client = null;
            
            client = new User(name, cpf);

            client.Email = email;

            client.Cidade = city;

            client.Telefone = phone;

            client.Senha = "123456";

            userModel.Create(client);
         
            return client;
        }

        public User Edit(int id, string nome)
        {
            UserModel userModel = new UserModel();
            User user = userModel.FindByID(id);

            if (user == null)
                return null;

            Console.WriteLine(user.Email);
            Console.ReadKey();
           return userModel.Save(user);
        }

    }
}
