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
            Application app = new Application();

            Console.SetWindowSize(125, 45);
            Console.Title = "Goblins - Soluções em bebidas";

            while (app.Run()) { GC.Collect(); };

            Console.WriteLine("\n\nPressione qualquer tecla para finalizar a aplicação.");
            Console.ReadKey();
        }
    }
}
