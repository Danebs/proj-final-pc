using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using LojaDeBebidas.lib;
using LojaDeBebidas.data;
using LojaDeBebidas.data.entidades;

namespace LojaDeBebidas.lib
{
    class Cashier
    {
        protected List<Product> CartProducts = new List<Product>(); 

        public void Menu()
        {
            UserModel UsersModel = new UserModel();
            ConsoleKey opcMenu = ConsoleKey.Enter;
            string cpfCliente;

            Console.Clear();
            UIComponents.PanelHeader("Caixa da Loja", "Cadastre aqui um cliente e  faça a venda de seus produtos...");
            // Solicitação de Cpf para buscar na matriz se o cliente está cadastrado
            Console.Write("\nPara iniciar uma sessão de compra, digite o cpf do cliente:");
            cpfCliente = Console.ReadLine();
            User client = UsersModel.FindByCpf(cpfCliente);
            // Estrutura para o cliente cadastrado e não cadastrado
            if (client != null)
            {
                Console.Clear();
                //informacao = InfoCliente(Cadastro, varBusca); // Array Recebendo o return do método que busca os dados do cliente pelo CPF
                // Exibindo os dados do cliente
                Console.WriteLine("|---------------------------------|");
                Console.WriteLine("| Dados do cliente :");    
                Console.WriteLine("|---------------------------------|");
                Console.WriteLine("| Código: {0}", client.Codigo);
                Console.WriteLine("| Nome: {0}", client.Nome);
                Console.WriteLine("| E-mail: {0}", client.Email);
                Console.WriteLine("| CPF: {0}", client.Cpf);
                Console.WriteLine("| Cidade: {0}", client.Cidade);
                //Console.WriteLine("| Telefone: {0}", client.Te);
                Console.WriteLine("\nOs dados estão corretos ? S - Sim | N - Não");

                if (Console.ReadKey().Key != ConsoleKey.N)
                {
                    UIComponents.Loader(750, 17, "Aguarde enquanto carregamos o caixa...", Application.AppTheme);
                    Thread.Sleep(1250);

                    do
                    {
                        opcMenu = ViewProducts();

                        switch (opcMenu)
                        {
                            case ConsoleKey.D1:
                            case ConsoleKey.NumPad1:
                                if (AddProduct())
                                    Console.WriteLine("Produto adicionado ao carrinho com sucesso!");
                                else
                                    Console.WriteLine("Não foi possível adicionar o produto!");
                                break;
                            case ConsoleKey.D2:
                            case ConsoleKey.NumPad2:

                                break;
                            case ConsoleKey.F9:
                                opcMenu = ConsoleKey.F9;
                                break;
                            default:
                                continue;
                        }

                    } while (opcMenu != ConsoleKey.F9);
                }
            }
            else // Caso o cliente não esteja cadastrado, esse "else" irá o direcionar para o cadastro de cliente.
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("\n\nCpf não encontrado, deseja cadastrar o cliente ? (s) - sim | (n) - não");
                Console.ResetColor();
            }

            Console.ReadKey();
        }

        //Método que retorna todas as informações de cadastro do cliente
        public string[] InfoCliente(string[,] pArray, string pBusc)
        {
            // Declaração de variáveis:
            bool ativ = false;
            int linha = 0;
            int numColunas = 0;

            //Percorre o Array e identifica qual a linha em que está localizado o cliente do cpf informado:
            for (int i = 0; i < pArray.GetLength(0); i++)
            {
                for (int c = 0; c < pArray.GetLength(1); c++)
                {
                    string t = pArray[i, c];
                    if (pBusc.Equals(t))
                    {
                        Console.WriteLine(t);
                        linha = i;
                    }
                    numColunas = c;
                }
            }

            // Array que receberá a linha de cadastro em que o cliente está localizado:
            string[] ArrayInfo = new string[numColunas + 1];

            for (int i = 0; i < ArrayInfo.Length; i++)
            {
                ArrayInfo[i] = pArray[linha, i];
            }

            return ArrayInfo;
        }
        // Método para Exibir lista de produtos para escolha do cliente.
        public ConsoleKey ViewProducts()
        {

            StockModel StockModel = new StockModel();

            Console.WriteLine("-------------------");
            Console.WriteLine(" Nossos Cardápio:");
            Console.WriteLine("-------------------");
            Console.WriteLine("|----------------------------------------------------------------------------------------|");
            Console.WriteLine("| CÓD | PRODUTO              | QTD | DESCRIÇÃO        | PREÇO                            |");
            Console.WriteLine("|----------------------------------------------------------------------------------------|");
            foreach (Product prod in StockModel.All())
            {
                Console.Write("| {0}  | {1}... | {2} | {3}... | {4} \n", prod.ID.ToString("D2"), prod.Name.Substring(0, 17), prod.Quantity.ToString("D3"), prod.Description.Substring(0, 15), prod.Price.ToString("C"));
            }
            Console.WriteLine("--------------------------------------------------------------------------------------");

            Console.WriteLine("Opções: \n(1) - Adicionar produto(s) | (2) - Ver meu carrinho | (F9) - Sair das compras");

            return Console.ReadKey().Key;
        }

        public bool AddProduct()
        {
            StockModel Stock = new StockModel();
            int cod, quantity = 0;

            Console.Write("Digite o código do produto desejado: ");
            cod = Convert.ToInt32(Console.ReadLine());
            Product prod = Stock.FindByID(cod);

            if (prod == null)
                return false;

            Console.Write("\nDigite a quantidade desejada: ");
            quantity = Convert.ToInt32(Console.ReadLine());


            return true;
        }
        public void ShowItem(Product product)
        {
            Console.WriteLine("---- Dados do Produto ----");
            Console.WriteLine("| CÓD: {0}", product.ID.ToString("D2"));
            Console.WriteLine("| Nome: {0}", product.Name);
            Console.WriteLine("| Descrição: {0}", product.Description);
            Console.WriteLine("| Preço: {0}", product.Price.ToString("C"));
            Console.WriteLine("| Quantidade: {0}", product.Quantity.ToString("D3"));
            Console.WriteLine("|--------------------------");

        }

        public void ViewCart()
        {

            Console.WriteLine("-------------------");
            Console.WriteLine(" Seu carrrinho:");
            Console.WriteLine("-------------------");
            Console.WriteLine("|------------------------------------------------------------------------------|");
            Console.WriteLine("| CÓD | PRODUTO              | QTD | Subtotal                                  |");
            Console.WriteLine("|------------------------------------------------------------------------------|");
            foreach (Product prod in CartProducts.ToArray())
            {
                Console.Write("| {0}  | {1}... | {2} | {3} \n", prod.ID.ToString("D2"), prod.Name.Substring(0, 17), prod.Quantity.ToString("D3"), prod.Description.Substring(0, 15), prod.Price.ToString("C"));
            }
            Console.WriteLine("--------------------------------------------------------------------------------------");
        }
    }
}
