using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LojaDeBebidas.lib
{
    class ClientsManager
    {
        public int IdUsuario { get; set; }

        public string NomeUsuario { get; set; }
        public string cpfs { get; set; }

        public void Gestao(int id, string category, string name, string cpfs)
       {
            this.IdUsuario = id;
            this.NomeUsuario = name;
            this.cpfs = cpfs;
        }

        struct Cliente
        {
            public int cod_cli;
            public string Usuario, CPF, cargos;
        }
        struct CPF
        {
            public int cod_cpf;
            public string Usuario, cpf, cargos;
        }


        public static void Main(string[] args)
        {
            Cliente[] clientes = new Cliente[5];
            CPF[] cpf = new CPF[11];

            int qtdCliente = 0;
            int qtdCPF = 0;
            int opcao = -1;

            do
            {
                Console.Title = " * SISTEMA DE RECEBIMENTOS * ";
                Console.BackgroundColor = ConsoleColor.White;// Muda a cor da tela.
                Console.ForegroundColor = ConsoleColor.DarkBlue;// Muda a cor da letra.
                Console.Clear(); //limpa a tela

                //Imprime na tela as opções do Menu:
                Console.WriteLine("-------------------------");
                Console.WriteLine("     MENU DE OPÇÕES      ");
                Console.WriteLine("-------------------------");
                Console.WriteLine(" Informe a opção deseja: \n");
                Console.WriteLine("1. Cadastrar Cliente");
                Console.WriteLine("2. Editar Cliente");

                Console.WriteLine("4. Sair");
                Console.SetCursorPosition(25, 3); //Move o cursor para o fim da 4a linha

                //lê a opção escolhida pelo usuário
                opcao = Convert.ToInt32(Console.ReadLine());

                //limpa a tela
                Console.Clear();


                //direciona o programa para a opção escolhida pelo usuário:
                switch (opcao)
                {
                    case 1:
                        //Testa se já chegou ao limite de clientes cadastrados
                        //onde o limite é o tamanho (Length) do vetor:
                        if (qtdCliente < clientes.Length)
                        {
                            //Preenche os dados do cliente
                            Console.WriteLine("Digite os dados do cliente \n");
                            Console.Write("Código: ");
                            clientes[qtdCliente].cod_cli = Convert.ToInt32(Console.ReadLine());
                            Console.Write("Nome: ");
                            clientes[qtdCliente].Usuario = Console.ReadLine();
                            Console.Write("Endereço: ");
                            clientes[qtdCliente].CPF = Console.ReadLine();
                            Console.Write("Telefone: ");
                            clientes[qtdCliente].cargos = Console.ReadLine();

                            //incrementa o número de clientes
                            qtdCliente++;

                            Console.WriteLine("\nCliente Cadastrado com sucesso!");
                        }
                        else
                        {
                            Console.WriteLine("Número máximo alcançado: " + qtdCliente);
                        }

                        Console.Write("\nPressione qualquer tecla para voltar ao menu.");

                        //Aguarda o usuário pressionar qualquer tecla para continuar:
                        Console.ReadKey();
                        break;
                    case 2:
                        Console.WriteLine(" vazio ");
                        Console.ReadKey();
                        break;

                        Console.Write("\nPressione qualquer tecla para voltar ao menu.");

                        //Aguarda o usuário pressionar qualquer tecla para continuar:
                        Console.ReadKey();
                        break;
                    case 4:
                        Console.Title = " * SAIR * ";
                        Console.WriteLine("------------------");
                        Console.WriteLine("Saindo do Sistema");
                        Console.WriteLine("------------------");
                        Console.ReadKey();
                        break;

                    default: //executado quando o usuário escolhe uma opção que não existe
                        Console.Title = " * INVALIDO * ";
                        Console.WriteLine("---------------");
                        Console.WriteLine("Opção inválida!");
                        Console.WriteLine("---------------");
                        Console.Write("\nPressione qualquer tecla para voltar ao menu.");
                        //Aguarda o usuário pressionar qualquer tecla para continuar:
                        Console.ReadKey();
                        break;
                }
            } while (opcao != 4);
        }
        // Exibir Usuarios 
        public void ExibirUsuarios(string[,] pArray)
        {
            Console.WriteLine("---------");
            Console.WriteLine("Usuarios:");
            Console.WriteLine("---------");
            for (int i = 0; i < pArray.GetLength(0); i++)
            {

                for (int c = 0; c < pArray.GetLength(1); c++)
                {

                    switch (c)
                    {
                        case 0:
                            Console.Write("ID :" + pArray[i, c]);
                            break;
                        case 1:
                            Console.Write("Usuario: " + pArray[i, c]);
                            break;
                        case 2:
                            Console.Write("CPF: " + pArray[i, c]);
                            break;
                        case 3:
                            Console.Write("Cargo: " + pArray[i, c]);
                            break;
                    }
                }
            }
        }
    }
}
