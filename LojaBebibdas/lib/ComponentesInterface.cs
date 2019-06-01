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

        public static void PanelHeader() {


        }
        public static void PanelFooter() { }

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
        public static void Logo() {
            Console.WriteLine("||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||");
            Console.WriteLine("|||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||");
            Console.WriteLine("||||                                                                           _    ");
            Console.WriteLine("||||    |||||||   ||||||    ||||||    |||     |||||| ||||  |||    ||||        /    ");
            Console.WriteLine("||||   ||||||||| ||||||||| |||||||||  |||     |||||| ||||  |||   |||||||  \\__|___/ ");
            Console.WriteLine("||||   |||    || |||   ||| |||   |||  |||      ||||  ||||| |||   |||||     \\    /");
            Console.WriteLine("||||   |||       |||   ||| |||  |||   |||      ||||  |||||||||    ||||      \\  /");
            Console.WriteLine("||||   |||       |||   ||| ||| ||     |||      ||||  ||| |||||     ||||      ||"); 
            Console.WriteLine("||||   ||| ||||| |||   ||| |||||||    |||      ||||  |||  ||||      ||||     ||");
            Console.WriteLine("||||   |||   ||| |||   ||| |||  |||   |||      ||||  |||  ||||   ||||||     _||_");
            Console.WriteLine("||||   ||||||||  ||||||||| |||||||||  ||||||  |||||| |||  ||||  ||||||     /    \\");
            Console.WriteLine("||||   ||||||      |||||   |||||||    ||||||  |||||| |||  ||||   ||||     /______\\");
            Console.WriteLine("||||   ");
            Console.WriteLine("|||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||");
            Console.WriteLine("||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||");

        }


    }
}
