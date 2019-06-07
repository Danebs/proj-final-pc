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
    class Application : Autenticador
    {
        protected ConsoleColor AppTheme = ConsoleColor.DarkGreen;
        private bool is_Active = true;

        // Esta é nossa área de depuração aqui a gente pode testar
        // e pegar os resultados antes da aplicação executar
        public void debugArea()
        {
            UserModel Users = new UserModel();

            foreach (User user in Users.All()) 
            {
                if(user != null)
                {
                    Console.WriteLine("Olá {0} - bem vindo da cidade de: {1}", user.Nome, user.Cidade);
                }           
            }
        }

        // Esse é o método que executa a aplicação
        public bool Run()
        {
            // @ Função: Testar a aplicação no contexto atual
            // this.debugArea();

            ComponentesInterface.OficialLogo(this.AppTheme);
            Thread.Sleep(1250);

            // @ Função: exibir Loader
            ComponentesInterface.Loader(750, 17, "Bem vindo ao Goblins, aguarde enquanto carregamos...", this.AppTheme);
            this.Login();

            // @ Função: exibir menu
            do { this.MainMenu(); } while (this.is_Active); 

            // @Função: Desabilitar a aplicação 
            return this.is_Active;
        }


        public bool Login()
        {
            string nome, senha;

            ComponentesInterface.PanelHeader("Goblins - Login", "Faça seu login para utilizar a aplicação.");

            do
            {
                for (int i = 0; i < 3; i++)
                {
                    Console.Write("\nDigite seu nome de usuário: ");
                    nome = Console.ReadLine();
                    Console.Write("Digite sua senha: ");
                    Console.ForegroundColor = Console.BackgroundColor;
                    senha = Console.ReadLine();
                    Console.ResetColor();

                    if (AuthUser(nome, senha))
                    {
                        Console.WriteLine("Bem vindo {0}", UserSession.Nome);
                        Console.WriteLine("\nSucesso !!!");
                        Console.ResetColor();
                        return true;
                    }
                    else { Console.WriteLine("Usuário ou senha digitado estão incorretos!"); }

                    Console.WriteLine((UserSession != null) ? UserSession.Cpf : "");
                }


                Console.WriteLine("Esqueci minha senha");
            } while (true);    
        }

        public void MainMenu()
        {
            ConsoleKey menuOption = ConsoleKey.Enter;
            
            do
            {
                Console.Clear();

                ComponentesInterface.PanelHeader("Goblins - Menu Principal", "Solução de caixa para bares e distribuidoras de bebidas");
                // Common Options

                // User Options
                Console.WriteLine("(f1) - Caixa da Loja"); // Ai entra a classe do João
                Console.WriteLine("(f2) - Monstruario"); // Aqui entra a classe do Vitor "Mostruario/Estoque"
                Console.WriteLine("(f3) - Gestão de clientes"); // Aqui é a gestão do cliente do Yury
                Console.WriteLine("(f4) - Gestão de Funcionários"); // Aqui a gestão de funcionário do Venezuela
                Console.WriteLine("(f5) - Relatórios Financeiros"); // Aqui o financeiro

                // Precisamos alimentar esses metodos com as ações
         
           
                // Funcion

                // Root Options
                Console.WriteLine("\n\n(f7) - Ajuda do sistema   (f9) - Sair do Sistema");

                Console.WriteLine("-----------------------------------------------------");
                Console.Write("\nPressione a tecla correspondente a opção Desejada:");
                Console.WriteLine("\n-----------------------------------------------------");

                menuOption = Console.ReadKey().Key;

                // @Função: 
                switch (menuOption)
                {

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
