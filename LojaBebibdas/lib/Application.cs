using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using LojaDeBebidas.data;
using LojaDeBebidas.data.entidades;

namespace LojaDeBebidas.lib
{
    class Application
    {
        protected User UserLogged;
        public static string AppName = "Hey!Bar";
        public static ConsoleColor AppTheme = ConsoleColor.DarkYellow;
        private bool is_Active = true;

        // Esta é nossa área de depuração aqui a gente pode testar
        // e pegar os resultados antes da aplicação executar
        public void debugArea()
        {
            ClientsModel clientModel = new ClientsModel();
            Console.WriteLine(clientModel.Edit(11,"yury").Nome);
            clientModel.All();

            Console.ReadKey();
        }

        // Esse é o método que executa a aplicação
        public bool Run()
        {
            // @ Função: Testar a aplicação no contexto atual
            this.debugArea();
     
            UIComponents.OficialLogo(AppTheme);
            Thread.Sleep(1250);

            // @ Função: exibir Loader
            UIComponents.Loader(750, 17, "Bem vindo ao " + AppName + " aguarde enquanto carregamos...", AppTheme);
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
                    case "Staff":
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

            UIComponents.PanelHeader(AppName + " - Menu Principal\n\t-----------------------", "Solução de caixa para bares e distribuidoras de bebidas");
            UIComponents.PanelInfoUser(UserLogged);
            // Common Options

            // User Options
            Console.WriteLine("\n\n\nVocê é usuário!!! Muito obrigado por participar");
            // Root Options
            Console.WriteLine("\n\n(f1) - Ajuda do sistema");

            this.is_Active = false;
        }
        protected void MenuStaff() {
            ConsoleKey menuOption = ConsoleKey.Enter;

            do
            {
                Console.Clear();

                UIComponents.PanelHeader(AppName + " - Menu Principal", "\t\t-------------------------\n\t\tSoftware de Gestão de produtos em bares e restaurantes.");
                // Common Options
                UIComponents.PanelInfoUser(UserLogged);
                Console.WriteLine("\n\n*****************\n\n---------- MENU PRINCIPAL ----------\n\n*****************");
                // User Options
                Console.WriteLine("| (1) | Caixa da loja"); // Aqui entra a classe do João
                Console.WriteLine("| (2) | Gestão de Cliente"); // Aqui entra a classe do Vitor "Mostruario/Estoque"
                Console.WriteLine("| (3) | Gestão de Produtos"); // Aqui é a gestão do cliente do Yury
                                                         
                UIComponents.PanelFooter();

                Console.WriteLine("----------------------------------------------------------------------------------------------");
                Console.Write("\t\tPressione a tecla correspondente a opção Desejada:");
                Console.WriteLine("\n--------------------------------------------------------------------------------------------");

        
                menuOption = Console.ReadKey().Key;

                // @Função: 
                switch (menuOption)
                {
                    case ConsoleKey.D1:
                    case ConsoleKey.NumPad1:
                        Cashier caixa = new Cashier();
                        caixa.Menu();
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

                UIComponents.PanelHeader(AppName + " - Menu Principal", "Solução de caixa para bares e distribuidoras de bebidas");
                UIComponents.PanelInfoUser(UserLogged);
                // Common Options

                // User Options
                Console.WriteLine("\t| (1) | - Caixa da Loja"); // Ai entra a classe do João
                Console.WriteLine("\t| (2) | - Monstruario"); // Aqui entra a classe do Vitor "Mostruario/Estoque"
                Console.WriteLine("\t| (3) | - Gestão de clientes"); // Aqui é a gestão do cliente do Yury
                Console.WriteLine("\t| (4) | - Gestão de Funcionários"); // Aqui a gestão de funcionário do Venezuela
                Console.WriteLine("\t| (5) | - Relatórios Financeiros"); // Aqui o financeiro

                UIComponents.PanelFooter();

                Console.WriteLine("\t--------------------------------------------------------------------");
                Console.Write("\t\tPressione a tecla correspondente a opção Desejada:");
                Console.WriteLine("\n\t------------------------------------------------------------------");

                menuOption = Console.ReadKey().Key;

                // @Função: 
                switch (menuOption)
                {
                    case ConsoleKey.D1:
                    case ConsoleKey.NumPad1:
                        Cashier caixa = new Cashier();
                        caixa.Menu();
                        break;
                    case ConsoleKey.F1:
                        FAQ faq = new FAQ();
                        faq.Menu();
                        break;
                    case ConsoleKey.D5:
                    case ConsoleKey.NumPad5:
                        Financial financialModule = new Financial();
                        financialModule.Menu();
                        break;

                    case ConsoleKey.F9:
                        this.is_Active = false;
                        break;
                    default:
                        continue;
                }

            } while (menuOption != ConsoleKey.F9);
        }

       



    }
}
