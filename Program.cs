using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mercado2
{
    class Program
    {
        static void Main(string[] args)
        {

            MenuAll menu = new MenuAll();
            menu.Executar();
           // ClienteMenu cliente = new ClienteMenu();
          //  cliente.ExecutarClientes();

           // Menufornecedor menufornecedor = new Menufornecedor();
            //menufornecedor.ExecutarFornecedor();


            Console.ReadLine();//Manter o Prompt Aberto
        }//fim do método
    }//fim da classe
}//fim do projeto
