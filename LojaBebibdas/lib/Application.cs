using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace LojaBebibdas.lib
{
    class Application
    {
        private bool is_Active = true;


        public bool Run()
        {

            ComponentesInterface.Logo();
            Thread.Sleep(1250);

            ComponentesInterface.Loader(750, 15);
            this.Login();

            do { this.MainMenu(); } while (this.is_Active); 


            return this.is_Active;
        }


        public bool Login()
        {
            string nome, senha;

            ComponentesInterface.PanelHeader();

            Console.Write("\n Digite seu nome de usuário:");
            nome = Console.ReadLine();
            Console.Write("Digite sua senha: ");
            Console.ForegroundColor = Console.BackgroundColor;
            senha = Console.ReadLine();
            Console.ResetColor();

            Console.WriteLine("\nSucesso !!!");
            return true;
        }

        public void MainMenu()
        {
            ConsoleKey selected = ConsoleKey.Enter;
            

            do
            {
                Console.Clear();
                Console.WriteLine("-------------------------------------");
                // Common Options

                // User Options
                Console.WriteLine("(f1) - Caixa da Loja");
                // Funcion

                // Root Options
                Console.WriteLine("\n\n(f7) - Ajuda do sistema   (f9) - Sair do Sistema");

                Console.WriteLine("-----------------------------------------------------");
                Console.Write("\nPressione a tecla correspondente a opção Desejada:");
                Console.WriteLine("\n-----------------------------------------------------");

                selected = Console.ReadKey().Key;

                switch (selected)
                {
                    case ConsoleKey.F9:
                        this.is_Active = false;
                        break;
                    default:
                        continue;
                }

            } while (selected != ConsoleKey.F9);
        }



    }
}
