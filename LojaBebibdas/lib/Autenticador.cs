using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LojaBebibdas.data;
using LojaDeBebidas.data.entidades;

namespace LojaBebibdas.lib
{
    class Autenticador : UserModel
    {
        public User UserSession;

        private bool AuthUser(string login, string password)
        {  
            User user = FindByName(login);

            if (user != null && user.ValidatePassword(password)) { 
                this.UserSession = user;
                Console.WriteLine(user);
                Console.WriteLine(UserSession.Codigo);
                return true;
            } else { 
                return false;
            }

        }

        private string RecoverPassword(string cpf)
        {
            User user = FindByCpf(cpf);

            if (user != null)
                return user.Cpf;

            return "";
        }

        public bool Login()
        {
            string nome, senha;

            ComponentesInterface.PanelHeader(Application.AppName + " - Login", "Faça seu login para utilizar a aplicação:");

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

                    else {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Usuário ou senha digitado estão incorretos!");
                        Console.ResetColor();
                    }

                    Console.WriteLine((UserSession != null) ? UserSession.Cpf : "");
                }

                Console.WriteLine("-----------------------------------------------");
                Console.WriteLine("\tRecuperação de senha...");
                Console.WriteLine("-----------------------------------------------");
                Console.Write("Digite seu cpf: ");
                string userCpf = Console.ReadLine();

                if (this.RecoverPassword(userCpf) != "")
                {
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine("Sua senha é: ", this.RecoverPassword(userCpf));
                    Console.ResetColor();
                } else {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("\tSua cadastro não foi encontrado =( ");
                    Console.ResetColor();
                }
      
               
            } while (true);
        }

    }
}
