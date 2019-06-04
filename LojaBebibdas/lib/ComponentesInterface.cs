using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LojaBebibdas.lib
{
    class ComponentesInterface
    {
        public static void PanelHeader(string title = "Bem vindo", string subtitle = "Soluções em bares") {
            Console.WriteLine("\t|||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||");
            Console.WriteLine("\t");
            Console.WriteLine("\t\t\t\t\t{0}\n\t\t\t\t\t\t      ---", title.ToUpper());
            Console.WriteLine("\t\t\t{0}", subtitle);
            Console.WriteLine("\t");
            Console.WriteLine("\t|||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||\n\n");
        }
        public static void PanelFooter() {
            Console.WriteLine("\n\n------- {0} -------", DateTime.Now);
        }

        public static void Loader(int time = 500, int length = 100, string title = "Carregando...", ConsoleColor loaderColor = ConsoleColor.Green) {
            Console.CursorVisible = false;
            
            Console.WriteLine("\n\n");
            Console.WriteLine(title);

            Console.ForegroundColor = loaderColor;
            Console.Write("||");
            for (int i = 0; i <= 5; i++)
            {
                for(int j = 0; j <= length; j++) { 
                    Console.Write("=");
                }
               
                Thread.Sleep(time);
            }
            Console.Write("||");
            Console.ResetColor();

            Console.WriteLine("\n\n");
        }
        public static void Logo(ConsoleColor corPrimaria = ConsoleColor.DarkMagenta, ConsoleColor corSecundaria = ConsoleColor.White) {
            Console.ForegroundColor = corSecundaria;
            Console.WriteLine("\t||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||");    
            Console.WriteLine("\t||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||");
            Console.ForegroundColor = corPrimaria;
            Console.WriteLine("\t\t                                                                         _    ");
            Console.WriteLine("\t\t ||||||    ||||||    ||||||    |||     |||||| ||||  |||    ||||        /    ");
            Console.WriteLine("\t\t||||||||| ||||||||| |||||||||  |||     |||||| ||||  |||   |||||||  \\__|___/ ");
            Console.WriteLine("\t\t|||    || |||   ||| |||   |||  |||      ||||  ||||| |||   |||||     \\    /");
            Console.WriteLine("\t\t|||       |||   ||| |||  |||   |||      ||||  |||||||||    ||||      \\  /");
            Console.WriteLine("\t\t|||       |||   ||| ||| ||     |||      ||||  ||| |||||     ||||      ||");
            Console.WriteLine("\t\t||| ||||| |||   ||| |||||||    |||      ||||  |||  ||||      ||||     ||");
            Console.WriteLine("\t\t|||   ||| |||   ||| |||  |||   |||      ||||  |||  ||||   ||||||     _||_");
            Console.WriteLine("\t\t||||||||  ||||||||| |||||||||  ||||||  |||||| |||  ||||  ||||||     /    \\");
            Console.WriteLine("\t\t |||||      |||||   |||||||    ||||||  |||||| |||  ||||   ||||     /______\\");
            Console.WriteLine("\t                                                                                              ");
            Console.ForegroundColor = corSecundaria;
            Console.WriteLine("\t||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||");
            Console.WriteLine("\t||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||");

            Console.ResetColor();
        }
    }
}
