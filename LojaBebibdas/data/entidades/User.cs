using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LojaDeBebidas.data.entidades
{
    class User
    {
        public int Codigo { get; set; }
        public string Nome { get; set; }
        public string Cpf { get; set; }

        public User (int codigo, string nome, string cpf)
        {
            this.Codigo = codigo;
            this.Nome = nome;
            this.Cpf = cpf;
        }
    }
}
