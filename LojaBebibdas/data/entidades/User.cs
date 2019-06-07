using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LojaDeBebidas.data.entidades
{
    class User
    {
        // Essa classe é responsável por manter a estrutura de um usuário com as ações dele e propriedades
        public int Codigo { get; set; }
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public string Email { get; set; }
        public string Cidade { get; set; }
        protected string Senha;
        public string Password {
            get { return this.Senha;  }
            set { this.Senha = value; }
        }

        // Esse método chamando o nome dá própria classe se chama construtor (Ele executa quando a classe inicializa uma instância)
        // Nesse caso ela obriga a classe Usuario a começar com um código, um nome e um cpf
        // Vamos ver esses dados na prática
        public User (int codigo, string nome, string cpf)
        {
            this.Codigo = codigo;
            this.Nome = nome.ToUpper();
            this.Cpf = cpf;
        }

        public bool ValidatePassword(string password)
        {
            return this.Password.Equals(password);
        }
    }
}
