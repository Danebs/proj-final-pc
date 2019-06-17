using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LojaDeBebidas.lib;

namespace LojaDeBebidas.lib
{
    class Financial
    {

        public void Menu()
        {
            Console.Clear();
            UIComponents.PanelHeader("Relatórios financeiros ", "Verifique suas financias para melhor gerenciamento de seu negócio.");
            Console.WriteLine("---------------------------------------------------");
            Console.WriteLine("--- Numero de Produtos: 0 ");
            Console.WriteLine("--- Vendas hoje: 0 ");
            Console.WriteLine("--- Caixa da loja:  R$2555.00");
            Console.WriteLine("---------------------------------------------------");
            UIComponents.PanelFooter();
            Console.ReadKey();
        }
    }
}
