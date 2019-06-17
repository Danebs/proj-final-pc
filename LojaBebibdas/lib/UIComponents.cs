using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using LojaDeBebidas.data.entidades;

namespace LojaDeBebidas.lib
{
    class UIComponents
    {
        public static void PanelHeader(string title = "Bem vindo", string subtitle = "Soluções em bares") {
            Console.WriteLine("\n\n||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||");
 
            Console.WriteLine("\n\t\t\t\t\t{0}", title.ToUpper());
            Console.WriteLine("\t\t\t{0}", subtitle);
          
            Console.WriteLine("\n||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||\n\n");
        }
        public static void PanelFooter(string menu_options = "(f1) - Ajuda do sistema | (f9) - Sair do Sistema") {
            Console.WriteLine("--------------------------------------------------------------------------------");
            Console.WriteLine("\n\n{0}", menu_options);
            Console.WriteLine("--------------------------------------------------------------------------------");
            Console.WriteLine("\n\n\t\t------- {0}/{1}/{2} às {3}h{4} -------", DateTime.Now.Day.ToString("D2"), DateTime.Now.Month.ToString("D2"), DateTime.Now.Year, DateTime.Now.Hour, DateTime.Now.Minute);
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
                    Console.Write(":");
                }
               
                Thread.Sleep(time);
            }
            Console.Write("||");
            Console.ResetColor();

            Console.WriteLine("\n\n");
        }

        public static void OficialLogo(ConsoleColor corPrimaria = ConsoleColor.DarkRed, ConsoleColor corSecundaria = ConsoleColor.White)
        {
            Console.ForegroundColor = corSecundaria;
            Console.WriteLine("\n\t|||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||\n");
            Console.ForegroundColor = corPrimaria;
            Console.WriteLine("\t\t|||   ||| ||||||||| |||      ||| ||||  |||||||    |||||||   |||||||         |||       |||");
            Console.WriteLine("\t\t|||   ||| ||||||||| ||||    |||| ||||  |||  |||  |||   |||  ||||||||        |||~~~~~~~|||||||");
            Console.WriteLine("\t\t|||   ||| |||        ||||||||||  ||||  |||  |||  |||   |||  |||   |||       |||       |||  |||");
            Console.ForegroundColor = corSecundaria;
            Console.WriteLine("\t\t||||||||| |||||||||     |||      ||||  ||| |||   |||||||||  |||   ||||      |||       |||  |||");
            Console.WriteLine("\t\t||||||||| |||||||||     |||      ||||  |||||||   |||||||||  |||||||||       |||       |||  |||");
            Console.WriteLine("\t\t|||   ||| |||           |||            |||  |||  |||   |||  |||  |||        |||       |||||||");
            Console.ForegroundColor = corPrimaria;
            Console.WriteLine("\t\t|||   ||| |||   |||    ||||||    ||||  |||   ||| |||   |||  |||   |||       |||       |||  ");
            Console.WriteLine("\t\t|||   ||| ||||||||| |||||||||||  ||||  ||||||||  |||   |||  |||    |||      \\\\\\======////");
           
            Console.WriteLine("\n\t||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||\n");
            Console.ResetColor();
        }


        protected static void BetaLogo(ConsoleColor corPrimaria = ConsoleColor.Green, ConsoleColor corSecundaria = ConsoleColor.White)
        {
            Console.ForegroundColor = corSecundaria;
            Console.WriteLine("\t||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||");
            Console.WriteLine("\t||||||                                                                                    ||||||");
            Console.ForegroundColor = corPrimaria;
            Console.WriteLine("\t\t                                                                         _    ");
            Console.WriteLine("\t\t ||||||    ||||||    ||||||    |||     |||||| ||||  |||    ||||        /    ");
            Console.WriteLine("\t\t||||||||| ||||||||| |||||||||  |||     |||||| ||||  |||   |||||||  \\__|___/ ");
            Console.ForegroundColor = corSecundaria;
            Console.WriteLine("\t\t|||    || |||   ||| |||   |||  |||      ||||  ||||| |||   |||||     \\    /");
            Console.WriteLine("\t\t|||       |||   ||| |||  |||   |||      ||||  |||||||||    ||||      \\  /");
            Console.WriteLine("\t\t|||       |||   ||| ||| ||     |||      ||||  ||| |||||     ||||      ||");
            Console.WriteLine("\t\t||| ||||| |||   ||| |||||||    |||      ||||  |||  ||||      ||||     ||");
            Console.ForegroundColor = corPrimaria;
            Console.WriteLine("\t\t|||   ||| |||   ||| |||  |||   |||      ||||  |||  ||||   ||||||     _||_");
            Console.WriteLine("\t\t||||||||  ||||||||| |||||||||  ||||||  |||||| |||  ||||  ||||||     /    \\");
            Console.WriteLine("\t\t |||||      |||||   |||||||    ||||||  |||||| |||  ||||   ||||     /______\\");
            Console.WriteLine("\n");
            Console.ForegroundColor = corSecundaria;
            Console.WriteLine("\t||||||                                                                                    ||||||");
            Console.WriteLine("\t||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||");

            Console.ResetColor();
        }

        public static void PanelInfoUser(User user)
        {
            Console.WriteLine("* ***************************************");
            Console.WriteLine("* *** Login: {0}", user.Codigo);
            Console.WriteLine("* *** Acesso: {0}", user.Role);
            Console.WriteLine("* *** Sua cidade: {0}", user.Cidade);
            Console.WriteLine("* **************************************");

        }

        public static void ChangeTextColor(string text, ConsoleColor corConsole = ConsoleColor.White)
        {
            Console.ForegroundColor = corConsole;
            Console.WriteLine(text);
            Console.ResetColor(); 
        }
    }
}
