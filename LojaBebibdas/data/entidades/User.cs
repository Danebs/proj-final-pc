using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LojaDeBebidas.data.entidades
{
    class User
    {
        public enum UserRoles { Root = 99, Staff = 2, Client = 1};
        // Essa classe é responsável por manter a estrutura de um usuário com as ações dele e propriedades
        public int Codigo { get; set; }
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public string Email = null;
        public string Cidade { get; set; }
        public string Telefone { get; set; }
        protected string Password = "";

        public string Senha {
            get { return this.Password.ToString();  }
            set { this.Password = value.ToString(); }
        }
        private UserRoles AccessLevel;

        public string Role {
            get { return this.AccessLevel.ToString();  }
            set
            {
                switch (Convert.ToInt32(value)) {
                    case 2:
                        this.AccessLevel = UserRoles.Staff;
                        break;
                    case 99:
                        this.AccessLevel = UserRoles.Root;
                        break;
                    default:
                        this.AccessLevel = UserRoles.Client;
                        break;
                }
            }
        }

        // Esse método chamando o nome dá própria classe se chama construtor (Ele executa quando a classe inicializa uma instância)
        // Nesse caso ela obriga a classe Usuario a começar com um código, um nome e um cpf
        // Vamos ver esses dados na prática
        public User (string nome, string cpf)
        {
            this.Nome = nome.ToUpper();
            this.Cpf = cpf;
        }

        public bool ValidatePassword(string password)
        {
            return this.Password.Equals(password);
        }
    }
}
