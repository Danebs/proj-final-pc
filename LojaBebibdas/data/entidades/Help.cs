using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LojaDeBebidas.data.entidades
{
    class Help
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public int Category { get; set; }
        protected enum CategoryEnum { Sistema = 1, Usabilidade = 2, Dicas = 3 }

        public Help(int _id, string _title)
        {
            this.ID = _id;
            this.Title = _title;
        }
    }

}
