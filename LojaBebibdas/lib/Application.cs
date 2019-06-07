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
        protected User UserLogged;
        public static string AppName = "Hey!Bar";
        protected ConsoleColor AppTheme = ConsoleColor.DarkGreen;
        private bool is_Active = true;

        // Esta é nossa área de depuração aqui a gente pode testar
        // e pegar os resultados antes da aplicação executar
        public void debugArea()
        {
            UserModel Users = new UserModel();
           
        }

        // Esse é o método que executa a aplicação
        public bool Run()
        {
            // @ Função: Testar a aplicação no contexto atual
            // this.debugArea();
            ComponentesInterface.OficialLogo(this.AppTheme);
            Thread.Sleep(1250);

            // @ Função: exibir Loader
            ComponentesInterface.Loader(750, 17, "Bem vindo ao " + AppName + " aguarde enquanto carregamos...", this.AppTheme);
            Autenticador Auth = new Autenticador();
            
            if (!Auth.Login())
                return !this.is_Active;

            UserLogged = Auth.UserSession;
     
            do {
                switch (UserLogged.Role)
                {
                    case "Root":
                        this.MenuRoot();
                        break;
                    case "Funcionario":
                        this.MenuStaff();
                        break;
                    default:
                        this.MenuClient();
                        break;
                }
            } while (this.is_Active);

            return this.is_Active;
          
        }

        protected void MenuClient() {
            ConsoleKey menuOption = ConsoleKey.Enter;
            Console.Clear();

            ComponentesInterface.PanelHeader(AppName + " - Menu Principal", "Solução de caixa para bares e distribuidoras de bebidas");
            ComponentesInterface.PanelInfoUser(UserLogged);
            // Common Options

            // User Options
            Console.WriteLine("Você é usuário!!! Muito obrigado por participar");
            // Root Options
            Console.WriteLine("\n\n(f1) - Ajuda do sistema");

            this.is_Active = false;
        }
        protected void MenuStaff() {
            ConsoleKey menuOption = ConsoleKey.Enter;

            do
            {
                Console.Clear();

                ComponentesInterface.PanelHeader(AppName + " - Menu Principal", "Software de Gestão para bares");
                // Common Options
                ComponentesInterface.PanelInfoUser(UserLogged);
                // User Options
                Console.WriteLine("(1) - Monstruario"); // Ai entra a classe do João
                Console.WriteLine("(2) - Gestão de Cliente"); // Aqui entra a classe do Vitor "Mostruario/Estoque"
                Console.WriteLine("(3) - Gestão de Produtos"); // Aqui é a gestão do cliente do Yury
                // Root Options
                Console.WriteLine("\n\n(f1) - Ajuda do sistema   (f9) - Sair do Sistema");

                Console.WriteLine("-----------------------------------------------------");
                Console.Write("\nPressione a tecla correspondente a opção Desejada:");
                Console.WriteLine("\n-----------------------------------------------------");

                ComponentesInterface.PanelFooter();
                menuOption = Console.ReadKey().Key;

                // @Função: 
                switch (menuOption)
                {
                    case ConsoleKey.F1:
                        break;

                    case ConsoleKey.F9:
                        this.is_Active = false;
                        break;
                    default:
                        continue;
                }
            } while (menuOption != ConsoleKey.F9);
        }
  
        protected void MenuRoot()
        {
            ConsoleKey menuOption = ConsoleKey.Enter;
            
            do
            {
                Console.Clear();

                ComponentesInterface.PanelHeader("Goblins - Menu Principal", "Solução de caixa para bares e distribuidoras de bebidas");
                // Common Options

                // User Options
                Console.WriteLine("(1) - Caixa da Loja"); // Ai entra a classe do João
                Console.WriteLine("(2) - Monstruario"); // Aqui entra a classe do Vitor "Mostruario/Estoque"
                Console.WriteLine("(3) - Gestão de clientes"); // Aqui é a gestão do cliente do Yury
                Console.WriteLine("(4) - Gestão de Funcionários"); // Aqui a gestão de funcionário do Venezuela
                Console.WriteLine("(5) - Relatórios Financeiros"); // Aqui o financeiro

                // Precisamos alimentar esses metodos com as ações
         
           
                // Funcion

                // Root Options
                Console.WriteLine("\n\n(f1) - Ajuda do sistema   (f9) - Sair do Sistema");

                Console.WriteLine("-----------------------------------------------------");
                Console.Write("\nPressione a tecla correspondente a opção Desejada:");
                Console.WriteLine("\n-----------------------------------------------------");

                menuOption = Console.ReadKey().Key;

                // @Função: 
                switch (menuOption)
                {
                    case ConsoleKey.F1:
                        break;

                    case ConsoleKey.F9:
                        this.is_Active = false;
                        break;
                    default:
                        continue;
                }

                ComponentesInterface.PanelFooter();

            } while (menuOption != ConsoleKey.F9);
        }

       



    }
}
