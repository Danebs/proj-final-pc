using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using LojaBebibdas.data;
using LojaDeBebidas.data.entidades;

namespace LojaBebibdas.lib
{
    class Application
    {
        private bool is_Active = true;


        public void debugArea()
        {
            UserModel Users = new UserModel();

            foreach (User user in Users.All()) 
            {
                if(user != null)
                {
                    Console.WriteLine(user.Nome);
                }
             
            }
        }

        public bool Run()
        {

            this.debugArea();

            ComponentesInterface.Logo();
            Thread.Sleep(1250);

            ComponentesInterface.Loader(750, 17, "Bem vindo ao Goblins, aguarde enquanto carregamos...", ConsoleColor.Cyan);
            this.Login();

            do { this.MainMenu(); } while (this.is_Active); 

            return this.is_Active;
        }


        public bool Login()
        {
            string nome, senha;

            ComponentesInterface.PanelHeader("Goblins - Login", "Faça seu login para utilizar a aplicação.");

            Console.Write("\nDigite seu nome de usuário: ");
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

                ComponentesInterface.PanelHeader("Goblins - Menu Principal", "Solução de caixa para bares e distribuidoras de bebidas");
                // Common Options

                // User Options
                Console.WriteLine("(f1) - Caixa da Loja");
                Console.WriteLine("(f2) - Monstruario");
                Console.WriteLine("(f3) - Gestão de clientes");
                Console.WriteLine("(f4) - Gestão de Funcionários");
                Console.WriteLine("(f5) - Relatórios Financeiros");

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

                ComponentesInterface.PanelFooter();

            } while (selected != ConsoleKey.F9);
        }



    }
}
