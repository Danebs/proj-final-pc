using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Schema;

namespace LojaBebibdas.data
{
    class UserModel
    {
        public int Codigo { get; set; }
        public string Nome { get; set; }
        public string Cpf { get; set; }


        public UserModel(int cod, string nome, string cpf)
        {
            this.Codigo = cod;
            this.Nome = nome;
            this.Cpf = cpf;
        }



    }
}
