using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LojaDeBebidas.data;
using LojaDeBebidas.data.entidades;

namespace LojaDeBebidas.lib
{
    class FAQ
    {

        public void Menu()
        {
            HelpModel Helps = new HelpModel();
            
            

            foreach(Help help in Helps.All())
            {
                Console.WriteLine("{0}", help.Title);
            }
            
            
            Console.WriteLine(Helps.All());
            Console.ReadKey();
        }

    }
}
