using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LojaBebibdas.lib;

namespace LojaDeBebidas
{
    class Init
    {
        static void Main(string[] args)
        {
            Console.Title = "Goblins - Soluções em bebidas";

            Application app = new Application();

            while (app.Run()) { GC.Collect(); };

            Console.WriteLine("\n\nPressione qualquer tecla para finalizar a aplicação.");
            Console.ReadKey();
        }
    }
}
